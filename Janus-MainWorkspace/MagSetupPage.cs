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
    public partial class MagSetupPage : Form
    {
        public MagSetupPage()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            if (MotorControls.IsMotorSerialInitialized)
            {
                SystemGlobals.objMagazinePage.TimerStates.Enabled = true;
            }
            else
            {
                SystemGlobals.objMagazinePage.TimerStates.Enabled = false;
            }
        }

        private void MagSetupPage_Load(object sender, EventArgs e)
        {
            int i = 0;
            // Baud Rate(combox)
            string[] strBaudRates = new string[5];// 9600, 19200, 38400, 57600, 115200
            strBaudRates[0] = "9600";
            strBaudRates[1] = "19200";
            strBaudRates[2] = "38400";
            strBaudRates[3] = "57600";
            strBaudRates[4] = "115200";
            SetBaudRateComboBox(strBaudRates);

            // Device ID(combox)
            string[] strDeviceIDs = new string[16];// 0 to 15, maximum is 16 Magazines
            for (i = 0; i < strDeviceIDs.Length; i++)
            {
                strDeviceIDs[i] = i.ToString();// from COM0 to COM15
            }
            SetDeviceIDComboBox(strDeviceIDs);
        }

        public void SetBaudRateComboBox(string[] strBaudRates)
        {
            combxBaudRate.BeginUpdate();
            combxBaudRate.Items.Clear();
            for (int i = 0; i < strBaudRates.Length; i++)
                combxBaudRate.Items.Add(strBaudRates[i]);

            if (combxBaudRate.Items.Count > 0)
                combxBaudRate.SelectedIndex = 0;
            combxBaudRate.EndUpdate();
        }

        public void SetDeviceIDComboBox(string[] strDeviceIDs)
        {
            combxDeviceID.BeginUpdate();
            combxDeviceID.Items.Clear();
            for (int i = 0; i < strDeviceIDs.Length; i++)
                combxDeviceID.Items.Add(strDeviceIDs[i]);

            if (combxDeviceID.Items.Count > 0)
                combxDeviceID.SelectedIndex = 0;
            combxDeviceID.EndUpdate();
        }

        private void cmdOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileOpenDialog = new OpenFileDialog();
            fileOpenDialog.Filter = "DMX-K-SA Parameter Files (*.par)|*.par";
            fileOpenDialog.Title = "Open DMX-K-SA Parameter File";
            fileOpenDialog.InitialDirectory = "C:\\Program Files (x86)\\Arcus Technology\\Drivemax Series\\";
            fileOpenDialog.ShowDialog();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Parameter Files (*.par)|*.par";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.Title = "Save DMX-K-SA Parameters As";
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

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            if (MotorControls.IsMotorSerialInitialized)
            {

            }
            else
            {
                MessageBox.Show("Communication port not open!");
            }
        }

        private void cmdDown_Click(object sender, EventArgs e)
        {
            if (MotorControls.IsMotorSerialInitialized)
            {

            }
            else
            {
                MessageBox.Show("Communication port not open!");
            }
        }

        private void cmdStore_Click(object sender, EventArgs e)
        {
            if (MotorControls.IsMotorSerialInitialized)
            {

            }
            else
            {
                MessageBox.Show("Communication port not open!");
            }
        }
    }
}
