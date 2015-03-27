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
    public partial class MagVariablesPage : Form
    {
        TextBox[] txtVariables = new TextBox[100];// 100 variables (V0 to V99)
        public MagVariablesPage()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            TimerVariableStates.Enabled = false;
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

        private void txtCommand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (MotorControls.IsMotorSerialInitialized)
                {
                    if (string.IsNullOrEmpty(txtCommand.Text))
                    {
                        return;
                    }
                    else
                    {
                        // Add some command here
                        SystemGlobals.objMagazinePage.TimerStates.Enabled = false; // Disable TimeRecv flow
                        txtCommand.Text = "";
                        SystemGlobals.objMagazinePage.TimerStates.Enabled = true; // Enable TimeRecv flow
                    }
                }
                else
                {
                    txtCommand.Text = "";
                    MessageBox.Show("Communication Error! Operation valid only when the port is open");
                }
            }
        }

        private void MagVariablesPage_Load(object sender, EventArgs e)
        {
            Variable_UI_Arrays_Assign();
            if (MotorControls.IsMotorSerialInitialized)
            {
                TimerVariableStates.Enabled = true;
            }
            else
            {
                TimerVariableStates.Enabled = false;
                for (int i = 0; i < txtVariables.Length; i++)
                {
                    txtVariables[i].Text = "";
                }
            }
        }

        private void Variable_UI_Arrays_Assign()
        {
            // Assign V0 to V100 textbox Array
            // V0 to V9
            txtVariables[0] = txtV0;
            txtVariables[1] = txtV1;
            txtVariables[2] = txtV2;
            txtVariables[3] = txtV3;
            txtVariables[4] = txtV4;
            txtVariables[5] = txtV5;
            txtVariables[6] = txtV6;
            txtVariables[7] = txtV7;
            txtVariables[8] = txtV8;
            txtVariables[9] = txtV9;

            // V10 to V19
            txtVariables[10] = txtV10;
            txtVariables[11] = txtV11;
            txtVariables[12] = txtV12;
            txtVariables[13] = txtV13;
            txtVariables[14] = txtV14;
            txtVariables[15] = txtV15;
            txtVariables[16] = txtV16;
            txtVariables[17] = txtV17;
            txtVariables[18] = txtV18;
            txtVariables[19] = txtV19;

            // V20 to V29
            txtVariables[20] = txtV20;
            txtVariables[21] = txtV21;
            txtVariables[22] = txtV22;
            txtVariables[23] = txtV23;
            txtVariables[24] = txtV24;
            txtVariables[25] = txtV25;
            txtVariables[26] = txtV26;
            txtVariables[27] = txtV27;
            txtVariables[28] = txtV28;
            txtVariables[29] = txtV29;

            // V30 to V39
            txtVariables[30] = txtV30;
            txtVariables[31] = txtV31;
            txtVariables[32] = txtV32;
            txtVariables[33] = txtV33;
            txtVariables[34] = txtV34;
            txtVariables[35] = txtV35;
            txtVariables[36] = txtV36;
            txtVariables[37] = txtV37;
            txtVariables[38] = txtV38;
            txtVariables[39] = txtV39;

            // V40 to V49
            txtVariables[40] = txtV40;
            txtVariables[41] = txtV41;
            txtVariables[42] = txtV42;
            txtVariables[43] = txtV43;
            txtVariables[44] = txtV44;
            txtVariables[45] = txtV45;
            txtVariables[46] = txtV46;
            txtVariables[47] = txtV47;
            txtVariables[48] = txtV48;
            txtVariables[49] = txtV49;

            // V50 to V59
            txtVariables[50] = txtV50;
            txtVariables[51] = txtV51;
            txtVariables[52] = txtV52;
            txtVariables[53] = txtV53;
            txtVariables[54] = txtV54;
            txtVariables[55] = txtV55;
            txtVariables[56] = txtV56;
            txtVariables[57] = txtV57;
            txtVariables[58] = txtV58;
            txtVariables[59] = txtV59;

            // V60 to V69
            txtVariables[60] = txtV60;
            txtVariables[61] = txtV61;
            txtVariables[62] = txtV62;
            txtVariables[63] = txtV63;
            txtVariables[64] = txtV64;
            txtVariables[65] = txtV65;
            txtVariables[66] = txtV66;
            txtVariables[67] = txtV67;
            txtVariables[68] = txtV68;
            txtVariables[69] = txtV69;

            // V70 to V79
            txtVariables[70] = txtV70;
            txtVariables[71] = txtV71;
            txtVariables[72] = txtV72;
            txtVariables[73] = txtV73;
            txtVariables[74] = txtV74;
            txtVariables[75] = txtV75;
            txtVariables[76] = txtV76;
            txtVariables[77] = txtV77;
            txtVariables[78] = txtV78;
            txtVariables[79] = txtV79;

            // V80 to V89
            txtVariables[80] = txtV80;
            txtVariables[81] = txtV81;
            txtVariables[82] = txtV82;
            txtVariables[83] = txtV83;
            txtVariables[84] = txtV84;
            txtVariables[85] = txtV85;
            txtVariables[86] = txtV86;
            txtVariables[87] = txtV87;
            txtVariables[88] = txtV88;
            txtVariables[89] = txtV89;

            // V90 to V99
            txtVariables[90] = txtV90;
            txtVariables[91] = txtV91;
            txtVariables[92] = txtV92;
            txtVariables[93] = txtV93;
            txtVariables[94] = txtV94;
            txtVariables[95] = txtV95;
            txtVariables[96] = txtV96;
            txtVariables[97] = txtV97;
            txtVariables[98] = txtV98;
            txtVariables[99] = txtV99;
        }

        private void GetVariableValue(int index)
        {
            string strResultValue = "";
            MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "V" + index + "\r");
            Thread.Sleep(10);
            MotorControls.oHyperTerminalAdapter.Read(ref strResultValue);
            txtVariables[index].Text = strResultValue;
        }

        private void TimerVariableStates_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                GetVariableValue(i);
            }
        }

        private void cmdClose2_Click(object sender, EventArgs e)
        {
            TimerVariableStates.Enabled = false;
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
    }
}
