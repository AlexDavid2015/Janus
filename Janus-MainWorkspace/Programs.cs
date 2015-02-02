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
    public partial class Programs : Form
    {
        public Programs()
        {
            InitializeComponent();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            SystemGlobals.objMain.Show();
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {

        }

        private void cmdModify_Click(object sender, EventArgs e)
        {

        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {

        }

        private void cmdPairingProgramProduct_Click(object sender, EventArgs e)
        {

        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {

        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            // Find and add Programs' NAME to the listbox
            lstFind.Items.Clear();
            string tableName = "recipes";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = SystemGlobals.ConnectionString;
            string cmdText = string.Format("SELECT * FROM [{0}] ORDER BY description ASC", tableName);
            SqlCommand command;
            command = new SqlCommand(cmdText, conn);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow dRow in dataTable.Rows)
                {
                    //Console.WriteLine(dr["ID"].ToString() + " " + dr["NAME"].ToString());
                    if (SystemGlobals.IsLike(dRow["description"].ToString(), txtFind.Text))
                    {
                        lstFind.Items.Add(dRow["description"].ToString());
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {

        }

        private void cmdImport_Click(object sender, EventArgs e)
        {

        }

        private void Programs_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'JanusDataSet.recipes' table. You can move, or remove it, as needed.
            this.recipesTableAdapter.Fill(this.JanusDataSet.recipes);
        }

        private void lstFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tableName = "recipes";
            bool bFound = false;
            int i = 0;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = SystemGlobals.ConnectionString;
            //string cmdText = string.Format("SELECT * FROM [{0}] ORDER BY NAME ASC", tableName);
            string cmdText = string.Format("SELECT RowNumber = ROW_NUMBER() OVER (ORDER BY id ASC), * From [{0}]", tableName);
            SqlCommand command = new SqlCommand(cmdText, conn);

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow dRow in dataTable.Rows)
                {
                    //Console.WriteLine(dr["ID"].ToString() + " " + dr["NAME"].ToString());
                    if (dRow["description"].ToString() == lstFind.Text)
                    {
                        bFound = true;
                        recipesBindingSource.Position = Convert.ToInt32(dRow["RowNumber"].ToString()) - 1;// navigator go to the corresponding item in the database also, this will also affect other texboxes
                        if (Convert.ToBoolean(dRow["locked"].ToString()))
                        {
                            chkLock.Checked = true;
                            gpbProgramPanel.Enabled = false;
                        }
                        else
                        {
                            chkLock.Checked = false;
                            gpbProgramPanel.Enabled = true;
                        }
                        break;
                    }
                }
                if (!bFound) // No record found
                {
                    MessageBox.Show("Selected recipe is not present. Check database integrity", "Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            { }
        }

        private void txtDescription_Click(object sender, EventArgs e)
        {
            SystemGlobals.InputVal = txtDescription.Text;
            SystemGlobals.InputTyp = "NM";
            Input objInput = new Input();
            objInput.ShowDialog();
            txtDescription.Text = SystemGlobals.InputVal;
            SystemGlobals.InputVal = "";
        }

        private void txtPressure_Click(object sender, EventArgs e)
        {
            SystemGlobals.InputVal = txtPressure.Text;
            SystemGlobals.InputTyp = "PT";
            Input objInput = new Input();
            objInput.ShowDialog();
            txtPressure.Text = SystemGlobals.InputVal;
            SystemGlobals.InputVal = "";
        }

        private void txtGas1_Click(object sender, EventArgs e)
        {
            SystemGlobals.InputVal = txtGas1.Text;
            SystemGlobals.InputTyp = "G1";
            Input objInput = new Input();
            objInput.ShowDialog();
            if (SystemGlobals.InputVal != "")
            {
                txtGas1.Text = Convert.ToInt32(Convert.ToSingle(SystemGlobals.InputVal)).ToString();
            }
            else
            {
                txtGas1.Text = SystemGlobals.InputVal;
            }
            SystemGlobals.InputVal = "";
        }

        private void txtGas2_Click(object sender, EventArgs e)
        {
            SystemGlobals.InputVal = txtGas2.Text;
            SystemGlobals.InputTyp = "G2";
            Input objInput = new Input();
            objInput.ShowDialog();
            if (SystemGlobals.InputVal != "")
            {
                txtGas2.Text = Convert.ToInt32(Convert.ToSingle(SystemGlobals.InputVal)).ToString();
            }
            else
            {
                txtGas2.Text = SystemGlobals.InputVal;
            }
            SystemGlobals.InputVal = "";
        }

        private void txtGas3_Click(object sender, EventArgs e)
        {

        }

        private void txtTTP_Click(object sender, EventArgs e)
        {
            SystemGlobals.InputVal = txtTTP.Text;
            SystemGlobals.InputTyp = "TTP";
            Input objInput = new Input();
            objInput.ShowDialog();
            if (SystemGlobals.InputVal != "")
            {
                txtTTP.Text = Convert.ToInt32(Convert.ToSingle(SystemGlobals.InputVal)).ToString();
            }
            else
            {
                txtTTP.Text = SystemGlobals.InputVal;
            }
            SystemGlobals.InputVal = "";
        }

        private void txtTopOffset_Click(object sender, EventArgs e)
        {
            SystemGlobals.InputVal = txtTopOffset.Text;
            SystemGlobals.InputTyp = "TO";
            Input objInput = new Input();
            objInput.ShowDialog();
            txtTopOffset.Text = SystemGlobals.InputVal;
            SystemGlobals.InputVal = "";
        }

        private void txtNumOfSubstrates_Click(object sender, EventArgs e)
        {
            SystemGlobals.InputVal = txtNumOfSubstrates.Text;
            SystemGlobals.InputTyp = "NS";
            Input objInput = new Input();
            objInput.ShowDialog();
            if (SystemGlobals.InputVal != "")
            {
                txtNumOfSubstrates.Text = Convert.ToInt32(Convert.ToSingle(SystemGlobals.InputVal)).ToString();
            }
            else
            {
                txtNumOfSubstrates.Text = SystemGlobals.InputVal;
            }
            SystemGlobals.InputVal = "";
        }

        private void txtLength_Click(object sender, EventArgs e)
        {
            SystemGlobals.InputVal = txtLength.Text;
            SystemGlobals.InputTyp = "LE";
            Input objInput = new Input();
            objInput.ShowDialog();
            if (SystemGlobals.InputVal != "")
            {
                txtLength.Text = Convert.ToInt32(Convert.ToSingle(SystemGlobals.InputVal)).ToString();
            }
            else
            {
                txtLength.Text = SystemGlobals.InputVal;
            }
            SystemGlobals.InputVal = "";
        }

        private void txtRFPower_Click(object sender, EventArgs e)
        {
            SystemGlobals.InputVal = txtRFPower.Text;
            SystemGlobals.InputTyp = "PW";
            Input objInput = new Input();
            objInput.ShowDialog();
            if (SystemGlobals.InputVal != "")
            {
                txtRFPower.Text = Convert.ToInt32(Convert.ToSingle(SystemGlobals.InputVal)).ToString();
            }
            else
            {
                txtRFPower.Text = SystemGlobals.InputVal;
            }
            SystemGlobals.InputVal = "";
        }

        private void txtRFTime_Click(object sender, EventArgs e)
        {
            SystemGlobals.InputVal = txtRFTime.Text;
            SystemGlobals.InputTyp = "RT";
            Input objInput = new Input();
            objInput.ShowDialog();
            if (SystemGlobals.InputVal != "")
            {
                txtRFTime.Text = Convert.ToInt32(Convert.ToSingle(SystemGlobals.InputVal)).ToString();
            }
            else
            {
                txtRFTime.Text = SystemGlobals.InputVal;
            }
            SystemGlobals.InputVal = "";
        }

        private void txtBias_Click(object sender, EventArgs e)
        {
            SystemGlobals.InputVal = txtBias.Text;
            SystemGlobals.InputTyp = "BI";
            Input objInput = new Input();
            objInput.ShowDialog();
            txtBias.Text = SystemGlobals.InputVal;
            SystemGlobals.InputVal = "";
        }

        private void txtTune_Click(object sender, EventArgs e)
        {
            SystemGlobals.InputVal = txtTune.Text;
            SystemGlobals.InputTyp = "TU";
            Input objInput = new Input();
            objInput.ShowDialog();
            txtTune.Text = SystemGlobals.InputVal;
            SystemGlobals.InputVal = "";
        }

        private void txtLoad_Click(object sender, EventArgs e)
        {
            SystemGlobals.InputVal = txtLoad.Text;
            SystemGlobals.InputTyp = "LD";
            Input objInput = new Input();
            objInput.ShowDialog();
            txtLoad.Text = SystemGlobals.InputVal;
            SystemGlobals.InputVal = "";
        }

        private void txtManualTuner_Click(object sender, EventArgs e)
        {
            SystemGlobals.InputVal = txtManualTuner.Text;
            SystemGlobals.InputTyp = "MT";
            Input objInput = new Input();
            objInput.ShowDialog();
            txtManualTuner.Text = SystemGlobals.InputVal;
            SystemGlobals.InputVal = "";
        }

        private void txtBottomOffset_Click(object sender, EventArgs e)
        {
            SystemGlobals.InputVal = txtBottomOffset.Text;
            SystemGlobals.InputTyp = "BO";
            Input objInput = new Input();
            objInput.ShowDialog();
            txtBottomOffset.Text = SystemGlobals.InputVal;
            SystemGlobals.InputVal = "";
        }

        private void txtPickOffset_Click(object sender, EventArgs e)
        {
            SystemGlobals.InputVal = txtPickOffset.Text;
            SystemGlobals.InputTyp = "PO";
            Input objInput = new Input();
            objInput.ShowDialog();
            txtPickOffset.Text = SystemGlobals.InputVal;
            SystemGlobals.InputVal = "";
        }

        private void txtMagOffset_Click(object sender, EventArgs e)
        {
            SystemGlobals.InputVal = txtMagOffset.Text;
            SystemGlobals.InputTyp = "MO";// Mag offset
            Input objInput = new Input();
            objInput.ShowDialog();
            txtMagOffset.Text = SystemGlobals.InputVal;
            SystemGlobals.InputVal = "";
        }
    }
}
