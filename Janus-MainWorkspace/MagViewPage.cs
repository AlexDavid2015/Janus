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

namespace CxTitan
{
    public partial class MagViewPage : Form
    {
        public MagViewPage()
        {
            InitializeComponent();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Compiled Program Files (*.cpg)|*.cpg";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.Title = "Save Compiled Program As";
            saveFileDialog.InitialDirectory = "C:\\Program Files (x86)\\Arcus Technology\\Drivemax Series\\";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void MagViewPage_Load(object sender, EventArgs e)
        {
            string startupPath = Environment.CurrentDirectory;
            string curCompileOutFile = "CompileOut.txt";
            string currCompileOutDir = startupPath + "\\" + curCompileOutFile;
            //string retMsg = "";// Messgebox display
            //bool IsDownloadOk = true;
            //string resultString = "";
            if (File.Exists(curCompileOutFile))
            {
                string[] lines = File.ReadAllLines(curCompileOutFile);
                foreach (string line in lines)
                {
                    lstCompiledCode.Items.Add(line);
                }
            }
            else
            {
                MessageBox.Show("Can not find the File CompileOut.txt.");
                return;
            }
        }
    }
}
