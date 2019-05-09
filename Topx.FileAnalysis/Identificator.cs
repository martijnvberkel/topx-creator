using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Topx.Data;

namespace Topx.FileAnalysis
{
    public class Identificator
    {
        public bool Error;

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                Error = true;
            }
        }

        private readonly string _droidCommandlineLocation;
        
        private readonly string _command;
        private string _errorMessage;


        public Identificator(string droidCommandlineLocation, string fileslocationToIdentify)
        {
            FileInfo signatureFileInfo;
            try
            {
                var signatureFilesDir = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE"), @".droid6\signature_files");
                var dir = new DirectoryInfo(signatureFilesDir);
                signatureFileInfo = dir.GetFiles("DROID_SignatureFile*").OrderByDescending(p => p.Name).FirstOrDefault();
            }
            catch (Exception e)
            {
                Error = true;
                ErrorMessage = "Er is geen DROID signaturefile gevonden. Start DROID eerst met de hand, en download de laatste signaturefiles.";
                return;
            }
         
            _droidCommandlineLocation = droidCommandlineLocation;

            _command = $@"droid -Nr {fileslocationToIdentify} -Ns ""{Path.Combine(signatureFileInfo.FullName)}""";
        }
      
       
        public void IdentifyFiles(List<Record> records)
        {
            if (records == null || !records.Any())
            {
                ErrorMessage = "Er zijn geen records gevonden, mogelijk zijn die nog niet geïmporteerd.";
                return;
            }

            //Create process
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process
            {
                StartInfo =
                {
                    FileName = _droidCommandlineLocation,
                    Arguments = _command,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            try
            {
                pProcess.Start();
            }
            catch (Exception e)
            {
                ErrorMessage = "DROID kon niet worden gestart. Mogelijk is de locatie niet juist aangegeven, "
                               + "of DROID is onjuist geinstalleerd. Probeer DROID eerst met de hand te starten om het probleem op te lossen.";
            }
            
            //Get program output
            var strOutput = pProcess.StandardOutput.ReadToEnd();

            //Wait for process to finish
            pProcess.WaitForExit();

            var terminaloutput = new List<string>();
            using (var reader = new StringReader(strOutput))
            {
                
                var line = string.Empty;
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        terminaloutput.Add(line);
                    }

                } while (line != null);
            }

            foreach (var line in terminaloutput)
            {
                var entry = line.Split(',');
                if (entry.Length == 2)  // alleen dan hebben we een entry met een bestandsnaam en een identificatie
                {
                    var file = Path.GetFileName(entry[0]);
                    var identification = entry[1];

                    var record = records.FirstOrDefault(t => t.Bestand_Formaat_Bestandsnaam == file);
                    if (record != null)
                    {
                        record.Bestand_Formaat_BestandsFormaat = identification;
                    }
                }
            }
        }
    }
}
