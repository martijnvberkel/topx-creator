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
    }
}
