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
            // JanusManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 578);
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

        internal System.Windows.Forms.Button cmdController;
        internal System.Windows.Forms.Button cmdExit;
        internal System.Windows.Forms.Button cmdMagazine;
    }
}