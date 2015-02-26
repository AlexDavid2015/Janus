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
            TimerStates.Enabled = false;// disable read values from Motors
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01X0\r");
            TimerStates.Enabled = true;// enable read values from Motors
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


            // TimerStates enable
            TimerStates.Enabled = true;










            //// Motor Initialize Part(Shit)
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
            TimerStates.Enabled = false;// disable read values from Motors
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01HSPD=1500\r");// speed = 1500
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01J-\r");
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void cmdSingJogPlus_Click(object sender, EventArgs e)
        {
            TimerStates.Enabled = false;// disable read values from Motors
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01HSPD=1500\r");// speed = 1500
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01J+\r");
            TimerStates.Enabled = true;// enable read values from Motors
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
            TimerStates.Enabled = false;// disable read values from Motors
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01HSPD=15000\r");// speed = 15000
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01J-\r");
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void cmdSingJogPlusFast_Click(object sender, EventArgs e)
        {
            TimerStates.Enabled = false;// disable read values from Motors
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01HSPD=15000\r");// speed = 15000
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01J+\r");
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void cmdSingRampStop_Click(object sender, EventArgs e)
        {
            TimerStates.Enabled = false;// disable read values from Motors
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01STOP\r");
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void cmdSingImmediateStop_Click(object sender, EventArgs e)
        {
            TimerStates.Enabled = false;// disable read values from Motors
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01ABORT\r");
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void cmdSingHomeLimitSwitchMinus_Click(object sender, EventArgs e)
        {
            TimerStates.Enabled = false;// disable read values from Motors
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01L-\r");
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void cmdSingHomeLimitSwitchPlus_Click(object sender, EventArgs e)
        {
            TimerStates.Enabled = false;// disable read values from Motors
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01L+\r");
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void cmdVariables_Click(object sender, EventArgs e)
        {
            MagVariablesPage magVariablesPage = new MagVariablesPage();
            magVariablesPage.ShowDialog();
        }

        private void cmdClearError_Click(object sender, EventArgs e)
        {
            TimerStates.Enabled = false;// disable read values from Motors
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01CLR\r");
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void TimerStates_Tick(object sender, EventArgs e)
        {
            ////Thread.Sleep(200);
            GetRealTimePulsePos();
            GetRealTimeEncoderPos();
            GetRealTimeDelta();
            GetRealTimeSpeed();
            GetRealTimeMotorStatus();
            GetRealTimeStepNLoopStatus();
            GetRealTimeMoveModeStatus();
            GetRealTimeDriverCurrent();
        }

        private void GetRealTimePulsePos()
        {
            MotorControls.oHyperTerminalAdapter.Write("@01PX\r");
            Thread.Sleep(20);
            MotorControls.oHyperTerminalAdapter.Read(ref MotorControls.PulsePos);
            txtPosition.Text = MotorControls.PulsePos;
        }

        private void GetRealTimeEncoderPos()
        {
            MotorControls.oHyperTerminalAdapter.Write("@01EX\r");
            Thread.Sleep(20);
            MotorControls.oHyperTerminalAdapter.Read(ref MotorControls.EncoderPos);
            txtEncoder.Text = MotorControls.EncoderPos;
        }

        private void GetRealTimeDelta()
        {
            MotorControls.oHyperTerminalAdapter.Write("@01DX\r");
            Thread.Sleep(20);
            MotorControls.oHyperTerminalAdapter.Read(ref MotorControls.Delta);
            txtDelta.Text = MotorControls.Delta;
        }

        private void GetRealTimeSpeed()
        {
            MotorControls.oHyperTerminalAdapter.Write("@01PS\r");
            Thread.Sleep(20);
            MotorControls.oHyperTerminalAdapter.Read(ref MotorControls.Speed);
            txtSpeed.Text = MotorControls.Speed;
        }

        private void GetRealTimeMotorStatus()
        {
            MotorControls.oHyperTerminalAdapter.Write("@01MST\r");
            Thread.Sleep(20);
            MotorControls.oHyperTerminalAdapter.Read(ref MotorControls.Status);
            switch (Convert.ToInt32(MotorControls.Status))
            {
                case 0:
                    txtStatus.Text = (MotorControls.MotionStatus.IDLE).ToString();
                    break;
                case 1:
                    txtStatus.Text = (MotorControls.MotionStatus.CONST).ToString();
                    break;
                case 3:
                    txtStatus.Text = (MotorControls.MotionStatus.ACCEL).ToString();
                    break;
                case 5:
                    txtStatus.Text = (MotorControls.MotionStatus.DECEL).ToString();
                    break;
                case 80:
                    txtStatus.Text = (MotorControls.MotionStatus.MINUS_LIM_ERR).ToString();
                    break;
                case 160:
                    txtStatus.Text = (MotorControls.MotionStatus.PLUS_LIM_ERR).ToString();
                    break;
                default:
                    break;
            }
        }

        private void GetRealTimeStepNLoopStatus()
        {
            MotorControls.oHyperTerminalAdapter.Write("@01SLS\r");
            Thread.Sleep(20);
            MotorControls.oHyperTerminalAdapter.Read(ref MotorControls.StepNLoop);
            switch (Convert.ToInt32(MotorControls.StepNLoop))
            {
                case 0:
                    txtStepNLoop.Text = (MotorControls.StepNLoopControlStatus.Idle).ToString();
                    break;
                case 1:
                    txtStepNLoop.Text = (MotorControls.StepNLoopControlStatus.Moving).ToString();
                    break;
                case 2:
                    txtStepNLoop.Text = (MotorControls.StepNLoopControlStatus.Correcting).ToString();
                    break;
                case 3:
                    txtStepNLoop.Text = (MotorControls.StepNLoopControlStatus.Stopping).ToString();
                    break;
                case 4:
                    txtStepNLoop.Text = (MotorControls.StepNLoopControlStatus.Aborting).ToString();
                    break;
                case 5:
                    txtStepNLoop.Text = (MotorControls.StepNLoopControlStatus.Jogging).ToString();
                    break;
                case 6:
                    txtStepNLoop.Text = (MotorControls.StepNLoopControlStatus.Homing).ToString();
                    break;
                case 7:
                    txtStepNLoop.Text = (MotorControls.StepNLoopControlStatus.ZHoming).ToString();
                    break;
                case 8:
                    txtStepNLoop.Text = (MotorControls.StepNLoopControlStatus.CorrectionRangeError).ToString();
                    break;
                case 9:
                    txtStepNLoop.Text = (MotorControls.StepNLoopControlStatus.CorrectionAttemptError).ToString();
                    break;
                case 10:
                    txtStepNLoop.Text = (MotorControls.StepNLoopControlStatus.StallError).ToString();
                    break;
                case 11:
                    txtStepNLoop.Text = (MotorControls.StepNLoopControlStatus.LimitError).ToString();
                    break;
                case 12:
                    txtStepNLoop.Text = (MotorControls.StepNLoopControlStatus.Reserved).ToString();
                    break;
                case 13:
                    txtStepNLoop.Text = (MotorControls.StepNLoopControlStatus.LimitHoming).ToString();
                    break;
                default:
                    break;
            }
        }

        private void GetRealTimeMoveModeStatus()
        {
            MotorControls.oHyperTerminalAdapter.Write("@01MM\r");
            Thread.Sleep(20);
            MotorControls.oHyperTerminalAdapter.Read(ref MotorControls.Mode);
            switch (Convert.ToInt32(MotorControls.StepNLoop))
            {
                case 0:
                    txtMode.Text = (MotorControls.MoveModeStatus.ABS).ToString();
                    break;
                case 1:
                    txtMode.Text = (MotorControls.MoveModeStatus.INC).ToString();
                    break;
                default:
                    break;
            }
        }

        private void GetRealTimeDriverCurrent()
        {
            MotorControls.oHyperTerminalAdapter.Write("@01CUR\r");
            Thread.Sleep(20);
            MotorControls.oHyperTerminalAdapter.Read(ref MotorControls.Current);
            txtCurrent.Text = MotorControls.Current;
        }

        private void cmdSingleRun_Click(object sender, EventArgs e)
        {
            TimerStates.Enabled = false;// disable read values from Motors
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01SR0=1\r");
            MotorControls.oHyperTerminalAdapter.Write("@01SR1=1\r");
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void cmdSingleStop_Click(object sender, EventArgs e)
        {
            TimerStates.Enabled = false;// disable read values from Motors
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01SR0=0\r");
            MotorControls.oHyperTerminalAdapter.Write("@01SR1=0\r");
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void cmdSinglePause_Click(object sender, EventArgs e)
        {
            TimerStates.Enabled = false;// disable read values from Motors
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01SR0=2\r");
            MotorControls.oHyperTerminalAdapter.Write("@01SR1=2\r");
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void cmdSingleContinue_Click(object sender, EventArgs e)
        {
            TimerStates.Enabled = false;// disable read values from Motors
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01SR0=3\r");
            MotorControls.oHyperTerminalAdapter.Write("@01SR1=3\r");
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void cmdResetEncoder_Click(object sender, EventArgs e)
        {
            TimerStates.Enabled = false;// disable read values from Motors
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01EX=0\r");
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void cmdResetPosition_Click(object sender, EventArgs e)
        {
            TimerStates.Enabled = false;// disable read values from Motors
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01PX=0\r");
            TimerStates.Enabled = true;// enable read values from Motors
        }
    }
}
