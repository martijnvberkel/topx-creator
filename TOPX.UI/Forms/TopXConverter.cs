using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Odbc;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using ByteSizeLib;
using MaterialSkin;
using MaterialSkin.Controls;
using NLog;
using Topx.BatchService;
using Topx.ComplexLinks;
using Topx.Creator;
using Topx.Data;
using Topx.DataServices;
using Topx.Importer;
using Topx.Interface;
using TOPX.UI.Classes;
using Topx.Data.DTO;
using Topx.FileAnalysis;
using Topx.Sidecar;
using Topx.Utility;
using Logger = NLog.Logger;

namespace TOPX.UI.Forms
{
    public partial class TopXConverter : MaterialForm
    {
        private readonly IDataService _dataservice;
        private List<string> _headersDossiers = new List<string>();
        private List<string> _headersRecords = new List<string>();

        private List<FieldMapping> _fieldmappingsDossiers;
        private List<FieldMapping> _fieldmappingsRecords;

        private static ILogger _logger;
        private readonly IIOUtilities _ioUtilities;
        private FormLog _formLog = new FormLog();

        private Headers _headers;
        private Globals _globals;

        private List<RIP.recordInformationPackage> _resultRecordInformationPackage;
        private WaitForm _waitForm;

        private string _lastSelectedDirToScanForMetadata;

        private BackgroundWorker bgworker;

        public TopXConverter(IDataService dataservice, ILogger logger, IIOUtilities ioUtilities)
        {
            _logger = logger;
            _ioUtilities = ioUtilities;
            _dataservice = dataservice;
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey500, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void TopXConverter_Load(object sender, EventArgs e)
        {
            {
                ShowWaitForm("een moment geduld...");
                if (!_dataservice.CanConnect())
                {
                    MessageBox.Show($"Kan de database niet vinden. {Environment.NewLine} Connectionstring: {_dataservice.Connectionstring}");
                    Application.Exit();
                    return;
                }

                _headers = new Headers();
                gridFieldMappingDossiers.AutoGenerateColumns = false;
                gridFieldMappingRecords.AutoGenerateColumns = false;

                Initialize();
                InitTooltips();
                _logger.Info("TopX Converter initalized");
                Updater.InitAutoUpdater();
            }
        }

        private void InitTooltips()
        {
            // Todo 

            //ToolTip toolTip1 = new ToolTip
            //{
            //    AutoPopDelay = 5000,
            //    InitialDelay = 1000,
            //    ReshowDelay = 500,
            //    ShowAlways = true
            //};

            //toolTip1.SetToolTip(this.gridFieldMappingDossiers, "De mappings zijn aan te passen door de bronvelden te verplaatsen met drag & drop");
            //toolTip1.SetToolTip(this.gridFieldMappingRecords, "De mappings zijn aan te passen door de bronvelden te verplaatsen met drag & drop");
        }

        private void ShowWaitForm(string message)
        {
            _waitForm = new WaitForm(message)
            {
                TopMost = true,
                StartPosition = FormStartPosition.CenterScreen
            };
            _waitForm.Show();
            _waitForm.Refresh();
            System.Threading.Thread.Sleep(700);
            Application.Idle += OnLoaded;
        }
        private void OnLoaded(object sender, EventArgs e)
        {
            Application.Idle -= OnLoaded;
            _waitForm.Close();
        }

        private void Initialize()
        {
            _globals = _dataservice.GetGlobals();
            var dossierFile = _globals?.LastDossierFileName;
            txtDossierLocation.Text = _globals?.LastDossierFileName;
            if (File.Exists(dossierFile))
            {
                LoadDossierFile(dossierFile);
            }

            var recordFile = _globals?.LastRecordsFileName;
            txtRecordBestandLocation.Text = _globals?.LastRecordsFileName;
            if (File.Exists(recordFile))
            {
                LoadRecordFile(recordFile);
            }

            txtBronArchief.Text = _globals?.BronArchief;
            txtDatumArchief.Text = _globals?.DatumArchief?.ToString("dd-MM-yyyy");
            txtDoelArchief.Text = _globals?.DoelArchief;
            txtDossierLocation.Text = _globals?.LastDossierFileName;
            txtIdentificatieArchief.Text = _globals?.IdentificatieArchief;
            txtNaamArchief.Text = _globals?.NaamArchief;
            txtOmschrijvingArchief.Text = _globals?.OmschrijvingArchief;
            txtBatchTargetDirectory.Text = _globals?.BatchTargetDirectory;
            txtBatchSourceDirectory.Text = _globals?.BatchSourceDirectory;
            txtSourceDirOfSidecarFiles.Text = _globals?.SourceDirOfSidecarFiles;
            txtTargetDirOfSidecarFiles.Text = _globals?.TargetDirOfSidecarFiles;

            lblVersion.Text = $"v {Application.ProductVersion}";

            if (File.Exists(_globals?.DroidInstallDirectory))
            {
                txtDroidLocation.Text = _globals?.DroidInstallDirectory;
            }
            if (Directory.Exists(_globals?.DirectoryFilesToScanForMetadata))
            {
                txtFilesDirToScan.Text = _globals.DirectoryFilesToScanForMetadata;
            }

            //_lastSelectedDirToScanForMetadata = @"D:\TopX_Data\TestFiles";
            btSaveTopxXml.Enabled = false;
        }

        private void btImportFilesInDb_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txtDossierLocation.Text))
            {
                MessageBox.Show($"Dossier-file niet gevonden.");
                return;
            }
            if (!File.Exists(txtRecordBestandLocation.Text))
            {
                MessageBox.Show($"Records-file niet gevonden.");
                return;
            }

