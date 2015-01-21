using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using Advantech.Adam;
using Apax_IO_Module_Library;


namespace CxTitan
{
    public static class AvantechAOs
    {
        //************************** AO module(APAX-5028) **************************//
        // Global object
        public const string APAX_INFO_NAME = "APAX";
        public const string DVICE_TYPE = "5028";

        public static AdamSocket m_adamSocket;
        public static int[] m_iTimeout;
        public static string m_szIP = "";

        public static Apax5000Config m_aConf;
        public static int m_idxID;
        public static int m_ScanTime_LocalSys;
        public static int m_iFailCount, m_iScanCount;
        public static int m_tmpidx;
        public static ushort[] m_usRanges_supAO;
        public static ushort[] m_usRanges, m_usStartupAO, m_usAOSafetyVals;
        public static bool m_bIsEnableSafetyFcn;
        public static string[] m_szSlots;// Container of all solt device type

        public static bool m_bStartFlag = false;
        public static float m_fHigh;
        public static float m_fLow;
        public static bool b_AOValueModified;
        public static int m_iSelChannels;
        public static ushort m_usStart;
        public static ushort m_usLength;
        public static string StatusBar_IO = "";

        // Some Text Information
        public static string txtModule;       //Information-> Module
        public static string txtID;                //Information -> Switch ID
        public static string txtSupportKernelFw;     //Information -> Support kernel Fw
        public static string txtFwVer;                    //Firmware version

        public static string txtlabHigh;
        public static string txtlabLow;
        public static string txtOutputVal;
        public static int tBarOutputVal;

        public static float[] m_fHighVals;
        public static float[] m_fLowVals;
        public static float[] m_fOutputVals;
        public static bool[] m_bAOItemSelected;// 8 items
        public static bool[] m_bAOValueModified;// 8 items
        // Some Text Information

        public static bool chbxShowRawData = false;// indicate whether show raw data

