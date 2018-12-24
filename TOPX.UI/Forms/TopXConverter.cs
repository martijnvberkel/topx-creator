using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using MaterialSkin;
using MaterialSkin.Controls;
using NLog;
using Topx.Creator;
using Topx.Data;
using Topx.DataServices;
using Topx.Importer;
using Topx.Interface;
using Topx.Parser.Model;
using TOPX.UI.Classes;
using AutoUpdaterDotNET;

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

        private WaitForm _waitForm;

        public TopXConverter(IDataService dataservice)
        {
            _dataservice = dataservice;
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            //materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
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

                InitDefaultFilesLoad();
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

        private void InitDefaultFilesLoad()
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
                LoadRecordFile(recordFile, loadfromCache: true);
            }

            txtBronArchief.Text = _globals?.BronArchief;
            txtDatumArchief.Text = _globals?.DatumArchief?.ToString("dd-MM-yyyy");
            txtDoelArchief.Text = _globals?.DoelArchief;
            txtDossierLocation.Text = _globals?.LastDossierFileName;
            txtIdentificatieArchief.Text = _globals?.IdentificatieArchief;
            txtNaamArchief.Text = _globals?.NaamArchief;
            txtOmschrijvingArchief.Text = _globals?.OmschrijvingArchief;
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
                    txtErrorsDossiers.Text = importer.ErrorMessage;
                }
            }

            using (var records = new StreamReader(new FileStream(txtRecordBestandLocation.Text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                importer.SaveRecords(_fieldmappingsRecords, records);
                if (importer.Error)
                {
                    txtErrorRecords.Text = importer.ErrorMessage;
                }
            }

            txtErrorRecords.Text = importer.ErrorsImportRecords.ToString();
            txtErrorsDossiers.Text = importer.ErrorsImportDossiers.ToString();
            Cursor.Current = Cursors.Default;

            MessageBox.Show(importer.Error ? "De import is afgerond met errors." : "De dossiers- en records/bestanden-metadata zijn succesvol geïmporteerd.");
        }

        private void btGenerateTopX_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var parser = new Parser(_globals, _dataservice);

                var listofdossiers = _dataservice.GetAllDossiers();
                var result = parser.ParseDataToTopx(listofdossiers);
                txtLogTopXCreate.Text = parser.ErrorMessage.ToString();

                Cursor.Current = Cursors.Default;

                if (result != null && parser.ErrorMessage.Length == 0)
                {
                    if (MessageBox.Show("Save xml?", "xml", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        SaveAsXml(result);
                    }
                }
                else
                {
                    if (parser.ErrorMessage.Length > 0 && result == null)
                    {
                        MessageBox.Show("Er zijn fouten opgetreden tijdens de conversie, TopX xml kan niet worden gegenereerd", "xml", MessageBoxButtons.OK);
                    }
                    else
                    {
                        if (MessageBox.Show("Er zijn fouten opgetreden tijdens de conversie. Wilt u de gegenereerde TopX xml toch opslaan?", "xml", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            SaveAsXml(result);
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

        private void SaveAsXml(recordInformationPackage result)
        {
            var savefile = new SaveFileDialog { FileName = "export.xml" };

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                var encoding = Encoding.UTF8;
                using (var writer = new StreamWriter(savefile.FileName, false, encoding))
                {
                    var serializer = new XmlSerializer(typeof(recordInformationPackage));
                    serializer.Serialize(writer, result);
                    writer.Flush();
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



        private void txtDossierLocation_TextChanged(object sender, EventArgs e)
        {

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

        private void LoadDossierFile(string fileName)
        {
            try
            {
                using (var sr = new StreamReader(new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                {
                    _headersDossiers = sr.ReadLine().Split(";"[0]).ToList();
                }
                _fieldmappingsDossiers = _dataservice.GetMappingsDossiers(_headersDossiers);
                if (_fieldmappingsDossiers == null)
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
        private void LoadRecordFile(string fileName, bool loadfromCache = false)
        {
            try
            {
                using (var sr = new StreamReader(new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                {
                    _headersRecords = sr.ReadLine().Split(";"[0]).ToList();
                }

                _fieldmappingsRecords = _dataservice.GetMappingsRecords(_headersRecords);
                if (_fieldmappingsRecords == null)
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

        //private void gridFieldMappingDossiers_Leave(object sender, EventArgs e)
        //{
        //    _dataservice.SaveMappings(_fieldmappingsDossiers, FieldMappingType.DOSSIER);
        //}

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
    }


}
