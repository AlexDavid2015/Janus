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
    public partial class MagTerminalPage : Form
    {
        public MagTerminalPage()
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

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Terminal Text Files (*.txt)|*.txt";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.Title = "Save Terminal Text As";
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

        private void txtCommand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (MotorControls.IsMotorSerialInitialized)// Motor Serial Port is open
                {
                    if (string.IsNullOrEmpty(txtCommand.Text))
                    {
                        return;
                    }
                    else
                    {
                        //HyperTerminalAdapter oHyperTerminalAdapter = new HyperTerminalAdapter();
                        //oHyperTerminalAdapter.Connect();
                        SystemGlobals.objMagazinePage.TimerStates.Enabled = false; // Disable TimeRecv flow
                        string command = "@0" + Convert.ToInt32(txtID.Text) + txtCommand.Text + "\r";
                        MotorControls.oHyperTerminalAdapter.Write(command); // Input pure standalone language
                        Thread.Sleep(20);
                        string strRecv = "";
                        MotorControls.oHyperTerminalAdapter.Read(ref strRecv);
                        if (string.IsNullOrEmpty(strRecv))
                        {
                            txtTerminalPage.AppendText("> @0" + Convert.ToInt32(txtID.Text) + txtCommand.Text + "\r\n" + "<NO REPLY!" + "\n");
                        }
                        else
                        {
                            txtTerminalPage.AppendText("> @0" + Convert.ToInt32(txtID.Text) + txtCommand.Text + "\r\n" + "< " + strRecv + "\n");
                        }
                        txtCommand.Text = "";
                        SystemGlobals.objMagazinePage.TimerStates.Enabled = true; // Enable TimeRecv flow
                        //oHyperTerminalAdapter.Disconnect();
                    }
                }
                else// Motor Port is not open
                {
                    string commandError = "Com Port Error";
                    txtTerminalPage.AppendText("> @0" + MotorControls.DeviceId + txtCommand.Text + "\r\n" + "< " + commandError + "\n");
                    txtCommand.Text = "";
                }
            }
        }

        private void MagTerminalPage_Load(object sender, EventArgs e)
        {
            txtID.Text = Convert.ToString(MotorControls.DeviceId);
        }
    }
}
