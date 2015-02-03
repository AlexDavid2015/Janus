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
    public partial class Programs : Form
    {
        recipesTableAdapter recipeTableAobj = new recipesTableAdapter();
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
            txtDescription.Text = "";
            txtPressure.Text = "";
            txtRFPower.Text = "";
            txtRFTime.Text = "";
            txtGas1.Text = "";
            txtGas2.Text = "";
            txtTTP.Text = "";
            txtTune.Text = "50";
            txtLoad.Text = "50";
            txtTopOffset.Text = "";
            txtBottomOffset.Text = "";
            txtNumOfSubstrates.Text = "";
            txtLength.Text = "";
            txtPickOffset.Text = "";
            txtMagOffset.Text = "";
            txtBias.Text = "0";// need to assign txtBias to be 0 here as later there will be null empty check

            txtManualTuner.Text = "";
            chkManualTuner.Checked = false;
            chkLock.Checked = false;
            BindingNavigatorPositionItem.Text = "Insert new values. then press Add";
            cmdModify.Text = "Add";
            cmdNew.Enabled = false;
            cmdDownload.Enabled = false;
            cmdFind.Enabled = false;
            cmdDelete.Enabled = false;
            BindingNavigatorMoveFirstItem.Enabled = false;
            BindingNavigatorMoveLastItem.Enabled = false;
            BindingNavigatorMoveNextItem.Enabled = false;
            BindingNavigatorMovePreviousItem.Enabled = false;
        }

        public void AddMod()
        {
            if (string.IsNullOrEmpty(txtGas1.Text))
            {
                txtGas1.Text = "2";
            }
            if (string.IsNullOrEmpty(txtGas2.Text))
            {
                txtGas2.Text = "2";
            }
            if (txtDescription.Text == "")
            {
                cmdModify.Text = "Modify";
                BindingNavigatorPositionItem.Text = "Couldn't add program";
                MessageBox.Show("Cannot add new program. Check program entries. This program will be deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                recipeTableAobj.DeleteRecipe_description(txtDescription.Text);
                this.recipesTableAdapter.Fill(this.JanusDataSet.recipes);

                cmdDownload.Enabled = true;// Download
                cmdFind.Enabled = true;
                cmdDelete.Enabled = true;
                BindingNavigatorMoveFirstItem.Enabled = true;
                BindingNavigatorMoveLastItem.Enabled = true;
                BindingNavigatorMoveNextItem.Enabled = true;
                BindingNavigatorMovePreviousItem.Enabled = true;
                return;
            }
            switch (cmdModify.Text)
            {
                case "Add":
                    BindingNavigatorPositionItem.Text = "Program added";
                    if (string.IsNullOrEmpty(txtPressure.Text) || string.IsNullOrEmpty(txtRFPower.Text) || string.IsNullOrEmpty(txtDescription.Text) || string.IsNullOrEmpty(txtGas1.Text) 
                    || string.IsNullOrEmpty(txtGas2.Text) || string.IsNullOrEmpty(txtTTP.Text) || string.IsNullOrEmpty(txtTune.Text) || string.IsNullOrEmpty(txtLoad.Text) 
                    || string.IsNullOrEmpty(txtBias.Text) || string.IsNullOrEmpty(txtTopOffset.Text) || string.IsNullOrEmpty(txtBottomOffset.Text) || string.IsNullOrEmpty(txtNumOfSubstrates.Text) 
                    || string.IsNullOrEmpty(txtLength.Text) || string.IsNullOrEmpty(txtPickOffset.Text) || string.IsNullOrEmpty(txtMagOffset.Text))
                    {
                        if (txtDescription.Text != "")// but other fields are empty only RName is not empty
                        {
                            MessageBox.Show("Attention! Program added with all values set to 0 (zero). This program will be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            recipeTableAobj.DeleteRecipe_description(txtDescription.Text);
                            this.recipesTableAdapter.Fill(this.JanusDataSet.recipes);
                        }
                    }
                    else
                    {
                        recipeTableAobj.InsertRecipe(txtDescription.Text, Convert.ToDouble(txtPressure.Text), Convert.ToInt16(txtRFPower.Text), Convert.ToDouble(txtRFTime.Text), Convert.ToInt16(txtGas1.Text),
                        Convert.ToInt16(txtGas2.Text), Convert.ToInt16(txtBias.Text), Convert.ToDouble(txtTune.Text), Convert.ToDouble(txtLoad.Text), Convert.ToInt16(txtTTP.Text), chkManualTuner.Checked,
                        Convert.ToDouble(txtManualTuner.Text), Convert.ToDouble(txtTopOffset.Text), Convert.ToDouble(txtBottomOffset.Text), Convert.ToInt32(txtNumOfSubstrates.Text), chkLock.Checked,
                        Convert.ToInt32(txtLength.Text), Convert.ToDouble(txtPickOffset.Text), Convert.ToDouble(txtMagOffset.Text));
                        this.recipesTableAdapter.Fill(this.JanusDataSet.recipes);
                    }
                    cmdModify.Text = "Modify";
                    cmdDownload.Enabled = true;// Download
                    cmdFind.Enabled = true;
                    cmdDelete.Enabled = true;
                    BindingNavigatorMoveFirstItem.Enabled = true;
                    BindingNavigatorMoveLastItem.Enabled = true;
                    BindingNavigatorMoveNextItem.Enabled = true;
                    BindingNavigatorMovePreviousItem.Enabled = true;
                    break;
                case "Modify":
                    //RecipeTableAobj.UpdateRECIPE_ID(RName.Text, Convert.ToDouble(RPressure.Text), Convert.ToInt32(RPower.Text), Convert.ToInt32(RTime.Text), Convert.ToInt32(RG1V.Text),
                    //    Convert.ToInt32(RG2V.Text), Convert.ToDouble(RTTP.Text), Convert.ToDouble(RTUNE.Text), Convert.ToDouble(RLOAD.Text), Convert.ToDouble(RBIAS.Text), Convert.ToDouble(txtManualTuner.Text),
                    //    Convert.ToDouble(RTO.Text), Convert.ToDouble(RBO.Text), Convert.ToInt32(RNOS.Text), chkLock.Checked, Convert.ToDouble(RLEN.Text), Convert.ToDouble(RPO.Text), Convert.ToDouble(RSO.Text), 
                    //    chkManualTuner.Checked, Convert.ToInt32(txtID.Text));// update based on ID
                    recipeTableAobj.UpdateRecipe_id(txtDescription.Text, Convert.ToDouble(txtPressure.Text), Convert.ToInt16(txtRFPower.Text), Convert.ToDouble(txtRFTime.Text), Convert.ToInt16(txtGas1.Text),
                        Convert.ToInt16(txtGas2.Text), Convert.ToInt16(txtBias.Text), Convert.ToDouble(txtTune.Text), Convert.ToDouble(txtLoad.Text), Convert.ToInt16(txtTTP.Text), chkManualTuner.Checked,
                        Convert.ToDouble(txtManualTuner.Text), Convert.ToDouble(txtTopOffset.Text), Convert.ToDouble(txtBottomOffset.Text), Convert.ToInt32(txtNumOfSubstrates.Text), chkLock.Checked,
                        Convert.ToInt32(txtLength.Text), Convert.ToDouble(txtPickOffset.Text), Convert.ToDouble(txtMagOffset.Text), Convert.ToInt32(lblID.Text));
                    break;
                default:
                    break;
            }
        }

        private void cmdModify_Click(object sender, EventArgs e)
        {
            try
            {
                AddMod();
            }
            catch (Exception ex)
            {

            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (recipeTableAobj.SelectCounts() < 2)
            {
                MessageBox.Show("The Database cannot be empty. This record cannot be deleted. To delete this record, creat a new one first.");
            }
            if (MessageBox.Show("Are you sure to Delete this record? You cannot UNDO this action.", "Attention!",
                    MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                recipeTableAobj.DeleteRecipe_description(txtDescription.Text);
                this.recipesTableAdapter.Fill(this.JanusDataSet.recipes);
                lstFind.Items.Clear();
            }
            else
            {
                return;
            }
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

        private void chkLock_Click(object sender, EventArgs e)
        {
            if (chkLock.Checked)
            {
                gpbProgramPanel.Enabled = false;
            }
            else
            {
                gpbProgramPanel.Enabled = true;
            }
        }
    }
}
