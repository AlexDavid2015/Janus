namespace CxTitan
{
    partial class CouplerInformation
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
            this.gpbInformation = new System.Windows.Forms.GroupBox();
            this.txtDeviceDesc = new System.Windows.Forms.TextBox();
            this.labDevDesc = new System.Windows.Forms.Label();
            this.txtDeviceName = new System.Windows.Forms.TextBox();
            this.labDevName = new System.Windows.Forms.Label();
            this.txtFwVer2 = new System.Windows.Forms.TextBox();
            this.labFwVer2 = new System.Windows.Forms.Label();
            this.txtFpgaFwVer = new System.Windows.Forms.TextBox();
            this.labFPGAVer = new System.Windows.Forms.Label();
            this.txtFwVer = new System.Windows.Forms.TextBox();
            this.labFwVer = new System.Windows.Forms.Label();
            this.labModuleName = new System.Windows.Forms.Label();
            this.gpbNetworkSetting = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDefaultGateway = new System.Windows.Forms.TextBox();
            this.txtSubnetAddress = new System.Windows.Forms.TextBox();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.labMacAddress = new System.Windows.Forms.Label();
            this.txtMacAddress = new System.Windows.Forms.TextBox();
            this.labIPAddress = new System.Windows.Forms.Label();
            this.labSubnetMask = new System.Windows.Forms.Label();
            this.labDefaultGateway = new System.Windows.Forms.Label();
            this.labHostIdle = new System.Windows.Forms.Label();
            this.numHostIdle = new System.Windows.Forms.TextBox();
            this.cmdExit = new System.Windows.Forms.Button();
            this.gpbInformation.SuspendLayout();
            this.gpbNetworkSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbInformation
            // 
            this.gpbInformation.Controls.Add(this.txtDeviceDesc);
            this.gpbInformation.Controls.Add(this.labDevDesc);
            this.gpbInformation.Controls.Add(this.txtDeviceName);
            this.gpbInformation.Controls.Add(this.labDevName);
            this.gpbInformation.Controls.Add(this.txtFwVer2);
            this.gpbInformation.Controls.Add(this.labFwVer2);
            this.gpbInformation.Controls.Add(this.txtFpgaFwVer);
            this.gpbInformation.Controls.Add(this.labFPGAVer);
            this.gpbInformation.Controls.Add(this.txtFwVer);
            this.gpbInformation.Controls.Add(this.labFwVer);
            this.gpbInformation.Controls.Add(this.labModuleName);
            this.gpbInformation.Location = new System.Drawing.Point(30, 12);
            this.gpbInformation.Name = "gpbInformation";
            this.gpbInformation.Size = new System.Drawing.Size(387, 273);
            this.gpbInformation.TabIndex = 74;
            this.gpbInformation.TabStop = false;
            this.gpbInformation.Text = "Information";
            // 
            // txtDeviceDesc
            // 
            this.txtDeviceDesc.Enabled = false;
            this.txtDeviceDesc.Location = new System.Drawing.Point(123, 195);
            this.txtDeviceDesc.Multiline = true;
            this.txtDeviceDesc.Name = "txtDeviceDesc";
            this.txtDeviceDesc.ReadOnly = true;
            this.txtDeviceDesc.Size = new System.Drawing.Size(247, 55);
            this.txtDeviceDesc.TabIndex = 50;
            // 
            // labDevDesc
            // 
            this.labDevDesc.Location = new System.Drawing.Point(6, 198);
            this.labDevDesc.Name = "labDevDesc";
            this.labDevDesc.Size = new System.Drawing.Size(120, 22);
            this.labDevDesc.TabIndex = 51;
            this.labDevDesc.Text = "Device Description :";
            // 
            // txtDeviceName
            // 
            this.txtDeviceName.Enabled = false;
            this.txtDeviceName.Location = new System.Drawing.Point(123, 157);
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.ReadOnly = true;
            this.txtDeviceName.Size = new System.Drawing.Size(176, 20);
            this.txtDeviceName.TabIndex = 49;
            // 
            // labDevName
            // 
            this.labDevName.Location = new System.Drawing.Point(6, 159);
            this.labDevName.Name = "labDevName";
            this.labDevName.Size = new System.Drawing.Size(120, 22);
            this.labDevName.TabIndex = 52;
            this.labDevName.Text = "Device Name :";
            // 
            // txtFwVer2
            // 
            this.txtFwVer2.Enabled = false;
            this.txtFwVer2.Location = new System.Drawing.Point(123, 122);
            this.txtFwVer2.Name = "txtFwVer2";
            this.txtFwVer2.ReadOnly = true;
            this.txtFwVer2.Size = new System.Drawing.Size(176, 20);
            this.txtFwVer2.TabIndex = 48;
            // 
            // labFwVer2
            // 
            this.labFwVer2.Location = new System.Drawing.Point(6, 123);
            this.labFwVer2.Name = "labFwVer2";
            this.labFwVer2.Size = new System.Drawing.Size(120, 22);
            this.labFwVer2.TabIndex = 53;
            this.labFwVer2.Text = "Kernel Version :";
            // 
            // txtFpgaFwVer
            // 
            this.txtFpgaFwVer.Enabled = false;
            this.txtFpgaFwVer.Location = new System.Drawing.Point(123, 87);
            this.txtFpgaFwVer.Name = "txtFpgaFwVer";
            this.txtFpgaFwVer.ReadOnly = true;
            this.txtFpgaFwVer.Size = new System.Drawing.Size(176, 20);
            this.txtFpgaFwVer.TabIndex = 46;
            // 
            // labFPGAVer
            // 
            this.labFPGAVer.Location = new System.Drawing.Point(6, 90);
            this.labFPGAVer.Name = "labFPGAVer";
            this.labFPGAVer.Size = new System.Drawing.Size(120, 22);
            this.labFPGAVer.TabIndex = 54;
            this.labFPGAVer.Text = "FPGA Version :";
            // 
            // txtFwVer
            // 
            this.txtFwVer.Enabled = false;
            this.txtFwVer.Location = new System.Drawing.Point(123, 51);
            this.txtFwVer.Name = "txtFwVer";
            this.txtFwVer.ReadOnly = true;
            this.txtFwVer.Size = new System.Drawing.Size(176, 20);
            this.txtFwVer.TabIndex = 47;
            // 
            // labFwVer
            // 
            this.labFwVer.Location = new System.Drawing.Point(6, 54);
            this.labFwVer.Name = "labFwVer";
            this.labFwVer.Size = new System.Drawing.Size(120, 22);
            this.labFwVer.TabIndex = 55;
            this.labFwVer.Text = "Firmware Version :";
            // 
            // labModuleName
            // 
            this.labModuleName.Location = new System.Drawing.Point(6, 23);
            this.labModuleName.Name = "labModuleName";
            this.labModuleName.Size = new System.Drawing.Size(100, 22);
            this.labModuleName.TabIndex = 56;
            this.labModuleName.Text = "APAX-PAC";
            // 
            // gpbNetworkSetting
            // 
            this.gpbNetworkSetting.Controls.Add(this.label3);
            this.gpbNetworkSetting.Controls.Add(this.txtDefaultGateway);
            this.gpbNetworkSetting.Controls.Add(this.txtSubnetAddress);
            this.gpbNetworkSetting.Controls.Add(this.txtIPAddress);
            this.gpbNetworkSetting.Controls.Add(this.labMacAddress);
            this.gpbNetworkSetting.Controls.Add(this.txtMacAddress);
            this.gpbNetworkSetting.Controls.Add(this.labIPAddress);
            this.gpbNetworkSetting.Controls.Add(this.labSubnetMask);
            this.gpbNetworkSetting.Controls.Add(this.labDefaultGateway);
            this.gpbNetworkSetting.Controls.Add(this.labHostIdle);
            this.gpbNetworkSetting.Controls.Add(this.numHostIdle);
            this.gpbNetworkSetting.Location = new System.Drawing.Point(436, 12);
            this.gpbNetworkSetting.Name = "gpbNetworkSetting";
            this.gpbNetworkSetting.Size = new System.Drawing.Size(291, 273);
            this.gpbNetworkSetting.TabIndex = 75;
            this.gpbNetworkSetting.TabStop = false;
            this.gpbNetworkSetting.Text = "Coupler Host Network Setting";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(237, 22);
            this.label3.TabIndex = 11;
            this.label3.Text = "Network Setting";
            // 
            // txtDefaultGateway
            // 
            this.txtDefaultGateway.BackColor = System.Drawing.SystemColors.Control;
            this.txtDefaultGateway.Enabled = false;
            this.txtDefaultGateway.Location = new System.Drawing.Point(103, 156);
            this.txtDefaultGateway.Name = "txtDefaultGateway";
            this.txtDefaultGateway.Size = new System.Drawing.Size(167, 20);
            this.txtDefaultGateway.TabIndex = 12;
            // 
            // txtSubnetAddress
            // 
            this.txtSubnetAddress.BackColor = System.Drawing.SystemColors.Control;
            this.txtSubnetAddress.Enabled = false;
            this.txtSubnetAddress.Location = new System.Drawing.Point(103, 122);
            this.txtSubnetAddress.Name = "txtSubnetAddress";
            this.txtSubnetAddress.Size = new System.Drawing.Size(167, 20);
            this.txtSubnetAddress.TabIndex = 13;
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.BackColor = System.Drawing.SystemColors.Control;
            this.txtIPAddress.Enabled = false;
            this.txtIPAddress.Location = new System.Drawing.Point(103, 87);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(167, 20);
            this.txtIPAddress.TabIndex = 14;
            // 
            // labMacAddress
            // 
            this.labMacAddress.Location = new System.Drawing.Point(6, 54);
            this.labMacAddress.Name = "labMacAddress";
            this.labMacAddress.Size = new System.Drawing.Size(96, 17);
            this.labMacAddress.TabIndex = 15;
            this.labMacAddress.Text = "Mac Address";
            // 
            // txtMacAddress
            // 
            this.txtMacAddress.BackColor = System.Drawing.SystemColors.Control;
            this.txtMacAddress.Enabled = false;
            this.txtMacAddress.Location = new System.Drawing.Point(103, 51);
            this.txtMacAddress.Name = "txtMacAddress";
            this.txtMacAddress.Size = new System.Drawing.Size(167, 20);
            this.txtMacAddress.TabIndex = 16;
            // 
            // labIPAddress
            // 
            this.labIPAddress.Location = new System.Drawing.Point(6, 90);
            this.labIPAddress.Name = "labIPAddress";
            this.labIPAddress.Size = new System.Drawing.Size(96, 17);
            this.labIPAddress.TabIndex = 17;
            this.labIPAddress.Text = "IP Address";
            // 
            // labSubnetMask
            // 
            this.labSubnetMask.Location = new System.Drawing.Point(6, 125);
            this.labSubnetMask.Name = "labSubnetMask";
            this.labSubnetMask.Size = new System.Drawing.Size(96, 17);
            this.labSubnetMask.TabIndex = 18;
            this.labSubnetMask.Text = "Subnet Mask";
            // 
            // labDefaultGateway
            // 
            this.labDefaultGateway.Location = new System.Drawing.Point(6, 159);
            this.labDefaultGateway.Name = "labDefaultGateway";
            this.labDefaultGateway.Size = new System.Drawing.Size(96, 17);
            this.labDefaultGateway.TabIndex = 19;
            this.labDefaultGateway.Text = "Default Gateway";
            // 
            // labHostIdle
            // 
            this.labHostIdle.Location = new System.Drawing.Point(6, 198);
            this.labHostIdle.Name = "labHostIdle";
            this.labHostIdle.Size = new System.Drawing.Size(96, 17);
            this.labHostIdle.TabIndex = 20;
            this.labHostIdle.Text = "Host Idle Timeout";
            // 
            // numHostIdle
            // 
            this.numHostIdle.BackColor = System.Drawing.SystemColors.Control;
            this.numHostIdle.Enabled = false;
            this.numHostIdle.Location = new System.Drawing.Point(103, 195);
            this.numHostIdle.Name = "numHostIdle";
            this.numHostIdle.Size = new System.Drawing.Size(167, 20);
            this.numHostIdle.TabIndex = 21;
            // 
            // cmdExit
            // 
            this.cmdExit.Location = new System.Drawing.Point(747, 13);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(75, 75);
            this.cmdExit.TabIndex = 76;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // CouplerInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 306);
            this.ControlBox = false;
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.gpbNetworkSetting);
            this.Controls.Add(this.gpbInformation);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CouplerInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CouplerInformation";
            this.Load += new System.EventHandler(this.CouplerInformation_Load);
            this.gpbInformation.ResumeLayout(false);
            this.gpbInformation.PerformLayout();
            this.gpbNetworkSetting.ResumeLayout(false);
            this.gpbNetworkSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox gpbInformation;
        internal System.Windows.Forms.GroupBox gpbNetworkSetting;
        private System.Windows.Forms.TextBox txtDeviceDesc;
        private System.Windows.Forms.Label labDevDesc;
        private System.Windows.Forms.TextBox txtDeviceName;
        private System.Windows.Forms.Label labDevName;
        private System.Windows.Forms.TextBox txtFwVer2;
        private System.Windows.Forms.Label labFwVer2;
        private System.Windows.Forms.TextBox txtFpgaFwVer;
        private System.Windows.Forms.Label labFPGAVer;
        private System.Windows.Forms.TextBox txtFwVer;
        private System.Windows.Forms.Label labFwVer;
        private System.Windows.Forms.Label labModuleName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDefaultGateway;
        private System.Windows.Forms.TextBox txtSubnetAddress;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label labMacAddress;
        private System.Windows.Forms.TextBox txtMacAddress;
        private System.Windows.Forms.Label labIPAddress;
        private System.Windows.Forms.Label labSubnetMask;
        private System.Windows.Forms.Label labDefaultGateway;
        private System.Windows.Forms.Label labHostIdle;
        private System.Windows.Forms.TextBox numHostIdle;
        internal System.Windows.Forms.Button cmdExit;
    }
}