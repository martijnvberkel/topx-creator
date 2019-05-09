using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Topx.Data;
using Topx.Data.DTO;
using Topx.DataServices;
using static Topx.Data.DTO.RIP;
using static Topx.Data.DTO.TopX;

namespace Topx.Creator
{
    public interface IParser
    {
        List<RIP.recordInformationPackage> ParseDataToTopx(List<Dossier> listOfDossiers, long maxBatchSize_bytes = 0);
    }

    public class Parser : IParser
    {
        private readonly Globals _globals;

        private readonly IDataService _dataservice;


        public List<string> ZaaknummerMarkForDelivered = new List<string>();
        public StringBuilder ErrorMessage = new StringBuilder();
        private string _identificatieArchief;
        private const string DateParsing = "d-M-yyyy";

        public Parser(Globals globals, IDataService dataservice)
        {
            _globals = globals;
            _dataservice = dataservice;
            _dataservice.ClearLog();
        }
        public List<RIP.recordInformationPackage> ParseDataToTopx(List<Dossier> listOfDossiers, long maxBatchSize_bytes = 0)
        {
            var resultRecordInformationPackages = new List<RIP.recordInformationPackage>();
            if (!TestHealthyGlobals())
            {
                return null;
            }
            _identificatieArchief = _globals.IdentificatieArchief;
            var datumArchief = _globals.DatumArchief;
            var omschrijvingArchief = _globals.OmschrijvingArchief;
            var bronArchief = _globals.BronArchief;
            var doelArchief = _globals.DoelArchief;
            var naamArchief = _globals.NaamArchief;



            long totalSize = 0;
            var rip = new recordInformationPackage()
            {
                record = RipArchief(_identificatieArchief, naamArchief)
            };

            foreach (var dossier in listOfDossiers)
            {

                try
                {
                    if (!dossier.Records.Any())
                    {
                        ErrorMessage.AppendLine($"Dossier {dossier.IdentificatieKenmerk}: Geen records gevonden");
                    }

                    if (string.IsNullOrEmpty(dossier.Naam))
                    {
                        ErrorMessage.AppendLine($"Dossier {dossier.IdentificatieKenmerk}: Veld Naam is leeg");
                    }

                    if (!ValidateDossier(dossier))
                        continue;

                    rip.record.Add(RipBeschikkingAsDossier(dossier));

                    foreach (var record in dossier.Records)
                    {
                        rip.record.Add(RipOobjectAsRecord(dossier, record, $"{dossier.IdentificatieKenmerk}_{Path.GetFileNameWithoutExtension(record.Bestand_Formaat_Bestandsnaam)}"));
                        rip.record.Add(RipObjectAsBestand(record));
                    }
                }
                catch (Exception ex)
                {
                    _dataservice.Log(dossier.IdentificatieKenmerk, $"ERROR: {ex.Message}");
                    ErrorMessage.AppendLine($"Dossier {dossier.IdentificatieKenmerk}: ERROR: { ex.Message}");
                }

                var sizeOfDossier = dossier.Records.Sum(record => record.Bestand_Formaat_BestandsOmvang ?? 0);
                totalSize += sizeOfDossier;

                if (maxBatchSize_bytes > 0 && totalSize + sizeOfDossier > maxBatchSize_bytes)  // Maxsize batch is bereikt
                {
                    // Clone rip 

                    resultRecordInformationPackages.Add(new recordInformationPackage()
                    {
                        packageHeader = RipHeader(_identificatieArchief, (DateTime)datumArchief, omschrijvingArchief, bronArchief, doelArchief),
                       record = rip.record
                    });

                    totalSize = 0;

                    // Clear rip voor de volgende batch
                    rip = new RIP.recordInformationPackage() { record = RipArchief(_identificatieArchief, naamArchief) };
                }
            }

            resultRecordInformationPackages.Add(new recordInformationPackage()
            {
                packageHeader = RipHeader(_identificatieArchief, (DateTime)datumArchief, omschrijvingArchief, bronArchief, doelArchief),
                record = rip.record
            });
            return resultRecordInformationPackages;
        }

