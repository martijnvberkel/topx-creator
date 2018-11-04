using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Topx.Data;
using Topx.Parser.Model;
using Topx.Utility;

namespace Topx.Creator
{
    public class Parser
    {
        public recordInformationPackage Rip;
        public List<string> ZaaknummerMarkForDelivered = new List<string>();
        public StringBuilder ErrorMessage = new StringBuilder();
        private string _identificatieArchief;
        private const string DateParsing = "d-M-yyyy";
        private const string DateTimeParsing = "d-M-yyyy H:m";

        public Parser()
        {
            Logger.ClearLog();
        }
        public recordInformationPackage ParseDataToTopx(int nrOfRecords = 0)
        {
            using (var entities = new ModelTopX())
            {
                _identificatieArchief = "NL-0784-10009";
                var datumArchief = Convert.ToDateTime(DateTime.Today);
                var omschrijvingArchief = "Bouwvergunningen Test ABG";
                var bronArchief = "Digitale bouwvergunningen";
                var doelArchief = "Bouwvergunningen om op te nemen in e-Depot";
                var naamArchief = omschrijvingArchief;

                //var identificatieArchief = "NL-0779-10001";
                //var datumArchief = Convert.ToDateTime(DateTime.Today);
                //var omschrijvingArchief = "Bouwvergunningen Gemeente Geertruidenberg 1928 - 1975";
                //var bronArchief = "Digitale bouwvergunningen";
                //var doelArchief = "Bouwvergunningen om op te nemen in e-Depot";
                //var naamArchief = "Bouwvergunningen Gemeente Geertruidenberg 1928 - 1975";
                Rip = new recordInformationPackage()
                {
                    packageHeader =
                        RipHeader(_identificatieArchief, datumArchief, omschrijvingArchief, bronArchief, doelArchief),
                    record = RipArchief(_identificatieArchief, naamArchief)
                };

                var listOfDossiers = from d in entities.Dossiers select d;
                var recordCounter = 0;
                foreach (var dossier in listOfDossiers)
                {
                    try
                    {
                        if (!dossier.Records.Any())
                        {
                            Logger.Log(dossier.IdentificatieKenmerk, "Geen records gevonden");
                        }

                        if (string.IsNullOrEmpty(dossier.Naam))
                        {
                            Logger.Log(dossier.IdentificatieKenmerk, "Veld Naam is leeg");
                        }

                        ValidateDossier(dossier);

                        Rip.record.Add(RipBeschikkingAsDossier(dossier));
                      
                        //Rip.record.Add(RipOobjectAsDoc(dossier, dossier.IdentificatieKenmerk));

                        foreach (var record in dossier.Records)
                        {
                            Rip.record.Add(RipOobjectAsDoc(dossier, $"{dossier.IdentificatieKenmerk}_{Path.GetFileNameWithoutExtension(record.Bestand_Formaat_Bestandsnaam)}" ));
                            Rip.record.Add(RipObjectAsBestand(record));
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(dossier.IdentificatieKenmerk, $"ERROR: {ex.Message}");
                    }

                    recordCounter++;
                    if (nrOfRecords > 0)
                        if (recordCounter >= nrOfRecords)
                            return Rip;
                }

                return Rip; //.Serialize();
            }
        }

        private void ValidateDossier(Dossier dossier)
        {
            //if (string.IsNullOrEmpty(dossier.Relatie_DatumOfPeriode))
            //    Logger.Log(dossier.IdentificatieKenmerk, "Relatie_DatumOfPeriode is leeg");
        }


        private ripRecordType RipOobjectAsDoc(Dossier dossier, string identificatieKenmerk)
        {
            //var identificatie = dossierId + "_FILE_" + count;
            var riprecordType = new ripRecordType()
            {
                recordHeader = new ripRecordHeaderType()
                {
                    identificatie = identificatieKenmerk,
                },
                metadata = new[] {new  ripMetadataType()
                {
                    schemaURI = "topx",
                    Any = ConvertTopxToXmlElement(GetRecordAsTopx(dossier, identificatieKenmerk))
                }}
            };
            return riprecordType;
        }

        private topxType GetRecordAsTopx(Dossier dossier, string identificatieKenmerk)
        {
            
            var eventgeschiedenis_DatumOfPeriode = DateTime.ParseExact(dossier.Eventgeschiedenis_DatumOfPeriode, DateParsing, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

            var relatie_DatumOfPeriode = dossier.Relatie_DatumOfPeriode != null
                ? DateTime.ParseExact(dossier.Relatie_DatumOfPeriode, DateParsing, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd")
                // Todo lelijke fix 
                : DateTime.ParseExact(dossier.Records.FirstOrDefault().Bestand_Formaat_DatumAanmaak, DateParsing, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

            var vertrouwelijkheid_DatumOfPeriode = DateTime.ParseExact(dossier.Vertrouwelijkheid_DatumOfPeriode, DateParsing, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

            var gebruiksrechten_DatumOfPeriode = DateTime.ParseExact(dossier.Gebruiksrechten_DatumOfPeriode, DateParsing, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

            var relatie = new[]
            {
                new relatieType()
                {
                    relatieID = new nonEmptyStringTypeAttribuut() {Value = _identificatieArchief},
                    typeRelatie = new nonEmptyStringTypeAttribuut() {Value = dossier.Relatie_Type ?? "Hiërachisch" },
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
                    taal = new[] { new taalTypeAttribuut() { Value = taalType.dut } },
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
                    openbaarheid = GetOpenbaarheid(dossier)
                    ,
                    gebruiksrechten = new gebruiksrechtenType[]
                    {
                        new gebruiksrechtenType()
                        {
                            omschrijvingVoorwaarden =new nonEmptyStringTypeAttribuut()
                            {
                                Value = dossier.Gebruiksrechten_OmschrijvingVoorwaarden,
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

       

        private openbaarheidType[] GetOpenbaarheid(Dossier dossier)
        {
            if (string.IsNullOrEmpty(dossier.Openbaarheid_DatumOfPeriode))
            {
                throw new Exception("Openbaarheid_DatumOfPeriode mag niet leeg zijn");
            }

            var openbaarheid_DatumOfPeriode = DateTime.ParseExact(dossier.Openbaarheid_DatumOfPeriode, DateParsing, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

            if (!string.IsNullOrEmpty(dossier.Openbaarheid_OmschrijvingBeperkingen))
            {
                return new[]
                {
                    new openbaarheidType()
                    {
                        omschrijvingBeperkingen = new[]
                        {
                            new nonEmptyStringTypeAttribuut() {Value = dossier.Openbaarheid_OmschrijvingBeperkingen}
                        },
                        datumOfPeriode = new datumOfPeriodeType()
                        {
                            //jaar = source.Jaar
                            datum = openbaarheid_DatumOfPeriode
                        }
                    }
                };
            }

            Logger.Log(dossier.IdentificatieKenmerk, "Openbaarheid_OmschrijvingBeperkingen mag niet leeg zijn" );
            return new[] {new openbaarheidType()
            {
                omschrijvingBeperkingen = new[]
                {
                    new nonEmptyStringTypeAttribuut() {Value = "ERROR - Openbaar kolom niet ingevuld"}
                }
            } };
        }

        private ripRecordType RipObjectAsBestand(Record record)
        {
            var identificatieKenmerkBestand = Path.GetFileNameWithoutExtension(record.Bestand_Formaat_Bestandsnaam);
            var riprecordType = new ripRecordType()
            {
                recordHeader = new ripRecordHeaderType()
                {
                    identificatie = identificatieKenmerkBestand,

                },
                metadata = new[] {new  ripMetadataType()
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

            var bestand_Formaat_DatumAanmaak = string.Empty;
            if (string.IsNullOrEmpty(record.Bestand_Formaat_DatumAanmaak))
            {
                ErrorMessage.Append($"{record.DossierId} Bestand_Formaat_DatumAanmaak mag niet leeg zijn");
            }
            else
            {
                bestand_Formaat_DatumAanmaak = DateTime.ParseExact(record.Bestand_Formaat_DatumAanmaak, DateParsing, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            }

            DateTime bestand_Formaat_FysiekeIntegriteit_DatumEnTijd = DateTime.MinValue;
            if (string.IsNullOrEmpty(record.Bestand_Formaat_FysiekeIntegriteit_DatumEnTijd))
            {
                ErrorMessage.Append($"{record.DossierId} Bestand_Formaat_FysiekeIntegriteit_DatumEnTijd mag niet leeg zijn.");
            }
            else
            {
                bestand_Formaat_FysiekeIntegriteit_DatumEnTijd = DateTime.ParseExact(record.Bestand_Formaat_FysiekeIntegriteit_DatumEnTijd, DateTimeParsing, CultureInfo.InvariantCulture);
            }


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
                                    datum = bestand_Formaat_DatumAanmaak
                                },
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
                                    datumEnTijd = new fysiekeIntegriteitTypeDatumEnTijd() {Value = bestand_Formaat_FysiekeIntegriteit_DatumEnTijd}
                                },
                                datumAanmaak = new formaatTypeDatumAanmaak()
                                {
                                    Value = bestand_Formaat_DatumAanmaak
                                }
                            },
                        }
                }
            };


            return topx;
        }


        private ripRecordType RipBeschikkingAsDossier(Dossier dossier)
        {
            
            var riprecordType = new ripRecordType()
            {
                recordHeader = new ripRecordHeaderType()
                {
                    identificatie = dossier.IdentificatieKenmerk
                    //omschrijving = new[] { source.C19_1_DN_Tabnaam },
                    //status = ripRecordStatusType.gewijzigd
                },
                metadata = new[] {new  ripMetadataType()
                {
                    schemaURI = "topx",
                    Any = ConvertTopxToXmlElement(GetDossierAsTopx(dossier))
                }}
            };
            return riprecordType;
        }


        private packageHeaderType RipHeader(string identificatie, DateTime datum, string omschrijving, string bron, string doel)
        {
            return new packageHeaderType()
            {
                identificatie = identificatie,
                datum = datum,
                omschrijving = new[] { omschrijving },
                bron = bron,
                doel = doel
            };
        }

        private List<ripRecordType> RipArchief(string archiefId, string naamArchief)
        {
            var result = new List<ripRecordType>();
            result.Add(
                new ripRecordType()
                {
                    recordHeader = new ripRecordHeaderType()
                    {
                        identificatie = archiefId
                    },
                    metadata = new[] {new  ripMetadataType()
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
                : DateTime.ParseExact(dossier.Records.FirstOrDefault().Bestand_Formaat_DatumAanmaak,
                    DateParsing, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

            var openbaarheid_DatumOfPeriode = DateTime.ParseExact(dossier.Openbaarheid_DatumOfPeriode,
                DateParsing, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

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

            string gebruiksrechten_DatumOfPeriode = string.Empty;
            if (string.IsNullOrEmpty(dossier.Gebruiksrechten_DatumOfPeriode))
            {
                ErrorMessage.Append($"{dossier.IdentificatieKenmerk}: Gebruiksrechten_DatumOfPeriode mag niet leeg zijn");
            }
            else
                gebruiksrechten_DatumOfPeriode = DateTime.ParseExact(dossier.Gebruiksrechten_DatumOfPeriode, DateParsing, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");


            var vertrouwelijkheid_DatumOfPeriode = DateTime.ParseExact(dossier.Vertrouwelijkheid_DatumOfPeriode, DateParsing, CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"); 

            topx.Item = new aggregatieType()
            {
                identificatiekenmerk = new nonEmptyStringTypeAttribuut() { Value = identificatiekenmerk },
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
                taal = new taalTypeAttribuut[] { new taalTypeAttribuut() { Value = (taalType)Enum.Parse(typeof(taalType), dossier.Taal) } },
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
                            jaar = dossier.Classificatie_DatumOfPeriode
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
                        geografischGebied = new[]
                        {
                            new @string()
                            {
                                Value = dossier.Dekking_GeografischGebied
                            }
                        },

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


    }
}
