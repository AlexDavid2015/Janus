using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace CxTitan
{
    public partial class Main : Form
    {
        private Button[] Main_Buttons = new Button[7];// group the access level buttons of Main Page( 7 == MainUiSections)
        public Main()
        {
            InitializeComponent();
            UI_Arrays_Assign();// Main_Buttons group
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
            this.Hide();
            SystemGlobals.loginReturn.Show();
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

        private void cmdUsers_Click(object sender, EventArgs e)
        {
            this.Hide();
            UsersPage usersPage = new UsersPage();
            usersPage.Show();
        }

        public void MainUI_AccessLevels()
        {
            //bool[] a = new bool[SystemGlobals.MainUiSections];
            for (int i = 0; i < SystemGlobals.MainUiSections; i++)
            {
                if (((Convert.ToInt32(SystemGlobals.CurrentUser.Level)) & (Convert.ToInt32(Math.Pow(2, i)))) == Convert.ToInt32(Math.Pow(2, i)))
                {
                    Main_Buttons[i].Enabled = true; //a[i] = true;
                }
                else
                {
                    Main_Buttons[i].Enabled = false; //a[i] = false;
                }
                //Main_Buttons[i].Enabled = a[i];
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void UI_Arrays_Assign()
        {
            //Assign the UI Button Arrays
            Main_Buttons[0] = cmdAuto;
            Main_Buttons[1] = cmdManual;
            Main_Buttons[2] = cmdPrograms;
            Main_Buttons[3] = cmdLog;
            Main_Buttons[4] = cmdSetup;
            Main_Buttons[5] = cmdUtilities;
            Main_Buttons[6] = cmdUsers;
        }
    }
}
