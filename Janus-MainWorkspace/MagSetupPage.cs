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
            string[] strDeviceIDs = new string[8];// 0 to 7, maximum is 8 Magazines
            for (i = 0; i < strDeviceIDs.Length; i++)
            {
                strDeviceIDs[i] = (i + 1).ToString();// Device ID from 1 to 8, but SelectIndex from 0 to 7(so there is a mapping between them)
            }
            SetDeviceIDComboBox(strDeviceIDs);

            if (MotorControls.IsMotorSerialInitialized)
            {
                // Some TextBox and CheckBox Enable
                chbxAutoResponse.Enabled = true;
                txtTimeOutCounter.Enabled = true;
                chbxEnableDecel.Enabled = true;
                chbxIERR.Enabled = true;
                chbxAutoRun1.Enabled = true;
                txtEOBoot.Enabled = true;
                txtDOBoot.Enabled = true;
                txtHCA.Enabled = true;

                // Some GroupBox Enable
                gpbOutput.Enabled = true;
                gpbInput.Enabled = true;
                gpbSAErr.Enabled = true;
                gpbPolarityEnable.Enabled = true;

                // Load Polarity in the Polarity groupbox
                LoadPolarity();
                // Load StepNLoop Control in the StepNLoop groupbox
                LoadStepNLoopControl();
                // Load Communication Setup
                LoadCommunicationSetup();
                // Load Misc Settings
                LoadMiscSettings();
                // Load Driver Current in the Driver Current groupbox
                LoadDriverCurrent();
            }
            else
            {
                // Some TextBox and CheckBox Disable
                chbxAutoResponse.Enabled = false;
                txtTimeOutCounter.Enabled = false;
                chbxEnableDecel.Enabled = false;
                chbxIERR.Enabled = false;
                chbxAutoRun1.Enabled = false;
                txtEOBoot.Enabled = false;
                txtDOBoot.Enabled = false;
                txtHCA.Enabled = false;
 
                // Some GroupBox Disable
                gpbOutput.Enabled = false;
                gpbInput.Enabled = false;
                gpbSAErr.Enabled = false;
                gpbPolarityEnable.Enabled = false;
            }
        }

        private void LoadPolarity()
        {
            try
            {
                MotorControls.oHyperTerminalAdapter.Write("@01POL\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref MotorControls.PolarityVal);
                int iPolarity = Convert.ToInt32(MotorControls.PolarityVal);
                string strBinaryPolarity = Convert.ToString(iPolarity, 2).PadLeft(16, '0');// 16-bit version
                // Direction(bit 1), Bit in inverse direction
                MotorControls.PolDirection = Convert.ToBoolean(Convert.ToInt32(strBinaryPolarity.Substring(14, 1)));
                // Limit(bit 4)
                MotorControls.PolLimit = Convert.ToBoolean(Convert.ToInt32(strBinaryPolarity.Substring(11, 1)));
                // Home(bit 5)
                MotorControls.PolHome = Convert.ToBoolean(Convert.ToInt32(strBinaryPolarity.Substring(10, 1)));
                // Latch(bit 6)
                MotorControls.PolLatch = Convert.ToBoolean(Convert.ToInt32(strBinaryPolarity.Substring(9, 1)));
                // In Position Output(bit 7)
                MotorControls.PolInPosOutput = Convert.ToBoolean(Convert.ToInt32(strBinaryPolarity.Substring(8, 1)));
                // Alarm Output(bit 8)
                MotorControls.PolAlarmOutput = Convert.ToBoolean(Convert.ToInt32(strBinaryPolarity.Substring(7, 1)));
                // Digital Output(bit 9)
                MotorControls.PolDigitalOutput = Convert.ToBoolean(Convert.ToInt32(strBinaryPolarity.Substring(6, 1)));
                // Digital Input(bit 10)
                MotorControls.PolDigitalInput = Convert.ToBoolean(Convert.ToInt32(strBinaryPolarity.Substring(5, 1)));
                // SA Err, Jump to line 0 on error(bit 11)
                MotorControls.PolSAErr = Convert.ToBoolean(Convert.ToInt32(strBinaryPolarity.Substring(4, 1)));
                // Enable Output(bit 12)
                MotorControls.PolEnableOutput = Convert.ToBoolean(Convert.ToInt32(strBinaryPolarity.Substring(3, 1)));

                // Corresponding UI related
                // Dir
                if (MotorControls.PolDirection)
                {
                    radDirCCW.Checked = true;
                }
                else
                {
                    radDirCW.Checked = true;
                }

                // Home
                if (MotorControls.PolHome)
                {
                    radHomeHigh.Checked = true;
                }
                else
                {
                    radHomeLow.Checked = true;
                }

                // Limit
                if (MotorControls.PolLimit)
                {
                    radLimitHigh.Checked = true;
                }
                else
                {
                    radLimitLow.Checked = true;
                }

                // Latch
                if (MotorControls.PolLatch)
                {
                    radLatchHigh.Checked = true;
                }
                else
                {
                    radLatchLow.Checked = true;
                }

                // In Pos Output
                if (MotorControls.PolInPosOutput)
                {
                    radInPosHigh.Checked = true;
                }
                else
                {
                    radInPosLow.Checked = true;
                }

                // Alarm Output
                if (MotorControls.PolAlarmOutput)
                {
                    radAlarmHigh.Checked = true;
                }
                else
                {
                    radAlarmLow.Checked = true;
                }

                // Digital Output
                if (MotorControls.PolDigitalOutput)
                {
                    radDigitalOutputHigh.Checked = true;
                }
                else
                {
                    radDigitalOutputLow.Checked = true;
                }

                // Input
                if (MotorControls.PolDigitalInput)
                {
                    radDigitalInputHigh.Checked = true;
                }
                else
                {
                    radDigitalInputLow.Checked = true;
                }

                // Sa Err
                if (MotorControls.PolSAErr)
                {
                    radSAErrHigh.Checked = true;
                }
                else
                {
                    radSAErrLow.Checked = true;
                }

                // Enable
                if (MotorControls.PolEnableOutput)
                {
                    radEnableHigh.Checked = true;
                }
                else
                {
                    radEnableLow.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadPolarity Error!!!");
            }
        }

        private void LoadStepNLoopControl()
        {
            try
            {
                string strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@01SL\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                chbxStepNLoopControlEnable.Checked = Convert.ToBoolean(Convert.ToInt32(strResultValue));

                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@01SLA\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                txtMaxAttempt.Text = strResultValue;

                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@01SLT\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                txtTolerance.Text = strResultValue;

                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@01SLM\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                txtIdleTol.Text = strResultValue;

                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@01SLE\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                txtErrorRange.Text = strResultValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadStepNLoopControl Error!!!");
            }
        }

        private void LoadCommunicationSetup()
        {
            try
            {
                // Communication mode
                string strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@01CM\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                if (Convert.ToBoolean(Convert.ToInt32(strResultValue)))
                {
                    radRS485.Checked = true;
                }
                else
                {
                    radRS232.Checked = true;
                }

                // Append ID
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@01RT\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                chbxAppendID.Checked= Convert.ToBoolean(Convert.ToInt32(strResultValue));

                // AutoResponse
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@01AR\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                chbxAutoResponse.Checked = Convert.ToBoolean(Convert.ToInt32(strResultValue));

                // BaudRate
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@01DB\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                int iBaudRate = Convert.ToInt32(strResultValue);
                if (iBaudRate <= 5)
                {
                    combxBaudRate.SelectedIndex = iBaudRate - 1;
                }
                else
                {
                    MessageBox.Show("BaudRate Range error!!!");
                }

                // Device ID
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@01DN\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                int iDeviceId = Convert.ToInt32(strResultValue.Substring(3));
                if (((iDeviceId - 1) >= 0) && ((iDeviceId - 1) <= 7))// 0 to 7, maximum is 8 Magazines
                {
                    combxDeviceID.SelectedIndex = iDeviceId - 1;// Mapping to SelectedIndex
                    MotorControls.DeviceId = iDeviceId;
                }
                else
                {
                    MessageBox.Show("Device ID error!!!");
                }

                // TimeOut Counter
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@01TOC\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                txtTimeOutCounter.Text = strResultValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadCommunicationSetup Error!!!");
            }
        }

        private void LoadMiscSettings()
        {
            try
            {
                // Enable Decel
                string strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@01EDEC\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                chbxEnableDecel.Checked = Convert.ToBoolean(Convert.ToInt32(strResultValue));

                // IERR
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@01IERR\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                chbxIERR.Checked = Convert.ToBoolean(Convert.ToInt32(strResultValue));

                // Alm/Inp
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@01EDO\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                chbxAlmInp.Checked = Convert.ToBoolean(Convert.ToInt32(strResultValue));

                // AutoRun 0
                MotorControls.oHyperTerminalAdapter.Write("@01SLOAD\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref MotorControls.AutoRunVal);
                int iAutoRunVal = Convert.ToInt32(MotorControls.AutoRunVal);
                string strAutoRun = Convert.ToString(iAutoRunVal, 2).PadLeft(2, '0');// 2-bit version
                // AutoRun 0(bit 0)
                MotorControls.AutoRun0 = Convert.ToBoolean(Convert.ToInt32(strAutoRun.Substring(0, 1)));
                chbxAutoRun0.Checked = MotorControls.AutoRun0;
                // AutoRun 1(bit 1)
                MotorControls.AutoRun1 = Convert.ToBoolean(Convert.ToInt32(strAutoRun.Substring(1, 1)));
                chbxAutoRun1.Checked = MotorControls.AutoRun1;

                // RZ
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@01RZ\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                chbxRZ.Checked = Convert.ToBoolean(Convert.ToInt32(strResultValue));

                // EO Boot
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@01EOBOOT\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                txtEOBoot.Text = strResultValue;

                // LCA
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@01LCA\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                txtLCA.Text = strResultValue;

                // DO Boot
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@01DOBOOT\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                txtDOBoot.Text = strResultValue;

                // HCA
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@01HCA\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                txtHCA.Text = strResultValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadMiscSettings Error!!!");
            }
        }

        private void LoadDriverCurrent()
        {
            try
            {
                // Run Current
                string strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@01CURR\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                txtCurrentRun.Text = strResultValue;

                // Idle Current
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@01CURI\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                txtCurrentIdle.Text = strResultValue;

                // Idle Time Setting
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@01CURT\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                txtCurrentIdleTimeSetting.Text = strResultValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadDriverCurrent Error!!!");
            }
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
                // Some TextBox and CheckBox Enable
                chbxAutoResponse.Enabled = true;
                txtTimeOutCounter.Enabled = true;
                chbxEnableDecel.Enabled = true;
                chbxIERR.Enabled = true;
                chbxAutoRun1.Enabled = true;
                txtEOBoot.Enabled = true;
                txtDOBoot.Enabled = true;
                txtHCA.Enabled = true;

                // Some GroupBox Enable
                gpbOutput.Enabled = true;
                gpbInput.Enabled = true;
                gpbSAErr.Enabled = true;
                gpbPolarityEnable.Enabled = true;

                // Load Polarity in the Polarity groupbox
                LoadPolarity();
                // Load StepNLoop Control in the StepNLoop groupbox
                LoadStepNLoopControl();
                // Load Communication Setup
                LoadCommunicationSetup();
                // Load Misc Settings
                LoadMiscSettings();
                // Load Driver Current in the Driver Current groupbox
                LoadDriverCurrent();
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
