using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using NLog;
using Topx.Data;
using Topx.DataServices;

namespace Topx.FileAnalysis
{
    public class Metadata
    {
        private readonly bool _setHash;
        private readonly bool _setSize;
        private readonly bool _setCreationDate;
        private readonly bool _setFileFormatIdentification;
        private readonly bool _testForPwProtection;
        private readonly string _path;
        private readonly string _droidInstallDirectory;
        private readonly List<Dossier> _dossiers;
        private readonly IDataService _dataService;
        private readonly ILogger _logger;

        public event EventHandler MetadataEventHandler;

        public bool Error => ErrorMessages.Length > 0;
        public StringBuilder ErrorMessages = new StringBuilder();

        // to check for case-senitive existence
        private readonly List<string> _allPresentFiles;


        public Metadata(bool setHash, bool setSize, bool setCreationDate, bool setFileFormatIdentification, bool testForPwProtection, string path, string droidInstallDirectory, List<Dossier> dossiers, IDataService dataService, ILogger logger)
        {
            _setHash = setHash;
            _setSize = setSize;
            _setCreationDate = setCreationDate;
            _setFileFormatIdentification = setFileFormatIdentification;
            _testForPwProtection = testForPwProtection;
            _path = path;
            _droidInstallDirectory = droidInstallDirectory;
            _dossiers = dossiers;
            _dataService = dataService;
            _logger = logger;
            _allPresentFiles = Directory.GetFiles(path).ToList();
        }

        public void Collect()
        {
            var metadataEvent = new MetadataEventargs(false);
            if (_setSize || _setCreationDate || _setHash)
            {
                GetMataData(metadataEvent);
            }

            if (_setFileFormatIdentification)
            {
                metadataEvent.Eventcounter.DroidStarted = true;
                GetFileIdentification(metadataEvent);
            }
        }

        private void GetFileIdentification(MetadataEventargs metadataEvent)
        {

            MetadataEventHandler?.Invoke(this, metadataEvent);
            var identificator = new Identificator(_droidInstallDirectory, _path, _logger);
            var records = _dataService.GetAllRecords();
            foreach (var record in records)
            {
                record.Bestand_Formaat_BestandsFormaat = string.Empty;
            }

            identificator.IdentifyFiles(records);
            if (identificator.Error)
                ErrorMessages.AppendLine(identificator.ErrorMessage);

            var count = 0;
            foreach (var record in records.Where(t => t.Bestand_Formaat_Bestandsnaam != string.Empty))
            {
                _dataService.SaveRecordChanges(record);
                count++;
            }
            metadataEvent.Eventcounter.TotalRecordsIdentified = count;
            metadataEvent.Eventcounter.IsReady = true;
            MetadataEventHandler?.Invoke(this, metadataEvent);
        }

        private void GetMataData(MetadataEventargs metadataEventargs)
        {
            var counter = 0;
            var steps = _dossiers.Count / 10;
            if (steps == 0)
                steps = 1;
            foreach (var dossier in _dossiers)
            {
                counter++;
                if (steps > 0 && counter % steps == 0)
                {
                    var progress = counter * 100 / _dossiers.Count;
                    metadataEventargs.Eventcounter.DossiersProgress = progress;
                    metadataEventargs.Eventcounter.DossiersCount = counter;
                    MetadataEventHandler?.Invoke(this, metadataEventargs);
                }
                foreach (var record in dossier.Records)
                {
                    try
                    {
                        var fileFullpath = Path.Combine(_path, record.Bestand_Formaat_Bestandsnaam);
                        var fileExists = File.Exists(fileFullpath);

                        if (fileExists && _allPresentFiles.Contains(fileFullpath))
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

                                if (_testForPwProtection && Path.GetExtension(fileFullpath).ToLower() != ".pdf") // alles behalve pdf
                                {
                                    if (MsOffice.IsPasswordProtected(stream))
                                    {
                                        ErrorMessages.AppendLine($"ERROR: password-protected document gevonden: {Path.GetFileName(fileFullpath)}");
                                    }
                                }
                            }

                            if (_testForPwProtection && Path.GetExtension(fileFullpath).ToLower() == ".pdf")
                            {
                                var checkPasswProtection = Pdf.IsPasswordProtected(fileFullpath);

                                if (checkPasswProtection == null)
                                {
                                    ErrorMessages.AppendLine($"Pdf password protection module kan bestand {Path.GetFileName(fileFullpath)} niet openen, mogelijk is deze niet benaderbaar");
                                }
                                if (checkPasswProtection == true)
                                {
                                    ErrorMessages.AppendLine($"ERROR: password-protected document gevonden: {Path.GetFileName(fileFullpath)}");
                                }
                            }
                        }
                        else
                        {
                            ErrorMessages.AppendLine(fileExists
                                ? $"File {Path.GetFileName(fileFullpath)} horende bij dossier {record.DossierId} is niet gescand, er is een verschil in hoofd/kleine letters wat niet is toegestaan (OOK in de bestandsextensie) ."
                                : $"File {Path.GetFileName(fileFullpath)} horende bij dossier {record.DossierId} is niet gevonden, let op verschil hoofd/kleine letters, ook in de bestandsextensie");
                        }
                    }
                    catch (Exception e)
                    {
                        ErrorMessages.AppendLine(e.Message);
                    }
                    _dataService.SaveRecordChanges(record);
                    metadataEventargs.Eventcounter.DossiersCount = counter;
                    MetadataEventHandler?.Invoke(this, metadataEventargs);
                }
            }
        }

        private string GetHash(Stream stream)
        {
            var sha = new SHA256Managed();
            var hash = sha.ComputeHash(stream);
            return BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
        }
    }
}