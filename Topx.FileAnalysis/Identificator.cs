﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using NLog;
using Topx.Data;
using Topx.Utility;

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


        public Identificator(string droidCommandlineLocation, string fileslocationToIdentify, ILogger logger)
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
            logger.Info($"droidCommandlineLocation: {_droidCommandlineLocation}");

            _command = $@"-Nr ""{fileslocationToIdentify}"" -Ns ""{Path.Combine(signatureFileInfo.FullName)}""";
            logger.Info($"command: {_command}");
        }


        public void IdentifyFiles(List<Record> records)
        {
            if (records == null || !records.Any())
            {
                ErrorMessage = "Er zijn geen records gevonden, mogelijk zijn die nog niet geïmporteerd.";
                return;
            }
            var output = new StringBuilder();
            var error = new StringBuilder();
            using (var process = new Process())
            {
                process.StartInfo.FileName = _droidCommandlineLocation;
                process.StartInfo.Arguments = _command;

                var javaPath = IOUtilities.GetJavaInstallationPath();
                if (!string.IsNullOrEmpty(javaPath))
                {
                    if (process.StartInfo.EnvironmentVariables.ContainsKey("PATH"))
                        process.StartInfo.EnvironmentVariables["PATH"] = Path.Combine(javaPath, "bin");
                    else
                    {
                        process.StartInfo.EnvironmentVariables.Add("PATH",
                            Path.Combine(IOUtilities.GetJavaInstallationPath(), "bin"));
                    }
                }

                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                using (AutoResetEvent outputWaitHandle = new AutoResetEvent(false))
                using (AutoResetEvent errorWaitHandle = new AutoResetEvent(false))
                {
                    process.OutputDataReceived += (sender, e) =>
                    {
                        if (e.Data == null)
                        {
                            outputWaitHandle.Set();
                        }
                        else
                        {
                            output.AppendLine(e.Data);
                        }
                    };
                    process.ErrorDataReceived += (sender, e) =>
                    {
                        if (e.Data == null)
                        {
                            errorWaitHandle.Set();
                        }
                        else
                        {
                            error.AppendLine(e.Data);
                        }
                    };

                    process.Start();

                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    process.WaitForExit();
                }
            }

            if (error.Length > 0)
            {
                var tempError = error.ToString();
                using (var reader = new StringReader(tempError))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!line.StartsWith("WARNING"))
                        {
                            _errorMessage += line + Environment.NewLine;
                            Error = true;
                        }
                    }
                }

                if (Error)
                    return;
            }

            string[] delim = { Environment.NewLine, "\n" };
            foreach (var line in output.ToString().Split(delim, StringSplitOptions.None).ToArray())
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