            _dataservice.ClearDossiersAndRecords();


            var importer = new Importer(_dataservice, !chkIgnoreValidationsOfNonMandatoryFields.Checked);
            if (!importer.CheckHealthyFieldmappings(_fieldmappingsDossiers) || !importer.CheckHealthyFieldmappings(_fieldmappingsRecords))
            {
                MessageBox.Show("Niet alle velden zijn gemapped. Corrigeer dit eerst, in de tab 'Bestanden'. ");
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            using (var dossiers = new StreamReader(new FileStream(txtDossierLocation.Text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), Encoding.UTF7))
            {
                importer.SaveDossiers(_fieldmappingsDossiers, dossiers);
                if (importer.Error)
                {
                    txtErrorsDossiers.Text = importer.ErrorMessage + Environment.NewLine + importer.ErrorsImportDossiers;
                    return;
                }


            }

            using (var records = new StreamReader(new FileStream(txtRecordBestandLocation.Text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), Encoding.UTF7))
            {
                importer.SaveRecords(_fieldmappingsRecords, records);
                if (importer.Error)
                {
                    txtErrorRecords.Text = importer.ErrorMessage + Environment.NewLine + importer.ErrorsImportRecords;
                }
            }

            txtErrorRecords.Text = importer.ErrorsImportRecords.ToString();
            txtErrorsDossiers.Text = importer.ErrorsImportDossiers.ToString();
            Cursor.Current = Cursors.Default;

            var msg = string.Empty;
            if (importer.Error)
            {
                MessageBox.Show($"De import is afgerond met errors.");
            }
            else
            {
                MessageBox.Show($"Import is succesvol. Dossiers: {importer.NrOfDossiers}, records: {importer.NrOfRecords}");
                if (importer.ComplexLinksFound)
                {
                    if (MessageBox.Show("Eer zijn dossiers met ComplexLinks gevonden. Klik op OK om door te gaan met het kopieren van records naar dossiers met een overeenkomende ComplexLink",
                            "ComplexLinks", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        var complexLinkProcessor = new ComplexLinkProcessor(_dataservice);
                        complexLinkProcessor.Process();
                        if (complexLinkProcessor.Error)
                        {
                            txtErrorsDossiers.Text += complexLinkProcessor.ErrorMessages.ToString();
                            MessageBox.Show("Het kopiëren van de records naar dossiers met overeenkomstige ComplexLinknummers is afgerond met errors. ");
                        }
                        else
                        {
                            MessageBox.Show("Het kopiëren van records naar dossiers met overeenkomstige ComplexLinknummers is succesvol afgerond.");
                        }
                    }
                }
            }
        }

        private void btGenerateTopX_Click(object sender, EventArgs e)
        {
            if (chkCreateBatchesSubdir.Checked)
            {

                if (!Directory.Exists(txtBatchSourceDirectory.Text))
                {
                    var msgText = string.IsNullOrEmpty(txtBatchSourceDirectory.Text)
                        ? "Wanneer 'Maak directories' is aangevinkt, moet de directory worden aangegeven waar de bronbestanden staan."
                        : $"Bron-directory {txtBatchSourceDirectory.Text} kan niet worden gevonden.";

                    MessageBox.Show(msgText);
                    return;
                }
                if (!Directory.Exists(txtBatchTargetDirectory.Text))
                {
                    var msgText = string.IsNullOrEmpty(txtBatchSourceDirectory.Text)
                        ? "Wanneer 'Maak directories' is aangevinkt, moet de directory worden aangegeven waar de doelbestanden naartoe gekopieerd moeten worden."
                        : $"Doel-directory {txtBatchTargetDirectory.Text} kan niet worden gevonden.";

                    MessageBox.Show(msgText);
                    return;
                }
            }

            try
            {
                _resultRecordInformationPackage = null;
                txtLogTopXCreate.Text = string.Empty;
                txtResultXml.Text = string.Empty;

                Cursor.Current = Cursors.WaitCursor;
                var parser = new Parser(_globals, _dataservice);

                var listofdossiers = _dataservice.GetAllDossiers();

                var batchSize = (long)ByteSize.FromGigaBytes(Convert.ToDouble(txtBatchSize.Text)).Bytes;

                _resultRecordInformationPackage = chkUseBatchSize.Checked
                    ? parser.ParseDataToTopx(listofdossiers, batchSize)
                    : parser.ParseDataToTopx(listofdossiers);

                txtLogTopXCreate.Text = parser.ErrorMessage.ToString();

                Cursor.Current = Cursors.Default;

                if (_resultRecordInformationPackage == null || parser.ErrorMessage.Length != 0)
                {
                    btSaveTopxXml.Enabled = false;
                    MessageBox.Show("Er zijn fouten opgetreden tijdens de conversie, TopX xml kan niet worden gegenereerd", "xml", MessageBoxButtons.OK);
                }
                else
                {
                    btSaveTopxXml.Enabled = true;
                    var xmlhelper = new XmlHelper();
                    var topXResult = xmlhelper.GetXmlStringFromObject(_resultRecordInformationPackage[0]);
                    txtResultXml.Text = topXResult;
                    txtLogTopXCreate.Text = xmlhelper.ValidationErrors.ToString();

                    if (string.IsNullOrEmpty(topXResult) && xmlhelper.ValidationErrors.Length > 0)
                    {
                        MessageBox.Show("Er zijn geen dossiers zonder validatiefouten om te exporteren.");
                        return;
                    }

                    if (_resultRecordInformationPackage.Count > 1 && chkUseBatchSize.Checked && !chkCreateBatchesSubdir.Checked)
                    {
                        var message =
                            $"Er zijn {_resultRecordInformationPackage.Count} TopX-files gegenereerd om de grootte per file te limiteren tot maximaal {txtBatchSize.Text} GB. Wilt u deze opslaan?";
                        if (MessageBox.Show(message, "xml", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            SaveAsXml(_resultRecordInformationPackage);
                        }
                    }
                    else if (_resultRecordInformationPackage.Count == 1 && !chkCreateBatchesSubdir.Checked)
                    {
                        var message = "Save TopX xml?";
                        if (MessageBox.Show(message, "xml", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            SaveAsXml(_resultRecordInformationPackage);
                        }
                    }
                    else if (chkCreateBatchesSubdir.Checked)
                    {
                        var message =
                            $"De batches worden opgeslagen in subdirectories onder {txtBatchTargetDirectory.Text}. Alle reeds aanwezige subdirectories worden GEWIST " +
                            $"om het resultaat zuiver te houden. {Environment.NewLine}Het kopiëren van alle bestanden kan enige tijd kosten, met name wanneer dit over een netwerk gaat. Doorgaan?";
                        if (MessageBox.Show(message, "batches", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            if (DeleteSubDirs(txtBatchTargetDirectory.Text))
                            {
                                ulong totalDiskSizeNeeded = _dataservice.GetTotalSizeNeededBytes();
                                var batches = new BatchCreator();

                                batches.Create(txtBatchTargetDirectory.Text, txtBatchSourceDirectory.Text, _resultRecordInformationPackage, _globals.NaamArchief, totalDiskSizeNeeded);
                                Cursor.Current = Cursors.Default;

                                txtLogTopXCreate.Text = batches.Logs.ToString();
                                MessageBox.Show(batches.Error
                                    ? "Er zijn fouten opgetreden bij het samenstellen van de batches. Zie de error-log."
                                    : "De batches zijn succesvol samengesteld.");
                            }
                            Cursor.Current = Cursors.Default;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(exception.Message);
                txtLogTopXCreate.Text = exception.ToString();
            }
        }

        private bool DeleteSubDirs(string dir)
        {
            var subdirs = Directory.EnumerateDirectories(dir);
            foreach (var subdir in subdirs)
            {
                try
                {
                    Directory.Delete(subdir, true);
                }
                catch (Exception e)
                {
                    MessageBox.Show($"De al aanwezige subdirectory ${subdir} kon niet worden verwijderd: {e.Message}");
                    return false;
                }
            }
            return true;
        }

        private void SaveAsXml(List<RIP.recordInformationPackage> recordInformationPackages)
        {
            var savefile = new SaveFileDialog { FileName = $"{_globals.NaamArchief}.xml" };

            if (savefile.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(savefile.FileName))
            {
                var counter = 0;
                foreach (var recordInformationPackage in recordInformationPackages)
                {
                    var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(savefile.FileName) + "_" + counter;

                    // Wanneer collectie maar 1 xml bevat, is het niet nodig om een getal toe te voegen aan de naam.
                    var newFullPath = _resultRecordInformationPackage.Count > 1
                        ? Path.Combine(Path.GetDirectoryName(savefile.FileName) ?? string.Empty, fileNameWithoutExtension + ".xml")
                        : savefile.FileName;

                    using (var writer = new StreamWriter(newFullPath, false, Encoding.UTF8))
                    {
                        var serializer = new XmlSerializer(typeof(RIP.recordInformationPackage));
                        serializer.Serialize(writer, recordInformationPackage);
                        writer.Flush();
                    }
                    counter++;
                }
            }
        }

        private bool IsFileOpen(string fileName)
        {
            FileStream stream = null;
            var file = new FileInfo(fileName);

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                stream?.Close();
            }
            //file is not locked
            return false;
        }

        private void btFillDatumArchief_Click(object sender, EventArgs e)
        {
            var datetimeToday = DateTime.Now.Date;
            txtDatumArchief.Text = datetimeToday.ToString("dd-MM-yyyy");
            _globals.DatumArchief = datetimeToday;
            _dataservice.SaveGlobals(_globals);
        }


        private void SaveGlobals(object sender, EventArgs e)
        {
            _globals = new Globals
            {
                BronArchief = txtBronArchief.Text,
                DoelArchief = txtDoelArchief.Text,

                NaamArchief = txtNaamArchief.Text,
                IdentificatieArchief = txtIdentificatieArchief.Text,
                OmschrijvingArchief = txtOmschrijvingArchief.Text,
                BatchSourceDirectory = txtBatchSourceDirectory.Text,
                BatchTargetDirectory = txtBatchTargetDirectory.Text,
                DroidInstallDirectory = txtDroidLocation.Text,
                DirectoryFilesToScanForMetadata = txtFilesDirToScan.Text,
                SourceDirOfSidecarFiles = txtSourceDirOfSidecarFiles.Text,
                TargetDirOfSidecarFiles = txtTargetDirOfSidecarFiles.Text
            };

            if (!string.IsNullOrEmpty(txtDatumArchief.Text))
            {
                DateTime tempdatumArchief;
                if (DateTime.TryParseExact(txtDatumArchief.Text, "dd-MM-yyyy", new CultureInfo("nl-NL"), DateTimeStyles.None, out tempdatumArchief))
                {
                    _globals.DatumArchief = tempdatumArchief;
                }
            }
            _dataservice.SaveGlobals(_globals);
        }


        private void picDossierSelector_Click(object sender, EventArgs e)
        {
            if (openFileDialogDossiers.ShowDialog() == DialogResult.OK)
            {
                if (IsFileOpen(openFileDialogDossiers.FileName))
                {
                    MessageBox.Show("Dossierbestand is geopend door een andere applicatie");
                    return;
                }
                txtDossierLocation.Text = openFileDialogDossiers.FileName;
                LoadDossierFile(openFileDialogDossiers.FileName);
                _dataservice.SaveLastDossierFileName(openFileDialogDossiers.FileName);
            }

        }

        private void ShowInvalidCsvMessage(string fileName)
        {
            MessageBox.Show($"Het aangeboden bestand {fileName} is geen (valide) csv-bestand. Controleer met een simpele editor als Notepad of Notepad++ de bestandsopmaak. Let erop dat de scheidingstekens puntkomma zijn. De bestandsnaam moet de extensie .csv hebben");
        }
        private void LoadDossierFile(string fileName, bool useCachedMappings = true)
        {
            try
            {
                if (!_ioUtilities.TestForValidCSV(fileName))
                {
                    ShowInvalidCsvMessage(fileName);
                    return;
                }
                using (var sr = new StreamReader(new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                {
                    var firstLine = sr.ReadLine();
                    if (firstLine == null)
                    {
                        MessageBox.Show($"De header (= de eerste regel) in de file {Path.GetFileName(fileName)} is leeg. Controleer de file op systeemkarakters zoals een tab of newline etc. met (bijvoorbeeld) Notepad++");
                        return;
                    }

                    var positionOfSystemCharacters = StringUtilities.CheckForSystemCharacters(firstLine);
                    if (positionOfSystemCharacters > 0)
                    {
                        MessageBox.Show($"De header (= de eerste regel) in de file {Path.GetFileName(fileName)} is niet valide. Er is een Control-karakter gevonden op positie {positionOfSystemCharacters}. Controleer de file op systeemkarakters zoals een tab of newline etc. met (bijvoorbeeld) Notepad++");
                        return;
                    }

                    _headersDossiers = firstLine.Split(";"[0]).ToList();
                    if (_headersDossiers.Count < 20 || _headersDossiers.Count > 40) // dan is het zeker dat er wat mis is
                    {
                        ShowInvalidCsvMessage(fileName);
                        return;
                    }

                }
                if (useCachedMappings)
                    _fieldmappingsDossiers = _dataservice.GetMappingsDossiers(_headersDossiers);

                if (_fieldmappingsDossiers == null || !useCachedMappings)
                {
                    _fieldmappingsDossiers = _headers.GetHeaderMappingDossiers(_headersDossiers);
                    _dataservice.SaveMappings(_fieldmappingsDossiers, FieldMappingType.DOSSIER);
                }
                gridFieldMappingDossiers.DataSource = _fieldmappingsDossiers;

            }
            catch (Exception e)
            {
                MessageBox.Show($"Het bestand kon niet worden ingelezen. Foutmelding: {e.Message}");
            }
        }
        private void LoadRecordFile(string fileName, bool useCachedMappings = true)
        {
            try
            {
                if (!_ioUtilities.TestForValidCSV(fileName))
                {
                    ShowInvalidCsvMessage(fileName);
                    return;
                }
                using (var sr = new StreamReader(new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                {
                    var firstLine = sr.ReadLine();
                    if (firstLine == null)
                    {
                        MessageBox.Show($"De header (= de eerste regel) in de file {Path.GetFileName(fileName)} is leeg. Controleer de file op systeemkarakters zoals een tab of newline etc. met (bijvoorbeeld) Notepad++");
                        return;
                    }

                    var positionOfSystemCharacters = StringUtilities.CheckForSystemCharacters(firstLine);
                    if (positionOfSystemCharacters > 0)
                    {
                        MessageBox.Show($"De header (= de eerste regel) in de file {Path.GetFileName(fileName)} is niet valide. Er is een Control-karakter gevonden op positie {positionOfSystemCharacters}. Controleer de file op systeemkarakters zoals een tab of newline etc. met (bijvoorbeeld) Notepad++");
                        return;
                    }
                    _headersRecords = firstLine.Split(";"[0]).ToList();
                    if (_headersDossiers.Count < 20 || _headersDossiers.Count > 40) // dan is het zeker dat er wat mis is
                    {
                        ShowInvalidCsvMessage(fileName);
                        return;
                    }
                }

                _fieldmappingsRecords = _dataservice.GetMappingsRecords(_headersRecords);
                if (_fieldmappingsRecords == null || !useCachedMappings)
                {
                    _fieldmappingsRecords = _headers.GetHeaderMappingRecordsBestanden(_headersRecords);
                    _dataservice.SaveMappings(_fieldmappingsRecords, FieldMappingType.RECORD);
                }
                gridFieldMappingRecords.DataSource = _fieldmappingsRecords;

            }
            catch (Exception e)
            {
                MessageBox.Show($"Het bestand kon niet worden ingelezen. Foutmelding: {e.Message}");
            }
        }

        private void picRecordsSelector_Click(object sender, EventArgs e)
        {
            if (openFileDialogRecords.ShowDialog() == DialogResult.OK)
            {
                if (IsFileOpen(openFileDialogRecords.FileName))
                {
                    MessageBox.Show("Dossierbestand is geopend door een andere applicatie");
                    return;
                }
                txtRecordBestandLocation.Text = openFileDialogRecords.FileName;
                LoadRecordFile(openFileDialogRecords.FileName);
                _dataservice.SaveLastRecordsFileName(openFileDialogRecords.FileName);
            }
        }

        private void gridFieldMappingRecords_Leave(object sender, EventArgs e)
        {
            _dataservice.SaveMappings(_fieldmappingsRecords, FieldMappingType.RECORD);
        }

        private void linkCopyErrorsDossiers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(txtErrorsDossiers.Text);
        }

        private void linkCopyErrorsRecords_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(txtErrorRecords.Text);
        }

        private void gridFieldMappingDossiers_Leave(object sender, EventArgs e)
        {

        }

        private void gridFieldMappingDossiers_DataSourceChanged(object sender, EventArgs e)
        {
            if (_fieldmappingsDossiers != null)
                _dataservice.SaveMappings(_fieldmappingsDossiers, FieldMappingType.DOSSIER);
        }

        private void gridFieldMappingRecords_DataSourceChanged(object sender, EventArgs e)
        {
            if (_fieldmappingsRecords != null)
                _dataservice.SaveMappings(_fieldmappingsRecords, FieldMappingType.RECORD);
        }

        private void linkCopyTopXCreateError_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(txtLogTopXCreate.Text);
        }

        private void btSaveTopxXml_Click(object sender, EventArgs e)
        {
            if (_resultRecordInformationPackage != null)
                SaveAsXml(_resultRecordInformationPackage);
            else
            {
                MessageBox.Show("Er is geen data aanwezig om op te slaan.");
            }
        }

        // ++++++++++++++++++++++++++++++++++++++++ Tab Metadata +++++++++++++++++++++++++++++++++++++++++++++++++

        private void picSelectDirToScan_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.SelectedPath = _lastSelectedDirToScanForMetadata;
                var result = folderBrowserDialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    txtFilesDirToScan.Text = folderBrowserDialog.SelectedPath;
                    _lastSelectedDirToScanForMetadata = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void btGenerateMetadata_Click(object sender, EventArgs e)
        {
            txtProgressMetaData.Text = string.Empty;
            if (!Directory.Exists(txtFilesDirToScan.Text))
            {
                MessageBox.Show($"De directory {txtFilesDirToScan.Text} kan niet worden gevonden.");
                return;
            }
            if (!checkGetCreationDate.Checked && !chkGetFileSignature.Checked && !chkGetFileSize.Checked && !chkGetHash.Checked && !chkTestForPasswProtection.Checked)
            {
                MessageBox.Show("Er is geen bewerking geselecteerd");
                return;
            }
            if (chkGetFileSignature.Checked && (!File.Exists(txtDroidLocation.Text) || Path.GetFileName(txtDroidLocation.Text) != "droid.bat"))
            {
                MessageBox.Show("Voor vaststellen van de File Signature moet eerst de locatie van droid.bat worden aangegeven (DROID moet eerst door jezelf worden geïnstalleerd). Dat is nodig omdat TopX Creator van deze tool gebruik maakt.");
                return;
            }

            Application.UseWaitCursor = true;

            InitBackgroundWorker();
            if (!bgworker.IsBusy)
            {

                bgworker.RunWorkerAsync();
                btGenerateMetadata.Enabled = false;
            }
        }

        private void InitBackgroundWorker()
        {
            bgworker = new BackgroundWorker();
            bgworker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            bgworker.RunWorkerCompleted += backgroundWorker_Completed;
            bgworker.ProgressChanged += Bgworker_ProgressChanged;
            bgworker.WorkerReportsProgress = true;
            bgworker.WorkerSupportsCancellation = true;
        }

        private void backgroundWorker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            btGenerateMetadata.Enabled = true;
            btGenerateMetadata.Focus();
            btMetadataCancel.Enabled = false;
            MessageBox.Show("Analyse metadata gereed");
            Application.UseWaitCursor = false;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var path = txtFilesDirToScan.Text;
            var fileAnalysis = new Metadata(chkGetHash.Checked, chkGetFileSize.Checked, checkGetCreationDate.Checked, chkGetFileSignature.Checked, chkTestForPasswProtection.Checked, path, txtDroidLocation.Text, _dataservice.GetAllDossiers(), _dataservice, _logger);
            fileAnalysis.MetadataEventHandler += IncreaseProgress;

            fileAnalysis.Collect();

            Invoke(new Action(() =>
                {
                    txtMetadataErrors.Text = fileAnalysis.ErrorMessages.ToString();
                }
            ));
        }

        private void Bgworker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            var values = (EventCounter)e.UserState;
            txtProgressMetaData.Text = $"Aantal dossiers: {values.DossiersCount}";
            if (values.DroidStarted)
            {
                txtProgressMetaData.Text += $"{Environment.NewLine}DROID bestandsanalyse gestart. Dit kan even duren...";
            }
            if (values.IsReady)
            {
                txtProgressMetaData.Text += $"{Environment.NewLine}Aantal door DROID geïdentificeerde bestanden: {values.TotalRecordsIdentified}";
            }
        }

        private void btMetadataCancel_Click(object sender, EventArgs e)
        {
            bgworker.CancelAsync();
            btGenerateMetadata.Enabled = true;
        }

        private void IncreaseProgress(object sender, EventArgs eventArgs)
        {
            var x = (MetadataEventargs)eventArgs;
            var values = x.GetProgress();
            bgworker.ReportProgress(values.DossiersProgress, values);

        }

        private void linkCopyMetadataErrors_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(txtMetadataErrors.Text);
        }


        private void gridFieldMappingDossiers_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    var currentRow = gridFieldMappingDossiers.HitTest(e.X, e.Y).RowIndex;

                    gridFieldMappingDossiers.ClearSelection();
                    gridFieldMappingDossiers.Rows[currentRow].Selected = true;

                    var screenPoint = ((Control)sender).PointToScreen(e.Location);
                    var formPoint = PointToClient(screenPoint); //this is the Form object
                    var formSelectDossierMapper =
                        new FormSelectMapper(_fieldmappingsDossiers, gridFieldMappingDossiers.Rows[currentRow].Cells[0].Value?.ToString())
                        {
                            Location = new Point(Location.X + formPoint.X + 50, Location.Y + formPoint.Y - 30)
                        };
                    formSelectDossierMapper.ShowDialog();
                    gridFieldMappingDossiers.DataSource = _fieldmappingsDossiers.ToList();

                }
                catch  // swallow exception
                {
                }
            }
        }


        private void gridFieldMappingRecords_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var currentRow = gridFieldMappingDossiers.HitTest(e.X, e.Y).RowIndex;

                gridFieldMappingRecords.ClearSelection();
                gridFieldMappingRecords.Rows[currentRow].Selected = true;

                var screenPoint = ((Control)sender).PointToScreen(e.Location);
                var formPoint = PointToClient(screenPoint); //this is the Form object
                var formSelectMapper =
                    new FormSelectMapper(_fieldmappingsRecords, gridFieldMappingRecords.Rows[currentRow].Cells[0].Value.ToString())
                    {
                        Location = new Point(Location.X + formPoint.X + 50, Location.Y + formPoint.Y - 30)
                    };
                formSelectMapper.ShowDialog();
                gridFieldMappingRecords.DataSource = _fieldmappingsRecords.ToList();
            }
        }
        private void btClearMappingsDossiers_Click(object sender, EventArgs e)
        {
            LoadDossierFile(txtDossierLocation.Text, useCachedMappings: false);
        }

        private void btClearMappingsRecords_Click(object sender, EventArgs e)
        {
            LoadRecordFile(txtRecordBestandLocation.Text, useCachedMappings: false);
        }

        private void gridFieldMappingDossiers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void btSaveDossierMapping_Click(object sender, EventArgs e)
        {
            SaveFieldMappingsToFile(_fieldmappingsDossiers, "Save dossiers");
        }
        private void btSaveRecordMapping_Click(object sender, EventArgs e)
        {
            SaveFieldMappingsToFile(_fieldmappingsRecords, "Save records");
        }

        private void btLoadRecordMapping_Click(object sender, EventArgs e)
        {
            if (LoadMappingFromFile(FieldMappingType.RECORD, _fieldmappingsRecords))
            {
                gridFieldMappingRecords.DataSource = null; // fix to force grid updating
                gridFieldMappingRecords.DataSource = _fieldmappingsRecords;
            }
        }
        private void btLoadDossierMapping_Click(object sender, EventArgs e)
        {
            if (LoadMappingFromFile(FieldMappingType.DOSSIER, _fieldmappingsDossiers))
            {
                gridFieldMappingDossiers.DataSource = null; // fix to force grid updating
                gridFieldMappingDossiers.DataSource = _fieldmappingsDossiers;
            }
        }

        private void SaveFieldMappingsToFile(List<FieldMapping> mappings, string title)
        {
            var savedial = new SaveFileDialog { Filter = "XML-File | *.xml", Title = title };
            savedial.ShowDialog();
            if (string.IsNullOrEmpty(savedial.FileName))
                return;
            try
            {
                using (var writer = savedial.OpenFile())
                {
                    var serializer = new XmlSerializer(typeof(List<FieldMapping>));
                    serializer.Serialize(writer, mappings);
                    writer.Flush();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Fout bij opslaan gegevens: {e.Message}");
            }
        }

        private bool LoadMappingFromFile(FieldMappingType fieldMappingType, List<FieldMapping> mapping)
        {
            var openFiledialog = new OpenFileDialog() { Filter = "XML-File | *.xml" };
            openFiledialog.ShowDialog();
            if (string.IsNullOrEmpty(openFiledialog.FileName))
                return false;

            try
            {
                using (var stream = File.OpenRead(openFiledialog.FileName))
                {
                    var serializer = new XmlSerializer(typeof(List<FieldMapping>));
                    var tempMappings = (List<FieldMapping>)serializer.Deserialize(stream);
                    mapping.Clear();

                    if (fieldMappingType == FieldMappingType.DOSSIER)
                    {
                        foreach (var tempDossierMapping in tempMappings)
                        {
                            if (string.IsNullOrEmpty(tempDossierMapping.DatabaseFieldName))
                                continue;
                            if (!_headersDossiers.Contains(tempDossierMapping.DatabaseFieldName, StringComparer.OrdinalIgnoreCase))
                            {
                                MessageBox.Show($"Er is een fout gevonden in het mappingbestand: Het veld {tempDossierMapping.DatabaseFieldName} is niet toegestaan in dossiermappings");
                                return false;
                            }
                        }
                    }

                    if (fieldMappingType == FieldMappingType.RECORD)
                    {
                        foreach (var tempRecordMapping in tempMappings)
                        {
                            if (string.IsNullOrEmpty(tempRecordMapping.DatabaseFieldName))
                                continue;
                            if (!_headersRecords.Contains(tempRecordMapping.DatabaseFieldName, StringComparer.OrdinalIgnoreCase))
                            {
                                MessageBox.Show($"Er is een fout gevonden in het mappingbestand: Het veld {tempRecordMapping.DatabaseFieldName} is niet toegestaan in recordmappings");
                                return false;
                            }
                        }
                    }

                    foreach (var tempDossierMapping in tempMappings)
                    {
                        if (!string.IsNullOrEmpty(tempDossierMapping.MappedFieldName) || !string.IsNullOrEmpty(tempDossierMapping.DatabaseFieldName))
                            mapping.Add(new FieldMapping()
                            {
                                MappedFieldName = tempDossierMapping.MappedFieldName,
                                DatabaseFieldName = tempDossierMapping.DatabaseFieldName,
                                TMLO = tempDossierMapping.TMLO
                            });
                    }
                    _dataservice.SaveMappings(mapping, fieldMappingType);
                }
                return true;
            }

            catch (Exception e)
            {
                MessageBox.Show($"Fout bij inlezen gegevens: {e.Message}");
                return false;
            }
        }

        private void txtBatchSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtBatchSize_Leave(object sender, EventArgs e)
        {
            txtBatchSize.Text = Regex.Replace(txtBatchSize.Text, "[^0-9.]", "");
            if (string.IsNullOrEmpty(txtBatchSize.Text))
            {
                txtBatchSize.Text = "0";
            }
        }

        private void picSelectBatchTargetDir_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                var result = folderBrowserDialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    txtBatchTargetDirectory.Text = folderBrowserDialog.SelectedPath;
                    SaveGlobals(null, null);
                }
            }
        }

        private void picSelectBatchSourceDir_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                var result = folderBrowserDialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    txtBatchSourceDirectory.Text = folderBrowserDialog.SelectedPath;
                    SaveGlobals(null, null);
                }
            }
        }

        private void chkCreateBatchesSubdir_CheckedChanged(object sender, EventArgs e)
        {
            txtBatchSourceDirectory.Enabled = chkCreateBatchesSubdir.Checked;
            txtBatchTargetDirectory.Enabled = chkCreateBatchesSubdir.Checked;
            picSelectBatchSourceDir.Enabled = chkCreateBatchesSubdir.Checked;
            picSelectBatchTargetDir.Enabled = chkCreateBatchesSubdir.Checked;

        }

        private void picSelectDroidLocation_Click(object sender, EventArgs e)
        {
            {
                var openfiledialog = new OpenFileDialog();
                ;
                if (openfiledialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(openfiledialog.FileName))
                {
                    txtDroidLocation.Text = openfiledialog.FileName;


                    if (File.Exists(openfiledialog.FileName))
                    {
                        txtDroidLocation.BackColor = DefaultBackColor;
                        SaveGlobals(null, null);
                    }
                    else
                    {
                        txtDroidLocation.BackColor = Color.DarkSalmon;
                        MessageBox.Show("droid.bat is niet aanwezig in de aangegeven folder.");
                    }
                }
            }
        }

        private void txtFilesDirToScan_Leave(object sender, EventArgs e)
        {
            SaveGlobals(null, null);
        }

        private void txtDroidLocation_Leave(object sender, EventArgs e)
        {
            SaveGlobals(null, null);
        }


        private void gridFieldMappingDossiers_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {

        }

        // ++++++++++++++++++++++++++++++++++++++++ Tab Sidecar-export +++++++++++++++++++++++++++++++++++++++++++++++++

        private void picSelectSourceDirOfSidecarFiles_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                var result = folderBrowserDialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    txtSourceDirOfSidecarFiles.Text = folderBrowserDialog.SelectedPath;
                    SaveGlobals(null, null);
                }
            }
        }

        private void picSelectTargetDirOfSidecarFiles_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                var result = folderBrowserDialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    txtTargetDirOfSidecarFiles.Text = folderBrowserDialog.SelectedPath;
                    SaveGlobals(null, null);
                }
            }
        }

        private void btGenerateSidecarExport_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtTargetDirOfSidecarFiles.Text) && MessageBox.Show($"Alle bestanden in de doeldirectory {txtTargetDirOfSidecarFiles.Text} worden gewist. Doorgaan?", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            if (_resultRecordInformationPackage?[0] == null)
            {
                MessageBox.Show("Er is geen TopX-data aanwezig. Ga naar tab 'Genereer TopX' en zorg ervoor dat er een TopX-bestand wordt gegenereerd. Deze hoeft - voor een sidecar-export - niet te worden opgeslagen.");
                return;
            }

            if (!Directory.Exists(txtSourceDirOfSidecarFiles.Text))
            {
                MessageBox.Show($"De brondirectory {txtSourceDirOfSidecarFiles.Text} is niet bereikbaar of bestaat niet.");
                return;
            }

            if (!Directory.Exists(txtTargetDirOfSidecarFiles.Text))
            {
                MessageBox.Show($"De doeldirectory voor de Sidecar-export {txtTargetDirOfSidecarFiles.Text} is niet bereikbaar of bestaat niet.");
                return;
            }

            var sidecarExport = new Export(txtSourceDirOfSidecarFiles.Text, txtTargetDirOfSidecarFiles.Text, _ioUtilities, _logger);
            var doc = new XDocument();
            using (var writer = doc.CreateWriter())
            {
                var serializer = new XmlSerializer(_resultRecordInformationPackage[0].GetType());
                serializer.Serialize(writer, _resultRecordInformationPackage[0]);
            }

            Cursor.Current = Cursors.WaitCursor;

            // Perform Sidecar-export
            var nrOfBatches = chkSidecarMakeBatches.Checked ? Convert.ToInt32(txtSidecarNrOfBatches.Text) : 0;
            var success = sidecarExport.Create(doc, nrOfBatches);

            Cursor.Current = Cursors.Default;

            if (sidecarExport.Error)
            {
                txtLogSidecarExport.Text = sidecarExport.ErrorMessage.ToString();
                linkOpenSidecarExportInExplorer.Visible = false;
            }
            else
            {
                txtLogSidecarExport.Text = $"{sidecarExport.NrOfDossiersExported} dossiers succesvol geëxporteerd.";
                linkOpenSidecarExportInExplorer.Visible = true;
            }

            MessageBox.Show(success
                ? "Sidecar-export is gereed"
                : "Errors in Sidecar-export");
        }

        private void linkOpenSidecarExportInExplorer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            IOUtilities.ShowExplorer(txtTargetDirOfSidecarFiles.Text);
        }

        private void txtSidecarNrOfBatches_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Prevent non-numeric chars
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void chkSidecarMakeBatches_CheckedChanged(object sender, EventArgs e)
        {
            txtSidecarNrOfBatches.Enabled = chkSidecarMakeBatches.Checked;
        }

        private void LblInfo_Click(object sender, EventArgs e)
        {
            var info = new Info()
            {
                TopMost = true,
                StartPosition = FormStartPosition.CenterScreen
            };
            info.Show();
        }

        private void linkLabelDROID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelDROID.LinkVisited = true;
            try
            {
                Process.Start("https://www.nationalarchives.gov.uk/information-management/manage-information/preserving-digital-records/droid/");
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Kan de link niet openen. Foutmelding: {exception.Message}");
            }
        }

        private void chkIgnoreValidationsOfNonMandatoryFields_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
