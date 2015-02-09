using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using APS_Define_W32;
using APS168_W32;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Threading;
using System.Data.SqlClient;
using System.Net.Sockets;
using Advantech.Adam;
using Apax_IO_Module_Library;


namespace CxTitan
{
    public partial class ConnectPage : Form
    {
        Label[] AI = new Label[12];
        Button[] DI = new Button[36];
        Button[] DO = new Button[36];
        Label[] AOHighVals = new Label[8];// AvantechAOs.m_aConf.HwIoTotal[AvantechAOs.m_tmpidx]
        Label[] AOLowVals = new Label[8];// AvantechAOs.m_aConf.HwIoTotal[AvantechAOs.m_tmpidx]
        Label[] AOOutputVals = new Label[8];// AvantechAOs.m_aConf.HwIoTotal[AvantechAOs.m_tmpidx]
        TextBox[] txtAOOutputVals = new TextBox[8];// AvantechAOs.m_aConf.HwIoTotal[AvantechAOs.m_tmpidx]
        TrackBar[] AOTrackBarVals = new TrackBar[8];// 8 AOs
        CheckBox[] AOChkRanges = new CheckBox[8];// 8 AO ranges
        CheckBox[] AIChkRanges = new CheckBox[12];// 12 AI ranges
        string IP = "10.0.0.1";// can be configured by AdamApax.NET Utility
        int DISlotNum = 1;// 5040 DI slot num = 1
        int DOSlotNum = 3;// 5046 DO slot num = 3
        int AOSlotNum = 5;// 5028 AO slot num = 5
        int AISlotNum = 7;// 5017H AI slot num = 7
        int DIOSlotNum = 9;// 5045 DI/O slot num = 9

        public ConnectPage()
        {  
            InitializeComponent();//constructor   
        }

        public delegate void SetTextCallback(string text, int pos);
	



	    public void ConnectPage_Activated(object sender, System.EventArgs e)
	    {
	    } // the above globals are MACHINE DEPENDENT. they go true or false depending on the PHYSICAL state of sensors and such. SO as there is no machine attached they are all false = red buttons

        private void DI5040_InterfaceRefresh()
        {
            txtDICntMin.Text = AvantechDIs.txtCntMin;
            chkBoxDIFilterEnable.Checked = AvantechDIs.chkBoxDiFilterEnable;
        }

