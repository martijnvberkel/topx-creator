using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Topx.Data;
using Topx.DataServices;
using Topx.FileAnalysis;

namespace Topx.FileAnalysis
{
}

public class Metadata
{
    private readonly bool _setHash;
    private readonly bool _setSize;
    private readonly bool _setCreationDate;
    private readonly bool _setFileFormatIdentification;
    private readonly string _path;
    private readonly string _droidInstallDirectory;
    private readonly List<Dossier> _dossiers;
    private readonly IDataService _dataService;

    public event EventHandler MetadataEventHandler;

    public bool Error => ErrorMessages.Length > 0;
    public StringBuilder ErrorMessages = new StringBuilder();

    // to check for case-senitive existence
    private readonly List<string> _allPresentFiles;


    public Metadata(bool setHash, bool setSize, bool setCreationDate, bool setFileFormatIdentification, string path, string droidInstallDirectory, List<Dossier> dossiers, IDataService dataService)
    {
        _setHash = setHash;
        _setSize = setSize;
        _setCreationDate = setCreationDate;
        _setFileFormatIdentification = setFileFormatIdentification;
        _path = path;
        _droidInstallDirectory = droidInstallDirectory;
        _dossiers = dossiers;
        _dataService = dataService;
        _allPresentFiles = Directory.GetFiles(path).ToList();
    }

    public void Collect()
    {
        try
        {
            var metadataEvent = new MetadataEventargs(true);
            if (_setSize || _setCreationDate || _setHash)
            {
                GetMataData(metadataEvent);
            }

            if (_setFileFormatIdentification)
            {
                GetFileIdentification(metadataEvent);
            }
        }
        catch (Exception e)
        {
            ErrorMessages.Append(e.Message);
        }
    }

    private void GetFileIdentification(MetadataEventargs metadataEvent)
    {

        MetadataEventHandler?.Invoke(this, metadataEvent);
        var identificator = new Identificator(_droidInstallDirectory, _path);
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
                        }
                    }
                    else
                    {
                        ErrorMessages.AppendLine(fileExists
                            ? $"File {fileFullpath} horende bij dossier {record.DossierId} is niet gescand, er is een verschil in hoofd/kleine letters wat niet is toegestaan (OOK in de bestandsextensie) ."
                            : $"File {fileFullpath} horende bij dossier {record.DossierId} is niet gevonden, let op verschil hoofd/kleine letters, ook in de bestandsextensie");
                    }
                }
                catch (Exception e)
                {
                    ErrorMessages.AppendLine(e.Message);
                }
                _dataService.SaveRecordChanges(record);
            }
        }
    }

    private string GetHash(Stream stream)
    {
        var sha = new SHA256Managed();
        var hash = sha.ComputeHash(stream);
        return BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
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

