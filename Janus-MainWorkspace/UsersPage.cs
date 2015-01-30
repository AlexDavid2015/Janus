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
using CxTitan.JanusDataSetTableAdapters;

namespace CxTitan
{
    public partial class UsersPage : Form
    {
        UsersTableAdapter UsersAobj = new UsersTableAdapter();
        private CheckBox[] UserPage_CheckBoxes = new CheckBox[7];// group the access level buttons of Main Page( 7 == MainUiSections)
        public UsersPage()
        {
            InitializeComponent();
            UI_Arrays_Assign();// UserPage_CheckBoxes group
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            //this.Close();
            //this.Dispose();
            this.Hide();
            SystemGlobals.objMain.Show();
        }

        private void UsersPage_Load(object sender, EventArgs e)
        {
            UpdateUserInfo();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            string strExistingUser = string.Format("Already have an existing user \"{0}\", please use another user name", txtName.Text);
            // check whether username is exist or not so that there will be no two same user names inside DB
            if (CheckExistingUser(txtName.Text))
            {
                MessageBox.Show(strExistingUser, "Information!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int totalPermissionLevel = 0;
            totalPermissionLevel = CalculatePermissionLevels();
            string strNewUserAdded = string.Format("New User \"{0}\" has been added!", txtName.Text);
            if ((!string.IsNullOrEmpty(txtName.Text)) && (txtPassword1.Text == txtPassword2.Text))
            {
                try
                {
                    UsersAobj.InsertUsers(txtName.Text, txtPassword1.Text, Convert.ToInt16(totalPermissionLevel));
                    MessageBox.Show(strNewUserAdded);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot add user. Check username or database integrity", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                UpdateUserInfo();
                ClearUserPageInfo();
            }
            else
            {
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    MessageBox.Show("Cannot add user with an empty name.", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtPassword1.Text != txtPassword2.Text)
                {
                    MessageBox.Show("Please make sure the two passwords are the same.", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private bool CheckExistingUser(string name)
        {
            bool bFound = false;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = SystemGlobals.ConnectionString;
            string cmdText = "SELECT * FROM Users";
            SqlCommand command = new SqlCommand(cmdText, conn);
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow dRow in dataTable.Rows)
                {
                    if (dRow["name"].ToString() == name)
                    {
                        bFound = true;
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

        private int CalculatePermissionLevels()
        {
            int[] Permissions = new int[SystemGlobals.MainUiSections];
            int TotalPermissionLevel = 0;
            try
            {
                for (int i = 0; i < SystemGlobals.MainUiSections; i++)
                {
                    Permissions[i] = UserPage_CheckBoxes[i].Checked ? 1 : 0;
                    TotalPermissionLevel = TotalPermissionLevel + (Permissions[i]*Convert.ToInt32(Math.Pow(2, i)));
                }
                return TotalPermissionLevel;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in CalculatePermissionLevels()", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private void cmdModify_Click(object sender, EventArgs e)
        {
            string strNonExistingUser = string.Format("No existing user \"{0}\", please add this user first or choose another user name to modify", txtName.Text);
            // check whether username is exist or not so that there will be no two same user names inside DB
            if (!CheckExistingUser(txtName.Text))
            {
                MessageBox.Show(strNonExistingUser, "Information!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int totalPermissionLevel = 0;
            totalPermissionLevel = CalculatePermissionLevels();
            string strNewUserModified = string.Format("User \"{0}\" information have been modified!", txtName.Text);
            if (lstUsers.Text == "op")
            {
                MessageBox.Show("This user cannot be deleted or modified!");
                return;
            }
            if (lstUsers.Text == "admin")
            {
                MessageBox.Show("This user cannot be deleted or modified!");
                return;
            }

            if ((!string.IsNullOrEmpty(txtName.Text)) && (txtPassword1.Text == txtPassword2.Text))
            {
                try
                {
                    UsersAobj.UpdateUsers_id(txtName.Text, txtPassword1.Text, Convert.ToInt16(totalPermissionLevel), Convert.ToInt32(txtID.Text));
                    //UpdateUsers(txtName.Text, txtPassword1.Text, Convert.ToInt16(totalPermissionLevel),
                    //    Convert.ToInt32(txtID.Text));
                    MessageBox.Show(strNewUserModified);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    MessageBox.Show("Cannot modify user information. Check username or database integrity", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //UpdateUserInfo();
                ClearUserPageInfo();
            }
            else
            {
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    MessageBox.Show("Cannot modify user with an empty name.", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtPassword1.Text != txtPassword2.Text)
                {
                    MessageBox.Show("Please make sure the two passwords are the same.", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void UpdateUsers(string name, string password, short permissionlevel, int id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = SystemGlobals.ConnectionString;
            using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
                 using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Users SET name = @name, password = @password, level = @level WHERE (id = @id)";

                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@level", permissionlevel);
                command.Parameters.AddWithValue("@id", id);
               connection.Open();
               command.ExecuteNonQuery();
               connection.Close();
            } 
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            string strUserDeleted = string.Format("User \"{0}\" has been deleted!", txtName.Text);
            if (lstUsers.Text == "op")
            {
	            MessageBox.Show("This user cannot be deleted or modified!");
	            return;
            }
            if (lstUsers.Text == "admin")
            {
	            MessageBox.Show("This user cannot be deleted or modified!");
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete this record?", string.Empty, MessageBoxButtons.OKCancel) ==
                DialogResult.OK)
            {
                if (lstUsers.SelectedIndex > -1)
                {
                    try
                    {
                        UsersAobj.DeleteUsers_name(lstUsers.SelectedItem.ToString());
                        MessageBox.Show(strUserDeleted);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cannot delete from Users table. Please check database integrity", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    UpdateUserInfo();
                    ClearUserPageInfo();
                }
                else
                {
                    MessageBox.Show("User not selected, cannot delete user information from DB");
                    return;
                }
            }
        }

        private void ClearUserPageInfo()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtPassword1.Text = "";
            txtPassword2.Text = "";
        }

        private void lstUsers_Click(object sender, EventArgs e)
        {
            string id = "";
            string name = "";
            //string password = "";
            short level = 0;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = SystemGlobals.ConnectionString;
            string cmdText = string.Format("SELECT * FROM Users WHERE name = '{0}'", lstUsers.SelectedItem);
            SqlCommand command = new SqlCommand(cmdText, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    id = reader["id"].ToString();
                    name = reader["name"].ToString();
                    //password = reader["password"].ToString();
                    level = Convert.ToInt16(reader["level"].ToString());
                }
            }
            catch (Exception ex)
            { }
            conn.Close();
            reader.Close();

            txtID.Text = id;
            txtName.Text = name;
            txtPassword1.Text = "";
            txtPassword2.Text = "";
            SetCheckBoxes(level);
        }

        private void SetCheckBoxes(short level)
        {
            for (int i = 0; i < SystemGlobals.MainUiSections; i++)
            {
                if (((level) & (Convert.ToInt32(Math.Pow(2, i)))) == Convert.ToInt32(Math.Pow(2, i)))
                {
                    UserPage_CheckBoxes[i].Checked = true;
                }
                else
                {
                    UserPage_CheckBoxes[i].Checked = false;
                }
            }
        }

        private void UpdateUserInfo()
        {
            lstUsers.Items.Clear();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = SystemGlobals.ConnectionString;
            conn.Open();
            string cmdText = "SELECT * FROM Users";
            SqlCommand command;
            command = new SqlCommand(cmdText, conn);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow dRow in dataTable.Rows)
                {
                    if (dRow["name"].ToString() != "SCI" && dRow["name"].ToString() != "scidebug")
                    {
                        lstUsers.Items.Add(dRow["name"].ToString());
                    }                    
                }
            }
            catch (Exception ex)
            { }
        }

        private void UI_Arrays_Assign()
        {
            //Assign the UI Checkbox Arrays
            UserPage_CheckBoxes[0] = chkAuto;
            UserPage_CheckBoxes[1] = chkManual;
            UserPage_CheckBoxes[2] = chkPrograms;
            UserPage_CheckBoxes[3] = chkLog;
            UserPage_CheckBoxes[4] = chkSetup;
            UserPage_CheckBoxes[5] = chkUtilities;
            UserPage_CheckBoxes[6] = chkUserManagement;
        }
    }
}
