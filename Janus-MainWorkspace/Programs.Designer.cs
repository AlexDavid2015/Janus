namespace CxTitan
{
    partial class Programs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Programs));
            this.cmdExit = new System.Windows.Forms.Button();
            this.gpbProgramPanel = new System.Windows.Forms.GroupBox();
            this.txtMagOffset = new System.Windows.Forms.TextBox();
            this.recipesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.JanusDataSet = new CxTitan.JanusDataSet();
            this.txtPickOffset = new System.Windows.Forms.TextBox();
            this.txtBottomOffset = new System.Windows.Forms.TextBox();
            this.txtManualTuner = new System.Windows.Forms.TextBox();
            this.txtLoad = new System.Windows.Forms.TextBox();
            this.txtTune = new System.Windows.Forms.TextBox();
            this.txtBias = new System.Windows.Forms.TextBox();
            this.txtRFTime = new System.Windows.Forms.TextBox();
            this.txtRFPower = new System.Windows.Forms.TextBox();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.txtNumOfSubstrates = new System.Windows.Forms.TextBox();
            this.txtTopOffset = new System.Windows.Forms.TextBox();
            this.txtTTP = new System.Windows.Forms.TextBox();
            this.txtGas3 = new System.Windows.Forms.TextBox();
            this.txtGas2 = new System.Windows.Forms.TextBox();
            this.txtGas1 = new System.Windows.Forms.TextBox();
            this.chkManualTuner = new System.Windows.Forms.CheckBox();
            this.lblMagOffset = new System.Windows.Forms.Label();
            this.lblPickOffset = new System.Windows.Forms.Label();
            this.lblBottomOffset = new System.Windows.Forms.Label();
            this.lblLoad = new System.Windows.Forms.Label();
            this.lblTune = new System.Windows.Forms.Label();
            this.lblBias = new System.Windows.Forms.Label();
            this.lblRFTime = new System.Windows.Forms.Label();
            this.lblRFPower = new System.Windows.Forms.Label();
            this.txtPressure = new System.Windows.Forms.TextBox();
            this.lblLength = new System.Windows.Forms.Label();
            this.lblNumOfSubStrates = new System.Windows.Forms.Label();
            this.lblTopOffset = new System.Windows.Forms.Label();
            this.lblTTP = new System.Windows.Forms.Label();
            this.lblGas3 = new System.Windows.Forms.Label();
            this.lblGas2 = new System.Windows.Forms.Label();
            this.lblGas1 = new System.Windows.Forms.Label();
            this.lblPressure = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.lstFind = new System.Windows.Forms.ListBox();
            this.cmdFind = new System.Windows.Forms.Button();
            this.cmdExport = new System.Windows.Forms.Button();
            this.cmdImport = new System.Windows.Forms.Button();
            this.cmdNew = new System.Windows.Forms.Button();
            this.cmdModify = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdDownload = new System.Windows.Forms.Button();
            this.cmdPairingProgramProduct = new System.Windows.Forms.Button();
            this.BindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.BindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.BindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.BindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.BindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.BindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.BindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.BindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.BindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.recipesTableAdapter = new CxTitan.JanusDataSetTableAdapters.recipesTableAdapter();
            this.chkLock = new System.Windows.Forms.CheckBox();
            this.gpbProgramPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recipesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JanusDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingNavigator1)).BeginInit();
            this.BindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdExit
            // 
            this.cmdExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cmdExit.Location = new System.Drawing.Point(668, 611);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(212, 61);
            this.cmdExit.TabIndex = 6;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // gpbProgramPanel
            // 
            this.gpbProgramPanel.Controls.Add(this.txtMagOffset);
            this.gpbProgramPanel.Controls.Add(this.txtPickOffset);
            this.gpbProgramPanel.Controls.Add(this.txtBottomOffset);
            this.gpbProgramPanel.Controls.Add(this.txtManualTuner);
            this.gpbProgramPanel.Controls.Add(this.txtLoad);
            this.gpbProgramPanel.Controls.Add(this.txtTune);
            this.gpbProgramPanel.Controls.Add(this.txtBias);
            this.gpbProgramPanel.Controls.Add(this.txtRFTime);
            this.gpbProgramPanel.Controls.Add(this.txtRFPower);
            this.gpbProgramPanel.Controls.Add(this.txtLength);
            this.gpbProgramPanel.Controls.Add(this.txtNumOfSubstrates);
            this.gpbProgramPanel.Controls.Add(this.txtTopOffset);
            this.gpbProgramPanel.Controls.Add(this.txtTTP);
            this.gpbProgramPanel.Controls.Add(this.txtGas3);
            this.gpbProgramPanel.Controls.Add(this.txtGas2);
            this.gpbProgramPanel.Controls.Add(this.txtGas1);
            this.gpbProgramPanel.Controls.Add(this.chkManualTuner);
            this.gpbProgramPanel.Controls.Add(this.lblMagOffset);
            this.gpbProgramPanel.Controls.Add(this.lblPickOffset);
            this.gpbProgramPanel.Controls.Add(this.lblBottomOffset);
            this.gpbProgramPanel.Controls.Add(this.lblLoad);
            this.gpbProgramPanel.Controls.Add(this.lblTune);
            this.gpbProgramPanel.Controls.Add(this.lblBias);
            this.gpbProgramPanel.Controls.Add(this.lblRFTime);
            this.gpbProgramPanel.Controls.Add(this.lblRFPower);
            this.gpbProgramPanel.Controls.Add(this.txtPressure);
            this.gpbProgramPanel.Controls.Add(this.lblLength);
            this.gpbProgramPanel.Controls.Add(this.lblNumOfSubStrates);
            this.gpbProgramPanel.Controls.Add(this.lblTopOffset);
            this.gpbProgramPanel.Controls.Add(this.lblTTP);
            this.gpbProgramPanel.Controls.Add(this.lblGas3);
            this.gpbProgramPanel.Controls.Add(this.lblGas2);
            this.gpbProgramPanel.Controls.Add(this.lblGas1);
            this.gpbProgramPanel.Controls.Add(this.lblPressure);
            this.gpbProgramPanel.Controls.Add(this.txtID);
            this.gpbProgramPanel.Controls.Add(this.lblDescription);
            this.gpbProgramPanel.Controls.Add(this.txtDescription);
            this.gpbProgramPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gpbProgramPanel.Location = new System.Drawing.Point(22, 12);
            this.gpbProgramPanel.Name = "gpbProgramPanel";
            this.gpbProgramPanel.Size = new System.Drawing.Size(603, 425);
            this.gpbProgramPanel.TabIndex = 74;
            this.gpbProgramPanel.TabStop = false;
            this.gpbProgramPanel.Text = "Program Panel";
            // 
            // txtMagOffset
            // 
            this.txtMagOffset.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recipesBindingSource, "MagOffset", true));
            this.txtMagOffset.Location = new System.Drawing.Point(419, 385);
            this.txtMagOffset.Name = "txtMagOffset";
            this.txtMagOffset.ReadOnly = true;
            this.txtMagOffset.Size = new System.Drawing.Size(118, 20);
            this.txtMagOffset.TabIndex = 71;
            this.txtMagOffset.Click += new System.EventHandler(this.txtMagOffset_Click);
            // 
            // recipesBindingSource
            // 
            this.recipesBindingSource.DataMember = "recipes";
            this.recipesBindingSource.DataSource = this.JanusDataSet;
            // 
            // JanusDataSet
            // 
            this.JanusDataSet.DataSetName = "JanusDataSet";
            this.JanusDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtPickOffset
            // 
            this.txtPickOffset.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recipesBindingSource, "poffset", true));
            this.txtPickOffset.Location = new System.Drawing.Point(419, 346);
            this.txtPickOffset.Name = "txtPickOffset";
            this.txtPickOffset.ReadOnly = true;
            this.txtPickOffset.Size = new System.Drawing.Size(118, 20);
            this.txtPickOffset.TabIndex = 70;
            this.txtPickOffset.Click += new System.EventHandler(this.txtPickOffset_Click);
            // 
            // txtBottomOffset
            // 
            this.txtBottomOffset.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recipesBindingSource, "bottom_offset", true));
            this.txtBottomOffset.Location = new System.Drawing.Point(419, 307);
            this.txtBottomOffset.Name = "txtBottomOffset";
            this.txtBottomOffset.ReadOnly = true;
            this.txtBottomOffset.Size = new System.Drawing.Size(118, 20);
            this.txtBottomOffset.TabIndex = 69;
            this.txtBottomOffset.Click += new System.EventHandler(this.txtBottomOffset_Click);
            // 
            // txtManualTuner
            // 
            this.txtManualTuner.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recipesBindingSource, "mttime", true));
            this.txtManualTuner.Location = new System.Drawing.Point(419, 269);
            this.txtManualTuner.Name = "txtManualTuner";
            this.txtManualTuner.ReadOnly = true;
            this.txtManualTuner.Size = new System.Drawing.Size(118, 20);
            this.txtManualTuner.TabIndex = 68;
            this.txtManualTuner.Click += new System.EventHandler(this.txtManualTuner_Click);
            // 
            // txtLoad
            // 
            this.txtLoad.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recipesBindingSource, "load", true));
            this.txtLoad.Location = new System.Drawing.Point(419, 229);
            this.txtLoad.Name = "txtLoad";
            this.txtLoad.ReadOnly = true;
            this.txtLoad.Size = new System.Drawing.Size(118, 20);
            this.txtLoad.TabIndex = 67;
            this.txtLoad.Click += new System.EventHandler(this.txtLoad_Click);
            // 
            // txtTune
            // 
            this.txtTune.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recipesBindingSource, "tune", true));
            this.txtTune.Location = new System.Drawing.Point(419, 191);
            this.txtTune.Name = "txtTune";
            this.txtTune.ReadOnly = true;
            this.txtTune.Size = new System.Drawing.Size(118, 20);
            this.txtTune.TabIndex = 66;
            this.txtTune.Click += new System.EventHandler(this.txtTune_Click);
            // 
            // txtBias
            // 
            this.txtBias.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recipesBindingSource, "Bias", true));
            this.txtBias.Location = new System.Drawing.Point(419, 153);
            this.txtBias.Name = "txtBias";
            this.txtBias.ReadOnly = true;
            this.txtBias.Size = new System.Drawing.Size(118, 20);
            this.txtBias.TabIndex = 65;
            this.txtBias.Click += new System.EventHandler(this.txtBias_Click);
            // 
            // txtRFTime
            // 
            this.txtRFTime.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recipesBindingSource, "rftime", true));
            this.txtRFTime.Location = new System.Drawing.Point(419, 114);
            this.txtRFTime.Name = "txtRFTime";
            this.txtRFTime.ReadOnly = true;
            this.txtRFTime.Size = new System.Drawing.Size(118, 20);
            this.txtRFTime.TabIndex = 64;
            this.txtRFTime.Click += new System.EventHandler(this.txtRFTime_Click);
            // 
            // txtRFPower
            // 
            this.txtRFPower.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recipesBindingSource, "rfpower", true));
            this.txtRFPower.Location = new System.Drawing.Point(419, 75);
            this.txtRFPower.Name = "txtRFPower";
            this.txtRFPower.ReadOnly = true;
            this.txtRFPower.Size = new System.Drawing.Size(118, 20);
            this.txtRFPower.TabIndex = 63;
            this.txtRFPower.Click += new System.EventHandler(this.txtRFPower_Click);
            // 
            // txtLength
            // 
            this.txtLength.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recipesBindingSource, "length", true));
            this.txtLength.Location = new System.Drawing.Point(105, 346);
            this.txtLength.Name = "txtLength";
            this.txtLength.ReadOnly = true;
            this.txtLength.Size = new System.Drawing.Size(119, 20);
            this.txtLength.TabIndex = 62;
            this.txtLength.Click += new System.EventHandler(this.txtLength_Click);
            // 
            // txtNumOfSubstrates
            // 
            this.txtNumOfSubstrates.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recipesBindingSource, "number_substrates", true));
            this.txtNumOfSubstrates.Location = new System.Drawing.Point(105, 307);
            this.txtNumOfSubstrates.Name = "txtNumOfSubstrates";
            this.txtNumOfSubstrates.ReadOnly = true;
            this.txtNumOfSubstrates.Size = new System.Drawing.Size(119, 20);
            this.txtNumOfSubstrates.TabIndex = 61;
            this.txtNumOfSubstrates.Click += new System.EventHandler(this.txtNumOfSubstrates_Click);
            // 
            // txtTopOffset
            // 
            this.txtTopOffset.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recipesBindingSource, "top_offset", true));
            this.txtTopOffset.Location = new System.Drawing.Point(105, 269);
            this.txtTopOffset.Name = "txtTopOffset";
            this.txtTopOffset.ReadOnly = true;
            this.txtTopOffset.Size = new System.Drawing.Size(119, 20);
            this.txtTopOffset.TabIndex = 60;
            this.txtTopOffset.Click += new System.EventHandler(this.txtTopOffset_Click);
            // 
            // txtTTP
            // 
            this.txtTTP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recipesBindingSource, "ttp", true));
            this.txtTTP.Location = new System.Drawing.Point(105, 229);
            this.txtTTP.Name = "txtTTP";
            this.txtTTP.ReadOnly = true;
            this.txtTTP.Size = new System.Drawing.Size(119, 20);
            this.txtTTP.TabIndex = 59;
            this.txtTTP.Click += new System.EventHandler(this.txtTTP_Click);
            // 
            // txtGas3
            // 
            this.txtGas3.Location = new System.Drawing.Point(106, 191);
            this.txtGas3.Name = "txtGas3";
            this.txtGas3.ReadOnly = true;
            this.txtGas3.Size = new System.Drawing.Size(118, 20);
            this.txtGas3.TabIndex = 58;
            this.txtGas3.Visible = false;
            this.txtGas3.Click += new System.EventHandler(this.txtGas3_Click);
            // 
            // txtGas2
            // 
            this.txtGas2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recipesBindingSource, "gas2", true));
            this.txtGas2.Location = new System.Drawing.Point(105, 153);
            this.txtGas2.Name = "txtGas2";
            this.txtGas2.ReadOnly = true;
            this.txtGas2.Size = new System.Drawing.Size(119, 20);
            this.txtGas2.TabIndex = 57;
            this.txtGas2.Click += new System.EventHandler(this.txtGas2_Click);
            // 
            // txtGas1
            // 
            this.txtGas1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recipesBindingSource, "gas1", true));
            this.txtGas1.Location = new System.Drawing.Point(105, 114);
            this.txtGas1.Name = "txtGas1";
            this.txtGas1.ReadOnly = true;
            this.txtGas1.Size = new System.Drawing.Size(119, 20);
            this.txtGas1.TabIndex = 56;
            this.txtGas1.Click += new System.EventHandler(this.txtGas1_Click);
            // 
            // chkManualTuner
            // 
            this.chkManualTuner.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.recipesBindingSource, "mton", true));
            this.chkManualTuner.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkManualTuner.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkManualTuner.Location = new System.Drawing.Point(321, 271);
            this.chkManualTuner.Name = "chkManualTuner";
            this.chkManualTuner.Size = new System.Drawing.Size(92, 17);
            this.chkManualTuner.TabIndex = 55;
            this.chkManualTuner.Text = "Manual Tuner";
            this.chkManualTuner.UseVisualStyleBackColor = false;
            // 
            // lblMagOffset
            // 
            this.lblMagOffset.Location = new System.Drawing.Point(318, 388);
            this.lblMagOffset.Name = "lblMagOffset";
            this.lblMagOffset.Size = new System.Drawing.Size(60, 13);
            this.lblMagOffset.TabIndex = 54;
            this.lblMagOffset.Text = "Mag Offset";
            // 
            // lblPickOffset
            // 
            this.lblPickOffset.Location = new System.Drawing.Point(318, 349);
            this.lblPickOffset.Name = "lblPickOffset";
            this.lblPickOffset.Size = new System.Drawing.Size(85, 13);
            this.lblPickOffset.TabIndex = 53;
            this.lblPickOffset.Text = "Pick Offset (mm)";
            // 
            // lblBottomOffset
            // 
            this.lblBottomOffset.Location = new System.Drawing.Point(318, 310);
            this.lblBottomOffset.Name = "lblBottomOffset";
            this.lblBottomOffset.Size = new System.Drawing.Size(85, 13);
            this.lblBottomOffset.TabIndex = 52;
            this.lblBottomOffset.Text = "Bottom Offset";
            // 
            // lblLoad
            // 
            this.lblLoad.Location = new System.Drawing.Point(318, 232);
            this.lblLoad.Name = "lblLoad";
            this.lblLoad.Size = new System.Drawing.Size(85, 13);
            this.lblLoad.TabIndex = 50;
            this.lblLoad.Text = "Load (%)";
            // 
            // lblTune
            // 
            this.lblTune.Location = new System.Drawing.Point(318, 194);
            this.lblTune.Name = "lblTune";
            this.lblTune.Size = new System.Drawing.Size(85, 13);
            this.lblTune.TabIndex = 49;
            this.lblTune.Text = "Tune (%)";
            // 
            // lblBias
            // 
            this.lblBias.Location = new System.Drawing.Point(318, 156);
            this.lblBias.Name = "lblBias";
            this.lblBias.Size = new System.Drawing.Size(85, 13);
            this.lblBias.TabIndex = 48;
            this.lblBias.Text = "Bias";
            // 
            // lblRFTime
            // 
            this.lblRFTime.Location = new System.Drawing.Point(318, 117);
            this.lblRFTime.Name = "lblRFTime";
            this.lblRFTime.Size = new System.Drawing.Size(60, 13);
            this.lblRFTime.TabIndex = 47;
            this.lblRFTime.Text = "RF Time (Seconds)";
            // 
            // lblRFPower
            // 
            this.lblRFPower.Location = new System.Drawing.Point(318, 78);
            this.lblRFPower.Name = "lblRFPower";
            this.lblRFPower.Size = new System.Drawing.Size(94, 13);
            this.lblRFPower.TabIndex = 46;
            this.lblRFPower.Text = "RF Power (Watts)";
            // 
            // txtPressure
            // 
            this.txtPressure.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recipesBindingSource, "pressure", true));
            this.txtPressure.Location = new System.Drawing.Point(106, 75);
            this.txtPressure.Name = "txtPressure";
            this.txtPressure.ReadOnly = true;
            this.txtPressure.Size = new System.Drawing.Size(118, 20);
            this.txtPressure.TabIndex = 45;
            this.txtPressure.Click += new System.EventHandler(this.txtPressure_Click);
            // 
            // lblLength
            // 
            this.lblLength.Location = new System.Drawing.Point(15, 349);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(85, 13);
            this.lblLength.TabIndex = 44;
            this.lblLength.Text = "Length (mm)";
            // 
            // lblNumOfSubStrates
            // 
            this.lblNumOfSubStrates.Location = new System.Drawing.Point(15, 310);
            this.lblNumOfSubStrates.Name = "lblNumOfSubStrates";
            this.lblNumOfSubStrates.Size = new System.Drawing.Size(85, 13);
            this.lblNumOfSubStrates.TabIndex = 43;
            this.lblNumOfSubStrates.Text = "N° of Substrates";
            // 
            // lblTopOffset
            // 
            this.lblTopOffset.Location = new System.Drawing.Point(15, 272);
            this.lblTopOffset.Name = "lblTopOffset";
            this.lblTopOffset.Size = new System.Drawing.Size(69, 13);
            this.lblTopOffset.TabIndex = 42;
            this.lblTopOffset.Text = "Top Offset";
            // 
            // lblTTP
            // 
            this.lblTTP.Location = new System.Drawing.Point(15, 232);
            this.lblTTP.Name = "lblTTP";
            this.lblTTP.Size = new System.Drawing.Size(85, 13);
            this.lblTTP.TabIndex = 41;
            this.lblTTP.Text = "TTP (Seconds)";
            // 
            // lblGas3
            // 
            this.lblGas3.Location = new System.Drawing.Point(15, 194);
            this.lblGas3.Name = "lblGas3";
            this.lblGas3.Size = new System.Drawing.Size(69, 13);
            this.lblGas3.TabIndex = 40;
            this.lblGas3.Text = "Gas 3 (sccm)";
            this.lblGas3.Visible = false;
            // 
            // lblGas2
            // 
            this.lblGas2.Location = new System.Drawing.Point(15, 156);
            this.lblGas2.Name = "lblGas2";
            this.lblGas2.Size = new System.Drawing.Size(69, 13);
            this.lblGas2.TabIndex = 39;
            this.lblGas2.Text = "Gas 2 (sccm)";
            // 
            // lblGas1
            // 
            this.lblGas1.Location = new System.Drawing.Point(15, 117);
            this.lblGas1.Name = "lblGas1";
            this.lblGas1.Size = new System.Drawing.Size(69, 13);
            this.lblGas1.TabIndex = 38;
            this.lblGas1.Text = "Gas 1 (sccm)";
            // 
            // lblPressure
            // 
            this.lblPressure.Location = new System.Drawing.Point(15, 78);
            this.lblPressure.Name = "lblPressure";
            this.lblPressure.Size = new System.Drawing.Size(85, 13);
            this.lblPressure.TabIndex = 37;
            this.lblPressure.Text = "Pressure (mbar)";
            // 
            // txtID
            // 
            this.txtID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recipesBindingSource, "id", true));
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(549, 10);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(48, 20);
            this.txtID.TabIndex = 36;
            this.txtID.Visible = false;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(15, 37);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(69, 13);
            this.lblDescription.TabIndex = 18;
            this.lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.recipesBindingSource, "description", true));
            this.txtDescription.Location = new System.Drawing.Point(105, 34);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(432, 20);
            this.txtDescription.TabIndex = 17;
            this.txtDescription.Click += new System.EventHandler(this.txtDescription_Click);
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(668, 12);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(212, 20);
            this.txtFind.TabIndex = 75;
            this.txtFind.Text = "*";
            // 
            // lstFind
            // 
            this.lstFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lstFind.FormattingEnabled = true;
            this.lstFind.ItemHeight = 24;
            this.lstFind.Location = new System.Drawing.Point(668, 73);
            this.lstFind.Name = "lstFind";
            this.lstFind.Size = new System.Drawing.Size(212, 364);
            this.lstFind.TabIndex = 76;
            this.lstFind.SelectedIndexChanged += new System.EventHandler(this.lstFind_SelectedIndexChanged);
            // 
            // cmdFind
            // 
            this.cmdFind.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmdFind.FlatAppearance.BorderSize = 0;
            this.cmdFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFind.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdFind.Location = new System.Drawing.Point(668, 477);
            this.cmdFind.Name = "cmdFind";
            this.cmdFind.Size = new System.Drawing.Size(212, 61);
            this.cmdFind.TabIndex = 77;
            this.cmdFind.Text = "Find";
            this.cmdFind.UseVisualStyleBackColor = true;
            this.cmdFind.Click += new System.EventHandler(this.cmdFind_Click);
            // 
            // cmdExport
            // 
            this.cmdExport.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmdExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cmdExport.FlatAppearance.BorderSize = 0;
            this.cmdExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExport.ForeColor = System.Drawing.Color.Black;
            this.cmdExport.Location = new System.Drawing.Point(668, 544);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(100, 61);
            this.cmdExport.TabIndex = 78;
            this.cmdExport.Text = "Export";
            this.cmdExport.UseVisualStyleBackColor = false;
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // cmdImport
            // 
            this.cmdImport.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmdImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cmdImport.FlatAppearance.BorderSize = 0;
            this.cmdImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdImport.ForeColor = System.Drawing.Color.Black;
            this.cmdImport.Location = new System.Drawing.Point(780, 544);
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Size = new System.Drawing.Size(100, 61);
            this.cmdImport.TabIndex = 79;
            this.cmdImport.Text = "Import";
            this.cmdImport.UseVisualStyleBackColor = false;
            this.cmdImport.Click += new System.EventHandler(this.cmdImport_Click);
            // 
            // cmdNew
            // 
            this.cmdNew.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmdNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cmdNew.FlatAppearance.BorderSize = 0;
            this.cmdNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cmdNew.ForeColor = System.Drawing.Color.Black;
            this.cmdNew.Location = new System.Drawing.Point(22, 477);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(265, 61);
            this.cmdNew.TabIndex = 80;
            this.cmdNew.Text = "New";
            this.cmdNew.UseVisualStyleBackColor = false;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // cmdModify
            // 
            this.cmdModify.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmdModify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cmdModify.FlatAppearance.BorderSize = 0;
            this.cmdModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cmdModify.ForeColor = System.Drawing.Color.Black;
            this.cmdModify.Location = new System.Drawing.Point(22, 544);
            this.cmdModify.Name = "cmdModify";
            this.cmdModify.Size = new System.Drawing.Size(120, 61);
            this.cmdModify.TabIndex = 81;
            this.cmdModify.Text = "Modify";
            this.cmdModify.UseVisualStyleBackColor = false;
            this.cmdModify.Click += new System.EventHandler(this.cmdModify_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmdDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cmdDelete.FlatAppearance.BorderSize = 0;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cmdDelete.ForeColor = System.Drawing.Color.Black;
            this.cmdDelete.Location = new System.Drawing.Point(167, 544);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(120, 61);
            this.cmdDelete.TabIndex = 82;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = false;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdDownload
            // 
            this.cmdDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cmdDownload.Location = new System.Drawing.Point(453, 477);
            this.cmdDownload.Name = "cmdDownload";
            this.cmdDownload.Size = new System.Drawing.Size(172, 128);
            this.cmdDownload.TabIndex = 83;
            this.cmdDownload.Text = "Download";
            this.cmdDownload.UseVisualStyleBackColor = true;
            this.cmdDownload.Click += new System.EventHandler(this.cmdDownload_Click);
            // 
            // cmdPairingProgramProduct
            // 
            this.cmdPairingProgramProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cmdPairingProgramProduct.Location = new System.Drawing.Point(22, 611);
            this.cmdPairingProgramProduct.Name = "cmdPairingProgramProduct";
            this.cmdPairingProgramProduct.Size = new System.Drawing.Size(265, 61);
            this.cmdPairingProgramProduct.TabIndex = 84;
            this.cmdPairingProgramProduct.Text = "                 PAIRING                   Program && Product";
            this.cmdPairingProgramProduct.UseVisualStyleBackColor = true;
            this.cmdPairingProgramProduct.Click += new System.EventHandler(this.cmdPairingProgramProduct_Click);
            // 
            // BindingNavigator1
            // 
            this.BindingNavigator1.AddNewItem = null;
            this.BindingNavigator1.AutoSize = false;
            this.BindingNavigator1.BindingSource = this.recipesBindingSource;
            this.BindingNavigator1.CountItem = this.BindingNavigatorCountItem;
            this.BindingNavigator1.DeleteItem = null;
            this.BindingNavigator1.Dock = System.Windows.Forms.DockStyle.None;
            this.BindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BindingNavigatorMoveFirstItem,
            this.BindingNavigatorMovePreviousItem,
            this.BindingNavigatorSeparator,
            this.BindingNavigatorPositionItem,
            this.BindingNavigatorCountItem,
            this.BindingNavigatorSeparator1,
            this.BindingNavigatorMoveNextItem,
            this.BindingNavigatorMoveLastItem,
            this.BindingNavigatorSeparator2});
            this.BindingNavigator1.Location = new System.Drawing.Point(22, 444);
            this.BindingNavigator1.MoveFirstItem = this.BindingNavigatorMoveFirstItem;
            this.BindingNavigator1.MoveLastItem = this.BindingNavigatorMoveLastItem;
            this.BindingNavigator1.MoveNextItem = this.BindingNavigatorMoveNextItem;
            this.BindingNavigator1.MovePreviousItem = this.BindingNavigatorMovePreviousItem;
            this.BindingNavigator1.Name = "BindingNavigator1";
            this.BindingNavigator1.PositionItem = this.BindingNavigatorPositionItem;
            this.BindingNavigator1.Size = new System.Drawing.Size(250, 25);
            this.BindingNavigator1.TabIndex = 85;
            this.BindingNavigator1.Text = "BindingNavigator1";
            // 
            // BindingNavigatorCountItem
            // 
            this.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem";
            this.BindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.BindingNavigatorCountItem.Text = "of {0}";
            this.BindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // BindingNavigatorMoveFirstItem
            // 
            this.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("BindingNavigatorMoveFirstItem.Image")));
            this.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem";
            this.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.BindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.BindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // BindingNavigatorMovePreviousItem
            // 
            this.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("BindingNavigatorMovePreviousItem.Image")));
            this.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem";
            this.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.BindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.BindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // BindingNavigatorSeparator
            // 
            this.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator";
            this.BindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // BindingNavigatorPositionItem
            // 
            this.BindingNavigatorPositionItem.AccessibleName = "Position";
            this.BindingNavigatorPositionItem.AutoSize = false;
            this.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem";
            this.BindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.BindingNavigatorPositionItem.Text = "0";
            this.BindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // BindingNavigatorSeparator1
            // 
            this.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1";
            this.BindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // BindingNavigatorMoveNextItem
            // 
            this.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("BindingNavigatorMoveNextItem.Image")));
            this.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem";
            this.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.BindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.BindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // BindingNavigatorMoveLastItem
            // 
            this.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("BindingNavigatorMoveLastItem.Image")));
            this.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem";
            this.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.BindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.BindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // BindingNavigatorSeparator2
            // 
            this.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2";
            this.BindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // recipesTableAdapter
            // 
            this.recipesTableAdapter.ClearBeforeFill = true;
            // 
            // chkLock
            // 
            this.chkLock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLock.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkLock.Location = new System.Drawing.Point(527, 444);
            this.chkLock.Name = "chkLock";
            this.chkLock.Size = new System.Drawing.Size(98, 17);
            this.chkLock.TabIndex = 86;
            this.chkLock.Text = "Lock Recipe";
            this.chkLock.UseVisualStyleBackColor = false;
            // 
            // Programs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(892, 680);
            this.ControlBox = false;
            this.Controls.Add(this.chkLock);
            this.Controls.Add(this.BindingNavigator1);
            this.Controls.Add(this.cmdPairingProgramProduct);
            this.Controls.Add(this.cmdDownload);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdModify);
            this.Controls.Add(this.cmdNew);
            this.Controls.Add(this.cmdImport);
            this.Controls.Add(this.cmdExport);
            this.Controls.Add(this.cmdFind);
            this.Controls.Add(this.lstFind);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.gpbProgramPanel);
            this.Controls.Add(this.cmdExit);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Programs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Programs";
            this.Load += new System.EventHandler(this.Programs_Load);
            this.gpbProgramPanel.ResumeLayout(false);
            this.gpbProgramPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recipesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JanusDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingNavigator1)).EndInit();
            this.BindingNavigator1.ResumeLayout(false);
            this.BindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button cmdExit;
        internal System.Windows.Forms.GroupBox gpbProgramPanel;
        internal System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.ListBox lstFind;
        internal System.Windows.Forms.Button cmdFind;
        internal System.Windows.Forms.Button cmdExport;
        internal System.Windows.Forms.Button cmdImport;
        internal System.Windows.Forms.Button cmdNew;
        internal System.Windows.Forms.Button cmdModify;
        internal System.Windows.Forms.Button cmdDelete;
        internal System.Windows.Forms.Button cmdDownload;
        internal System.Windows.Forms.Button cmdPairingProgramProduct;
        internal System.Windows.Forms.Label lblDescription;
        internal System.Windows.Forms.TextBox txtDescription;
        internal System.Windows.Forms.TextBox txtID;
        internal System.Windows.Forms.Label lblPressure;
        internal System.Windows.Forms.Label lblGas2;
        internal System.Windows.Forms.Label lblGas1;
        internal System.Windows.Forms.Label lblTTP;
        internal System.Windows.Forms.Label lblGas3;
        internal System.Windows.Forms.Label lblTopOffset;
        internal System.Windows.Forms.Label lblNumOfSubStrates;
        internal System.Windows.Forms.Label lblLength;
        internal System.Windows.Forms.TextBox txtPressure;
        internal System.Windows.Forms.Label lblRFPower;
        internal System.Windows.Forms.Label lblPickOffset;
        internal System.Windows.Forms.Label lblBottomOffset;
        internal System.Windows.Forms.Label lblLoad;
        internal System.Windows.Forms.Label lblTune;
        internal System.Windows.Forms.Label lblBias;
        internal System.Windows.Forms.Label lblRFTime;
        internal System.Windows.Forms.Label lblMagOffset;
        internal System.Windows.Forms.CheckBox chkManualTuner;
        internal System.Windows.Forms.TextBox txtMagOffset;
        internal System.Windows.Forms.TextBox txtPickOffset;
        internal System.Windows.Forms.TextBox txtBottomOffset;
        internal System.Windows.Forms.TextBox txtManualTuner;
        internal System.Windows.Forms.TextBox txtLoad;
        internal System.Windows.Forms.TextBox txtTune;
        internal System.Windows.Forms.TextBox txtBias;
        internal System.Windows.Forms.TextBox txtRFTime;
        internal System.Windows.Forms.TextBox txtRFPower;
        internal System.Windows.Forms.TextBox txtLength;
        internal System.Windows.Forms.TextBox txtNumOfSubstrates;
        internal System.Windows.Forms.TextBox txtTopOffset;
        internal System.Windows.Forms.TextBox txtTTP;
        internal System.Windows.Forms.TextBox txtGas3;
        internal System.Windows.Forms.TextBox txtGas2;
        internal System.Windows.Forms.TextBox txtGas1;
        internal System.Windows.Forms.BindingNavigator BindingNavigator1;
        internal System.Windows.Forms.ToolStripLabel BindingNavigatorCountItem;
        internal System.Windows.Forms.ToolStripButton BindingNavigatorMoveFirstItem;
        internal System.Windows.Forms.ToolStripButton BindingNavigatorMovePreviousItem;
        internal System.Windows.Forms.ToolStripSeparator BindingNavigatorSeparator;
        internal System.Windows.Forms.ToolStripTextBox BindingNavigatorPositionItem;
        internal System.Windows.Forms.ToolStripSeparator BindingNavigatorSeparator1;
        internal System.Windows.Forms.ToolStripButton BindingNavigatorMoveNextItem;
        internal System.Windows.Forms.ToolStripButton BindingNavigatorMoveLastItem;
        internal System.Windows.Forms.ToolStripSeparator BindingNavigatorSeparator2;
        internal System.Windows.Forms.BindingSource recipesBindingSource;
        internal JanusDataSet JanusDataSet;
        internal JanusDataSetTableAdapters.recipesTableAdapter recipesTableAdapter;
        internal System.Windows.Forms.CheckBox chkLock;
    }
}