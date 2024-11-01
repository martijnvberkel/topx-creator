using System.Drawing;
using AutoUpdaterDotNET;
using System.Windows.Forms;

namespace TOPX.UI.Forms
{
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
        }

        private void linkMVBWorks_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://mvbworks.com");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://mvbworks.com/downloads/");
        }

        private void btPrelease_Click(object sender, System.EventArgs e)
        {
            AutoUpdater.Start("https://mvbworks.com/downloads/updates/prerelease/version.xml");
            Close();
        }
    }
}
