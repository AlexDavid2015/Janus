using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using Advantech.Adam;
using Apax_IO_Module_Library;
using System.Collections;

namespace CxTitan
{
    public static class AvantechAIs
    {
        //************************** AI module(APAX-5017H) **************************//
        // Global object
        public const string APAX_INFO_NAME = "APAX";
        public const string DVICE_TYPE = "5017H";

        public static AdamSocket m_adamSocket;
        public static int[] m_iTimeout;
        public static string m_szIP = "";//""

        public static Apax5000Config m_aConf;
        public static int m_idxID;
        public static int m_ScanTime_LocalSys;
        public static int m_iFailCount, m_iScanCount;
        public static int m_tmpidx;
        public static string[] m_szSlots;// Container of all solt device type

        public static bool[] m_bChMask;
        public static uint m_uiChMask = 0;
        public static uint m_uiBurnoutVal = 0;
        public static uint m_uiBurnoutMask = 0;
        public static ushort[] m_usRanges;
        public static bool m_bStartFlag = false;
        public static ushort m_usStart;
        public static ushort m_usLength;
        public static string StatusBar_IO = "";
        public static int m_iSamplingRateIdx = 0;// for recording idx in RefreshAiSampleRate() and idx external use
        

        // Some Text information
        public static string txtModule;       //Information-> Module
        public static string txtID;                //Information -> Switch ID
        public static string txtSupportKernelFw;     //Information -> Support kernel Fw
        public static string txtFwVer;                    //Firmware version
        public static string txtAIOFwVer;   //AIO Firmware version
        // End of Some Text information

        public static bool chbxShowRawData = false;// indicate whether show raw data

        public static void Initialize()
        {
            m_szSlots = null;
            m_iScanCount = 0;
            m_iFailCount = 0;
            m_bChMask = new bool[AdamControl.APAX_MaxAIOCh];
            m_idxID = -1; // Set in invalid num 
            m_ScanTime_LocalSys = 500;// Scan time default 500 ms
            //timer1.Interval = m_ScanTime_LocalSys;//1000
            m_iTimeout = new int[3];
            m_iTimeout[0] = 2000; // Connection Timeout    
            m_iTimeout[1] = 2000; // Send Timeout
            m_iTimeout[2] = 2000;// Receive Timeout
            //this.StatusBar_IO.Text = ("Start to demo "
            //            + (APAX_INFO_NAME + ("-"
            //            + (DVICE_TYPE + " by clicking \'Start\' button."))));
        }

        public static void Initialize(string IP, int SlotNum, int ScanTime)
        {
            m_szSlots = null;
            m_idxID = SlotNum; // Set Slot_ID
            m_iScanCount = 0;
            m_iFailCount = 0;
            m_bChMask = new bool[AdamControl.APAX_MaxAIOCh];
            m_ScanTime_LocalSys = ScanTime;// Scan time

            //timer1.Interval = m_ScanTime_LocalSys;//1000
            m_iTimeout = new int[3];
            m_iTimeout[0] = 2000;// Connection Timeout    
            m_iTimeout[1] = 2000;// Send Timeout
            m_iTimeout[2] = 2000;// Receive Timeout
            m_szIP = IP;

            //this.StatusBar_IO.Text = ("Start to demo "
            //            + (APAX_INFO_NAME + ("-"
            //            + (DVICE_TYPE + " by clicking \'Start\' button."))));
        }

        /// <summary>
        /// Waiting Foam dialog
        /// </summary>
        public static void showMsg()
        {
            Wait_Form FormWait = new Wait_Form();
            FormWait.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            FormWait.Start_Wait(3000);
            FormWait.ShowDialog();
            FormWait.Dispose();
            FormWait = null;
        }

