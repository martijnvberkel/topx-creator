using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Topx.Data;

namespace Topx.FileAnalysis
{
    
    public class Metadata
    {
        public bool Error;
        public StringBuilder ErrorMessages = new StringBuilder();

        public void Collect(string path, List<Record> records, List<Bestand> bestanden)
        {
            foreach (var record in records)
            {
                // Hash
                var fileFullpath = Path.Combine(path, record.Bestand_Formaat_Bestandsnaam);
                if (File.Exists(fileFullpath))
                {
                    record.Bestand_Formaat_FysiekeIntegriteit_Waarde = GetHash(fileFullpath);
                }
                else
                {
                    ErrorMessages.AppendLine($"File {fileFullpath} horende bij dossier {record.DossierId} is niet gevonden");
                }
            }
        }

        private string GetHash(string path)
        {
            using (var stream = File.OpenRead(path))
            {
                var sha = new SHA256Managed();
                var hash = sha.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", string.Empty);
            }
        }
    }
}
