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
                    using (var stream = File.OpenRead(fileFullpath))
                    {
                        record.Bestand_Formaat_FysiekeIntegriteit_Waarde = GetHash(stream);
                        GetDateFromPdf(stream);
                    }
                       
                }
                else
                {
                    ErrorMessages.AppendLine($"File {fileFullpath} horende bij dossier {record.DossierId} is niet gevonden");
                }
            }
        }

        private string GetHash(Stream stream)
        {
            var sha = new SHA256Managed();
            var hash = sha.ComputeHash(stream);
            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }

        private DateTime GetDateFromPdf(Stream stream)
        {
            var pdf = new Pdf();
            var x = pdf.CreationDate(stream);
            return Convert.ToDateTime("01-01-2001");
            //var date = stream.BeginRead()
        }
        public static long FindPosition(Stream stream, byte[] byteSequence)
        {
            if (byteSequence.Length > stream.Length)
                return -1;

            byte[] buffer = new byte[byteSequence.Length];

            using (BufferedStream bufStream = new BufferedStream(stream, byteSequence.Length))
            {
                int i;
                while ((i = bufStream.Read(buffer, 0, byteSequence.Length)) == byteSequence.Length)
                {
                    if (byteSequence.SequenceEqual(buffer))
                        return bufStream.Position - byteSequence.Length;
                    else
                        bufStream.Position -= byteSequence.Length - PadLeftSequence(buffer, byteSequence);
                }
            }

            return -1;
        }

        private static int PadLeftSequence(byte[] bytes, byte[] seqBytes)
        {
            int i = 1;
            while (i < bytes.Length)
            {
                int n = bytes.Length - i;
                byte[] aux1 = new byte[n];
                byte[] aux2 = new byte[n];
                Array.Copy(bytes, i, aux1, 0, n);
                Array.Copy(seqBytes, aux2, n);
                if (aux1.SequenceEqual(aux2))
                    return i;
                i++;
            }
            return i;
        }
    }
}
