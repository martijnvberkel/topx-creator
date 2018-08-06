using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TOPX.UI
{
    public partial class TopXConverter : Form
    {
        public TopXConverter()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void TopXConverter_Load(object sender, EventArgs e)
        {
            textBox1.Text = "--- begin ---" + System.Environment.NewLine + "bBScgdKBnc34XYi0lbKJnhdHFJLKEd9wdNfb0Akx7tNNCjorPw0Gzn4tUlC9khDRIhGj3p9NFNY0MOv8nOQ==" + System.Environment.NewLine + " ---- end -----";
        }
    }
}
