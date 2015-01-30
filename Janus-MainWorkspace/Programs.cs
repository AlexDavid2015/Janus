using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CxTitan
{
    public partial class Programs : Form
    {
        public Programs()
        {
            InitializeComponent();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            SystemGlobals.objMain.Show();
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {

        }

        private void cmdModify_Click(object sender, EventArgs e)
        {

        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {

        }

        private void cmdPairingProgramProduct_Click(object sender, EventArgs e)
        {

        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {

        }

        private void cmdFind_Click(object sender, EventArgs e)
        {

        }

        private void cmdExport_Click(object sender, EventArgs e)
        {

        }

        private void cmdImport_Click(object sender, EventArgs e)
        {

        }

        private void Programs_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'JanusDataSet.recipes' table. You can move, or remove it, as needed.
            this.recipesTableAdapter.Fill(this.JanusDataSet.recipes);
        }
    }
}
