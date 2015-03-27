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
    public partial class XThreadPage : Form
    {
        public XThreadPage()
        {
            InitializeComponent();
        }

        private void cmdRun_Click(object sender, EventArgs e)
        {
            TimerProgramControl.Enabled = false;
            if (radProgram0.Checked)// Run Program 0
            {
                //Thread.Sleep(100);
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "SR0=1\r");
            }

            if (radProgram1.Checked)// Run Program 1
            {
                //Thread.Sleep(100);
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "SR1=1\r");
            }
            TimerProgramControl.Enabled = true;
        }

        private void cmdStop_Click(object sender, EventArgs e)
        {
            TimerProgramControl.Enabled = false;
            if (radProgram0.Checked)// Stop Program 0
            {
                //Thread.Sleep(100);
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "SR0=0\r");
            }

            if (radProgram1.Checked)// Stop Program 1
            {
                //Thread.Sleep(100);
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "SR1=0\r");
            }
            TimerProgramControl.Enabled = true;
        }

        private void cmdPause_Click(object sender, EventArgs e)
        {
            TimerProgramControl.Enabled = false;
            if (radProgram0.Checked)// Pause Program 0
            {
                //Thread.Sleep(100);
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "SR0=2\r");
            }

            if (radProgram1.Checked)// Pause Program 1
            {
                //Thread.Sleep(100);
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "SR1=2\r");
            }
            TimerProgramControl.Enabled = true;
        }

        private void cmdContinue_Click(object sender, EventArgs e)
        {
            TimerProgramControl.Enabled = false;
            if (radProgram0.Checked)// Continue Program 0
            {
                //Thread.Sleep(100);
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "SR0=3\r");
            }

            if (radProgram1.Checked)// Continue Program 1
            {
                //Thread.Sleep(100);
                MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "SR1=3\r");
            }
            TimerProgramControl.Enabled = true;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            //SystemGlobals.objMagazinePage.TimerStates.Enabled = true;
            if (MotorControls.IsMotorSerialInitialized)
            {
                SystemGlobals.objMagazinePage.TimerStates.Enabled = true;
            }
            else
            {
                SystemGlobals.objMagazinePage.TimerStates.Enabled = false;
            }
        }

        private void XThreadPage_Load(object sender, EventArgs e)
        {
            TimerProgramControl.Enabled = true;
        }

        private void TimerProgramControl_Tick(object sender, EventArgs e)
        {
            GetProgram0Status();
            GetProgram0Index();
            GetProgram1Status();
            GetProgram1Index();
        }

        private void GetProgram0Status()// Get Program0 status
        {
            MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "SASTAT[0]\r");
            Thread.Sleep(20);
            MotorControls.oHyperTerminalAdapter.Read(ref MotorControls.Program0Status);
            //txtProgram0Status.Text = MotorControls.Program0Status;
            switch (Convert.ToInt32(MotorControls.Program0Status))
            {
                case 0:
                    txtProgram0Status.Text = (MotorControls.ProgramControlStatus.Idle).ToString();
                    break;
                case 1:
                    txtProgram0Status.Text = (MotorControls.ProgramControlStatus.Running).ToString();
                    break;
                case 2:
                    txtProgram0Status.Text = (MotorControls.ProgramControlStatus.Paused).ToString();
                    break;
                case 4:
                    txtProgram0Status.Text = (MotorControls.ProgramControlStatus.InError).ToString();
                    break;
                default:
                    break;
            }
        }

        private void GetProgram1Status()// Get Program1 status
        {
            MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "SASTAT[1]\r");
            Thread.Sleep(20);
            MotorControls.oHyperTerminalAdapter.Read(ref MotorControls.Program1Status);
            //txtProgram1Status.Text = MotorControls.Program1Status;
            switch (Convert.ToInt32(MotorControls.Program1Status))
            {
                case 0:
                    txtProgram1Status.Text = (MotorControls.ProgramControlStatus.Idle).ToString();
                    break;
                case 1:
                    txtProgram1Status.Text = (MotorControls.ProgramControlStatus.Running).ToString();
                    break;
                case 2:
                    txtProgram1Status.Text = (MotorControls.ProgramControlStatus.Paused).ToString();
                    break;
                case 4:
                    txtProgram1Status.Text = (MotorControls.ProgramControlStatus.InError).ToString();
                    break;
                default:
                    break;
            }
        }

        private void GetProgram0Index()// Get Program0 index
        {
            MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "SPC[0]\r");
            Thread.Sleep(20);
            MotorControls.oHyperTerminalAdapter.Read(ref MotorControls.Program0Index);
            txtProgram0Index.Text = MotorControls.Program0Index;
        }

        private void GetProgram1Index()// Get Program1 index
        {
            MotorControls.oHyperTerminalAdapter.Write("@0" + MotorControls.DeviceId + "SPC[1]\r");
            Thread.Sleep(20);
            MotorControls.oHyperTerminalAdapter.Read(ref MotorControls.Program1Index);
            txtProgram1Index.Text = MotorControls.Program1Index;
        }
    }
}
