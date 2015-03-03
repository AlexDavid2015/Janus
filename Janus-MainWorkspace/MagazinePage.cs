﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        private void cmdSingMagABS_Click(object sender, EventArgs e)// absolute position move
        {
            TimerStates.Enabled = false;// disable read values from Motors
            SetMotorSpeed();
            SetMotorAccelDecel();
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01X" + txtRefPos.Text + "\r");
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void cmdSingMoveToZero_Click(object sender, EventArgs e)
        {
            //MotorControls.SendReceive("PX=0");
            TimerStates.Enabled = false;// disable read values from Motors
            SetMotorSpeed();
            SetMotorAccelDecel();
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
            string[] strDeviceIDs = new string[16];// 0 to 15, maximum is 16 Magazines
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
                // TimerStates enable
                TimerStates.Enabled = true;
                MotorControls.IsMotorSerialInitialized = true;
            }
            else
            {
                lblPort.Text = "Error";
                lblPort.BackColor = Color.Red;
                // TimerStates disable
                TimerStates.Enabled = false;
                MotorControls.IsMotorSerialInitialized = false;
            }
            cbxDeviceID.SelectedIndex = MotorControls.oHyperTerminalAdapter.COMID;













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

        private void cmdSingMagHomePlus_Click(object sender, EventArgs e)
        {
            TimerStates.Enabled = false;// disable read values from Motors
            //SetMotorSpeedAndAcceleration();
            SetMotorSpeed();
            SetMotorAccelDecel();
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01H+\r");
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void cmdSingJogMinus_Click(object sender, EventArgs e)
        {
            TimerStates.Enabled = false;// disable read values from Motors
            //Thread.Sleep(100);
            //MotorControls.oHyperTerminalAdapter.Write("@01HSPD=1500\r");// speed = 1500

            //SetMotorSpeedAndAcceleration();
            SetMotorSpeed();
            SetMotorAccelDecel();
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01J-\r");
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void cmdSingJogPlus_Click(object sender, EventArgs e)
        {
            TimerStates.Enabled = false;// disable read values from Motors
            //Thread.Sleep(100);
            //MotorControls.oHyperTerminalAdapter.Write("@01HSPD=1500\r");// speed = 1500

            //SetMotorSpeedAndAcceleration();
            SetMotorSpeed();
            SetMotorAccelDecel();
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01J+\r");
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void cmdClearCodeSpace_Click(object sender, EventArgs e)
        {
            if (MotorControls.IsMotorSerialInitialized)
            {
                TimerStates.Enabled = false;
                MotorControls.oHyperTerminalAdapter.CloseSerialPort(); // close serial port

                string startupPath = Environment.CurrentDirectory;
                // ClearCodeSpace
                // write some settings to sa_download_upload_setup.txt here
                string curClearCodeSpaceSettingFile = "sa_download_upload_setup.txt";
                string curClearCodeSpaceSettingDir = startupPath + "\\" + curClearCodeSpaceSettingFile;
                string[] ClearCodeSpaceSettingRows = new string[] { "LIN:1275", "COM:SERIAL", "DEV:01", "POR:5", "BAU:9600", 
                "OPE:CLEAR", "FIL:CompileOut.txt", "MOD:DMX-K-SA-17/23" };// row settings can be edit later
                using (StreamWriter sw = new StreamWriter(curClearCodeSpaceSettingFile))
                {
                    foreach (string s in ClearCodeSpaceSettingRows)
                    {
                        sw.WriteLine(s);
                    }
                }

                string arg = @"user=Software-2";// just an example this can be anything
                string command = "SA_Download_Upload.exe";
                ProcessStartInfo clearCodeProc = new ProcessStartInfo(command, arg);
                clearCodeProc.UseShellExecute = false;
                clearCodeProc.CreateNoWindow = true; // Important if you want to keep shell window hidden
                Process.Start(clearCodeProc).WaitForExit(); //important to add WaitForExit()
                MessageBox.Show("Done!");

                MotorControls.oHyperTerminalAdapter.OpenSerialPort();// open serial port
                TimerStates.Enabled = true;
            }
            else
            {
                TimerStates.Enabled = false;
                MessageBox.Show("Communication port not open! Cannot clear code space in the motor!");
            }
        }

        private void cmdTerminal_Click(object sender, EventArgs e)
        {
            if (MotorControls.IsMotorSerialInitialized)
            {
                TimerStates.Enabled = false;
                MagTerminalPage terminalPage = new MagTerminalPage();
                terminalPage.ShowDialog();
            }
            else
            {
                MessageBox.Show("Communication port not open!");
                TimerStates.Enabled = false;
                MagTerminalPage terminalPage = new MagTerminalPage();
                terminalPage.ShowDialog();
            }
        }

        private void cmdSetup_Click(object sender, EventArgs e)
        {
            if (MotorControls.IsMotorSerialInitialized)
            {
                TimerStates.Enabled = false;
                MagSetupPage setupPage = new MagSetupPage();
                setupPage.ShowDialog();
            }
            else
            {
                MessageBox.Show("Communication port not open!");
                TimerStates.Enabled = false;
                MagSetupPage setupPage = new MagSetupPage();
                setupPage.ShowDialog();
            }
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
            txtCode.Clear();
        }

        private void SetMotorSpeedAndAcceleration()
        {
            TimerStates.Enabled = false;// disable read values from Motors
            // High Speed
            Thread.Sleep(20);
            MotorControls.oHyperTerminalAdapter.Write("@01HSPD=" + txtHighSpeed.Text + "\r");// send High speed

            // Low Speed
            Thread.Sleep(20);
            MotorControls.oHyperTerminalAdapter.Write("@01LSPD=" + txtLowSpeed.Text + "\r");// send Low speed

            // Accel
            Thread.Sleep(20);
            MotorControls.oHyperTerminalAdapter.Write("@01ACC=" + txtAccel.Text + "\r");// send Accel

            // Decel
            Thread.Sleep(20);
            MotorControls.oHyperTerminalAdapter.Write("@01DEC=" + txtDecel.Text + "\r");// send Decel

            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void SetMotorSpeed()
        {
            TimerStates.Enabled = false;// disable read values from Motors
            // High Speed
            Thread.Sleep(20);
            MotorControls.oHyperTerminalAdapter.Write("@01HSPD=" + txtHighSpeed.Text + "\r");// send High speed

            // Low Speed
            Thread.Sleep(20);
            MotorControls.oHyperTerminalAdapter.Write("@01LSPD=" + txtLowSpeed.Text + "\r");// send Low speed
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void SetMotorAccelDecel()
        {
            TimerStates.Enabled = false;// disable read values from Motors
            // Accel
            Thread.Sleep(20);
            MotorControls.oHyperTerminalAdapter.Write("@01ACC=" + txtAccel.Text + "\r");// send Accel

            // Decel
            Thread.Sleep(20);
            MotorControls.oHyperTerminalAdapter.Write("@01DEC=" + txtDecel.Text + "\r");// send Decel

            TimerStates.Enabled = true;// enable read values from Motors
        }

        //private void SetMotorPulsePos()
        //{
            
        //}

        private void SetMotorHighSpeed()
        {
            TimerStates.Enabled = false;// disable read values from Motors
            // High Speed
            Thread.Sleep(20);
            MotorControls.oHyperTerminalAdapter.Write("@01HSPD=" + txtHighSpeed.Text + "\r");// send High speed
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void SetMotorLowSpeed()
        {
            TimerStates.Enabled = false;// disable read values from Motors
            // Low Speed
            Thread.Sleep(20);
            MotorControls.oHyperTerminalAdapter.Write("@01LSPD=" + txtLowSpeed.Text + "\r");// send Low speed
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void SetMotorAccel()
        {
            TimerStates.Enabled = false;// disable read values from Motors
            // Accel
            Thread.Sleep(20);
            MotorControls.oHyperTerminalAdapter.Write("@01ACC=" + txtAccel.Text + "\r");// send Accel
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void SetMotorDecel()
        {
            TimerStates.Enabled = false;// disable read values from Motors
            // Decel
            Thread.Sleep(20);
            MotorControls.oHyperTerminalAdapter.Write("@01DEC=" + txtDecel.Text + "\r");// send Decel
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void cmdSingMagHomeMinus_Click(object sender, EventArgs e)
        {
            TimerStates.Enabled = false;// disable read values from Motors
            //SetMotorSpeedAndAcceleration();

            SetMotorSpeed();
            SetMotorAccelDecel();
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01H-\r");
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void cmdSingMagHomeLowSpeedMinus_Click(object sender, EventArgs e)
        {
            TimerStates.Enabled = false;// disable read values from Motors
            //SetMotorSpeedAndAcceleration();
            SetMotorSpeed();
            SetMotorAccelDecel();
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01J-\r");
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void cmdSingMagHomeLowSpeedPlus_Click(object sender, EventArgs e)
        {
            TimerStates.Enabled = false;// disable read values from Motors
            //SetMotorSpeedAndAcceleration();
            SetMotorSpeed();
            SetMotorAccelDecel();
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01J+\r");
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void cmdSingRampStop_Click(object sender, EventArgs e)
        {
            TimerStates.Enabled = false;// disable read values from Motors
            SetMotorDecel();
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
            SetMotorSpeed();
            SetMotorAccelDecel();
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01L-\r");
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void cmdSingHomeLimitSwitchPlus_Click(object sender, EventArgs e)
        {
            TimerStates.Enabled = false;// disable read values from Motors
            SetMotorSpeed();
            SetMotorAccelDecel();
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01L+\r");
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void cmdVariables_Click(object sender, EventArgs e)
        {
            TimerStates.Enabled = false;
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
            
            // Motor Status
            GetRealTimePulsePos();
            GetRealTimeEncoderPos();
            GetRealTimeDelta();
            GetRealTimeSpeed();
            GetRealTimeMotorStatus();
            GetRealTimeStepNLoopStatus();
            GetRealTimeMoveModeStatus();
            GetRealTimeDriverCurrent();

            // Program Control Status
            GetProgram0Status();
            GetProgram0Index();

            // DIO status
            GetDIOStatus();
        }

        private void GetDIOStatus()
        {
            // DI 1 to 6 all back color???

            // DO1 InPos
            MotorControls.oHyperTerminalAdapter.Write("@01DO1\r");
            Thread.Sleep(20);
            MotorControls.oHyperTerminalAdapter.Read(ref MotorControls.DO1InPos);
            if (Convert.ToBoolean(Convert.ToInt32(MotorControls.DO1InPos)))
            {
                lblDO1InPosVal.BackColor = Color.Green;
            }
            else
            {
                lblDO1InPosVal.BackColor = SystemColors.Control;
            }

            // DO2 Sync
            MotorControls.oHyperTerminalAdapter.Write("@01DO2\r");
            Thread.Sleep(20);
            MotorControls.oHyperTerminalAdapter.Read(ref MotorControls.DO2Sync);
            if (Convert.ToBoolean(Convert.ToInt32(MotorControls.DO2Sync)))
            {
                lblDO2SyncVal.BackColor = Color.Blue;
            }
            else
            {
                lblDO2SyncVal.BackColor = SystemColors.Control;
            }

            // DO3 Alarm
            MotorControls.oHyperTerminalAdapter.Write("@01DO3\r");
            Thread.Sleep(20);
            MotorControls.oHyperTerminalAdapter.Read(ref MotorControls.DO3Alarm);
            if (Convert.ToBoolean(Convert.ToInt32(MotorControls.DO3Alarm)))
            {
                lblDO3AlarmVal.BackColor = Color.Red;
            }
            else
            {
                lblDO3AlarmVal.BackColor = SystemColors.Control;
            }
        }

        private void GetProgram0Status()// Get Program0 status
        {
            MotorControls.oHyperTerminalAdapter.Write("@01SASTAT[0]\r");
            Thread.Sleep(20);
            MotorControls.oHyperTerminalAdapter.Read(ref MotorControls.Program0Status);
            //txtProgramControlStatus.Text = MotorControls.Program0Status;
            switch (Convert.ToInt32(MotorControls.Program0Status))
            {
                case 0:
                    txtProgramControlStatus.Text = (MotorControls.ProgramControlStatus.Idle).ToString();
                    break;
                case 1:
                    txtProgramControlStatus.Text = (MotorControls.ProgramControlStatus.Running).ToString();
                    break;
                case 2:
                    txtProgramControlStatus.Text = (MotorControls.ProgramControlStatus.Paused).ToString();
                    break;
                case 4:
                    txtProgramControlStatus.Text = (MotorControls.ProgramControlStatus.InError).ToString();
                    break;
                default:
                    break;
            }
        }

        private void GetProgram0Index()
        {
            MotorControls.oHyperTerminalAdapter.Write("@01SPC[0]\r");
            Thread.Sleep(20);
            MotorControls.oHyperTerminalAdapter.Read(ref MotorControls.Program0Index);
            txtProgramControlIndex.Text = MotorControls.Program0Index;
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
            // default colors
            lblNegLim.BackColor = SystemColors.Control;
            lblPosLim.BackColor = SystemColors.Control;
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
                    lblNegLim.BackColor = Color.Green;
                    lblPosLim.BackColor = SystemColors.Control;
                    break;
                case 160:
                    txtStatus.Text = (MotorControls.MotionStatus.PLUS_LIM_ERR).ToString();
                    lblNegLim.BackColor = SystemColors.Control;
                    lblPosLim.BackColor = Color.Green;
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
            switch (Convert.ToInt32(MotorControls.Mode))
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

        private void cmdSCV_Click(object sender, EventArgs e)
        {
            TimerStates.Enabled = false;// disable read values from Motors
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01SCV=1\r");
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void cmdTRAP_Click(object sender, EventArgs e)
        {
            TimerStates.Enabled = false;// disable read values from Motors
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01SCV=0\r");
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void cmdTX_Click(object sender, EventArgs e)
        {

        }

        private void cmdABS_Click(object sender, EventArgs e)
        {
            TimerStates.Enabled = false;// disable read values from Motors
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01ABS\r");
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void cmdINC_Click(object sender, EventArgs e)
        {
            TimerStates.Enabled = false;// disable read values from Motors
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01INC\r");
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void cmdSetEncoderPos_Click(object sender, EventArgs e)
        {
            TimerStates.Enabled = false;// disable read values from Motors
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01EX" + txtRefPos.Text + "\r");
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void cmdSetPulsePos_Click(object sender, EventArgs e)
        {
            TimerStates.Enabled = false;// disable read values from Motors
            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01PX" + txtRefPos.Text + "\r");
            TimerStates.Enabled = true;// enable read values from Motors
        }

        private void cmdCompile_Click(object sender, EventArgs e)
        {
            TimerStates.Enabled = false;
            string startupPath = Environment.CurrentDirectory;
            string curCompileDecompileSettingFile = "sa_compile_decompile_setup.txt";
            string curCompileDecompileSettingDir = startupPath + "\\" + curCompileDecompileSettingFile;

            string[] CompileDecompileSettingRows = new string[] { "MOD:DMX-K-SA-17/23", "OPE:COMPILE", "FIL:Program.prg", "VER:401BLA" };// row settings can be edit later
            using (StreamWriter sw = new StreamWriter(curCompileDecompileSettingFile))
            {
                foreach (string s in CompileDecompileSettingRows)
                {
                    sw.WriteLine(s);
                }
            }

            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Nothing to Compile!");
            }
            else
            {
                string curCompileFile = "Program.prg";
                string curCompileDir = startupPath + "\\" + curCompileFile;
                File.WriteAllText(curCompileFile, txtCode.Text);
                string arg = @"user=Software-2";// just an example this can be anything
                string command = "SA_Compile_Decompile.exe";
                ProcessStartInfo compileProc = new ProcessStartInfo(command, arg);
                compileProc.UseShellExecute = false;
                compileProc.CreateNoWindow = true; // Important if you want to keep shell window hidden
                Process.Start(compileProc).WaitForExit(); //important to add WaitForExit()

                string curCompileOutFile = "CompileOut.txt";
                string curCompileOutDir = startupPath + "\\" + curCompileOutFile;
                string retMsg = "";// Messgebox display
                bool IsCompileOk = true;
                string resultString = "";
                if (File.Exists(curCompileOutFile))
                {
                    string[] lines = File.ReadAllLines(curCompileOutFile);
                    foreach (string line in lines)
                    {
                        // later polish it for focus the line number
                        //if (line.Contains("Line"))
                        //{
                        //    resultString = Regex.Match(line, @"\d+").Value;
                        //    txtCode.SelectionStart = line.Length - 1;// line number
                        //    txtCode.SelectionLength = 1;
                        //    txtCode.Focus();
                        //}
                        if (line.Contains("Failed Compile!"))
                        {
                            IsCompileOk = false;
                        }
                        retMsg += line + "\n";
                    }
                    if (!IsCompileOk)// IsCompileOk become false, only when have "Failed Compile!" display Msg, otherwise no display
                    {
                        MessageBox.Show(retMsg);
                    }
                    else
                    {
                        MessageBox.Show("Done!");
                    }
                }
                else
                {
                    MessageBox.Show("Can not find the File CompileOut.txt.");
                    return;
                }
                //MessageBox.Show("OK");
            }
            if (MotorControls.IsMotorSerialInitialized)
            {
                TimerStates.Enabled = true;
            }
            else
            {
                TimerStates.Enabled = false;
            }
            //TimerStates.Enabled = true;
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {            
            if (MotorControls.IsMotorSerialInitialized)
            {
                TimerStates.Enabled = false;
                MotorControls.oHyperTerminalAdapter.CloseSerialPort();// close serial port

                string startupPath = Environment.CurrentDirectory;
                // Download
                // write some settings to sa_download_upload_setup.txt here
                string curDownloadUploadSettingFile = "sa_download_upload_setup.txt";
                string curDownloadUploadSettingDir = startupPath + "\\" + curDownloadUploadSettingFile;
                string[] DownloadUploadSettingRows = new string[] { "LIN:1275", "COM:SERIAL", "POR:5", "BAU:9600", "DEV:01", 
                "OPE:DOWNLOAD", "FIL:CompileOut.txt", "MOD:DMX-K-SA-17/23" };// row settings can be edit later
                using (StreamWriter sw = new StreamWriter(curDownloadUploadSettingFile))
                {
                    foreach (string s in DownloadUploadSettingRows)
                    {
                        sw.WriteLine(s);
                    }
                }

                string arg = @"user=Software-2";// just an example this can be anything
                string command = "SA_Download_Upload.exe";
                ProcessStartInfo downloadProc = new ProcessStartInfo(command, arg);
                downloadProc.UseShellExecute = false;
                downloadProc.CreateNoWindow = true; // Important if you want to keep shell window hidden
                Process.Start(downloadProc).WaitForExit(); //important to add WaitForExit()

                string curDownloadOutFile = "DownloadOut.txt";
                string curDownloadOutDir = startupPath + "\\" + curDownloadOutFile;
                string retMsg = "";// Messgebox display
                bool IsDownloadOk = true;
                string resultString = "";
                if (File.Exists(curDownloadOutFile))
                {
                    string[] lines = File.ReadAllLines(curDownloadOutFile);
                    foreach (string line in lines)
                    {
                        if (line.Contains("DOWNLOAD FAILED!"))
                        {
                            IsDownloadOk = false;
                        }
                        retMsg += line + "\n";
                    }
                    if (!IsDownloadOk)// IsCompileOk become false, only when have "Failed Compile!" display Msg, otherwise no display
                    {
                        MessageBox.Show(retMsg);
                    }
                    else
                    {
                        MessageBox.Show("Done!");
                    }
                }
                else
                {
                    MessageBox.Show("Can not find the File DownloadOut.txt.");
                    return;
                }

                MotorControls.oHyperTerminalAdapter.OpenSerialPort();// open serial port
                TimerStates.Enabled = true;
            }
            else
            {
                TimerStates.Enabled = false;
                MessageBox.Show("Communication port not open! Cannot download program to the motor!");
            }
            //TimerStates.Enabled = true;
        }

        private void cmdUpload_Click(object sender, EventArgs e)
        {            
            if (MotorControls.IsMotorSerialInitialized)
            {
                TimerStates.Enabled = false;
                MotorControls.oHyperTerminalAdapter.CloseSerialPort();// close serial port

                string startupPath = Environment.CurrentDirectory;
                txtCode.Clear();
                // Upload
                // write some settings to sa_download_upload_setup.txt here
                //string curDownloadUploadSettingFile =
                //    @"D:\JanusProjects\TestRunExeProcess\TestRunExeProcess\TestRunExeProcess\bin\Debug\sa_download_upload_setup.txt";
                string curDownloadUploadSettingFile = "sa_download_upload_setup.txt";
                string curDownloadUploadSettingDir = startupPath + "\\" + curDownloadUploadSettingFile;

                string[] DownloadUploadSettingRows = new string[] { "LIN:1275", "COM:SERIAL", "DEV:01", "POR:5", "BAU:9600", 
                "OPE:UPLOAD", "FIL:CompileOut.txt", "MOD:DMX-K-SA-17/23" };// row settings can be edit later
                using (StreamWriter sw = new StreamWriter(curDownloadUploadSettingFile))
                {
                    foreach (string s in DownloadUploadSettingRows)
                    {
                        sw.WriteLine(s);
                    }
                }

                // Decompile
                // write some settings to sa_compile_decompile_setup.txt here
                string curCompileDecompileSettingFile = "sa_compile_decompile_setup.txt";
                string curCompileDecompileSettingDir = startupPath + "\\" + curCompileDecompileSettingFile;

                string[] CompileDecompileSettingRows = new string[] { "MOD:DMX-K-SA-17/23", "OPE:DECOMPILE", "FIL:UploadOut.txt", "VER:401BLA" };// row settings can be edit later
                using (StreamWriter sw = new StreamWriter(curCompileDecompileSettingFile))
                {
                    foreach (string s in CompileDecompileSettingRows)
                    {
                        sw.WriteLine(s);
                    }
                }

                // Run Shell
                string arg1 = @"user=Software-2";// just an example this can be anything
                string command1 = "SA_Download_Upload.exe";
                ProcessStartInfo uploadProc = new ProcessStartInfo(command1, arg1);
                uploadProc.UseShellExecute = false;
                uploadProc.CreateNoWindow = true; // Important if you want to keep shell window hidden
                Process.Start(uploadProc).WaitForExit(); //important to add WaitForExit()

                // Compile
                string arg2 = @"user=Software-2";// just an example this can be anything
                string command = "SA_Compile_Decompile.exe";
                ProcessStartInfo compileProc = new ProcessStartInfo(command, arg2);
                compileProc.UseShellExecute = false;
                compileProc.CreateNoWindow = true; // Important if you want to keep shell window hidden
                Process.Start(compileProc).WaitForExit(); //important to add WaitForExit()

                // Read Decompile File
                string curDeCompileOutFile = "DecompileOut.prg";
                string curDeCompileOutDir = startupPath + "\\" + curDeCompileOutFile;
                if (File.Exists(curDeCompileOutFile))
                {
                    string[] lines = File.ReadAllLines(curDeCompileOutFile);
                    foreach (string line in lines)
                    {
                        txtCode.AppendText(line + "\r\n");
                    }
                }
                else
                {
                    MessageBox.Show("File DecompileOut.prg does not exist.");
                    return;
                }

                MotorControls.oHyperTerminalAdapter.OpenSerialPort();// open serial port
                TimerStates.Enabled = true;
            }
            else
            {
                TimerStates.Enabled = false;
                MessageBox.Show("Communication port not open! Cannot upload program from the motor!");
            }
            //TimerStates.Enabled = true;
        }

        private void chbxMagMotorControlEnable_Click(object sender, EventArgs e)
        {
            //if (chbxMagMotorControlEnable.Checked)
            //{

            //}
            //else
            //{
                
            //}

            Thread.Sleep(100);
            MotorControls.oHyperTerminalAdapter.Write("@01EO=" + Convert.ToInt32(chbxMagMotorControlEnable.Checked) + "\r");
        }

        private void cmdXThread_Click(object sender, EventArgs e)
        {
            if (MotorControls.IsMotorSerialInitialized)
            {
                TimerStates.Enabled = false;
                XThreadPage xthreadPage = new XThreadPage();
                xthreadPage.ShowDialog();
            }
            else
            {
                return;
            }
        }

        private void cmdExpandProgram_Click(object sender, EventArgs e)
        {
            ExpandedProgramCodePage expandedProgramCodePage = new ExpandedProgramCodePage();
            expandedProgramCodePage.ShowDialog();
        }

        private void cmdView_Click(object sender, EventArgs e)
        {
            MagViewPage magViewPage = new MagViewPage();
            magViewPage.ShowDialog();
        }
    }
}
