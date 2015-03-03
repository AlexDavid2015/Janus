namespace CxTitan
{
    partial class ExpandedProgramCodePage
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
            this.gpbProgramEditor = new System.Windows.Forms.GroupBox();
            this.txtProgramCode = new System.Windows.Forms.TextBox();
            this.cmdCompile = new System.Windows.Forms.Button();
            this.cmdDownload = new System.Windows.Forms.Button();
            this.cmdUpload = new System.Windows.Forms.Button();
            this.cmdOpen = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdNew = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.gpbProgramEditor.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbProgramEditor
            // 
            this.gpbProgramEditor.Controls.Add(this.cmdClose);
            this.gpbProgramEditor.Controls.Add(this.cmdNew);
            this.gpbProgramEditor.Controls.Add(this.cmdSave);
            this.gpbProgramEditor.Controls.Add(this.cmdOpen);
            this.gpbProgramEditor.Controls.Add(this.cmdUpload);
            this.gpbProgramEditor.Controls.Add(this.cmdDownload);
            this.gpbProgramEditor.Controls.Add(this.cmdCompile);
            this.gpbProgramEditor.Controls.Add(this.txtProgramCode);
            this.gpbProgramEditor.Location = new System.Drawing.Point(12, 3);
            this.gpbProgramEditor.Name = "gpbProgramEditor";
            this.gpbProgramEditor.Size = new System.Drawing.Size(560, 646);
            this.gpbProgramEditor.TabIndex = 77;
            this.gpbProgramEditor.TabStop = false;
            // 
            // txtProgramCode
            // 
            this.txtProgramCode.Location = new System.Drawing.Point(14, 18);
            this.txtProgramCode.Multiline = true;
            this.txtProgramCode.Name = "txtProgramCode";
            this.txtProgramCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtProgramCode.Size = new System.Drawing.Size(533, 511);
            this.txtProgramCode.TabIndex = 91;
            this.txtProgramCode.WordWrap = false;
            // 
            // cmdCompile
            // 
            this.cmdCompile.Location = new System.Drawing.Point(14, 554);
            this.cmdCompile.Name = "cmdCompile";
            this.cmdCompile.Size = new System.Drawing.Size(70, 65);
            this.cmdCompile.TabIndex = 97;
            this.cmdCompile.Text = "Compile";
            this.cmdCompile.UseVisualStyleBackColor = true;
            this.cmdCompile.Click += new System.EventHandler(this.cmdCompile_Click);
            // 
            // cmdDownload
            // 
            this.cmdDownload.Location = new System.Drawing.Point(92, 554);
            this.cmdDownload.Name = "cmdDownload";
            this.cmdDownload.Size = new System.Drawing.Size(70, 65);
            this.cmdDownload.TabIndex = 98;
            this.cmdDownload.Text = "Download";
            this.cmdDownload.UseVisualStyleBackColor = true;
            this.cmdDownload.Click += new System.EventHandler(this.cmdDownload_Click);
            // 
            // cmdUpload
            // 
            this.cmdUpload.Location = new System.Drawing.Point(169, 554);
            this.cmdUpload.Name = "cmdUpload";
            this.cmdUpload.Size = new System.Drawing.Size(70, 65);
            this.cmdUpload.TabIndex = 99;
            this.cmdUpload.Text = "Upload";
            this.cmdUpload.UseVisualStyleBackColor = true;
            this.cmdUpload.Click += new System.EventHandler(this.cmdUpload_Click);
            // 
            // cmdOpen
            // 
            this.cmdOpen.Location = new System.Drawing.Point(246, 554);
            this.cmdOpen.Name = "cmdOpen";
            this.cmdOpen.Size = new System.Drawing.Size(70, 65);
            this.cmdOpen.TabIndex = 100;
            this.cmdOpen.Text = "Open";
            this.cmdOpen.UseVisualStyleBackColor = true;
            this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(323, 554);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(70, 65);
            this.cmdSave.TabIndex = 101;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdNew
            // 
            this.cmdNew.Location = new System.Drawing.Point(400, 554);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(70, 65);
            this.cmdNew.TabIndex = 102;
            this.cmdNew.Text = "New";
            this.cmdNew.UseVisualStyleBackColor = true;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(477, 554);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(70, 65);
            this.cmdClose.TabIndex = 103;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // ExpandedProgramCodePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 661);
            this.Controls.Add(this.gpbProgramEditor);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExpandedProgramCodePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Program Editor";
            this.Load += new System.EventHandler(this.ExpandedProgramCodePage_Load);
            this.gpbProgramEditor.ResumeLayout(false);
            this.gpbProgramEditor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox gpbProgramEditor;
        private System.Windows.Forms.TextBox txtProgramCode;
        internal System.Windows.Forms.Button cmdCompile;
        internal System.Windows.Forms.Button cmdDownload;
        internal System.Windows.Forms.Button cmdSave;
        internal System.Windows.Forms.Button cmdOpen;
        internal System.Windows.Forms.Button cmdUpload;
        internal System.Windows.Forms.Button cmdNew;
        internal System.Windows.Forms.Button cmdClose;
    }
}