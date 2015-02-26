using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {

        }

        private void txtCommand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (string.IsNullOrEmpty(txtCommand.Text))
                {
                    return;
                }
                else
                {
                    //HyperTerminalAdapter oHyperTerminalAdapter = new HyperTerminalAdapter();
                    //oHyperTerminalAdapter.Connect();
                    SystemGlobals.objMagazinePage.TimerStates.Enabled = false;// Disable TimeRecv flow
                    string command = "@01" + txtCommand.Text + "\r";
                    MotorControls.oHyperTerminalAdapter.Write(command);// Input pure standalone language
                    Thread.Sleep(20);
                    string strRecv = "";
                    MotorControls.oHyperTerminalAdapter.Read(ref strRecv);
                    txtTerminalPage.AppendText("> @01" + txtCommand.Text + "\r\n" + "< " + strRecv + "\n");
                    txtCommand.Text = "";
                    SystemGlobals.objMagazinePage.TimerStates.Enabled = true;// Enable TimeRecv flow
                    //oHyperTerminalAdapter.Disconnect();
                }
            }
        }
    }
}
