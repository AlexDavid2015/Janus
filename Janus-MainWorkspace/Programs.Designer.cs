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
            this.cmdExit = new System.Windows.Forms.Button();
            this.gpbProgramPanel = new System.Windows.Forms.GroupBox();
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
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblPressure = new System.Windows.Forms.Label();
            this.lblGas1 = new System.Windows.Forms.Label();
            this.lblGas2 = new System.Windows.Forms.Label();
            this.lblGas3 = new System.Windows.Forms.Label();
            this.lblTTP = new System.Windows.Forms.Label();
            this.lblTopOffset = new System.Windows.Forms.Label();
            this.lblNumOfSubStrates = new System.Windows.Forms.Label();
            this.lblLength = new System.Windows.Forms.Label();
            this.txtPressure = new System.Windows.Forms.TextBox();
            this.lblRFPower = new System.Windows.Forms.Label();
            this.lblRFTime = new System.Windows.Forms.Label();
            this.lblBias = new System.Windows.Forms.Label();
            this.lblTune = new System.Windows.Forms.Label();
            this.lblLoad = new System.Windows.Forms.Label();
            this.lblBottomOffset = new System.Windows.Forms.Label();
            this.lblPickOffset = new System.Windows.Forms.Label();
            this.lblMagOffset = new System.Windows.Forms.Label();
            this.chkManualTuner = new System.Windows.Forms.CheckBox();
            this.txtGas1 = new System.Windows.Forms.TextBox();
            this.txtGas2 = new System.Windows.Forms.TextBox();
            this.txtGas3 = new System.Windows.Forms.TextBox();
            this.txtTTP = new System.Windows.Forms.TextBox();
            this.txtTopOffset = new System.Windows.Forms.TextBox();
            this.txtNumOfSubstrates = new System.Windows.Forms.TextBox();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.txtRFPower = new System.Windows.Forms.TextBox();
            this.txtRFTime = new System.Windows.Forms.TextBox();
            this.txtBias = new System.Windows.Forms.TextBox();
            this.txtTune = new System.Windows.Forms.TextBox();
            this.txtLoad = new System.Windows.Forms.TextBox();
            this.txtManualTuner = new System.Windows.Forms.TextBox();
            this.txtBottomOffset = new System.Windows.Forms.TextBox();
            this.txtPickOffset = new System.Windows.Forms.TextBox();
            this.txtMagOffset = new System.Windows.Forms.TextBox();
            this.gpbProgramPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdExit
            // 
            this.cmdExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cmdExit.Location = new System.Drawing.Point(668, 594);
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
            this.gpbProgramPanel.Size = new System.Drawing.Size(603, 429);
            this.gpbProgramPanel.TabIndex = 74;
            this.gpbProgramPanel.TabStop = false;
            this.gpbProgramPanel.Text = "Program Panel";
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
            // 
            // cmdFind
            // 
            this.cmdFind.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmdFind.FlatAppearance.BorderSize = 0;
            this.cmdFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFind.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdFind.Location = new System.Drawing.Point(668, 460);
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
            this.cmdExport.Location = new System.Drawing.Point(668, 527);
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
            this.cmdImport.Location = new System.Drawing.Point(780, 527);
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
            this.cmdNew.Location = new System.Drawing.Point(22, 460);
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
            this.cmdModify.Location = new System.Drawing.Point(22, 527);
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
            this.cmdDelete.Location = new System.Drawing.Point(167, 527);
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
            this.cmdDownload.Location = new System.Drawing.Point(453, 460);
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
            this.cmdPairingProgramProduct.Location = new System.Drawing.Point(22, 594);
            this.cmdPairingProgramProduct.Name = "cmdPairingProgramProduct";
            this.cmdPairingProgramProduct.Size = new System.Drawing.Size(265, 61);
            this.cmdPairingProgramProduct.TabIndex = 84;
            this.cmdPairingProgramProduct.Text = "                 PAIRING                   Program && Product";
            this.cmdPairingProgramProduct.UseVisualStyleBackColor = true;
            this.cmdPairingProgramProduct.Click += new System.EventHandler(this.cmdPairingProgramProduct_Click);
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
            this.txtDescription.Location = new System.Drawing.Point(105, 34);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(432, 20);
            this.txtDescription.TabIndex = 17;
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(549, 10);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(48, 20);
            this.txtID.TabIndex = 36;
            this.txtID.Visible = false;
            // 
            // lblPressure
            // 
            this.lblPressure.Location = new System.Drawing.Point(15, 78);
            this.lblPressure.Name = "lblPressure";
            this.lblPressure.Size = new System.Drawing.Size(85, 13);
            this.lblPressure.TabIndex = 37;
            this.lblPressure.Text = "Pressure (mbar)";
            // 
            // lblGas1
            // 
            this.lblGas1.Location = new System.Drawing.Point(15, 117);
            this.lblGas1.Name = "lblGas1";
            this.lblGas1.Size = new System.Drawing.Size(69, 13);
            this.lblGas1.TabIndex = 38;
            this.lblGas1.Text = "Gas 1 (sccm)";
            // 
            // lblGas2
            // 
            this.lblGas2.Location = new System.Drawing.Point(15, 156);
            this.lblGas2.Name = "lblGas2";
            this.lblGas2.Size = new System.Drawing.Size(69, 13);
            this.lblGas2.TabIndex = 39;
            this.lblGas2.Text = "Gas 2 (sccm)";
            // 
            // lblGas3
            // 
            this.lblGas3.Location = new System.Drawing.Point(15, 194);
            this.lblGas3.Name = "lblGas3";
            this.lblGas3.Size = new System.Drawing.Size(69, 13);
            this.lblGas3.TabIndex = 40;
            this.lblGas3.Text = "Gas 3 (sccm)";
            // 
            // lblTTP
            // 
            this.lblTTP.Location = new System.Drawing.Point(15, 232);
            this.lblTTP.Name = "lblTTP";
            this.lblTTP.Size = new System.Drawing.Size(85, 13);
            this.lblTTP.TabIndex = 41;
            this.lblTTP.Text = "TTP (Seconds)";
            // 
            // lblTopOffset
            // 
            this.lblTopOffset.Location = new System.Drawing.Point(15, 272);
            this.lblTopOffset.Name = "lblTopOffset";
            this.lblTopOffset.Size = new System.Drawing.Size(69, 13);
            this.lblTopOffset.TabIndex = 42;
            this.lblTopOffset.Text = "Top Offset";
            // 
            // lblNumOfSubStrates
            // 
            this.lblNumOfSubStrates.Location = new System.Drawing.Point(15, 310);
            this.lblNumOfSubStrates.Name = "lblNumOfSubStrates";
            this.lblNumOfSubStrates.Size = new System.Drawing.Size(85, 13);
            this.lblNumOfSubStrates.TabIndex = 43;
            this.lblNumOfSubStrates.Text = "N° of Substrates";
            // 
            // lblLength
            // 
            this.lblLength.Location = new System.Drawing.Point(15, 349);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(85, 13);
            this.lblLength.TabIndex = 44;
            this.lblLength.Text = "Length (mm)";
            // 
            // txtPressure
            // 
            this.txtPressure.Location = new System.Drawing.Point(106, 75);
            this.txtPressure.Name = "txtPressure";
            this.txtPressure.ReadOnly = true;
            this.txtPressure.Size = new System.Drawing.Size(118, 20);
            this.txtPressure.TabIndex = 45;
            // 
            // lblRFPower
            // 
            this.lblRFPower.Location = new System.Drawing.Point(318, 78);
            this.lblRFPower.Name = "lblRFPower";
            this.lblRFPower.Size = new System.Drawing.Size(94, 13);
            this.lblRFPower.TabIndex = 46;
            this.lblRFPower.Text = "RF Power (Watts)";
            // 
            // lblRFTime
            // 
            this.lblRFTime.Location = new System.Drawing.Point(318, 117);
            this.lblRFTime.Name = "lblRFTime";
            this.lblRFTime.Size = new System.Drawing.Size(60, 13);
            this.lblRFTime.TabIndex = 47;
            this.lblRFTime.Text = "RF Time (Seconds)";
            // 
            // lblBias
            // 
            this.lblBias.Location = new System.Drawing.Point(318, 156);
            this.lblBias.Name = "lblBias";
            this.lblBias.Size = new System.Drawing.Size(85, 13);
            this.lblBias.TabIndex = 48;
            this.lblBias.Text = "Bias";
            // 
            // lblTune
            // 
            this.lblTune.Location = new System.Drawing.Point(318, 194);
            this.lblTune.Name = "lblTune";
            this.lblTune.Size = new System.Drawing.Size(85, 13);
            this.lblTune.TabIndex = 49;
            this.lblTune.Text = "Tune (%)";
            // 
            // lblLoad
            // 
            this.lblLoad.Location = new System.Drawing.Point(318, 232);
            this.lblLoad.Name = "lblLoad";
            this.lblLoad.Size = new System.Drawing.Size(85, 13);
            this.lblLoad.TabIndex = 50;
            this.lblLoad.Text = "Load (%)";
            // 
            // lblBottomOffset
            // 
            this.lblBottomOffset.Location = new System.Drawing.Point(318, 310);
            this.lblBottomOffset.Name = "lblBottomOffset";
            this.lblBottomOffset.Size = new System.Drawing.Size(85, 13);
            this.lblBottomOffset.TabIndex = 52;
            this.lblBottomOffset.Text = "Bottom Offset";
            // 
            // lblPickOffset
            // 
            this.lblPickOffset.Location = new System.Drawing.Point(318, 349);
            this.lblPickOffset.Name = "lblPickOffset";
            this.lblPickOffset.Size = new System.Drawing.Size(85, 13);
            this.lblPickOffset.TabIndex = 53;
            this.lblPickOffset.Text = "Pick Offset (mm)";
            // 
            // lblMagOffset
            // 
            this.lblMagOffset.Location = new System.Drawing.Point(318, 388);
            this.lblMagOffset.Name = "lblMagOffset";
            this.lblMagOffset.Size = new System.Drawing.Size(60, 13);
            this.lblMagOffset.TabIndex = 54;
            this.lblMagOffset.Text = "Mag Offset";
            // 
            // chkManualTuner
            // 
            this.chkManualTuner.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkManualTuner.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkManualTuner.Location = new System.Drawing.Point(321, 271);
            this.chkManualTuner.Name = "chkManualTuner";
            this.chkManualTuner.Size = new System.Drawing.Size(92, 17);
            this.chkManualTuner.TabIndex = 55;
            this.chkManualTuner.Text = "Manual Tuner";
            this.chkManualTuner.UseVisualStyleBackColor = false;
            // 
            // txtGas1
            // 
            this.txtGas1.Location = new System.Drawing.Point(105, 114);
            this.txtGas1.Name = "txtGas1";
            this.txtGas1.ReadOnly = true;
            this.txtGas1.Size = new System.Drawing.Size(119, 20);
            this.txtGas1.TabIndex = 56;
            // 
            // txtGas2
            // 
            this.txtGas2.Location = new System.Drawing.Point(105, 153);
            this.txtGas2.Name = "txtGas2";
            this.txtGas2.ReadOnly = true;
            this.txtGas2.Size = new System.Drawing.Size(119, 20);
            this.txtGas2.TabIndex = 57;
            // 
            // txtGas3
            // 
            this.txtGas3.Location = new System.Drawing.Point(106, 191);
            this.txtGas3.Name = "txtGas3";
            this.txtGas3.ReadOnly = true;
            this.txtGas3.Size = new System.Drawing.Size(118, 20);
            this.txtGas3.TabIndex = 58;
            // 
            // txtTTP
            // 
            this.txtTTP.Location = new System.Drawing.Point(105, 229);
            this.txtTTP.Name = "txtTTP";
            this.txtTTP.ReadOnly = true;
            this.txtTTP.Size = new System.Drawing.Size(119, 20);
            this.txtTTP.TabIndex = 59;
            // 
            // txtTopOffset
            // 
            this.txtTopOffset.Location = new System.Drawing.Point(105, 269);
            this.txtTopOffset.Name = "txtTopOffset";
            this.txtTopOffset.ReadOnly = true;
            this.txtTopOffset.Size = new System.Drawing.Size(119, 20);
            this.txtTopOffset.TabIndex = 60;
            // 
            // txtNumOfSubstrates
            // 
            this.txtNumOfSubstrates.Location = new System.Drawing.Point(105, 307);
            this.txtNumOfSubstrates.Name = "txtNumOfSubstrates";
            this.txtNumOfSubstrates.ReadOnly = true;
            this.txtNumOfSubstrates.Size = new System.Drawing.Size(119, 20);
            this.txtNumOfSubstrates.TabIndex = 61;
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(105, 346);
            this.txtLength.Name = "txtLength";
            this.txtLength.ReadOnly = true;
            this.txtLength.Size = new System.Drawing.Size(119, 20);
            this.txtLength.TabIndex = 62;
            // 
            // txtRFPower
            // 
            this.txtRFPower.Location = new System.Drawing.Point(419, 75);
            this.txtRFPower.Name = "txtRFPower";
            this.txtRFPower.ReadOnly = true;
            this.txtRFPower.Size = new System.Drawing.Size(118, 20);
            this.txtRFPower.TabIndex = 63;
            // 
            // txtRFTime
            // 
            this.txtRFTime.Location = new System.Drawing.Point(419, 114);
            this.txtRFTime.Name = "txtRFTime";
            this.txtRFTime.ReadOnly = true;
            this.txtRFTime.Size = new System.Drawing.Size(118, 20);
            this.txtRFTime.TabIndex = 64;
            // 
            // txtBias
            // 
            this.txtBias.Location = new System.Drawing.Point(419, 153);
            this.txtBias.Name = "txtBias";
            this.txtBias.ReadOnly = true;
            this.txtBias.Size = new System.Drawing.Size(118, 20);
            this.txtBias.TabIndex = 65;
            // 
            // txtTune
            // 
            this.txtTune.Location = new System.Drawing.Point(419, 191);
            this.txtTune.Name = "txtTune";
            this.txtTune.ReadOnly = true;
            this.txtTune.Size = new System.Drawing.Size(118, 20);
            this.txtTune.TabIndex = 66;
            // 
            // txtLoad
            // 
            this.txtLoad.Location = new System.Drawing.Point(419, 229);
            this.txtLoad.Name = "txtLoad";
            this.txtLoad.ReadOnly = true;
            this.txtLoad.Size = new System.Drawing.Size(118, 20);
            this.txtLoad.TabIndex = 67;
            // 
            // txtManualTuner
            // 
            this.txtManualTuner.Location = new System.Drawing.Point(419, 269);
            this.txtManualTuner.Name = "txtManualTuner";
            this.txtManualTuner.ReadOnly = true;
            this.txtManualTuner.Size = new System.Drawing.Size(118, 20);
            this.txtManualTuner.TabIndex = 68;
            // 
            // txtBottomOffset
            // 
            this.txtBottomOffset.Location = new System.Drawing.Point(419, 307);
            this.txtBottomOffset.Name = "txtBottomOffset";
            this.txtBottomOffset.ReadOnly = true;
            this.txtBottomOffset.Size = new System.Drawing.Size(118, 20);
            this.txtBottomOffset.TabIndex = 69;
            // 
            // txtPickOffset
            // 
            this.txtPickOffset.Location = new System.Drawing.Point(419, 346);
            this.txtPickOffset.Name = "txtPickOffset";
            this.txtPickOffset.ReadOnly = true;
            this.txtPickOffset.Size = new System.Drawing.Size(118, 20);
            this.txtPickOffset.TabIndex = 70;
            // 
            // txtMagOffset
            // 
            this.txtMagOffset.Location = new System.Drawing.Point(419, 385);
            this.txtMagOffset.Name = "txtMagOffset";
            this.txtMagOffset.ReadOnly = true;
            this.txtMagOffset.Size = new System.Drawing.Size(118, 20);
            this.txtMagOffset.TabIndex = 71;
            // 
            // Programs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(892, 667);
            this.ControlBox = false;
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
    }
}