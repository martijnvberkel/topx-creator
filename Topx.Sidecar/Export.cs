using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using NLog;
using Topx.Utility;


public interface IExport
{
    bool Create(XDocument xdoc, string sourceDirOfSidecarFiles,
        string targetDirOfSidecarFiles);
}
public class Export 
{
    public StringBuilder ErrorMessage = new StringBuilder();
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
        try
        {
            if (_ioUtilities.DirectoryExists(_targetDir))
                _ioUtilities.DeleteDirectoryAndContent(_targetDir);
               

            System.Threading.Thread.Sleep(100);
            _ioUtilities.CreateDirectory(_targetDir);

            WriteHeader(xdoc, _targetDir);
            var archiefDir = WriteArchief(xdoc, _targetDir);

            WriteDossiers(xdoc, archiefDir);

            return ErrorMessage.Length == 0;
        }
        catch (Exception e)
        {
            ErrorMessage.AppendLine(e.Message);
            _logger.Error(e);
            return false;
        }
    }

    private void WriteDossiers(XDocument xdoc, string archiefDir)
    {
        foreach (var dossier in xdoc.Descendants(nsArchf + "aggregatie") .Where(t => t.Element(nsArchf + "aggregatieniveau")?.Value == "Dossier"))
        {
            var idkenmerk = dossier.Element(nsArchf + "identificatiekenmerk")? .Value;
            var dirDossier = Path.Combine(archiefDir, idkenmerk ?? throw new InvalidOperationException("identificatiekenmerk ontbreekt"));

            _ioUtilities.CreateDirectory(dirDossier);
            _ioUtilities.Save(dossier.Parent, Path.Combine(dirDossier, $"{idkenmerk}.metadata"));

            var recordsOfDossiers = xdoc.Descendants(nsArchf + "aggregatie")
                .Where(t => t.Descendants(nsArchf + "relatieID").FirstOrDefault()?.Value == idkenmerk 
                            && t.Descendants(nsArchf + "aggregatieniveau").FirstOrDefault()?.Value == "Record");

            foreach (var record in recordsOfDossiers)
            {
                WriteRecord(record, xdoc, dirDossier);
            }
        }
    }

    private void WriteRecord(XElement record, XDocument xdoc, string dossierDir)
    {
        var idkenmerkRecord = record.Element(nsArchf + "identificatiekenmerk")?.Value;
        var directoryName = idkenmerkRecord.Split('_')[1];
        var recordDir = Path.Combine(dossierDir, directoryName);

        _ioUtilities.CreateDirectory(recordDir);
        _ioUtilities.Save(record.Parent, Path.Combine(recordDir, $"{idkenmerkRecord}.metadata"));

        var bestanden  = xdoc.Descendants(nsArchf + "bestand")
            .Where(t => t.Descendants(nsArchf + "relatieID").FirstOrDefault()?.Value == idkenmerkRecord
                        && t.Descendants(nsArchf + "aggregatieniveau").FirstOrDefault()?.Value == "Bestand");

        foreach (var bestand in bestanden)
        {
            WriteBestand(bestand, recordDir);
        }
    }

    private void WriteBestand(XElement bestand, string recordDir)
    {
        var bestandsNaam = bestand.Descendants(nsArchf + "bestandsnaam").First(). Element(nsArchf + "naam")?. Value;
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
            ErrorMessage.AppendLine($"Bestand {fileFullSourcePath} niet gevonden");
        }
    }

    private void WriteHeader(XDocument xdoc, string targetDir)
    {

        var headerElement = xdoc.Descendants(nsHeader + "packageHeader").FirstOrDefault();
        var identificatie = headerElement.Element(nsHeader + "identificatie").Value;
        _ioUtilities.Save(headerElement, Path.Combine(targetDir, identificatie));
       
    }

    private string WriteArchief(XDocument xdoc, string targetDir)
    {
        var elementArchief = xdoc.Descendants (nsArchf + "aggregatie").FirstOrDefault(t => t.Element(nsArchf + "aggregatieniveau").Value == "Archief");
        var archiefNaam = elementArchief.Element(nsArchf + "naam").Value;
        var identificatiekenmerk = elementArchief.Element(nsArchf + "identificatiekenmerk").Value;

        var archiefDir = Path.Combine(targetDir, archiefNaam);
        Directory.CreateDirectory(archiefDir);
        _ioUtilities.Save(elementArchief.Parent, Path.Combine(archiefDir, $"{identificatiekenmerk}.metadata"));
        return archiefDir;
    }
}

