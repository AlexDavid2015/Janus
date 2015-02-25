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
                    Thread.Sleep(200);
                    MotorControls.oHyperTerminalAdapter.Write(txtCommand.Text + "\r");
                    Thread.Sleep(500);
                    string x = MotorControls.oHyperTerminalAdapter.Read();
                    //oHyperTerminalAdapter.Disconnect();
                    //MessageBox.Show("Result of the command was: " + x); 
                }
            }
        }
    }
}
