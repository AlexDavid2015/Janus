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
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            this.Hide();
            SystemGlobals.objMain.Show();// Main page show
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
        }

        private void cmdShutDown_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to shut down?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) ==
                DialogResult.OK)
            {
                this.Close();
                this.Dispose();
                System.Environment.Exit(1);
            }
        }

        private void cmdOP_Click(object sender, EventArgs e)
        {

        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            SystemGlobals.loginReturn = this;
        }
    }
}