        /// <summary>
        /// Check module controllable
        /// </summary>
        /// <returns></returns>
        public static bool CheckControllable()
        {
            //Avantech.AIEnabled = false;// disable AI refresh
            ushort active;
            if (m_adamSocket.Configuration().SYS_GetGlobalActive(out active))
            {
                if (active == 1)
                    return true;
                else
                {
                    MessageBox.Show("There is another controller taking control, so you only can monitor IO data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    return false;
                }
            }
            else if (m_adamSocket.Modbus().LastError == Advantech.Common.ErrorCode.Socket_Recv_Fail)
                MessageBox.Show("SYS_GetGlobalActive failed (Err: " + m_adamSocket.Modbus().LastError.ToString() + ")", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            else
                MessageBox.Show("Checking controllable failed, utility only could monitor io data now. (" + m_adamSocket.Modbus().LastError.ToString() + ")", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            //Avantech.AIEnabled = true;// enable AI refresh
            return false;
        }

        /// <summary>
        /// Get Channel information "Range" column
        /// </summary>
        /// <returns></returns>
        public static bool RefreshRanges()
        {
            try
            {
                int iChannelTotal = m_aConf.HwIoTotal[m_tmpidx];
                if (m_adamSocket.Configuration().GetModuleConfig(m_idxID, out m_aConf))
                {
                    m_adamSocket.Configuration().GetModuleCurrentRange(Convert.ToInt32(m_idxID), m_aConf);
                    m_usRanges = m_aConf.wChRange;
                    m_adamSocket.Configuration().GetModuleCurrentChMsk(Convert.ToInt32(m_idxID), m_aConf);
                    m_uiChMask = m_aConf.dwChMask;
                    for (int i = 0; i < m_bChMask.Length; i++)
                    {
                        m_bChMask[i] = ((m_uiChMask & (0x01 << i)) > 0);
                    }
                    //for (int i = 0; i < iChannelTotal; i++)
                    //{
                    //    listViewChInfo.Items[i].SubItems[5].Text = AnalogInput.GetRangeName(m_usRanges[i]).ToString();
                    //}
                }
                else
                    StatusBar_IO += "GetModuleConfig(Error:" + m_adamSocket.Modbus().LastError.ToString() + ") Failed! ";//StatusBar_IO.Text += "GetModuleConfig(Error:" + m_adamSocket.Modbus().LastError.ToString() + ") Failed! ";
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Refresh Integration time 
        /// </summary>
        public static void RefreshAiSetting()
        {
            if (m_adamSocket.Configuration().GetModuleFunPara(m_idxID, m_aConf))
            {
                uint uiFcnParam;

                //Check if support SampleRate
                if (m_aConf.byFunType_0 == (byte)_FunctionType.Filter)
                {
                    uiFcnParam = m_aConf.dwFunParam_0;
                }
                else if (m_aConf.byFunType_1 == (byte)_FunctionType.Filter)
                {
                    uiFcnParam = m_aConf.dwFunParam_1;
                }
                else if (m_aConf.byFunType_2 == (byte)_FunctionType.Filter)
                {
                    uiFcnParam = m_aConf.dwFunParam_2;
                }
                else if (m_aConf.byFunType_3 == (byte)_FunctionType.Filter)
                {
                    uiFcnParam = m_aConf.dwFunParam_3;
                }
                else if (m_aConf.byFunType_4 == (byte)_FunctionType.Filter)
                {
                    uiFcnParam = m_aConf.dwFunParam_4;
                }
                else
                    return;
            }
            else
                StatusBar_IO += "GetModuleConfig(Error:" + m_adamSocket.Modbus().LastError.ToString() + ") Failed! ";//StatusBar_IO.Text += "GetModuleConfig(Error:" + m_adamSocket.Modbus().LastError.ToString() + ") Failed! ";
        }

        /// <summary>
        /// Refresh AI Burnout detect mode settings
        /// </summary>
        /// <param name="bUpdateBurnFun"></param>
        /// <param name="bUpdateBurnVal"></param>
        /// <returns></returns>
        public static bool RefreshBurnoutSetting(bool bUpdateBurnFun, bool bUpdateBurnVal)
        {
            try
            {
                bool bRet = false;
                uint o_dwEnableMask;
                uint o_dwValue;

                ThreadStart newStart = new ThreadStart(showMsg);
                Thread waitThread = new Thread(newStart);
                waitThread.Start();

                if (bUpdateBurnFun)     //Get burnout mask value
                {
                    if (!m_adamSocket.AnalogInput().GetBurnoutFunEnable(m_idxID, out o_dwEnableMask))
                        bRet = false;
                    else
                    {
                        bRet = true;
                        m_uiBurnoutMask = o_dwEnableMask;
                    }
                    System.Threading.Thread.Sleep(1000);
                }
                if (bUpdateBurnVal)
                {
                    if (!m_adamSocket.AnalogInput().GetBurnoutValue(m_idxID, out o_dwValue))
                        bRet = false;
                    else
                    {
                        bRet = true;
                        m_uiBurnoutVal = o_dwValue;
                        //if (m_uiBurnoutVal == 0x00000000)       //Update Burnout Detect Mode combobox value
                        //    cbxBurnoutValue.SelectedIndex = 0;
                        //else
                        //    cbxBurnoutValue.SelectedIndex = 1;
                    }
                }
                return bRet;
            }
            catch
            {
                return false;
            }
        }

        public static void RefreshAiSampleRate()
        {
            int idx = -1;
            uint uiRate;
            if (m_adamSocket.AnalogInput().GetSampleRate(m_idxID, out uiRate))
            {
                if (m_aConf.GetModuleName() == "5017")
                {
                    if (uiRate == 1)
                        idx = 0;
                    else if (uiRate == 10)
                        idx = 1;
                }
                else if (m_aConf.GetModuleName() == "5017H")
                {
                    if (uiRate == 100)
                        idx = 0;
                    else if (uiRate == 1000)
                        idx = 1;
                }
                else
                    idx = -2;

                if (idx >= 0)
                {
                    //if (idx > cbxSampleRate.Items.Count - 1)
                    //    cbxSampleRate.SelectedIndex = -1;
                    //else
                    //    cbxSampleRate.SelectedIndex = idx;
                }
                else
                    StatusBar_IO += "GetSampleRate Index (Err : " + idx.ToString() + ") Failed! ";//StatusBar_IO.Text += "GetSampleRate Index (Err : " + idx.ToString() + ") Failed! ";
                m_iSamplingRateIdx = idx;
            }
            else
                StatusBar_IO += "GetSampleRate (Err : " + m_adamSocket.Modbus().LastError.ToString() + ") Failed! ";//StatusBar_IO.Text += "GetSampleRate (Err : " + m_adamSocket.Modbus().LastError.ToString() + ") Failed! ";
        }

        /// <summary>
        /// When change tab, refresh status, timer, counter related informations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSelPageName = "AI";//string strSelPageName = tabControl1.TabPages[tabControl1.SelectedIndex].Text;
            //StatusBar_IO.Text = "";
            m_adamSocket.Disconnect();
            m_adamSocket.Connect(m_adamSocket.GetIP(), ProtocolType.Tcp, 502);
            if (strSelPageName == "Module Information")
            {
                m_iFailCount = 0;
                m_iScanCount = 0;
            }
            else if (strSelPageName == "AI")
            {
                RefreshRanges();
                RefreshAiSetting();
                if (m_aConf.GetModuleName() == "5017H")
                    RefreshBurnoutSetting(true, true);
                if (m_aConf.GetModuleName() == "5017")
                    RefreshBurnoutSetting(false, true);

                RefreshAiSampleRate();
            }

            // timer1 enabled always
            //if (tabControl1.SelectedIndex == 0)
            //    timer1.Enabled = false;
            //else
            //{
            //    if (listViewChInfo.SelectedIndices.Count == 0)
            //        listViewChInfo.Items[0].Selected = true;

            //    timer1.Enabled = true;
            //}
        }

        public static void Start()
        {
            string strbtnStatus = "Start";
            if ((string.Compare(strbtnStatus, "Start", true) == 0))
            {
                // Was Stop, Then Start
                if (!StartRemote())
                {
                    return;
                }
                m_bStartFlag = true;
                //this.btnStart.Text = "Stop";
            }
            else
            {
                // Was Start, Then Stop
                //this.StatusBar_IO.Text = ("Start to demo "
                //            + APAX_INFO_NAME + "-"
                //            + DVICE_TYPE + " by clicking 'Start'button.");
                StatusBar_IO = ("Start to demo "
                        + APAX_INFO_NAME + "-"
                        + DVICE_TYPE + " by clicking 'Start'button.");
                FreeResource();
                //this.btnStart.Text = "Start";
            }
        }

        public static void formIP_ApplyIPAddressClick(string strIP)
        {
            m_szIP = strIP;
        }

        public static bool SetIp()
        {
            int count = 0;
            while (((count <= 2) && (m_szIP == "")))
            {
                IPForm formIP = new IPForm();
                formIP.ApplyIPAddressClick += new IPForm.EventHandler_ApplyIPAddressClick(formIP_ApplyIPAddressClick);
                formIP.ShowDialog();
                formIP.Dispose();
                formIP = null;
                count++;
            }
            if ((m_szIP == null))
            {
                return false;
            }
            return true;
        }

        public static bool OpenDevice()
        {
            m_adamSocket = new AdamSocket(AdamType.Apax5070);
            m_adamSocket.SetTimeout(m_iTimeout[0], m_iTimeout[1], m_iTimeout[2]);
            if (m_adamSocket.Connect(AdamType.Apax5070, m_szIP, ProtocolType.Tcp))
            {
                if (!m_adamSocket.Configuration().GetSlotInfo(out m_szSlots))
                {
                    StatusBar_IO = "GetSlotInfo() Failed! ";//this.StatusBar_IO.Text = "GetSlotInfo() Failed! ";
                    return false;
                }
            }
            return true;
        }

        public static bool DeviceFind()
        {
            int iLoop = 0;
            int iDeviceNum = 0;
            if ((m_idxID == -1))
            {
                for (iLoop = 0; iLoop < m_szSlots.Length; iLoop++)
                {
                    if ((m_szSlots[iLoop] == null))
                        continue;
                    if ((string.Compare(m_szSlots[iLoop], 0, DVICE_TYPE, 0, DVICE_TYPE.Length) == 0) && (m_szSlots[iLoop].Length == 5))
                    {
                        iDeviceNum++;
                        if ((iDeviceNum == 1))// Record first find device
                        {

                            m_idxID = iLoop;// Get DVICE_TYPE Solt

                        }
                    }
                }
            }
            else if ((string.Compare(m_szSlots[m_idxID], 0, DVICE_TYPE, 0, DVICE_TYPE.Length) == 0))
            {
                iDeviceNum++;
            }

            if ((iDeviceNum == 1))
            {
                return true;
            }
            else if ((iDeviceNum > 1))
            {
                MessageBox.Show("Found " + iDeviceNum.ToString() + " " + DVICE_TYPE + " devices." + " It's will demo Solt " + m_idxID.ToString() + ".", "Warning");
                return true;
            }
            else
            {
                MessageBox.Show(("Can\'t find any "
                                + (DVICE_TYPE + " device!")), "Error");
                return false;
            }
        }

        /// <summary>
        /// Used for change I/O module 
        /// </summary>
        /// <returns></returns>
        public static bool FreeResource()
        {
            if (m_bStartFlag)
            {
                m_bStartFlag = false;
                //this.tabControl1.Enabled = false;
                //this.tabControl1.Visible = false;
                Avantech.AIEnabled = false;//timer1.Enabled = false;

                m_adamSocket.Configuration().SYS_SetLocateModule(m_idxID, 0);
                m_adamSocket.Disconnect();
                m_adamSocket = null;
            }
            return true;
        }

        public static bool StartRemote()
        {
            if ((m_szIP == ""))
            {
                if (!SetIp())
                {
                    MessageBox.Show("Demo failed! Please set up IP address.", "Error");
                    return false;
                }
            }
            try
            {
                if (!OpenDevice())
                {
                    throw new System.Exception("Open Local Device Fail.");
                }
                if (!DeviceFind())
                {
                    throw new System.Exception("Find " + DVICE_TYPE + "Device Fail.");
                }
                if (!RefreshConfiguration())
                {
                    throw new System.Exception("Get" + DVICE_TYPE + " Device Configuration Fail.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
                return false;
            }
            StatusBar_IO = "Starting to remote...";//this.StatusBar_IO.Text = "Starting to remote...";
            //this.timer1.Interval = m_ScanTime_LocalSys;// 1000 or 100
            //this.tabControl1.Enabled = true;
            //this.tabControl1.Visible = true;
            //InitialDataTabPages();
            ////this.Text = (APAX_INFO_NAME + DVICE_TYPE);
            //m_iScanCount = 0;
            //this.tabControl1.SelectedIndex = 0;
            return true;
        }

        /// <summary>
        /// APAX I/O module information init function
        /// </summary>
        /// <returns></returns>
        public static bool RefreshConfiguration()
        {


            if (m_adamSocket.Configuration().GetModuleConfig(m_idxID, out m_aConf))
            {

                txtModule = m_aConf.GetModuleName();//txtModule.Text = m_aConf.GetModuleName();       //Information-> Module
                txtID = m_idxID.ToString();//txtID.Text = m_idxID.ToString();                //Information -> Switch ID
                txtSupportKernelFw = m_aConf.wSupportFwVer.ToString("X04").Insert(2, ".");//txtSupportKernelFw.Text = m_aConf.wSupportFwVer.ToString("X04").Insert(2, ".");     //Information -> Support kernel Fw
                txtFwVer = m_aConf.wFwVerNo.ToString("X04").Insert(2, ".");//txtFwVer.Text = m_aConf.wFwVerNo.ToString("X04").Insert(2, ".");                    //Firmware version
                txtAIOFwVer = m_aConf.wHwVer.ToString("X04").Insert(2, ".");//txtAIOFwVer.Text = m_aConf.wHwVer.ToString("X04").Insert(2, ".");   //AIO Firmware version
                RefreshModbusAddressSetting();

            }
            else
            {
                StatusBar_IO = " GetModuleConfig(Error:" + m_adamSocket.Configuration().LastError.ToString() + ") Failed! ";//StatusBar_IO.Text = " GetModuleConfig(Error:" + m_adamSocket.Configuration().LastError.ToString() + ") Failed! ";
                return false;
            }
            return true;
        }

        public static void RefreshModbusAddressSetting()
        {
            bool bFixed;

            m_adamSocket.Configuration().GetModbusAddressMode(out bFixed);
            if (bFixed)
            {
                if (m_aConf.wDevType == (ushort)_DeviceType.DigitalInput || m_aConf.wDevType == (ushort)_DeviceType.DigitalOutput)
                {
                    m_usStart = Convert.ToUInt16(64 * m_idxID + 1); //64(Coils, bit) is Slot shift, please reference Modbus/TCP address mapping table(0x)
                    m_usLength = m_aConf.byChTotal;
                }
                else if (m_aConf.wDevType == (ushort)_DeviceType.AnalogInput || m_aConf.wDevType == (ushort)_DeviceType.AnalogOutput)
                {
                    m_usStart = Convert.ToUInt16(32 * m_idxID + 40001); //32(Registers, 2 bytes) is Slot shift, please reference Modbus/TCP address mapping table(4x)
                    m_usLength = m_aConf.byChTotal;
                }
                else if (m_aConf.wDevType == (ushort)_DeviceType.Counter || m_aConf.wDevType == (ushort)_DeviceType.PWM)
                {
                    m_usStart = Convert.ToUInt16(32 * m_idxID + 40001);
                    m_usLength = Convert.ToUInt16(m_aConf.byHwIoTotal_2 * 2 + 1); //per counter channel use 2 Registers(= 4 bytes)
                }
            }
            else
            {
                int o_iStartAddr, o_iLength;
                if (m_adamSocket.Configuration().GetModbusAddressConfig(m_idxID, out o_iStartAddr, out o_iLength))
                {
                    m_usStart = Convert.ToUInt16(o_iStartAddr);
                    m_usLength = Convert.ToUInt16(o_iLength);
                }
            }
        }

        /// <summary>
        /// Init Channel Information
        /// </summary>
        /// <param name="m_aConf">apax 5000 device object</param>
        public static void InitialDataTabPages()
        {
            int i = 0, idx = 0;
            byte type = (byte)_HardwareIOType.AI;   //APAX-5017H is AI module
            ListViewItem lvItem;
            string[] strRanges;
            ushort[] m_usRanges_supAI;

            for (i = 0; i < m_aConf.HwIoType.Length; i++)
            {
                if (m_aConf.HwIoType[i] == type)
                    idx = i;
            }
            m_tmpidx = idx;

            //init range combobox
            if (m_tmpidx == 0)
            {
                m_adamSocket.Configuration().GetModuleTotalRange((int)m_idxID, m_aConf, 0);
                m_usRanges_supAI = m_aConf.wHwIoType_0_Range;
            }
            else if (m_tmpidx == 1)
            {
                m_adamSocket.Configuration().GetModuleTotalRange((int)m_idxID, m_aConf, 1);
                m_usRanges_supAI = m_aConf.wHwIoType_1_Range;
            }
            else if (m_tmpidx == 2)
            {
                m_adamSocket.Configuration().GetModuleTotalRange((int)m_idxID, m_aConf, 2);
                m_usRanges_supAI = m_aConf.wHwIoType_2_Range;
            }
            else if (m_tmpidx == 3)
            {
                m_adamSocket.Configuration().GetModuleTotalRange((int)m_idxID, m_aConf, 3);
                m_usRanges_supAI = m_aConf.wHwIoType_3_Range;
            }
            else
            {
                m_adamSocket.Configuration().GetModuleTotalRange((int)m_idxID, m_aConf, 4);
                m_usRanges_supAI = m_aConf.wHwIoType_4_Range;
            }
            //Get combobox items of Range
            strRanges = new string[m_aConf.HwIoType_TotalRange[m_tmpidx]];
            for (i = 0; i < strRanges.Length; i++)
            {
                strRanges[i] = AnalogInput.GetRangeName(m_usRanges_supAI[i]);
            }
            // ***** // SetRangeComboBox(strRanges);
            //Get combobox items of Burnout Detect Mode
            // ***** // SetBurnoutFcnValueComboBox(new string[] { "Down Scale", "Up Scale" });
            //Get combobox items of Sampling rate (Hz/Ch)
            // ***** // SetSampleRateComboBox(new string[] { "100", "1000" });

            //init channel information
            // ***** // listViewChInfo.BeginUpdate();
            // ***** // listViewChInfo.Items.Clear();
            //for (i = 0; i < m_aConf.HwIoTotal[m_tmpidx]; i++)
            //{
            //    lvItem = new ListViewItem(_HardwareIOType.AI.ToString());   //type
            //    lvItem.SubItems.Add(i.ToString());      //Ch
            //    lvItem.SubItems.Add(Convert.ToString(m_usStart + i));     //Modbus address
            //    lvItem.SubItems.Add("*****");           //Value
            //    lvItem.SubItems.Add("*****");           //Ch Status 
            //    lvItem.SubItems.Add("*****");           //Range
            //    listViewChInfo.Items.Add(lvItem);
            //}
            //listViewChInfo.EndUpdate();
        }

        ///// <summary>
        ///// Get Range combobox string
        ///// </summary>
        ///// <param name="strRanges"></param>
        //public void SetRangeComboBox(string[] strRanges)
        //{
        //    cbxRange.BeginUpdate();
        //    cbxRange.Items.Clear();
        //    for (int i = 0; i < strRanges.Length; i++)
        //        cbxRange.Items.Add(strRanges[i]);

        //    if (cbxRange.Items.Count > 0)
        //        cbxRange.SelectedIndex = 0;
        //    cbxRange.EndUpdate();
        //}

        ///// <summary>
        ///// Get Burnout detect mode value combobox string
        ///// </summary>
        ///// <param name="strRanges"></param>
        //public void SetBurnoutFcnValueComboBox(string[] strRanges)
        //{
        //    cbxBurnoutValue.BeginUpdate();
        //    cbxBurnoutValue.Items.Clear();
        //    for (int i = 0; i < strRanges.Length; i++)
        //        cbxBurnoutValue.Items.Add(strRanges[i]);

        //    if (cbxBurnoutValue.Items.Count > 0)
        //        cbxBurnoutValue.SelectedIndex = 0;
        //    cbxBurnoutValue.EndUpdate();
        //}

        ///// <summary>
        ///// Get Sampling rate value combobox string
        ///// </summary>
        ///// <param name="strSampleRate"></param>
        //public void SetSampleRateComboBox(string[] strSampleRate)
        //{
        //    cbxSampleRate.BeginUpdate();
        //    cbxSampleRate.Items.Clear();
        //    for (int i = 0; i < strSampleRate.Length; i++)
        //        cbxSampleRate.Items.Add(strSampleRate[i]);

        //    if (cbxSampleRate.Items.Count > 0)
        //        cbxSampleRate.SelectedIndex = 0;
        //    cbxSampleRate.EndUpdate();
        //}



        /// <summary>
        /// Refresh AI Channel Information
        /// </summary>
        /// <returns></returns>
        public static bool RefreshData(ref double[] AIVals)
        {
            int iChannelTotal = m_aConf.HwIoTotal[m_tmpidx];

            if (m_uiChMask != 0x00)
            {
                ushort[] usVal;
                Advantech.Adam.Apax5000_ChannelStatus[] aStatus;

                if (!m_adamSocket.AnalogInput().GetChannelStatus(m_idxID, iChannelTotal, out aStatus))
                {
                    StatusBar_IO += "[GetChannelStatus] ApiErr:" + m_adamSocket.Modbus().LastError.ToString() + " ";//StatusBar_IO.Text += "[GetChannelStatus] ApiErr:" + m_adamSocket.Modbus().LastError.ToString() + " ";
                    return false;
                }
                if (!m_adamSocket.AnalogInput().GetValues(m_idxID, iChannelTotal, out usVal))
                {
                    StatusBar_IO += "[GetValues] ApiErr:" + m_adamSocket.Modbus().LastError.ToString() + " ";//StatusBar_IO.Text += "[GetValues] ApiErr:" + m_adamSocket.Modbus().LastError.ToString() + " ";
                    return false;
                }

                string[] strVal = new string[iChannelTotal];
                string[] strStatus = new string[iChannelTotal];
                double[] dVals = new double[iChannelTotal];

                for (int i = 0; i < iChannelTotal; i++)
                {
                    if (m_aConf.wPktVer >= 0x0002)
                        dVals[i] = AnalogInput.GetScaledValueWithResolution(m_usRanges[i], usVal[i], m_aConf.wHwIoType_0_Resolution);
                    else
                    {
                        if (m_aConf.GetModuleName() == "5017H")
                            dVals[i] = AnalogInput.GetScaledValueWithResolution(m_usRanges[i], usVal[i], 12);
                        else
                            dVals[i] = AnalogInput.GetScaledValue(m_usRanges[i], usVal[i]);
                    }
                    //AIVals[i] = dVals[i];

                    if (m_bChMask[i])
                    {
                        if (IsShowRawData)
                            strVal[i] = usVal[i].ToString("X04");
                        else
                            strVal[i] = dVals[i].ToString(AnalogInput.GetFloatFormat(m_usRanges[i]));
                        strStatus[i] = aStatus[i].ToString();
                    }
                    else
                    {
                        strVal[i] = "*****";
                        strStatus[i] = "Disable";
                    }
                    //listViewChInfo.Items[i].SubItems[3].Text = strVal[i].ToString();  //moduify "Value" column
                    //listViewChInfo.Items[i].SubItems[4].Text = strStatus[i].ToString();   //modify "Ch Status" column
                }
                dVals.CopyTo(AIVals, 0);
            }
            else
            {
                for (int i = 0; i < iChannelTotal; i++)
                {
                    //listViewChInfo.Items[i].SubItems[3].Text = "******";        //moduify "Value" column
                    //listViewChInfo.Items[i].SubItems[4].Text = "******";        //modify "Ch Status" column
                }
            }
            return true;
        }


        /// <summary>
        /// Refresh AI Channel Information
        /// </summary>
        /// <returns></returns>
        public static bool RefreshData(ref string[] strAIVals)
        {
            int iChannelTotal = m_aConf.HwIoTotal[m_tmpidx];

            if (m_uiChMask != 0x00)
            {
                ushort[] usVal;
                Advantech.Adam.Apax5000_ChannelStatus[] aStatus;

                if (!m_adamSocket.AnalogInput().GetChannelStatus(m_idxID, iChannelTotal, out aStatus))
                {
                    StatusBar_IO += "[GetChannelStatus] ApiErr:" + m_adamSocket.Modbus().LastError.ToString() + " ";//StatusBar_IO.Text += "[GetChannelStatus] ApiErr:" + m_adamSocket.Modbus().LastError.ToString() + " ";
                    return false;
                }
                if (!m_adamSocket.AnalogInput().GetValues(m_idxID, iChannelTotal, out usVal))
                {
                    StatusBar_IO += "[GetValues] ApiErr:" + m_adamSocket.Modbus().LastError.ToString() + " ";//StatusBar_IO.Text += "[GetValues] ApiErr:" + m_adamSocket.Modbus().LastError.ToString() + " ";
                    return false;
                }

                string[] strVal = new string[iChannelTotal];
                string[] strStatus = new string[iChannelTotal];
                double[] dVals = new double[iChannelTotal];

                for (int i = 0; i < iChannelTotal; i++)
                {
                    if (m_aConf.wPktVer >= 0x0002)
                        dVals[i] = AnalogInput.GetScaledValueWithResolution(m_usRanges[i], usVal[i], m_aConf.wHwIoType_0_Resolution);
                    else
                    {
                        if (m_aConf.GetModuleName() == "5017H")
                            dVals[i] = AnalogInput.GetScaledValueWithResolution(m_usRanges[i], usVal[i], 12);
                        else
                            dVals[i] = AnalogInput.GetScaledValue(m_usRanges[i], usVal[i]);
                    }
                    //AIVals[i] = dVals[i];

                    if (m_bChMask[i])
                    {
                        if (IsShowRawData)
                            strVal[i] = usVal[i].ToString("X04");
                        else
                            strVal[i] = dVals[i].ToString(AnalogInput.GetFloatFormat(m_usRanges[i]));
                        strStatus[i] = aStatus[i].ToString();
                    }
                    else
                    {
                        strVal[i] = "*****";
                        strStatus[i] = "Disable";
                    }
                    //listViewChInfo.Items[i].SubItems[3].Text = strVal[i].ToString();  //moduify "Value" column
                    //listViewChInfo.Items[i].SubItems[4].Text = strStatus[i].ToString();   //modify "Ch Status" column
                }
                strVal.CopyTo(strAIVals, 0);
            }
            else
            {
                for (int i = 0; i < iChannelTotal; i++)
                {
                    //listViewChInfo.Items[i].SubItems[3].Text = "******";        //moduify "Value" column
                    //listViewChInfo.Items[i].SubItems[4].Text = "******";        //modify "Ch Status" column
                }
            }
            return true;
        }

        public static bool IsShowRawData
        {
            get
            {
                return chbxShowRawData;//return chbxShowRawData.Checked;
            }
        }

        /// <summary>
        /// When change tab, refresh status, timer, counter related informations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void tabControl1_SelectedIndexChanged()
        {
            string strSelPageName = "AI";//string strSelPageName = tabControl1.TabPages[tabControl1.SelectedIndex].Text;
            StatusBar_IO = "";//StatusBar_IO.Text = "";
            m_adamSocket.Disconnect();
            m_adamSocket.Connect(m_adamSocket.GetIP(), ProtocolType.Tcp, 502);
            m_adamSocket.GetDSPFWVer(ref Avantech.m_sDSPFWVer);
            if (strSelPageName == "Module Information")
            {
                m_iFailCount = 0;
                m_iScanCount = 0;
            }
            else if (strSelPageName == "AI")
            {
                RefreshRanges();
                RefreshAiSetting();
                if (m_aConf.GetModuleName() == "5017H")
                    RefreshBurnoutSetting(true, true);
                if (m_aConf.GetModuleName() == "5017")
                    RefreshBurnoutSetting(false, true);

                RefreshAiSampleRate();
                //timer1.Enabled = true;
            }

            //if (tabControl1.SelectedIndex == 0)
            //    timer1.Enabled = false;
            //else
            //{
            //    if (listViewChInfo.SelectedIndices.Count == 0)
            //        listViewChInfo.Items[0].Selected = true;

            //    timer1.Enabled = true;
            //}
        }
        //************************** End of AI module(APAX-5017H) **************************//
    }
}
