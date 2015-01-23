namespace CxTitan
{
    partial class UsersPage
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
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.cmdExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword2 = new System.Windows.Forms.TextBox();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdModify = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.chkAuto = new System.Windows.Forms.CheckBox();
            this.chkManual = new System.Windows.Forms.CheckBox();
            this.chkPrograms = new System.Windows.Forms.CheckBox();
            this.chkLog = new System.Windows.Forms.CheckBox();
            this.chkSetup = new System.Windows.Forms.CheckBox();
            this.chkUtilities = new System.Windows.Forms.CheckBox();
            this.chkUserManagement = new System.Windows.Forms.CheckBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstUsers
            // 
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.Location = new System.Drawing.Point(30, 33);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(182, 290);
            this.lstUsers.TabIndex = 0;
            this.lstUsers.Click += new System.EventHandler(this.lstUsers_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Location = new System.Drawing.Point(30, 384);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(182, 53);
            this.cmdExit.TabIndex = 1;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(259, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name (max 10 chars)";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(262, 60);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(249, 20);
            this.txtName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(259, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password (max 10 chars)";
            // 
            // txtPassword1
            // 
            this.txtPassword1.Location = new System.Drawing.Point(262, 125);
            this.txtPassword1.Name = "txtPassword1";
            this.txtPassword1.PasswordChar = '*';
            this.txtPassword1.Size = new System.Drawing.Size(249, 20);
            this.txtPassword1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(259, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Repeat Password";
            // 
            // txtPassword2
            // 
            this.txtPassword2.Location = new System.Drawing.Point(262, 194);
            this.txtPassword2.Name = "txtPassword2";
            this.txtPassword2.PasswordChar = '*';
            this.txtPassword2.Size = new System.Drawing.Size(249, 20);
            this.txtPassword2.TabIndex = 7;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(262, 256);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(249, 53);
            this.cmdAdd.TabIndex = 8;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdModify
            // 
            this.cmdModify.Location = new System.Drawing.Point(262, 325);
            this.cmdModify.Name = "cmdModify";
            this.cmdModify.Size = new System.Drawing.Size(117, 53);
            this.cmdModify.TabIndex = 9;
            this.cmdModify.Text = "Modify";
            this.cmdModify.UseVisualStyleBackColor = true;
            this.cmdModify.Click += new System.EventHandler(this.cmdModify_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(394, 325);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(117, 53);
            this.cmdDelete.TabIndex = 10;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // chkAuto
            // 
            this.chkAuto.AutoSize = true;
            this.chkAuto.Location = new System.Drawing.Point(634, 38);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(73, 17);
            this.chkAuto.TabIndex = 11;
            this.chkAuto.Text = "Automatic";
            this.chkAuto.UseVisualStyleBackColor = true;
            // 
            // chkManual
            // 
            this.chkManual.AutoSize = true;
            this.chkManual.Location = new System.Drawing.Point(634, 73);
            this.chkManual.Name = "chkManual";
            this.chkManual.Size = new System.Drawing.Size(61, 17);
            this.chkManual.TabIndex = 12;
            this.chkManual.Text = "Manual";
            this.chkManual.UseVisualStyleBackColor = true;
            // 
            // chkPrograms
            // 
            this.chkPrograms.AutoSize = true;
            this.chkPrograms.Location = new System.Drawing.Point(634, 107);
            this.chkPrograms.Name = "chkPrograms";
            this.chkPrograms.Size = new System.Drawing.Size(70, 17);
            this.chkPrograms.TabIndex = 13;
            this.chkPrograms.Text = "Programs";
            this.chkPrograms.UseVisualStyleBackColor = true;
            // 
            // chkLog
            // 
            this.chkLog.AutoSize = true;
            this.chkLog.Location = new System.Drawing.Point(634, 141);
            this.chkLog.Name = "chkLog";
            this.chkLog.Size = new System.Drawing.Size(44, 17);
            this.chkLog.TabIndex = 15;
            this.chkLog.Text = "Log";
            this.chkLog.UseVisualStyleBackColor = true;
            // 
            // chkSetup
            // 
            this.chkSetup.AutoSize = true;
            this.chkSetup.Location = new System.Drawing.Point(634, 174);
            this.chkSetup.Name = "chkSetup";
            this.chkSetup.Size = new System.Drawing.Size(54, 17);
            this.chkSetup.TabIndex = 16;
            this.chkSetup.Text = "Setup";
            this.chkSetup.UseVisualStyleBackColor = true;
            // 
            // chkUtilities
            // 
            this.chkUtilities.AutoSize = true;
            this.chkUtilities.Location = new System.Drawing.Point(634, 206);
            this.chkUtilities.Name = "chkUtilities";
            this.chkUtilities.Size = new System.Drawing.Size(59, 17);
            this.chkUtilities.TabIndex = 17;
            this.chkUtilities.Text = "Utilities";
            this.chkUtilities.UseVisualStyleBackColor = true;
            // 
            // chkUserManagement
            // 
            this.chkUserManagement.AutoSize = true;
            this.chkUserManagement.Location = new System.Drawing.Point(634, 239);
            this.chkUserManagement.Name = "chkUserManagement";
            this.chkUserManagement.Size = new System.Drawing.Size(113, 17);
            this.chkUserManagement.TabIndex = 18;
            this.chkUserManagement.Text = "User Management";
            this.chkUserManagement.UseVisualStyleBackColor = true;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(473, 30);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(38, 20);
            this.txtID.TabIndex = 19;
            this.txtID.Visible = false;
            // 
            // UsersPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 478);
            this.ControlBox = false;
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.chkUserManagement);
            this.Controls.Add(this.chkUtilities);
            this.Controls.Add(this.chkSetup);
            this.Controls.Add(this.chkLog);
            this.Controls.Add(this.chkPrograms);
            this.Controls.Add(this.chkManual);
            this.Controls.Add(this.chkAuto);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdModify);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.txtPassword2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.lstUsers);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UsersPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UsersPage";
            this.Load += new System.EventHandler(this.UsersPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword2;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdModify;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.CheckBox chkAuto;
        private System.Windows.Forms.CheckBox chkManual;
        private System.Windows.Forms.CheckBox chkPrograms;
        private System.Windows.Forms.CheckBox chkLog;
        private System.Windows.Forms.CheckBox chkSetup;
        private System.Windows.Forms.CheckBox chkUtilities;
        private System.Windows.Forms.CheckBox chkUserManagement;
        private System.Windows.Forms.TextBox txtID;
    }
}