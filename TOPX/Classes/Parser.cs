using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Xml;
using System.Xml.Serialization;
using TOPX.Classes;

namespace TOPX
{
    public class Parser
    {
        public recordInformationPackage Rip;
        public List<string> ZaaknummerMarkForDelivered = new List<string>();

        public recordInformationPackage ParseCSV(int nrOfRecords = 0)
        {
            using (var entities = new TOPXEntities())
            {
                var identificatieArchief = "NL-0834-10002";
                var datumArchief = Convert.ToDateTime(DateTime.Today);
                var omschrijvingArchief = "Bouwvergunningen Gemeente Raamsdonk 1993 - 1996";
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
                        RipHeader(identificatieArchief, datumArchief, omschrijvingArchief, bronArchief, doelArchief),
                    record = RipArchief(identificatieArchief, naamArchief)
                };

                var listOfDossiers = GetListOfDossiers(entities);
                var recordCounter = 0;
                foreach (var dossier in listOfDossiers)
                {
                    try
                    {
                        var entries = (from d in entities.Source where d.C2_dn_Bestand.StartsWith(dossier) select d).ToList();
                        var dossiersZonderBeschikking =
                            (from d in entities.DossiersZonderBeschikking select d.DossierZonderBeschikking).ToList();

                        //var dossierEntry = (from d in entries
                        //                    where d.C19_1_DN_Tabnaam == "Beschikking"
                        //  || d.C2_dn_Bestand.Contains("GDB-0391")
                        //  || d.C2_dn_Bestand.Contains("GDB-1064")
                        //  || d.C2_dn_Bestand.Contains("GDB-0005-02")
                        //                    select d);
                        var dossierEntry = (from d in entries
                            where
                            d.C19_1_DN_Tabnaam == "Beschikking" || dossiersZonderBeschikking.Contains( d.C2_dn_Bestand.Substring(0, d.C2_dn_Bestand.Length -3))
                            select d). ToList();
                        

                        if (!dossierEntry.Any())
                        {
                            Logger.Log(dossier, "ERROR - Geen beschikking gevonden");
                            continue;
                        }

                        var isExceptionGeenBeschikking = dossiersZonderBeschikking.Contains(dossierEntry[0].C2_dn_Bestand.Substring(0, dossierEntry[0].C2_dn_Bestand.Length -3));

                        if (dossierEntry.Count() > 1 && !isExceptionGeenBeschikking)
                        {
                            Logger.Log(dossier, "Meer dan 2 beschikkingen in 1 dossier");
                            throw new Exception("Meer dan 2 beschikkingen in 1 dossier");
                        }
                        var source = dossierEntry.FirstOrDefault();

                        if (string.IsNullOrEmpty(source.Datum_vergunning) || string.IsNullOrEmpty(source.C91_zn_Datum_vergunning))
                        {
                            Logger.Log(source.C2_dn_Bestand, "ERROR - Datum vergunning leeg");
                            continue;
                        }
                        if (string.IsNullOrEmpty(source.OmschrijvingCompleet))
                        {
                            Logger.Log(source.C2_dn_Bestand, "OmschrijvingCompleet is leeg (Excel kolom: \"Omschrijving bouwvergunning, adres, huisnummer, plaatsnaam\" ");
                            continue;
                        }

                        if (source.Datum_vergunning.StartsWith("12"))
                        {
                            Logger.Log(source.C2_dn_Bestand, "Datum vergunning label onjuist, kan niet met een getal beginnen, waarschijnlijk meerdere kolommen onjuist");
                            continue;
                        }

                        var testForDoubles = from t in entities.Source
                                             where
                   t.C2zn__Zaaknummer == source.C2zn__Zaaknummer
                   && t.C2_dn_Bestand.Substring(0, t.C2_dn_Bestand.Length - 3) != source.C2_dn_Bestand.Substring(0, source.C2_dn_Bestand.Length - 3)
                                             select t;

                        if (testForDoubles.Any())
                        {
                            Logger.Log(source.C2_dn_Bestand, $"Zaaknummer {source.C2zn__Zaaknummer} komt meer dan 1 keer voor bij verschillende dossiers.");
                            continue;
                        }

                        Rip.record.Add(RipBeschikkingAsDossier(source, dossier, identificatieArchief));
                        ZaaknummerMarkForDelivered.Add(dossier);

                        var bestandEntries = (from d in entries select d);
                        var count = 0;
                        foreach (var bestandEntry in bestandEntries)
                        {
                            //double test2;
                            //if (!double.TryParse(bestandEntry.FileSize_Bytes.ToString(), out test2))
                            //{
                            //    throw new Exception("File size is not in correct format");

                            //}
                            var zaaknummer = Extensions.GetZaakNummerWithYear(bestandEntry.C2zn__Zaaknummer);
                            var idRecordAsDoc = zaaknummer + "_" + bestandEntry.C2_dn_Bestand;


                            Rip.record.Add(RipOobjectAsDoc(bestandEntry, idRecordAsDoc, zaaknummer, entities));


                            var fileSize = (from f in entities.FileSizes where f.Bestandsnaam == bestandEntry.C2_dn_Bestand + ".pdf" select f).FirstOrDefault();
                            if (fileSize == null)
                            {
                                fileSize = new FileSizes() { Bestandsnaam = "NIET GEVONDEN" };
                                Logger.Log(bestandEntry.C2_dn_Bestand, $"Bestandsnaam niet gevonden in filesize tabel van file");

                            }

                            var fileChecksum = (from f in entities.checksum where f.Filename == fileSize.Bestandsnaam select f).FirstOrDefault();

                            if (fileChecksum == null)
                            {
                                Logger.Log(bestandEntry.C2_dn_Bestand, "Checksum niet gevonden van file");
                                fileChecksum = new checksum() { Checksum1 = "NIET GEVONDEN" };
                            }
                            Rip.record.Add(RipObjectAsBestand(bestandEntry, bestandEntry.C2_dn_Bestand, idRecordAsDoc, fileChecksum, fileSize, "fmt/18", "sha256"));
                            count += 1;

                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(dossier, $"ERROR: {ex.Message}");
                    }

                    recordCounter++;
                    if (nrOfRecords > 0)
                        if (recordCounter >= nrOfRecords)
                            return Rip;
                }

                return Rip; //.Serialize();
            }
        }


