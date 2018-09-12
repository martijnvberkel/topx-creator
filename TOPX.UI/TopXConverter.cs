using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Topx.Data;
using Topx.FileAnalysis;
using Topx.Importer;
using Topx.Interface;

namespace TOPX.UI
{
    public partial class TopXConverter : MaterialForm
    {
        private List<string> _headersDossiers = new List<string>();
        private List<string> _headersRecords = new List<string>();

        private List<FieldMapping> _fieldmappingsDossiers;
        private List<FieldMapping> _fieldmappingsRecords;

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
            _headers = new Headers(new TOPX_GenericEntities());
            gridFieldMappingDossiers.AutoGenerateColumns = false;
            gridFieldMappingRecords.AutoGenerateColumns = false;
        }

        private void ditIs1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void btSelectDossiers_Click(object sender, EventArgs e)
        {
            if (openFileDialogDossiers.ShowDialog() == DialogResult.OK)
            {
                filelocationDossiers.Text = Path.GetFileName(openFileDialogDossiers.FileName);
                using (var sr = new StreamReader(openFileDialogDossiers.FileName))
                {
                    _headersDossiers = sr.ReadLine().Split(";"[0]).ToList();
                }
            }
            gridFieldMappingDossiers.DataSource = _headers.GetHeaderMappingDossiers(_headersDossiers);
        }

        private void btSelectRecords_Click(object sender, EventArgs e)
        {
            if (openFileDialogRecords.ShowDialog() == DialogResult.OK)
            {
                filelocationRecords.Text = Path.GetFileName(openFileDialogRecords.FileName);
                using (var sr = new StreamReader(openFileDialogRecords.FileName))
                {
                    _headersRecords = sr.ReadLine().Split(";"[0]).ToList();
                }
            }
            gridFieldMappingRecords.DataSource = _headers.GetHeaderMappingRecordsBestanden(_headersRecords);
        }

        private void btImportFiles_Click(object sender, EventArgs e)
        {
            using (var entities = new TOPX_GenericEntities())
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
            using (var entities = new TOPX_GenericEntities())
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
            using (var entities = new TOPX_GenericEntities())
            {
                var records = (from r in entities.Record select r).ToList();
                var bestanden = (from b in entities.Bestand select b).ToList();
                var metadata = new Metadata();
                //metadata.Collect(txtFileLocation.Text, records, bestanden);
                entities.SaveChanges();
            }
        }
    }
}