        private void DO5046_InterfaceRefresh()
        {
            chbxDOEnableSafety.Checked = AvantechDOs.m_bIsEnableSafetyFcn;
            btnDOSetSafetyValue.Enabled = AvantechDOs.m_bIsEnableSafetyFcn;

            bool bDORet;
            int iDOChannelTotal = AvantechDOs.m_aConf.HwIoTotal[AvantechDOs.m_tmpidx];
            bool[] DOvalues = new bool[iDOChannelTotal];

            cmdNETWORK.BackColor = Color.Green;
            bDORet = AvantechDOs.RefreshData(ref DOvalues);
            lblDOErr.Invoke((MethodInvoker)delegate { lblDOErr.Text = bDORet ? "0" : "-1"; });//lblDOErr.Text = bDORet ? "0" : "-1";
            cmdNETWORK.BackColor = Color.Gray;
            if (bDORet)
            {
                for (int i = 0; i < iDOChannelTotal; i++)
                {
                    DO[i].BackColor = DOvalues[i] ? Color.Green : Color.Red;
                }
            }
            else
            {
                MessageBox.Show("Digital Output refresh first time failed!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }

        private void AO_InitialDataTabPages()
        {
            int i = 0, idx = 0;
            byte type = (byte)_HardwareIOType.AO;   //APAX-5028 is AO module
            ListViewItem lvItem;
            string[] strRanges;

            for (i = 0; i < AvantechAOs.m_aConf.HwIoType.Length; i++)
            {
                if (AvantechAOs.m_aConf.HwIoType[i] == type)
                    idx = i;
            }
            AvantechAOs.m_tmpidx = idx;

            if (AvantechAOs.m_tmpidx == 0)
            {
                AvantechAOs.m_adamSocket.Configuration().GetModuleTotalRange((int)AvantechAOs.m_idxID, AvantechAOs.m_aConf, 0);
                AvantechAOs.m_usRanges_supAO = AvantechAOs.m_aConf.wHwIoType_0_Range;
            }
            else if (AvantechAOs.m_tmpidx == 1)
            {
                AvantechAOs.m_adamSocket.Configuration().GetModuleTotalRange((int)AvantechAOs.m_idxID, AvantechAOs.m_aConf, 1);
                AvantechAOs.m_usRanges_supAO = AvantechAOs.m_aConf.wHwIoType_1_Range;
            }
            else if (AvantechAOs.m_tmpidx == 2)
            {
                AvantechAOs.m_adamSocket.Configuration().GetModuleTotalRange((int)AvantechAOs.m_idxID, AvantechAOs.m_aConf, 2);
                AvantechAOs.m_usRanges_supAO = AvantechAOs.m_aConf.wHwIoType_2_Range;
            }
            else if (AvantechAOs.m_tmpidx == 3)
            {
                AvantechAOs.m_adamSocket.Configuration().GetModuleTotalRange((int)AvantechAOs.m_idxID, AvantechAOs.m_aConf, 3);
                AvantechAOs.m_usRanges_supAO = AvantechAOs.m_aConf.wHwIoType_3_Range;
            }
            else
            {
                AvantechAOs.m_adamSocket.Configuration().GetModuleTotalRange((int)AvantechAOs.m_idxID, AvantechAOs.m_aConf, 4);
                AvantechAOs.m_usRanges_supAO = AvantechAOs.m_aConf.wHwIoType_4_Range;
            }
            //init range combobox
            strRanges = new string[AvantechAOs.m_aConf.HwIoType_TotalRange[AvantechAOs.m_tmpidx]];
            for (i = 0; i < strRanges.Length; i++)
            {
                strRanges[i] = AnalogOutput.GetRangeName(AvantechAOs.m_usRanges_supAO[i]);
            }
            SetAORangeComboBox(strRanges);

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
            //    listViewChInfo.Items.Add(lvItem);
            //}
            //listViewChInfo.EndUpdate();
        }

        public void SetAORangeComboBox(string[] strRanges)
        {
            cbxAORange.BeginUpdate();
            cbxAORange.Items.Clear();
            for (int i = 0; i < strRanges.Length; i++)
                cbxAORange.Items.Add(strRanges[i]);

            if (cbxAORange.Items.Count > 0)
                cbxAORange.SelectedIndex = 0;
            cbxAORange.EndUpdate();
        }

        private void AI_InitialDataTabPages()
        {
            int i = 0, idx = 0;
            byte type = (byte)_HardwareIOType.AI;   //APAX-5017H is AI module
            ListViewItem lvItem;
            string[] strRanges;
            ushort[] m_usRanges_supAI;

            for (i = 0; i < AvantechAIs.m_aConf.HwIoType.Length; i++)
            {
                if (AvantechAIs.m_aConf.HwIoType[i] == type)
                    idx = i;
            }
            AvantechAIs.m_tmpidx = idx;

            //init range combobox
            if (AvantechAIs.m_tmpidx == 0)
            {
                AvantechAIs.m_adamSocket.Configuration().GetModuleTotalRange((int)AvantechAIs.m_idxID, AvantechAIs.m_aConf, 0);
                m_usRanges_supAI = AvantechAIs.m_aConf.wHwIoType_0_Range;
            }
            else if (AvantechAIs.m_tmpidx == 1)
            {
                AvantechAIs.m_adamSocket.Configuration().GetModuleTotalRange((int)AvantechAIs.m_idxID, AvantechAIs.m_aConf, 1);
                m_usRanges_supAI = AvantechAIs.m_aConf.wHwIoType_1_Range;
            }
            else if (AvantechAIs.m_tmpidx == 2)
            {
                AvantechAIs.m_adamSocket.Configuration().GetModuleTotalRange((int)AvantechAIs.m_idxID, AvantechAIs.m_aConf, 2);
                m_usRanges_supAI = AvantechAIs.m_aConf.wHwIoType_2_Range;
            }
            else if (AvantechAIs.m_tmpidx == 3)
            {
                AvantechAIs.m_adamSocket.Configuration().GetModuleTotalRange((int)AvantechAIs.m_idxID, AvantechAIs.m_aConf, 3);
                m_usRanges_supAI = AvantechAIs.m_aConf.wHwIoType_3_Range;
            }
            else
            {
                AvantechAIs.m_adamSocket.Configuration().GetModuleTotalRange((int)AvantechAIs.m_idxID, AvantechAIs.m_aConf, 4);
                m_usRanges_supAI = AvantechAIs.m_aConf.wHwIoType_4_Range;
            }
            //Get combobox items of Range
            strRanges = new string[AvantechAIs.m_aConf.HwIoType_TotalRange[AvantechAIs.m_tmpidx]];
            for (i = 0; i < strRanges.Length; i++)
            {
                strRanges[i] = AnalogInput.GetRangeName(m_usRanges_supAI[i]);
            }
            SetAIRangeComboBox(strRanges);
            //Get combobox items of Burnout Detect Mode
            SetAIBurnoutFcnValueComboBox(new string[] { "Down Scale", "Up Scale" });
            //Get combobox items of Sampling rate (Hz/Ch)
            SetAISampleRateComboBox(new string[] { "100", "1000" });

            //init channel information
            //listViewChInfo.BeginUpdate();
            //listViewChInfo.Items.Clear();
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

        public void SetAIRangeComboBox(string[] strRanges)
        {
            cbxAIRange.BeginUpdate();
            cbxAIRange.Items.Clear();
            for (int i = 0; i < strRanges.Length; i++)
                cbxAIRange.Items.Add(strRanges[i]);

            if (cbxAIRange.Items.Count > 0)
                cbxAIRange.SelectedIndex = 0;
            cbxAIRange.EndUpdate();
        }

        public void SetAIBurnoutFcnValueComboBox(string[] strRanges)
        {
            cbxAIBurnoutValue.BeginUpdate();
            cbxAIBurnoutValue.Items.Clear();
            for (int i = 0; i < strRanges.Length; i++)
                cbxAIBurnoutValue.Items.Add(strRanges[i]);

            if (cbxAIBurnoutValue.Items.Count > 0)
                cbxAIBurnoutValue.SelectedIndex = 0;
            cbxAIBurnoutValue.EndUpdate();
        }

        public void SetAISampleRateComboBox(string[] strSampleRate)
        {
            cbxAISampleRate.BeginUpdate();
            cbxAISampleRate.Items.Clear();
            for (int i = 0; i < strSampleRate.Length; i++)
                cbxAISampleRate.Items.Add(strSampleRate[i]);

            if (cbxAISampleRate.Items.Count > 0)
                cbxAISampleRate.SelectedIndex = 0;
            cbxAISampleRate.EndUpdate();
        }

        private void AI5017H_InterfaceRefresh()
        {
            AI_InitialDataTabPages();
            AvantechAIs.m_iScanCount = 0;
        }

        private void AO5028_InterfaceRefresh()
        {
            // InitialDataTabPages
            AO_InitialDataTabPages();
            AvantechAOs.m_iScanCount = 0;


            string strSelPageName = "AO";//string strSelPageName = tabControl1.TabPages[tabControl1.SelectedIndex].Text;
            int idx = 0;
            int iAOChannelTotal = AvantechAOs.m_aConf.HwIoTotal[AvantechAOs.m_tmpidx];
            ushort usVal;

            AvantechAOs.StatusBar_IO = "";//StatusBar_IO.Text = "";

            AvantechAOs.m_adamSocket.Disconnect();
            AvantechAOs.m_adamSocket.Connect(AvantechAOs.m_adamSocket.GetIP(), ProtocolType.Tcp, 502);

            if (strSelPageName == "Module Information")
            {
                AvantechAOs.m_iFailCount = 0;
                AvantechAOs.m_iScanCount = 0;
            }
            else if (strSelPageName == "AO")
            {
                AvantechAOs.RefreshRanges();
                AvantechAOs.RefreshAoStartupValues();
                AvantechAOs.RefreshSafetySetting();
                chbxAOEnableSafety.Checked = AvantechAOs.m_bIsEnableSafetyFcn;


                for (idx = 0; idx < iAOChannelTotal; idx++)
                {
                    if (AvantechAOs.m_adamSocket.AnalogOutput().GetCurrentValue(AvantechAOs.m_idxID, idx, out usVal))// m_idxID is SlotNum(its the index ID of the 5 I/O modules)
                    {
                        AnalogOutput.GetRangeHighLow(AvantechAOs.m_usRanges[idx], out AvantechAOs.m_fHighVals[idx], out AvantechAOs.m_fLowVals[idx]);
                        AvantechAOs.m_fOutputVals[idx] = AnalogOutput.GetScaledValue(AvantechAOs.m_usRanges[idx], usVal);
                        //RefreshOutputPanel(m_fHighVal[idx], m_fLowVal[idx], m_fOutputVal[idx]);// use the High, Low and Output Vals to update UI correspondingly
                        RefreshAnalogOutputPanel(AvantechAOs.m_fHighVals[idx], AvantechAOs.m_fLowVals[idx],
                            AvantechAOs.m_fOutputVals[idx], idx);
                    }
                    else
                        AvantechAOs.StatusBar_IO += "GetValues() filed!";//this.StatusBar_IO.Text += "GetValues() filed!";
                }
            }
            //for (int idx = 0; idx < iAOChannelTotal; idx++)
            //{
            //    //RefreshOutputPanel(m_fHighVal[idx], m_fLowVal[idx], m_fOutputVal[idx]);// use the High, Low and Output Vals to update UI correspondingly
            //    RefreshAnalogOutputPanel(AvantechAOs.m_fHighVals[idx], AvantechAOs.m_fLowVals[idx],
            //        AvantechAOs.m_fOutputVals[idx], idx);
            //}
        }

        private void AO5028_InterfaceInitialize()
        {
            int iAOChannelTotal = AvantechAOs.m_aConf.HwIoTotal[AvantechAOs.m_tmpidx];
            for (int i = 0; i < iAOChannelTotal; i++)
            {
                AOHighVals[i].Text = AvantechAOs.m_fHighVals[i].ToString();
                AOLowVals[i].Text = AvantechAOs.m_fLowVals[i].ToString();
                AOOutputVals[i].Text = AvantechAOs.m_fOutputVals[i].ToString();
                AOTrackBarVals[i].Value = Convert.ToInt32(AOTrackBarVals[i].Minimum + (AOTrackBarVals[i].Maximum - AOTrackBarVals[i].Minimum) * (AvantechAOs.m_fOutputVals[i] - AvantechAOs.m_fLowVals[i]) / (AvantechAOs.m_fHighVals[i] - AvantechAOs.m_fLowVals[i]));
            }
        }

        private void DIO5045_InterfaceRefresh()
        {
            // DIO DI's UI interface update
            txtDIO_DICntMin.Text = AvantechDIOs.txtCntMin;
            chkBoxDIO_DIFilterEnable.Checked = AvantechDIOs.chkBoxDiFilterEnable;

            // DIO DO's EnableSafety and SetSafetyValue interface update
            chbxDIO_DOEnableSafety.Checked = AvantechDIOs.m_bIsEnableSafetyFcn;
            btnDIO_DOSetSafetyValue.Enabled = AvantechDIOs.m_bIsEnableSafetyFcn;

            int i = 0;
            // DI total
            int iDIChannelTotal = AvantechDIs.m_aConf.HwIoTotal[AvantechDIs.m_tmpidx];
            // DO total
            int iDOChannelTotal = AvantechDOs.m_aConf.HwIoTotal[AvantechDOs.m_tmpidx];
            // DIO's DI Channel
            bool bDIORet;
            int iDIO_DIChannelTotal = AvantechDIOs.m_aConf.HwIoTotal[AvantechDIOs.m_DIidx];
            bool[] DIO_DIvalues = new bool[iDIO_DIChannelTotal];
            // DIO's DO Channel
            int iDIO_DOChannelTotal = AvantechDIOs.m_aConf.HwIoTotal[AvantechDIOs.m_DOidx];
            bool[] DIO_DOvalues = new bool[iDIO_DOChannelTotal];
            cmdNETWORK.BackColor = Color.Green;
            bDIORet = AvantechDIOs.RefreshData(ref DIO_DIvalues, ref DIO_DOvalues);
            lblDIOErr.Invoke((MethodInvoker)delegate { lblDIOErr.Text = bDIORet ? "0" : "-1"; });//lblDIOErr.Text = bDIORet ? "0" : "-1";
            cmdNETWORK.BackColor = Color.Gray;
            if (bDIORet)
            {
                AvantechDIOs.m_iScanCount++;
                AvantechDIOs.m_iFailCount = 0;
                for (i = iDIChannelTotal; i < iDIChannelTotal + iDIO_DIChannelTotal; i++)
                {
                    DI[i].BackColor = DIO_DIvalues[i - iDIChannelTotal] ? Color.Green : Color.Red;
                }
                for (i = iDOChannelTotal; i < iDOChannelTotal + iDIO_DOChannelTotal; i++)
                {
                    DO[i].BackColor = DIO_DOvalues[i - iDOChannelTotal] ? Color.Green : Color.Red;
                }
            }
            else
            {
                MessageBox.Show("Digital Input/Output refresh first time failed!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }

        private void AvantechSystemInitialize()
        {
            //// Avantech System and ScanTime initialize
            //TreeNode treeNode = new TreeNode(IP);
            //Avantech.ScanTimeInitialize();
            //Avantech.SetIPAddress(IP);
            //Avantech.AfterSelect_CouplerDevice(treeNode);

            // Avantech System and ScanTime initialize
            TreeNode treeNode = new TreeNode(SystemGlobals.IP);
            Avantech.ScanTimeInitialize();
            Avantech.SetIPAddress(SystemGlobals.IP);
            Avantech.AfterSelect_CouplerDevice(treeNode);
        }

        private void AvantechIO_Modules_Initialize()
        {
            //// 5040 DI initialize(1)
            //AvantechDIs.Initialize(IP, DISlotNum, Avantech.m_ScanTime_LocalSys[0]);
            //AvantechDIs.Start();
            //AvantechDIs.tabControl1_SelectedIndexChanged();
            //bool bDIRet;
            //int iDIChannelTotal = AvantechDIs.m_aConf.HwIoTotal[AvantechDIs.m_tmpidx];
            //bool[] DIvalues = new bool[iDIChannelTotal];
            //DI5040_InterfaceRefresh();


            //// 5046 DO initialize(3)
            //AvantechDOs.Initialize(IP, DOSlotNum, Avantech.m_ScanTime_LocalSys[0]);
            //AvantechDOs.Start();
            //AvantechDOs.tabControl1_SelectedIndexChanged();
            //// DO start to refresh one time to get the latest DO values
            //DO5046_InterfaceRefresh();


            //// 5028 AO initialize(5)
            //AvantechAOs.Initialize(IP, AOSlotNum, Avantech.m_ScanTime_LocalSys[0]);
            //AvantechAOs.Start();
            ////AvantechAOs.tabControl1_SelectedIndexChanged();// Get High values, Low values and current Output values from AO module
            //AO5028_InterfaceRefresh();// Get High values, Low values and current Output values from AO module and Update UI correspondingly
            ////AO5028_InterfaceInitialize();// Use these High values, Low values and current Output values to update UI 


            //// 5017H AI initialize(7)
            //AvantechAIs.Initialize(IP, AISlotNum, Avantech.m_ScanTime_LocalSys[0]);
            //AvantechAIs.Start();
            //AvantechAIs.tabControl1_SelectedIndexChanged();
            //AI5017H_InterfaceRefresh();


            //// 5045 DI/O initialize(9)
            //AvantechDIOs.Initialize(IP, DIOSlotNum, Avantech.m_ScanTime_LocalSys[0]);
            //AvantechDIOs.Start();
            //AvantechDIOs.tabControl1_SelectedIndexChanged_DI();
            //AvantechDIOs.tabControl1_SelectedIndexChanged_DO();
            //// DIO start to refresh one time to get the latest DIO values
            //DIO5045_InterfaceRefresh();



            // 5040 DI initialize(1)
            AvantechDIs.Initialize(SystemGlobals.IP, SystemGlobals.DISlotNum, Avantech.m_ScanTime_LocalSys[0]);
            AvantechDIs.Start();
            AvantechDIs.tabControl1_SelectedIndexChanged();
            bool bDIRet;
            int iDIChannelTotal = AvantechDIs.m_aConf.HwIoTotal[AvantechDIs.m_tmpidx];
            bool[] DIvalues = new bool[iDIChannelTotal];
            DI5040_InterfaceRefresh();


            // 5046 DO initialize(3)
            AvantechDOs.Initialize(SystemGlobals.IP, SystemGlobals.DOSlotNum, Avantech.m_ScanTime_LocalSys[0]);
            AvantechDOs.Start();
            AvantechDOs.tabControl1_SelectedIndexChanged();
            // DO start to refresh one time to get the latest DO values
            DO5046_InterfaceRefresh();


            // 5028 AO initialize(5)
            AvantechAOs.Initialize(SystemGlobals.IP, SystemGlobals.AOSlotNum, Avantech.m_ScanTime_LocalSys[0]);
            AvantechAOs.Start();
            //AvantechAOs.tabControl1_SelectedIndexChanged();// Get High values, Low values and current Output values from AO module
            AO5028_InterfaceRefresh();// Get High values, Low values and current Output values from AO module and Update UI correspondingly
            //AO5028_InterfaceInitialize();// Use these High values, Low values and current Output values to update UI 


            // 5017H AI initialize(7)
            AvantechAIs.Initialize(SystemGlobals.IP, SystemGlobals.AISlotNum, Avantech.m_ScanTime_LocalSys[0]);
            AvantechAIs.Start();
            AvantechAIs.tabControl1_SelectedIndexChanged();
            AI5017H_InterfaceRefresh();


            // 5045 DI/O initialize(9)
            AvantechDIOs.Initialize(SystemGlobals.IP, SystemGlobals.DIOSlotNum, Avantech.m_ScanTime_LocalSys[0]);
            AvantechDIOs.Start();
            AvantechDIOs.tabControl1_SelectedIndexChanged_DI();
            AvantechDIOs.tabControl1_SelectedIndexChanged_DO();
            // DIO start to refresh one time to get the latest DIO values
            DIO5045_InterfaceRefresh();
        }

        private void IO_UI_Arrays_Assign()
        {
            //Assign the AI Array
            AI[0] = lblAI_0;
            AI[1] = lblAI_1;
            AI[2] = lblAI_2;
            AI[3] = lblAI_3;
            AI[4] = lblAI_4;
            AI[5] = lblAI_5;
            AI[6] = lblAI_6;
            AI[7] = lblAI_7;
            AI[8] = lblAI_8;
            AI[9] = lblAI_9;
            AI[10] = lblAI_10;
            AI[11] = lblAI_11;

            //Assign the DI Array(0-23: 5040 DI, 24-35: 5045 DI)
            DI[0] = DI_0;
            DI[1] = DI_1;
            DI[2] = DI_2;
            DI[3] = DI_3;
            DI[4] = DI_4;
            DI[5] = DI_5;
            DI[6] = DI_6;
            DI[7] = DI_7;
            DI[8] = DI_8;
            DI[9] = DI_9;
            DI[10] = DI_10;
            DI[11] = DI_11;
            DI[12] = DI_12;
            DI[13] = DI_13;
            DI[14] = DI_14;
            DI[15] = DI_15;
            DI[16] = DI_16;
            DI[17] = DI_17;
            DI[18] = DI_18;
            DI[19] = DI_19;
            DI[20] = DI_20;
            DI[21] = DI_21;
            DI[22] = DI_22;
            DI[23] = DI_23;
            DI[24] = DI_24;
            DI[25] = DI_25;
            DI[26] = DI_26;
            DI[27] = DI_27;
            DI[28] = DI_28;
            DI[29] = DI_29;
            DI[30] = DI_30;
            DI[31] = DI_31;
            DI[32] = DI_32;
            DI[33] = DI_33;
            DI[34] = DI_34;
            DI[35] = DI_35;

            //Assign the DO Array(0-23: 5046 DO, 24-35: 5045 DO)
            DO[0] = DO_0;
            DO[1] = DO_1;
            DO[2] = DO_2;
            DO[3] = DO_3;
            DO[4] = DO_4;
            DO[5] = DO_5;
            DO[6] = DO_6;
            DO[7] = DO_7;
            DO[8] = DO_8;
            DO[9] = DO_9;
            DO[10] = DO_10;
            DO[11] = DO_11;
            DO[12] = DO_12;
            DO[13] = DO_13;
            DO[14] = DO_14;
            DO[15] = DO_15;
            DO[16] = DO_16;
            DO[17] = DO_17;
            DO[18] = DO_18;
            DO[19] = DO_19;
            DO[20] = DO_20;
            DO[21] = DO_21;
            DO[22] = DO_22;
            DO[23] = DO_23;
            DO[24] = DO_24;
            DO[25] = DO_25;
            DO[26] = DO_26;
            DO[27] = DO_27;
            DO[28] = DO_28;
            DO[29] = DO_29;
            DO[30] = DO_30;
            DO[31] = DO_31;
            DO[32] = DO_32;
            DO[33] = DO_33;
            DO[34] = DO_34;
            DO[35] = DO_35;

            // Assign AO High Vals
            AOHighVals[0] = lblAO_0High;
            AOHighVals[1] = lblAO_1High;
            AOHighVals[2] = lblAO_2High;
            AOHighVals[3] = lblAO_3High;
            AOHighVals[4] = lblAO_4High;
            AOHighVals[5] = lblAO_5High;
            AOHighVals[6] = lblAO_6High;
            AOHighVals[7] = lblAO_7High;

            // Assign AO Low Vals
            AOLowVals[0] = lblAO_0Low;
            AOLowVals[1] = lblAO_1Low;
            AOLowVals[2] = lblAO_2Low;
            AOLowVals[3] = lblAO_3Low;
            AOLowVals[4] = lblAO_4Low;
            AOLowVals[5] = lblAO_5Low;
            AOLowVals[6] = lblAO_6Low;
            AOLowVals[7] = lblAO_7Low;

            // Assign AO Output label Vals
            AOOutputVals[0] = lblAO_0Value;
            AOOutputVals[1] = lblAO_1Value;
            AOOutputVals[2] = lblAO_2Value;
            AOOutputVals[3] = lblAO_3Value;
            AOOutputVals[4] = lblAO_4Value;
            AOOutputVals[5] = lblAO_5Value;
            AOOutputVals[6] = lblAO_6Value;
            AOOutputVals[7] = lblAO_7Value;

            // Assign AO Output Text Vals
            txtAOOutputVals[0] = txtAO_0Val;
            txtAOOutputVals[1] = txtAO_1Val;
            txtAOOutputVals[2] = txtAO_2Val;
            txtAOOutputVals[3] = txtAO_3Val;
            txtAOOutputVals[4] = txtAO_4Val;
            txtAOOutputVals[5] = txtAO_5Val;
            txtAOOutputVals[6] = txtAO_6Val;
            txtAOOutputVals[7] = txtAO_7Val;

            // Assign TrackBar array
            AOTrackBarVals[0] = tBarAO_0Val;
            AOTrackBarVals[1] = tBarAO_1Val;
            AOTrackBarVals[2] = tBarAO_2Val;
            AOTrackBarVals[3] = tBarAO_3Val;
            AOTrackBarVals[4] = tBarAO_4Val;
            AOTrackBarVals[5] = tBarAO_5Val;
            AOTrackBarVals[6] = tBarAO_6Val;
            AOTrackBarVals[7] = tBarAO_7Val;

            // Assign AO Checkbox array
            AOChkRanges[0] = chbxAO_0Range;
            AOChkRanges[1] = chbxAO_1Range;
            AOChkRanges[2] = chbxAO_2Range;
            AOChkRanges[3] = chbxAO_3Range;
            AOChkRanges[4] = chbxAO_4Range;
            AOChkRanges[5] = chbxAO_5Range;
            AOChkRanges[6] = chbxAO_6Range;
            AOChkRanges[7] = chbxAO_7Range;

            // Assign AI Checkbox array
            AIChkRanges[0] = chbxAI_0Range;
            AIChkRanges[1] = chbxAI_1Range;
            AIChkRanges[2] = chbxAI_2Range;
            AIChkRanges[3] = chbxAI_3Range;
            AIChkRanges[4] = chbxAI_4Range;
            AIChkRanges[5] = chbxAI_5Range;
            AIChkRanges[6] = chbxAI_6Range;
            AIChkRanges[7] = chbxAI_7Range;
            AIChkRanges[8] = chbxAI_8Range;
            AIChkRanges[9] = chbxAI_9Range;
            AIChkRanges[10] = chbxAI_10Range;
            AIChkRanges[11] = chbxAI_11Range;
        }

        private void LoadSystemSetting_DB()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = SystemGlobals.ConnectionString;
            string cmdText = "SELECT IP, ScanTime, ConnectionTimeOut, SendTimeOut, ReceiveTimeOut, DOSlotNum, AOSlotNum, AISlotNum, DIOSlotNum, DISlotNum, DIO_DIindex, DIO_DOindex FROM Avantech";
            SqlCommand command = new SqlCommand(cmdText, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                while(reader.Read())
                {
                    SystemGlobals.IP = reader["IP"].ToString();
                    SystemGlobals.ScanTime = Convert.ToInt32(reader["ScanTime"].ToString());
                    SystemGlobals.ConnectionTimeOut = Convert.ToInt32(reader["ConnectionTimeOut"].ToString());
                    SystemGlobals.SendTimeOut = Convert.ToInt32(reader["SendTimeOut"].ToString());
                    SystemGlobals.ReceiveTimeOut = Convert.ToInt32(reader["ReceiveTimeOut"].ToString());
                    SystemGlobals.DOSlotNum = Convert.ToInt32(reader["DOSlotNum"].ToString());
                    SystemGlobals.AOSlotNum = Convert.ToInt32(reader["AOSlotNum"].ToString());
                    SystemGlobals.AISlotNum = Convert.ToInt32(reader["AISlotNum"].ToString());
                    SystemGlobals.DIOSlotNum = Convert.ToInt32(reader["DIOSlotNum"].ToString());
                    SystemGlobals.DISlotNum = Convert.ToInt32(reader["DISlotNum"].ToString());
                    SystemGlobals.DIO_DIindex = Convert.ToInt32(reader["DIO_DIindex"].ToString());
                    SystemGlobals.DIO_DOindex = Convert.ToInt32(reader["DIO_DOindex"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot get information about Avantech. Check database integrity", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (conn != null)
                {
                    conn.Close();
                }
                return;
            }
            conn.Close();
            reader.Close();
        }

        public void ConnectPage_Load(System.Object sender, System.EventArgs e)   
        {
            // Load Default System Setting From Database
            LoadSystemSetting_DB();

            int i = 0;
            // IO UI Arrays Assign
            IO_UI_Arrays_Assign();

            // System Initialize
            AvantechSystemInitialize();
            if (Avantech.bModbusConnected)
            {                
                // Connection status
                txtConnection.Text = "OnLine";
                cmdPWR.BackColor = Color.Green;
                cmdIO.BackColor = Color.Green;

                // All IOs initialization
                AvantechIO_Modules_Initialize();

                // Testing Output Split
                OutputTimer.Enabled = true;

                try
                {
                    MainThread.RunWorkerAsync();
                    Avantech.MainThreadEnabled = true;
                    Avantech.AIEnabled = true;
                    Avantech.DIOEnabled = true;
                    Avantech.DIEnabled = true;
                    Avantech.DOEnabled = true;
                    Avantech.AOEnabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Program already running. This instance will abort.");
                    //if(MainThread.IsBusy==false)
                    System.Environment.Exit(0);
                }
            }
            else
            {
                txtConnection.Text = "OffLine";
                cmdPWR.BackColor = Color.Gray;
                cmdIO.BackColor = Color.Gray;

                // -2 means that modules not connected
                lblAIErr.Text = "-2";
                lblDIOErr.Text = "-2";
                lblDIErr.Text = "-2";
                lblDOErr.Text = "-2";
                lblAOErr.Text = "-2";

                AvantechAOs.Initialize(SystemGlobals.IP, SystemGlobals.AOSlotNum, Avantech.m_ScanTime_LocalSys[0]);//AvantechAOs.Initialize(IP, AOSlotNum, Avantech.m_ScanTime_LocalSys[0]);
            }
        }


        public void cmdConnect_Click(System.Object sender, System.EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                MessageBox.Show("Modbus is already connected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                AvantechSystemInitialize();
                if (Avantech.bModbusConnected)
                {
                    // Connection status
                    txtConnection.Text = "OnLine";
                    cmdPWR.BackColor = Color.Green;
                    cmdIO.BackColor = Color.Green;
                    // Corresponding UI enabled
                    gbDI.Enabled = true;
                    gbDO.Enabled = true;
                    gbAO.Enabled = true;
                    gbAI.Enabled = true;
                    gbAORangeSettings.Enabled = true;
                    gbAOSafetyFunction.Enabled = true;

                    // All IOs initialization
                    AvantechIO_Modules_Initialize();

                    // Testing Output Split
                    //OutputTimer.Enabled = true;

                    try
                    {
                        //if(!MainThread.IsBusy)
                        //{
                        //    MainThread.RunWorkerAsync();
                        //}                        
                        //Avantech.MainThreadEnabled = true;
                        Avantech.AIEnabled = true;
                        Avantech.DIOEnabled = true;
                        Avantech.DIEnabled = true;
                        Avantech.DOEnabled = true;
                        Avantech.AOEnabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Program already running. This instance will abort.");
                        //if(MainThread.IsBusy==false)
                        System.Environment.Exit(0);
                    }
                }
                else
                {
                    txtConnection.Text = "OffLine";
                    cmdPWR.BackColor = Color.Gray;
                    cmdIO.BackColor = Color.Gray;

                    // -2 means that modules not connected
                    lblAIErr.Text = "-2";
                    lblDIOErr.Text = "-2";
                    lblDIErr.Text = "-2";
                    lblDOErr.Text = "-2";
                    lblAOErr.Text = "-2";

                    AvantechAOs.Initialize(SystemGlobals.IP, SystemGlobals.AOSlotNum, Avantech.m_ScanTime_LocalSys[0]);//AvantechAOs.Initialize(IP, AOSlotNum, Avantech.m_ScanTime_LocalSys[0]);
                }
            }
        }

        public void ConnectPage_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            int ret2 = APS168.APS_close();
            ret2 = APS168_W32.APS168.APS_close();
            Environment.Exit(0);
        }

        private void cmdHelp_Click(System.Object sender, System.EventArgs e)
	    {
		    System.Diagnostics.Process p = new System.Diagnostics.Process();

		    try {
                p.StartInfo.FileName = "C:/Users/Paloma/Documents/Visual Studio 2013/Projects/c# CxTitan16apr14_beta3/c# CxTitan16apr14_beta2/CxTitan/Manuals/APS_FunctionLibrary_V1.2.pdf";
			    p.Start();
		    } catch (Exception ex) {
			    MessageBox.Show(ex.ToString());
		    }

	    }

        private void SetDO(int iSlot, int iChannel, bool bState)
        {
            //Avantech.APAX5046_DOEnabled = false;
            //Application.DoEvents();
            // if iSlot = 3: AvantechDOs, else if iSlot = 9:  AvantechDIOs

            //OutputTimer.Enabled = false;

            string errorMsg = "";
            errorMsg = string.Format("Set digital output failed! at Channel {0} in iSlot {1}", iSlot, iChannel);
            if(iSlot == 3)// 5046 DOs
            {                
                if (!AvantechDOs.CheckControllable())
                    return;
                Avantech.DOEnabled = false;
                int iDOChannelTotal = AvantechDOs.m_aConf.HwIoTotal[AvantechDOs.m_tmpidx];
                bool[] DOvalues = new bool[iDOChannelTotal];
                if (AvantechDOs.m_adamSocket.DigitalOutput().SetValue(iSlot, iChannel, bState))
                {
                    AvantechDOs.RefreshData(ref DOvalues);//AvantechDOs.RefreshData(ref DOvalues);
                }//AvantechDOs.RefreshData(ref DOvalues);// if RefreshData is refreshed too fast, there will be problems
                else
                    MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                Avantech.DOEnabled = true;
            }
            else if(iSlot == 9)// 5045 DIO's DOs
            {                
                if (!AvantechDIOs.CheckControllable())
                    return;
                Avantech.DIOEnabled = false;
                int iDIChannelTotal = AvantechDIOs.m_aConf.HwIoTotal[AvantechDIOs.m_DIidx];
                int iDOChannelTotal = AvantechDIOs.m_aConf.HwIoTotal[AvantechDIOs.m_DOidx];
                bool[] DIvalues = new bool [iDIChannelTotal];
                bool[] DOvalues = new bool[iDOChannelTotal];
                if (AvantechDIOs.m_adamSocket.DigitalOutput().SetValue(iSlot, iChannel, bState))
                {
                    AvantechDIOs.Refresh_DOData(ref DOvalues);//AvantechDIOs.RefreshData(ref DIvalues, ref DOvalues);
                }//AvantechDOs.RefreshData(ref DOvalues);// if RefreshData is refreshed too fast, there will be problems
                else
                    MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                Avantech.DIOEnabled = true;
            }
            else
            {
                MessageBox.Show("Set unknown digital output!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            //OutputTimer.Enabled = true;
            //Thread.Sleep(200);
            //Avantech.APAX5046_DOEnabled = true;
        }

	    private void DO_0_Click(System.Object sender, System.EventArgs e)
	    {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                if (!AvantechDOs.CheckControllable())
                {
                    lblDOErr.Text = "-1";
                    return;
                }
                //Avantech.APAX5046_DOEnabled = false;//Avantech.MainThreadEnabled = false;
                if (DO_0.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DOSlotNum, 0, bVal);
                    DO_0.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DOSlotNum, 0, bVal);                   
                    DO_0.BackColor = Color.Red;
                }
                //Avantech.APAX5046_DOEnabled = true;//Avantech.MainThreadEnabled = true;
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_0.BackColor == Color.Red)
                {
                    DO_0.BackColor = Color.Green;
                }
                else
                {
                    DO_0.BackColor = Color.Red;
                }
            }
	    }

        private void DO_4_Click(System.Object sender, System.EventArgs e)
	    {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                if (!AvantechDOs.CheckControllable())
                {
                    lblDOErr.Text = "-1";
                    return;
                }
                if (DO_4.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DOSlotNum, 4, bVal);
                    DO_4.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DOSlotNum, 4, bVal);
                    DO_4.BackColor = Color.Red;
                }
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_4.BackColor == Color.Red)
                {
                    DO_4.BackColor = Color.Green;
                }
                else
                {
                    DO_4.BackColor = Color.Red;
                }
            }
	    }

        private void DO_5_Click(System.Object sender, System.EventArgs e)
	    {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                if (!AvantechDOs.CheckControllable())
                {
                    lblDOErr.Text = "-1";
                    return;
                }
                if (DO_5.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DOSlotNum, 5, bVal);
                    DO_5.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DOSlotNum, 5, bVal);
                    DO_5.BackColor = Color.Red;
                }
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_5.BackColor == Color.Red)
                {
                    DO_5.BackColor = Color.Green;
                }
                else
                {
                    DO_5.BackColor = Color.Red;
                }
            }
	    }

        private void DO_6_Click(System.Object sender, System.EventArgs e)
	    {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                if (!AvantechDOs.CheckControllable())
                {
                    lblDOErr.Text = "-1";
                    return;
                }
                if (DO_6.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DOSlotNum, 6, bVal);
                    DO_6.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DOSlotNum, 6, bVal);
                    DO_6.BackColor = Color.Red;
                }
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_6.BackColor == Color.Red)
                {
                    DO_6.BackColor = Color.Green;
                }
                else
                {
                    DO_6.BackColor = Color.Red;
                }
            }
	    }

        private void DO_7_Click(System.Object sender, System.EventArgs e)
	    {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                if (!AvantechDOs.CheckControllable())
                {
                    lblDOErr.Text = "-1";
                    return;
                }
                if (DO_7.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DOSlotNum, 7, bVal);
                    DO_7.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DOSlotNum, 7, bVal);
                    DO_7.BackColor = Color.Red;
                }
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_7.BackColor == Color.Red)
                {
                    DO_7.BackColor = Color.Green;
                }
                else
                {
                    DO_7.BackColor = Color.Red;
                }
            }
	    }

        private void DO_8_Click(System.Object sender, System.EventArgs e)
	    {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                if (!AvantechDOs.CheckControllable())
                {
                    lblDOErr.Text = "-1";
                    return;
                }
                if (DO_8.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DOSlotNum, 8, bVal);
                    DO_8.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DOSlotNum, 8, bVal);
                    DO_8.BackColor = Color.Red;
                }
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_8.BackColor == Color.Red)
                {
                    DO_8.BackColor = Color.Green;
                }
                else
                {
                    DO_8.BackColor = Color.Red;
                }
            }
	    }

        private void DO_9_Click(System.Object sender, System.EventArgs e)
	    {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                if (!AvantechDOs.CheckControllable())
                {
                    lblDOErr.Text = "-1";
                    return;
                }
                if (DO_9.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DOSlotNum, 9, bVal);
                    DO_9.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DOSlotNum, 9, bVal);
                    DO_9.BackColor = Color.Red;
                }
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_9.BackColor == Color.Red)
                {
                    DO_9.BackColor = Color.Green;
                }
                else
                {
                    DO_9.BackColor = Color.Red;
                }
            }
	    }

        private void DO_10_Click(System.Object sender, System.EventArgs e)
	    {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                if (!AvantechDOs.CheckControllable())
                {
                    lblDOErr.Text = "-1";
                    return;
                }
                if (DO_10.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DOSlotNum, 10, bVal);
                    DO_10.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DOSlotNum, 10, bVal);
                    DO_10.BackColor = Color.Red;
                }
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_10.BackColor == Color.Red)
                {
                    DO_10.BackColor = Color.Green;
                }
                else
                {
                    DO_10.BackColor = Color.Red;
                }
            }
	    }

        private void DO_11_Click(System.Object sender, System.EventArgs e)
	    {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                if (!AvantechDOs.CheckControllable())
                {
                    lblDOErr.Text = "-1";
                    return;
                }
                if (DO_11.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DOSlotNum, 11, bVal);
                    DO_11.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DOSlotNum, 11, bVal);
                    DO_11.BackColor = Color.Red;
                }
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_11.BackColor == Color.Red)
                {
                    DO_11.BackColor = Color.Green;
                }
                else
                {
                    DO_11.BackColor = Color.Red;
                }
            }
	    }

        private void DO_12_Click(System.Object sender, System.EventArgs e)
	    {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                if (!AvantechDOs.CheckControllable())
                {
                    lblDOErr.Text = "-1";
                    return;
                }
                if (DO_12.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DOSlotNum, 12, bVal);
                    DO_12.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DOSlotNum, 12, bVal);
                    DO_12.BackColor = Color.Red;
                }
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_12.BackColor == Color.Red)
                {
                    DO_12.BackColor = Color.Green;
                }
                else
                {
                    DO_12.BackColor = Color.Red;
                }
            }
	    }

        private void DO_13_Click(System.Object sender, System.EventArgs e)
	    {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                if (!AvantechDOs.CheckControllable())
                {
                    lblDOErr.Text = "-1";
                    return;
                }
                if (DO_13.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DOSlotNum, 13, bVal);
                    DO_13.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DOSlotNum, 13, bVal);
                    DO_13.BackColor = Color.Red;
                }
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_13.BackColor == Color.Red)
                {
                    DO_13.BackColor = Color.Green;
                }
                else
                {
                    DO_13.BackColor = Color.Red;
                }
            }
	    }

        private void DO_14_Click(System.Object sender, System.EventArgs e)
	    {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                if (!AvantechDOs.CheckControllable())
                {
                    lblDOErr.Text = "-1";
                    return;
                }
                if (DO_14.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DOSlotNum, 14, bVal);
                    DO_14.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DOSlotNum, 14, bVal);
                    DO_14.BackColor = Color.Red;
                }
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_14.BackColor == Color.Red)
                {
                    DO_14.BackColor = Color.Green;
                }
                else
                {
                    DO_14.BackColor = Color.Red;
                }
            }
	    }

        private void DO_15_Click(System.Object sender, System.EventArgs e)
	    {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                if (!AvantechDOs.CheckControllable())
                {
                    lblDOErr.Text = "-1";
                    return;
                }
                if (DO_15.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DOSlotNum, 15, bVal);
                    DO_15.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DOSlotNum, 15, bVal);
                    DO_15.BackColor = Color.Red;
                }
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_15.BackColor == Color.Red)
                {
                    DO_15.BackColor = Color.Green;
                }
                else
                {
                    DO_15.BackColor = Color.Red;
                }
            }
	    }

	    private void BGWConnect_RunWorkerCompleted(System.Object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
	    {
            //TextBox1.Text = "OffLine";
            //TextBox2.Text = "OffLine";
            //this.Show();

            //MessageBox.Show("Lost connection!");
	    }


	    public void MainThread_DoWork(System.Object sender, System.ComponentModel.DoWorkEventArgs e)
	    {
            int i = 0;
            double Ai_Value = 0;
            Int32 ret2 = default(Int32);
            double FreeSlot = 0;


            // AI 5017H 
            bool bAIRet;
            int iAIChannelTotal = AvantechAIs.m_aConf.HwIoTotal[AvantechAIs.m_tmpidx];
            double[] AIvalues = new double[iAIChannelTotal];
            string[] strAIvalues = new string[iAIChannelTotal];

            // DIO 5045
            //bool bDIO_DIRet;
            //bool bDIO_DORet;
            bool bDIORet;
            // DIO's DI Channel
            int iDIO_DIChannelTotal = AvantechDIOs.m_aConf.HwIoTotal[AvantechDIOs.m_DIidx];
            bool[] DIO_DIvalues = new bool[iDIO_DIChannelTotal];
            // DIO's DO Channel
            int iDIO_DOChannelTotal = AvantechDIOs.m_aConf.HwIoTotal[AvantechDIOs.m_DOidx];
            bool[] DIO_DOvalues = new bool[iDIO_DOChannelTotal];

            // DI 5040
            bool bDIRet;
            int iDIChannelTotal = AvantechDIs.m_aConf.HwIoTotal[AvantechDIs.m_tmpidx];
            bool[] DIvalues = new bool[iDIChannelTotal];

            // DO 5046
            bool bDORet;
            int iDOChannelTotal = AvantechDOs.m_aConf.HwIoTotal[AvantechDOs.m_tmpidx];
            bool[] DOvalues = new bool[iDOChannelTotal];

            // AO 5028
            bool bAORet;
            int iAOChannelTotal = AvantechAOs.m_aConf.HwIoTotal[AvantechAOs.m_tmpidx];
            double[] AOvalues = new double[iAOChannelTotal];
            string[] strAOvalues = new string[iAOChannelTotal];

            
            while (Avantech.MainThreadEnabled)
            {
                //StatusBar_IO.Text = "Polling (Interval=" + timer1.Interval.ToString() + "ms): ";

                //// ***********DI*********** ////
                if (Avantech.DIEnabled)
                {
                    cmdNETWORK.BackColor = Color.Green;
                    bDIRet = AvantechDIs.RefreshData(ref DIvalues);
                    lblDIErr.Invoke((MethodInvoker)delegate { lblDIErr.Text = bDIRet ? "0" : "-1"; });//lblDIErr.Text = bDIRet ? "0" : "-1";
                    cmdNETWORK.BackColor = Color.Gray;
                    if (bDIRet)
                    {
                        AvantechDIs.m_iScanCount++;
                        AvantechDIs.m_iFailCount = 0;
                        this.Invoke((MethodInvoker)delegate
                        {
                            for (i = 0; i < iDIChannelTotal; i++)
                            {
                                DI[i].BackColor = DIvalues[i] ? Color.Green : Color.Red;
                            }
                        });
                    }
                    else
                    {
                        AvantechDIs.m_iFailCount++;
                    }

                    if (AvantechDIs.m_iFailCount > 5)
                    {
                        Avantech.DIEnabled = false;//timer1.Enabled = false;
                        Avantech.bModbusConnected = false;
                        MessageBox.Show("Failed more than 5 times! Please check the physical connection and MODBUS address setting!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    }
                    if (AvantechDIs.m_iScanCount % 50 == 0)
                        GC.Collect();
                }
                //// ***********End of DI*********** ////



                // ***********DO*********** ////
                //if (Avantech.DOEnabled)
                //{
                //    cmdNETWORK.BackColor = Color.Green;
                //    bDORet = AvantechDOs.RefreshData(ref DOvalues);
                //    lblDOErr.Invoke((MethodInvoker)delegate { this.Text = bDORet ? "0" : "-1"; });//lblDOErr.Text = bDORet ? "0" : "-1";
                //    cmdNETWORK.BackColor = Color.Gray;
                //    if (bDORet)
                //    {
                //        AvantechDOs.m_iScanCount++;
                //        AvantechDOs.m_iFailCount = 0;
                //        this.Invoke((MethodInvoker)delegate
                //        {
                //            for (i = 0; i < iDOChannelTotal; i++)
                //            {
                //                DO[i].BackColor = DOvalues[i] ? Color.Green : Color.Red;
                //            }
                //        });
                //    }
                //    else
                //    {
                //        AvantechDOs.m_iFailCount++;
                //    }

                //    if (AvantechDOs.m_iFailCount > 5)
                //    {
                //        Avantech.DOEnabled = false;//timer1.Enabled = false;
                //        MessageBox.Show("Failed more than 5 times! Please check the physical connection and MODBUS address setting!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);

                //    }
                //    if (AvantechDOs.m_iScanCount % 50 == 0)
                //        GC.Collect();
                //}
                // ***********End of DO*********** ////



                // ***********AO*********** ////
                //if (Avantech.AOEnabled)
                //{
                //    cmdNETWORK.BackColor = Color.Green;
                //    bAORet = AvantechAOs.RefreshData(ref strAOvalues);
                //    if (bAORet)
                //    {
                //        AvantechAOs.m_iScanCount++;
                //        AvantechAOs.m_iFailCount = 0;
                //    }
                //    else
                //    {
                //        AvantechAOs.m_iFailCount++;
                //    }

                //    if (AvantechAOs.m_iFailCount > 5)
                //    {
                //        Avantech.AOEnabled = false;//timer1.Enabled = false;
                //        MessageBox.Show("Failed more than 5 times! Please check the physical connection and MODBUS address setting!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                //    }
                //    if (AvantechAOs.m_iScanCount % 50 == 0)
                //        GC.Collect();
                //}
                // ***********End of AO*********** ////



                //// ***********AI*********** ////
                if (Avantech.AIEnabled)
                {
                    cmdNETWORK.BackColor = Color.Green;
                    //bAIRet = AvantechAIs.RefreshData(ref AIvalues);
                    bAIRet = AvantechAIs.RefreshData(ref strAIvalues);
                    lblAIErr.Invoke((MethodInvoker)delegate { lblAIErr.Text = bAIRet ? "0" : "-1"; });//lblAIErr.Text = bAIRet ? "0" : "-1";
                    cmdNETWORK.BackColor = Color.Gray;
                    if (bAIRet)
                    {
                        AvantechAIs.m_iScanCount++;
                        AvantechAIs.m_iFailCount = 0;
                        for (i = 0; i < iAIChannelTotal; i++)
                        {
                            SetText(strAIvalues[i], i);//SetText(Convert.ToString(AIvalues[i]), i);
                        }
                    }
                    else
                    {
                        AvantechAIs.m_iFailCount++;
                    }

                    if (AvantechAIs.m_iFailCount > 5)
                    {
                        Avantech.AIEnabled = false;//timer1.Enabled = false;
                        Avantech.bModbusConnected = false;
                        MessageBox.Show("Failed more than 5 times! Please check the physical connection and MODBUS address setting!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    }
                    if (AvantechAIs.m_iScanCount % 50 == 0)
                        GC.Collect();
                }
                //// ***********End of AI*********** ////



                // ***********DIO*********** ////
                // ***********Refresh DI only***********//
                //if (Avantech.DIOEnabled)
                //{
                //    cmdNETWORK.BackColor = Color.Green;
                //    bDIORet = AvantechDIOs.Refresh_DIData(ref DIO_DIvalues);//bDIORet = AvantechDIOs.RefreshData(ref DIO_DIvalues, ref DIO_DOvalues);
                //    lblDIOErr.Invoke((MethodInvoker)delegate { this.Text = bDIORet ? "0" : "-1"; });//lblDIOErr.Text = bDIORet ? "0" : "-1";
                //    cmdNETWORK.BackColor = Color.Gray;
                //    if (bDIORet)
                //    {
                //        AvantechDIOs.m_iScanCount++;
                //        AvantechDIOs.m_iFailCount = 0;
                //        this.Invoke((MethodInvoker)delegate
                //        {
                //            for (i = iDIChannelTotal; i < iDIChannelTotal + iDIO_DIChannelTotal; i++)
                //            {
                //                DI[i].BackColor = DIO_DIvalues[i - iDIChannelTotal] ? Color.Green : Color.Red;
                //            }
                //            //for (i = iDOChannelTotal; i < iDOChannelTotal + iDIO_DOChannelTotal; i++)
                //            //{
                //            //    DO[i].BackColor = DIO_DOvalues[i - iDOChannelTotal] ? Color.Green : Color.Red;
                //            //}
                //        });
                //    }
                //    else
                //    {
                //        AvantechDIOs.m_iFailCount++;
                //    }

                //    if (AvantechDIOs.m_iFailCount > 5)
                //    {
                //        Avantech.DIOEnabled = false;//timer1.Enabled = false;
                //        MessageBox.Show("Failed more than 5 times! Please check the physical connection and MODBUS address setting!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);

                //    }
                //    if (AvantechDIOs.m_iScanCount % 50 == 0)
                //        GC.Collect();
                //}
                // ***********End of DIO*********** ////


                Thread.Sleep(Avantech.m_ScanTime_LocalSys[0]);// same as Avantech's timer1(1000)
            }
	    }

	    private void MainThread_RunWorkerCompleted(System.Object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
	    {
		    //Thread.Sleep(1000)
		    if (BGWConnect.IsBusy == false) {
			    BGWConnect.RunWorkerAsync();
		    }

	    }


	    private void SetText(string text, int pos)
	    {
		    try {
			    if (this.AI[pos].InvokeRequired) {
				    SetTextCallback d = new SetTextCallback(SetText);
				    this.Invoke(d, new object[] {
					    text,
					    pos
				    });
			    } 
                else {
				    this.AI[pos].Text = text;
			    }
            } catch (Exception ex) 
            {
		    }
	    }

        private void cmdStartProgram_Click(object sender, EventArgs e) 
        {
            //this.Hide();
            //CxTitan.Manual objManual = new CxTitan.Manual();
            //objManual.Hide();
            //CxTitan.Splash objSplash = new CxTitan.Splash();

            //objSplash.ShowDialog();
      
        
       
	    }


        public void cmdExit_Click(object sender, EventArgs e)
        {
            //// Disable Threads
            //if(MainThread.IsBusy)
            //{
            //    MainThread.CancelAsync();
            //}
            //Avantech.MainThreadEnabled = false;
            //OutputTimer.Enabled = false;
            //Avantech.bModbusConnected = false;

            //// Disconnect IO modules
            //AvantechDIs.FreeResource();
            //AvantechDOs.FreeResource();
            //AvantechAOs.FreeResource();
            //AvantechAIs.FreeResource();
            //AvantechDIOs.FreeResource();

            this.Hide();
            SystemGlobals.objJanusManual.Show();//SystemGlobals.JanusManualPageReturn.Show();//System.Environment.Exit(0);
        }

        public void cmdDisconnect_Click(object sender, EventArgs e)
        {
            // Disconnect IO modules
            AvantechDIs.FreeResource();
            AvantechDOs.FreeResource();
            AvantechAOs.FreeResource();
            AvantechAIs.FreeResource();
            AvantechDIOs.FreeResource();

            // Corresponding UI disabled
            txtConnection.Text = "OffLine";
            cmdPWR.BackColor = Color.Gray;
            cmdIO.BackColor = Color.Gray;
            gbDI.Enabled = false;
            gbDO.Enabled = false;
            gbAO.Enabled = false;
            gbAI.Enabled = false;
            gbAORangeSettings.Enabled = false;
            gbAOSafetyFunction.Enabled = false;

            //// Thread and timer disable
            //if(MainThread.IsBusy)
            //{
            //    MainThread.CancelAsync();
            //}            
            //Avantech.MainThreadEnabled = false;
            //OutputTimer.Enabled = false;

            // Connection status disable
            Avantech.bModbusConnected = false;
        }

        private void BGWConnect_DoWork(object sender, DoWorkEventArgs e)
        {
            ////Disconnect
            //int ret = APS168.APS_close();
            // APS168.APS_stop_field_bus(CardID, BusNo);
            
            ////Timer1.Enabled = False
            ////End
	    }

        private void DO_1_Click(object sender, EventArgs e)
        {
            //if (Avantech.bModbusConnected)
            //{
            //    bool bVal = false;
            //    int iDOChannelTotal = AvantechDOs.m_aConf.HwIoTotal[AvantechDOs.m_tmpidx];
            //    bool[] DOvalues = new bool[iDOChannelTotal];
            //    if (!AvantechDOs.CheckControllable())
            //        return;
            //    if (DO_1.BackColor == Color.Red)
            //    {
            //        bVal = true;
            //        if (AvantechDOs.m_adamSocket.DigitalOutput().SetValue(DOSlotNum, 1, bVal))
            //            AvantechDOs.RefreshData(ref DOvalues);
            //        else
            //            MessageBox.Show("Set digital output failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            //        DO_1.BackColor = Color.Green;
            //    }
            //    else
            //    {
            //        bVal = false;
            //        if (AvantechDOs.m_adamSocket.DigitalOutput().SetValue(DOSlotNum, 1, bVal))
            //            AvantechDOs.RefreshData(ref DOvalues);
            //        else
            //            MessageBox.Show("Set digital output failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            //        DO_1.BackColor = Color.Red;
            //    }
            //}
            //else
            //{
            //    // no connection, just click as normal buttons
            //    if (DO_1.BackColor == Color.Red)
            //    {
            //        DO_1.BackColor = Color.Green;
            //    }
            //    else
            //    {
            //        DO_1.BackColor = Color.Red;
            //    }
            //}

            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                if (!AvantechDOs.CheckControllable())
                {
                    lblDOErr.Text = "-1";
                    return;
                }
                if (DO_1.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DOSlotNum, 1, bVal);
                    DO_1.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DOSlotNum, 1, bVal);
                    DO_1.BackColor = Color.Red;
                }
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_1.BackColor == Color.Red)
                {
                    DO_1.BackColor = Color.Green;
                }
                else
                {
                    DO_1.BackColor = Color.Red;
                }
            }
        }

        private void DO_2_Click(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                if (!AvantechDOs.CheckControllable())
                {
                    lblDOErr.Text = "-1";
                    return;
                }
                if (DO_2.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DOSlotNum, 2, bVal);
                    DO_2.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DOSlotNum, 2, bVal);
                    DO_2.BackColor = Color.Red;
                }
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_2.BackColor == Color.Red)
                {
                    DO_2.BackColor = Color.Green;
                }
                else
                {
                    DO_2.BackColor = Color.Red;
                }
            }
        }

        private void DO_3_Click(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                if (!AvantechDOs.CheckControllable())
                {
                    lblDOErr.Text = "-1";
                    return;
                }
                if (DO_3.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DOSlotNum, 3, bVal);
                    DO_3.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DOSlotNum, 3, bVal);
                    DO_3.BackColor = Color.Red;
                }
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_3.BackColor == Color.Red)
                {
                    DO_3.BackColor = Color.Green;
                }
                else
                {
                    DO_3.BackColor = Color.Red;
                }
            }
        }

        private void DO_16_Click(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                if (!AvantechDOs.CheckControllable())
                {
                    lblDOErr.Text = "-1";
                    return;
                }
                if (DO_16.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DOSlotNum, 16, bVal);
                    DO_16.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DOSlotNum, 16, bVal);
                    DO_16.BackColor = Color.Red;
                }
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_16.BackColor == Color.Red)
                {
                    DO_16.BackColor = Color.Green;
                }
                else
                {
                    DO_16.BackColor = Color.Red;
                }
            }
        }

        private void DO_17_Click(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                if (!AvantechDOs.CheckControllable())
                {
                    lblDOErr.Text = "-1";
                    return;
                }
                if (DO_17.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DOSlotNum, 17, bVal);
                    DO_17.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DOSlotNum, 17, bVal);
                    DO_17.BackColor = Color.Red;
                }
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_17.BackColor == Color.Red)
                {
                    DO_17.BackColor = Color.Green;
                }
                else
                {
                    DO_17.BackColor = Color.Red;
                }
            }
        }

        private void DO_18_Click(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                if (!AvantechDOs.CheckControllable())
                {
                    lblDOErr.Text = "-1";
                    return;
                }
                if (DO_18.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DOSlotNum, 18, bVal);
                    DO_18.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DOSlotNum, 18, bVal);
                    DO_18.BackColor = Color.Red;
                }
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_18.BackColor == Color.Red)
                {
                    DO_18.BackColor = Color.Green;
                }
                else
                {
                    DO_18.BackColor = Color.Red;
                }
            }
        }

        private void DO_19_Click(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                if (!AvantechDOs.CheckControllable())
                {
                    lblDOErr.Text = "-1";
                    return;
                }
                if (DO_19.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DOSlotNum, 19, bVal);
                    DO_19.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DOSlotNum, 19, bVal);
                    DO_19.BackColor = Color.Red;
                }
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_19.BackColor == Color.Red)
                {
                    DO_19.BackColor = Color.Green;
                }
                else
                {
                    DO_19.BackColor = Color.Red;
                }
            }
        }

        private void DO_20_Click(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                if (!AvantechDOs.CheckControllable())
                {
                    lblDOErr.Text = "-1";
                    return;
                }
                if (DO_20.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DOSlotNum, 20, bVal);
                    DO_20.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DOSlotNum, 20, bVal);
                    DO_20.BackColor = Color.Red;
                }
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_20.BackColor == Color.Red)
                {
                    DO_20.BackColor = Color.Green;
                }
                else
                {
                    DO_20.BackColor = Color.Red;
                }
            }
        }

        private void DO_21_Click(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                if (!AvantechDOs.CheckControllable())
                {
                    lblDOErr.Text = "-1";
                    return;
                }
                if (DO_21.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DOSlotNum, 21, bVal);
                    DO_21.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DOSlotNum, 21, bVal);
                    DO_21.BackColor = Color.Red;
                }
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_21.BackColor == Color.Red)
                {
                    DO_21.BackColor = Color.Green;
                }
                else
                {
                    DO_21.BackColor = Color.Red;
                }
            }
        }

        private void DO_22_Click(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                if (!AvantechDOs.CheckControllable())
                {
                    lblDOErr.Text = "-1";
                    return;
                }
                if (DO_22.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DOSlotNum, 22, bVal);
                    DO_22.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DOSlotNum, 22, bVal);
                    DO_22.BackColor = Color.Red;
                }
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_22.BackColor == Color.Red)
                {
                    DO_22.BackColor = Color.Green;
                }
                else
                {
                    DO_22.BackColor = Color.Red;
                }
            }
        }

        private void DO_23_Click(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                if (!AvantechDOs.CheckControllable())
                {
                    lblDOErr.Text = "-1";
                    return;
                }
                if (DO_23.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DOSlotNum, 23, bVal);
                    DO_23.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DOSlotNum, 23, bVal);
                    DO_23.BackColor = Color.Red;
                }
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_23.BackColor == Color.Red)
                {
                    DO_23.BackColor = Color.Green;
                }
                else
                {
                    DO_23.BackColor = Color.Red;
                }
            }
        }

        // From DO_24 onwards to DO_35, use AvantechDIOs as they are belong to APAX5045
        // DIOSlotNum = 9 and channel starting from AvantechDIOs.m_iDoOffset = 12 to 23
        private void DO_24_Click(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                //Avantech.DIOEnabled = false;
                if (!AvantechDIOs.CheckControllable())
                {
                    lblDIOErr.Text = "-1";
                    return;
                }
                if (DO_24.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DIOSlotNum, AvantechDIOs.m_iDoOffset, bVal);
                    DO_24.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DIOSlotNum, AvantechDIOs.m_iDoOffset, bVal);
                    DO_24.BackColor = Color.Red;
                }
                //Avantech.DIOEnabled = true;
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_24.BackColor == Color.Red)
                {
                    DO_24.BackColor = Color.Green;
                }
                else
                {
                    DO_24.BackColor = Color.Red;
                }
            }
        }

        private void DO_25_Click(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                //Avantech.DIOEnabled = false;
                if (!AvantechDIOs.CheckControllable())
                {
                    lblDIOErr.Text = "-1";
                    return;
                }
                if (DO_25.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DIOSlotNum, 1 + AvantechDIOs.m_iDoOffset, bVal);
                    DO_25.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DIOSlotNum, 1 + AvantechDIOs.m_iDoOffset, bVal);
                    DO_25.BackColor = Color.Red;
                }
                //Avantech.DIOEnabled = true;
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_25.BackColor == Color.Red)
                {
                    DO_25.BackColor = Color.Green;
                }
                else
                {
                    DO_25.BackColor = Color.Red;
                }
            }
        }

        private void DO_26_Click(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                //Avantech.DIOEnabled = false;
                if (!AvantechDIOs.CheckControllable())
                {
                    lblDIOErr.Text = "-1";
                    return;
                }
                if (DO_26.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DIOSlotNum, 2 + AvantechDIOs.m_iDoOffset, bVal);
                    DO_26.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DIOSlotNum, 2 + AvantechDIOs.m_iDoOffset, bVal);
                    DO_26.BackColor = Color.Red;
                }
                //Avantech.DIOEnabled = true;
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_26.BackColor == Color.Red)
                {
                    DO_26.BackColor = Color.Green;
                }
                else
                {
                    DO_26.BackColor = Color.Red;
                }
            }
        }

        private void DO_27_Click(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                //Avantech.DIOEnabled = false;
                if (!AvantechDIOs.CheckControllable())
                {
                    lblDIOErr.Text = "-1";
                    return;
                }
                if (DO_27.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DIOSlotNum, 3 + AvantechDIOs.m_iDoOffset, bVal);
                    DO_27.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DIOSlotNum, 3 + AvantechDIOs.m_iDoOffset, bVal);
                    DO_27.BackColor = Color.Red;
                }
                //Avantech.DIOEnabled = true;
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_27.BackColor == Color.Red)
                {
                    DO_27.BackColor = Color.Green;
                }
                else
                {
                    DO_27.BackColor = Color.Red;
                }
            }
        }

        private void DO_28_Click(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                //Avantech.DIOEnabled = false;
                if (!AvantechDIOs.CheckControllable())
                {
                    lblDIOErr.Text = "-1";
                    return;
                }
                if (DO_28.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DIOSlotNum, 4 + AvantechDIOs.m_iDoOffset, bVal);
                    DO_28.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DIOSlotNum, 4 + AvantechDIOs.m_iDoOffset, bVal);
                    DO_28.BackColor = Color.Red;
                }
                //Avantech.DIOEnabled = true;
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_28.BackColor == Color.Red)
                {
                    DO_28.BackColor = Color.Green;
                }
                else
                {
                    DO_28.BackColor = Color.Red;
                }
            }
        }

        private void DO_29_Click(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                //Avantech.DIOEnabled = false;
                if (!AvantechDIOs.CheckControllable())
                {
                    lblDIOErr.Text = "-1";
                    return;
                }
                if (DO_29.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DIOSlotNum, 5 + AvantechDIOs.m_iDoOffset, bVal);
                    DO_29.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DIOSlotNum, 5 + AvantechDIOs.m_iDoOffset, bVal);
                    DO_29.BackColor = Color.Red;
                }
                //Avantech.DIOEnabled = true;
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_29.BackColor == Color.Red)
                {
                    DO_29.BackColor = Color.Green;
                }
                else
                {
                    DO_29.BackColor = Color.Red;
                }
            }
        }

        private void DO_30_Click(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                //Avantech.DIOEnabled = false;
                if (!AvantechDIOs.CheckControllable())
                {
                    lblDIOErr.Text = "-1";
                    return;
                }
                if (DO_30.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DIOSlotNum, 6 + AvantechDIOs.m_iDoOffset, bVal);
                    DO_30.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DIOSlotNum, 6 + AvantechDIOs.m_iDoOffset, bVal);
                    DO_30.BackColor = Color.Red;
                }
                //Avantech.DIOEnabled = true;
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_30.BackColor == Color.Red)
                {
                    DO_30.BackColor = Color.Green;
                }
                else
                {
                    DO_30.BackColor = Color.Red;
                }
            }
        }

        private void DO_31_Click(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                //Avantech.DIOEnabled = false;
                if (!AvantechDIOs.CheckControllable())
                {
                    lblDIOErr.Text = "-1";
                    return;
                }
                if (DO_31.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DIOSlotNum, 7 + AvantechDIOs.m_iDoOffset, bVal);
                    DO_31.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DIOSlotNum, 7 + AvantechDIOs.m_iDoOffset, bVal);
                    DO_31.BackColor = Color.Red;
                }
                //Avantech.DIOEnabled = true;
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_31.BackColor == Color.Red)
                {
                    DO_31.BackColor = Color.Green;
                }
                else
                {
                    DO_31.BackColor = Color.Red;
                }
            }
        }

        private void DO_32_Click(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                //Avantech.DIOEnabled = false;
                if (!AvantechDIOs.CheckControllable())
                {
                    lblDIOErr.Text = "-1";
                    return;
                }
                if (DO_32.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DIOSlotNum, 8 + AvantechDIOs.m_iDoOffset, bVal);
                    DO_32.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DIOSlotNum, 8 + AvantechDIOs.m_iDoOffset, bVal);
                    DO_32.BackColor = Color.Red;
                }
                //Avantech.DIOEnabled = true;
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_32.BackColor == Color.Red)
                {
                    DO_32.BackColor = Color.Green;
                }
                else
                {
                    DO_32.BackColor = Color.Red;
                }
            }
        }

        private void DO_33_Click(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                //Avantech.DIOEnabled = false;
                if (!AvantechDIOs.CheckControllable())
                {
                    lblDIOErr.Text = "-1";
                    return;
                }
                if (DO_33.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DIOSlotNum, 9 + AvantechDIOs.m_iDoOffset, bVal);
                    DO_33.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DIOSlotNum, 9 + AvantechDIOs.m_iDoOffset, bVal);
                    DO_33.BackColor = Color.Red;
                }
                //Avantech.DIOEnabled = true;
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_33.BackColor == Color.Red)
                {
                    DO_33.BackColor = Color.Green;
                }
                else
                {
                    DO_33.BackColor = Color.Red;
                }
            }
        }

        private void DO_34_Click(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                //Avantech.DIOEnabled = false;
                if (!AvantechDIOs.CheckControllable())
                {
                    lblDIOErr.Text = "-1";
                    return;
                }
                if (DO_34.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DIOSlotNum, 10 + AvantechDIOs.m_iDoOffset, bVal);
                    DO_34.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DIOSlotNum, 10 + AvantechDIOs.m_iDoOffset, bVal);
                    DO_34.BackColor = Color.Red;
                }
                //Avantech.DIOEnabled = true;
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_34.BackColor == Color.Red)
                {
                    DO_34.BackColor = Color.Green;
                }
                else
                {
                    DO_34.BackColor = Color.Red;
                }
            }
        }

        private void DO_35_Click(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                bool bVal = false;
                //Avantech.DIOEnabled = false;
                if (!AvantechDIOs.CheckControllable())
                {
                    lblDIOErr.Text = "-1";
                    return;
                }
                if (DO_35.BackColor == Color.Red)
                {
                    bVal = true;
                    SetDO(DIOSlotNum, 11 + AvantechDIOs.m_iDoOffset, bVal);
                    DO_35.BackColor = Color.Green;
                }
                else
                {
                    bVal = false;
                    SetDO(DIOSlotNum, 11 + AvantechDIOs.m_iDoOffset, bVal);
                    DO_35.BackColor = Color.Red;
                }
                //Avantech.DIOEnabled = true;
            }
            else
            {
                // no connection, just click as normal buttons
                if (DO_35.BackColor == Color.Red)
                {
                    DO_35.BackColor = Color.Green;
                }
                else
                {
                    DO_35.BackColor = Color.Red;
                }
            }
        }

        private void tBarAO_0Val_ValueChanged(object sender, EventArgs e)
        {
            //float fVal;
            //fVal = (AvantechAOs.m_fHigh - AvantechAOs.m_fLow) * (tBarAO_0Val.Value - tBarAO_0Val.Minimum) / (tBarAO_0Val.Maximum - tBarAO_0Val.Minimum) + AvantechAOs.m_fLow;
            //txtAO_0Val.Text = fVal.ToString("0.000");//txtOutputVal.Text = fVal.ToString("0.000");

            float fVal;
            fVal = (AvantechAOs.m_fHighVals[0] - AvantechAOs.m_fLowVals[0]) * (tBarAO_0Val.Value - tBarAO_0Val.Minimum) / (tBarAO_0Val.Maximum - tBarAO_0Val.Minimum) + AvantechAOs.m_fLowVals[0];
            txtAO_0Val.Text = fVal.ToString("0.000");
        }

        private void tBarAO_0Val_MouseDown(object sender, MouseEventArgs e)
        {
            //AvantechAOs.b_AOValueModified = true;
            //txtAO_0Val.SelectAll();

            AvantechAOs.m_bAOValueModified[0] = true;
            txtAO_0Val.SelectAll();
        }

        private void txtAO_0Val_KeyPress(object sender, KeyPressEventArgs e)
        {
            AvantechAOs.m_bAOValueModified[0] = true;
        }

        private void txtAO_0Val_MouseDown(object sender, MouseEventArgs e)
        {
            AvantechAOs.m_bAOValueModified[0] = true;
        }

        private void tBarAO_1Val_ValueChanged(object sender, EventArgs e)
        {
            float fVal;
            fVal = (AvantechAOs.m_fHighVals[1] - AvantechAOs.m_fLowVals[1]) * (tBarAO_1Val.Value - tBarAO_1Val.Minimum) / (tBarAO_1Val.Maximum - tBarAO_1Val.Minimum) + AvantechAOs.m_fLowVals[1];
            txtAO_1Val.Text = fVal.ToString("0.000");
        }

        private void tBarAO_1Val_MouseDown(object sender, MouseEventArgs e)
        {
            AvantechAOs.m_bAOValueModified[1] = true;
            txtAO_1Val.SelectAll();
        }

        private void tBarAO_2Val_ValueChanged(object sender, EventArgs e)
        {
            float fVal;
            fVal = (AvantechAOs.m_fHighVals[2] - AvantechAOs.m_fLowVals[2]) * (tBarAO_2Val.Value - tBarAO_2Val.Minimum) / (tBarAO_2Val.Maximum - tBarAO_2Val.Minimum) + AvantechAOs.m_fLowVals[2];
            txtAO_2Val.Text = fVal.ToString("0.000");
        }

        private void tBarAO_2Val_MouseDown(object sender, MouseEventArgs e)
        {
            AvantechAOs.m_bAOValueModified[2] = true;
            txtAO_2Val.SelectAll();
        }

        private void tBarAO_3Val_ValueChanged(object sender, EventArgs e)
        {
            float fVal;
            fVal = (AvantechAOs.m_fHighVals[3] - AvantechAOs.m_fLowVals[3]) * (tBarAO_3Val.Value - tBarAO_3Val.Minimum) / (tBarAO_3Val.Maximum - tBarAO_3Val.Minimum) + AvantechAOs.m_fLowVals[3];
            txtAO_3Val.Text = fVal.ToString("0.000");
        }

        private void tBarAO_3Val_MouseDown(object sender, MouseEventArgs e)
        {
            AvantechAOs.m_bAOValueModified[3] = true;
            txtAO_3Val.SelectAll();
        }

        private void tBarAO_4Val_ValueChanged(object sender, EventArgs e)
        {
            float fVal;
            fVal = (AvantechAOs.m_fHighVals[4] - AvantechAOs.m_fLowVals[4]) * (tBarAO_4Val.Value - tBarAO_4Val.Minimum) / (tBarAO_4Val.Maximum - tBarAO_4Val.Minimum) + AvantechAOs.m_fLowVals[4];
            txtAO_4Val.Text = fVal.ToString("0.000");
        }

        private void tBarAO_4Val_MouseDown(object sender, MouseEventArgs e)
        {
            AvantechAOs.m_bAOValueModified[4] = true;
            txtAO_4Val.SelectAll();
        }

        private void tBarAO_5Val_ValueChanged(object sender, EventArgs e)
        {
            float fVal;
            fVal = (AvantechAOs.m_fHighVals[5] - AvantechAOs.m_fLowVals[5]) * (tBarAO_5Val.Value - tBarAO_5Val.Minimum) / (tBarAO_5Val.Maximum - tBarAO_5Val.Minimum) + AvantechAOs.m_fLowVals[5];
            txtAO_5Val.Text = fVal.ToString("0.000");
        }

        private void tBarAO_5Val_MouseDown(object sender, MouseEventArgs e)
        {
            AvantechAOs.m_bAOValueModified[5] = true;
            txtAO_5Val.SelectAll();
        }

        private void tBarAO_6Val_ValueChanged(object sender, EventArgs e)
        {
            float fVal;
            fVal = (AvantechAOs.m_fHighVals[6] - AvantechAOs.m_fLowVals[6]) * (tBarAO_6Val.Value - tBarAO_6Val.Minimum) / (tBarAO_6Val.Maximum - tBarAO_6Val.Minimum) + AvantechAOs.m_fLowVals[6];
            txtAO_6Val.Text = fVal.ToString("0.000");
        }

        private void tBarAO_6Val_MouseDown(object sender, MouseEventArgs e)
        {
            AvantechAOs.m_bAOValueModified[6] = true;
            txtAO_6Val.SelectAll();
        }

        private void tBarAO_7Val_ValueChanged(object sender, EventArgs e)
        {
            float fVal;
            fVal = (AvantechAOs.m_fHighVals[7] - AvantechAOs.m_fLowVals[7]) * (tBarAO_7Val.Value - tBarAO_7Val.Minimum) / (tBarAO_7Val.Maximum - tBarAO_7Val.Minimum) + AvantechAOs.m_fLowVals[7];
            txtAO_7Val.Text = fVal.ToString("0.000");
        }

        private void tBarAO_7Val_MouseDown(object sender, MouseEventArgs e)
        {
            AvantechAOs.m_bAOValueModified[7] = true;
            txtAO_7Val.SelectAll();
        }

        private void txtAO_1Val_KeyPress(object sender, KeyPressEventArgs e)
        {
            AvantechAOs.m_bAOValueModified[1] = true;
        }

        private void txtAO_1Val_MouseDown(object sender, MouseEventArgs e)
        {
            AvantechAOs.m_bAOValueModified[1] = true;
        }

        private void txtAO_2Val_KeyPress(object sender, KeyPressEventArgs e)
        {
            AvantechAOs.m_bAOValueModified[2] = true;
        }

        private void txtAO_2Val_MouseDown(object sender, MouseEventArgs e)
        {
            AvantechAOs.m_bAOValueModified[2] = true;
        }

        private void txtAO_3Val_KeyPress(object sender, KeyPressEventArgs e)
        {
            AvantechAOs.m_bAOValueModified[3] = true;
        }

        private void txtAO_3Val_MouseDown(object sender, MouseEventArgs e)
        {
            AvantechAOs.m_bAOValueModified[3] = true;
        }

        private void txtAO_4Val_KeyPress(object sender, KeyPressEventArgs e)
        {
            AvantechAOs.m_bAOValueModified[4] = true;
        }

        private void txtAO_4Val_MouseDown(object sender, MouseEventArgs e)
        {
            AvantechAOs.m_bAOValueModified[4] = true;
        }

        private void txtAO_5Val_KeyPress(object sender, KeyPressEventArgs e)
        {
            AvantechAOs.m_bAOValueModified[5] = true;
        }

        private void txtAO_5Val_MouseDown(object sender, MouseEventArgs e)
        {
            AvantechAOs.m_bAOValueModified[5] = true;
        }

        private void txtAO_6Val_KeyPress(object sender, KeyPressEventArgs e)
        {
            AvantechAOs.m_bAOValueModified[6] = true;
        }

        private void txtAO_6Val_MouseDown(object sender, MouseEventArgs e)
        {
            AvantechAOs.m_bAOValueModified[6] = true;
        }

        private void txtAO_7Val_KeyPress(object sender, KeyPressEventArgs e)
        {
            AvantechAOs.m_bAOValueModified[7] = true;
        }

        private void txtAO_7Val_MouseDown(object sender, MouseEventArgs e)
        {
            AvantechAOs.m_bAOValueModified[7] = true;
        }

        // Only related to AO
        /// </summary>
        /// <returns></returns>
        private bool RefreshAOData()
        {
            int iChannelTotal = AvantechAOs.m_aConf.HwIoTotal[AvantechAOs.m_tmpidx];
            ushort[] usVal;
            string[] strVal;
            //float fHigh = 0, fLow = 0;
            float[] fHighVals = new float[iChannelTotal];
            float[] fLowVals = new float[iChannelTotal];

            if (!AvantechAOs.m_adamSocket.AnalogOutput().GetValues(AvantechAOs.m_idxID, iChannelTotal, out usVal))
            {
                //StatusBar_IO.Text += "ApiErr:" + m_adamSocket.Modbus().LastError.ToString() + " ";
                return false;
            }
            strVal = new string[usVal.Length];

            for (int i = 0; i < iChannelTotal; i++)
            {
                if (AvantechAOs.IsShowRawData)
                    strVal[i] = usVal[i].ToString("X04");
                else
                    strVal[i] = AnalogOutput.GetScaledValue(AvantechAOs.m_usRanges[i], usVal[i]).ToString(AnalogOutput.GetFloatFormat(AvantechAOs.m_usRanges[i]));
                AOOutputVals[i].Text = strVal[i].ToString();//listViewChInfo.Items[i].SubItems[3].Text = strVal[i].ToString();  //moduify "Value" column
            }

            //Update tBarOutputVal
            for (int j = 0; j < iChannelTotal; j++)
            {
                if (!AvantechAOs.m_bAOValueModified[j])
                {
                    AnalogOutput.GetRangeHighLow(AvantechAOs.m_usRanges[j], out fHighVals[j], out fLowVals[j]);
                    RefreshAnalogOutputPanel(fHighVals[j], fLowVals[j],
                        AnalogOutput.GetScaledValue(AvantechAOs.m_usRanges[j], usVal[j]), j);
                    //RefreshOutputPanel(fHighVals[j], fLowVals[j], AnalogOutput.GetScaledValue(m_usRanges[j], usVal[j]));
                }
            }

            return true;
        }

        private void RefreshAnalogOutputPanel(float fHigh, float fLow, float fOutputVal, int idx)
        {
            AOHighVals[idx].Text = fHigh.ToString();
            AOLowVals[idx].Text = fLow.ToString();
            txtAOOutputVals[idx].Text = fOutputVal.ToString("0.000");// textbox refresh
            AOOutputVals[idx].Text = fOutputVal.ToString("0.000");// output label refresh
            AOTrackBarVals[idx].Value = Convert.ToInt32(AOTrackBarVals[idx].Minimum + (AOTrackBarVals[idx].Maximum - AOTrackBarVals[idx].Minimum) * (fOutputVal - fLow) / (fHigh - fLow));
        }

        private void SetAO(int idx)
        {
            AvantechAOs.m_bAOValueModified[idx] = false;// b_AOValueModified = false;
            if (!AvantechAOs.CheckControllable())
            {
                lblAOErr.Text = "-1";
                return;
            }

            Avantech.AOEnabled = false;// timer1.Enabled = false;
            float fVal, fHigh, fLow;
            if (txtAOOutputVals[idx].Text.Length == 0)
            {
                MessageBox.Show("Illegal value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }

            try
            {
                //Get range higf & low
                AnalogOutput.GetRangeHighLow(AvantechAOs.m_usRanges[idx], out fHigh, out fLow);
                if (fHigh - fLow == 0)
                {
                    MessageBox.Show("GetRangeHighLow() failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    return;
                }
                //convert output value to float
                fVal = 0.0f;
                if (txtAOOutputVals[idx].Text != null && txtAOOutputVals[idx].Text.Length > 0)
                {
                    try
                    {
                        fVal = Convert.ToSingle(txtAOOutputVals[idx].Text);
                    }
                    catch
                    {
                        System.Windows.Forms.MessageBox.Show("Invalid value: " + txtAOOutputVals[idx].Text);
                    }
                }
                if (fVal > fHigh || fVal < fLow)
                {
                    MessageBox.Show("Illegal value! Please enter the value " + fLow.ToString() + " ~ " + fHigh.ToString() + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    return;
                }
                //Set channel value
                if (AvantechAOs.m_adamSocket.AnalogOutput().SetCurrentValue(AvantechAOs.m_idxID, idx, AvantechAOs.m_usRanges[idx], fVal))
                {
                    //RefreshOutputPanel(fHigh, fLow, fVal);
                    RefreshAnalogOutputPanel(fHigh, fLow, fVal, idx);// refresh special index of analog output panel

                    // Same functionality of setting values
                    //lblAO_0High.Text = fHigh.ToString();
                    //lblAO_0Low.Text = fLow.ToString();
                    //txtAO_0Val.Text = fVal.ToString("0.000");
                    //lblAO_0Value.Text = fVal.ToString("0.000");
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
            RefreshAOData();//RefreshData();
            string strInfo = string.Format("Set output AO_{0} value done!", idx);
            MessageBox.Show(strInfo, "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

            Avantech.AOEnabled = true;//timer1.Enabled = true;
        }

        private void btnAO_0ApplyOutput_Click(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                //AvantechAOs.m_bAOValueModified[0] = false;
                //if (!AvantechAOs.CheckControllable())
                //    return;

                //// timer1.Enabled = false;
                //float fVal, fHigh, fLow;
                //if (txtAOOutputVals[0].Text.Length == 0)
                //{
                //    MessageBox.Show("Illegal value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                //    return;
                //}

                //try
                //{
                //    //Get range higf & low
                //    AnalogOutput.GetRangeHighLow(AvantechAOs.m_usRanges[0], out fHigh, out fLow);
                //    if (fHigh - fLow == 0)
                //    {
                //        MessageBox.Show("GetRangeHighLow() failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                //        return;
                //    }
                //    //convert output value to float
                //    fVal = 0.0f;
                //    if (txtAOOutputVals[0].Text != null && txtAOOutputVals[0].Text.Length > 0)
                //    {
                //        try
                //        {
                //            fVal = Convert.ToSingle(txtAOOutputVals[0].Text);
                //        }
                //        catch
                //        {
                //            System.Windows.Forms.MessageBox.Show("Invalid value: " + txtAOOutputVals[0].Text);
                //        }
                //    }
                //    if (fVal > fHigh || fVal < fLow)
                //    {
                //        MessageBox.Show("Illegal value! Please enter the value " + fLow.ToString() + " ~ " + fHigh.ToString() + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                //        return;
                //    }
                //    //Set channel value
                //    if (AvantechAOs.m_adamSocket.AnalogOutput().SetCurrentValue(AvantechAOs.m_idxID, 0, AvantechAOs.m_usRanges[0], fVal))
                //    {
                //        //RefreshOutputPanel(fHigh, fLow, fVal);
                //        RefreshAnalogOutputPanel(fHigh, fLow, fVal, 0);

                //        // Same functionality of setting values
                //        //lblAO_0High.Text = fHigh.ToString();
                //        //lblAO_0Low.Text = fLow.ToString();
                //        //txtAO_0Val.Text = fVal.ToString("0.000");
                //        //lblAO_0Value.Text = fVal.ToString("0.000");
                //    }
                //    else
                //    {
                //        MessageBox.Show("Change current value failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                //        return;
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.ToString());
                //    return;
                //}
                //RefreshAOData();//RefreshData();
                //MessageBox.Show("Set output AO_0 value done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                ////timer1.Enabled = true;
                SetAO(0);
            }
            else
            {
                MessageBox.Show("Modbus connection error!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnAO_1ApplyOutput_Click(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                SetAO(1);
            }
            else
            {
                MessageBox.Show("Modbus connection error!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnAO_2ApplyOutput_Click(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                SetAO(2);
            }
            else
            {
                MessageBox.Show("Modbus connection error!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnAO_3ApplyOutput_Click(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                SetAO(3);
            }
            else
            {
                MessageBox.Show("Modbus connection error!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnAO_4ApplyOutput_Click(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                SetAO(4);
            }
            else
            {
                MessageBox.Show("Modbus connection error!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnAO_5ApplyOutput_Click(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                SetAO(5);
            }
            else
            {
                MessageBox.Show("Modbus connection error!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnAO_6ApplyOutput_Click(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                SetAO(6);
            }
            else
            {
                MessageBox.Show("Modbus connection error!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnAO_7ApplyOutput_Click(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                SetAO(7);
            }
            else
            {
                MessageBox.Show("Modbus connection error!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnAOApplySelRange_Click(object sender, EventArgs e)
        {
            DialogResult result;
            if (!AvantechAOs.CheckControllable())
                return;
            Avantech.AOEnabled = false;//timer1.Enabled = false;

            result = MessageBox.Show("After changing range setting, you need to configure proper start-up value again!", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                bool bRet = true;
                bool i_bApplyAll = chbxAOApplyAll.Checked;
                //if (listViewChInfo.SelectedIndices.Count == 0 && !i_bApplyAll)
                //{
                //    MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                //    bRet = false;
                //}

                // if no selection, Messagebox out
                if (((!chbxAO_0Range.Checked) && (!chbxAO_1Range.Checked) && (!chbxAO_2Range.Checked) && (!chbxAO_3Range.Checked) 
                    && (!chbxAO_4Range.Checked) && (!chbxAO_5Range.Checked) && (!chbxAO_6Range.Checked) && (!chbxAO_7Range.Checked)) && !i_bApplyAll)
                {
                    MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    bRet = false;
                }
                if (bRet)
                {
                    ushort[] usRanges = new ushort[AvantechAOs.m_usRanges.Length];
                    int iChannelTotal = AvantechAOs.m_aConf.HwIoTotal[AvantechAOs.m_tmpidx];
                    ushort usVal;
                    Array.Copy(AvantechAOs.m_usRanges, 0, usRanges, 0, AvantechAOs.m_usRanges.Length);
                    if (i_bApplyAll)// all selected
                    {
                        for (int i = 0; i < usRanges.Length; i++)
                        {
                            usRanges[i] = AnalogOutput.GetRangeCode2Byte(cbxAORange.SelectedItem.ToString());
                            //// Set Channel value to 0 to be safe first when change range  (Disable this for purpose use only!!!)
                            //if (!AvantechAOs.m_adamSocket.AnalogOutput().SetCurrentValue(AvantechAOs.m_idxID, i, AvantechAOs.m_usRanges[i], 0))
                            //{
                            //    //RefreshAnalogOutputPanel(fHigh, fLow, fVal, idx);// refresh special index of analog output panel
                            //    MessageBox.Show("Set channel default value 0 failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                            //    return;
                            //}
                        }
                    }
                    else// only some of them selected
                    {
                        //for (int i = 0; i < listViewChInfo.SelectedIndices.Count; i++)
                        //{
                        //    usRanges[listViewChInfo.SelectedIndices[i]] = AnalogOutput.GetRangeCode2Byte(cbxRange.SelectedItem.ToString());
                        //}

                        for (int i = 0; i < iChannelTotal; i++)
                        {
                            if (AOChkRanges[i].Checked) // means that it is selected, otherwise skip it
                            {
                                usRanges[i] = AnalogOutput.GetRangeCode2Byte(cbxAORange.SelectedItem.ToString());
                                //// Set Channel value to 0 to be safe first when change range  (Disable this for purpose use only !!!)
                                //if (!AvantechAOs.m_adamSocket.AnalogOutput().SetCurrentValue(AvantechAOs.m_idxID, i, AvantechAOs.m_usRanges[i], 0))
                                //{
                                //    //RefreshAnalogOutputPanel(fHigh, fLow, fVal, idx);// refresh special index of analog output panel
                                //    MessageBox.Show("Set channel default value 0 failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                                //    return;
                                //}
                            }
                        }
                    }
                    
                    if (AvantechAOs.m_adamSocket.AnalogOutput().SetRanges(AvantechAOs.m_idxID, iChannelTotal, usRanges))
                    {
                        MessageBox.Show("Set ranges done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        AvantechAOs.RefreshRanges();
                        // Update Range column
                        //for (int i = 0; i < iChannelTotal; i++)
                        //    listViewChInfo.Items[i].SubItems[4].Text = AnalogOutput.GetRangeName(m_usRanges[i]).ToString();

                        // Refresh low and high range vals of AO after applying new kind of ranges
                        for (int idx = 0; idx < iChannelTotal; idx++)
                        {
                            if (AvantechAOs.m_adamSocket.AnalogOutput().GetCurrentValue(AvantechAOs.m_idxID, idx, out usVal))// m_idxID is SlotNum(its the index ID of the 5 I/O modules)
                            {
                                AnalogOutput.GetRangeHighLow(AvantechAOs.m_usRanges[idx], out AvantechAOs.m_fHighVals[idx], out AvantechAOs.m_fLowVals[idx]);
                                AvantechAOs.m_fOutputVals[idx] = AnalogOutput.GetScaledValue(AvantechAOs.m_usRanges[idx], usVal);
                                //RefreshOutputPanel(m_fHighVal[idx], m_fLowVal[idx], m_fOutputVal[idx]);// use the High, Low and Output Vals to update UI correspondingly
                                RefreshAnalogOutputPanel(AvantechAOs.m_fHighVals[idx], AvantechAOs.m_fLowVals[idx],
                                    AvantechAOs.m_fOutputVals[idx], idx);
                            }
                            else
                                AvantechAOs.StatusBar_IO += "GetValues() filed!";//this.StatusBar_IO.Text += "GetValues() filed!";
                        }
                        AvantechAOs.RefreshAoStartupValues();
                    }
                    else
                    {
                        MessageBox.Show("Set ranges failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    }

                }

            }
            Avantech.AOEnabled = true;//timer1.Enabled = true;
        }

        private void btnAOSetSafetyValue_Click(object sender, EventArgs e)
        {
            if (!AvantechAOs.CheckControllable())
                return;

            Avantech.AOEnabled = false;//timer1.Enabled = false;
            int iChannelTotal = AvantechAOs.m_aConf.HwIoTotal[AvantechAOs.m_tmpidx];
            float[] fAOSafetyVals = new float[iChannelTotal];

            for (int i = 0; i < iChannelTotal; i++)
                fAOSafetyVals[i] = AnalogOutput.GetScaledValue(AvantechAOs.m_usRanges[i], AvantechAOs.m_usAOSafetyVals[i]);

            string[] szRanges = new string[iChannelTotal];

            for (int idx = 0; idx < szRanges.Length; idx++)
                szRanges[idx] = AnalogInput.GetRangeName(AvantechAOs.m_usRanges[idx]);

            AO_FormSafetySetting AO_formSafety = new AO_FormSafetySetting(iChannelTotal, fAOSafetyVals, szRanges);
            AO_formSafety.ApplySafetyValueClick += new AO_FormSafetySetting.EventHandler_ApplySafetyValueClick(AO_FormSafety_ApplySafetyValueClick);

            AO_formSafety.ShowDialog();
            AO_formSafety.Dispose();
            AO_formSafety = null;

            Avantech.AOEnabled = true;//timer1.Enabled = true;
        }

        /// <summary>
        ///  Apply setting when user configure safety status
        /// </summary>
        /// <param name="bVal"></param>
        private void AO_FormSafety_ApplySafetyValueClick(string[] szVal)
        {
            int iChannelTotal = AvantechAOs.m_aConf.HwIoTotal[AvantechAOs.m_tmpidx];
            float fVal, fHigh, fLow;
            ushort[] usAOSafetyVals = new ushort[AvantechAOs.m_usAOSafetyVals.Length];
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

                AnalogOutput.GetRangeHighLow(AvantechAOs.m_usRanges[i], out fHigh, out fLow);

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

            if (!AvantechAOs.m_adamSocket.AnalogOutput().SetSafetyValues(AvantechAOs.m_idxID, iChannelTotal, usAOSafetyVals))
                MessageBox.Show("Set safety value failed! (Err: " + AvantechAOs.m_adamSocket.Modbus().LastError.ToString() + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);

            AvantechAOs.RefreshSafetySetting();

        }

        private void chbxAOEnableSafety_CheckedChanged(object sender, EventArgs e)
        {
            btnAOSetAsSafety.Enabled = chbxAOEnableSafety.Checked;
            btnAOSetSafetyValue.Enabled = chbxAOEnableSafety.Checked;
            if (!AvantechAOs.CheckControllable())
                return;

            if (!AvantechAOs.m_adamSocket.Configuration().OUT_SetSafetyEnable(AvantechAOs.m_idxID, chbxAOEnableSafety.Checked))
                MessageBox.Show("Set safety function failed! (Err: " + AvantechAOs.m_adamSocket.Modbus().LastError.ToString() + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);

            AvantechAOs.RefreshSafetySetting();
        }

        // Set Startup value(when power off and on again, the output value use this value
        private void btnAOSetAsStartup_Click(object sender, EventArgs e)
        {
            if (!AvantechAOs.CheckControllable())
                return;
            float fVal, fHigh, fLow;
            int iChannelTotal = AvantechAOs.m_aConf.HwIoTotal[AvantechAOs.m_tmpidx];
            ushort[] usStartupAO = new ushort[AvantechAOs.m_usStartupAO.Length];

            Avantech.AOEnabled = false;//timer1.Enabled = false;
            if (((!chbxAO_0Range.Checked) && (!chbxAO_1Range.Checked) && (!chbxAO_2Range.Checked) && (!chbxAO_3Range.Checked)
                && (!chbxAO_4Range.Checked) && (!chbxAO_5Range.Checked) && (!chbxAO_6Range.Checked) && (!chbxAO_7Range.Checked)))
            {
                MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }

            try
            {
                for (int i = 0; i < iChannelTotal; i++)
                {
                    if (AOChkRanges[i].Checked) // if it is selected
                    {
                            if (txtAOOutputVals[i].Text.Length == 0)
                            {
                                MessageBox.Show("Illegal value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                                return;
                            }

                            //Get range higf & low
                            AnalogOutput.GetRangeHighLow(AvantechAOs.m_usRanges[i], out fHigh, out fLow);
                            if (fHigh - fLow == 0)
                            {
                                MessageBox.Show("GetRangeHighLow() failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                                return;
                            }
                            //convert output value to float
                            fVal = 0.0f;
                            if (txtAOOutputVals[i].Text != null && txtAOOutputVals[i].Text.Length > 0)
                            {
                                try
                                {
                                    fVal = Convert.ToSingle(txtAOOutputVals[i].Text);
                                }
                                catch
                                {
                                    System.Windows.Forms.MessageBox.Show("Invalid value: " + txtAOOutputVals[i].Text);
                                }
                            }
                            if (fVal > fHigh || fVal < fLow)
                            {
                                MessageBox.Show("Illegal value! Please enter the value " + fLow.ToString() + " ~ " + fHigh.ToString() + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                                return;
                            }
                            
                            Array.Copy(AvantechAOs.m_usStartupAO, 0, usStartupAO, 0, AvantechAOs.m_usStartupAO.Length);
                            usStartupAO[i] = Convert.ToUInt16(65535.0f * ((fVal - fLow) / (fHigh - fLow)));
                    }
                }

                if (AvantechAOs.m_adamSocket.AnalogOutput().SetStartupValues(AvantechAOs.m_idxID, usStartupAO))
                {
                    MessageBox.Show("Set AO startup values done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    AvantechAOs.RefreshAoStartupValues();
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
            Avantech.AOEnabled = true;//timer1.Enabled = true;
        }

        private void btnAOSetAsSafety_Click(object sender, EventArgs e)// seems has some problems, need to check(not multiple selections?)
        {
            if (!AvantechAOs.CheckControllable())
                return;

            if (((!chbxAO_0Range.Checked) && (!chbxAO_1Range.Checked) && (!chbxAO_2Range.Checked) && (!chbxAO_3Range.Checked)
                && (!chbxAO_4Range.Checked) && (!chbxAO_5Range.Checked) && (!chbxAO_6Range.Checked) && (!chbxAO_7Range.Checked)))
            {
                MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }

            try
            {
                float fVal, fHigh, fLow;
                int iChannelTotal = AvantechAOs.m_aConf.HwIoTotal[AvantechAOs.m_tmpidx];
                ushort[] usAOSafetyVals = new ushort[AvantechAOs.m_usAOSafetyVals.Length];
                //Get range higf & low
                for (int i = 0; i < iChannelTotal; i++)
                {
                    if (AOChkRanges[i].Checked)// if it is selected
                    {
                        AnalogOutput.GetRangeHighLow(AvantechAOs.m_usRanges[i], out fHigh, out fLow);
                        if (fHigh - fLow == 0)
                        {
                            MessageBox.Show("GetRangeHighLow() failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                            return;
                        }
                        //convert output value to float
                        fVal = 0.0f;
                        if (txtAOOutputVals[i].Text != null && txtAOOutputVals[i].Text.Length > 0)
                        {
                            try
                            {
                                fVal = Convert.ToSingle(txtAOOutputVals[i].Text);
                            }
                            catch
                            {
                                System.Windows.Forms.MessageBox.Show("Invalid value: " + txtAOOutputVals[i].Text);
                            }
                        }
                        
                        //Array.Copy(AvantechAOs.m_usAOSafetyVals, 0, usAOSafetyVals, 0, AvantechAOs.m_usAOSafetyVals.Length);

                        usAOSafetyVals[i] = Convert.ToUInt16(65535.0f * ((fVal - fLow) / (fHigh - fLow)));

                        AvantechAOs.m_usAOSafetyVals[i] = usAOSafetyVals[i];
                    }
                }

                //Array.Copy(AvantechAOs.m_usAOSafetyVals, 0, usAOSafetyVals, 0, AvantechAOs.m_usAOSafetyVals.Length);

                if (!AvantechAOs.m_adamSocket.AnalogOutput().SetSafetyValues(AvantechAOs.m_idxID, iChannelTotal, usAOSafetyVals))
                    MessageBox.Show("Set safety value failed! (Err: " + AvantechAOs.m_adamSocket.Modbus().LastError.ToString() + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                else
                    MessageBox.Show("Set safety value done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                AvantechAOs.RefreshSafetySetting();

            }
            catch
            {
                return;
            }
            return;
        }

        private void chbxDOEnableSafety_CheckedChanged(object sender, EventArgs e)
        {
            btnDOSetSafetyValue.Enabled = chbxDOEnableSafety.Checked;
            if (!AvantechDOs.CheckControllable())
                return;

            if (!AvantechDOs.m_adamSocket.Configuration().OUT_SetSafetyEnable(AvantechDOs.m_idxID, chbxDOEnableSafety.Checked))
                MessageBox.Show("Set safety function failed! (Err: " + AvantechDOs.m_adamSocket.Modbus().LastError.ToString() + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);

            AvantechDOs.RefreshSafetySetting();
        }

        private void chbxDIO_DOEnableSafety_CheckedChanged(object sender, EventArgs e)
        {
            btnDIO_DOSetSafetyValue.Enabled = chbxDIO_DOEnableSafety.Checked;
            if (!AvantechDIOs.CheckControllable())
                return;

            if (!AvantechDIOs.m_adamSocket.Configuration().OUT_SetSafetyEnable(AvantechDIOs.m_idxID, chbxDIO_DOEnableSafety.Checked))
                MessageBox.Show("Set safety function failed! (Err: " + AvantechDIOs.m_adamSocket.Modbus().LastError.ToString() + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);

            AvantechDIOs.RefreshSafetySetting();
        }

        private void btnDOSetSafetyValue_Click(object sender, EventArgs e)
        {
            if (!AvantechDOs.CheckControllable())
                return;

            //timer1.Enabled = false;

            int iChannelTotal = AvantechDOs.m_aConf.HwIoTotal[AvantechDOs.m_tmpidx];
            DO_FormSafetySetting DO_formSafety = new DO_FormSafetySetting(iChannelTotal, AvantechDOs.m_bDOSafetyVals);
            DO_formSafety.ApplySafetyValueClick += new DO_FormSafetySetting.EventHandler_ApplySafetyValueClick(DO_FormSafety_ApplySafetyValueClick);

            DO_formSafety.ShowDialog();
            DO_formSafety.Dispose();
            DO_formSafety = null;
            //timer1.Enabled = true;
        }

        /// <summary>
        ///  Apply setting when user configure safety status
        /// </summary>
        /// <param name="bVal"></param>
        private void DO_FormSafety_ApplySafetyValueClick(bool[] bVal)
        {
            if (!AvantechDOs.m_adamSocket.DigitalOutput().SetSafetyValues(AvantechDOs.m_idxID, bVal))
                MessageBox.Show("Set safety value failed! (Err: " + AvantechDOs.m_adamSocket.Modbus().LastError.ToString() + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            else
                MessageBox.Show("Set safety value ok!", "Info");
            AvantechDOs.RefreshSafetySetting();
        }

        private void btnDIO_DOSetSafetyValue_Click(object sender, EventArgs e)
        {
            if (!AvantechDIOs.CheckControllable())
                return;

            //timer1.Enabled = false;

            int iChannelTotal = AvantechDIOs.m_aConf.HwIoTotal[AvantechDIOs.m_DOidx];

            DIO_FormSafetySetting DIO_FormSafety = new DIO_FormSafetySetting(iChannelTotal, AvantechDIOs.m_bDOSafetyVals);
            DIO_FormSafety.ApplySafetyValueClick += new DIO_FormSafetySetting.EventHandler_ApplySafetyValueClick(DIO_FormSafety_ApplySafetyValueClick);

            DIO_FormSafety.ShowDialog();
            DIO_FormSafety.Dispose();
            DIO_FormSafety = null;
            //timer1.Enabled = true;
        }

        /// <summary>
        ///  Apply setting when user configure safety status
        /// </summary>
        /// <param name="bVal"></param>
        private void DIO_FormSafety_ApplySafetyValueClick(bool[] bVal)
        {
            if (!AvantechDIOs.m_adamSocket.DigitalOutput().SetSafetyValues(AvantechDIOs.m_idxID, bVal))
                MessageBox.Show("Set safety value failed! (Err: " + AvantechDIOs.m_adamSocket.Modbus().LastError.ToString() + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            else
                MessageBox.Show("Set safety value ok!", "Info");
            AvantechDIOs.RefreshSafetySetting();
        }

        private void btnDIApplySetting_Click(object sender, EventArgs e)
        {
            uint uiWidth = 10;
            bool bDI = chkBoxDIFilterEnable.Checked;
            string strCntMin = txtDICntMin.Text;
            uiWidth = Convert.ToUInt32(strCntMin);
            if (uiWidth > AvantechDIs.DI_FILTER_WIDTH_MAX || uiWidth < AvantechDIs.DI_FILTER_WIDTH_MIN)
            {
                MessageBox.Show("Error: Illegal parameter. The range of Di filter width is " + AvantechDIs.DI_FILTER_WIDTH_MIN.ToString() + "~" + AvantechDIs.DI_FILTER_WIDTH_MAX + " (0.1ms).\nAnd the width value have to be multiple of 5.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }
            if (AvantechDIs.m_adamSocket.DigitalInput().SetDigitalFilterMiniSignalWidth(AvantechDIs.m_idxID, uiWidth, bDI))
            {
                if (uiWidth % 5 == 0)
                    MessageBox.Show("Set digital filter width done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                else
                    MessageBox.Show("Set digital filter width done!\nThe width value have to be multiple of 5.\n (" + uiWidth.ToString() + " => " + Convert.ToString(uiWidth - uiWidth % 5) + ")", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Set digital filter width failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                return;
            }
        }

        private void btnDIO_DIApplySetting_Click(object sender, EventArgs e)
        {
            uint uiWidth = 10;
            bool bDI = chkBoxDIO_DIFilterEnable.Checked;
            string strCntMin = txtDIO_DICntMin.Text;
            uiWidth = Convert.ToUInt32(strCntMin);
            if (uiWidth > AvantechDIOs.DI_FILTER_WIDTH_MAX || uiWidth < AvantechDIOs.DI_FILTER_WIDTH_MIN)
            {
                MessageBox.Show("Error: Illegal parameter. The range of Di filter width is " + AvantechDIOs.DI_FILTER_WIDTH_MIN.ToString() + "~" + AvantechDIOs.DI_FILTER_WIDTH_MAX + " (0.1ms).\nAnd the width value have to be multiple of 5.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }
            if (AvantechDIOs.m_adamSocket.DigitalInput().SetDigitalFilterMiniSignalWidth(AvantechDIOs.m_idxID, uiWidth, bDI))
            {
                if (uiWidth % 5 == 0)
                    MessageBox.Show("Set digital filter width done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                else
                    MessageBox.Show("Set digital filter width done!\nThe width value have to be multiple of 5.\n (" + uiWidth.ToString() + " => " + Convert.ToString(uiWidth - uiWidth % 5) + ")", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Set digital filter width failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                return;
            }
        }

        private void btnAIApplySelRange_Click(object sender, EventArgs e)
        {
            if (!AvantechAIs.CheckControllable())
                return;
            Avantech.AIEnabled = false;//timer1.Enabled = false;

            bool bRet = true;
            if (((!chbxAI_0Range.Checked) && (!chbxAI_1Range.Checked) && (!chbxAI_2Range.Checked) && (!chbxAI_3Range.Checked)
                && (!chbxAI_4Range.Checked) && (!chbxAI_5Range.Checked) && (!chbxAI_6Range.Checked) && (!chbxAI_7Range.Checked)
                && (!chbxAI_8Range.Checked) && (!chbxAI_9Range.Checked) && (!chbxAI_10Range.Checked) && (!chbxAI_11Range.Checked)) && !chbxAIApplyAll.Checked)
            {
                MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                bRet = false;
            }
            if (bRet)
            {
                int iChannelTotal = AvantechAIs.m_aConf.HwIoTotal[AvantechAIs.m_tmpidx];
                ushort[] usRanges = new ushort[AvantechAIs.m_usRanges.Length];
                Array.Copy(AvantechAIs.m_usRanges, 0, usRanges, 0, AvantechAIs.m_usRanges.Length);
                if (chbxAIApplyAll.Checked)
                {
                    for (int i = 0; i < usRanges.Length; i++)
                    {
                        usRanges[i] = AnalogInput.GetRangeCode2Byte(cbxAIRange.SelectedItem.ToString());
                    }
                }
                else// only some of them selected
                {
                    //for (int i = 0; i < listViewChInfo.SelectedIndices.Count; i++)
                    //{
                    //    usRanges[listViewChInfo.SelectedIndices[i]] = AnalogInput.GetRangeCode2Byte(cbxRange.SelectedItem.ToString());
                    //}
                    for(int i = 0; i < iChannelTotal; i++)
                    {
                        if(AIChkRanges[i].Checked)
                        {
                            usRanges[i] = AnalogInput.GetRangeCode2Byte(cbxAIRange.SelectedItem.ToString());
                        }
                    }
                }
                if (AvantechAIs.m_adamSocket.AnalogInput().SetRanges(AvantechAIs.m_idxID, iChannelTotal, usRanges))
                {
                    AvantechAIs.RefreshRanges();
                }
                else
                {
                    MessageBox.Show("Set ranges failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
            }
            Avantech.AIEnabled = true;//timer1.Enabled = true;
        }

        private void btnAIBurnoutFcn_Click(object sender, EventArgs e)
        {
            if (!AvantechAIs.CheckControllable())
                return;
            Avantech.AIEnabled = false;//timer1.Enabled = false;
            int iChannelTotal = AvantechAIs.m_aConf.HwIoTotal[AvantechAIs.m_tmpidx];
            if (chbxAIApplyAll.Checked)
            {               
                if (chkAIBurnoutFcn.Checked)
                    AvantechAIs.m_uiBurnoutMask = (uint)(0x1 << iChannelTotal) - 1;
                else
                    AvantechAIs.m_uiBurnoutMask = 0x0;
            }
            else
            {
                int idx = 0;
                //for (int i = 0; i < listViewChInfo.Items.Count; i++)
                //{
                //    if (listViewChInfo.Items[i].Selected)
                //    {
                //        idx = i;
                //        break;
                //    }
                //}
                for (int i = 0; i < iChannelTotal; i++)
                {
                    if (AOChkRanges[i].Checked) // means that it is selected, otherwise skip it
                    {
                        idx = i;
                        break;
                    }
                }

                uint uiMask = (uint)(0x1 << idx);
                if (chkAIBurnoutFcn.Checked)
                    AvantechAIs.m_uiBurnoutMask |= uiMask;
                else
                    AvantechAIs.m_uiBurnoutMask &= ~uiMask;
            }
            if (AvantechAIs.m_adamSocket.AnalogInput().SetBurnoutFunEnable(AvantechAIs.m_idxID, AvantechAIs.m_uiBurnoutMask))
            {
                MessageBox.Show("Set burnout enable function done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                AvantechAIs.RefreshBurnoutSetting(true, false); //refresh burnout mask value
            }
            else
                MessageBox.Show("Set burnout enable function failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            Avantech.AIEnabled = true;//timer1.Enabled = true;
        }

        private void btnAIBurnoutValue_Click(object sender, EventArgs e)
        {
            uint uiVal;
            if (cbxAIBurnoutValue.SelectedIndex == 0)
                uiVal = 0;
            else
                uiVal = 0xFFFF;
            if (!AvantechAIs.CheckControllable())
                return;
            Avantech.AIEnabled = false;//timer1.Enabled = false;
            if (AvantechAIs.m_adamSocket.AnalogInput().SetBurnoutValue(AvantechAIs.m_idxID, uiVal))
            {
                MessageBox.Show("Set burnout value done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                AvantechAIs.RefreshBurnoutSetting(false, true);     //refresh burnout detect mode
            }
            else
                MessageBox.Show("Set burnout value failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            Avantech.AIEnabled = true;//timer1.Enabled = true;
        }

        private void btnAISampleRate_Click(object sender, EventArgs e)
        {
            int iIdx = cbxAISampleRate.SelectedIndex;
            if (!AvantechAIs.CheckControllable())
                return;
            Avantech.AIEnabled = false;//timer1.Enabled = false;

            uint uiRate;

            if (AvantechAIs.m_aConf.GetModuleName() == "5017")
            {
                if (iIdx == 0)
                    uiRate = 1;
                else
                    uiRate = 10;
            }
            else //if (m_aConf.GetModuleName() == "5017H")
            {
                if (iIdx == 0)
                    uiRate = 100;
                else
                    uiRate = 1000;
            }
            if (AvantechAIs.m_adamSocket.AnalogInput().SetSampleRate(AvantechAIs.m_idxID, uiRate))
            {
                MessageBox.Show("Set sampling rate done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                AvantechAIs.RefreshAiSampleRate();
            }
            else
                MessageBox.Show("Set sampling rate failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

            Avantech.AIEnabled = true;//timer1.Enabled = true;
        }

        private void OutputTimer_Tick(object sender, EventArgs e)
        {
            int i = 0;
            bool bDORet;
            int iDOChannelTotal = AvantechDOs.m_aConf.HwIoTotal[AvantechDOs.m_tmpidx];
            bool[] DOvalues = new bool[iDOChannelTotal];

            bool bAORet;
            int iAOChannelTotal = AvantechAOs.m_aConf.HwIoTotal[AvantechAOs.m_tmpidx];
            double[] AOvalues = new double[iAOChannelTotal];
            string[] strAOvalues = new string[iAOChannelTotal];

            bool bDIORet;
            // DIO's DI Channel
            int iDIO_DIChannelTotal = AvantechDIOs.m_aConf.HwIoTotal[AvantechDIOs.m_DIidx];
            bool[] DIO_DIvalues = new bool[iDIO_DIChannelTotal];
            // DIO's DO Channel
            int iDIO_DOChannelTotal = AvantechDIOs.m_aConf.HwIoTotal[AvantechDIOs.m_DOidx];
            bool[] DIO_DOvalues = new bool[iDIO_DOChannelTotal];

            // DI 5040
            bool bDIRet;
            int iDIChannelTotal = AvantechDIs.m_aConf.HwIoTotal[AvantechDIs.m_tmpidx];
            bool[] DIvalues = new bool[iDIChannelTotal];

            // ***********DO*********** ////
            if (Avantech.DOEnabled)
            {
                cmdNETWORK.BackColor = Color.Green;
                bDORet = AvantechDOs.RefreshData(ref DOvalues);
                lblDOErr.Text = bDORet ? "0" : "-1";//lblDOErr.Text = bDORet ? "0" : "-1";
                cmdNETWORK.BackColor = Color.Gray;
                if (bDORet)
                {
                    AvantechDOs.m_iScanCount++;
                    AvantechDOs.m_iFailCount = 0;
                    for (i = 0; i < iDOChannelTotal; i++)
                    {
                        DO[i].BackColor = DOvalues[i] ? Color.Green : Color.Red;
                    }
                }
                else
                {
                    AvantechDOs.m_iFailCount++;
                }

                if (AvantechDOs.m_iFailCount > 5)
                {
                    Avantech.DOEnabled = false;//timer1.Enabled = false;
                    //OutputTimer.Enabled = false;
                    Avantech.bModbusConnected = false;
                    MessageBox.Show("Failed more than 5 times! Please check the physical connection and MODBUS address setting!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);

                }
                if (AvantechDOs.m_iScanCount % 50 == 0)
                    GC.Collect();
            }
            // ***********End of DO*********** ////



            // ***********AO*********** ////
            if (Avantech.AOEnabled)
            {
                cmdNETWORK.BackColor = Color.Green;
                bAORet = AvantechAOs.RefreshData(ref strAOvalues);
                lblAOErr.Text = bAORet ? "0" : "-1";//lblDOErr.Text = bDORet ? "0" : "-1";
                cmdNETWORK.BackColor = Color.Gray;
                if (bAORet)
                {
                    AvantechAOs.m_iScanCount++;
                    AvantechAOs.m_iFailCount = 0;
                }
                else
                {
                    AvantechAOs.m_iFailCount++;
                }

                if (AvantechAOs.m_iFailCount > 5)
                {
                    Avantech.AOEnabled = false;//timer1.Enabled = false;
                    //OutputTimer.Enabled = false;
                    Avantech.bModbusConnected = false;
                    MessageBox.Show("Failed more than 5 times! Please check the physical connection and MODBUS address setting!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                }
                if (AvantechAOs.m_iScanCount % 50 == 0)
                    GC.Collect();
            }
            // ***********End of AO*********** ////


            if (Avantech.DIOEnabled)
            {
                cmdNETWORK.BackColor = Color.Green;
                bDIORet = AvantechDIOs.Refresh_DIData(ref DIO_DIvalues);//bDIORet = AvantechDIOs.RefreshData(ref DIO_DIvalues, ref DIO_DOvalues);
                lblDIOErr.Text = bDIORet ? "0" : "-1";//lblDIOErr.Text = bDIORet ? "0" : "-1";
                cmdNETWORK.BackColor = Color.Gray;
                if (bDIORet)
                {
                    AvantechDIOs.m_iScanCount++;
                    AvantechDIOs.m_iFailCount = 0;
                    for (i = iDIChannelTotal; i < iDIChannelTotal + iDIO_DIChannelTotal; i++)
                    {
                        DI[i].BackColor = DIO_DIvalues[i - iDIChannelTotal] ? Color.Green : Color.Red;
                    }
                        //for (i = iDOChannelTotal; i < iDOChannelTotal + iDIO_DOChannelTotal; i++)
                        //{
                        //    DO[i].BackColor = DIO_DOvalues[i - iDOChannelTotal] ? Color.Green : Color.Red;
                        //}
                }
                else
                {
                    AvantechDIOs.m_iFailCount++;
                }

                if (AvantechDIOs.m_iFailCount > 5)
                {
                    Avantech.DIOEnabled = false;//timer1.Enabled = false;
                    //OutputTimer.Enabled = false;
                    Avantech.bModbusConnected = false;
                    MessageBox.Show("Failed more than 5 times! Please check the physical connection and MODBUS address setting!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);

                }
                if (AvantechDIOs.m_iScanCount % 50 == 0)
                    GC.Collect();
            }
        }

        private void chbxAIApplyAll_CheckedChanged(object sender, EventArgs e)
        {
            int iChannelTotal = AvantechAIs.m_aConf.HwIoTotal[AvantechAIs.m_tmpidx];
            for (int i = 0; i < iChannelTotal; i++)
            {
                AIChkRanges[i].Checked = chbxAIApplyAll.Checked;
            }
        }

        private void chbxAOApplyAll_CheckedChanged(object sender, EventArgs e)
        {
            int iChannelTotal = AvantechAOs.m_aConf.HwIoTotal[AvantechAOs.m_tmpidx];
            for (int i = 0; i < iChannelTotal; i++)
            {
                AOChkRanges[i].Checked = chbxAOApplyAll.Checked;
            }
        }

        private void cmdSystemSettings_Click(object sender, EventArgs e)
        {
            SystemSettingsPage systemSettingsPage = new SystemSettingsPage();
            systemSettingsPage.ShowDialog();
        }

        private void cmdSystemToDefault_Click(object sender, EventArgs e)
        {
            //LoadSystemSetting_DB();

            //// System Initialize
            //AvantechSystemInitialize();
            //if (Avantech.bModbusConnected)
            //{
            //    // Connection status
            //    txtConnection.Text = "OnLine";
            //    cmdPWR.BackColor = Color.Green;
            //    cmdIO.BackColor = Color.Green;

            //    // All IOs initialization
            //    AvantechIO_Modules_Initialize();

            //    // Testing Output Split
            //    OutputTimer.Enabled = true;

            //    try
            //    {
            //        MainThread.RunWorkerAsync();
            //        Avantech.MainThreadEnabled = true;
            //        Avantech.AIEnabled = true;
            //        Avantech.DIOEnabled = true;
            //        Avantech.DIEnabled = true;
            //        Avantech.DOEnabled = true;
            //        Avantech.AOEnabled = true;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Program already running. This instance will abort.");
            //        //if(MainThread.IsBusy==false)
            //        System.Environment.Exit(0);
            //    }
            //}
            //else
            //{
            //    txtConnection.Text = "OffLine";
            //    cmdPWR.BackColor = Color.Gray;
            //    cmdIO.BackColor = Color.Gray;

            //    // -2 means that modules not connected
            //    lblAIErr.Text = "-2";
            //    lblDIOErr.Text = "-2";
            //    lblDIErr.Text = "-2";
            //    lblDOErr.Text = "-2";
            //    lblAOErr.Text = "-2";

            //    AvantechAOs.Initialize(SystemGlobals.IP, SystemGlobals.AOSlotNum, Avantech.m_ScanTime_LocalSys[0]);//AvantechAOs.Initialize(IP, AOSlotNum, Avantech.m_ScanTime_LocalSys[0]);
            //}

            if (Avantech.bModbusConnected)
            {
                MessageBox.Show("Modbus is already connected, no need to restore to default!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                // Load System DB Settings
                LoadSystemSetting_DB();

                AvantechSystemInitialize();
                if (Avantech.bModbusConnected)
                {
                    // Connection status
                    txtConnection.Text = "OnLine";
                    cmdPWR.BackColor = Color.Green;
                    cmdIO.BackColor = Color.Green;
                    // Corresponding UI enabled
                    gbDI.Enabled = true;
                    gbDO.Enabled = true;
                    gbAO.Enabled = true;
                    gbAI.Enabled = true;
                    gbAORangeSettings.Enabled = true;
                    gbAOSafetyFunction.Enabled = true;

                    // All IOs initialization
                    AvantechIO_Modules_Initialize();

                    // Testing Output Split
                    //OutputTimer.Enabled = true;

                    try
                    {
                        //if(!MainThread.IsBusy)
                        //{
                        //    MainThread.RunWorkerAsync();
                        //}                        
                        //Avantech.MainThreadEnabled = true;
                        Avantech.AIEnabled = true;
                        Avantech.DIOEnabled = true;
                        Avantech.DIEnabled = true;
                        Avantech.DOEnabled = true;
                        Avantech.AOEnabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Program already running. This instance will abort.");
                        //if(MainThread.IsBusy==false)
                        System.Environment.Exit(0);
                    }
                }
                else
                {
                    txtConnection.Text = "OffLine";
                    cmdPWR.BackColor = Color.Gray;
                    cmdIO.BackColor = Color.Gray;

                    // -2 means that modules not connected
                    lblAIErr.Text = "-2";
                    lblDIOErr.Text = "-2";
                    lblDIErr.Text = "-2";
                    lblDOErr.Text = "-2";
                    lblAOErr.Text = "-2";

                    AvantechAOs.Initialize(SystemGlobals.IP, SystemGlobals.AOSlotNum, Avantech.m_ScanTime_LocalSys[0]);//AvantechAOs.Initialize(IP, AOSlotNum, Avantech.m_ScanTime_LocalSys[0]);
                }
            }
        }

        private void cmdCouplerInformation_Click(object sender, EventArgs e)
        {
            CouplerInformation couplerInformation = new CouplerInformation();
            couplerInformation.ShowDialog();
        }
    }
}

   
    
      
  