        private ripRecordType RipOobjectAsDoc(Source bestandEntry, string identificatie, string relatieId, TOPXEntities entities)
        {
            //var identificatie = dossierId + "_FILE_" + count;
            var riprecordType = new ripRecordType()
            {
                recordHeader = new ripRecordHeaderType()
                {
                    identificatie = identificatie,
                },
                metadata = new[] {new  ripMetadataType()
                            {
                                schemaURI = "topx",
                                Any = ConvertTopxToXmlElement(GetDocAsTopx(bestandEntry, identificatie, relatieId, entities))
                            }}
            };
            return riprecordType;
        }

        private topxType GetDocAsTopx(Source source, string identificatie, string relatieId, TOPXEntities entities)
        {
            var topx = new topxType
            {
                Item = new aggregatieType()
                {
                    identificatiekenmerk = new nonEmptyStringTypeAttribuut() { Value = identificatie },

                    eventGeschiedenis = new eventGeschiedenisType[] { new eventGeschiedenisType() {datumOfPeriode = new datumOfPeriodeType()
                { datum = DateTime.ParseExact(source.C91_zn_Datum_vergunning,
                          "yyyy.MM.dd",CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") },
                    type = new nonEmptyStringTypeAttribuut() {Value = "Verzending"} ,
                    verantwoordelijkeFunctionaris = new nonEmptyStringTypeAttribuut() {Value = "Afdeling Ondersteuning"}  } },

                    aggregatieniveau = new aggregatieTypeAggregatieniveau()
                    {
                        Value = aggregatieAggregatieniveauType.Record
                    },
                    naam = new[] { new nonEmptyStringTypeAttribuut() { Value = source.C4_dn_Omschrijving } },
                    taal = new[] { new taalTypeAttribuut() { Value = taalType.dut } },
                    relatie = new[]
                    {
                        new relatieType()
                        {
                            relatieID = new nonEmptyStringTypeAttribuut() {Value = relatieId},
                            typeRelatie = new nonEmptyStringTypeAttribuut() {Value = "Hiërarchisch"},
                            datumOfPeriode = new datumOfPeriodeType()
                            {
                                datum = DateTime.ParseExact(source.Aanmaakdatum_bestand,
                                    "yyyy.MM.dd", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd")
                            },
                        }
                    },
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
                            datum = DateTime.ParseExact(source.C91_zn_Datum_vergunning,
                          "yyyy.MM.dd",CultureInfo.InvariantCulture).ToString("yyyy-MM-dd")
                        }
                    }
                },
                    openbaarheid = GetOpenbaarheid(entities, source)
                ,
                    gebruiksrechten = GetGebruiksrechten(entities, source)
                }
            };



            return topx;
        }

