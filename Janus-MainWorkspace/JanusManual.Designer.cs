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
            this.cmdBridge = new System.Windows.Forms.Button();
            this.cmdChamberTrack = new System.Windows.Forms.Button();
            this.cmdLIFT = new System.Windows.Forms.Button();
            this.cmdLeadFrameExtractor = new System.Windows.Forms.Button();
            this.cmdPusherGripperAssy = new System.Windows.Forms.Button();
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
            // cmdBridge
            // 
            this.cmdBridge.Location = new System.Drawing.Point(270, 55);
            this.cmdBridge.Name = "cmdBridge";
            this.cmdBridge.Size = new System.Drawing.Size(75, 75);
            this.cmdBridge.TabIndex = 5;
            this.cmdBridge.Text = "Bridge";
            this.cmdBridge.UseVisualStyleBackColor = true;
            this.cmdBridge.Click += new System.EventHandler(this.cmdBridge_Click);
            // 
            // cmdChamberTrack
            // 
            this.cmdChamberTrack.Location = new System.Drawing.Point(381, 55);
            this.cmdChamberTrack.Name = "cmdChamberTrack";
            this.cmdChamberTrack.Size = new System.Drawing.Size(75, 75);
            this.cmdChamberTrack.TabIndex = 6;
            this.cmdChamberTrack.Text = "Chamber Track";
            this.cmdChamberTrack.UseVisualStyleBackColor = true;
            this.cmdChamberTrack.Click += new System.EventHandler(this.cmdChamberTrack_Click);
            // 
            // cmdLIFT
            // 
            this.cmdLIFT.Location = new System.Drawing.Point(491, 55);
            this.cmdLIFT.Name = "cmdLIFT";
            this.cmdLIFT.Size = new System.Drawing.Size(75, 75);
            this.cmdLIFT.TabIndex = 7;
            this.cmdLIFT.Text = "LIFT";
            this.cmdLIFT.UseVisualStyleBackColor = true;
            this.cmdLIFT.Click += new System.EventHandler(this.cmdLIFT_Click);
            // 
            // cmdLeadFrameExtractor
            // 
            this.cmdLeadFrameExtractor.Location = new System.Drawing.Point(708, 55);
            this.cmdLeadFrameExtractor.Name = "cmdLeadFrameExtractor";
            this.cmdLeadFrameExtractor.Size = new System.Drawing.Size(75, 75);
            this.cmdLeadFrameExtractor.TabIndex = 8;
            this.cmdLeadFrameExtractor.Text = "Lead Frame Extractor";
            this.cmdLeadFrameExtractor.UseVisualStyleBackColor = true;
            this.cmdLeadFrameExtractor.Click += new System.EventHandler(this.cmdLeadFrameExtractor_Click);
            // 
            // cmdPusherGripperAssy
            // 
            this.cmdPusherGripperAssy.Location = new System.Drawing.Point(600, 55);
            this.cmdPusherGripperAssy.Name = "cmdPusherGripperAssy";
            this.cmdPusherGripperAssy.Size = new System.Drawing.Size(75, 75);
            this.cmdPusherGripperAssy.TabIndex = 9;
            this.cmdPusherGripperAssy.Text = "Pusher & Gripper Assembly";
            this.cmdPusherGripperAssy.UseVisualStyleBackColor = true;
            this.cmdPusherGripperAssy.Click += new System.EventHandler(this.cmdPusherGripperAssy_Click);
            // 
            // JanusManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 578);
            this.Controls.Add(this.cmdPusherGripperAssy);
            this.Controls.Add(this.cmdLeadFrameExtractor);
            this.Controls.Add(this.cmdLIFT);
            this.Controls.Add(this.cmdChamberTrack);
            this.Controls.Add(this.cmdBridge);
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
        internal System.Windows.Forms.Button cmdBridge;
        internal System.Windows.Forms.Button cmdChamberTrack;
        internal System.Windows.Forms.Button cmdLIFT;
        internal System.Windows.Forms.Button cmdLeadFrameExtractor;
        internal System.Windows.Forms.Button cmdPusherGripperAssy;
    }
}