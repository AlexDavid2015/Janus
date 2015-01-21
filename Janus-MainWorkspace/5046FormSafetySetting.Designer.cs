namespace CxTitan
{
    partial class DO_FormSafetySetting
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridviewSafety = new System.Windows.Forms.DataGridView();
            this.colChannel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDOSafetyState = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chbxSelecteAll = new System.Windows.Forms.CheckBox();
            this.btnDO_SafetySettingApply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewSafety)).BeginInit();
            this.SuspendLayout();
            // 
            // gridviewSafety
            // 
            this.gridviewSafety.AllowUserToAddRows = false;
            this.gridviewSafety.AllowUserToDeleteRows = false;
            this.gridviewSafety.AllowUserToResizeColumns = false;
            this.gridviewSafety.AllowUserToResizeRows = false;
            this.gridviewSafety.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gridviewSafety.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridviewSafety.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChannel,
            this.colDOSafetyState});
            this.gridviewSafety.Location = new System.Drawing.Point(12, 13);
            this.gridviewSafety.MultiSelect = false;
            this.gridviewSafety.Name = "gridviewSafety";
            this.gridviewSafety.RowHeadersVisible = false;
            this.gridviewSafety.RowTemplate.Height = 24;
            this.gridviewSafety.Size = new System.Drawing.Size(218, 393);
            this.gridviewSafety.TabIndex = 1;
            this.gridviewSafety.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridviewSafety_CellContentClick);
            // 
            // colChannel
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colChannel.DefaultCellStyle = dataGridViewCellStyle3;
            this.colChannel.HeaderText = "Channel";
            this.colChannel.Name = "colChannel";
            this.colChannel.ReadOnly = true;
            this.colChannel.Width = 80;
            // 
            // colDOSafetyState
            // 
            this.colDOSafetyState.HeaderText = "          Safety State";
            this.colDOSafetyState.Name = "colDOSafetyState";
            this.colDOSafetyState.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDOSafetyState.Width = 115;
            // 
            // chbxSelecteAll
            // 
            this.chbxSelecteAll.AutoSize = true;
            this.chbxSelecteAll.Location = new System.Drawing.Point(104, 17);
            this.chbxSelecteAll.Name = "chbxSelecteAll";
            this.chbxSelecteAll.Size = new System.Drawing.Size(15, 14);
            this.chbxSelecteAll.TabIndex = 3;
            this.chbxSelecteAll.UseVisualStyleBackColor = true;
            this.chbxSelecteAll.Click += new System.EventHandler(this.chbxSelecteAll_Click);
            // 
            // btnDO_SafetySettingApply
            // 
            this.btnDO_SafetySettingApply.Location = new System.Drawing.Point(162, 412);
            this.btnDO_SafetySettingApply.Name = "btnDO_SafetySettingApply";
            this.btnDO_SafetySettingApply.Size = new System.Drawing.Size(68, 25);
            this.btnDO_SafetySettingApply.TabIndex = 4;
            this.btnDO_SafetySettingApply.Text = "Apply";
            this.btnDO_SafetySettingApply.UseVisualStyleBackColor = true;
            this.btnDO_SafetySettingApply.Click += new System.EventHandler(this.btnDO_SafetySettingApply_Click);
            // 
            // DO_FormSafetySetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 516);
            this.Controls.Add(this.btnDO_SafetySettingApply);
            this.Controls.Add(this.chbxSelecteAll);
            this.Controls.Add(this.gridviewSafety);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DO_FormSafetySetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DO_FormSafetySetting";
            ((System.ComponentModel.ISupportInitialize)(this.gridviewSafety)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridviewSafety;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChannel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colDOSafetyState;
        private System.Windows.Forms.CheckBox chbxSelecteAll;
        private System.Windows.Forms.Button btnDO_SafetySettingApply;
    }
}