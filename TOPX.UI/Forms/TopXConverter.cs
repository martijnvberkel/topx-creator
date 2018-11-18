using System;
using System.Collections.Generic;
using System.Drawing;
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
using Topx.FileAnalysis;
using Topx.Importer;
using Topx.Interface;
using Topx.Parser.Model;
using TOPX.UI.Classes;

namespace TOPX.UI.Forms
{
    public partial class TopXConverter : MaterialForm
    {
        private List<string> _headersDossiers = new List<string>();
        private List<string> _headersRecords = new List<string>();

        private List<FieldMapping> _fieldmappingsDossiers;
        private List<FieldMapping> _fieldmappingsRecords;

        private static Logger _logger;
        private FormLog _formLog = new FormLog();

        private Headers _headers;
        public TopXConverter()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

        }

        private void TopXConverter_Load(object sender, EventArgs e)
        {
            Logging.Init();
            _logger = LogManager.GetCurrentClassLogger();
            _headers = new Headers(new ModelTopX());

            gridFieldMappingDossiers.AutoGenerateColumns = false;
            gridFieldMappingRecords.AutoGenerateColumns = false;

            InitDefaultFilesLoad();
        }

        private void InitDefaultFilesLoad()
        {
            var globals = GlobalsService.GetGlobals();
            var dossierFile = globals?.LastDossierFileName;
            txtDossierLocation.Text = globals?.LastDossierFileName;
            if (File.Exists(dossierFile))
            {
                LoadDossierFile(dossierFile);
            }

            var recordFile = globals?.LastRecordsFileName;
            txtRecordBestandLocation.Text = globals?.LastDossierFileName;
            if (File.Exists(recordFile))
            {
                LoadRecordFile(recordFile);
            }

            txtBronArchief.Text = globals?.BronArchief;
            txtDatumArchief.Text = globals?.DatumArchief.ToString("dd-MM-yyyy");
            txtDoelArchief.Text = globals?.DoelArchief;
            txtDossierLocation.Text = globals?.LastDossierFileName;
            txtIdentificatieArchief.Text = globals?.IdentificatieArchief;
            txtNaamArchief.Text = globals?.NaamArchief;
            txtOmschrijvingArchief.Text = globals?.OmschrijvingArchief;
        }

        private void btImportFilesInDb_Click(object sender, EventArgs e)
        {
            using (var entities = new ModelTopX())
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

                entities.Database.ExecuteSqlCommand("truncate table Records");
                entities.Database.ExecuteSqlCommand("truncate table Bestanden");
                entities.Database.ExecuteSqlCommand("delete from Dossiers");

                var importer = new Importer(entities);

                using (var dossiers = new StreamReader(new FileStream(txtDossierLocation.Text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                {
                    importer.ImportDossiers(_fieldmappingsDossiers, _headersDossiers, dossiers, Headers.MappingType.DOSSIER);
                    if (importer.Error)
                    {
                        txtErrorsDossiers.Text = importer.ErrorMessage;
                    }
                }

                importer = new Importer(entities);
                using (var records = new StreamReader(new FileStream(txtRecordBestandLocation.Text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                {
                    importer.ImportDossiers(_fieldmappingsRecords, _headersRecords, records, Headers.MappingType.RECORD);
                    if (importer.Error)
                    {
                        txtErrorRecords.Text = importer.ErrorMessage;
                    }
                }
            }
        }

        private void btGenerateTopX_Click(object sender, EventArgs e)
        {
            try
            {
                //Cursor.Current = Cursors.WaitCursor;
                var parser = new Parser();
                var result = parser.ParseDataToTopx();
                txtLogTopXCreate.Text = parser.ErrorMessage.ToString();

                Cursor.Current = Cursors.Default;

                if (MessageBox.Show("Save xml?", "xml", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveAsXml(result);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                txtLogTopXCreate.Text = exception.ToString();
            }
        }

        private void SaveAsXml(recordInformationPackage result)
        {
            var savefile = new SaveFileDialog { FileName = "export.xml" };

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                var encoding = Encoding.UTF8;//.GetEncoding("ISO-8859-1");
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
            txtDatumArchief.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");
        }

        private void btSaveGlobals_Click(object sender, EventArgs e)
        {
            _logger.Error("Test");

            using (var entities = new ModelTopX())
            {
                DateTime tempdatumArchief;
                if (!DateTime.TryParseExact(txtDatumArchief.Text, "dd-MM-yyyy", new CultureInfo("nl-NL"), DateTimeStyles.None, out tempdatumArchief))
                {
                    MessageBox.Show("Datum Archief is niet correct.");
                    return;
                }

                var globals = (from g in entities.Globals select g).FirstOrDefault();
                if (globals == null)
                {
                    globals = new Globals();
                    entities.Globals.Add(globals);
                }

                globals.BronArchief = txtBronArchief.Text;
                globals.DoelArchief = txtDoelArchief.Text;
                globals.DatumArchief = tempdatumArchief;
                globals.NaamArchief = txtNaamArchief.Text;
                globals.IdentificatieArchief = txtIdentificatieArchief.Text;
                globals.OmschrijvingArchief = txtOmschrijvingArchief.Text;
                entities.SaveChanges();
            }
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
                GlobalsService.SaveLastDossierFileName(openFileDialogDossiers.FileName);
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
                _fieldmappingsDossiers = _headers.GetHeaderMappingDossiers(_headersDossiers);
                gridFieldMappingDossiers.DataSource = _fieldmappingsDossiers;

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
                GlobalsService.SaveLastRecordsFileName(openFileDialogRecords.FileName);
            }

        }

        private void LoadRecordFile(string fileName)
        {
            try
            {
                using (var sr = new StreamReader(new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                {
                    _headersRecords = sr.ReadLine().Split(";"[0]).ToList();
                }
                _fieldmappingsRecords = _headers.GetHeaderMappingRecordsBestanden(_headersRecords);
                gridFieldMappingRecords.DataSource = _fieldmappingsRecords;

            }
            catch (Exception e)
            {
                MessageBox.Show($"Het bestand kon niet worden ingelezen. Foutmelding: {e.Message}");
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
                GlobalsService.SaveLastDossierFileName(txtDossierLocation.Text);
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
                GlobalsService.SaveLastRecordsFileName(txtRecordBestandLocation.Text);
            }
        }


    }
}
