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

        private static  Logger _logger;
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
            using (var entities = new ModelTopX())
            {
                var x = (from i in entities.Dossiers select i).ToList();
                x.Add(new Dossier() { Classificatie_Bron = "test" });
                entities.SaveChanges();
            }

            gridFieldMappingDossiers.AutoGenerateColumns = false;
            gridFieldMappingRecords.AutoGenerateColumns = false;

            
        }

        private void btImportFiles_Click(object sender, EventArgs e)
        {
            using (var entities = new ModelTopX())
            {

                entities.Database.ExecuteSqlCommand("truncate table Records");
                entities.Database.ExecuteSqlCommand("truncate table Bestanden");
                entities.Database.ExecuteSqlCommand("delete from Dossiers");

                _fieldmappingsDossiers = _headers.GetHeaderMappingDossiers(_headersDossiers);
                _fieldmappingsRecords = _headers.GetHeaderMappingRecordsBestanden(_headersRecords);

                var importer = new Importer(entities);
                using (var dossiers = new StreamReader(openFileDialogDossiers.FileName))
                {
                    importer.ImportDossiers(_fieldmappingsDossiers, _headersDossiers, dossiers, Headers.MappingType.DOSSIER);
                    if (importer.Error)
                    {
                        txtErrorsDossiers.Text = importer.ErrorMessage;
                    }
                }

                importer = new Importer(entities);
                using (var records = new StreamReader(openFileDialogRecords.FileName))
                {
                    importer.ImportDossiers(_fieldmappingsRecords, _headersRecords, records, Headers.MappingType.RECORD);
                    if (importer.Error)
                    {
                        txtErrorRecords.Text = importer.ErrorMessage;
                    }
                }
            }
        }

        private void btFileLocation_Click(object sender, EventArgs e)
        {
            using (var entities = new ModelTopX())
            {

                var dialogResult = folderBrowserDialogFiles.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    txtFileLocation.Text = folderBrowserDialogFiles.SelectedPath;
                }
            }
        }

        private void btAnalyse_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtFileLocation.Text))
            {
                MessageBox.Show("Directory bestaat niet");
                return;
            }
            using (var entities = new ModelTopX())
            {
                var records = (from r in entities.Records select r).ToList();
                //var bestanden = (from b in entities.Bestand select b).ToList();
                var metadata = new Metadata();
                //metadata.Collect(txtFileLocation.Text, records, bestanden);
                entities.SaveChanges();
            }
        }

        private void btCreateTopX_Click(object sender, EventArgs e)
        {
            var parser = new Parser();
            var result = parser.ParseDataToTopx();


            
            Cursor.Current = Cursors.Default;

            if (MessageBox.Show("Save xml?", "xml", MessageBoxButtons.YesNo) == DialogResult.Yes)
                SaveAsXml(result);

        }

        private void SaveAsXml(recordInformationPackage result)
        {
            var savefile = new SaveFileDialog();

            savefile.FileName = "export.xml";
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
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                stream?.Close();
            }

            //file is not locked
            return false;
        }

        private void txtDossierLocation_Click(object sender, EventArgs e)
        {
            if (openFileDialogDossiers.ShowDialog() == DialogResult.OK)
            {
                if (IsFileOpen(openFileDialogDossiers.FileName))
                {
                    MessageBox.Show("Dossierbestand is geopend door een andere applicatie");
                    return;
                }
                txtDossierLocation.Text = Path.GetFileName(openFileDialogDossiers.FileName);
                using (var sr = new StreamReader(openFileDialogDossiers.FileName))
                {
                    _headersDossiers = sr.ReadLine().Split(";"[0]).ToList();
                }
            }
            gridFieldMappingDossiers.DataSource = _headers.GetHeaderMappingDossiers(_headersDossiers);

        }

        private void txtRecordBestandLocation_Click(object sender, EventArgs e)
        {
            if (openFileDialogRecords.ShowDialog() == DialogResult.OK)
            {
                if (IsFileOpen(openFileDialogDossiers.FileName))
                {
                    MessageBox.Show("Dossierbestand is geopend door een andere applicatie");
                    return;
                }
                txtRecordBestandLocation.Text = Path.GetFileName(openFileDialogRecords.FileName);
                using (var sr = new StreamReader(openFileDialogRecords.FileName))
                {
                    _headersRecords = sr.ReadLine().Split(";"[0]).ToList();
                }
            }
            gridFieldMappingRecords.DataSource = _headers.GetHeaderMappingRecordsBestanden(_headersRecords);
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
                if (!DateTime.TryParseExact(txtDatumArchief.Text, "dd-MM-yyyy", new CultureInfo("nl-NL"), DateTimeStyles.None,  out tempdatumArchief))
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

        private void button1_Click(object sender, EventArgs e)
        {
            _formLog.Show();
        }
    }
}
