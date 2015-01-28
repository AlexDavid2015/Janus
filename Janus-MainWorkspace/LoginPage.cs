using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            if (IsUserInformationCorrect())
            {
                this.Hide();
                SystemGlobals.objMain.MainUI_AccessLevels();// update UI according to Access Levels
                SystemGlobals.objMain.Show();// Main page show
            }
            else
            {
                MessageBox.Show("Wrong user information, please make sure the username and password are all correct!!");
                txtPassword.Focus();
            }
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
            // Set Current User info as "op" in DB
            SystemGlobals.CurrentUser.UserName = "op";
            SystemGlobals.CurrentUser.Level = 1;

            this.Hide();
            SystemGlobals.objMain.MainUI_AccessLevels();// update UI according to Access Levels
            SystemGlobals.objMain.Show();// Main page show?? or directly show Auto Page?
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            SystemGlobals.loginPageReturn = this;
            LanguageInitialize();
        }

        private bool IsUserInformationCorrect()
        {
            bool bFound = false;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = SystemGlobals.ConnectionString;
            string cmdText = "SELECT name, password FROM Users";
            SqlCommand command = new SqlCommand(cmdText, conn);
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow dRow in dataTable.Rows)
                {
                    if ((dRow["name"].ToString() == txtUserName.Text) &&
                        (dRow["password"].ToString() == txtPassword.Text))
                    {
                        bFound = true;
                        LoadCurrentUserInfoDB();
                        break;
                    }
                }
                return bFound;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot get information about Users. Check database integrity", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (conn != null)
                {
                    conn.Close();
                }
                return false;
            }
        }

        private void LoadCurrentUserInfoDB()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = SystemGlobals.ConnectionString;
            string cmdText = string.Format("SELECT * FROM Users WHERE name = '{0}' and password = '{1}'", 
                txtUserName.Text, txtPassword.Text);
            SqlCommand command = new SqlCommand(cmdText, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    SystemGlobals.CurrentUser.UserName = reader["name"].ToString();
                    SystemGlobals.CurrentUser.PassWord = reader["password"].ToString();
                    SystemGlobals.CurrentUser.Level = Convert.ToInt16(reader["level"].ToString());
                }
            }
            catch (Exception ex)
            { }
            conn.Close();
            reader.Close();
        }

        private void cbxLanguageSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            SystemGlobals.LanguageCode = cbxLanguageSelection.Text;
            LanguageUIUpdate();
        }

        private void LanguageInitialize()
        {
            //int LanguageNum = Convert.ToInt32(LanguageTableAobj.LanguageCount());
            //string[] strLanguages = new string[LanguageNum];

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = SystemGlobals.ConnectionString;
            string cmdText = "SELECT * FROM Language";
            SqlCommand command = new SqlCommand(cmdText, conn);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow dRow in dataTable.Rows)
                {
                    cbxLanguageSelection.Items.Add(dRow["languageType"].ToString());
                    //if (dRow["languageType"].ToString() == SystemGlobals.LanguageCode)
                    //{
                    //    cmdController.Text = dRow["Item0"].ToString();
                    //    cmdMagazine.Text = dRow["Item1"].ToString();
                    //    cmdExit.Text = dRow["Item2"].ToString();
                    //}
                }
                if (cbxLanguageSelection.Items.Count > 0)
                    cbxLanguageSelection.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot get information about Language. Check database integrity", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (conn != null)
                {
                    conn.Close();
                }
                return;
            }
            if (conn != null)
            {
                conn.Close();
            }
        }

        private void LanguageUIUpdate()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = SystemGlobals.ConnectionString;
            string cmdText = "SELECT * FROM Language";
            SqlCommand command = new SqlCommand(cmdText, conn);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow dRow in dataTable.Rows)
                {
                    if (dRow["languageType"].ToString() == SystemGlobals.LanguageCode)
                    {
                        // JanusManual Page
                        SystemGlobals.objJanusManual.cmdController.Text = dRow["ItemJanusManual0"].ToString();
                        SystemGlobals.objJanusManual.cmdMagazine.Text = dRow["ItemJanusManual1"].ToString();
                        SystemGlobals.objJanusManual.cmdExit.Text = dRow["ItemJanusManual2"].ToString();

                        // Login Page
                        lblUserName.Text = dRow["ItemLogin0"].ToString();
                        lblPassword.Text = dRow["ItemLogin1"].ToString();
                        cmdOK.Text = dRow["ItemLogin2"].ToString();
                        cmdOP.Text = dRow["ItemLogin3"].ToString();
                        cmdShutDown.Text = dRow["ItemLogin4"].ToString();
                        cmdClear.Text = dRow["ItemLogin5"].ToString();

                        // Main Page
                        SystemGlobals.objMain.cmdAuto.Text = dRow["ItemMain0"].ToString();
                        SystemGlobals.objMain.cmdManual.Text = dRow["ItemMain1"].ToString();
                        SystemGlobals.objMain.cmdPrograms.Text = dRow["ItemMain2"].ToString();
                        SystemGlobals.objMain.cmdLog.Text = dRow["ItemMain3"].ToString();
                        SystemGlobals.objMain.cmdSetup.Text = dRow["ItemMain4"].ToString();
                        SystemGlobals.objMain.cmdUtilities.Text = dRow["ItemMain5"].ToString();
                        SystemGlobals.objMain.cmdUsers.Text = dRow["ItemMain6"].ToString();
                        SystemGlobals.objMain.cmdLogOut.Text = dRow["ItemMain7"].ToString();
                        SystemGlobals.objMain.cmdShutDown.Text = dRow["ItemMain8"].ToString();

                        // User Page
                        SystemGlobals.objUsersPage.lblName.Text = dRow["ItemUsers0"].ToString();
                        SystemGlobals.objUsersPage.lblPassword1.Text = dRow["ItemUsers1"].ToString();
                        SystemGlobals.objUsersPage.lblPassword2.Text = dRow["ItemUsers2"].ToString();
                        SystemGlobals.objUsersPage.cmdAdd.Text = dRow["ItemUsers3"].ToString();
                        SystemGlobals.objUsersPage.cmdModify.Text = dRow["ItemUsers4"].ToString();
                        SystemGlobals.objUsersPage.cmdDelete.Text = dRow["ItemUsers5"].ToString();
                        SystemGlobals.objUsersPage.cmdExit.Text = dRow["ItemUsers6"].ToString();
                        SystemGlobals.objUsersPage.chkAuto.Text = dRow["ItemUsers7"].ToString();
                        SystemGlobals.objUsersPage.chkManual.Text = dRow["ItemUsers8"].ToString();
                        SystemGlobals.objUsersPage.chkPrograms.Text = dRow["ItemUsers9"].ToString();
                        SystemGlobals.objUsersPage.chkLog.Text = dRow["ItemUsers10"].ToString();
                        SystemGlobals.objUsersPage.chkSetup.Text = dRow["ItemUsers11"].ToString();
                        SystemGlobals.objUsersPage.chkUtilities.Text = dRow["ItemUsers12"].ToString();
                        SystemGlobals.objUsersPage.chkUserManagement.Text = dRow["ItemUsers13"].ToString();
                        //// Connection Page
                        //SystemGlobals.objConnectPage.cmdConnect.Text = dRow["Item3"].ToString();

                        // Magazine Page
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot get information about Language. Check database integrity", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (conn != null)
                {
                    conn.Close();
                }
                return;
            }
            if (conn != null)
            {
                conn.Close();
            }
        }
    }
}
