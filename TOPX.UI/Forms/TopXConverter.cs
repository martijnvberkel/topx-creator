﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;
using MaterialSkin;
using MaterialSkin.Controls;
using NLog;
using Topx.ComplexLinks;
using Topx.Creator;
using Topx.Data;
using Topx.DataServices;
using Topx.Importer;
using Topx.Interface;
using TOPX.UI.Classes;
using Topx.Data.DTO;
using Topx.FileAnalysis;
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

        private static Logger _logger;
        private FormLog _formLog = new FormLog();

        private Headers _headers;
        private Globals _globals;

        private List<RIP.recordInformationPackage> _resultRecordInformationPackage;
        private WaitForm _waitForm;

        private string _lastSelectedDirToScanForMetadata;

        private BackgroundWorker bgworker;

        public TopXConverter(IDataService dataservice)
        {
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
                    MessageBox.Show($"Kan de database niet vinden. {Environment.NewLine} Connectionstring: {_dataservice.Conectionstring}");
                    Application.Exit();
                    return;
                }
                Logging.Init();
                _logger = LogManager.GetCurrentClassLogger();
                _headers = new Headers();

                gridFieldMappingDossiers.AutoGenerateColumns = false;
                gridFieldMappingRecords.AutoGenerateColumns = false;

                Initialize();
                InitTooltips();
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
            lblVersion.Text = $"v {Application.ProductVersion}";

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


            var importer = new Importer(_dataservice);
            if (!importer.CheckHealthyFieldmappings(_fieldmappingsDossiers) || !importer.CheckHealthyFieldmappings(_fieldmappingsRecords))
            {
                MessageBox.Show("Niet alle velden zijn gemapped. Corrigeer dit eerst, in de tab 'Bestanden'. ");
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            using (var dossiers = new StreamReader(new FileStream(txtDossierLocation.Text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                importer.SaveDossiers(_fieldmappingsDossiers, dossiers);
                if (importer.Error)
                {
                    txtErrorsDossiers.Text = importer.ErrorMessage + Environment.NewLine + importer.ErrorsImportDossiers;
                    return;
                }

                
            }

            using (var records = new StreamReader(new FileStream(txtRecordBestandLocation.Text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
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
            try
            {
                _resultRecordInformationPackage = null;
                txtLogTopXCreate.Text = string.Empty;
                txtResultXml.Text = string.Empty;

                Cursor.Current = Cursors.WaitCursor;
                var parser = new Parser(_globals, _dataservice);

                var listofdossiers = _dataservice.GetAllDossiers();
                var batchSize = (long) Convert.ToInt32(txtBatchSize.Text) * (long)1073741824; // GB naar bytes

                _resultRecordInformationPackage = chkUseBatchSize.Checked 
                    ? parser.ParseDataToTopx(listofdossiers, batchSize) 
                    : parser.ParseDataToTopx(listofdossiers);

                txtLogTopXCreate.Text = parser.ErrorMessage.ToString();

                Cursor.Current = Cursors.Default;

                if (_resultRecordInformationPackage != null && parser.ErrorMessage.Length == 0)
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

                    var message = _resultRecordInformationPackage.Count > 1 
                        ? $"Er zijn {_resultRecordInformationPackage.Count} TopX-files gegenereerd om de grootte per file te limiteren tot maximaal {txtBatchSize.Text} GB. Wilt u deze opslaan?" 
                        : "Save TopX xml?";

                    if (MessageBox.Show(message, "xml", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        SaveAsXml(_resultRecordInformationPackage);
                    }
                }

                else
                {
                    btSaveTopxXml.Enabled = false;
                    MessageBox.Show("Er zijn fouten opgetreden tijdens de conversie, TopX xml kan niet worden gegenereerd", "xml", MessageBoxButtons.OK);
                }

            }
            catch (Exception exception)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(exception.Message);
                txtLogTopXCreate.Text = exception.ToString();
            }
        }

        private void SaveAsXml( List <RIP.recordInformationPackage> recordInformationPackages)
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
                OmschrijvingArchief = txtOmschrijvingArchief.Text
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

        private void LoadDossierFile(string fileName, bool useCachedMappings = true)
        {
            try
            {
                using (var sr = new StreamReader(new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                {
                    _headersDossiers = sr.ReadLine().Split(";"[0]).ToList();
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
                using (var sr = new StreamReader(new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                {
                    _headersRecords = sr.ReadLine().Split(";"[0]).ToList();
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



        private void btImportDossiers_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txtDossierLocation.Text))
            {
                MessageBox.Show("Bestand niet gevonden.");
            }
            else
            {
                _dataservice.SaveLastDossierFileName(txtDossierLocation.Text);
                LoadDossierFile(txtDossierLocation.Text);
            }
        }

        private void btLoadRecords_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txtRecordBestandLocation.Text))
            {
                MessageBox.Show("Bestand niet gevonden.");
            }
            else
            {
                LoadRecordFile(txtRecordBestandLocation.Text);
                _dataservice.SaveLastRecordsFileName(txtRecordBestandLocation.Text);
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
            if (!Directory.Exists(txtFilesDirToScan.Text))
            {
                MessageBox.Show($"De directory {txtFilesDirToScan.Text} kan niet worden gevonden.");
                return;
            }
            if (!checkGetCreationDate.Checked && !chkGetFileSignature.Checked && !chkGetFileSize.Checked && !chkGetHash.Checked)
            {
                MessageBox.Show("Er is geen bewerking geselecteerd");
                return;
            }
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
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var path = txtFilesDirToScan.Text;
            var fileAnalysis = new Metadata(chkGetHash.Checked, chkGetFileSize.Checked, checkGetCreationDate.Checked, chkGetFileSignature.Checked, path, _dataservice.GetAllDossiers(), _dataservice);
            fileAnalysis.DossierHandled += IncreaseProgress;
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
        }

        private void btMetadataCancel_Click(object sender, EventArgs e)
        {
            bgworker.CancelAsync();
            btGenerateMetadata.Enabled = true;
        }

        private void IncreaseProgress(object sender, EventArgs eventArgs)
        {
            var x = (MetadataEventargs)eventArgs;
            bgworker.ReportProgress(x.GetProgress());
        }

        private void linkCopyMetadataErrors_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(txtMetadataErrors.Text);
        }


        private void gridFieldMappingDossiers_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var currentRow = gridFieldMappingDossiers.HitTest(e.X, e.Y).RowIndex;

                gridFieldMappingDossiers.ClearSelection();
                gridFieldMappingDossiers.Rows[currentRow].Selected = true;

                var screenPoint = ((Control)sender).PointToScreen(e.Location);
                var formPoint = PointToClient(screenPoint); //this is the Form object
                var formSelectDossierMapper =
                    new FormSelectMapper(_fieldmappingsDossiers, gridFieldMappingDossiers.Rows[currentRow].Cells[0].Value.ToString())
                    {
                        Location = new Point(Location.X + formPoint.X + 50, Location.Y + formPoint.Y - 30)
                    };
                formSelectDossierMapper.ShowDialog();
                gridFieldMappingDossiers.DataSource = _fieldmappingsDossiers.ToList();
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
    }
}
