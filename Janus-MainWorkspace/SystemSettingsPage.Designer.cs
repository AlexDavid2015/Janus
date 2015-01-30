namespace CxTitan
{
    partial class SystemSettingsPage
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
            this.cmdExit = new System.Windows.Forms.Button();
            this.gpbSystemSettings = new System.Windows.Forms.GroupBox();
            this.txtDIO_DOindex = new System.Windows.Forms.TextBox();
            this.SystemSettingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtDIO_DIindex = new System.Windows.Forms.TextBox();
            this.txtDISlotNum = new System.Windows.Forms.TextBox();
            this.txtDIOSlotNum = new System.Windows.Forms.TextBox();
            this.txtAISlotNum = new System.Windows.Forms.TextBox();
            this.txtAOSlotNum = new System.Windows.Forms.TextBox();
            this.txtDOSlotNum = new System.Windows.Forms.TextBox();
            this.txtReceiveTimeOut = new System.Windows.Forms.TextBox();
            this.txtSendTimeOut = new System.Windows.Forms.TextBox();
            this.txtConnectionTimeOut = new System.Windows.Forms.TextBox();
            this.txtScanTime = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.lblDIO_DOindex = new System.Windows.Forms.Label();
            this.lblDIO_DIindex = new System.Windows.Forms.Label();
            this.lblDISlotNum = new System.Windows.Forms.Label();
            this.lblDIOSlotNum = new System.Windows.Forms.Label();
            this.lblAISlotNum = new System.Windows.Forms.Label();
            this.lblAOSlotNum = new System.Windows.Forms.Label();
            this.lblDOSlotNum = new System.Windows.Forms.Label();
            this.lblReceiveTimeOut = new System.Windows.Forms.Label();
            this.lblSendTimeOut = new System.Windows.Forms.Label();
            this.lblConnectionTimeOut = new System.Windows.Forms.Label();
            this.lblScanTime = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            this.JanusDataSet = new CxTitan.JanusDataSet();
            this.AvantechTableAdapter = new CxTitan.JanusDataSetTableAdapters.AvantechTableAdapter();
            this.gpbSystemSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SystemSettingsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JanusDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdExit
            // 
            this.cmdExit.Location = new System.Drawing.Point(503, 423);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(148, 41);
            this.cmdExit.TabIndex = 23;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // gpbSystemSettings
            // 
            this.gpbSystemSettings.Controls.Add(this.txtDIO_DOindex);
            this.gpbSystemSettings.Controls.Add(this.txtDIO_DIindex);
            this.gpbSystemSettings.Controls.Add(this.txtDISlotNum);
            this.gpbSystemSettings.Controls.Add(this.txtDIOSlotNum);
            this.gpbSystemSettings.Controls.Add(this.txtAISlotNum);
            this.gpbSystemSettings.Controls.Add(this.txtAOSlotNum);
            this.gpbSystemSettings.Controls.Add(this.txtDOSlotNum);
            this.gpbSystemSettings.Controls.Add(this.txtReceiveTimeOut);
            this.gpbSystemSettings.Controls.Add(this.txtSendTimeOut);
            this.gpbSystemSettings.Controls.Add(this.txtConnectionTimeOut);
            this.gpbSystemSettings.Controls.Add(this.txtScanTime);
            this.gpbSystemSettings.Controls.Add(this.txtIP);
            this.gpbSystemSettings.Controls.Add(this.lblDIO_DOindex);
            this.gpbSystemSettings.Controls.Add(this.lblDIO_DIindex);
            this.gpbSystemSettings.Controls.Add(this.lblDISlotNum);
            this.gpbSystemSettings.Controls.Add(this.lblDIOSlotNum);
            this.gpbSystemSettings.Controls.Add(this.lblAISlotNum);
            this.gpbSystemSettings.Controls.Add(this.lblAOSlotNum);
            this.gpbSystemSettings.Controls.Add(this.lblDOSlotNum);
            this.gpbSystemSettings.Controls.Add(this.lblReceiveTimeOut);
            this.gpbSystemSettings.Controls.Add(this.lblSendTimeOut);
            this.gpbSystemSettings.Controls.Add(this.lblConnectionTimeOut);
            this.gpbSystemSettings.Controls.Add(this.lblScanTime);
            this.gpbSystemSettings.Controls.Add(this.lblIP);
            this.gpbSystemSettings.Location = new System.Drawing.Point(36, 28);
            this.gpbSystemSettings.Name = "gpbSystemSettings";
            this.gpbSystemSettings.Size = new System.Drawing.Size(615, 375);
            this.gpbSystemSettings.TabIndex = 74;
            this.gpbSystemSettings.TabStop = false;
            this.gpbSystemSettings.Text = "System Settings";
            // 
            // txtDIO_DOindex
            // 
            this.txtDIO_DOindex.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.SystemSettingsBindingSource, "DIO_DOindex", true));
            this.txtDIO_DOindex.Enabled = false;
            this.txtDIO_DOindex.Location = new System.Drawing.Point(483, 335);
            this.txtDIO_DOindex.Name = "txtDIO_DOindex";
            this.txtDIO_DOindex.Size = new System.Drawing.Size(94, 20);
            this.txtDIO_DOindex.TabIndex = 136;
            // 
            // SystemSettingsBindingSource
            // 
            this.SystemSettingsBindingSource.DataMember = "Avantech";
            this.SystemSettingsBindingSource.DataSource = this.JanusDataSet;
            // 
            // txtDIO_DIindex
            // 
            this.txtDIO_DIindex.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.SystemSettingsBindingSource, "DIO_DIindex", true));
            this.txtDIO_DIindex.Enabled = false;
            this.txtDIO_DIindex.Location = new System.Drawing.Point(483, 281);
            this.txtDIO_DIindex.Name = "txtDIO_DIindex";
            this.txtDIO_DIindex.Size = new System.Drawing.Size(94, 20);
            this.txtDIO_DIindex.TabIndex = 135;
            // 
            // txtDISlotNum
            // 
            this.txtDISlotNum.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.SystemSettingsBindingSource, "DISlotNum", true));
            this.txtDISlotNum.Location = new System.Drawing.Point(483, 226);
            this.txtDISlotNum.Name = "txtDISlotNum";
            this.txtDISlotNum.Size = new System.Drawing.Size(94, 20);
            this.txtDISlotNum.TabIndex = 134;
            // 
            // txtDIOSlotNum
            // 
            this.txtDIOSlotNum.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.SystemSettingsBindingSource, "DIOSlotNum", true));
            this.txtDIOSlotNum.Location = new System.Drawing.Point(483, 175);
            this.txtDIOSlotNum.Name = "txtDIOSlotNum";
            this.txtDIOSlotNum.Size = new System.Drawing.Size(94, 20);
            this.txtDIOSlotNum.TabIndex = 133;
            // 
            // txtAISlotNum
            // 
            this.txtAISlotNum.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.SystemSettingsBindingSource, "AISlotNum", true));
            this.txtAISlotNum.Location = new System.Drawing.Point(483, 126);
            this.txtAISlotNum.Name = "txtAISlotNum";
            this.txtAISlotNum.Size = new System.Drawing.Size(94, 20);
            this.txtAISlotNum.TabIndex = 132;
            // 
            // txtAOSlotNum
            // 
            this.txtAOSlotNum.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.SystemSettingsBindingSource, "AOSlotNum", true));
            this.txtAOSlotNum.Location = new System.Drawing.Point(483, 79);
            this.txtAOSlotNum.Name = "txtAOSlotNum";
            this.txtAOSlotNum.Size = new System.Drawing.Size(94, 20);
            this.txtAOSlotNum.TabIndex = 131;
            // 
            // txtDOSlotNum
            // 
            this.txtDOSlotNum.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.SystemSettingsBindingSource, "DOSlotNum", true));
            this.txtDOSlotNum.Location = new System.Drawing.Point(483, 33);
            this.txtDOSlotNum.Name = "txtDOSlotNum";
            this.txtDOSlotNum.Size = new System.Drawing.Size(94, 20);
            this.txtDOSlotNum.TabIndex = 130;
            // 
            // txtReceiveTimeOut
            // 
            this.txtReceiveTimeOut.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.SystemSettingsBindingSource, "ReceiveTimeOut", true));
            this.txtReceiveTimeOut.Location = new System.Drawing.Point(171, 226);
            this.txtReceiveTimeOut.Name = "txtReceiveTimeOut";
            this.txtReceiveTimeOut.Size = new System.Drawing.Size(94, 20);
            this.txtReceiveTimeOut.TabIndex = 129;
            // 
            // txtSendTimeOut
            // 
            this.txtSendTimeOut.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.SystemSettingsBindingSource, "SendTimeOut", true));
            this.txtSendTimeOut.Location = new System.Drawing.Point(171, 175);
            this.txtSendTimeOut.Name = "txtSendTimeOut";
            this.txtSendTimeOut.Size = new System.Drawing.Size(94, 20);
            this.txtSendTimeOut.TabIndex = 128;
            // 
            // txtConnectionTimeOut
            // 
            this.txtConnectionTimeOut.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.SystemSettingsBindingSource, "ConnectionTimeOut", true));
            this.txtConnectionTimeOut.Location = new System.Drawing.Point(171, 126);
            this.txtConnectionTimeOut.Name = "txtConnectionTimeOut";
            this.txtConnectionTimeOut.Size = new System.Drawing.Size(94, 20);
            this.txtConnectionTimeOut.TabIndex = 127;
            // 
            // txtScanTime
            // 
            this.txtScanTime.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.SystemSettingsBindingSource, "ScanTime", true));
            this.txtScanTime.Location = new System.Drawing.Point(171, 79);
            this.txtScanTime.Name = "txtScanTime";
            this.txtScanTime.Size = new System.Drawing.Size(94, 20);
            this.txtScanTime.TabIndex = 126;
            // 
            // txtIP
            // 
            this.txtIP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.SystemSettingsBindingSource, "IP", true));
            this.txtIP.Location = new System.Drawing.Point(171, 33);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(94, 20);
            this.txtIP.TabIndex = 125;
            // 
            // lblDIO_DOindex
            // 
            this.lblDIO_DOindex.Location = new System.Drawing.Point(331, 338);
            this.lblDIO_DOindex.Name = "lblDIO_DOindex";
            this.lblDIO_DOindex.Size = new System.Drawing.Size(110, 13);
            this.lblDIO_DOindex.TabIndex = 46;
            this.lblDIO_DOindex.Text = "5045_DIO_DOindex";
            // 
            // lblDIO_DIindex
            // 
            this.lblDIO_DIindex.Location = new System.Drawing.Point(331, 284);
            this.lblDIO_DIindex.Name = "lblDIO_DIindex";
            this.lblDIO_DIindex.Size = new System.Drawing.Size(110, 13);
            this.lblDIO_DIindex.TabIndex = 45;
            this.lblDIO_DIindex.Text = "5045_DIO_DIindex";
            // 
            // lblDISlotNum
            // 
            this.lblDISlotNum.Location = new System.Drawing.Point(331, 229);
            this.lblDISlotNum.Name = "lblDISlotNum";
            this.lblDISlotNum.Size = new System.Drawing.Size(102, 13);
            this.lblDISlotNum.TabIndex = 44;
            this.lblDISlotNum.Text = "5040_DISlotNum";
            // 
            // lblDIOSlotNum
            // 
            this.lblDIOSlotNum.Location = new System.Drawing.Point(331, 178);
            this.lblDIOSlotNum.Name = "lblDIOSlotNum";
            this.lblDIOSlotNum.Size = new System.Drawing.Size(102, 13);
            this.lblDIOSlotNum.TabIndex = 43;
            this.lblDIOSlotNum.Text = "5045_DIOSlotNum";
            // 
            // lblAISlotNum
            // 
            this.lblAISlotNum.Location = new System.Drawing.Point(331, 129);
            this.lblAISlotNum.Name = "lblAISlotNum";
            this.lblAISlotNum.Size = new System.Drawing.Size(102, 13);
            this.lblAISlotNum.TabIndex = 42;
            this.lblAISlotNum.Text = "5017H_AISlotNum";
            // 
            // lblAOSlotNum
            // 
            this.lblAOSlotNum.Location = new System.Drawing.Point(331, 82);
            this.lblAOSlotNum.Name = "lblAOSlotNum";
            this.lblAOSlotNum.Size = new System.Drawing.Size(93, 13);
            this.lblAOSlotNum.TabIndex = 41;
            this.lblAOSlotNum.Text = "5028_AOSlotNum";
            // 
            // lblDOSlotNum
            // 
            this.lblDOSlotNum.Location = new System.Drawing.Point(331, 36);
            this.lblDOSlotNum.Name = "lblDOSlotNum";
            this.lblDOSlotNum.Size = new System.Drawing.Size(93, 13);
            this.lblDOSlotNum.TabIndex = 40;
            this.lblDOSlotNum.Text = "5046_DOSlotNum";
            // 
            // lblReceiveTimeOut
            // 
            this.lblReceiveTimeOut.Location = new System.Drawing.Point(18, 229);
            this.lblReceiveTimeOut.Name = "lblReceiveTimeOut";
            this.lblReceiveTimeOut.Size = new System.Drawing.Size(108, 13);
            this.lblReceiveTimeOut.TabIndex = 39;
            this.lblReceiveTimeOut.Text = "ReceiveTimeOut(ms)";
            // 
            // lblSendTimeOut
            // 
            this.lblSendTimeOut.Location = new System.Drawing.Point(18, 178);
            this.lblSendTimeOut.Name = "lblSendTimeOut";
            this.lblSendTimeOut.Size = new System.Drawing.Size(93, 13);
            this.lblSendTimeOut.TabIndex = 38;
            this.lblSendTimeOut.Text = "SendTimeOut(ms)";
            // 
            // lblConnectionTimeOut
            // 
            this.lblConnectionTimeOut.Location = new System.Drawing.Point(18, 129);
            this.lblConnectionTimeOut.Name = "lblConnectionTimeOut";
            this.lblConnectionTimeOut.Size = new System.Drawing.Size(125, 13);
            this.lblConnectionTimeOut.TabIndex = 37;
            this.lblConnectionTimeOut.Text = "ConnectionTimeOut(ms)";
            // 
            // lblScanTime
            // 
            this.lblScanTime.Location = new System.Drawing.Point(18, 82);
            this.lblScanTime.Name = "lblScanTime";
            this.lblScanTime.Size = new System.Drawing.Size(77, 13);
            this.lblScanTime.TabIndex = 36;
            this.lblScanTime.Text = "ScanTime(ms)";
            // 
            // lblIP
            // 
            this.lblIP.Location = new System.Drawing.Point(18, 36);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(24, 13);
            this.lblIP.TabIndex = 35;
            this.lblIP.Text = "IP";
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(36, 423);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(148, 41);
            this.cmdSave.TabIndex = 75;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // JanusDataSet
            // 
            this.JanusDataSet.DataSetName = "JanusDataSet";
            this.JanusDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // AvantechTableAdapter
            // 
            this.AvantechTableAdapter.ClearBeforeFill = true;
            // 
            // SystemSettingsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 476);
            this.ControlBox = false;
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.gpbSystemSettings);
            this.Controls.Add(this.cmdExit);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SystemSettingsPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Settings Page";
            this.Load += new System.EventHandler(this.SystemSettingsPage_Load);
            this.gpbSystemSettings.ResumeLayout(false);
            this.gpbSystemSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SystemSettingsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JanusDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button cmdExit;
        internal System.Windows.Forms.GroupBox gpbSystemSettings;
        internal System.Windows.Forms.Label lblIP;
        internal System.Windows.Forms.Label lblScanTime;
        internal System.Windows.Forms.Label lblConnectionTimeOut;
        internal System.Windows.Forms.Label lblSendTimeOut;
        internal System.Windows.Forms.Label lblReceiveTimeOut;
        internal System.Windows.Forms.Label lblDOSlotNum;
        internal System.Windows.Forms.Label lblDISlotNum;
        internal System.Windows.Forms.Label lblDIOSlotNum;
        internal System.Windows.Forms.Label lblAISlotNum;
        internal System.Windows.Forms.Label lblAOSlotNum;
        internal System.Windows.Forms.Label lblDIO_DIindex;
        internal System.Windows.Forms.Label lblDIO_DOindex;
        internal System.Windows.Forms.Button cmdSave;
        internal System.Windows.Forms.TextBox txtIP;
        internal System.Windows.Forms.TextBox txtScanTime;
        internal System.Windows.Forms.TextBox txtConnectionTimeOut;
        internal System.Windows.Forms.TextBox txtSendTimeOut;
        internal System.Windows.Forms.TextBox txtReceiveTimeOut;
        internal System.Windows.Forms.TextBox txtDOSlotNum;
        internal System.Windows.Forms.TextBox txtAOSlotNum;
        internal System.Windows.Forms.TextBox txtAISlotNum;
        internal System.Windows.Forms.TextBox txtDIOSlotNum;
        protected internal System.Windows.Forms.TextBox txtDISlotNum;
        internal System.Windows.Forms.TextBox txtDIO_DIindex;
        internal System.Windows.Forms.TextBox txtDIO_DOindex;
        internal JanusDataSet JanusDataSet;
        internal System.Windows.Forms.BindingSource SystemSettingsBindingSource;
        internal JanusDataSetTableAdapters.AvantechTableAdapter AvantechTableAdapter;
    }
}