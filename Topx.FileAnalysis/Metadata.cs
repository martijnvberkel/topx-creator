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
        private readonly bool _setHash;
        private readonly bool _setSize;
        private readonly bool _setCreationDate;
        private readonly bool _setFileFormatIdentification;
        private readonly string _path;
        private readonly List<Record> _records;
        public bool Error;
        public StringBuilder ErrorMessages = new StringBuilder();

        public Metadata(bool setHash, bool setSize, bool setCreationDate, bool setFileFormatIdentification, string path, List<Record> records)
        {
            _setHash = setHash;
            _setSize = setSize;
            _setCreationDate = setCreationDate;
            _setFileFormatIdentification = setFileFormatIdentification;
            _path = path;
            _records = records;
        }

        public bool TestIfAllFilesArePresent()
        {
            var filesInDir = Directory.GetFiles(_path) .Select(Path.GetFileName) .ToList();
            var filesInDirCount = filesInDir.Count();

            if (filesInDirCount < _records.Count)
            {
                ErrorMessages.AppendLine($"In de dir {_path} staan {filesInDirCount} files, en er zijn {_records.Count} records aanwezig. ");
                foreach (var record in _records)
                {
                    if (!filesInDir.Contains(record.Bestand_Formaat_Bestandsnaam))
                    {
                        ErrorMessages.Append($"File {record.Bestand_Formaat_Bestandsnaam} niet gevonden in {_path}");
                    }
                }
                return false;
            }
            return true;
        }

        public void Collect()
        {
            foreach (var record in _records)
            {
                var fileFullpath = Path.Combine(_path, record.Bestand_Formaat_Bestandsnaam);
                if (File.Exists(fileFullpath))
                {

                    if (_setCreationDate)
                        record.Bestand_Formaat_DatumAanmaak = File.GetCreationTime(fileFullpath);

                    using (var stream = File.OpenRead(fileFullpath))
                    {
                       if (_setSize)
                            record.Bestand_Formaat_BestandsOmvang = stream.Length;

                        if (_setHash)
                        {
                            record.Bestand_Formaat_FysiekeIntegriteit_Waarde = GetHash(stream);
                            record.Bestand_Formaat_FysiekeIntegriteit_DatumEnTijd = DateTime.Now;
                            record.Bestand_Formaat_FysiekeIntegriteit_Algoritme = "sha256";
                        }
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
