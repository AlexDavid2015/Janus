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
using CxTitan.AvantechDataSetTableAdapters;

namespace CxTitan
{
    public partial class JanusManual : Form
    {
        LanguageTableAdapter LanguageTableAobj = new LanguageTableAdapter();
        public JanusManual()
        {
            InitializeComponent();
        }

        private void cmdController_Click(object sender, EventArgs e)
        {            
            //ConnectPage connPage = new ConnectPage();
            //connPage.Show();
            this.Hide();
            SystemGlobals.objConnectPage.Show();
        }

        private void cmdMagazine_Click(object sender, EventArgs e)
        {
            this.Hide();
            SystemGlobals.objMagazinePage.Show();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            // Disable Threads
            if (SystemGlobals.objConnectPage.MainThread.IsBusy)
            {
                SystemGlobals.objConnectPage.MainThread.CancelAsync();
            }
            Avantech.MainThreadEnabled = false;
            SystemGlobals.objConnectPage.OutputTimer.Enabled = false;
            Avantech.bModbusConnected = false;

            // Disconnect IO modules
            AvantechDIs.FreeResource();
            AvantechDOs.FreeResource();
            AvantechAOs.FreeResource();
            AvantechAIs.FreeResource();
            AvantechDIOs.FreeResource();

            //System.Environment.Exit(0);
            SystemGlobals.objMain.Show();
        }

        private void JanusManual_Load(object sender, EventArgs e)
        {
            SystemGlobals.JanusPageReturn = this;
            LanguageInitialize();// load default language and update UI
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
                foreach(DataRow dRow in dataTable.Rows)
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
                if(conn != null)
                {
                    conn.Close();
                }
                return;
            }
            if(conn != null)
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
                        cmdController.Text = dRow["Item0"].ToString();
                        cmdMagazine.Text = dRow["Item1"].ToString();
                        cmdExit.Text = dRow["Item2"].ToString();
                        // Connection Page
                        SystemGlobals.objConnectPage.cmdConnect.Text = dRow["Item3"].ToString();
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

        private void cbxLanguageSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            SystemGlobals.LanguageCode = cbxLanguageSelection.Text;
            LanguageUIUpdate();
        }

        //public void SetAIRangeComboBox(string[] strRanges)
        //{
        //    cbxAIRange.BeginUpdate();
        //    cbxAIRange.Items.Clear();
        //    for (int i = 0; i < strRanges.Length; i++)
        //        cbxAIRange.Items.Add(strRanges[i]);

        //    if (cbxAIRange.Items.Count > 0)
        //        cbxAIRange.SelectedIndex = 0;
        //    cbxAIRange.EndUpdate();
        //}
    }
}
