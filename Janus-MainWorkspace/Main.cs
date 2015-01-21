using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CxTitan
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void cmdAuto_Click(object sender, EventArgs e)
        {

        }

        private void cmdManual_Click(object sender, EventArgs e)
        {
            this.Hide();
            JanusManual janusManual = new JanusManual();
            janusManual.Show();
        }

        private void cmdLogOut_Click(object sender, EventArgs e)
        {
            SystemGlobals.loginReturn.Show();
        }

        private void cmdShutDown_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            System.Environment.Exit(1);
        }
    }
}
