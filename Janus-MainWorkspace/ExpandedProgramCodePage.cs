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
    public partial class ExpandedProgramCodePage : Form
    {
        public ExpandedProgramCodePage()
        {
            InitializeComponent();
        }

        private void cmdCompile_Click(object sender, EventArgs e)
        {

        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {

        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {

        }

        private void cmdOpen_Click(object sender, EventArgs e)
        {

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {

        }

        private void cmdNew_Click(object sender, EventArgs e)
        {

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void ExpandedProgramCodePage_Load(object sender, EventArgs e)
        {
            txtProgramCode.Text = SystemGlobals.objMagazinePage.txtCode.Text;
            txtProgramCode.SelectionStart = txtProgramCode.TextLength;
            txtProgramCode.SelectionLength = 0;
        }
    }
}
