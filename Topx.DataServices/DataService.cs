using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using Topx.Data;


namespace Topx.DataServices
{

    public interface IDataService
    {
        void SaveLastDossierFileName(string fileName);
        void SaveLastRecordsFileName(string fileName);
        string GetLastDossierFileName();
        string GetLastRecordsFileName();
        Globals GetGlobals();
        void SaveGlobals(Globals globals);
        void SaveDossier(Dossier dossier);
        void SaveRecord(Record record);
        void ClearDossiersAndRecords();
        List<FieldMapping> GetMappingsDossiers();
        List<FieldMapping> GetMappingsRecords();
        void SaveMappings(List<FieldMapping> fieldmappingdossiers, FieldMappingType type);
    }

    public class DataService : IDataService
    {
        public DataService()
        {
        }

        public void ClearDossiersAndRecords()
        {
            using (var entities = new ModelTopX())
            {
                entities.Database.ExecuteSqlCommand("truncate table Records");
                entities.Database.ExecuteSqlCommand("truncate table Bestanden");
                entities.Database.ExecuteSqlCommand("delete from Dossiers");
            }
        }

        public void SaveLastDossierFileName(string fileName)
        {
            using (var entities = new ModelTopX())
            {
                var globals = (from g in entities.Globals select g).FirstOrDefault() ?? new Globals();
                globals.LastDossierFileName = fileName;
                entities.SaveChanges();
            }
        }

        public void SaveLastRecordsFileName(string fileName)
        {
            using (var entities = new ModelTopX())
            {
                var globals = (from g in entities.Globals select g).FirstOrDefault() ?? new Globals();
                globals.LastRecordsFileName = fileName;
                entities.SaveChanges();
            }
        }

        public string GetLastDossierFileName()
        {
            using (var entities = new ModelTopX())
            {
                return (from g in entities.Globals select g).FirstOrDefault()?.LastDossierFileName;
            }
        }

        public string GetLastRecordsFileName()
        {
            using (var entities = new ModelTopX())
            {
                return (from g in entities.Globals select g).FirstOrDefault()?.LastRecordsFileName;
            }
        }

        public Globals GetGlobals()
        {
            using (var entities = new ModelTopX())
            {
                return (from g in entities.Globals select g).FirstOrDefault();
            }
        }

        public void SaveGlobals(Globals globals)
        {
            using (var entities = new ModelTopX())
            {
                var globalsFirstRecord = (from g in entities.Globals select g).FirstOrDefault();
                if (globalsFirstRecord != null)
                    entities.Entry(globalsFirstRecord).CurrentValues.SetValues(globals);
                else
                {
                    entities.Globals.Add(globals);
                }
                entities.SaveChanges();
            }
        }

        public void SaveDossier(Dossier dossier)
        {
            using (var entities = new ModelTopX())
            {
                entities.Dossiers.Add(dossier);
                entities.SaveChanges();
            }
        }
        public void SaveRecord(Record record)
        {
            using (var entities = new ModelTopX())
            {
                var dossierId = record.DossierId;
                if (!entities.Dossiers.Any(t => t.IdentificatieKenmerk == dossierId))
                {
                    recorde
                }
                entities.Records.Add(record);
                entities.SaveChanges();
            }
        }

        public List<FieldMapping> GetMappingsDossiers()
        {
            using (var entities = new ModelTopX())
            {
                return (from m in entities.FieldMappings where m.Type == "DOSSIER" select m) .ToList();
            }
        }
        public List<FieldMapping> GetMappingsRecords()
        {
            using (var entities = new ModelTopX())
            {
                return (from m in entities.FieldMappings where m.Type == "RECORD" select m).ToList();
            }
        }

        public void SaveMappings(List<FieldMapping> fieldmappingsModified, FieldMappingType type)
        {
            using (var entities = new ModelTopX())
            {
                var fieldmappings = from m in entities.FieldMappings where m.Type == type.ToString() select m;
                entities.FieldMappings.RemoveRange(fieldmappings);
                entities.SaveChanges();

                foreach (var fieldmapping in fieldmappingsModified)
                {
                    fieldmapping.Type = type.ToString();
                    entities.FieldMappings.Add(fieldmapping);
                }
                entities.SaveChanges();
            }
        }
    }
}
