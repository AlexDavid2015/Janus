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

            uint lpNumDevices = 0;
            MotorControls.fnPerformaxComGetNumDevices(ref lpNumDevices);

            //MotorControls.fnPerformaxComGetProductString()

            uint dwReadTimeout = 5000;
            uint dwWriteTimeout = 5000;
            MotorControls.fnPerformaxComSetTimeouts(dwReadTimeout, dwWriteTimeout);

            IntPtr ptr = new IntPtr(0);
            bool bOpen;
            bOpen = MotorControls.fnPerformaxComOpen(4, ref ptr);


        }

        private void cmdSingMagCLOSE_Click(object sender, EventArgs e)
        {

        }

        private void cmdSingJogMinus_Click(object sender, EventArgs e)
        {

        }

        private void cmdSingJogPlus_Click(object sender, EventArgs e)
        {

        }

        private void cmdClearCodeSpace_Click(object sender, EventArgs e)
        {

        }

        private void cmdTerminal_Click(object sender, EventArgs e)
        {
            MagTerminalPage terminalPage = new MagTerminalPage();
            terminalPage.Show();
        }

        private void cmdSetup_Click(object sender, EventArgs e)
        {
            MagSetupPage setupPage = new MagSetupPage();
            setupPage.Show();
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

        }

        private void cmdSingImmediateStop_Click(object sender, EventArgs e)
        {

        }

        private void cmdSingHomeLimitSwitchMinus_Click(object sender, EventArgs e)
        {

        }

        private void cmdSingHomeLimitSwitchPlus_Click(object sender, EventArgs e)
        {

        }
    }
}