        public static void Initialize()
        {
            m_szSlots = null;
            m_iScanCount = 0;
            m_iFailCount = 0;
            m_idxID = -1; // Set in invalid num 
            m_ScanTime_LocalSys = 500;// Scan time default 500 ms
            //timer1.Interval = m_ScanTime_LocalSys;
            b_AOValueModified = false;
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
            m_ScanTime_LocalSys = ScanTime;// Scan time
            b_AOValueModified = false;
            //timer1.Interval = m_ScanTime_LocalSys;
            m_iTimeout = new int[3];
            m_iTimeout[0] = 2000;// Connection Timeout    
            m_iTimeout[1] = 2000;// Send Timeout
            m_iTimeout[2] = 2000;// Receive Timeout
            m_szIP = IP;

            //this.StatusBar_IO.Text = ("Start to demo "
            //            + (APAX_INFO_NAME + ("-"
            //            + (DVICE_TYPE + " by clicking \'Start\' button."))));
            m_fHighVals = new float[8];// 8 high analog output values m_aConf.HwIoTotal[m_tmpidx]
            m_fLowVals = new float[8];// 8 low analog output values
            m_fOutputVals = new float[8];// 8 preset analog output values
            m_bAOItemSelected = new bool[8];// 8 analog output items selections
            m_bAOValueModified = new bool[8];// 8 analog output value modifications
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
                Avantech.AOEnabled = false;//timer1.Enabled = false;

                m_adamSocket.Configuration().SYS_SetLocateModule(m_idxID, 0);
                m_adamSocket.Disconnect();
                m_adamSocket = null;
            }
            return true;
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
            //this.timer1.Interval = m_ScanTime_LocalSys;
            //this.tabControl1.Enabled = true;
            //this.tabControl1.Visible = true;
            //InitialDataTabPages();
            //this.Text = (APAX_INFO_NAME + DVICE_TYPE);
            //m_iScanCount = 0;
            //this.tabControl1.SelectedIndex = 0;
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
                    if ((string.Compare(m_szSlots[iLoop], 0, DVICE_TYPE, 0, DVICE_TYPE.Length) == 0))
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
        /// APAX I/O module information init function
        /// </summary>
        /// <returns></returns>
        public static bool RefreshConfiguration()
        {


            if (m_adamSocket.Configuration().GetModuleConfig(m_idxID, out m_aConf))
            {

                txtModule = m_aConf.GetModuleName();//txtModule.Text = m_aConf.GetModuleName();       //Information-> Module
                txtID = m_idxID.ToString(); //txtID.Text = m_idxID.ToString();                //Information -> Switch ID
                txtSupportKernelFw = m_aConf.wSupportFwVer.ToString("X04").Insert(2, ".");//txtSupportKernelFw.Text = m_aConf.wSupportFwVer.ToString("X04").Insert(2, ".");     //Information -> Support kernel Fw
                txtFwVer = m_aConf.wFwVerNo.ToString("X04").Insert(2, ".");//txtFwVer.Text = m_aConf.wFwVerNo.ToString("X04").Insert(2, ".");                    //Firmware version
                RefreshModbusAddressSetting();
            }
            else
            {
                StatusBar_IO = " GetModuleConfig(Error:" + m_adamSocket.Configuration().LastError.ToString() + ") Failed! ";//StatusBar_IO.Text = " GetModuleConfig(Error:" + m_adamSocket.Configuration().LastError.ToString() + ") Failed! ";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Init Channel Information
        /// </summary>
        /// <param name="aConf">apax 5000 device object</param>
        public static void InitialDataTabPages()
        {
            int i = 0, idx = 0;
            byte type = (byte)_HardwareIOType.AO;   //APAX-5028 is AO module
            ListViewItem lvItem;
            string[] strRanges;

            for (i = 0; i < m_aConf.HwIoType.Length; i++)
            {
                if (m_aConf.HwIoType[i] == type)
                    idx = i;
            }
            m_tmpidx = idx;

            if (m_tmpidx == 0)
            {
                m_adamSocket.Configuration().GetModuleTotalRange((int)m_idxID, m_aConf, 0);
                m_usRanges_supAO = m_aConf.wHwIoType_0_Range;
            }
            else if (m_tmpidx == 1)
            {
                m_adamSocket.Configuration().GetModuleTotalRange((int)m_idxID, m_aConf, 1);
                m_usRanges_supAO = m_aConf.wHwIoType_1_Range;
            }
            else if (m_tmpidx == 2)
            {
                m_adamSocket.Configuration().GetModuleTotalRange((int)m_idxID, m_aConf, 2);
                m_usRanges_supAO = m_aConf.wHwIoType_2_Range;
            }
            else if (m_tmpidx == 3)
            {
                m_adamSocket.Configuration().GetModuleTotalRange((int)m_idxID, m_aConf, 3);
                m_usRanges_supAO = m_aConf.wHwIoType_3_Range;
            }
            else
            {
                m_adamSocket.Configuration().GetModuleTotalRange((int)m_idxID, m_aConf, 4);
                m_usRanges_supAO = m_aConf.wHwIoType_4_Range;
            }
            //init range combobox
            strRanges = new string[m_aConf.HwIoType_TotalRange[m_tmpidx]];
            for (i = 0; i < strRanges.Length; i++)
            {
                strRanges[i] = AnalogOutput.GetRangeName(m_usRanges_supAO[i]);
            }
            //SetRangeComboBox(strRanges);

            //listViewChInfo.BeginUpdate();
            //listViewChInfo.Items.Clear();
            //for (i = 0; i < m_aConf.HwIoTotal[m_tmpidx]; i++)
            //{
            //    lvItem = new ListViewItem(_HardwareIOType.AO.ToString());   //Type
            //    lvItem.SubItems.Add(i.ToString());  //Ch
            //    lvItem.SubItems.Add(Convert.ToString(m_usStart + i));   //Modbus address
            //    lvItem.SubItems.Add("*****");       //Value
            //    lvItem.SubItems.Add("*****");       //Range
            //    lvItem.SubItems.Add("*****");       //Start up
            //    lvItem.SubItems.Add("*****");       //Safety Value
            //    //listViewChInfo.Items.Add(lvItem);
            //}
            //listViewChInfo.EndUpdate();
        }

        //public static void SetRangeComboBox(string[] strRanges)
        //{
        //    cbxRange.BeginUpdate();
        //    cbxRange.Items.Clear();
        //    for (int i = 0; i < strRanges.Length; i++)
        //        cbxRange.Items.Add(strRanges[i]);

        //    if (cbxRange.Items.Count > 0)
        //        cbxRange.SelectedIndex = 0;
        //    cbxRange.EndUpdate();
        //}

        /// <summary>
        /// Refresh AI Channel Information
        /// </summary>
        /// <returns></returns>
        public static bool RefreshData(ref string[] strAOVals)
        {
            int iChannelTotal = m_aConf.HwIoTotal[m_tmpidx];
            ushort[] usVal;
            string[] strVal;
            //float fHigh = 0, fLow = 0;
            float[] fHighVals = new float[iChannelTotal];
            float[] fLowVals = new float[iChannelTotal];

            if (!m_adamSocket.AnalogOutput().GetValues(m_idxID, iChannelTotal, out usVal))
            {
                StatusBar_IO += "ApiErr:" + m_adamSocket.Modbus().LastError.ToString() + " ";//StatusBar_IO.Text += "ApiErr:" + m_adamSocket.Modbus().LastError.ToString() + " ";
                return false;
            }
            strVal = new string[usVal.Length];

            for (int i = 0; i < iChannelTotal; i++)
            {
                if (IsShowRawData)
                    strVal[i] = usVal[i].ToString("X04");
                else
                    strVal[i] = AnalogOutput.GetScaledValue(m_usRanges[i], usVal[i]).ToString(AnalogOutput.GetFloatFormat(m_usRanges[i]));
                strAOVals[i] = strVal[i].ToString();//listViewChInfo.Items[i].SubItems[3].Text = strVal[i].ToString();  //moduify "Value" column
            }


            ////Update tBarOutputVal
            //if (!b_AOValueModified)
            //{
            //    int idx = 0;
            //    //for (int i = 0; i < listViewChInfo.Items.Count; i++)
            //    //{
            //    //    if (listViewChInfo.Items[i].Selected)
            //    //        idx = i;
            //    //}
            //    AnalogOutput.GetRangeHighLow(m_usRanges[idx], out fHigh, out fLow);
            //    RefreshOutputPanel(fHigh, fLow, AnalogOutput.GetScaledValue(m_usRanges[idx], usVal[idx]));
            //}

            ////Update tBarOutputVal
            //for (int j = 0; j < iChannelTotal; j++)
            //{
            //    if (!m_bAOValueModified[j])
            //    {
            //        AnalogOutput.GetRangeHighLow(m_usRanges[j], out fHighVals[j], out fLowVals[j]);
            //        RefreshOutputPanel(fHighVals[j], fLowVals[j], AnalogOutput.GetScaledValue(m_usRanges[j], usVal[j]));
            //    }
            //}

            ////Update tBarOutputVal
            //for (int j = 0; j < iChannelTotal; j++)
            //{
            //    if (!m_bAOValueModified[j])
            //    {
            //        AnalogOutput.GetRangeHighLow(m_usRanges[j], out fHighVals[j], out fLowVals[j]);
            //        RefreshOutputPanel(fHighVals[j], fLowVals[j], AnalogOutput.GetScaledValue(m_usRanges[j], usVal[j]));
            //    }
            //}

            return true;
        }

        public static void tabControl1_SelectedIndexChanged()
        {
            string strSelPageName = "AO";//string strSelPageName = tabControl1.TabPages[tabControl1.SelectedIndex].Text;
            int idx;
            float fHigh = 0, fLow = 0, fVal = 0;
            ushort usVal;

            StatusBar_IO = "";//StatusBar_IO.Text = "";

            m_adamSocket.Disconnect();
            m_adamSocket.Connect(m_adamSocket.GetIP(), ProtocolType.Tcp, 502);

            if (strSelPageName == "Module Information")
            {
                m_iFailCount = 0;
                m_iScanCount = 0;
            }
            else if (strSelPageName == "AO")
            {
                RefreshRanges();
                RefreshAoStartupValues();
                RefreshSafetySetting();
                //chbxEnableSafety.Checked = m_bIsEnableSafetyFcn;
                //Set AO info



                //idx = 0;    //initial index
                //if (m_adamSocket.AnalogOutput().GetCurrentValue(m_idxID, idx, out usVal))
                //{
                //    AnalogOutput.GetRangeHighLow(m_usRanges[idx], out fHigh, out fLow);
                //    fVal = AnalogOutput.GetScaledValue(m_usRanges[idx], usVal);

                //    RefreshOutputPanel(fHigh, fLow, fVal);
                //}
                //else
                //    StatusBar_IO += "GetValues() filed!";//this.StatusBar_IO.Text += "GetValues() filed!";


                //// Get High, Low and Output Vals
                //int iChannelTotal = m_aConf.HwIoTotal[m_tmpidx];
                //for (idx = 0; idx < iChannelTotal; idx++)
                //{
                //    if (m_adamSocket.AnalogOutput().GetCurrentValue(m_idxID, idx, out usVal))// m_idxID is SlotNum(its the index ID of the 5 I/O modules)
                //    {
                //        AnalogOutput.GetRangeHighLow(m_usRanges[idx], out m_fHighVals[idx], out m_fLowVals[idx]);
                //        m_fOutputVals[idx] = AnalogOutput.GetScaledValue(m_usRanges[idx], usVal);
                //        //RefreshOutputPanel(m_fHighVal[idx], m_fLowVal[idx], m_fOutputVal[idx]);// use the High, Low and Output Vals to update UI correspondingly
                //    }
                //    else
                //        StatusBar_IO += "GetValues() filed!";//this.StatusBar_IO.Text += "GetValues() filed!";
                //}

                //synchronize channel status 
                //for (int i = 0; i < listViewChInfo.Items.Count; i++)
                //{
                //    if (i == idx)
                //        listViewChInfo.Items[i].Selected = true;
                //    else
                //        listViewChInfo.Items[i].Selected = false;
                //}
                //string szTemp = AnalogOutput.GetRangeName(m_usRanges[idx]);
                //for (int i = 0; i < cbxRange.Items.Count; i++)
                //{
                //    if (szTemp == cbxRange.Items[i].ToString())
                //    {
                //        cbxRange.SelectedIndex = i;
                //        break;
                //    }
                //}

            }
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
                    // Update Range column
                    //for (int i = 0; i < iChannelTotal; i++)
                    //    listViewChInfo.Items[i].SubItems[4].Text = AnalogOutput.GetRangeName(m_usRanges[i]).ToString();
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
        /// Refresh start up value
        /// </summary>
        /// <returns></returns>
        public static bool RefreshAoStartupValues()
        {
            try
            {
                string[] strVals;
                int iChannelTotal = m_aConf.HwIoTotal[m_tmpidx];

                if (m_adamSocket.AnalogOutput().GetStartupValues(m_idxID, iChannelTotal, out m_usStartupAO))
                {
                    strVals = new string[iChannelTotal];
                    for (int i = 0; i < m_usStartupAO.Length; i++)
                    {
                        strVals[i] = AnalogOutput.GetScaledValue(m_usRanges[i], m_usStartupAO[i]).ToString("0.000;-0.000");
                        //listViewChInfo.Items[i].SubItems[5].Text = strVals[i];
                    }
                }
                else
                    StatusBar_IO += "GetStartupValues() Failed! ";//StatusBar_IO.Text += "GetStartupValues() Failed! ";
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Refresh Modules's Safety column value
        /// </summary>
        public static void RefreshSafetySetting()
        {
            int iChannelTotal = m_aConf.HwIoTotal[m_tmpidx];
            if (!m_adamSocket.Configuration().OUT_GetSafetyEnable(m_idxID, out m_bIsEnableSafetyFcn))
            {
                StatusBar_IO += "OUT_GetSafetyEnable(Error:" + m_adamSocket.Modbus().LastError.ToString() + ") Failed! ";//StatusBar_IO.Text += "OUT_GetSafetyEnable(Error:" + m_adamSocket.Modbus().LastError.ToString() + ") Failed! ";
            }
            if (m_bIsEnableSafetyFcn)
            {
                ushort[] o_usValues;
                //string[] strSafetyValue;
                //string test;
                if (m_adamSocket.AnalogOutput().GetSafetyValues(m_idxID, iChannelTotal, out o_usValues))
                {
                    m_usAOSafetyVals = o_usValues;
                    //strSafetyValue = new string[iChannelTotal];
                    //for (int i = 0; i < iChannelTotal; i++)
                    //    listViewChInfo.Items[i].SubItems[6].Text = AnalogOutput.GetScaledValue(m_usRanges[i], m_usAOSafetyVals[i]).ToString("0.000;-0.000");  //moduify "Safety" column
                }
                else
                    StatusBar_IO += "GetSafetyValues(Error:" + m_adamSocket.Modbus().LastError.ToString() + ") Failed! ";//StatusBar_IO.Text += "GetSafetyValues(Error:" + m_adamSocket.Modbus().LastError.ToString() + ") Failed! ";
            }
            else
            {
                //for (int i = 0; i < iChannelTotal; i++)
                //    listViewChInfo.Items[i].SubItems[6].Text = "Disable";  //moduify "Safety" column
            }
        }

        /// <summary>
        /// Check module controllable
        /// </summary>
        /// <returns></returns>
        public static bool CheckControllable()
        {
            //Avantech.AOEnabled = false;// disable AO refresh
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
            //Avantech.AOEnabled = true;// enable AO refresh
            return false;
        }

        //private void listViewChInfo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int idx = 0;
        //    //Update txtSelChannel UI
        //    for (int i = 0; i < listViewChInfo.Items.Count; i++)
        //    {
        //        if (listViewChInfo.Items[i].Selected)
        //        {
        //            idx = i;
        //        }
        //    }
        //    txtSelChannel.Text = idx.ToString();
        //    m_iSelChannels = idx;
        //    b_AOValueModified = false;
        //}

        /// <summary>
        /// Set UI of txtOutputVal and tBarOutputVal
        /// </summary>
        /// <param name="fHigh"></param>
        /// <param name="fLow"></param>
        /// <param name="fOutputVal"></param>
        public static void RefreshOutputPanel(float fHigh, float fLow, float fOutputVal)
        {
            //m_fHigh = fHigh;
            //m_fLow = fLow;

            //txtlabHigh = m_fHigh.ToString();//labHigh.Text = m_fHigh.ToString();
            //txtlabLow= m_fLow.ToString();//labLow.Text = m_fLow.ToString();
            //txtOutputVal = fOutputVal.ToString("0.000");//txtOutputVal.Text = fOutputVal.ToString("0.000");
            //tBarOutputVal.Value = Convert.ToInt32(tBarOutputVal.Minimum + (tBarOutputVal.Maximum - tBarOutputVal.Minimum) * (fOutputVal - fLow) / (fHigh - fLow));//tBarOutputVal.Value = Convert.ToInt32(tBarOutputVal.Minimum + (tBarOutputVal.Maximum - tBarOutputVal.Minimum) * (fOutputVal - fLow) / (fHigh - fLow));



            m_fHigh = fHigh;
            m_fLow = fLow;

            txtlabHigh = m_fHigh.ToString();//labHigh.Text = m_fHigh.ToString();
            txtlabLow = m_fLow.ToString();//labLow.Text = m_fLow.ToString();
            txtOutputVal = fOutputVal.ToString("0.000");//txtOutputVal.Text = fOutputVal.ToString("0.000");
            //tBarOutputVal.Value = Convert.ToInt32(tBarOutputVal.Minimum + (tBarOutputVal.Maximum - tBarOutputVal.Minimum) * (fOutputVal - fLow) / (fHigh - fLow));//tBarOutputVal.Value = Convert.ToInt32(tBarOutputVal.Minimum + (tBarOutputVal.Maximum - tBarOutputVal.Minimum) * (fOutputVal - fLow) / (fHigh - fLow));
        }

        public static bool IsShowRawData
        {
            get
            {
                return chbxShowRawData;
            }
        }

        public static void btnApplyOutput_Click(object sender, EventArgs e)
        {
            b_AOValueModified = false;
            if (!CheckControllable())
                return;

            //timer1.Enabled = false;
            float fVal, fHigh, fLow;
            if (txtOutputVal.Length == 0)
            {
                MessageBox.Show("Illegal value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }

            try
            {
                //Get range higf & low
                AnalogOutput.GetRangeHighLow(m_usRanges[m_iSelChannels], out fHigh, out fLow);
                if (fHigh - fLow == 0)
                {
                    MessageBox.Show("GetRangeHighLow() failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    return;
                }
                //convert output value to float
                fVal = 0.0f;
                if (txtOutputVal != null && txtOutputVal.Length > 0)
                {
                    try
                    {
                        fVal = Convert.ToSingle(txtOutputVal);
                    }
                    catch
                    {
                        System.Windows.Forms.MessageBox.Show("Invalid value: " + txtOutputVal);
                    }
                }
                if (fVal > fHigh || fVal < fLow)
                {
                    MessageBox.Show("Illegal value! Please enter the value " + fLow.ToString() + " ~ " + fHigh.ToString() + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    return;
                }
                //Set channel value
                if (m_adamSocket.AnalogOutput().SetCurrentValue(m_idxID, m_iSelChannels, m_usRanges[m_iSelChannels], fVal))
                {
                    RefreshOutputPanel(fHigh, fLow, fVal);
                }
                else
                {
                    MessageBox.Show("Change current value failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            //RefreshData();
            MessageBox.Show("Set output value done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

            //timer1.Enabled = true;
        }

        //public static void btnApplySelRange_Click(object sender, EventArgs e)
        //{
        //    DialogResult result;
        //    if (!CheckControllable())
        //        return;
        //    //timer1.Enabled = false;

        //    result = MessageBox.Show("After changing range setting, you need to configure proper start-up value again!", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        //    if (result == DialogResult.Yes)
        //    {
        //        bool bRet = true;
        //        bool i_bApplyAll = chbxApplyAll.Checked;
        //        if (listViewChInfo.SelectedIndices.Count == 0 && !i_bApplyAll)
        //        {
        //            MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        //            bRet = false;
        //        }
        //        if (bRet)
        //        {
        //            ushort[] usRanges = new ushort[m_usRanges.Length];
        //            Array.Copy(m_usRanges, 0, usRanges, 0, m_usRanges.Length);
        //            if (i_bApplyAll)
        //            {
        //                for (int i = 0; i < usRanges.Length; i++)
        //                {
        //                    usRanges[i] = AnalogOutput.GetRangeCode2Byte(cbxRange.SelectedItem.ToString());
        //                }
        //            }
        //            else
        //            {
        //                for (int i = 0; i < listViewChInfo.SelectedIndices.Count; i++)
        //                {
        //                    usRanges[listViewChInfo.SelectedIndices[i]] = AnalogOutput.GetRangeCode2Byte(cbxRange.SelectedItem.ToString());
        //                }
        //            }
        //            int iChannelTotal = this.m_aConf.HwIoTotal[m_tmpidx];
        //            if (m_adamSocket.AnalogOutput().SetRanges(this.m_idxID, iChannelTotal, usRanges))
        //            {
        //                MessageBox.Show("Set ranges done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        //                RefreshRanges();
        //                RefreshAoStartupValues();
        //            }
        //            else
        //            {
        //                MessageBox.Show("Set ranges failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        //            }

        //        }

        //    }
        //    //timer1.Enabled = true;
        //}

        //private void tBarOutputVal_ValueChanged(object sender, EventArgs e)
        //{
        //    float fVal;
        //    fVal = (m_fHigh - m_fLow) * (tBarOutputVal.Value - tBarOutputVal.Minimum) / (tBarOutputVal.Maximum - tBarOutputVal.Minimum) + m_fLow;
        //    txtOutputVal.Text = fVal.ToString("0.000");
        //}

        public static void btnSetAsStartup_Click(object sender, EventArgs e)
        {
            if (!CheckControllable())
                return;
            float fVal, fHigh, fLow;

            //timer1.Enabled = false;
            if (txtOutputVal.Length == 0)
            {
                MessageBox.Show("Illegal value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }

            try
            {
                //Get range higf & low
                AnalogOutput.GetRangeHighLow(m_usRanges[m_iSelChannels], out fHigh, out fLow);
                if (fHigh - fLow == 0)
                {
                    MessageBox.Show("GetRangeHighLow() failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    return;
                }
                //convert output value to float
                fVal = 0.0f;
                if (txtOutputVal != null && txtOutputVal.Length > 0)
                {
                    try
                    {
                        fVal = Convert.ToSingle(txtOutputVal);
                    }
                    catch
                    {
                        System.Windows.Forms.MessageBox.Show("Invalid value: " + txtOutputVal);
                    }
                }
                if (fVal > fHigh || fVal < fLow)
                {
                    MessageBox.Show("Illegal value! Please enter the value " + fLow.ToString() + " ~ " + fHigh.ToString() + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    return;
                }
                ushort[] usStartupAO = new ushort[m_usStartupAO.Length];
                Array.Copy(m_usStartupAO, 0, usStartupAO, 0, m_usStartupAO.Length);
                usStartupAO[m_iSelChannels] = Convert.ToUInt16(65535.0f * ((fVal - fLow) / (fHigh - fLow)));
                if (m_adamSocket.AnalogOutput().SetStartupValues(m_idxID, usStartupAO))
                {
                    MessageBox.Show("Set AO startup values done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    RefreshAoStartupValues();
                }
                else
                {
                    MessageBox.Show("Set AO startup values failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }

            }
            catch
            {
                MessageBox.Show("Illegal value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;

            }

            //timer1.Enabled = true;
        }

        //public static void btnSetAsSafety_Click(object sender, EventArgs e)
        //{
        //    if (!CheckControllable())
        //        return;

        //    try
        //    {
        //        float fVal, fHigh, fLow;
        //        int iChannelTotal = m_aConf.HwIoTotal[m_tmpidx];
        //        //Get range higf & low
        //        AnalogOutput.GetRangeHighLow(m_usRanges[m_iSelChannels], out fHigh, out fLow);
        //        if (fHigh - fLow == 0)
        //        {
        //            MessageBox.Show("GetRangeHighLow() failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        //            return;
        //        }
        //        //convert output value to float
        //        fVal = 0.0f;
        //        if (txtOutputVal != null && txtOutputVal.Length > 0)
        //        {
        //            try
        //            {
        //                fVal = Convert.ToSingle(txtOutputVal);
        //            }
        //            catch
        //            {
        //                System.Windows.Forms.MessageBox.Show("Invalid value: " + txtOutputVal);
        //            }
        //        }
        //        ushort[] usAOSafetyVals = new ushort[m_usAOSafetyVals.Length];
        //        Array.Copy(m_usAOSafetyVals, 0, usAOSafetyVals, 0, m_usAOSafetyVals.Length);

        //        usAOSafetyVals[m_iSelChannels] = Convert.ToUInt16(65535.0f * ((fVal - fLow) / (fHigh - fLow)));

        //        if (!m_adamSocket.AnalogOutput().SetSafetyValues(m_idxID, iChannelTotal, usAOSafetyVals))
        //            MessageBox.Show("Set safety value failed! (Err: " + m_adamSocket.Modbus().LastError.ToString() + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);

        //        RefreshSafetySetting();

        //    }
        //    catch
        //    {
        //        return;
        //    }
        //    return;
        //}

        //public static void btnSetSafetyValue_Click(object sender, EventArgs e)
        //{
        //    if (!CheckControllable())
        //        return;

        //    //timer1.Enabled = false;
        //    int iChannelTotal = m_aConf.HwIoTotal[m_tmpidx];
        //    float[] fAOSafetyVals = new float[iChannelTotal];

        //    for (int i = 0; i < iChannelTotal; i++)
        //        fAOSafetyVals[i] = AnalogOutput.GetScaledValue(m_usRanges[i], m_usAOSafetyVals[i]);

        //    string[] szRanges = new string[iChannelTotal];

        //    for (int idx = 0; idx < szRanges.Length; idx++)
        //        szRanges[idx] = AnalogInput.GetRangeName(m_usRanges[idx]);

        //    FormSafetySetting formSafety = new FormSafetySetting(iChannelTotal, fAOSafetyVals, szRanges);
        //    formSafety.ApplySafetyValueClick += new FormSafetySetting.EventHandler_ApplySafetyValueClick(formSafety_ApplySafetyValueClick);

        //    formSafety.ShowDialog();
        //    formSafety.Dispose();
        //    formSafety = null;

        //    //timer1.Enabled = true;
        //}

        /// <summary>
        ///  Apply setting when user configure safety status
        /// </summary>
        /// <param name="bVal"></param>
        public static void formSafety_ApplySafetyValueClick(string[] szVal)
        {
            int iChannelTotal = m_aConf.HwIoTotal[m_tmpidx];
            float fVal, fHigh, fLow;
            ushort[] usAOSafetyVals = new ushort[m_usAOSafetyVals.Length];
            for (int i = 0; i < iChannelTotal; i++)
            {
                fVal = 0.0f;
                if (szVal[i] != null && szVal[i].Length > 0)
                {
                    try
                    {
                        fVal = Convert.ToSingle(szVal[i]);
                    }
                    catch
                    {
                        System.Windows.Forms.MessageBox.Show("Invalid value: " + szVal[i]);
                    }
                }

                AnalogOutput.GetRangeHighLow(m_usRanges[i], out fHigh, out fLow);

                if (fHigh - fLow == 0)
                {
                    MessageBox.Show("GetRangeHighLow() failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    return;
                }

                if (fVal > fHigh || fVal < fLow)
                {
                    MessageBox.Show("Channel " + i.ToString() + " is illegal value! Please enter the value " + fLow.ToString() + " ~ " + fHigh.ToString() + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    return;
                }

                usAOSafetyVals[i] = Convert.ToUInt16(65535.0f * ((fVal - fLow) / (fHigh - fLow)));
            }

            if (!m_adamSocket.AnalogOutput().SetSafetyValues(m_idxID, iChannelTotal, usAOSafetyVals))
                MessageBox.Show("Set safety value failed! (Err: " + m_adamSocket.Modbus().LastError.ToString() + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);

            RefreshSafetySetting();

        }

        //public static void btnLocate_Click(object sender, EventArgs e)
        //{
        //    if (btnLocate.Text == "Enable")
        //    {
        //        if (m_adamSocket.Configuration().SYS_SetLocateModule(m_idxID, 255))
        //            btnLocate.Text = "Disable";
        //        else
        //            MessageBox.Show("Locate module failed!", "Error");
        //    }
        //    else
        //    {
        //        if (m_adamSocket.Configuration().SYS_SetLocateModule(m_idxID, 0))
        //            btnLocate.Text = "Enable";
        //        else
        //            MessageBox.Show("Locate module failed!", "Error");
        //    }
        //}

        //private void txtOutputVal_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    b_AOValueModified = true;
        //}

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

        public static void Start()
        {
            string strbtnStatus = "Start";//string strbtnStatus = this.btnStart.Text;
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

        //private void Btn_Quit_Click(object sender, EventArgs e)
        //{
        //    Close();
        //}

        //private void tBarOutputVal_MouseDown(object sender, MouseEventArgs e)
        //{
        //    b_AOValueModified = true;
        //    txtOutputVal.SelectAll();
        //}

        //private void chbxHide_CheckedChanged(object sender, EventArgs e)
        //{
        //    panel1.Visible = !chbxHide.Checked;
        //}

        //private void txtOutputVal_MouseDown(object sender, MouseEventArgs e)
        //{
        //    b_AOValueModified = true;
        //}

        //private void chbxEnableSafety_CheckedChanged(object sender, EventArgs e)
        //{
        //    btnSetAsSafety.Enabled = chbxEnableSafety.Checked;
        //    btnSetSafetyValue.Enabled = chbxEnableSafety.Checked;
        //    if (!CheckControllable())
        //        return;

        //    if (!m_adamSocket.Configuration().OUT_SetSafetyEnable(m_idxID, chbxEnableSafety.Checked))
        //        MessageBox.Show("Set safety function failed! (Err: " + m_adamSocket.Modbus().LastError.ToString() + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);

        //    RefreshSafetySetting();
        //}

        //private void Form_APAX_5028_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    FreeResource();
        //}
        //************************** End of AO module(APAX-5028) **************************//
    }
}
