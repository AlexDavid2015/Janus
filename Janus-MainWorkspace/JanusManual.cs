using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CxTitan.AvantechDataSetTableAdapters;

namespace CxTitan
{
    public partial class JanusManual : Form
    {
        LanguageTableAdapter LanguageTableAobj = new LanguageTableAdapter();
        public JanusManual()
        {
            InitializeComponent();
        }

        private void cmdController_Click(object sender, EventArgs e)
        {            
            //ConnectPage connPage = new ConnectPage();
            //connPage.Show();
            this.Hide();
            SystemGlobals.objConnectPage.Show();
        }

        private void cmdMagazine_Click(object sender, EventArgs e)
        {
            this.Hide();
            SystemGlobals.objMagazinePage.Show();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            // Disable Threads
            if (SystemGlobals.objConnectPage.MainThread.IsBusy)
            {
                SystemGlobals.objConnectPage.MainThread.CancelAsync();
            }
            Avantech.MainThreadEnabled = false;
            SystemGlobals.objConnectPage.OutputTimer.Enabled = false;
            Avantech.bModbusConnected = false;

            // Disconnect IO modules
            AvantechDIs.FreeResource();
            AvantechDOs.FreeResource();
            AvantechAOs.FreeResource();
            AvantechAIs.FreeResource();
            AvantechDIOs.FreeResource();

            //System.Environment.Exit(0);
            this.Hide();
            SystemGlobals.objMain.Show();
        }

        private void JanusManual_Load(object sender, EventArgs e)
        {
            //SystemGlobals.JanusManualPageReturn = this;
            //LanguageInitialize();// load default language and update UI
        }

        //public void SetAIRangeComboBox(string[] strRanges)
        //{
        //    cbxAIRange.BeginUpdate();
        //    cbxAIRange.Items.Clear();
        //    for (int i = 0; i < strRanges.Length; i++)
        //        cbxAIRange.Items.Add(strRanges[i]);

        //    if (cbxAIRange.Items.Count > 0)
        //        cbxAIRange.SelectedIndex = 0;
        //    cbxAIRange.EndUpdate();
        //}
    }
}
