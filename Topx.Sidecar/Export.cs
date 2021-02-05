using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using NLog;
using Topx.Utility;

namespace Topx.Sidecar
{
    public class Export 
    {
        public StringBuilder ErrorMessage { get; set; }

        public bool Error => ErrorMessage.Length != 0;
        public int NrOfDossiersExported { get; set; }

        private readonly ILogger _logger;
        private readonly string _sourceDirOfSidecarFiles;
        private readonly string _targetDir;
        private readonly IIOUtilities _ioUtilities;

        private readonly XNamespace nsHeader = "http://www.nationaalarchief.nl/RIP/v0.3";
        private readonly XNamespace nsArchf = "http://www.nationaalarchief.nl/ToPX/v2.3";


        public Export(string sourceDirOfSidecarFiles, string targetDir, IIOUtilities ioUtilities, ILogger logger)
        {
            _logger = logger;
            _sourceDirOfSidecarFiles = sourceDirOfSidecarFiles;
            _targetDir = targetDir;
            _ioUtilities = ioUtilities;
        }

        public bool Create(XDocument xdoc)
        {
           return Create(xdoc, 0);
        }
        public bool Create(XDocument xdoc, int nrOfBatches)
        {
            _logger.Info("Create export started");
            ErrorMessage = new StringBuilder();
            try
            {
                if (_ioUtilities.DirectoryExists(_targetDir))
                    _ioUtilities.DeleteDirectoryAndContent(_targetDir);

                System.Threading.Thread.Sleep(100);
                _ioUtilities.CreateDirectory(_targetDir);

               //WriteHeader(xdoc, _targetDir);
                var archiefDir = WriteArchief(xdoc, _targetDir);

                WriteDossiers(xdoc, archiefDir, nrOfBatches);

                return ErrorMessage.Length == 0;
            }
            catch (Exception e)
            {
                ErrorMessage.AppendLine(e.Message);
                _logger.Error(e);
                return false;
            }
        }

        private void WriteDossiers(XDocument xdoc, string archiefDir, int nrOfBatches)
        {
            NrOfDossiersExported = 0;
            foreach (var dossier in xdoc.Descendants(nsArchf + "aggregatie").Where(t => t.Element(nsArchf + "aggregatieniveau")?.Value == "Dossier"))
            {
                var idkenmerk = dossier.Element(nsArchf + "identificatiekenmerk")?.Value;
                var dirDossier = Path.Combine(archiefDir, idkenmerk ?? throw new InvalidOperationException("identificatiekenmerk ontbreekt"));

                _ioUtilities.CreateDirectory(dirDossier);
                _ioUtilities.Save(dossier.Parent, Path.Combine(dirDossier, $"{idkenmerk}.metadata"));
                _logger.Info($"Dossier {idkenmerk} saved");

                var recordsOfDossiers = xdoc.Descendants(nsArchf + "aggregatie")
                    .Where(t => t.Descendants(nsArchf + "relatieID").FirstOrDefault()?.Value == idkenmerk
                                && t.Descendants(nsArchf + "aggregatieniveau").FirstOrDefault()?.Value == "Record");

                foreach (var record in recordsOfDossiers)
                {
                    WriteRecord(record, xdoc, dirDossier);
                }

                NrOfDossiersExported += 1;
                if (nrOfBatches != 0 && NrOfDossiersExported >= nrOfBatches)
                {
                    _logger.Info($"nrOfBatches {nrOfBatches} reached");
                    break;
                }
                    
            }
        }

        private void WriteRecord(XElement record, XDocument xdoc, string dossierDir)
        {
            var idkenmerkRecord = record.Element(nsArchf + "identificatiekenmerk")?.Value;

            if (!IOUtilities.IsValidDirectoryName(idkenmerkRecord) || !IOUtilities.IsValidDirectoryName(idkenmerkRecord))
            {
                var logmessage = $"De samengestelde mapnaam {dossierDir}\\{idkenmerkRecord} bevat niet-toegestane karakters";
                ErrorMessage.AppendLine(logmessage); 
                _logger.Error(logmessage);
                return;
            }

            var recordDir = Path.Combine(dossierDir, idkenmerkRecord);

            _ioUtilities.CreateDirectory(recordDir);
            _ioUtilities.Save(record.Parent, Path.Combine(recordDir, $"{idkenmerkRecord}.metadata"));

            var bestanden = xdoc.Descendants(nsArchf + "bestand")
                .Where(t => t.Descendants(nsArchf + "relatieID").FirstOrDefault()?.Value == idkenmerkRecord
                            && t.Descendants(nsArchf + "aggregatieniveau").FirstOrDefault()?.Value == "Bestand");

            foreach (var bestand in bestanden)
            {
                WriteBestand(bestand, recordDir);
            }
        }

        private void WriteBestand(XElement bestand, string recordDir)
        {
            var bestandsNaam = bestand.Descendants(nsArchf + "bestandsnaam").First().Element(nsArchf + "naam")?.Value;
            _ioUtilities.Save(bestand.Parent, Path.Combine(recordDir, $"{bestandsNaam}.metadata"));

            var extension = bestand.Descendants(nsArchf + "bestandsnaam").First().Element(nsArchf + "extensie")?.Value;

            bestandsNaam = bestandsNaam + "." + extension;
            var fileFullSourcePath = Path.Combine(_sourceDirOfSidecarFiles, bestandsNaam);
            if (_ioUtilities.FileExists(Path.Combine(_sourceDirOfSidecarFiles, bestandsNaam)))
            {
                _ioUtilities.FileCopy(fileFullSourcePath, Path.Combine(recordDir, bestandsNaam));
            }
            else
            {
                _logger.Error($"Bestand {fileFullSourcePath} niet gevonden");
                ErrorMessage.AppendLine($"Bestand {fileFullSourcePath} niet gevonden");
            }
        }

        private void WriteHeader(XDocument xdoc, string targetDir)
        {

            var headerElement = xdoc.Descendants(nsHeader + "packageHeader").FirstOrDefault();
            var identificatie = headerElement.Element(nsHeader + "identificatie").Value;
            _ioUtilities.Save(headerElement, Path.Combine(targetDir, identificatie));
            _logger.Info($"header {identificatie} saved");
        }

        private string WriteArchief(XDocument xdoc, string targetDir)
        {
            var elementArchief = xdoc.Descendants(nsArchf + "aggregatie").FirstOrDefault(t => t.Element(nsArchf + "aggregatieniveau").Value == "Archief");
            var archiefNaam = elementArchief.Element(nsArchf + "naam").Value;
            var identificatiekenmerk = elementArchief.Element(nsArchf + "identificatiekenmerk").Value;

            var archiefDir = Path.Combine(targetDir, identificatiekenmerk);
            Directory.CreateDirectory(archiefDir);
            _ioUtilities.Save(elementArchief.Parent, Path.Combine(archiefDir, $"{identificatiekenmerk}.metadata"));
            _logger.Info($"archief {archiefNaam} saved");
            return archiefDir;
        }
    }
}