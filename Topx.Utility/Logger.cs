using System;
using System.Linq;
using System.Text;
using Topx.Data;

namespace Topx.Utility
{
    public class Logger
    {
        public static void Log(string dossier, string message)
        {
            using (var entities = new TOPX_GenericEntities())
            {
                entities.Log.Add(new Log() { Identifier = dossier, Description = message, DateTime = DateTime.Now });
                entities.SaveChanges();
            }
        }

        public static string GetLog()
        {
            using (var entities = new TOPX_GenericEntities())
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
