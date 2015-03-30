namespace CxTitan
{
    partial class MagTerminalPage
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
            this.txtTerminalPage = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTerminalPage
            // 
            this.txtTerminalPage.Location = new System.Drawing.Point(23, 12);
            this.txtTerminalPage.Multiline = true;
            this.txtTerminalPage.Name = "txtTerminalPage";
            this.txtTerminalPage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTerminalPage.Size = new System.Drawing.Size(268, 346);
            this.txtTerminalPage.TabIndex = 92;
            // 
            // lblID
            // 
            this.lblID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblID.Location = new System.Drawing.Point(20, 383);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(25, 13);
            this.lblID.TabIndex = 93;
            this.lblID.Text = "ID:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(51, 380);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(53, 20);
            this.txtID.TabIndex = 94;
            this.txtID.Text = "01";
            // 
            // txtCommand
            // 
            this.txtCommand.Location = new System.Drawing.Point(121, 380);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(170, 20);
            this.txtCommand.TabIndex = 95;
            this.txtCommand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCommand_KeyPress);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(67, 418);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(65, 31);
            this.cmdSave.TabIndex = 96;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(175, 418);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(65, 31);
            this.cmdClose.TabIndex = 97;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // MagTerminalPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 461);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.txtTerminalPage);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MagTerminalPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TerminalPage";
            this.Load += new System.EventHandler(this.MagTerminalPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTerminalPage;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtCommand;
        internal System.Windows.Forms.Button cmdSave;
        internal System.Windows.Forms.Button cmdClose;
    }
}