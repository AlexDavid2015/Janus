using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CxTitan.AvantechDataSetTableAdapters;

namespace CxTitan
{
    public partial class SystemSettingsPage : Form
    {
        AvantechTableAdapter AvantechTableAobj = new AvantechTableAdapter();
        public SystemSettingsPage()
        {
            InitializeComponent();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                AvantechTableAobj.UpdateSystemSettings(txtIP.Text, Convert.ToInt32(txtScanTime.Text), txtConnectionTimeOut.Text, txtSendTimeOut.Text, txtReceiveTimeOut.Text,
                    Convert.ToInt32(txtDOSlotNum.Text), Convert.ToInt32(txtAOSlotNum.Text), Convert.ToInt32(txtAISlotNum.Text), Convert.ToInt32(txtDIOSlotNum.Text), Convert.ToInt32(txtDISlotNum.Text));
                MessageBox.Show("System Settings Save Done!!!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("System Settings Save Failed!!!");
                return;
            }
        }

        private void SystemSettingsPage_Load(object sender, EventArgs e)
        {
            AvantechTableAdapter.Fill(AvantechDataSet.Avantech);
            if (SystemGlobals.CurrentUser.Level != 255)
            {
                gpbSystemSettings.Enabled = false;
                cmdSave.Enabled = false;
            }
        }
    }
}
