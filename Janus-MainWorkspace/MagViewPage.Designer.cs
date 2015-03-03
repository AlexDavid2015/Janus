namespace CxTitan
{
    partial class MagViewPage
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
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.lstCompiledCode = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(54, 418);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(65, 31);
            this.cmdSave.TabIndex = 97;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(186, 418);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(65, 31);
            this.cmdClose.TabIndex = 98;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // lstCompiledCode
            // 
            this.lstCompiledCode.FormattingEnabled = true;
            this.lstCompiledCode.Location = new System.Drawing.Point(33, 21);
            this.lstCompiledCode.Name = "lstCompiledCode";
            this.lstCompiledCode.Size = new System.Drawing.Size(248, 355);
            this.lstCompiledCode.TabIndex = 99;
            // 
            // MagViewPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 461);
            this.Controls.Add(this.lstCompiledCode);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MagViewPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MagViewPage";
            this.Load += new System.EventHandler(this.MagViewPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button cmdSave;
        internal System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.ListBox lstCompiledCode;
    }
}