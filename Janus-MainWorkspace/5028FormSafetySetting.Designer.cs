namespace CxTitan
{
    partial class AO_FormSafetySetting
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridviewSafety = new System.Windows.Forms.DataGridView();
            this.colChannel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAOSafetyValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAORange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAO_SafetySettingApply = new System.Windows.Forms.Button();
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
            this.colAOSafetyValue,
            this.colAORange});
            this.gridviewSafety.Location = new System.Drawing.Point(12, 13);
            this.gridviewSafety.MultiSelect = false;
            this.gridviewSafety.Name = "gridviewSafety";
            this.gridviewSafety.RowHeadersVisible = false;
            this.gridviewSafety.RowTemplate.Height = 24;
            this.gridviewSafety.Size = new System.Drawing.Size(218, 393);
            this.gridviewSafety.TabIndex = 2;
            // 
            // colChannel
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colChannel.DefaultCellStyle = dataGridViewCellStyle2;
            this.colChannel.HeaderText = "Channel";
            this.colChannel.Name = "colChannel";
            this.colChannel.ReadOnly = true;
            this.colChannel.Width = 55;
            // 
            // colAOSafetyValue
            // 
            this.colAOSafetyValue.HeaderText = "Safety Value";
            this.colAOSafetyValue.MaxInputLength = 10;
            this.colAOSafetyValue.Name = "colAOSafetyValue";
            this.colAOSafetyValue.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colAOSafetyValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAOSafetyValue.Width = 80;
            // 
            // colAORange
            // 
            this.colAORange.HeaderText = "AO Range";
            this.colAORange.Name = "colAORange";
            this.colAORange.ReadOnly = true;
            this.colAORange.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colAORange.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAORange.Width = 80;
            // 
            // btnAO_SafetySettingApply
            // 
            this.btnAO_SafetySettingApply.Location = new System.Drawing.Point(162, 412);
            this.btnAO_SafetySettingApply.Name = "btnAO_SafetySettingApply";
            this.btnAO_SafetySettingApply.Size = new System.Drawing.Size(68, 25);
            this.btnAO_SafetySettingApply.TabIndex = 7;
            this.btnAO_SafetySettingApply.Text = "Apply";
            this.btnAO_SafetySettingApply.UseVisualStyleBackColor = true;
            this.btnAO_SafetySettingApply.Click += new System.EventHandler(this.btnAO_SafetySettingApply_Click);
            // 
            // AO_FormSafetySetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 516);
            this.Controls.Add(this.btnAO_SafetySettingApply);
            this.Controls.Add(this.gridviewSafety);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AO_FormSafetySetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AO_FormSafetySetting";
            ((System.ComponentModel.ISupportInitialize)(this.gridviewSafety)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridviewSafety;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChannel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAOSafetyValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAORange;
        private System.Windows.Forms.Button btnAO_SafetySettingApply;
    }
}