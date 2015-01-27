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

        private void AccessLevels()
        {
            
        }
    }
}
