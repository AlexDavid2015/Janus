namespace CxTitan
{
    partial class LoginPage
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
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdClear = new System.Windows.Forms.Button();
            this.cmdShutDown = new System.Windows.Forms.Button();
            this.cmdOP = new System.Windows.Forms.Button();
            this.cbxLanguageSelection = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(48, 40);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(116, 23);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "UserName:";
            // 
            // lblPassword
            // 
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(48, 93);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(101, 23);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(199, 43);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(201, 20);
            this.txtUserName.TabIndex = 2;
            this.txtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserName_KeyPress);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(199, 96);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(201, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // cmdOK
            // 
            this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.Location = new System.Drawing.Point(52, 236);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(97, 92);
            this.cmdOK.TabIndex = 4;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdClear
            // 
            this.cmdClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClear.Location = new System.Drawing.Point(303, 377);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(97, 92);
            this.cmdClear.TabIndex = 5;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // cmdShutDown
            // 
            this.cmdShutDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdShutDown.Location = new System.Drawing.Point(52, 377);
            this.cmdShutDown.Name = "cmdShutDown";
            this.cmdShutDown.Size = new System.Drawing.Size(97, 92);
            this.cmdShutDown.TabIndex = 6;
            this.cmdShutDown.Text = "ShutDown";
            this.cmdShutDown.UseVisualStyleBackColor = true;
            this.cmdShutDown.Click += new System.EventHandler(this.cmdShutDown_Click);
            // 
            // cmdOP
            // 
            this.cmdOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOP.Location = new System.Drawing.Point(303, 236);
            this.cmdOP.Name = "cmdOP";
            this.cmdOP.Size = new System.Drawing.Size(97, 92);
            this.cmdOP.TabIndex = 7;
            this.cmdOP.Text = "Operator";
            this.cmdOP.UseVisualStyleBackColor = true;
            this.cmdOP.Click += new System.EventHandler(this.cmdOP_Click);
            // 
            // cbxLanguageSelection
            // 
            this.cbxLanguageSelection.Location = new System.Drawing.Point(410, 7);
            this.cbxLanguageSelection.Name = "cbxLanguageSelection";
            this.cbxLanguageSelection.Size = new System.Drawing.Size(63, 21);
            this.cbxLanguageSelection.TabIndex = 72;
            this.cbxLanguageSelection.SelectedIndexChanged += new System.EventHandler(this.cbxLanguageSelection_SelectedIndexChanged);
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 498);
            this.ControlBox = false;
            this.Controls.Add(this.cbxLanguageSelection);
            this.Controls.Add(this.cmdOP);
            this.Controls.Add(this.cmdShutDown);
            this.Controls.Add(this.cmdClear);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginPage";
            this.Load += new System.EventHandler(this.LoginPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.Label lblUserName;
        internal System.Windows.Forms.Label lblPassword;
        internal System.Windows.Forms.Button cmdOK;
        internal System.Windows.Forms.Button cmdOP;
        internal System.Windows.Forms.Button cmdShutDown;
        internal System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.ComboBox cbxLanguageSelection;
    }
}