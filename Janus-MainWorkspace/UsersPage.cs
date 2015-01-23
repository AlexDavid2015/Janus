﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CxTitan.AvantechDataSetTableAdapters;

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
            this.Close();
            this.Dispose();
            SystemGlobals.objMain.Show();
        }

        private void UsersPage_Load(object sender, EventArgs e)
        {
            UpdateUserInfo();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            int i = 0;
            i = CalculatePermissionLevels();
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

        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
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
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cannot delete from Users table. Please check database integrity", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    UpdateUserInfo();
                }
            }
        }

        private void lstUsers_Click(object sender, EventArgs e)
        {
            short level = 0;
            string name = "";
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
                    name = reader["name"].ToString();
                    level = Convert.ToInt16(reader["level"].ToString());
                }
            }
            catch (Exception ex)
            { }
            conn.Close();
            reader.Close();

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