        private gebruiksrechtenType[] GetGebruiksrechten(TOPXEntities entities, Source source)
        {
            var datum = DateTime.ParseExact(source.C91_zn_Datum_vergunning,
                          "yyyy.MM.dd", CultureInfo.InvariantCulture);

            var gebruiksrechtenCol = from o in entities.Gebruiksrechten where o.naam == source.C2_dn_Bestand orderby o.begin select o;
            if (!gebruiksrechtenCol.Any())
            {
                return new gebruiksrechtenType[]
               {
                    new gebruiksrechtenType()
                    {
                        omschrijvingVoorwaarden = new nonEmptyStringTypeAttribuut()
                        {
                            Value = datum <= Convert.ToDateTime("31-12-1970")
                            ? "Vrij te gebruiken"
                            : 
                            source.C19_1_DN_Tabnaam.ToLower().Contains("tekening") ?
                            "Auteursrechtelijk beschermd wegens rechten van de architect" : "Vrij te gebruiken"
                        },
                        datumOfPeriode = new datumOfPeriodeType()
                        {
                            datum = datum.ToString("yyyy-MM-dd")
                        }
                    }
               };
            }
            // record(s) gebruiksrechten gevonden
            List<gebruiksrechtenType> listGebruiksrechten = new List<gebruiksrechtenType>();

            foreach (var gebruiksrechten in gebruiksrechtenCol)
            {
                if (gebruiksrechten.eind != null)
                {
                    listGebruiksrechten.Add(
                        new gebruiksrechtenType()
                        {
                            omschrijvingVoorwaarden = new nonEmptyStringTypeAttribuut()

                            { Value = gebruiksrechten.omschrijvingVoorwaarden },
                            datumOfPeriode = new datumOfPeriodeType()
                            {
                                periode = new periodeType()
                                {
                                    begin = new datumOfJaarType()
                                    {
                                        Item = new datumOfJaarTypeDatum()
                                        {
                                            Value = (DateTime)gebruiksrechten.begin
                                        }
                                    },
                                    //eind = new datumOfJaarType()
                                    //{
                                    //    Item = new datumOfJaarTypeDatum()
                                    //    {
                                    //        Value = (DateTime)gebruiksrechten.eind
                                    //    }
                                    //}
                                }
                            }
                        });
                }
                else // openbaarheid.eind is niet ingevuld 
                {
                    listGebruiksrechten.Add(
                        new gebruiksrechtenType()
                        {
                            omschrijvingVoorwaarden = new nonEmptyStringTypeAttribuut()
                            {
                                Value = gebruiksrechten.omschrijvingVoorwaarden
                            },
                            datumOfPeriode = new datumOfPeriodeType()
                            {
                                //datum = new datumOfPeriodeType() { datum = Convert.ToDateTime(gebruiksrechten.begin).ToString("yyyy-MM-dd") }
                                datum = Convert.ToDateTime(gebruiksrechten.begin).ToString("yyyy-MM-dd")
                            }
                        });

                }
            }
            return listGebruiksrechten.ToArray();

        }

