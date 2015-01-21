namespace CxTitan
{
    partial class DIO_FormSafetySetting
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridviewSafety = new System.Windows.Forms.DataGridView();
            this.colChannel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDOSafetyState = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnDIO_SafetySettingApply = new System.Windows.Forms.Button();
            this.chbxSelecteAll = new System.Windows.Forms.CheckBox();
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
            this.gridviewSafety.TabIndex = 5;
            this.gridviewSafety.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridviewSafety_CellContentClick);
            // 
            // colChannel
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colChannel.DefaultCellStyle = dataGridViewCellStyle1;
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
            // btnDIO_SafetySettingApply
            // 
            this.btnDIO_SafetySettingApply.Location = new System.Drawing.Point(162, 412);
            this.btnDIO_SafetySettingApply.Name = "btnDIO_SafetySettingApply";
            this.btnDIO_SafetySettingApply.Size = new System.Drawing.Size(68, 25);
            this.btnDIO_SafetySettingApply.TabIndex = 6;
            this.btnDIO_SafetySettingApply.Text = "Apply";
            this.btnDIO_SafetySettingApply.UseVisualStyleBackColor = true;
            this.btnDIO_SafetySettingApply.Click += new System.EventHandler(this.btnDIO_SafetySettingApply_Click);
            // 
            // chbxSelecteAll
            // 
            this.chbxSelecteAll.AutoSize = true;
            this.chbxSelecteAll.Location = new System.Drawing.Point(104, 17);
            this.chbxSelecteAll.Name = "chbxSelecteAll";
            this.chbxSelecteAll.Size = new System.Drawing.Size(15, 14);
            this.chbxSelecteAll.TabIndex = 7;
            this.chbxSelecteAll.UseVisualStyleBackColor = true;
            this.chbxSelecteAll.Click += new System.EventHandler(this.chbxSelecteAll_Click);
            // 
            // DIO_FormSafetySetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 516);
            this.Controls.Add(this.chbxSelecteAll);
            this.Controls.Add(this.btnDIO_SafetySettingApply);
            this.Controls.Add(this.gridviewSafety);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DIO_FormSafetySetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DIO_FormSafetySetting";
            ((System.ComponentModel.ISupportInitialize)(this.gridviewSafety)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridviewSafety;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChannel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colDOSafetyState;
        private System.Windows.Forms.Button btnDIO_SafetySettingApply;
        private System.Windows.Forms.CheckBox chbxSelecteAll;
    }
}