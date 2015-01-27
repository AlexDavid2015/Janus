namespace CxTitan
{
    partial class Main
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
            this.cmdAuto = new System.Windows.Forms.Button();
            this.cmdManual = new System.Windows.Forms.Button();
            this.cmdLogOut = new System.Windows.Forms.Button();
            this.cmdShutDown = new System.Windows.Forms.Button();
            this.cmdUsers = new System.Windows.Forms.Button();
            this.cmdPrograms = new System.Windows.Forms.Button();
            this.cmdLog = new System.Windows.Forms.Button();
            this.cmdSetup = new System.Windows.Forms.Button();
            this.cmdUtilities = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdAuto
            // 
            this.cmdAuto.Location = new System.Drawing.Point(23, 50);
            this.cmdAuto.Name = "cmdAuto";
            this.cmdAuto.Size = new System.Drawing.Size(75, 63);
            this.cmdAuto.TabIndex = 0;
            this.cmdAuto.Text = "Automatic";
            this.cmdAuto.UseVisualStyleBackColor = true;
            this.cmdAuto.Click += new System.EventHandler(this.cmdAuto_Click);
            // 
            // cmdManual
            // 
            this.cmdManual.Location = new System.Drawing.Point(136, 50);
            this.cmdManual.Name = "cmdManual";
            this.cmdManual.Size = new System.Drawing.Size(75, 63);
            this.cmdManual.TabIndex = 1;
            this.cmdManual.Text = "Manual";
            this.cmdManual.UseVisualStyleBackColor = true;
            this.cmdManual.Click += new System.EventHandler(this.cmdManual_Click);
            // 
            // cmdLogOut
            // 
            this.cmdLogOut.Location = new System.Drawing.Point(802, 50);
            this.cmdLogOut.Name = "cmdLogOut";
            this.cmdLogOut.Size = new System.Drawing.Size(75, 63);
            this.cmdLogOut.TabIndex = 2;
            this.cmdLogOut.Text = "Log Out";
            this.cmdLogOut.UseVisualStyleBackColor = true;
            this.cmdLogOut.Click += new System.EventHandler(this.cmdLogOut_Click);
            // 
            // cmdShutDown
            // 
            this.cmdShutDown.Location = new System.Drawing.Point(911, 50);
            this.cmdShutDown.Name = "cmdShutDown";
            this.cmdShutDown.Size = new System.Drawing.Size(75, 63);
            this.cmdShutDown.TabIndex = 3;
            this.cmdShutDown.Text = "Shut Down";
            this.cmdShutDown.UseVisualStyleBackColor = true;
            this.cmdShutDown.Click += new System.EventHandler(this.cmdShutDown_Click);
            // 
            // cmdUsers
            // 
            this.cmdUsers.Location = new System.Drawing.Point(694, 50);
            this.cmdUsers.Name = "cmdUsers";
            this.cmdUsers.Size = new System.Drawing.Size(75, 63);
            this.cmdUsers.TabIndex = 4;
            this.cmdUsers.Text = "Users";
            this.cmdUsers.UseVisualStyleBackColor = true;
            this.cmdUsers.Click += new System.EventHandler(this.cmdUsers_Click);
            // 
            // cmdPrograms
            // 
            this.cmdPrograms.Location = new System.Drawing.Point(251, 50);
            this.cmdPrograms.Name = "cmdPrograms";
            this.cmdPrograms.Size = new System.Drawing.Size(75, 63);
            this.cmdPrograms.TabIndex = 5;
            this.cmdPrograms.Text = "Programs";
            this.cmdPrograms.UseVisualStyleBackColor = true;
            // 
            // cmdLog
            // 
            this.cmdLog.Location = new System.Drawing.Point(366, 50);
            this.cmdLog.Name = "cmdLog";
            this.cmdLog.Size = new System.Drawing.Size(75, 63);
            this.cmdLog.TabIndex = 6;
            this.cmdLog.Text = "Log";
            this.cmdLog.UseVisualStyleBackColor = true;
            // 
            // cmdSetup
            // 
            this.cmdSetup.Location = new System.Drawing.Point(473, 50);
            this.cmdSetup.Name = "cmdSetup";
            this.cmdSetup.Size = new System.Drawing.Size(75, 63);
            this.cmdSetup.TabIndex = 7;
            this.cmdSetup.Text = "Setup";
            this.cmdSetup.UseVisualStyleBackColor = true;
            // 
            // cmdUtilities
            // 
            this.cmdUtilities.Location = new System.Drawing.Point(584, 50);
            this.cmdUtilities.Name = "cmdUtilities";
            this.cmdUtilities.Size = new System.Drawing.Size(75, 63);
            this.cmdUtilities.TabIndex = 8;
            this.cmdUtilities.Text = "Utilities";
            this.cmdUtilities.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 555);
            this.ControlBox = false;
            this.Controls.Add(this.cmdUtilities);
            this.Controls.Add(this.cmdSetup);
            this.Controls.Add(this.cmdLog);
            this.Controls.Add(this.cmdPrograms);
            this.Controls.Add(this.cmdUsers);
            this.Controls.Add(this.cmdShutDown);
            this.Controls.Add(this.cmdLogOut);
            this.Controls.Add(this.cmdManual);
            this.Controls.Add(this.cmdAuto);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button cmdAuto;
        internal System.Windows.Forms.Button cmdManual;
        internal System.Windows.Forms.Button cmdPrograms;
        internal System.Windows.Forms.Button cmdLog;
        internal System.Windows.Forms.Button cmdSetup;
        internal System.Windows.Forms.Button cmdUtilities;
        internal System.Windows.Forms.Button cmdUsers;
        internal System.Windows.Forms.Button cmdLogOut;
        internal System.Windows.Forms.Button cmdShutDown;
    }
}