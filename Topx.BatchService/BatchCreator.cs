using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using ByteSizeLib;
using Topx.Data.DTO;
using Topx.Utility;

namespace Topx.BatchService
{
    public class BatchServiceEventargs : EventArgs
    {
        public int Progress;

        public BatchServiceEventargs(int progress)
        {
            Progress = progress;
        }

        public int GetProgress()
        {
            return Progress;
        }
    }
    public class BatchCreator
    {
        public StringBuilder Logs = new StringBuilder();
        private XNamespace nameSpace = "http://www.nationaalarchief.nl/ToPX/v2.3";

        public void Create(string targetrootdirectory, string sourceDirectory, List<RIP.recordInformationPackage> listRecordInformationPackage, string topxBaseFileName, ulong totalSizeBytesNeeded)
        {
            try
            {
                if (totalSizeBytesNeeded > IOUtilities.DiskspaceBytes(targetrootdirectory))
                {
                    Logs.AppendLine($"Er is onvoldoende schijfruimte beschikbaar op {targetrootdirectory}. Benodigd: {Math.Round(ByteSize.FromBytes(totalSizeBytesNeeded) .MegaBytes)} MB");
                    return;
                }
            }
            catch (Exception ex)
            {
                Logs.AppendLine($"ERROR: Kon de beschikbare diskruimte niet vaststellen: {ex.Message}");
                return;
            }

            if (!Directory.Exists(sourceDirectory))
            {
                Logs.AppendLine($"Brondirectory {sourceDirectory} kon niet worden gevonden. Deze bestaat niet, is onbereikbaar of de toegang is geweigerd.");
                return;
            }

            if (!Directory.Exists(targetrootdirectory))
            {
                Logs.AppendLine($"Doeldirectory {targetrootdirectory} kon niet worden gevonden. Deze bestaat niet, is onbereikbaar of de toegang is geweigerd.");
                return;
            }

            if (!hasWriteAccessToFolder(targetrootdirectory))
            {
                Logs.AppendLine($"Je hebt geen schrijfrechten op de doeldirectory {targetrootdirectory} ");
                return;
            }

            var subdirIndex = 0;
            foreach (var recordInformationPackage in listRecordInformationPackage)
            {
                var targetdirectory = Path.Combine(targetrootdirectory, $"batch_{subdirIndex}");
                Directory.CreateDirectory(targetdirectory);

                XDocument topx = new XDocument();
                using (var writer = topx.CreateWriter())
                {
                    var serializer = new XmlSerializer(recordInformationPackage.GetType());
                    serializer.Serialize(writer, recordInformationPackage);
                }

                var topxFilename = Path.GetFileNameWithoutExtension(topxBaseFileName) + "_" + subdirIndex + ".xml";

                topx.Save(Path.Combine(targetdirectory, topxFilename));

                foreach (var element in topx.Descendants(nameSpace + "bestandsnaam"))
                {
                    var file = element.Element(nameSpace + "naam")?.Value;
                    var extension = element.Element(nameSpace + "extensie")?.Value;
                    if (!string.IsNullOrEmpty(extension))
                        file += "." + extension;

                    if (string.IsNullOrEmpty(file))
                    {
                        Logs.AppendLine("Ëlement 'naam' onder 'bestandsnaam' mag niet leeg zijn");
                        continue;
                    }

                    var fullpathSource = Path.Combine(sourceDirectory, file);
                    var fullpathDestination = Path.Combine(targetdirectory, file);
                    try
                    {
                        File.Copy(fullpathSource, fullpathDestination);
                    }
                    catch (Exception e)
                    {
                        Logs.AppendLine($"ERROR: Kan file ${file} niet kopiëren naar doeldirectory: {e.Message}");
                    }
                }
                subdirIndex++;
            }
            Logs.AppendLine();
            Logs.AppendLine($"INFO: Aantal batches: {subdirIndex + 1}");

        }

        private bool hasWriteAccessToFolder(string folderPath)
        {
            try
            {
                // Attempt to get a list of security permissions from the folder. 
                // This will raise an exception if the path is read only or do not have access to view the permissions. 
                System.Security.AccessControl.DirectorySecurity ds = Directory.GetAccessControl(folderPath);
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
        }
    }
}
