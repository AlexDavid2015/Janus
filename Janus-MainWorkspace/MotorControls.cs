﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CxTitan
{
    public static class MotorControls
    {
        //private static string sdeviceStr;
        //public static bool bRunMode = false, bComStatus, bUpdatePar, bparChanged, bAutoHoming, bMoving;
        //private static string error = "";
        //public static int iHSpeed;
        //public static int iLSpeed;
        //public static int iAccel;

        //public static bool ConnectMotor()
        //{
        //    bool bSuccess = false;
        //    if (bRunMode)
        //    {
        //        if (sdeviceStr == "sde01")
        //            return true;
        //        if (GetDeviceList().ToUpper().Equals("SDE01"))
        //        {
        //            sdeviceStr = "sde01";
        //            Ok_Alias(ref bSuccess);
        //            if (bSuccess)
        //            {
        //                bSuccess = false;
        //                DownloadSetting(ref bSuccess);
        //            }
        //            GetStoredValues();
        //            bSuccess = true;
        //        }
        //    }
        //    return bSuccess;
        //}

        //public static string GetDeviceList()
        //{
        //    Performax.modPerformax.hUSBDevice = Performax.modPerformax.INVALID_HANDLE_VALUE;

        //    int DevNum = 0;
        //    byte[] DevStr = new byte[5];
        //    //unchecked { DevStr = (byte)Performax.modPerformax.PERFORMAX_MAX_DEVICE_STRLEN; }
        //    string NewDevStr = "", tempStr;
        //    //object i;
        //    short j = 0;

        //    Performax.modPerformax.Status = Performax.modPerformax.fnPerformaxComGetNumDevices(ref DevNum);

        //    if (Performax.modPerformax.Status.ToString().Equals("1"))
        //    {
        //        for (int i = 0; i < DevNum; i++)
        //        {
        //            Performax.modPerformax.Status = Performax.modPerformax.fnPerformaxComGetProductString(i, ref DevStr[0], Performax.modPerformax.PERFORMAX_RETURN_SERIAL_NUMBER);
        //            NewDevStr = System.Text.ASCIIEncoding.ASCII.GetString(DevStr);

        //            if (NewDevStr.ToUpper().Equals("SDE01"))
        //            {
        //                tempStr = i.ToString();
        //                //NewDevStr = NewDevStr + " , Index=" + tempStr;
        //                //DeviceList.Items.Insert(j, NewDevStr);
        //                j++;
        //            }
        //        }
        //        return (j > 0) ? NewDevStr : "";
        //    }
        //    else
        //        return "";
        //}

        //public static void Ok_Alias(ref bool isOk)
        //{
        //    int deviceIndex;
        //    deviceIndex = (int)Performax.modPerformax.hUSBDevice;
        //    Performax.modPerformax.Status = Performax.modPerformax.fnPerformaxComSetTimeouts(5000, 5000);
        //    Performax.modPerformax.Status = Performax.modPerformax.fnPerformaxComOpen(0, ref deviceIndex);
        //    Performax.modPerformax.hUSBDevice = deviceIndex;

        //    if (Performax.modPerformax.Status.ToString().Equals("0"))
        //    {
        //        ShowError("Error opening device. Application is aborting. Reset hardware and try again.");
        //        return;
        //    }
        //    //MainControlStart();
        //    bUpdatePar = false;
        //    bparChanged = false;
        //    bComStatus = true;
        //    if (bComStatus == false) return;
        //    isOk = true;
        //}

        //public static void ShowError(string Message)
        //{
        //    MessageBox.Show(Message, "Error in Dispenser");
        //    DisconnectMotor();
        //}

        //public static void DisconnectMotor()
        //{
        //    try
        //    {
        //        Performax.modPerformax.fnPerformaxComClose((int)Performax.modPerformax.hUSBDevice);
        //        sdeviceStr = "";
        //    }
        //    catch { MessageBox.Show("Could'nt Disconnect the Motor."); }
        //}

        //public static void DownloadSetting(ref bool isOk)
        //{
        //    string sReplyStr;

        //    if (!bComStatus)
        //    {
        //        ShowError("Communication not open");
        //        return;
        //    }

        //    SendReceive("ABORT");
        //    sReplyStr = Convert.ToString(SendReceive("EO=1"));
        //    sReplyStr = Convert.ToString(SendReceive("INC"));
        //    sReplyStr = Convert.ToString(SendReceive("SLOAD=0"));
        //    //SetPolarity();
        //    sReplyStr = Convert.ToString(SendReceive("DL=0"));
        //    sReplyStr = Convert.ToString(SendReceive("MM=1"));

        //    bComStatus = true;
        //}

        //public static void SetSpeedAccel()
        //{
        //    string sCmdStr;

        //    sCmdStr = "HSPD=" + iHSpeed.ToString();
        //    SendReceive(sCmdStr);

        //    sCmdStr = "LSPD=" + iLSpeed.ToString();
        //    SendReceive(sCmdStr);

        //    sCmdStr = "ACC=" + iAccel.ToString();
        //    SendReceive(sCmdStr);
        //}

        //public static string SendReceive(string command)
        //{
        //    string sResponse = "";
        //    int i, ret;
        //    try
        //    {
        //        if (!bComStatus)
        //        {
        //            sResponse = "0";
        //            return sResponse;
        //        }
        //        ret = (int)Performax.modPerformax.PerformaxSendGetReply(ref command, ref sResponse);
        //        if (ret < 0)
        //        {
        //            bComStatus = false; ShowError("Communication not open");
        //        }
        //        sResponse = sResponse.Remove(0, 3);
        //        i = sResponse.Length;
        //        if (i == 0)
        //        {
        //            if (!command.Contains("SA"))
        //            {
        //                bComStatus = false; ShowError("Send Receive Error");//Error();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ShowError("Send Receive Exception");
        //    }
        //    return sResponse;
        //}

        //public static void GetStoredValues()
        //{

        //}

        //public static int BitAND(int val1, int val2)
        //{
        //    return Performax.modPerformax.BitAND(ref val1, ref val2);
        //}
    }
}