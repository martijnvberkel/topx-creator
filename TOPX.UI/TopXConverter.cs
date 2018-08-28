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

namespace TOPX.UI
{
    public partial class TopXConverter : MaterialForm
    {
        private List<string> _headersDossiers = new List<string>();
        private List<string> _headersRecords = new List<string>();
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
            
        }

        private void ditIs1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
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
        }
    }
}
