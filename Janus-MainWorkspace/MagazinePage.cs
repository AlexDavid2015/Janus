using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Performax;

namespace CxTitan
{
    public partial class MagazinePage : Form
    {
        public MagazinePage()
        {
            //MotorControls.bRunMode = true;
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            SystemGlobals.objJanusManual.Show();//SystemGlobals.JanusManualPageReturn.Show();//System.Environment.Exit(0);
        }

        private void cmdSingMagHOME_Click(object sender, EventArgs e)
        {

        }

        private void cmdSingMoveToZero_Click(object sender, EventArgs e)
        {
            //MotorControls.SendReceive("PX=0");
        }

        private void MagazinePage_Load(object sender, EventArgs e)
        {
            //if (MotorControls.ConnectMotor())
            //{
                
            //}
            //else
            //{
            //    MessageBox.Show("No Pump Device Found", "Get Device List Error");
            //}
        }

        private void cmdSingMagCLOSE_Click(object sender, EventArgs e)
        {

        }

        private void cmdSingJogMinus_Click(object sender, EventArgs e)
        {

        }

        private void cmdSingJogPlus_Click(object sender, EventArgs e)
        {

        }
    }
}