        private openbaarheidType[] GetOpenbaarheid(TOPXEntities entities, Source source)
        {
            if (string.IsNullOrEmpty(source.Jaar))
            {
                throw new Exception("Jaar mag niet leeg zijn");
            }

            //var openbaarheidCol = source.Openbaar;
            if (!string.IsNullOrEmpty(source.Openbaar))
            {
                return new[]
                {
                    new openbaarheidType()
                    {
                        omschrijvingBeperkingen = new[]
                        {
                            new nonEmptyStringTypeAttribuut() {Value = source.Openbaar}
                        },
                        datumOfPeriode = new datumOfPeriodeType()
                        {
                            //jaar = source.Jaar
                              datum = DateTime.ParseExact(source.Aanmaakdatum_bestand,
                                    "yyyy.MM.dd", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd")
                        }
                    }
                };

            }
            return new[] {new openbaarheidType()
            {
                 omschrijvingBeperkingen = new[]
                        {
                            new nonEmptyStringTypeAttribuut() {Value = "ERROR - Openbaar kolom niet ingevuld"}
                        }
            } };
        }
        private openbaarheidType[] GetOpenbaarheid_OLD(TOPXEntities entities, Source source)
        {

            var openbaarheidCol = (from o in entities.Openbaarheid where o.naam == source.C2_dn_Bestand orderby o.begin select o);
            if (!openbaarheidCol.Any())
            {
                return new[]
                {
                    new openbaarheidType()
                    {
                        omschrijvingBeperkingen = new[]
                        {
                            new nonEmptyStringTypeAttribuut() {Value = source.Openbaar}
                        },
                        datumOfPeriode = new datumOfPeriodeType()
                        {
                            jaar = source.Jaar
                        }
                    }
                };

            }
            // Openbaarheid records gevonden

            List<openbaarheidType> listOpenbaarheid = new List<openbaarheidType>();
            foreach (var openbaarheid in openbaarheidCol)
            {
                if (openbaarheid.eind != null)
                {
                    listOpenbaarheid.Add(
                        new openbaarheidType()
                        {
                            omschrijvingBeperkingen = new[]
                        {
                            new nonEmptyStringTypeAttribuut() {Value = openbaarheid.omschrijvingBeperkingen}
                        },
                            datumOfPeriode = new datumOfPeriodeType()
                            {
                                periode = new periodeType()
                                {
                                    begin = new datumOfJaarType()
                                    {
                                        Item = new datumOfJaarTypeDatum()
                                        {
                                            Value = (DateTime)openbaarheid.begin
                                        }
                                    },
                                    //eind = new datumOfJaarType()
                                    //{
                                    //    Item = new datumOfJaarTypeDatum()
                                    //    {
                                    //        Value = (DateTime)openbaarheid.eind
                                    //    }
                                    //}
                                }
                            }
                        });
                }
                else // openbaarheid.eind is niet ingevuld 
                {
                    listOpenbaarheid.Add(
                        new openbaarheidType()
                        {
                            omschrijvingBeperkingen = new[]
                        {
                            new nonEmptyStringTypeAttribuut() {Value = openbaarheid.omschrijvingBeperkingen}
                        },
                            datumOfPeriode = new datumOfPeriodeType() { datum = Convert.ToDateTime(openbaarheid.begin).ToString("yyyy-MM-dd") }

                        });

                }
            }
            return listOpenbaarheid.ToArray();
        }

        private ripRecordType RipObjectAsBestand(Source bestandEntry, string dossierId, string relatieId, checksum checksum, FileSizes fileSize, string bestandsformaat, string algoritme)
        {
            var identificatie = dossierId;
            var riprecordType = new ripRecordType()
            {
                recordHeader = new ripRecordHeaderType()
                {
                    identificatie = identificatie,

                },
                metadata = new[] {new  ripMetadataType()
                            {
                                schemaURI = "topx",

                               Any = ConvertTopxToXmlElement(GetBestandAsTopx(bestandEntry, relatieId, identificatie, bestandsformaat,algoritme, checksum, fileSize))
                            }}
            };
            return riprecordType;
        }

        private topxType GetBestandAsTopx(Source source, string releatieId, string identificatiekenmerk, string bestandsformaat, string algoritme, checksum checksum, FileSizes fileSize)
        {
            string strGemaaktOp;
            DateTime gemaaktOp;
            if (fileSize.Gemaakt_op == null)
            {
                strGemaaktOp = "NIET GEVONDEN";
                gemaaktOp = DateTime.MinValue;
            }
            else
            {
                gemaaktOp = fileSize.Gemaakt_op != null
                    ? gemaaktOp = DateTime.ParseExact(fileSize.Gemaakt_op, "d-M-yyyy H:m", CultureInfo.InvariantCulture)
                    : gemaaktOp = DateTime.MinValue;

                strGemaaktOp = gemaaktOp.ToString("yyyy-MM-dd");
            }


            var topx = new topxType
            {
                Item = new bestandType()
                {
                    identificatiekenmerk = new nonEmptyStringTypeAttribuut() { Value = identificatiekenmerk },
                    aggregatieniveau = new bestandTypeAggregatieniveau()
                    {
                        Value = bestandAggregatieniveauType.Bestand
                    },
                    naam = new[] { new nonEmptyStringTypeAttribuut() { Value = source.OmschrijvingCompleet } },
                    //plaats = new @string() { Value = "storage location" },
                    relatie = new[]
                    {
                        new relatieType()
                        {
                            relatieID = new nonEmptyStringTypeAttribuut() {Value = releatieId},
                            typeRelatie = new nonEmptyStringTypeAttribuut() {Value = "Hiërarchisch"},
                            datumOfPeriode = new datumOfPeriodeType()
                            {
                                datum = strGemaaktOp
                            },
                        }
                    },


                    vorm = new vormType()
                    {
                        redactieGenre = new @string() { Value = source.C19_1_DN_Tabnaam },
                    },
                    formaat = new[]
                    {
                        new formaatType()
                        {
                            identificatiekenmerk = new nonEmptyStringTypeAttribuut() {Value = identificatiekenmerk},
                            bestandsnaam = new bestandsnaamType()
                            {
                                naam = new nonEmptyStringTypeAttribuut() {Value = source.C2_dn_Bestand},
                                extensie = new @string() {Value = source.Bestandsformaat}
                            },
                            omvang = new formaatTypeOmvang() {Value = fileSize.Omvang_Byte__B_ },
                            //bestandsformaat = new @string() {Value = "fmt/18"},
                            bestandsformaat = new @string() {Value = bestandsformaat},
                            fysiekeIntegriteit = new fysiekeIntegriteitType()
                            {
                                algoritme = new nonEmptyStringTypeAttribuut() {Value = algoritme},
                                waarde = new nonEmptyStringTypeAttribuut() {Value = checksum.Checksum1 },
                                datumEnTijd = new fysiekeIntegriteitTypeDatumEnTijd() {Value = gemaaktOp}
                            },
                            datumAanmaak = new formaatTypeDatumAanmaak()
                            {
                                Value = strGemaaktOp
                            }
                        },
                    }
                }
            };


            return topx;
        }


        private ripRecordType RipBeschikkingAsDossier(Source source, string identificatie, string archiefId)
        {
            var riprecordType = new ripRecordType()
            {
                recordHeader = new ripRecordHeaderType()
                {
                    identificatie = Extensions.GetZaakNummerWithYear(source.C2zn__Zaaknummer),
                    //omschrijving = new[] { source.C19_1_DN_Tabnaam },
                    //status = ripRecordStatusType.gewijzigd
                },
                metadata = new[] {new  ripMetadataType()
                            {
                                schemaURI = "topx",
                                Any = ConvertTopxToXmlElement(GetDossierAsTopx(source, archiefId))
                            }}
            };
            return riprecordType;
        }

        private List<string> GetListOfDossiers(TOPXEntities entities)
        {
            var markedAsDelivered = from t in entities.MarkedAsDelivered select t;

            var result = (from d in entities.Source
                              //where !(from x in markedAsDelivered select x.Zaaknr.Substring(0,2)) == 
                          where d.C2_dn_Bestand.Length > 0
                          select d.C2_dn_Bestand.Substring(0, d.C2_dn_Bestand.Length - 3))
                .Distinct()
                .OrderBy(p => p)
                .ToList();

            var filteredresult = (from a in result
                                  where !(from b in markedAsDelivered select b.Zaaknr).Contains(a)
                                  select a).ToList();

            //  var eersteShift = from firsthift in entities.EersteShift select firsthift;

            // var result2 = from a in eersteShift join f in filteredresult on a.Bestand equals f select a.Bestand;


            return filteredresult.ToList();
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

        private topxType GetDossierAsTopx(Source source, string archiefId)
        {

            var topx = new topxType();
            //var identificatiekenmerkTemp = source.C2_dn_Bestand.Split("-"[0]);
            var identificatiekenmerk = Extensions.GetZaakNummerWithYear(source.C2zn__Zaaknummer);

            topx.Item = new aggregatieType()
            {
                identificatiekenmerk = new nonEmptyStringTypeAttribuut() { Value = identificatiekenmerk },
                aggregatieniveau = new aggregatieTypeAggregatieniveau()
                {
                    Value = aggregatieAggregatieniveauType.Dossier

                },
                eventGeschiedenis = new eventGeschiedenisType[] { new eventGeschiedenisType() {datumOfPeriode = new datumOfPeriodeType()
                {
                    datum = string.IsNullOrEmpty(source.C91_zn_Datum_vergunning)
                      ? "ERROR - ONBEKEND"
                      : DateTime.ParseExact(source.C91_zn_Datum_vergunning,
                          "yyyy.MM.dd",CultureInfo.InvariantCulture).ToString("yyyy-MM-dd")
                },
                    type = new nonEmptyStringTypeAttribuut() {Value = "Afsluiting"} ,
                    verantwoordelijkeFunctionaris = new nonEmptyStringTypeAttribuut() {Value = "Afdeling Ondersteuning"}  }
                                                                 },

                naam = new[] { new nonEmptyStringTypeAttribuut() { Value = source.OmschrijvingCompleet } },
                taal = new taalTypeAttribuut[] { new taalTypeAttribuut() { Value = taalType.dut } },
                relatie = new[] {new relatieType()
                {
                    relatieID = new nonEmptyStringTypeAttribuut() {Value = archiefId },
                    typeRelatie = new nonEmptyStringTypeAttribuut() {Value = "Hiërarchisch"},
                    datumOfPeriode = new datumOfPeriodeType() {datum = DateTime.ParseExact(source.Aanmaakdatum_bestand,
                          "yyyy.MM.dd",CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") },

                }},
                classificatie = new classificatieType[] {new classificatieType()
                {
                    code = new nonEmptyStringTypeAttribuut() { Value = source.C51zn_classificatiecode},
                    omschrijving =  new nonEmptyStringTypeAttribuut() {Value = source.C52zn_Omschrijving_classificatiecode_},
                    bron = new nonEmptyStringTypeAttribuut() {Value = source.C53_zn_Bron_},
                    datumOfPeriode = new datumOfPeriodeType()
                    {
                        jaar = source.C54_zn_Bron_classificatiecode
                    }
                   // new datumOfPeriodeTypeJaar () { Value = source.C54_zn_Bron_classificatiecode }
                },

                },
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
                            datum = DateTime.ParseExact(source.C91_zn_Datum_vergunning,
                          "yyyy.MM.dd",CultureInfo.InvariantCulture).ToString("yyyy-MM-dd")
                        }
                    }
                },
                openbaarheid = new openbaarheidType[]
                {
                    new openbaarheidType()
                    {
                        omschrijvingBeperkingen = new nonEmptyStringTypeAttribuut[]
                        {
                            new nonEmptyStringTypeAttribuut() {Value = source.Openbaar}
                        },
                        datumOfPeriode = new datumOfPeriodeType()
                        {
                           datum = DateTime.ParseExact(source.C91_zn_Datum_vergunning,
                          "yyyy.MM.dd",CultureInfo.InvariantCulture).ToString("yyyy-MM-dd")
                        }
                    }
                },
                dekking = new dekkingType[] {new dekkingType()
                {
                    inTijd = new periodeType()
                    {
                        begin = new datumOfJaarType()
                        {
                           Item = new datumOfJaarTypeDatum() { Value = Convert.ToDateTime(DateTime.ParseExact(source.C91_zn_Datum_vergunning,
                               "yyyy.MM.dd", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"))}
                        },
                          eind = new datumOfJaarType()
                        {
                             Item = new datumOfJaarTypeDatum() { Value = Convert.ToDateTime(DateTime.ParseExact(source.C91_zn_Datum_vergunning,
                               "yyyy.MM.dd", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"))}
                        }

                    },
                    geografischGebied = new[]
                    {
                        new @string()
                        {
                            Value = source.Postcode == string.Empty
                            ? source.Straat + " " + source.Huisnr + " " + source.Plaatsnaam
                            : source.Straat + " " + source.Huisnr + " " + source.Postcode + " " + source.Plaatsnaam
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
                            identificatiekenmerk = new nonEmptyStringTypeAttribuut() {Value = source.KvK_nummer},
                            aggregatieniveau = new @string() { Value= source.Organisatie },
                            geautoriseerdeNaam = new nonEmptyStringTypeAttribuut() {Value = source.C15c_Gemeente }
                        }
                    },
                    activiteit = new[]
                    {
                        new activiteitType()
                        {
                        naam = new nonEmptyStringTypeAttribuut() { Value = source.Verlenen_bouwvergunningen }
                        }
                    }

                },
                gebruiksrechten = new gebruiksrechtenType[]
                {
                    new gebruiksrechtenType()
                    {
                        omschrijvingVoorwaarden = new nonEmptyStringTypeAttribuut() {Value = source.Vrij_te_gebruiken },
                        datumOfPeriode = new datumOfPeriodeType()
                        {
                            datum = string.IsNullOrEmpty(source.C91_zn_Datum_vergunning)
                            ?  "ERROR - ONBEKEND"
                            : DateTime.ParseExact(source.C91_zn_Datum_vergunning, "yyyy.MM.dd", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd")
                        }
                    }
                },
                integriteit = new @string() { Value = source.C_Integer }
            };
            return topx;
        }


    }
}

