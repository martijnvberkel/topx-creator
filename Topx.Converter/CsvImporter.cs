using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TOPX;
using TOPX.Classes;

namespace Topx.Converter
{
    public class CsvImporter
    {
       
        public static void Import(string csvFilePath, bool temp = false)
        {
            if (IsFileLocked(new FileInfo(csvFilePath)))
            {
                MessageBox.Show("file is locked");
                return;
            }
            try
            {
                using (var entities = new TOPXEntities())
                {

                    using (var streamreader = new StreamReader(csvFilePath, Encoding.Default))
                    {
                        streamreader.ReadLine(); // 
                        while (streamreader.Peek() > 0)
                        {
                            var line = streamreader.ReadLine();
                            var record = line.Split(";"[0]);
                            var dossier = record[0];

                            bool existingRecord;
                            existingRecord = temp
                                ? (from c in entities.Source_temp where c.C2_dn_Bestand == dossier select c).Any()
                                : (from c in entities.Source where c.C2_dn_Bestand == dossier select c).Any();
                                 

                            if (!existingRecord)
                                InsertRecord(record, entities, temp);
                        }

                    }
                }
            }

            catch (Exception ex)
            {
                
                throw new Exception(ex.ToString());
            }

        }
        private static bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        public static void UpdateSource(string csvFilePath, bool header)
        {
            try
            {
                using (var entities = new TOPXEntities())
                {
                    using (var streamreader = new StreamReader(csvFilePath, Encoding.Default))
                    {
                        if (header)
                            streamreader.ReadLine(); // 

                        while (streamreader.Peek() > 0)
                        {
                            var line = streamreader.ReadLine();
                            var record = line.Split(";"[0]);
                            var dossier = record[0];

                            var sourceFound =
                                (from c in entities.Source where c.C2_dn_Bestand == dossier select c).FirstOrDefault();
                            if (sourceFound != null)
                            {
                               entities.Source.Remove(sourceFound);
                                Logger.Log(dossier, "Removed");
                            }
                            InsertRecord(record, entities, false);
                            Logger.Log(dossier, "Added");
                            entities.SaveChanges();
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        private static void InsertRecord(string[] record, TOPXEntities entities, bool temp)
        {
            try
            {
                if (!temp)
                {
                    var source = new Source();

                    source.C2_dn_Bestand = record[0];
                    source.Bouwvergnr2 = record[1];
                    source.Straat = record[2];
                    source.Postcode = record[3];
                    source.AdresFull = record[4];
                    source.Adres = record[5];
                    source.Huisnr = record[6];
                    source.Voorvoegsl = record[7];
                    source.StraatHuisnr = record[8];
                    source.Postcode2 = record[9];
                    source.Bvnr = record[10];
                    source.Jaar = record[11];
                    source.C2zn__Zaaknummer = record[12];
                    source.C19_1_DN_Tabnaam = record[13];
                    source.C4_dn_Omschrijving = record[14];
                    source.C91_zn_Datum_vergunning = record[15];
                    source.C4_zn_Omschrijving = record[16];
                    source.OmschrijvingCompleet = record[17];
                    source.Plaatsnaam = record[18];
                    source.C15c_Gemeente = record[19];
                    source.C51zn_classificatiecode = record[20];
                    source.C52zn_Omschrijving_classificatiecode_ = record[21];
                    source.C53_zn_Bron_ = record[22];
                    source.Omschrijving_ = record[23];
                    source.Gemeentecode = record[24];
                    source.C54_zn_Bron_classificatiecode = record[25];
                    source.KvK_nummer = record[26];
                    source.Omvang_in_MB = record[27];
                    source.Bestandsformaat = record[28];
                    source.Language = record[29];
                    source.Datum_vergunning = record[30];
                    source.C_Bouw_en_woningtoezicht = record[31];
                    source.zn_bn_Hierarchisch = record[32];
                    source.Gemeente = record[33];
                    source.Organisatie = record[34];
                    source.Verlenen_bouwvergunningen = record[35];
                    source.Vrij_te_gebruiken = record[36];
                    source.Openbaar = record[37];
                    source.C_Integer = record[38];
                    source.Enkelvoudig = record[39];
                    source.Aanmaakdatum_bestand = record[40];
                    source.C_Aggregatieniveau = record[41];
                    source.C_Relatie_ID = record[42];
                    source.Checksum = record[43];
                    source.Datum = record[44];
                    source.C_BN_Algoritme = record[45];
                    source.ZN_DN_Classificatie = record[46];

                    entities.Source.Add(source);
                    entities.SaveChanges();
                }
                else
                {
                    var source = new Source_temp();

                    source.C2_dn_Bestand = record[0];
                    source.Bouwvergnr2 = record[1];
                    source.Straat = record[2];
                    source.Postcode = record[3];
                    source.AdresFull = record[4];
                    source.Adres = record[5];
                    source.Huisnr = record[6];
                    source.Voorvoegsl = record[7];
                    source.StraatHuisnr = record[8];
                    source.Postcode2 = record[9];
                    source.Bvnr = record[10];
                    source.Jaar = record[11];
                    source.C2zn__Zaaknummer = record[12];
                    source.C19_1_DN_Tabnaam = record[13];
                    source.C4_dn_Omschrijving = record[14];
                    source.C91_zn_Datum_vergunning = record[15];
                    source.C4_zn_Omschrijving = record[16];
                    source.OmschrijvingCompleet = record[17];
                    source.Plaatsnaam = record[18];
                    source.C15c_Gemeente = record[19];
                    source.C51zn_classificatiecode = record[20];
                    source.C52zn_Omschrijving_classificatiecode_ = record[21];
                    source.C53_zn_Bron_ = record[22];
                    source.Omschrijving_ = record[23];
                    source.Gemeentecode = record[24];
                    source.C54_zn_Bron_classificatiecode = record[25];
                    source.KvK_nummer = record[26];
                    source.Omvang_in_MB = record[27];
                    source.Bestandsformaat = record[28];
                    source.Language = record[29];
                    source.Datum_vergunning = record[30];
                    source.C_Bouw_en_woningtoezicht = record[31];
                    source.zn_bn_Hierarchisch = record[32];
                    source.Gemeente = record[33];
                    source.Organisatie = record[34];
                    source.Verlenen_bouwvergunningen = record[35];
                    source.Vrij_te_gebruiken = record[36];
                    source.Openbaar = record[37];
                    source.C_Integer = record[38];
                    source.Enkelvoudig = record[39];
                    source.Aanmaakdatum_bestand = record[40];
                    source.C_Aggregatieniveau = record[41];
                    source.C_Relatie_ID = record[42];
                    source.Checksum = record[43];
                    source.Datum = record[44];
                    source.C_BN_Algoritme = record[45];
                    source.ZN_DN_Classificatie = record[46];

                    entities.Source_temp.Add(source);
                    entities.SaveChanges();
                }
            }
            
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public static void ImportFileSize(string fileName)
        {
            try
            {
                using (var entities = new TOPXEntities())
                {

                    using (var streamreader = new StreamReader(fileName, Encoding.Default))
                    {
                        streamreader.ReadLine(); // 
                        while (streamreader.Peek() > 0)
                        {
                            var line = streamreader.ReadLine();
                            var record = line.Split(";"[0]);
                            InsertRecordFileSize(record, entities);
                        }

                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private static void InsertRecordFileSize(string[] record, TOPXEntities entities)
        {
            var filenaamClean = record[0].Substring(0, record[0].Length - 3);
            var fileSize = new FileSizes()
            {
                Bestandsnaam = record[0],
                Omvang_Byte__B_ = record[1],
                CleanName = filenaamClean
            };

            entities.FileSizes.Add(fileSize);
            entities.SaveChanges();
        }

        public static void ImportChecksum(string fileName)
        {
            try
            {
                using (var entities = new TOPXEntities())
                {

                    using (var streamreader = new StreamReader(fileName))
                    {
                        streamreader.ReadLine(); // 
                        while (streamreader.Peek() > 0)
                        {
                            var line = streamreader.ReadLine();
                            var record = line.Split(";"[0]);
                            InsertRecordChecksum(record, entities);
                        }

                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private static void InsertRecordChecksum(string[] record, TOPXEntities entities)
        {
            var checksum = new checksum()
            {
                Filename = record[0],
                Checksum1 = record[1]
            };
            entities.checksum.Add(checksum);
            entities.SaveChanges();
        }
    }
}

