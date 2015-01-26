namespace CxTitan
{
    partial class Splash
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
            this.components = new System.ComponentModel.Container();
            this.lblVersion = new System.Windows.Forms.Label();
            this.PBar = new System.Windows.Forms.ProgressBar();
            this.WaitTime = new System.Windows.Forms.Timer(this.components);
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(95, 508);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(660, 90);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "Version";
            // 
            // PBar
            // 
            this.PBar.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.PBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PBar.Location = new System.Drawing.Point(0, 613);
            this.PBar.MarqueeAnimationSpeed = 10;
            this.PBar.Minimum = 1;
            this.PBar.Name = "PBar";
            this.PBar.Size = new System.Drawing.Size(859, 23);
            this.PBar.TabIndex = 3;
            this.PBar.UseWaitCursor = true;
            this.PBar.Value = 1;
            // 
            // WaitTime
            // 
            this.WaitTime.Tick += new System.EventHandler(this.WaitTime_Tick);
            // 
            // PictureBox2
            // 
            this.PictureBox2.Image = global::CxTitan.Properties.Resources.Janus2;
            this.PictureBox2.Location = new System.Drawing.Point(30, 12);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(309, 79);
            this.PictureBox2.TabIndex = 4;
            this.PictureBox2.TabStop = false;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Location = new System.Drawing.Point(521, 12);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(326, 482);
            this.PictureBox1.TabIndex = 0;
            this.PictureBox1.TabStop = false;
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 636);
            this.ControlBox = false;
            this.Controls.Add(this.PictureBox2);
            this.Controls.Add(this.PBar);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.PictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SCI Automation JANUS";
            this.Load += new System.EventHandler(this.Splash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBox1;
        private System.Windows.Forms.Label lblVersion;
        internal System.Windows.Forms.ProgressBar PBar;
        internal System.Windows.Forms.Timer WaitTime;
        private System.Windows.Forms.PictureBox PictureBox2;
    }
}