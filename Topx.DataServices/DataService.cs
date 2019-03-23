using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using Topx.Data;


namespace Topx.DataServices
{

    public interface IDataService
    {
        void SaveLastDossierFileName(string fileName);
        void SaveLastRecordsFileName(string fileName);
        string GetLastDossierFileName();
        string GetLastRecordsFileName();
        List<Dossier> GetAllDossiers();
        Globals GetGlobals();
        void SaveGlobals(Globals globals);
        bool SaveDossier(Dossier dossier);
        bool SaveRecord(Record record);
        void SaveRecordChanges(Record record);
        void ClearDossiersAndRecords();
        List<FieldMapping> GetMappingsDossiers(List<string> headersList);
        List<FieldMapping> GetMappingsRecords(List<string> headersList);
        void SaveMappings(List<FieldMapping> fieldmappingdossiers, FieldMappingType type);
        string ErrorMessage { get; set; }
        bool Error { get; set; }
        void Log(string dossier, string message);
        void ClearLog();
        string GetLog();
        bool CanConnect();
        string Conectionstring { get; set; }

        void SaveComplexLink(ComplexLink complexLink);
    }

    public class DataService : IDataService
    {
        private string _errorMessage;
        public string Conectionstring { get; set; }
       

        public bool Error { get; set; }
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                Error = true;
            }
        }

        public DataService(string conectionstring)
        {
            Conectionstring = conectionstring;
        }

        public bool CanConnect()
        {
            try
            {
                using (var entities = new ModelTopX(Conectionstring))
                {
                    //var test = (from i in entities.Dossiers select i).FirstOrDefault();
                    return true;
                }
            }
            catch (Exception e)
            {
                try   // second try, the database might not be initialized
                {
                    Thread.Sleep(2000);
                    using (var entities = new ModelTopX(Conectionstring))
                    {
                        var test = (from i in entities.Dossiers select i).FirstOrDefault();
                        return true;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
               
            }
        }

        public void ClearDossiersAndRecords()
        {
            using (var entities = new ModelTopX(Conectionstring))
            {
                entities.Database.ExecuteSqlCommand("truncate table Records");
                entities.Database.ExecuteSqlCommand("truncate table Bestanden");
                entities.Database.ExecuteSqlCommand("truncate table ComplexLinks");
                entities.Database.ExecuteSqlCommand("delete from Dossiers");
               
            }
        }

        public void SaveLastDossierFileName(string fileName)
        {
            using (var entities = new ModelTopX(Conectionstring))
            {
                var globals = (from g in entities.Globals select g).FirstOrDefault() ?? new Globals();
                globals.LastDossierFileName = fileName;
                entities.SaveChanges();
            }
        }

        public void SaveLastRecordsFileName(string fileName)
        {
            using (var entities = new ModelTopX(Conectionstring))
            {
                var globals = (from g in entities.Globals select g).FirstOrDefault() ?? new Globals();
                globals.LastRecordsFileName = fileName;
                entities.SaveChanges();
            }
        }

        public string GetLastDossierFileName()
        {
            using (var entities = new ModelTopX(Conectionstring))
            {
                return (from g in entities.Globals select g).FirstOrDefault()?.LastDossierFileName;
            }
        }

        public string GetLastRecordsFileName()
        {
            using (var entities = new ModelTopX(Conectionstring))
            {
                return (from g in entities.Globals select g).FirstOrDefault()?.LastRecordsFileName;
            }
        }

        public List<Dossier> GetAllDossiers()
        {
            using (var entities = new ModelTopX(Conectionstring))
            {
                return (from d in entities.Dossiers select d). Include("Records"). ToList();
            }
        }

        public void SaveRecordChanges(Record record)
        {
            using (var entities = new ModelTopX(Conectionstring))
            {
                entities.Entry(record).State = EntityState.Modified;
                //entities.Records.Attach(record);
                
                entities.SaveChanges();
            }
        }

        public Globals GetGlobals()
        {
            using (var entities = new ModelTopX(Conectionstring))
            {
                return (from g in entities.Globals select g).FirstOrDefault();
            }
        }

        public void SaveGlobals(Globals globals)
        {
            using (var entities = new ModelTopX(Conectionstring))
            {
                var globalsFirstRecord = (from g in entities.Globals select g).FirstOrDefault();
                if (globalsFirstRecord != null)
                    entities.Globals.Remove(globalsFirstRecord);

                entities.Globals.Add(globals);

                entities.SaveChanges();
            }
        }

        public bool SaveDossier(Dossier dossier)
        {
            ErrorMessage = string.Empty;
            using (var entities = new ModelTopX(Conectionstring))
            {
                try
                {
                    entities.Dossiers.Add(dossier);
                    entities.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        //Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        //    eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        var error = new StringBuilder();
                        foreach (var ve in eve.ValidationErrors)
                        {
                            error.AppendLine($"Veld: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                        }
                        ErrorMessage = error.ToString();
                    }
                    return false;
                }
                return true;
            }
        }
        public bool SaveRecord(Record record)
        {
            ErrorMessage = string.Empty;
            using (var entities = new ModelTopX(Conectionstring))
            {
                var dossierId = record.DossierId;
                if (!entities.Dossiers.Any(t => t.IdentificatieKenmerk == dossierId))
                {
                    ErrorMessage = $"ERROR: Record met bestandsnaam {record.Naam} is niet geïmporteerd, verwijst naar niet-bestaande DossierId {record.DossierId} ";
                    return false;
                }
                try
                {
                    entities.Records.Add(record);
                    entities.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        //Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        //    eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        var error = new StringBuilder();
                        foreach (var ve in eve.ValidationErrors)
                        {
                            error.AppendLine($"Veld: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                        }
                        ErrorMessage = error.ToString();
                        return false;
                    }
                }
            }
            return true;
        }

        public List<FieldMapping> GetMappingsDossiers(List<string> headersList)
        {
            using (var entities = new ModelTopX(Conectionstring))
            {
                var listFieldmappings = (from m in entities.FieldMappings where m.Type == "DOSSIER" select m).ToList();

                // Als er een element van de opgeslagen fieldmappings niet voorkomt in de header-collectie, is deze niet consistent -> return null
                if (listFieldmappings.Any(fieldMapping => !string.IsNullOrEmpty(fieldMapping.MappedFieldName) && !headersList.Contains(fieldMapping.MappedFieldName)))
                    return null;

                // Als er een element van de header-collectie niet voorkomt in de opgeslagen fieldmappings, is deze niet consistent -> return null
                if (headersList.Any(header => !string.IsNullOrEmpty(header) && !listFieldmappings.Select(t => t.MappedFieldName == header).Any()))
                    return null;

                return listFieldmappings;
            }
        }
        public List<FieldMapping> GetMappingsRecords(List<string> headersList)
        {
            using (var entities = new ModelTopX(Conectionstring))
            {
                var listFieldmappings = (from m in entities.FieldMappings where m.Type == "RECORD" select m).ToList();

                // Als er een element van de opgeslagen fieldmappings niet voorkomt in de header-collectie, is deze niet consistent -> return null
                if (listFieldmappings.Any(fieldMapping => !string.IsNullOrEmpty(fieldMapping.MappedFieldName) && !headersList.Contains(fieldMapping.MappedFieldName)))
                    return null;

                // Als er een element van de header-collectie niet voorkomt in de opgeslagen fieldmappings, is deze niet consistent -> return null
                if (headersList.Any(header => !string.IsNullOrEmpty(header) && !listFieldmappings.Select(t => t.MappedFieldName == header).Any()))
                    return null;

                return listFieldmappings;
            }
        }

        public void SaveMappings(List<FieldMapping> fieldmappingsModified, FieldMappingType type)
        {
            using (var entities = new ModelTopX(Conectionstring))
            {
                var fieldmappings = from m in entities.FieldMappings where m.Type == type.ToString() select m;
                entities.FieldMappings.RemoveRange(fieldmappings);
                entities.SaveChanges();

                foreach (var fieldmapping in fieldmappingsModified)
                {
                    fieldmapping.Type = type.ToString();
                    if (!string.IsNullOrEmpty(fieldmapping.DatabaseFieldName) || !string.IsNullOrEmpty(fieldmapping.MappedFieldName))
                        entities.FieldMappings.Add(fieldmapping);
                }
                entities.SaveChanges();
            }
        }

        public void SaveComplexLink(ComplexLink complexLink)
        {
            using (var entities = new ModelTopX(Conectionstring))
            {
                entities.ComplexLinks.Add(complexLink);
                entities.SaveChanges();
            }
        }

        public  void Log(string dossier, string message)
        {
            using (var entities = new ModelTopX(Conectionstring))
            {
                entities.Log.Add(new Log() {Id = Guid.NewGuid(), Identifier = dossier, Description = message, DateTime = DateTime.Now });
                entities.SaveChanges();
            }
        }

        public  void ClearLog()
        {
            using (var entities = new ModelTopX(Conectionstring))
            {
                entities.Database.ExecuteSqlCommand("TRUNCATE TABLE log");
            }
        }

        public  string GetLog()
        {
            using (var entities = new ModelTopX(Conectionstring))
            {
                var logEntries = from l in entities.Log select l;
                var stringBuilder = new StringBuilder();
                foreach (var logEntry in logEntries)
                    stringBuilder.AppendLine($"{logEntry.DateTime}\t{logEntry.Identifier}\t{logEntry.Description} ");
                return stringBuilder.ToString();
            }

        }
    }
}
