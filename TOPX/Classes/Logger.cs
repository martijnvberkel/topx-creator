using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOPX.Classes
{
    public class Logger
    {
        public static void Log(string dossier, string message)
        {
            using (var entities = new TOPXEntities())
            {
                entities.Log.Add(new Log() {Bestand = dossier, Omschrijving = message, DateTime = DateTime.Now});
                entities.SaveChanges();
            }
        }

        public static string GetLog()
        {
            using (var entities = new TOPXEntities())
            {
                var logEntries = from l in entities.Log select l;
                var stringBuilder = new StringBuilder();
                foreach (var logEntry in logEntries)
                    stringBuilder.AppendLine($"{logEntry.DateTime}\t{logEntry.Bestand}\t{logEntry.Omschrijving} ");
                return stringBuilder.ToString();
            }
            
        }
    }
}
