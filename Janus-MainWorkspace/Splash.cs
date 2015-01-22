using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CxTitan
{
    public partial class Splash : Form
    {
        private int i = 0;
        private int WaitTimeMS;
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            WaitTime.Enabled = true;// set Wait Time
            CheckForExistingInstance();
            lblVersion.Text = this.GetType().Assembly.GetName().Name.ToString() + " Ver: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine
                + "Owner: " + "SCI Automation Pte Ltd" + Environment.NewLine + Application.ExecutablePath;

            ProgressBarUpdate();
        }

        public void CheckForExistingInstance()
        {
            // Get number of processes of your program
            Process aProcess = Process.GetCurrentProcess();
            string aProcName = aProcess.ProcessName;
            if(Process.GetProcessesByName(aProcName).Length > 1)
            {
                MessageBox.Show("Another Instance of this process is already running", "More than 1 Instances are not allowed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
            }
        }

        private void ProgressBarUpdate()
        {
            PBar.Value = 1;
            Thread.Sleep(20);

            PBar.Value = 10;
            Thread.Sleep(20);

            LoadCycleDB();// Collect cycles info and last recipe id
            PBar.Value = 20;
            Thread.Sleep(20);

            PBar.Value = 30;
            Thread.Sleep(20);

            PBar.Value = 40;
            Thread.Sleep(20);

            SystemGlobals.CurrentUser = new clsUser();// Defines Current User
            PBar.Value = 50;
            Thread.Sleep(20);

            PBar.Value = 60;
            Thread.Sleep(20);

            PBar.Value = 70;
            Thread.Sleep(20);

            PBar.Value = 80;
            Thread.Sleep(20);

            PBar.Value = 90;
            Thread.Sleep(20);

            PBar.Value = 100;
            Thread.Sleep(20);
        }

        public void SetWaitTime(int millisecs = 100)
        {
            WaitTimeMS = millisecs;
        }

        private void WaitTime_Tick(object sender, EventArgs e)
        {
            i++;
            if (i > WaitTimeMS)
            {
                i = 0;
                WaitTime.Enabled = false;
                this.Close();
                this.Dispose();
            }
        }

        private void LoadCycleDB()
        {
            // read one record row from Machine cycle table
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = SystemGlobals.ConnectionString;
            SqlCommand command = new SqlCommand("SELECT Cycles, ShiftCycles, ServiceCycles, LastRecipe FROM MachineCycles", conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    SystemGlobals.Cycles = Convert.ToInt64(reader["Cycles"].ToString());
                    SystemGlobals.ShiftCycles = Convert.ToInt64(reader["ShiftCycles"].ToString());
                    SystemGlobals.ServiceCycles = Convert.ToInt64(reader["ServiceCycles"].ToString());
                    SystemGlobals.IDLastRecipe = reader["LastRecipe"].ToString();// last recipe ID
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot get information about MachineCylces. Check database integrity", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (conn != null)
                {
                    conn.Close();
                }
                return;
            }
            conn.Close();
            reader.Close();
        }
    }
}
