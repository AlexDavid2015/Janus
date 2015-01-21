namespace CxTitan
{
    partial class JanusManual
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
            this.cmdMagazine = new System.Windows.Forms.Button();
            this.cmdController = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cbxLanguageSelection = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdMagazine
            // 
            this.cmdMagazine.Location = new System.Drawing.Point(162, 55);
            this.cmdMagazine.Name = "cmdMagazine";
            this.cmdMagazine.Size = new System.Drawing.Size(75, 75);
            this.cmdMagazine.TabIndex = 3;
            this.cmdMagazine.Text = "Magazine";
            this.cmdMagazine.UseVisualStyleBackColor = true;
            this.cmdMagazine.Click += new System.EventHandler(this.cmdMagazine_Click);
            // 
            // cmdController
            // 
            this.cmdController.Location = new System.Drawing.Point(50, 55);
            this.cmdController.Name = "cmdController";
            this.cmdController.Size = new System.Drawing.Size(75, 75);
            this.cmdController.TabIndex = 2;
            this.cmdController.Text = "Controller";
            this.cmdController.UseVisualStyleBackColor = true;
            this.cmdController.Click += new System.EventHandler(this.cmdController_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Location = new System.Drawing.Point(755, 474);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(75, 75);
            this.cmdExit.TabIndex = 4;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cbxLanguageSelection
            // 
            this.cbxLanguageSelection.Location = new System.Drawing.Point(755, 27);
            this.cbxLanguageSelection.Name = "cbxLanguageSelection";
            this.cbxLanguageSelection.Size = new System.Drawing.Size(75, 21);
            this.cbxLanguageSelection.TabIndex = 69;
            this.cbxLanguageSelection.SelectedIndexChanged += new System.EventHandler(this.cbxLanguageSelection_SelectedIndexChanged);
            // 
            // lblLanguage
            // 
            this.lblLanguage.Location = new System.Drawing.Point(752, 9);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(64, 15);
            this.lblLanguage.TabIndex = 70;
            this.lblLanguage.Text = "Language:";
            // 
            // JanusManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 578);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.cbxLanguageSelection);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdMagazine);
            this.Controls.Add(this.cmdController);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JanusManual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JANUS Manual Page ";
            this.Load += new System.EventHandler(this.JanusManual_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdMagazine;
        internal System.Windows.Forms.Button cmdController;
        internal System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.ComboBox cbxLanguageSelection;
        private System.Windows.Forms.Label lblLanguage;
    }
}