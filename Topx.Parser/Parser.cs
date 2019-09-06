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
using Topx.Utility;
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

        public StringBuilder ErrorMessage = new StringBuilder();
        private string _identificatieArchief;
        private const string DateParsing = "d-M-yyyy";

        public Parser(Globals globals, IDataService dataservice)
        {
            _globals = globals;
            _dataservice = dataservice;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listOfDossiers"></param>
        /// <param name="maxBatchSize_bytes"></param>
        /// <returns> List recordInformationPackage: Is het complete TopX objectmodel, serializable naar xml</returns>
        public List<RIP.recordInformationPackage> ParseDataToTopx(List<Dossier> listOfDossiers, long maxBatchSize_bytes = 0)
        {
            var resultRecordInformationPackages = new List<RIP.recordInformationPackage>();
            if (!TestHealthyGlobals())
                return null;

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
                        ErrorMessage.AppendLine($"Dossier {dossier.IdentificatieKenmerk}: Geen records gevonden");

                    if (string.IsNullOrEmpty(dossier.Naam))
                        ErrorMessage.AppendLine($"Dossier {dossier.IdentificatieKenmerk}: Veld Naam is leeg");

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

                if (maxBatchSize_bytes > 0 && totalSize * 1.2 > maxBatchSize_bytes)  // Maxsize batch is bereikt, hou marge van 20%
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dossier"></param>
        /// <param name="record"></param>
        /// <param name="identificatieKenmerk"></param>
        /// <returns>(RIP) record-object voor xml-serialization</returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dossier"></param>
        /// <param name="record"></param>
        /// <param name="identificatieKenmerk"></param>
        /// <returns>Record-fragment voor xml-serialization</returns>
        private TopX.topxType GetRecordAsTopx(Dossier dossier, Record record, string identificatieKenmerk)
        {

            var eventgeschiedenis_DatumOfPeriode = DateTime.ParseExact(dossier.Eventgeschiedenis_DatumOfPeriode, DateParsing, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

            var relatie_DatumOfPeriode = dossier.Relatie_DatumOfPeriode ?? record.Bestand_Formaat_DatumAanmaak?.ToString("yyyy-MM-dd"); ;

            var vertrouwelijkheid_DatumOfPeriode = DateTime.ParseExact(record.Vertrouwelijkheid_DatumOfPeriode, DateParsing, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

            if (!Enum.TryParse(record.Vertrouwelijkheid_ClassificatieNiveau.RemoveSpaces(), out classificatieNiveauType classificatieNiveauType))
            {
                ErrorMessage.AppendLine(
                    $"ERROR: record naam: {record.Naam}: Het classificatieniveau {record.Vertrouwelijkheid_ClassificatieNiveau} is niet herkend als geldige waarde.");
            }

            var gebruiksrechten_DatumOfPeriode = DateTime.ParseExact(record.Gebruiksrechten_DatumOfPeriode, DateParsing, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");


            var relatie = new[]
             {
                new TopX.relatieType()
                {
                    relatieID = new TopX.nonEmptyStringTypeAttribuut() {Value = dossier.IdentificatieKenmerk},
                    typeRelatie = new TopX.nonEmptyStringTypeAttribuut() {Value = dossier.Relatie_Type ?? "Hiërarchisch" },
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
                    naam = new[] { new nonEmptyStringTypeAttribuut() { Value = record.Naam } },
                    taal = new taalTypeAttribuut[] { new taalTypeAttribuut() { Value = (taalType)Enum.Parse(typeof(taalType), dossier.Taal.ToLower()) } },
                    //  taal = new[] { new taalTypeAttribuut() { Value = taalType.dut } },
                    relatie = relatie,
                    vertrouwelijkheid = new vertrouwelijkheidType[]
                    {
                        new vertrouwelijkheidType()
                        {
                            classificatieNiveau = new vertrouwelijkheidTypeClassificatieNiveau()
                            {
                                Value = classificatieNiveauType
                            },
                            datumOfPeriode = new datumOfPeriodeType()
                            {
                                datum = vertrouwelijkheid_DatumOfPeriode
                            }
                        }
                    },
                    openbaarheid = GetOpenbaarheid(record.Bestand_Formaat_Bestandsnaam, record.Openbaarheid_OmschrijvingBeperkingen, record.Openbaarheid_DatumOfPeriode)
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

        private openbaarheidType[] GetOpenbaarheid(string id, string openbaarheid_omschrijvingbeperkingen, string openbaarheid_datumofperiode)
        {
            if (string.IsNullOrEmpty(openbaarheid_datumofperiode))
                throw new Exception($"{id} Openbaarheid_DatumOfPeriode mag niet leeg zijn");

            if (string.IsNullOrEmpty(openbaarheid_omschrijvingbeperkingen))
                throw new Exception($"{id} Openbaarheid_OmschrijvingBeperkingen mag niet leeg zijn");

            var arrDatumsOfPeriodes = openbaarheid_datumofperiode.RemoveSpaces().Split('|');
            var arrOmschrijvingBeperkingen = openbaarheid_omschrijvingbeperkingen.Split('|').Select(t => t.Trim()).ToArray();


            if (arrDatumsOfPeriodes.Length != arrOmschrijvingBeperkingen.Length)
                throw new Exception($"{id}: Aantal Openbaarheid_DatumOfPeriode {openbaarheid_datumofperiode} en Openbaarheid_OmschrijvingBeperkingen {openbaarheid_omschrijvingbeperkingen} komen niet overeen");

            var openbaarheidstypen = new List<openbaarheidType>();
            for (var index = 0; index < arrDatumsOfPeriodes.Length; index++)
            {
                var openbaarheid_DatumOfPeriode = DateTime.ParseExact(arrDatumsOfPeriodes[index], DateParsing, CultureInfo.InvariantCulture);

                if (!string.IsNullOrEmpty(arrOmschrijvingBeperkingen[index]))
                {

                    datumOfPeriodeType datumOfPeriode;

                    // Wanneer maar 1 entry (dus in de meeste gevallen), OF als de laatste entry van een collectie is gehaald, geef dan geen periode aan
                    if (index == arrDatumsOfPeriodes.Length - 1)
                        datumOfPeriode = new datumOfPeriodeType()
                        {
                            datum = openbaarheid_DatumOfPeriode.ToString("yyyy-MM-dd")
                        };
                    else // dus wel een periode aangeven
                    {
                        var openbaarheid_DatumOfPeriode_Eind = DateTime.ParseExact(arrDatumsOfPeriodes[index + 1], DateParsing, CultureInfo.InvariantCulture).AddDays(-1);
                        datumOfPeriode = new datumOfPeriodeType()
                        {
                            periode = new periodeType()
                            {
                                begin = new datumOfJaarType()
                                {
                                    Item = new datumOfJaarTypeDatum() { Value = openbaarheid_DatumOfPeriode },
                                },
                                eind = new datumOfJaarType()
                                {
                                    Item = new datumOfJaarTypeDatum() { Value = openbaarheid_DatumOfPeriode_Eind }
                                }
                            }
                        };
                    }

                    openbaarheidstypen.Add(
                        new openbaarheidType()
                        {
                            omschrijvingBeperkingen = new[]
                            {
                                new nonEmptyStringTypeAttribuut() {Value = arrOmschrijvingBeperkingen[index]}
                            },
                            datumOfPeriode = datumOfPeriode
                        });
                }
            };
            return openbaarheidstypen.ToArray();
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

            var identificatieKenmerkBestand = Path.GetFileNameWithoutExtension(record.Bestand_Formaat_Bestandsnaam);
            var relatieKenmerkBestand = $"{record.DossierId}_{identificatieKenmerkBestand}";

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

                    // openbaarheid = GetOpenbaarheid(record.Bestand_Formaat_Bestandsnaam, record.Openbaarheid_OmschrijvingBeperkingen, record.Openbaarheid_DatumOfPeriode),

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
            var result = new List<RIP.ripRecordType>
            {
                new RIP.ripRecordType()
                {
                    recordHeader = new RIP.ripRecordHeaderType() {identificatie = archiefId},
                    metadata = new[]
                    {
                        new RIP.ripMetadataType()
                        {
                            schemaURI = "topx",
                            Any = ConvertTopxToXmlElement(GetTopxArchiefNiveau(archiefId, naamArchief))
                        }
                    }
                }
            };
            return result;
        }

        private XmlElement[] ConvertTopxToXmlElement(topxType topx)
        {
            var doc = new XmlDocument();

            using (var writer = doc.CreateNavigator().AppendChild())
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
            var identificatiekenmerk = dossier.IdentificatieKenmerk;

            var eventgeschiedenis_DatumOfPeriode = string.IsNullOrEmpty(dossier.Eventgeschiedenis_DatumOfPeriode)
                ? "ERROR - ONBEKEND"
                : DateTime.ParseExact(dossier.Eventgeschiedenis_DatumOfPeriode,
                    DateParsing, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

            var relatie_DatumOfPeriode = dossier.Relatie_DatumOfPeriode != null
                ? DateTime.ParseExact(dossier.Relatie_DatumOfPeriode,
                    DateParsing, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd")
                : dossier.Records.FirstOrDefault()?.Bestand_Formaat_DatumAanmaak?.ToString("yyyy-MM-dd");

            var openbaarheid = GetOpenbaarheid(dossier.IdentificatieKenmerk,
                dossier.Openbaarheid_OmschrijvingBeperkingen, dossier.Openbaarheid_DatumOfPeriode);

            var omschrijving = new @string[] { new @string() };
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

            var dekking_geografischgebied = dossier.Dekking_GeografischGebied.Split('|').Select(dekking => new @string() { Value = dekking.Trim() }).ToArray();

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
                openbaarheid = openbaarheid,
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
