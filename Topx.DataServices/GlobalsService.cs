using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topx.Data;

namespace Topx.DataServices
{
    public class GlobalsService
    {
        public static void SaveLastDossierFileName(string fileName)
        {
            using (var entities = new ModelTopX())
            {
                var globals = (from g in entities.Globals select g).FirstOrDefault() ?? new Globals();
                globals.LastDossierFileName = fileName;
                entities.SaveChanges();
            }
        }
        public static void SaveLastRecordsFileName(string fileName)
        {
            using (var entities = new ModelTopX())
            {
                var globals = (from g in entities.Globals select g).FirstOrDefault() ?? new Globals();
                globals.LastRecordsFileName = fileName;
                entities.SaveChanges();
            }
        }

        public static string GetLastDossierFileName()
        {
            using (var entities = new ModelTopX())
            {
                return (from g in entities.Globals select g).FirstOrDefault()?.LastDossierFileName;
            }
        }

        public static string GetLastRecordsFileName()
        {
            using (var entities = new ModelTopX())
            {
                return (from g in entities.Globals select g).FirstOrDefault()?.LastRecordsFileName;
            }
        }

        public static Globals GetGlobals()
        {
            using (var entities = new ModelTopX())
            {
                return (from g in entities.Globals select g).FirstOrDefault();
            }
        }

    }
}
