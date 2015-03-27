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
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "POL\r");
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

        private void SetPolarity()
        {
            try
            {
                string strInputPolRaw = "";
                // As all the radios are in the groupbox, so it can be done like this way
                MotorControls.PolDirection = radDirCCW.Checked;// bit 1
                MotorControls.PolLimit = radLimitHigh.Checked;// bit 4
                MotorControls.PolHome = radHomeHigh.Checked;// bit 5
                MotorControls.PolLatch = radLatchHigh.Checked;// bit 6
                MotorControls.PolInPosOutput = radInPosHigh.Checked;// bit 7
                MotorControls.PolAlarmOutput = radAlarmHigh.Checked;// bit 8
                MotorControls.PolDigitalOutput = radDigitalOutputHigh.Checked;// bit 9
                MotorControls.PolDigitalInput = radDigitalInputHigh.Checked;// bit 10
                MotorControls.PolSAErr = radSAErrHigh.Checked;// bit 11
                MotorControls.PolEnableOutput = radEnableHigh.Checked;// bit 12

                // single bit string assign
                string strPolReserved0 = "0";
                string strPolDir = (Convert.ToInt32(MotorControls.PolDirection)).ToString();
                string strPolReserved2 = "0";
                string strPolReserved3 = "0";
                string strPolLimit = (Convert.ToInt32(MotorControls.PolLimit)).ToString();
                string strPolHome = (Convert.ToInt32(MotorControls.PolHome)).ToString();
                string strPolLatch = (Convert.ToInt32(MotorControls.PolLatch)).ToString();
                string strPolInPosOutput = (Convert.ToInt32(MotorControls.PolInPosOutput)).ToString();
                string strPolAlarmOutput = (Convert.ToInt32(MotorControls.PolAlarmOutput)).ToString();
                string strPolDigitalOutput = (Convert.ToInt32(MotorControls.PolDigitalOutput)).ToString();
                string strPolDigitalInput = (Convert.ToInt32(MotorControls.PolDigitalInput)).ToString();
                string strPolSAErr = (Convert.ToInt32(MotorControls.PolSAErr)).ToString();
                string strPolEnableOutput = (Convert.ToInt32(MotorControls.PolEnableOutput)).ToString();

                // transfer to Polarity Value
                strInputPolRaw = strPolEnableOutput + strPolSAErr + strPolDigitalInput + strPolDigitalOutput + strPolAlarmOutput + strPolInPosOutput + strPolLatch + 
                    strPolHome + strPolLimit + strPolReserved3 + strPolReserved2 + strPolDir + strPolReserved0;
                string strBinaryPolarity = strInputPolRaw.PadLeft(16, '0');// 16-bit version, add 0 on the left
                int iPolarityVal = Convert.ToInt32(strBinaryPolarity, 2);

                // Set and Send Polarity Value
                string strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "POL=" + iPolarityVal + "\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);

            }
            catch (Exception ex)
            {
                MessageBox.Show("SetPolarity Error!!!");
            }
        }

        private void LoadStepNLoopControl()
        {
            try
            {
                // Step N Loop Control Enable
                string strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "SL\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                chbxStepNLoopControlEnable.Checked = Convert.ToBoolean(Convert.ToInt32(strResultValue));

                // Max Attempt
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "SLA\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                txtMaxAttempt.Text = strResultValue;

                // Tolerance
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "SLT\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                txtTolerance.Text = strResultValue;

                // Idle Tol
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "SLM\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                txtIdleTol.Text = strResultValue;

                // Error Range
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "SLE\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                txtErrorRange.Text = strResultValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadStepNLoopControl Error!!!");
            }
        }

        private void SetStepNLoopControl()
        {
            try
            {
                // Step N Loop Control Enable
                string strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "SL=" + Convert.ToInt32(chbxStepNLoopControlEnable.Checked) + "\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);

                // Max Attempt
                strResultValue = "";
                int parsedResult;
                if (int.TryParse(txtMaxAttempt.Text, out parsedResult) == false)
                {
                    MessageBox.Show("Only Numeric Values are allowed for Max Attempt.");
                    return;
                }
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "SLA=" + parsedResult + "\r");// Convert.ToInt32(txtMaxAttempt.Text)
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);


                // Tolerance
                strResultValue = "";
                if (int.TryParse(txtTolerance.Text, out parsedResult) == false)
                {
                    MessageBox.Show("Only Numeric Values are allowed for Tolerance.");
                    return;
                }
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "SLT=" + parsedResult + "\r");// Convert.ToInt32(txtTolerance.Text)
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);

                // Idle Tol
                strResultValue = "";
                if (int.TryParse(txtIdleTol.Text, out parsedResult) == false)
                {
                    MessageBox.Show("Only Numeric Values are allowed for Idle Tol.");
                }
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "SLM=" + parsedResult + "\r");// Convert.ToInt32(txtIdleTol.Text)
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);

                // Error Range
                strResultValue = "";
                if (int.TryParse(txtErrorRange.Text, out parsedResult) == false)
                {
                    MessageBox.Show("Only Numeric Values are allowed for Error Range.");
                }
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "SLE=" + parsedResult + "\r");// Convert.ToInt32(txtErrorRange.Text)
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show("SetStepNLoopControl Error!!!");
            }
        }

        private void LoadCommunicationSetup()
        {
            try
            {
                // Communication mode
                string strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "CM\r");
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
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "RT\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                chbxAppendID.Checked= Convert.ToBoolean(Convert.ToInt32(strResultValue));

                // AutoResponse
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "AR\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                chbxAutoResponse.Checked = Convert.ToBoolean(Convert.ToInt32(strResultValue));

                // BaudRate
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "DB\r");
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
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "DN\r");
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
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "TOC\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                txtTimeOutCounter.Text = strResultValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadCommunicationSetup Error!!!");
            }
        }

        private void SetCommunicationSetup()
        {
            try
            {
                // Communication method
                string strResultValue = "";

                // Append ID
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "RT=" + Convert.ToInt32(chbxAppendID.Checked) + "\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);

                // Auto Response
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "AR=" + Convert.ToInt32(chbxAutoResponse.Checked) + "\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);

                // Baud Rate

                // Device ID

                // Time-out Counter
                strResultValue = "";
                int parsedResult;
                if (int.TryParse(txtTimeOutCounter.Text, out parsedResult) == false)
                {
                    MessageBox.Show("Only Numeric Values are allowed for Time-out Counter.");
                    return;
                }
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "TOC=" + parsedResult + "\r");// Convert.ToInt32(txtTimeOutCounter.Text) 
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show("SetCommunicationSetup Error!!!");
            }
        }

        private void LoadMiscSettings()
        {
            try
            {
                // Enable Decel
                string strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "EDEC\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                chbxEnableDecel.Checked = Convert.ToBoolean(Convert.ToInt32(strResultValue));

                // IERR
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "IERR\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                chbxIERR.Checked = Convert.ToBoolean(Convert.ToInt32(strResultValue));

                // Alm/Inp
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "EDO\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                chbxAlmInp.Checked = Convert.ToBoolean(Convert.ToInt32(strResultValue));

                // AutoRun
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "SLOAD\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref MotorControls.AutoRunVal);
                int iAutoRunVal = Convert.ToInt32(MotorControls.AutoRunVal);
                string strAutoRun = Convert.ToString(iAutoRunVal, 2).PadLeft(2, '0');// 2-bit version
                // AutoRun 0(bit 0), Bit in inverse direction
                MotorControls.AutoRun0 = Convert.ToBoolean(Convert.ToInt32(strAutoRun.Substring(1, 1)));
                chbxAutoRun0.Checked = MotorControls.AutoRun0;
                // AutoRun 1(bit 1)
                MotorControls.AutoRun1 = Convert.ToBoolean(Convert.ToInt32(strAutoRun.Substring(0, 1)));
                chbxAutoRun1.Checked = MotorControls.AutoRun1;

                // RZ
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "RZ\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                chbxRZ.Checked = Convert.ToBoolean(Convert.ToInt32(strResultValue));

                // EO Boot
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "EOBOOT\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                txtEOBoot.Text = strResultValue;

                // LCA
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "LCA\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                txtLCA.Text = strResultValue;

                // DO Boot
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "DOBOOT\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                txtDOBoot.Text = strResultValue;

                // HCA
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "HCA\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                txtHCA.Text = strResultValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadMiscSettings Error!!!");
            }
        }

        private void SetMiscSettings()
        {
            try
            {
                // Enable Decel
                string strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "EDEC=" + Convert.ToInt32(chbxEnableDecel.Checked) + "\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);

                // IERR
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "IERR" + Convert.ToInt32(chbxIERR.Checked) + "\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);

                // Alm/Inp
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "EDO" + Convert.ToInt32(chbxAlmInp.Checked) + "\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);

                // AutoRun
                strResultValue = "";
                string strInputAutoRunRaw = "";
                MotorControls.AutoRun0 = chbxAutoRun0.Checked;
                MotorControls.AutoRun1 = chbxAutoRun1.Checked;
                // single bit string assign
                string strAutoRun0 = (Convert.ToInt32(MotorControls.AutoRun0)).ToString();
                string strAutoRun1 = (Convert.ToInt32(MotorControls.AutoRun1)).ToString();
                strInputAutoRunRaw = strAutoRun1 + strAutoRun0;
                int iAutoRunVal = Convert.ToInt32(strInputAutoRunRaw, 2);
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "SLOAD=" + iAutoRunVal + "\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);

                // RZ
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "RZ=" + Convert.ToInt32(chbxRZ.Checked) + "\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);

                // EO Boot
                strResultValue = "";
                int parsedResult;
                if (int.TryParse(txtEOBoot.Text, out parsedResult) == false)
                {
                    MessageBox.Show("Only Numeric Values are allowed for EO Boot.");
                    return;
                }
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "EOBOOT=" + parsedResult + "\r");// Convert.ToInt32(txtEOBoot.Text) 
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);

                // LCA
                strResultValue = "";
                if (int.TryParse(txtLCA.Text, out parsedResult) == false)
                {
                    MessageBox.Show("Only Numeric Values are allowed for LCA.");
                    return;
                }
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "LCA=" + parsedResult + "\r");// Convert.ToInt32(txtLCA.Text)
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);

                // DO Boot
                strResultValue = "";
                if (int.TryParse(txtDOBoot.Text, out parsedResult) == false)
                {
                    MessageBox.Show("Only Numeric Values are allowed for DO Boot.");
                    return;
                }
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "DOBOOT=" + parsedResult + "\r");// Convert.ToInt32(txtDOBoot.Text)
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);

                // HCA
                strResultValue = "";
                if (int.TryParse(txtHCA.Text, out parsedResult) == false)
                {
                    MessageBox.Show("Only Numeric Values are allowed for HCA.");
                    return;
                }
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "HCA=" + parsedResult + "\r");// Convert.ToInt32(txtHCA.Text)
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show("SetMiscSettings Error!!!");
            }
        }

        private void LoadDriverCurrent()
        {
            try
            {
                // Run Current
                string strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "CURR\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                txtCurrentRun.Text = strResultValue;

                // Idle Current
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "CURI\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                txtCurrentIdle.Text = strResultValue;

                // Idle Time Setting
                strResultValue = "";
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "CURT\r");
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                txtCurrentIdleTimeSetting.Text = strResultValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadDriverCurrent Error!!!");
            }
        }

        private void SetDriverCurrent()
        {
            try
            {
                string strResultValue = "";
                // Run Current
                int parsedResult;
                if (int.TryParse(txtCurrentRun.Text, out parsedResult) == false)
                {
                    MessageBox.Show("Only Numeric Values are allowed for Run Current.");
                    return;
                }
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "CURR=" + parsedResult + "\r");// Convert.ToInt32(txtCurrentRun.Text)
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);

                // Idle Current
                if (int.TryParse(txtCurrentIdle.Text, out parsedResult) == false)
                {
                    MessageBox.Show("Only Numeric Values are allowed for Idle Current.");
                    return;
                }
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "CURI=" + parsedResult + "\r");// Convert.ToInt32(txtCurrentIdle.Text)
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);

                // Idle Time Setting
                if (int.TryParse(txtCurrentIdleTimeSetting.Text, out parsedResult) == false)
                {
                    MessageBox.Show("Only Numeric Values are allowed for Idle Time Setting.");
                    return;
                }
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "CURT=" + parsedResult + "\r");// Convert.ToInt32(txtCurrentIdleTimeSetting.Text)
                Thread.Sleep(10);
                MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show("SetDriverCurrent Error!!!");
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

        private void DownloadSetupSettings()
        {
            try
            {
                // Set Polarity in the Polarity groupbox
                SetPolarity();
                // Load StepNLoop Control in the StepNLoop groupbox
                SetStepNLoopControl();
                // Load Communication Setup(Need to check)
                SetCommunicationSetup();
                // Load Misc Settings
                SetMiscSettings();
                // Load Driver Current in the Driver Current groupbox
                SetDriverCurrent();
                // MessageBox Show
                MessageBox.Show("Download Done!");
            }
            catch (Exception)
            {
                MessageBox.Show("DownloadSetupSettings Failed!!!");
            }
        }

        private void cmdDown_Click(object sender, EventArgs e)
        {
            if (MotorControls.IsMotorSerialInitialized)
            {
                DownloadSetupSettings();
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
                if (MessageBox.Show("Are you sure you want to save parameters to flash?", "Store to Flash", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //DownloadSetupSettings();

                    //string strResultValue = "";
                    //// Store settings
                    //MotorControls.oHyperTerminalAdapter.Write("@01STORE\r");
                    //Thread.Sleep(10);
                    //MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
                    MessageBox.Show("Store to Flash Done!");
                }
            }
            else
            {
                MessageBox.Show("Communication port not open!");
            }
        }
    }
}
