namespace CxTitan
{
    partial class XThreadPage
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
            this.gpbProgramControl = new System.Windows.Forms.GroupBox();
            this.cmdContinue = new System.Windows.Forms.Button();
            this.cmdPause = new System.Windows.Forms.Button();
            this.cmdStop = new System.Windows.Forms.Button();
            this.cmdRun = new System.Windows.Forms.Button();
            this.txtProgram1Index = new System.Windows.Forms.TextBox();
            this.txtProgram0Index = new System.Windows.Forms.TextBox();
            this.lblProgram1Index = new System.Windows.Forms.Label();
            this.lblProgram0Index = new System.Windows.Forms.Label();
            this.txtProgram1Status = new System.Windows.Forms.TextBox();
            this.lblProgram1Status = new System.Windows.Forms.Label();
            this.txtProgram0Status = new System.Windows.Forms.TextBox();
            this.gpbPrograms = new System.Windows.Forms.GroupBox();
            this.radProgram1 = new System.Windows.Forms.RadioButton();
            this.radProgram0 = new System.Windows.Forms.RadioButton();
            this.lblProgram0Status = new System.Windows.Forms.Label();
            this.lblProgram1 = new System.Windows.Forms.Label();
            this.lblProgram0 = new System.Windows.Forms.Label();
            this.cmdClose = new System.Windows.Forms.Button();
            this.TimerProgramControl = new System.Windows.Forms.Timer(this.components);
            this.gpbProgramControl.SuspendLayout();
            this.gpbPrograms.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbProgramControl
            // 
            this.gpbProgramControl.Controls.Add(this.cmdContinue);
            this.gpbProgramControl.Controls.Add(this.cmdPause);
            this.gpbProgramControl.Controls.Add(this.cmdStop);
            this.gpbProgramControl.Controls.Add(this.cmdRun);
            this.gpbProgramControl.Controls.Add(this.txtProgram1Index);
            this.gpbProgramControl.Controls.Add(this.txtProgram0Index);
            this.gpbProgramControl.Controls.Add(this.lblProgram1Index);
            this.gpbProgramControl.Controls.Add(this.lblProgram0Index);
            this.gpbProgramControl.Controls.Add(this.txtProgram1Status);
            this.gpbProgramControl.Controls.Add(this.lblProgram1Status);
            this.gpbProgramControl.Controls.Add(this.txtProgram0Status);
            this.gpbProgramControl.Controls.Add(this.gpbPrograms);
            this.gpbProgramControl.Controls.Add(this.lblProgram0Status);
            this.gpbProgramControl.Controls.Add(this.lblProgram1);
            this.gpbProgramControl.Controls.Add(this.lblProgram0);
            this.gpbProgramControl.Location = new System.Drawing.Point(12, 12);
            this.gpbProgramControl.Name = "gpbProgramControl";
            this.gpbProgramControl.Size = new System.Drawing.Size(394, 186);
            this.gpbProgramControl.TabIndex = 94;
            this.gpbProgramControl.TabStop = false;
            this.gpbProgramControl.Text = "Program Control";
            // 
            // cmdContinue
            // 
            this.cmdContinue.Location = new System.Drawing.Point(314, 109);
            this.cmdContinue.Name = "cmdContinue";
            this.cmdContinue.Size = new System.Drawing.Size(56, 50);
            this.cmdContinue.TabIndex = 103;
            this.cmdContinue.Text = "Cont";
            this.cmdContinue.UseVisualStyleBackColor = true;
            this.cmdContinue.Click += new System.EventHandler(this.cmdContinue_Click);
            // 
            // cmdPause
            // 
            this.cmdPause.Location = new System.Drawing.Point(252, 109);
            this.cmdPause.Name = "cmdPause";
            this.cmdPause.Size = new System.Drawing.Size(56, 50);
            this.cmdPause.TabIndex = 104;
            this.cmdPause.Text = "Pause";
            this.cmdPause.UseVisualStyleBackColor = true;
            this.cmdPause.Click += new System.EventHandler(this.cmdPause_Click);
            // 
            // cmdStop
            // 
            this.cmdStop.Location = new System.Drawing.Point(190, 109);
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(56, 50);
            this.cmdStop.TabIndex = 103;
            this.cmdStop.Text = "Stop";
            this.cmdStop.UseVisualStyleBackColor = true;
            this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
            // 
            // cmdRun
            // 
            this.cmdRun.Location = new System.Drawing.Point(128, 109);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(56, 50);
            this.cmdRun.TabIndex = 102;
            this.cmdRun.Text = "Run";
            this.cmdRun.UseVisualStyleBackColor = true;
            this.cmdRun.Click += new System.EventHandler(this.cmdRun_Click);
            // 
            // txtProgram1Index
            // 
            this.txtProgram1Index.Enabled = false;
            this.txtProgram1Index.Location = new System.Drawing.Point(320, 53);
            this.txtProgram1Index.Name = "txtProgram1Index";
            this.txtProgram1Index.ReadOnly = true;
            this.txtProgram1Index.Size = new System.Drawing.Size(44, 20);
            this.txtProgram1Index.TabIndex = 101;
            // 
            // txtProgram0Index
            // 
            this.txtProgram0Index.Enabled = false;
            this.txtProgram0Index.Location = new System.Drawing.Point(320, 25);
            this.txtProgram0Index.Name = "txtProgram0Index";
            this.txtProgram0Index.ReadOnly = true;
            this.txtProgram0Index.Size = new System.Drawing.Size(44, 20);
            this.txtProgram0Index.TabIndex = 100;
            // 
            // lblProgram1Index
            // 
            this.lblProgram1Index.Location = new System.Drawing.Point(277, 56);
            this.lblProgram1Index.Name = "lblProgram1Index";
            this.lblProgram1Index.Size = new System.Drawing.Size(41, 17);
            this.lblProgram1Index.TabIndex = 99;
            this.lblProgram1Index.Text = "Index";
            // 
            // lblProgram0Index
            // 
            this.lblProgram0Index.Location = new System.Drawing.Point(277, 28);
            this.lblProgram0Index.Name = "lblProgram0Index";
            this.lblProgram0Index.Size = new System.Drawing.Size(41, 17);
            this.lblProgram0Index.TabIndex = 98;
            this.lblProgram0Index.Text = "Index";
            // 
            // txtProgram1Status
            // 
            this.txtProgram1Status.Enabled = false;
            this.txtProgram1Status.Location = new System.Drawing.Point(172, 51);
            this.txtProgram1Status.Name = "txtProgram1Status";
            this.txtProgram1Status.ReadOnly = true;
            this.txtProgram1Status.Size = new System.Drawing.Size(44, 20);
            this.txtProgram1Status.TabIndex = 97;
            // 
            // lblProgram1Status
            // 
            this.lblProgram1Status.Location = new System.Drawing.Point(125, 56);
            this.lblProgram1Status.Name = "lblProgram1Status";
            this.lblProgram1Status.Size = new System.Drawing.Size(41, 17);
            this.lblProgram1Status.TabIndex = 96;
            this.lblProgram1Status.Text = "Status";
            // 
            // txtProgram0Status
            // 
            this.txtProgram0Status.Enabled = false;
            this.txtProgram0Status.Location = new System.Drawing.Point(172, 25);
            this.txtProgram0Status.Name = "txtProgram0Status";
            this.txtProgram0Status.ReadOnly = true;
            this.txtProgram0Status.Size = new System.Drawing.Size(44, 20);
            this.txtProgram0Status.TabIndex = 95;
            // 
            // gpbPrograms
            // 
            this.gpbPrograms.Controls.Add(this.radProgram1);
            this.gpbPrograms.Controls.Add(this.radProgram0);
            this.gpbPrograms.Location = new System.Drawing.Point(13, 102);
            this.gpbPrograms.Name = "gpbPrograms";
            this.gpbPrograms.Size = new System.Drawing.Size(95, 57);
            this.gpbPrograms.TabIndex = 94;
            this.gpbPrograms.TabStop = false;
            // 
            // radProgram1
            // 
            this.radProgram1.AutoSize = true;
            this.radProgram1.Location = new System.Drawing.Point(6, 31);
            this.radProgram1.Name = "radProgram1";
            this.radProgram1.Size = new System.Drawing.Size(73, 17);
            this.radProgram1.TabIndex = 1;
            this.radProgram1.Text = "Program 1";
            this.radProgram1.UseVisualStyleBackColor = true;
            // 
            // radProgram0
            // 
            this.radProgram0.AutoSize = true;
            this.radProgram0.Checked = true;
            this.radProgram0.Location = new System.Drawing.Point(6, 9);
            this.radProgram0.Name = "radProgram0";
            this.radProgram0.Size = new System.Drawing.Size(73, 17);
            this.radProgram0.TabIndex = 0;
            this.radProgram0.TabStop = true;
            this.radProgram0.Text = "Program 0";
            this.radProgram0.UseVisualStyleBackColor = true;
            // 
            // lblProgram0Status
            // 
            this.lblProgram0Status.Location = new System.Drawing.Point(125, 28);
            this.lblProgram0Status.Name = "lblProgram0Status";
            this.lblProgram0Status.Size = new System.Drawing.Size(41, 17);
            this.lblProgram0Status.TabIndex = 90;
            this.lblProgram0Status.Text = "Status";
            // 
            // lblProgram1
            // 
            this.lblProgram1.Location = new System.Drawing.Point(10, 56);
            this.lblProgram1.Name = "lblProgram1";
            this.lblProgram1.Size = new System.Drawing.Size(71, 17);
            this.lblProgram1.TabIndex = 59;
            this.lblProgram1.Text = "Program 1";
            // 
            // lblProgram0
            // 
            this.lblProgram0.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProgram0.Location = new System.Drawing.Point(10, 28);
            this.lblProgram0.Name = "lblProgram0";
            this.lblProgram0.Size = new System.Drawing.Size(71, 13);
            this.lblProgram0.TabIndex = 76;
            this.lblProgram0.Text = "Program 0";
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(140, 215);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(118, 36);
            this.cmdClose.TabIndex = 105;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // TimerProgramControl
            // 
            this.TimerProgramControl.Interval = 300;
            this.TimerProgramControl.Tick += new System.EventHandler(this.TimerProgramControl_Tick);
            // 
            // XThreadPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 263);
            this.ControlBox = false;
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.gpbProgramControl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XThreadPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multi-Thread Control";
            this.Load += new System.EventHandler(this.XThreadPage_Load);
            this.gpbProgramControl.ResumeLayout(false);
            this.gpbProgramControl.PerformLayout();
            this.gpbPrograms.ResumeLayout(false);
            this.gpbPrograms.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox gpbProgramControl;
        private System.Windows.Forms.GroupBox gpbPrograms;
        private System.Windows.Forms.RadioButton radProgram1;
        private System.Windows.Forms.RadioButton radProgram0;
        private System.Windows.Forms.Label lblProgram0Status;
        private System.Windows.Forms.Label lblProgram1;
        private System.Windows.Forms.Label lblProgram0;
        private System.Windows.Forms.TextBox txtProgram0Status;
        private System.Windows.Forms.Label lblProgram1Status;
        private System.Windows.Forms.TextBox txtProgram1Status;
        private System.Windows.Forms.Label lblProgram1Index;
        private System.Windows.Forms.Label lblProgram0Index;
        private System.Windows.Forms.TextBox txtProgram1Index;
        private System.Windows.Forms.TextBox txtProgram0Index;
        internal System.Windows.Forms.Button cmdRun;
        internal System.Windows.Forms.Button cmdContinue;
        internal System.Windows.Forms.Button cmdPause;
        internal System.Windows.Forms.Button cmdStop;
        internal System.Windows.Forms.Button cmdClose;
        internal System.Windows.Forms.Timer TimerProgramControl;
    }
}