        private bool TestHealthyGlobals()
        {
            var error = false;
            if (string.IsNullOrEmpty(_globals.BronArchief))
            {
                ErrorMessage.AppendLine("Bron Archief mag niet leeg zijn");
                error = true;
            }
            if (string.IsNullOrEmpty(_globals.DoelArchief))
            {
                ErrorMessage.AppendLine("Doel Archief mag niet leeg zijn");
                error = true;
            }
            if (string.IsNullOrEmpty(_globals.IdentificatieArchief))
            {
                ErrorMessage.AppendLine("Identificatie Archief mag niet leeg zijn");
                error = true;
            }
            if (string.IsNullOrEmpty(_globals.NaamArchief))
            {
                ErrorMessage.AppendLine("Naam Archief mag niet leeg zijn");
                error = true;
            }
            if (_globals.DatumArchief == null)
            {
                ErrorMessage.AppendLine("Datum Archief mag niet leeg zijn");
                error = true;
            }
            return !error;

        }

        private bool ValidateDossier(Dossier dossier)
        {
            var localErrormessage = new StringBuilder();
            foreach (var record in dossier.Records)
            {
                if (string.IsNullOrEmpty(record.Bestand_Formaat_BestandsFormaat))
                    localErrormessage.AppendLine($"Dossier: {dossier.IdentificatieKenmerk}: Bestand_Formaat_BestandsFormaat is leeg");
                if (string.IsNullOrEmpty(record.Bestand_Formaat_Bestandsnaam))
                    localErrormessage.AppendLine($"Dossier: {dossier.IdentificatieKenmerk}: Bestand_Formaat_Bestandsnaam is leeg");
                if (string.IsNullOrEmpty(record.Bestand_Formaat_FysiekeIntegriteit_Algoritme))
                    localErrormessage.AppendLine($"Dossier: {dossier.IdentificatieKenmerk}: Bestand_Formaat_FysiekeIntegriteit_Algoritme is leeg");
                if (string.IsNullOrEmpty(record.Bestand_Formaat_FysiekeIntegriteit_Waarde))
                    localErrormessage.AppendLine($"Dossier: {dossier.IdentificatieKenmerk}: Bestand_Formaat_FysiekeIntegriteit_Waarde is leeg");
                if (string.IsNullOrEmpty(record.Bestand_Vorm_Redactiegenre))
                    localErrormessage.AppendLine($"Dossier: {dossier.IdentificatieKenmerk}: Bestand_Vorm_Redactiegenre is leeg");
                if (record.Bestand_Formaat_BestandsOmvang == null || record.Bestand_Formaat_BestandsOmvang == 0)
                    localErrormessage.AppendLine($"Dossier: {dossier.IdentificatieKenmerk}: Bestand_Formaat_BestandsOmvang is leeg of 0. Mogelijk moet de metadata nog worden aangevuld met een scan van de fysieke bestanden");
            }
            if (localErrormessage.Length == 0)
                return true;
            ErrorMessage.AppendLine(localErrormessage.ToString());
            return false;
        }


        private RIP.ripRecordType RipOobjectAsRecord(Dossier dossier, Record record, string identificatieKenmerk)
        {
            //var identificatie = dossierId + "_FILE_" + count;
            var riprecordType = new RIP.ripRecordType()
            {
                recordHeader = new RIP.ripRecordHeaderType()
                {
                    identificatie = identificatieKenmerk,
                },
                metadata = new[] {new  RIP.ripMetadataType()
                {
                    schemaURI = "topx",
                    Any = ConvertTopxToXmlElement(GetRecordAsTopx(dossier, record, identificatieKenmerk))
                }}
            };
            return riprecordType;
        }

