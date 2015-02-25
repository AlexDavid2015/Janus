using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms; // temp use during debug 
using Microsoft.SqlServer.Server;

namespace CxTitan
{
    public class HyperTerminalAdapter
    {
        public SerialPort oSerialPort = new SerialPort();

        // Allow the user to set the appropriate properties.
        public int BaudRate = 9600;
        public int DataBits = 8;
        public int ReadTimeout = 2000;
        public int WriteTimeout = 2000;
        public string PortName = "COM5";
        public int COMID = 5;
        public string Handshake = "";
        public string Name = "user";
        public string DataReceived = "";
        public string sParity = "none";
        public int iStopBits = 1;

        public HyperTerminalAdapter()
        {
            this.Configure();
        }

        public void Configure()
        {
            oSerialPort.PortName = this.PortName;
            oSerialPort.BaudRate = this.BaudRate;
            oSerialPort.DataBits = this.DataBits;
            oSerialPort.ReadTimeout = this.ReadTimeout;
            oSerialPort.WriteTimeout = this.WriteTimeout;

            oSerialPort.Handshake = System.IO.Ports.Handshake.None;

            if(this.sParity == "even"){ 
                oSerialPort.Parity = Parity.Even; 
            }else if(this.sParity == "odd"){ 
                oSerialPort.Parity = Parity.Odd; 
            }else if(this.sParity == "mark"){ 
                oSerialPort.Parity = Parity.Mark; 
            }else if(this.sParity == "space"){ 
                oSerialPort.Parity = Parity.Space; 
            } else { 
                oSerialPort.Parity = Parity.None; 
            } 

            if(this.iStopBits == 0){ 
                oSerialPort.StopBits = StopBits.None; 
            }else if(this.iStopBits == 1.5){ 
                oSerialPort.StopBits = StopBits.OnePointFive; 
            }else if(this.iStopBits == 2){ 
                oSerialPort.StopBits = StopBits.Two; 
            } else { 
                oSerialPort.StopBits = StopBits.One; 
            } 

            MessageBox.Show("Serial port" + PortName + " Configured");
        }

        public bool Connect() 
        { 
            try { 
                if (!oSerialPort.IsOpen) { 
                    oSerialPort.Open(); 
                    MessageBox.Show("Serial port " + PortName + " Connected");
                    return true;
                } // else already open
                else
                {
                    return false;
                }
            } catch (Exception ex) {  
                    MessageBox.Show("Error: Connection is in use or is not available: \n\n" + ex);
                    return false;
            } 
        }

        public void Disconnect() 
        { 
            try{ 
                if (oSerialPort.IsOpen) { 
                    oSerialPort.Close(); 
                    MessageBox.Show("Disconnected"); 
                } //else not open 
            } catch { } 
        } 

        public void Write(string sData /* string data to write to the port */ ) 
        { 
            if (oSerialPort.IsOpen) 
            { 
                try 
                { 
                    oSerialPort.WriteLine(sData); 
                    //MessageBox.Show("Command Issued: " + sData); 
                } catch { } 
            } 
        } 

        public string Read() 
        { 
            try 
            { 
                this.DataReceived = oSerialPort.ReadLine().ToString(); 
                MessageBox.Show(this.DataReceived); 
                return (this.DataReceived); 
            } 
            catch 
            { 
                return ""; 
            } 
        } 
    }
}
