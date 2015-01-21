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
            this.SuspendLayout();
            // 
            // cmdAuto
            // 
            this.cmdAuto.Location = new System.Drawing.Point(24, 30);
            this.cmdAuto.Name = "cmdAuto";
            this.cmdAuto.Size = new System.Drawing.Size(75, 63);
            this.cmdAuto.TabIndex = 0;
            this.cmdAuto.Text = "Automatic";
            this.cmdAuto.UseVisualStyleBackColor = true;
            this.cmdAuto.Click += new System.EventHandler(this.cmdAuto_Click);
            // 
            // cmdManual
            // 
            this.cmdManual.Location = new System.Drawing.Point(132, 30);
            this.cmdManual.Name = "cmdManual";
            this.cmdManual.Size = new System.Drawing.Size(75, 63);
            this.cmdManual.TabIndex = 1;
            this.cmdManual.Text = "Manual";
            this.cmdManual.UseVisualStyleBackColor = true;
            this.cmdManual.Click += new System.EventHandler(this.cmdManual_Click);
            // 
            // cmdLogOut
            // 
            this.cmdLogOut.Location = new System.Drawing.Point(849, 30);
            this.cmdLogOut.Name = "cmdLogOut";
            this.cmdLogOut.Size = new System.Drawing.Size(75, 63);
            this.cmdLogOut.TabIndex = 2;
            this.cmdLogOut.Text = "Log Out";
            this.cmdLogOut.UseVisualStyleBackColor = true;
            this.cmdLogOut.Click += new System.EventHandler(this.cmdLogOut_Click);
            // 
            // cmdShutDown
            // 
            this.cmdShutDown.Location = new System.Drawing.Point(962, 30);
            this.cmdShutDown.Name = "cmdShutDown";
            this.cmdShutDown.Size = new System.Drawing.Size(75, 63);
            this.cmdShutDown.TabIndex = 3;
            this.cmdShutDown.Text = "Shut Down";
            this.cmdShutDown.UseVisualStyleBackColor = true;
            this.cmdShutDown.Click += new System.EventHandler(this.cmdShutDown_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 555);
            this.ControlBox = false;
            this.Controls.Add(this.cmdShutDown);
            this.Controls.Add(this.cmdLogOut);
            this.Controls.Add(this.cmdManual);
            this.Controls.Add(this.cmdAuto);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdAuto;
        private System.Windows.Forms.Button cmdManual;
        private System.Windows.Forms.Button cmdLogOut;
        private System.Windows.Forms.Button cmdShutDown;
    }
}