        private TopX.topxType GetRecordAsTopx(Dossier dossier, Record record, string identificatieKenmerk)
        {

            var eventgeschiedenis_DatumOfPeriode = DateTime.ParseExact(dossier.Eventgeschiedenis_DatumOfPeriode, DateParsing, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

            var relatie_DatumOfPeriode = dossier.Relatie_DatumOfPeriode ?? record.Bestand_Formaat_DatumAanmaak?.ToString("yyyy-MM-dd"); ;

            var vertrouwelijkheid_DatumOfPeriode = DateTime.ParseExact(record.Vertrouwelijkheid_DatumOfPeriode, DateParsing, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

            var gebruiksrechten_DatumOfPeriode = DateTime.ParseExact(record.Gebruiksrechten_DatumOfPeriode, DateParsing, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");


           var relatie = new[]
            {
                new TopX.relatieType()
                {
                    relatieID = new TopX.nonEmptyStringTypeAttribuut() {Value = dossier.IdentificatieKenmerk},
                    typeRelatie = new TopX.nonEmptyStringTypeAttribuut() {Value = dossier.Relatie_Type ?? "Hiërachisch" },
                    datumOfPeriode = new datumOfPeriodeType()
                    {
                        datum = relatie_DatumOfPeriode
                    },
                }
            };
            var topx = new topxType
            {
                Item = new aggregatieType()
                {
                    identificatiekenmerk = new nonEmptyStringTypeAttribuut() { Value = identificatieKenmerk },
                    
                    eventGeschiedenis = new eventGeschiedenisType[] { new eventGeschiedenisType() {datumOfPeriode = new datumOfPeriodeType()
                        { datum = eventgeschiedenis_DatumOfPeriode },
                        type = new nonEmptyStringTypeAttribuut() {Value = dossier.Eventgeschiedenis_Type} ,
                        verantwoordelijkeFunctionaris = new nonEmptyStringTypeAttribuut() {Value = dossier.Eventgeschiedenis_VerantwoordelijkeFunctionaris}  } },

                    aggregatieniveau = new aggregatieTypeAggregatieniveau()
                    {
                        Value = aggregatieAggregatieniveauType.Record
                    },
                    naam = new[] { new nonEmptyStringTypeAttribuut() { Value = dossier.Naam } },
                    taal = new taalTypeAttribuut[] { new taalTypeAttribuut() { Value = (taalType)Enum.Parse(typeof(taalType), dossier.Taal.ToLower()) } },
                  //  taal = new[] { new taalTypeAttribuut() { Value = taalType.dut } },
                    relatie = relatie,
                    vertrouwelijkheid = new vertrouwelijkheidType[]
                    {
                        new vertrouwelijkheidType()
                        {
                            classificatieNiveau = new vertrouwelijkheidTypeClassificatieNiveau()
                            {
                                Value = classificatieNiveauType.Nietvertrouwelijk
                            },
                            datumOfPeriode = new datumOfPeriodeType()
                            {
                                datum = vertrouwelijkheid_DatumOfPeriode
                            }
                        }
                    },
                    openbaarheid = GetOpenbaarheid(record)
                    ,
                    gebruiksrechten = new gebruiksrechtenType[]
                    {
                        new gebruiksrechtenType()
                        {
                            omschrijvingVoorwaarden =new nonEmptyStringTypeAttribuut()
                            {
                                Value = record.Gebruiksrechten_OmschrijvingVoorwaarden,
                            },
                                datumOfPeriode = new datumOfPeriodeType()
                            {
                                datum = gebruiksrechten_DatumOfPeriode
                            }
                        }
                    }
                }
            };
            return topx;
        }



        private openbaarheidType[] GetOpenbaarheid(Record record)
        {
            if (string.IsNullOrEmpty(record.Openbaarheid_DatumOfPeriode))
            {
                throw new Exception("Openbaarheid_DatumOfPeriode mag niet leeg zijn");
            }

            var openbaarheid_DatumOfPeriode = DateTime.ParseExact(record.Openbaarheid_DatumOfPeriode, DateParsing, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

            if (!string.IsNullOrEmpty(record.Openbaarheid_OmschrijvingBeperkingen))
            {
                return new[]
                {
                    new openbaarheidType()
                    {
                        omschrijvingBeperkingen = new[]
                        {
                            new nonEmptyStringTypeAttribuut() {Value = record.Openbaarheid_OmschrijvingBeperkingen}
                        },
                        datumOfPeriode = new datumOfPeriodeType()
                        {
                            //jaar = source.Jaar
                            datum = openbaarheid_DatumOfPeriode
                        }
                    }
                };
            }

            _dataservice.Log(record.DossierId, "Openbaarheid_OmschrijvingBeperkingen mag niet leeg zijn");
            return new[] {new openbaarheidType()
            {
                omschrijvingBeperkingen = new[]
                {
                    new nonEmptyStringTypeAttribuut() {Value = "ERROR - Openbaar kolom niet ingevuld"}
                }
            } };
        }

        private RIP.ripRecordType RipObjectAsBestand(Record record)
        {
            var identificatieKenmerkBestand = Path.GetFileNameWithoutExtension(record.Bestand_Formaat_Bestandsnaam);
            var riprecordType = new RIP.ripRecordType()
            {
                recordHeader = new RIP.ripRecordHeaderType()
                {
                    identificatie = identificatieKenmerkBestand,

                },
                metadata = new[] {new  RIP.ripMetadataType()
                {
                    schemaURI = "topx",

                    Any = ConvertTopxToXmlElement(GetBestandAsTopx(record))
                }}
            };
            return riprecordType;
        }

        private topxType GetBestandAsTopx(Record record)
        {

            DateTime gemaaktOp;
            var identificatieKenmerkBestand = Path.GetFileNameWithoutExtension(record.Bestand_Formaat_Bestandsnaam);
            var relatieKenmerkBestand = $"{record.DossierId}_{identificatieKenmerkBestand}";

            var openbaarheid_DatumOfPeriode = DateTime.ParseExact(record.Openbaarheid_DatumOfPeriode,
                DateParsing, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            
            var topx = new topxType
            {
                Item = new bestandType()
                {
                    identificatiekenmerk = new nonEmptyStringTypeAttribuut() { Value = identificatieKenmerkBestand },
                    aggregatieniveau = new bestandTypeAggregatieniveau()
                    {
                        Value = bestandAggregatieniveauType.Bestand
                    },
                    naam = new[] { new nonEmptyStringTypeAttribuut() { Value = record.Naam } },
                    //plaats = new @string() { Value = "storage location" },
                    relatie = new[]
                    {
                            new relatieType()
                            {
                                relatieID = new nonEmptyStringTypeAttribuut() {Value = relatieKenmerkBestand},
                                typeRelatie = new nonEmptyStringTypeAttribuut() {Value = record.Relatie_TypeRelatie ?? "Hiërarchisch"},
                                datumOfPeriode = new datumOfPeriodeType()
                                {
                                    datum = record.Bestand_Formaat_DatumAanmaak?.ToString("yyyy-MM-dd")
                                },
                            }
                        },
                  
                    openbaarheid = new openbaarheidType[]
                    {
                        new openbaarheidType()
                        {
                            omschrijvingBeperkingen = new nonEmptyStringTypeAttribuut[]
                            {
                                new nonEmptyStringTypeAttribuut() {Value = record.Openbaarheid_OmschrijvingBeperkingen }
                            },
                            datumOfPeriode = new datumOfPeriodeType()
                            {
                                datum = openbaarheid_DatumOfPeriode
                            }
                        }
                    },
                    vorm = new vormType()
                    {
                        redactieGenre = new @string() { Value = record.Bestand_Vorm_Redactiegenre },
                    },
                    formaat = new[]
                    {
                            new formaatType()
                            {
                                identificatiekenmerk = new nonEmptyStringTypeAttribuut() {Value = identificatieKenmerkBestand},
                                bestandsnaam = new bestandsnaamType()
                                {
                                    naam = new nonEmptyStringTypeAttribuut() {Value = identificatieKenmerkBestand},
                                    extensie = new @string() {Value = Path.GetExtension(record.Bestand_Formaat_Bestandsnaam).Substring(1)} // skip the dot
                                },
                                omvang = new formaatTypeOmvang() {Value = record.Bestand_Formaat_BestandsOmvang.ToString()},
                                //bestandsformaat = new @string() {Value = "fmt/18"},
                                bestandsformaat = new @string() {Value = record.Bestand_Formaat_BestandsFormaat},
                                fysiekeIntegriteit = new fysiekeIntegriteitType()
                                {
                                    algoritme = new nonEmptyStringTypeAttribuut() {Value = record.Bestand_Formaat_FysiekeIntegriteit_Algoritme},
                                    waarde = new nonEmptyStringTypeAttribuut() {Value = record.Bestand_Formaat_FysiekeIntegriteit_Waarde},
                                    datumEnTijd = new fysiekeIntegriteitTypeDatumEnTijd() {Value = record.Bestand_Formaat_FysiekeIntegriteit_DatumEnTijd ?? DateTime.MinValue}
                                },
                                datumAanmaak = new formaatTypeDatumAanmaak()
                                {
                                    Value = record.Bestand_Formaat_DatumAanmaak?.ToString("yyyy-MM-dd")
                                }
                            },
                        }
                }
            };


            return topx;
        }


        private RIP.ripRecordType RipBeschikkingAsDossier(Dossier dossier)
        {

            var riprecordType = new RIP.ripRecordType()
            {
                recordHeader = new RIP.ripRecordHeaderType()
                {
                    identificatie = dossier.IdentificatieKenmerk
                    //omschrijving = new[] { source.C19_1_DN_Tabnaam },
                    //status = ripRecordStatusType.gewijzigd
                },
                metadata = new[] {new  RIP.ripMetadataType()
                {
                    schemaURI = "topx",
                    Any = ConvertTopxToXmlElement(GetDossierAsTopx(dossier))
                }}
            };
            return riprecordType;
        }


        private RIP.packageHeaderType RipHeader(string identificatie, DateTime datum, string omschrijving, string bron, string doel)
        {
            return new RIP.packageHeaderType()
            {
                identificatie = identificatie,
                datum = datum,
                omschrijving = new[] { omschrijving },
                bron = bron,
                doel = doel
            };
        }

        private List<RIP.ripRecordType> RipArchief(string archiefId, string naamArchief)
        {
            var result = new List<RIP.ripRecordType>();
            result.Add(
                new RIP.ripRecordType()
                {
                    recordHeader = new RIP.ripRecordHeaderType()
                    {
                        identificatie = archiefId
                    },
                    metadata = new[] {new  RIP.ripMetadataType()
                    {
                        schemaURI = "topx",
                        Any = ConvertTopxToXmlElement( GetTopxArchiefNiveau(archiefId, naamArchief))
                    }}
                }
            );
            return result;
        }

        private XmlElement[] ConvertTopxToXmlElement(topxType topx)
        {
            XmlDocument doc = new XmlDocument();

            using (XmlWriter writer = doc.CreateNavigator().AppendChild())
            {
                new System.Xml.Serialization.XmlSerializer(topx.GetType()).Serialize(writer, topx);
            }

            return new[] { doc.DocumentElement };
        }
        private topxType GetTopxArchiefNiveau(string archiefId, string naamArchief)
        {
            var topx = new topxType()
            {
                Item = new aggregatieType()
                {
                    identificatiekenmerk = new nonEmptyStringTypeAttribuut() { Value = archiefId },
                    aggregatieniveau = new aggregatieTypeAggregatieniveau() { Value = aggregatieAggregatieniveauType.Archief },
                    naam = new[] { new nonEmptyStringTypeAttribuut() { Value = naamArchief } }
                }
            };

            return topx;

        }

        private topxType GetDossierAsTopx(Dossier dossier)
        {


            var topx = new topxType();
            //var identificatiekenmerkTemp = source.C2_dn_Bestand.Split("-"[0]);
            var identificatiekenmerk = dossier.IdentificatieKenmerk;

            var eventgeschiedenis_DatumOfPeriode = string.IsNullOrEmpty(dossier.Eventgeschiedenis_DatumOfPeriode)
                ? "ERROR - ONBEKEND"
                : DateTime.ParseExact(dossier.Eventgeschiedenis_DatumOfPeriode,
                    DateParsing, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

            var relatie_DatumOfPeriode = dossier.Relatie_DatumOfPeriode != null
                ? DateTime.ParseExact(dossier.Relatie_DatumOfPeriode,
                    DateParsing, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd")
                : dossier.Records.FirstOrDefault()?.Bestand_Formaat_DatumAanmaak?.ToString("yyyy-MM-dd");

            var openbaarheid_DatumOfPeriode = DateTime.ParseExact(dossier.Openbaarheid_DatumOfPeriode,
                DateParsing, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

            var omschrijving = new @string[] { new @string()};
            omschrijving[0].Value = dossier.Omschrijving;

            string gebruiksrechten_DatumOfPeriode = string.Empty;
            if (string.IsNullOrEmpty(dossier.Gebruiksrechten_DatumOfPeriode))
            {
                ErrorMessage.Append($"{dossier.IdentificatieKenmerk}: Gebruiksrechten_DatumOfPeriode mag niet leeg zijn");
            }
            else
                gebruiksrechten_DatumOfPeriode = DateTime.ParseExact(dossier.Gebruiksrechten_DatumOfPeriode, DateParsing, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");


            var vertrouwelijkheid_DatumOfPeriode = DateTime.ParseExact(dossier.Vertrouwelijkheid_DatumOfPeriode, DateParsing, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

            var dekking_InTijd_Begin = new datumOfJaarTypeDatum()
            {
                Value = Convert.ToDateTime(DateTime.ParseExact(dossier.Dekking_InTijd_Begin,
                    DateParsing, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"))
            };

            var dekking_InTijd_Eind = new datumOfJaarTypeDatum()
            {
                Value = Convert.ToDateTime(DateTime.ParseExact(dossier.Dekking_InTijd_Eind,
                    DateParsing, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"))
            };

            var dekking_geografischgebied = dossier.Dekking_GeografischGebied.Split(',').Select(dekking => new @string() {Value = dekking.Trim()}).ToArray();

            topx.Item = new aggregatieType()
            {
                identificatiekenmerk = new nonEmptyStringTypeAttribuut() { Value = identificatiekenmerk },
                omschrijving = omschrijving,
                aggregatieniveau = new aggregatieTypeAggregatieniveau()
                {
                    Value = aggregatieAggregatieniveauType.Dossier

                },
                eventGeschiedenis = new eventGeschiedenisType[] { new eventGeschiedenisType() {datumOfPeriode = new datumOfPeriodeType()
                    {
                        datum = eventgeschiedenis_DatumOfPeriode
                    },
                    type = new nonEmptyStringTypeAttribuut() {Value = dossier.Eventgeschiedenis_Type} ,
                    verantwoordelijkeFunctionaris = new nonEmptyStringTypeAttribuut() {Value = dossier.Eventgeschiedenis_VerantwoordelijkeFunctionaris}  }
                },

                naam = new[] { new nonEmptyStringTypeAttribuut() { Value = dossier.Naam } },
               // taal = new taalTypeAttribuut[] { new taalTypeAttribuut() { Value = (taalType)Enum.Parse(typeof(taalType), dossier.Taal.ToLower()) } },
                relatie = new[] {new relatieType()
                {
                    relatieID = new nonEmptyStringTypeAttribuut() {Value = _identificatieArchief },
                    typeRelatie = new nonEmptyStringTypeAttribuut() {Value = dossier.Relatie_Type == null ? "Hiërarchisch" : dossier.Relatie_Type},
                    datumOfPeriode = new datumOfPeriodeType() {
                        datum = relatie_DatumOfPeriode
                    },

                }},
                classificatie = new[] {new classificatieType()
                    {
                        code = new nonEmptyStringTypeAttribuut() { Value = dossier.Classificatie_Code},
                        omschrijving =  new nonEmptyStringTypeAttribuut() {Value = dossier.Classificatie_Omschrijving},
                        bron = new nonEmptyStringTypeAttribuut() {Value = dossier.Classificatie_Bron},
                        datumOfPeriode = new datumOfPeriodeType()
                        {
                            jaar = GetYearFromDatumOfPeriode(dossier.Classificatie_DatumOfPeriode)
                        }

                    },

                },
                vertrouwelijkheid = new vertrouwelijkheidType[]
                {
                    new vertrouwelijkheidType()
                    {
                        classificatieNiveau = new vertrouwelijkheidTypeClassificatieNiveau()
                        {
                            Value = (classificatieNiveauType) Enum.Parse(typeof(classificatieNiveauType), Regex.Replace(dossier.Vertrouwelijkheid_ClassificatieNiveau, @"\s+", "") )
                        },
                        datumOfPeriode = new datumOfPeriodeType()
                        {
                            datum = vertrouwelijkheid_DatumOfPeriode
                        }
                    }
                },
                openbaarheid = new openbaarheidType[]
                {
                    new openbaarheidType()
                    {
                        omschrijvingBeperkingen = new nonEmptyStringTypeAttribuut[]
                        {
                            new nonEmptyStringTypeAttribuut() {Value = dossier.Openbaarheid_OmschrijvingBeperkingen }
                        },
                        datumOfPeriode = new datumOfPeriodeType()
                        {
                            datum = openbaarheid_DatumOfPeriode
                        }
                    }
                },
                dekking = new dekkingType[] {new dekkingType()
                    {
                        inTijd = new periodeType()
                        {
                            begin = new datumOfJaarType()
                            {
                                Item = dekking_InTijd_Begin
                            },
                            eind = new datumOfJaarType()
                            {
                                Item = dekking_InTijd_Eind
                            }

                        },
                        geografischGebied = dekking_geografischgebied,

                    }
                },
                context = new contextType()
                {
                    actor = new[]
                    {
                        new actorType()
                        {
                            identificatiekenmerk = new nonEmptyStringTypeAttribuut() {Value =dossier.Context_Actor_IdentificatieKenmerk},
                            aggregatieniveau = new @string() { Value= dossier.Context_Actor_AggregatieNiveau },
                            geautoriseerdeNaam = new nonEmptyStringTypeAttribuut() {Value = dossier.Context_Actor_GeautoriseerdeNaam }
                        }
                    },
                    activiteit = new[]
                    {
                        new activiteitType()
                        {
                            naam = new nonEmptyStringTypeAttribuut() { Value = dossier.Context_Activiteit_Naam }
                        }
                    }

                },
                gebruiksrechten = new gebruiksrechtenType[]
                {
                    new gebruiksrechtenType()
                    {
                        omschrijvingVoorwaarden = new nonEmptyStringTypeAttribuut() {Value = dossier.Gebruiksrechten_OmschrijvingVoorwaarden },
                        datumOfPeriode = new datumOfPeriodeType()
                        {
                            datum = gebruiksrechten_DatumOfPeriode
                        }
                    }
                },
                integriteit = new @string() { Value = dossier.Integriteit }
            };
            return topx;
        }

        private string GetYearFromDatumOfPeriode(string dossierClassificatieDatumOfPeriode)
        {
            var regex = new Regex(@"\d{4}");
            return regex.Match(dossierClassificatieDatumOfPeriode).Value;
        }
    }
}
