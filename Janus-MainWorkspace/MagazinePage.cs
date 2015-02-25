using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Performax;

namespace CxTitan
{
    public partial class MagazinePage : Form
    {
        public MagazinePage()
        {
            //MotorControls.bRunMode = true;
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            SystemGlobals.objJanusManual.Show();//SystemGlobals.JanusManualPageReturn.Show();//System.Environment.Exit(0);
        }

        private void cmdSingMagHOME_Click(object sender, EventArgs e)
        {

        }

        private void cmdSingMoveToZero_Click(object sender, EventArgs e)
        {
            //MotorControls.SendReceive("PX=0");
            Thread.Sleep(200);
            MotorControls.oHyperTerminalAdapter.Write("@01X0\r");
        }

        private void MagazinePage_Load(object sender, EventArgs e)
        {
            //if (MotorControls.ConnectMotor())
            //{
                
            //}
            //else
            //{
            //    MessageBox.Show("No Pump Device Found", "Get Device List Error");
            //}


            // Device ID(combox)
            string[] strDeviceIDs = new string[16];// 0 to 15, maximum is 15 Magazines
            for (int i = 0; i < strDeviceIDs.Length; i++)
            {
                strDeviceIDs[i] = i.ToString();// from COM0 to COM15
            }
            SetDeviceIDComboBox(strDeviceIDs);

            // Sync Cfg(combox)
            string[] strSyncCfgs = new string[3];
            strSyncCfgs[0] = "<";
            strSyncCfgs[1] = "=";
            strSyncCfgs[2] = ">";
            SetSyncCfgComboBox(strSyncCfgs);
            cbxSyncCfg.SelectedIndex = 1;// to point to "="



            // Serial port connected and motion intialize
            if (MotorControls.oHyperTerminalAdapter.Connect())
            {
                lblPort.Text = "Successful";
                lblPort.BackColor = Color.Green;
            }
            else
            {
                lblPort.Text = "Error";
                lblPort.BackColor = Color.Red;
            }
            cbxDeviceID.SelectedIndex = MotorControls.oHyperTerminalAdapter.COMID;






            //// Motor Initialize Part
            //uint lpNumDevices = 0;
            //MotorControls.fnPerformaxComGetNumDevices(ref lpNumDevices);

            ////MotorControls.fnPerformaxComGetProductString()

            //uint dwReadTimeout = 5000;
            //uint dwWriteTimeout = 5000;
            //MotorControls.fnPerformaxComSetTimeouts(dwReadTimeout, dwWriteTimeout);

            //IntPtr ptr = new IntPtr(0);
            //bool bOpen;
            //bOpen = MotorControls.fnPerformaxComOpen(4, ref ptr);
            //// End of Motor Initialize Part
        }

        public void SetDeviceIDComboBox(string[] strDeviceIDs)
        {
            cbxDeviceID.BeginUpdate();
            cbxDeviceID.Items.Clear();
            for (int i = 0; i < strDeviceIDs.Length; i++)
                cbxDeviceID.Items.Add(strDeviceIDs[i]);

            if (cbxDeviceID.Items.Count > 0)
                cbxDeviceID.SelectedIndex = 0;
            cbxDeviceID.EndUpdate();
        }

        public void SetSyncCfgComboBox(string[] strSyncCfgs)
        {
            cbxSyncCfg.BeginUpdate();
            cbxSyncCfg.Items.Clear();
            for (int i = 0; i < strSyncCfgs.Length; i++)
                cbxSyncCfg.Items.Add(strSyncCfgs[i]);

            if (cbxSyncCfg.Items.Count > 0)
                cbxSyncCfg.SelectedIndex = 0;
            cbxSyncCfg.EndUpdate();
        }

        private void cmdSingMagCLOSE_Click(object sender, EventArgs e)
        {

        }

        private void cmdSingJogMinus_Click(object sender, EventArgs e)
        {
            Thread.Sleep(200);
            MotorControls.oHyperTerminalAdapter.Write("@01J-\r");
        }

        private void cmdSingJogPlus_Click(object sender, EventArgs e)
        {
            Thread.Sleep(200);
            MotorControls.oHyperTerminalAdapter.Write("@01J+\r");
        }

        private void cmdClearCodeSpace_Click(object sender, EventArgs e)
        {

        }

        private void cmdTerminal_Click(object sender, EventArgs e)
        {
            MagTerminalPage terminalPage = new MagTerminalPage();
            terminalPage.ShowDialog();
        }

        private void cmdSetup_Click(object sender, EventArgs e)
        {
            MagSetupPage setupPage = new MagSetupPage();
            setupPage.ShowDialog();
        }

        private void cmdFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileOpenDialog = new OpenFileDialog();
            fileOpenDialog.Filter = "DMX-K-SA Program Files (*.prg)|*.prg";
            fileOpenDialog.Title = "Open DMX-K-SA Program";
            fileOpenDialog.InitialDirectory = "C:\\Program Files (x86)\\Arcus Technology\\Drivemax Series\\";
            fileOpenDialog.ShowDialog();
        }

        private void cmdFileSave_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "DMX-K-SA Program Files (*.prg)|*.prg";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.Title = "Save DMX-K-SA Program As";
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

        private void cmdFileNew_Click(object sender, EventArgs e)
        {

        }

        private void cmdSingMagOPEN_Click(object sender, EventArgs e)
        {

        }

        private void cmdSingJogMinusFast_Click(object sender, EventArgs e)
        {

        }

        private void cmdSingJogPlusFast_Click(object sender, EventArgs e)
        {

        }

        private void cmdSingRampStop_Click(object sender, EventArgs e)
        {
            Thread.Sleep(200);
            MotorControls.oHyperTerminalAdapter.Write("@01STOP\r");
        }

        private void cmdSingImmediateStop_Click(object sender, EventArgs e)
        {
            Thread.Sleep(200);
            MotorControls.oHyperTerminalAdapter.Write("@01ABORT\r");
        }

        private void cmdSingHomeLimitSwitchMinus_Click(object sender, EventArgs e)
        {
            Thread.Sleep(200);
            MotorControls.oHyperTerminalAdapter.Write("@01L-\r");
        }

        private void cmdSingHomeLimitSwitchPlus_Click(object sender, EventArgs e)
        {
            Thread.Sleep(200);
            MotorControls.oHyperTerminalAdapter.Write("@01L+\r");
        }

        private void cmdVariables_Click(object sender, EventArgs e)
        {
            MagVariablesPage magVariablesPage = new MagVariablesPage();
            magVariablesPage.ShowDialog();
        }

        private void cmdClearError_Click(object sender, EventArgs e)
        {
            Thread.Sleep(200);
            MotorControls.oHyperTerminalAdapter.Write("@01CLR\r");
        }
    }
}
