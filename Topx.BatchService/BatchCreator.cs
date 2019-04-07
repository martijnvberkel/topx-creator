using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Topx.Data.DTO;

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
        public StringBuilder Errors = new StringBuilder();
        public void Create(string targetdirectory, string sourceDirectory, List<RIP.recordInformationPackage> listRecordInformationPackage, string topxBaseFileName)
        {
            if (! Directory.Exists(sourceDirectory))
            {
                Errors.AppendLine($"Brondirectory {sourceDirectory} kon niet worden gevonden. Deze bestaat niet, is onbereikbaar of de toegang is geweigerd.");
                return;
            }

            if (!Directory.Exists(targetdirectory))
            {
                Errors.AppendLine($"Doeldirectory {targetdirectory} kon niet worden gevonden. Deze bestaat niet, is onbereikbaar of de toegang is geweigerd.");
                return;
            }

            if (!hasWriteAccessToFolder(targetdirectory))
            {
                Errors.AppendLine($"Je hebt geen schrijfrechten op de doeldirectory {targetdirectory} ");
                return;
            }

            var records = listRecordInformationPackage[0];


            var counter = 0;
            foreach (var recordInformationPackage in listRecordInformationPackage)
            {
                var batchDirectoryPath = Path.Combine(targetdirectory, $"Batch_{counter}");

                try
                {
                    Directory.CreateDirectory(batchDirectoryPath);
                }
                catch (Exception ex)
                {
                    Errors.AppendLine($"FATAL: Subdirectory {batchDirectoryPath} kon niet worden aangemaakt: {ex.Message}");
                    return;
                }
                 // Write TopX eerst
                var fileName = Path.GetFileNameWithoutExtension(topxBaseFileName) + "_" + counter + ".xml";
                
                using (var writer = new StreamWriter(Path.Combine(batchDirectoryPath, fileName) , false, Encoding.UTF8))
                {
                    var serializer = new XmlSerializer(typeof(RIP.recordInformationPackage));
                    serializer.Serialize(writer, recordInformationPackage);
                    writer.Flush();
                }

               // CopyFilesThatBelongToCollectionToTarget(recordInformationPackage, batchDirectoryPath);

                counter++;
            }


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
