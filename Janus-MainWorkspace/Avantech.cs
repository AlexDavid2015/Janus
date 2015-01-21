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
    public static class Avantech
    {
        // Global object
        public static AdamSocket m_adamModbusSocket;
        public static int[] m_ScanTime_LocalSys;
        public static int[] m_iTimeout;
        public static string m_szIP = "";
        public static string[] m_szSlotInfo;

        public static ArrayList m_adamList_Group;
        public static AdamInformation adamObject;
        public static string m_sDSPFWVer;

        public static int IDX_SWITCHID = 0;
        public static int IDX_MODULENAME = 1;
        public static int IDX_ADDRESSTYPE = 2;
        public static int IDX_STARTADDRESS = 3;
        public static int IDX_LENGTH = 4;


        // Temporary
        public static bool panelFSVSetting;
        public static bool chbxEnCommFSV = true;
        public static string txtCommFSVtimeout = ""; //Communication IO FSV Timeout
        // End of Temporary


        // variables in RefreshConfiguration
        public static string labModuleName = "";
        public static string txtFwVer = "";
        public static string txtFwVer2 = "";
        public static string txtFpgaFwVer = "";
        public static string txtDeviceName = "";
        public static string txtDeviceDesc = "";
        public static string txtMacAddress = "";
        public static string txtIPAddress = "";
        public static string txtSubnetAddress = "";
        public static string txtDefaultGateway = "";
        public static string numHostIdle = "";
        // End of variables in RefreshConfiguration

        public static bool bModbusConnected;// indicate modbus connection status
        public static bool MainThreadEnabled = false;
        public static bool APAX5017H_AIEnabled = false;
        public static bool APAX5045_DIOEnabled = false;
        public static bool APAX5040_DIEnabled = false;
        public static bool APAX5046_DOEnabled = false;
        public static bool APAX5028_AOEnabled = false;

        public static bool AIEnabled
        {
            get { return APAX5017H_AIEnabled; }
            set { APAX5017H_AIEnabled = value; }
        }

        public static bool DIOEnabled
        {
            get { return APAX5045_DIOEnabled; }
            set { APAX5045_DIOEnabled = value; }
        }

        public static bool DIEnabled
        {
            get { return APAX5040_DIEnabled; }
            set { APAX5040_DIEnabled = value; }
        }

        public static bool DOEnabled
        {
            get { return APAX5046_DOEnabled; }
            set { APAX5046_DOEnabled = value; }
        }

        public static bool AOEnabled
        {
            get { return APAX5028_AOEnabled; }
            set { APAX5028_AOEnabled = value; }
        }

        public static void ScanTimeInitialize()
        {
            //// scan timer init
            //m_ScanTime_LocalSys = new int[1];
            //m_ScanTime_LocalSys[0] = 1000;
            //m_adamModbusSocket = null;
            //m_iTimeout = new int[3];
            //m_iTimeout[0] = 2000;// Connection Timeout     
            //m_iTimeout[1] = 2000; // Send Timeout
            //m_iTimeout[2] = 2000;// Receive Timeout

            // scan timer init
            m_ScanTime_LocalSys = new int[1];
            m_ScanTime_LocalSys[0] = SystemGlobals.ScanTime;
            m_adamModbusSocket = null;
            m_iTimeout = new int[3];
            m_iTimeout[0] = SystemGlobals.ConnectionTimeOut;// Connection Timeout
            m_iTimeout[1] = SystemGlobals.SendTimeOut; // Send Timeout
            m_iTimeout[2] = SystemGlobals.ReceiveTimeOut;// Receive Timeout
        }

        /// <summary>
        /// Refresh Coupler IP address and IO modules


        /// <summary>
        /// Pop window to set IP address
        public static void SetIPAddress(string strIP)
        {
            m_szIP = strIP;
        }

        // Show Wait Msg
        public static void ShowWaitMsg()
        {
            Wait_Form FormWait = new Wait_Form();
            FormWait.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            FormWait.Start_Wait(3000);
            FormWait.ShowDialog();
            FormWait.Dispose();
            FormWait = null;
        }

        /// <summary>
        /// Refresh Current I/O Modules at this APAX controller
        /// </summary>
        /// <param name="dsInfo">I/O Module description</param>
        public static void RefreshCurrentModuleInfo()
        {

            try
            {

                ListViewItem[] listItemModule = new ListViewItem[m_szSlotInfo.Length];

                //listViewDescription.BeginUpdate();
                //listViewDescription.Items.Clear();

                for (int i = 0; i < m_szSlotInfo.Length; i++)
                {
                    listItemModule[i] = new ListViewItem(i.ToString());
                    listItemModule[i].SubItems.Add(m_szSlotInfo[i]);
                    //listViewDescription.Items.Add(listItemModule[i]);

                }

                //listViewDescription.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        /// <summary>
        /// Refresh Modbus Address type and value
        /// </summary>
        public static void RefreshModbusAddressSetting()
        {
            try
            {
                if (m_adamModbusSocket.Connect(m_adamModbusSocket.GetIP(), ProtocolType.Tcp, 502))
                {
                    bool bFixed;
                    m_adamModbusSocket.Configuration().GetModbusAddressMode(out bFixed);
                    string[] szAddressType = new string[m_szSlotInfo.Length];
                    string[] szLength = new string[m_szSlotInfo.Length];
                    string[] szStartAddress = new string[m_szSlotInfo.Length];

                    //Update Modbus Address Setting tab
                    ListViewItem[] listItemModule = new ListViewItem[m_szSlotInfo.Length];
                    for (int i = 0; i < m_szSlotInfo.Length; i++)
                    {
                        listItemModule[i] = new ListViewItem(i.ToString());
                        if (m_szSlotInfo[i] != null)
                        {
                            listItemModule[i].SubItems.Add("APAX-" + m_szSlotInfo[i]);
                        }
                        else
                        {
                            listItemModule[i].SubItems.Add("Empty");
                        }
                        listItemModule[i].SubItems.Add("");
                        listItemModule[i].SubItems.Add("");
                        listItemModule[i].SubItems.Add("");
                        //gvAddress.Items.Add(listItemModule[i]);
                    }

                    if (bFixed)
                    {
                        //addressTypeValue.Text = "Fixed Mode";
                        for (int i = 0; i < m_szSlotInfo.Length; i++)
                        {
                            if (m_szSlotInfo[i] != null)
                            {
                                Apax5000Config apaxConfig = null;
                                int iTemp;
                                m_adamModbusSocket.Configuration().GetModuleConfig(i, out apaxConfig);
                                if (apaxConfig.wDevType == 0x0001 || apaxConfig.wDevType == 0x0002)
                                {
                                    szLength[i] = Convert.ToString(64);
                                    iTemp = 64 * i + 1;
                                    szAddressType[i] = "0X";
                                }
                                else
                                {
                                    szLength[i] = Convert.ToString(32);
                                    iTemp = 32 * i + 1;
                                    szAddressType[i] = "4X";
                                }
                                szStartAddress[i] = iTemp.ToString();
                            }
                            else
                            {
                                szAddressType[i] = "0X";
                                szStartAddress[i] = (0).ToString();
                                szLength[i] = (0).ToString();
                            }
                        }
                    }
                    else
                    {
                        int[] o_iData;
                        //addressTypeValue.Text = "Flexible Mode";
                        m_adamModbusSocket.Modbus().ReadAdvantechRegs(60101, 64, out o_iData);
                        for (int i = 0; i < m_szSlotInfo.Length; i++)
                        {

                            int iStartAddress = o_iData[i * 2] % 10000;
                            if (o_iData[i * 2] / 40000 == 1)
                                szAddressType[i] = "4X";
                            else
                                szAddressType[i] = "0X";
                            szStartAddress[i] = iStartAddress.ToString();
                            szLength[i] = o_iData[i * 2 + 1].ToString();
                        }
                    }
                    //UpdateInfoString(IDX_STARTADDRESS, szStartAddress);
                    //UpdateInfoString(IDX_ADDRESSTYPE, szAddressType);
                    //UpdateInfoString(IDX_LENGTH, szLength);
                }

            }
            catch
            {
                MessageBox.Show("Initialize UI Modbus address setting failed.", "Error");
            }
            m_adamModbusSocket.Disconnect();

        }

        /// <summary>
        /// Refresh Modbus Address row value
        /// </summary>
        /// <param name="idxColumn"></param>
        /// <param name="szString"></param>
        public static void UpdateInfoString(int idxColumn, string[] szString)
        {
            for (int idxRow = 0; idxRow < m_szSlotInfo.Length; idxRow++)
            {
                //if (szString[idxRow] != null)
                //    gvAddress.Items[idxRow].SubItems[idxColumn].Text = szString[idxRow];
            }
        }

        /// <summary>
        /// Refresh Fail Safe Value Setting
        /// </summary>
        public static void RefreshFSVSettingInfo()
        {
            int[] o_iData;
            AdamSocket adamSocket = new AdamSocket(AdamType.Apax5070);

            if (adamSocket.Connect(m_szIP, ProtocolType.Tcp, 502))
            {
                if (adamSocket.Modbus().ReadAdvantechRegs(60004, 2, out o_iData)) //60004 is to read platform (AXIS) FW version
                {
                    if (0x0a == (o_iData[0] >> 12)) //check 'a' of 0xa105
                    {
                        if (0x105 > (o_iData[0] & 0x0FFF))
                            panelFSVSetting = false;//panelFSVSetting.Visible = false; //AXIS fw version under 105 not support set communication IO FSV, so invisible
                        else
                        { //fw version greater than 0x105 (include 0x105)
                            if (adamSocket.Modbus().ReadAdvantechRegs(60301, 2, out o_iData)) //Communication IO FSV Setting
                            {
                                if (0x01 == o_iData[0]) //Communication IO FSV enable
                                {
                                    chbxEnCommFSV = true;
                                    //txtCommFSVtimeout.Enable= true;
                                    txtCommFSVtimeout = o_iData[1].ToString();//txtCommFSVtimeout.Text = o_iData[1].ToString(); //Communication IO FSV Timeout
                                }
                                else
                                    chbxEnCommFSV = false;//chbxEnCommFSV.Checked = false;
                            }
                        }
                    }
                }
                else
                    panelFSVSetting = false;//panelFSVSetting.Visible = false;
            }

            adamSocket.Disconnect();
            adamSocket = null;
        }

        /// <summary>
        /// Init APAX controller information
        /// </summary>
        /// <returns></returns>
        public static bool RefreshConfiguration()
        {
            //Query device information and network informations
            if (AdamSocket.GetAdamDeviceList(m_szIP, 2000, out m_adamList_Group))
            {
                adamObject = (AdamInformation)m_adamList_Group[0];
            }
            else
            {
                MessageBox.Show("Get module information failed!", "Error");
            }
            //APAX Coupler Information
            labModuleName = "APAX-PAC";
            txtFwVer = string.Format("{0:X2}.{1:X2}", adamObject.FwVer[0], adamObject.FwVer[1]);//this.txtFwVer.Text = string.Format("{0:X2}.{1:X2}", adamObject.FwVer[0], adamObject.FwVer[1]);  //Firmware Version
            txtFwVer2 = m_sDSPFWVer.Substring(0, 4).Insert(2, ".");//this.txtFwVer2.Text = m_sDSPFWVer.Substring(0, 4).Insert(2, ".");                               //Kernel Firmware Version

            if (m_adamModbusSocket.Connect(AdamType.Apax5070, m_szIP, ProtocolType.Udp))            //FPGA Firmware Version
            {
                uint o_dwVer;
                if (m_adamModbusSocket.Configuration().GetFpgaVersion(out o_dwVer))
                    txtFpgaFwVer = o_dwVer.ToString("X4").Insert(2, ".");//this.txtFpgaFwVer.Text = o_dwVer.ToString("X4").Insert(2, ".");
            }

            m_adamModbusSocket.Disconnect();
            txtDeviceName = adamObject.DeviceName;
            txtDeviceDesc = adamObject.Description;
            RefreshCurrentModuleInfo(); //Current modules information
            //Network information
            txtMacAddress = string.Format("{0:X02}-{1:X02}-{2:X02}-{3:X02}-{4:X02}-{5:X02}",   //MAC address
                adamObject.Mac[0], adamObject.Mac[1],
                adamObject.Mac[2], adamObject.Mac[3],
                adamObject.Mac[4], adamObject.Mac[5]);
            txtIPAddress = string.Format("{0}.{1}.{2}.{3}",    //IP address
                adamObject.IP[0], adamObject.IP[1], adamObject.IP[2], adamObject.IP[3]);
            txtSubnetAddress = string.Format("{0}.{1}.{2}.{3}",    //subnet mask
                adamObject.Subnet[0], adamObject.Subnet[1], adamObject.Subnet[2], adamObject.Subnet[3]);
            txtDefaultGateway = string.Format("{0}.{1}.{2}.{3}",    //default gateway
                adamObject.Gateway[0], adamObject.Gateway[1], adamObject.Gateway[2], adamObject.Gateway[3]);
            numHostIdle = adamObject.HostIdleTime.ToString();

            // Refresh Modbus address mapping
            RefreshModbusAddressSetting();
            // Refresh FSV settings
            RefreshFSVSettingInfo();

            return true;
        }

        /// <summary>
        /// Refresh I/O modules of this controller and show controller information
        /// </summary>
        /// <param name="e"></param>
        public static void AfterSelect_CouplerDevice(TreeNode e)
        {
            TreeNode adamNode;

            m_adamModbusSocket = new AdamSocket(AdamType.Apax5070);
            m_adamModbusSocket.SetTimeout(m_iTimeout[0], m_iTimeout[1], m_iTimeout[2]);
            if (m_adamModbusSocket.Connect(AdamType.Apax5070, m_szIP, ProtocolType.Tcp))
            {
                bModbusConnected = true;
                if (m_adamModbusSocket.RefreshIOInfo())
                {
                    ThreadStart newStart = new ThreadStart(ShowWaitMsg);
                    Thread waitThread = new Thread(ShowWaitMsg);
                    waitThread.Start();
                    //ShowWaitMsg();
                    m_adamModbusSocket.Configuration().GetSlotInfo(out m_szSlotInfo);
                    //
                    //treeView1.BeginUpdate();
                    e.Nodes.Clear();
                    for (int iCnt = 0; iCnt < m_szSlotInfo.Length; iCnt++)
                    {
                        if (m_szSlotInfo[iCnt] != null)
                        {
                            adamNode = new TreeNode(m_szSlotInfo[iCnt] + "(S" + iCnt.ToString() + ")");
                            adamNode.Tag = (byte)iCnt;
                            e.Nodes.Add(adamNode);
                        }
                    }
                    e.ExpandAll();
                    //treeView1.EndUpdate();
                    m_adamModbusSocket.GetDSPFWVer(ref m_sDSPFWVer);
                    m_adamModbusSocket.Disconnect();
                }
            }
            else
            {
                bModbusConnected = false;
                MessageBox.Show("Connection error ( Err : " + m_adamModbusSocket.LastError.ToString() + " ). Please check the network setting.", "Error");
                m_adamModbusSocket.Disconnect();
                m_adamModbusSocket = null;
                return;

            }

            RefreshConfiguration();
            m_adamModbusSocket = null;
        }

        /// <summary>
        /// When select any I/O Modules, show related APAX I/O module at rignt Form
        /// </summary>
        /// <param name="e"></param>
        public static void AfterSelect_CouplerSlot(TreeNode e)
        {
            int iSlot;
            int iCmpLength = 4;
            iSlot = Convert.ToInt32(e.Tag);
            if ((MessageBox.Show("Do you want to demo APAX-" + e.Text + "?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No))
            {
                return;
            }

            Form apaxModule;
            if ((string.Compare(e.Text, 0, "5013", 0, iCmpLength) == 0))
            {
                //apaxModule = new Form_APAX_5013(m_szIP, ((byte)(iSlot)), m_ScanTime_LocalSys[0]);
            }
            else if ((string.Compare(e.Text, 0, "5017H", 0, (iCmpLength + 1)) == 0))
            {
                //apaxModule = new Form_APAX_5017H(m_szIP, ((byte)(iSlot)), m_ScanTime_LocalSys[0]);
                //apaxModule.ShowDialog();
            }
            else if ((string.Compare(e.Text, 0, "5017", 0, iCmpLength) == 0))
            {
                //apaxModule = new Form_APAX_5017(m_szIP, ((byte)(iSlot)), m_ScanTime_LocalSys[0]);
            }
            else if ((string.Compare(e.Text, 0, "5018", 0, iCmpLength) == 0))
            {
                //apaxModule = new Form_APAX_5018(m_szIP, ((byte)(iSlot)), m_ScanTime_LocalSys[0]);
            }
            else if ((string.Compare(e.Text, 0, "5028", 0, iCmpLength) == 0))
            {
                //apaxModule = new Form_APAX_5028(m_szIP, ((byte)(iSlot)), m_ScanTime_LocalSys[0]);
            }
            else if ((string.Compare(e.Text, 0, "5040", 0, iCmpLength) == 0))
            {
                //apaxModule = new Form_APAX_5040(m_szIP, ((byte)(iSlot)), m_ScanTime_LocalSys[0]);
            }
            else if ((string.Compare(e.Text, 0, "5045", 0, iCmpLength) == 0))
            {
                //apaxModule = new Form_APAX_5045(m_szIP, ((byte)(iSlot)), m_ScanTime_LocalSys[0]);
            }
            else if ((string.Compare(e.Text, 0, "5046", 0, iCmpLength) == 0))
            {
                //apaxModule = new Form_APAX_5046(m_szIP, ((byte)(iSlot)), m_ScanTime_LocalSys[0]);
            }
            else if ((string.Compare(e.Text, 0, "5060", 0, iCmpLength) == 0))
            {
                //apaxModule = new Form_APAX_5060(m_szIP, ((byte)(iSlot)), m_ScanTime_LocalSys[0]);
            }
            else if ((string.Compare(e.Text, 0, "5080", 0, iCmpLength) == 0))
            {
                //apaxModule = new Form_APAX_5080(m_szIP, ((byte)(iSlot)), m_ScanTime_LocalSys[0]);
            }
            else if ((string.Compare(e.Text, 0, "5082", 0, iCmpLength) == 0))
            {
                //apaxModule = new Form_APAX_5082(m_szIP, ((byte)(iSlot)), m_ScanTime_LocalSys[0]);
            }
            else
            {
                MessageBox.Show(("Not support APAX"
                                + (e.Text + " module")), "Error");
                return;
            }
            //apaxModule.ShowDialog();

            GC.Collect();
        }

        /// <summary>
        /// Select tree items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void treeView1_AfterSelect(TreeNode node)
        {
            if ((string.Compare(node.Text, "Ethernet") != 0) && (m_szIP != ""))
            {
                if (string.Compare(node.Text, m_szIP) == 0)// 'Coupler' node
                    AfterSelect_CouplerDevice(node);
                else// 'Slot' node
                    AfterSelect_CouplerSlot(node);
            }
        }

        //private void chbxEnCommFSV_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chbxEnCommFSV.Checked)
        //        txtCommFSVtimeout.Enabled = true;
        //    else
        //        txtCommFSVtimeout.Enabled = false;
        //}



        //private void btnSetCommFSV_Click(object sender, EventArgs e)
        //{
        //    int[] iData = new int[1];
        //    AdamSocket adamSocket = new AdamSocket(AdamType.Apax5070);
        //    int iAddr = 60301; //Communication IO FSV Setting

        //    if (chbxEnCommFSV.Checked)
        //        iData[0] = 0x01;
        //    else
        //        iData[0] = 0x00;

        //    if (adamSocket.Connect(this.txtIPAddress.Text, ProtocolType.Tcp, 502))
        //    {
        //        if (adamSocket.Modbus().WriteAdvantechRegs(iAddr, iData))
        //        {
        //            if (chbxEnCommFSV.Checked)
        //            {
        //                try
        //                {
        //                    iData[0] = Convert.ToInt32(txtCommFSVtimeout.Text);

        //                    if ((1 > iData[0]) || (65535 < iData[0]))
        //                    {
        //                        MessageBox.Show("Input value not acceptable,\nplease enter value from 1~65535");
        //                        return;
        //                    }

        //                    iAddr = 60302; //Communication IO FSV Timeout
        //                    if (adamSocket.Modbus().WriteAdvantechRegs(iAddr, iData))
        //                        MessageBox.Show("Set Communication FSV Done.");
        //                    else
        //                        MessageBox.Show("Set Communication FSV failed.");
        //                }
        //                catch
        //                {
        //                    MessageBox.Show("Input fromat not correct,\nplease enter value from 1~65535");
        //                }
        //            }
        //            else
        //            {
        //                txtCommFSVtimeout.Enabled = false;

        //                iAddr = 60302; //Communication IO FSV Timeout
        //                if (adamSocket.Modbus().WriteAdvantechRegs(iAddr, iData))
        //                    MessageBox.Show("Set Communication FSV Done.");
        //                else
        //                    MessageBox.Show("Set Communication FSV failed.");
        //            }

        //        }
        //        else
        //            MessageBox.Show("Set Communication FSV Setting failed.");
        //    }

        //    adamSocket.Disconnect();
        //    adamSocket = null;
        //}
    }
}
