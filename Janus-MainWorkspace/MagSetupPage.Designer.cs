namespace CxTitan
{
    partial class MagSetupPage
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
            this.gpbPolarity = new System.Windows.Forms.GroupBox();
            this.gpbSetupPara = new System.Windows.Forms.GroupBox();
            this.gpbCommunicatinSetup = new System.Windows.Forms.GroupBox();
            this.combxBaudRate = new System.Windows.Forms.ComboBox();
            this.txtTimeOutCounter = new System.Windows.Forms.TextBox();
            this.lblTimeOutCounter = new System.Windows.Forms.Label();
            this.lblDeviceID = new System.Windows.Forms.Label();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.chbxSyncOutputEnableDO2 = new System.Windows.Forms.CheckBox();
            this.combxDeviceID = new System.Windows.Forms.ComboBox();
            this.gpbRSCommunication = new System.Windows.Forms.GroupBox();
            this.chbAutoResponse = new System.Windows.Forms.CheckBox();
            this.lblMS = new System.Windows.Forms.Label();
            this.radRS485 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.gpbMiscSettings = new System.Windows.Forms.GroupBox();
            this.chbxEnableDecel = new System.Windows.Forms.CheckBox();
            this.chbxIERR = new System.Windows.Forms.CheckBox();
            this.chbxAutoRun0 = new System.Windows.Forms.CheckBox();
            this.chbxAutoRun1 = new System.Windows.Forms.CheckBox();
            this.chbxAlmLnp = new System.Windows.Forms.CheckBox();
            this.chbxRZ = new System.Windows.Forms.CheckBox();
            this.lblEOBoot = new System.Windows.Forms.Label();
            this.lblDOBoot = new System.Windows.Forms.Label();
            this.lblLCA = new System.Windows.Forms.Label();
            this.lblHCA = new System.Windows.Forms.Label();
            this.txtEOBoot = new System.Windows.Forms.TextBox();
            this.txtDOBoot = new System.Windows.Forms.TextBox();
            this.txtLCA = new System.Windows.Forms.TextBox();
            this.txtHCA = new System.Windows.Forms.TextBox();
            this.gpbStepNLoopControl = new System.Windows.Forms.GroupBox();
            this.txtErrorRange = new System.Windows.Forms.TextBox();
            this.lblErrorRange = new System.Windows.Forms.Label();
            this.txtIdleTol = new System.Windows.Forms.TextBox();
            this.lblIdleTol = new System.Windows.Forms.Label();
            this.txtTolerance = new System.Windows.Forms.TextBox();
            this.lblTolerance = new System.Windows.Forms.Label();
            this.lblMaxAttempt = new System.Windows.Forms.Label();
            this.chbxStepNLoopControlEnable = new System.Windows.Forms.CheckBox();
            this.txtMaxAttempt = new System.Windows.Forms.TextBox();
            this.gpbDriverCurrent = new System.Windows.Forms.GroupBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.txtRun = new System.Windows.Forms.TextBox();
            this.lblIdle = new System.Windows.Forms.Label();
            this.lblRun = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblRunMA = new System.Windows.Forms.Label();
            this.lblIdleMA = new System.Windows.Forms.Label();
            this.lblTimeMS = new System.Windows.Forms.Label();
            this.cmdOpen = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdUpload = new System.Windows.Forms.Button();
            this.cmdDown = new System.Windows.Forms.Button();
            this.cmdStore = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.gpbSetupPara.SuspendLayout();
            this.gpbCommunicatinSetup.SuspendLayout();
            this.gpbRSCommunication.SuspendLayout();
            this.gpbMiscSettings.SuspendLayout();
            this.gpbStepNLoopControl.SuspendLayout();
            this.gpbDriverCurrent.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbPolarity
            // 
            this.gpbPolarity.Location = new System.Drawing.Point(6, 10);
            this.gpbPolarity.Name = "gpbPolarity";
            this.gpbPolarity.Size = new System.Drawing.Size(283, 338);
            this.gpbPolarity.TabIndex = 77;
            this.gpbPolarity.TabStop = false;
            this.gpbPolarity.Text = "Polarity";
            // 
            // gpbSetupPara
            // 
            this.gpbSetupPara.Controls.Add(this.cmdClose);
            this.gpbSetupPara.Controls.Add(this.cmdStore);
            this.gpbSetupPara.Controls.Add(this.cmdDown);
            this.gpbSetupPara.Controls.Add(this.cmdUpload);
            this.gpbSetupPara.Controls.Add(this.cmdSave);
            this.gpbSetupPara.Controls.Add(this.cmdOpen);
            this.gpbSetupPara.Controls.Add(this.gpbDriverCurrent);
            this.gpbSetupPara.Controls.Add(this.gpbStepNLoopControl);
            this.gpbSetupPara.Controls.Add(this.gpbMiscSettings);
            this.gpbSetupPara.Controls.Add(this.gpbCommunicatinSetup);
            this.gpbSetupPara.Controls.Add(this.gpbPolarity);
            this.gpbSetupPara.Location = new System.Drawing.Point(12, 1);
            this.gpbSetupPara.Name = "gpbSetupPara";
            this.gpbSetupPara.Size = new System.Drawing.Size(565, 648);
            this.gpbSetupPara.TabIndex = 92;
            this.gpbSetupPara.TabStop = false;
            // 
            // gpbCommunicatinSetup
            // 
            this.gpbCommunicatinSetup.Controls.Add(this.lblMS);
            this.gpbCommunicatinSetup.Controls.Add(this.chbAutoResponse);
            this.gpbCommunicatinSetup.Controls.Add(this.gpbRSCommunication);
            this.gpbCommunicatinSetup.Controls.Add(this.combxDeviceID);
            this.gpbCommunicatinSetup.Controls.Add(this.combxBaudRate);
            this.gpbCommunicatinSetup.Controls.Add(this.txtTimeOutCounter);
            this.gpbCommunicatinSetup.Controls.Add(this.lblTimeOutCounter);
            this.gpbCommunicatinSetup.Controls.Add(this.lblDeviceID);
            this.gpbCommunicatinSetup.Controls.Add(this.lblBaudRate);
            this.gpbCommunicatinSetup.Controls.Add(this.chbxSyncOutputEnableDO2);
            this.gpbCommunicatinSetup.Location = new System.Drawing.Point(309, 10);
            this.gpbCommunicatinSetup.Name = "gpbCommunicatinSetup";
            this.gpbCommunicatinSetup.Size = new System.Drawing.Size(250, 186);
            this.gpbCommunicatinSetup.TabIndex = 93;
            this.gpbCommunicatinSetup.TabStop = false;
            this.gpbCommunicatinSetup.Text = "Communication Setup";
            // 
            // combxBaudRate
            // 
            this.combxBaudRate.FormattingEnabled = true;
            this.combxBaudRate.Location = new System.Drawing.Point(131, 85);
            this.combxBaudRate.Name = "combxBaudRate";
            this.combxBaudRate.Size = new System.Drawing.Size(99, 21);
            this.combxBaudRate.TabIndex = 92;
            // 
            // txtTimeOutCounter
            // 
            this.txtTimeOutCounter.Enabled = false;
            this.txtTimeOutCounter.Location = new System.Drawing.Point(131, 157);
            this.txtTimeOutCounter.Name = "txtTimeOutCounter";
            this.txtTimeOutCounter.ReadOnly = true;
            this.txtTimeOutCounter.Size = new System.Drawing.Size(60, 20);
            this.txtTimeOutCounter.TabIndex = 91;
            this.txtTimeOutCounter.Text = "0";
            // 
            // lblTimeOutCounter
            // 
            this.lblTimeOutCounter.Location = new System.Drawing.Point(10, 160);
            this.lblTimeOutCounter.Name = "lblTimeOutCounter";
            this.lblTimeOutCounter.Size = new System.Drawing.Size(98, 17);
            this.lblTimeOutCounter.TabIndex = 90;
            this.lblTimeOutCounter.Text = "Time-out Counter";
            // 
            // lblDeviceID
            // 
            this.lblDeviceID.Location = new System.Drawing.Point(10, 123);
            this.lblDeviceID.Name = "lblDeviceID";
            this.lblDeviceID.Size = new System.Drawing.Size(71, 17);
            this.lblDeviceID.TabIndex = 59;
            this.lblDeviceID.Text = "Device ID";
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBaudRate.Location = new System.Drawing.Point(10, 88);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(71, 13);
            this.lblBaudRate.TabIndex = 76;
            this.lblBaudRate.Text = "Baud Rate";
            // 
            // chbxSyncOutputEnableDO2
            // 
            this.chbxSyncOutputEnableDO2.Location = new System.Drawing.Point(131, 19);
            this.chbxSyncOutputEnableDO2.Name = "chbxSyncOutputEnableDO2";
            this.chbxSyncOutputEnableDO2.Size = new System.Drawing.Size(81, 26);
            this.chbxSyncOutputEnableDO2.TabIndex = 87;
            this.chbxSyncOutputEnableDO2.Text = "Append ID";
            // 
            // combxDeviceID
            // 
            this.combxDeviceID.FormattingEnabled = true;
            this.combxDeviceID.Location = new System.Drawing.Point(131, 119);
            this.combxDeviceID.Name = "combxDeviceID";
            this.combxDeviceID.Size = new System.Drawing.Size(60, 21);
            this.combxDeviceID.TabIndex = 93;
            // 
            // gpbRSCommunication
            // 
            this.gpbRSCommunication.Controls.Add(this.radioButton1);
            this.gpbRSCommunication.Controls.Add(this.radRS485);
            this.gpbRSCommunication.Location = new System.Drawing.Point(13, 15);
            this.gpbRSCommunication.Name = "gpbRSCommunication";
            this.gpbRSCommunication.Size = new System.Drawing.Size(95, 57);
            this.gpbRSCommunication.TabIndex = 94;
            this.gpbRSCommunication.TabStop = false;
            // 
            // chbAutoResponse
            // 
            this.chbAutoResponse.Location = new System.Drawing.Point(131, 50);
            this.chbAutoResponse.Name = "chbAutoResponse";
            this.chbAutoResponse.Size = new System.Drawing.Size(99, 26);
            this.chbAutoResponse.TabIndex = 95;
            this.chbAutoResponse.Text = "Auto Response";
            // 
            // lblMS
            // 
            this.lblMS.Location = new System.Drawing.Point(197, 160);
            this.lblMS.Name = "lblMS";
            this.lblMS.Size = new System.Drawing.Size(33, 17);
            this.lblMS.TabIndex = 96;
            this.lblMS.Text = "ms";
            // 
            // radRS485
            // 
            this.radRS485.AutoSize = true;
            this.radRS485.Location = new System.Drawing.Point(6, 9);
            this.radRS485.Name = "radRS485";
            this.radRS485.Size = new System.Drawing.Size(61, 17);
            this.radRS485.TabIndex = 0;
            this.radRS485.TabStop = true;
            this.radRS485.Text = "RS-485";
            this.radRS485.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 31);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(61, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "RS-232";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // gpbMiscSettings
            // 
            this.gpbMiscSettings.Controls.Add(this.txtHCA);
            this.gpbMiscSettings.Controls.Add(this.txtLCA);
            this.gpbMiscSettings.Controls.Add(this.txtDOBoot);
            this.gpbMiscSettings.Controls.Add(this.txtEOBoot);
            this.gpbMiscSettings.Controls.Add(this.lblHCA);
            this.gpbMiscSettings.Controls.Add(this.lblLCA);
            this.gpbMiscSettings.Controls.Add(this.lblDOBoot);
            this.gpbMiscSettings.Controls.Add(this.lblEOBoot);
            this.gpbMiscSettings.Controls.Add(this.chbxRZ);
            this.gpbMiscSettings.Controls.Add(this.chbxAlmLnp);
            this.gpbMiscSettings.Controls.Add(this.chbxAutoRun1);
            this.gpbMiscSettings.Controls.Add(this.chbxAutoRun0);
            this.gpbMiscSettings.Controls.Add(this.chbxIERR);
            this.gpbMiscSettings.Controls.Add(this.chbxEnableDecel);
            this.gpbMiscSettings.Location = new System.Drawing.Point(309, 202);
            this.gpbMiscSettings.Name = "gpbMiscSettings";
            this.gpbMiscSettings.Size = new System.Drawing.Size(250, 146);
            this.gpbMiscSettings.TabIndex = 94;
            this.gpbMiscSettings.TabStop = false;
            this.gpbMiscSettings.Text = "Misc Settings";
            // 
            // chbxEnableDecel
            // 
            this.chbxEnableDecel.Enabled = false;
            this.chbxEnableDecel.Location = new System.Drawing.Point(21, 25);
            this.chbxEnableDecel.Name = "chbxEnableDecel";
            this.chbxEnableDecel.Size = new System.Drawing.Size(95, 17);
            this.chbxEnableDecel.TabIndex = 87;
            this.chbxEnableDecel.Text = "Enable Decel";
            // 
            // chbxIERR
            // 
            this.chbxIERR.Enabled = false;
            this.chbxIERR.Location = new System.Drawing.Point(166, 25);
            this.chbxIERR.Name = "chbxIERR";
            this.chbxIERR.Size = new System.Drawing.Size(64, 17);
            this.chbxIERR.TabIndex = 88;
            this.chbxIERR.Text = "IERR";
            // 
            // chbxAutoRun0
            // 
            this.chbxAutoRun0.Enabled = false;
            this.chbxAutoRun0.Location = new System.Drawing.Point(21, 48);
            this.chbxAutoRun0.Name = "chbxAutoRun0";
            this.chbxAutoRun0.Size = new System.Drawing.Size(95, 17);
            this.chbxAutoRun0.TabIndex = 89;
            this.chbxAutoRun0.Text = "Auto Run 0";
            // 
            // chbxAutoRun1
            // 
            this.chbxAutoRun1.Enabled = false;
            this.chbxAutoRun1.Location = new System.Drawing.Point(21, 71);
            this.chbxAutoRun1.Name = "chbxAutoRun1";
            this.chbxAutoRun1.Size = new System.Drawing.Size(95, 17);
            this.chbxAutoRun1.TabIndex = 90;
            this.chbxAutoRun1.Text = "Auto Run 1";
            // 
            // chbxAlmLnp
            // 
            this.chbxAlmLnp.Enabled = false;
            this.chbxAlmLnp.Location = new System.Drawing.Point(166, 48);
            this.chbxAlmLnp.Name = "chbxAlmLnp";
            this.chbxAlmLnp.Size = new System.Drawing.Size(64, 17);
            this.chbxAlmLnp.TabIndex = 91;
            this.chbxAlmLnp.Text = "Alm/Inp";
            // 
            // chbxRZ
            // 
            this.chbxRZ.Enabled = false;
            this.chbxRZ.Location = new System.Drawing.Point(166, 71);
            this.chbxRZ.Name = "chbxRZ";
            this.chbxRZ.Size = new System.Drawing.Size(64, 17);
            this.chbxRZ.TabIndex = 92;
            this.chbxRZ.Text = "RZ";
            // 
            // lblEOBoot
            // 
            this.lblEOBoot.Location = new System.Drawing.Point(18, 95);
            this.lblEOBoot.Name = "lblEOBoot";
            this.lblEOBoot.Size = new System.Drawing.Size(52, 17);
            this.lblEOBoot.TabIndex = 97;
            this.lblEOBoot.Text = "EO Boot";
            // 
            // lblDOBoot
            // 
            this.lblDOBoot.Location = new System.Drawing.Point(18, 120);
            this.lblDOBoot.Name = "lblDOBoot";
            this.lblDOBoot.Size = new System.Drawing.Size(52, 17);
            this.lblDOBoot.TabIndex = 98;
            this.lblDOBoot.Text = "DO Boot";
            // 
            // lblLCA
            // 
            this.lblLCA.Location = new System.Drawing.Point(140, 95);
            this.lblLCA.Name = "lblLCA";
            this.lblLCA.Size = new System.Drawing.Size(35, 17);
            this.lblLCA.TabIndex = 99;
            this.lblLCA.Text = "LCA";
            // 
            // lblHCA
            // 
            this.lblHCA.Location = new System.Drawing.Point(140, 120);
            this.lblHCA.Name = "lblHCA";
            this.lblHCA.Size = new System.Drawing.Size(35, 17);
            this.lblHCA.TabIndex = 100;
            this.lblHCA.Text = "HCA";
            // 
            // txtEOBoot
            // 
            this.txtEOBoot.Enabled = false;
            this.txtEOBoot.Location = new System.Drawing.Point(76, 92);
            this.txtEOBoot.Name = "txtEOBoot";
            this.txtEOBoot.ReadOnly = true;
            this.txtEOBoot.Size = new System.Drawing.Size(25, 20);
            this.txtEOBoot.TabIndex = 97;
            this.txtEOBoot.Text = "0";
            // 
            // txtDOBoot
            // 
            this.txtDOBoot.Enabled = false;
            this.txtDOBoot.Location = new System.Drawing.Point(76, 117);
            this.txtDOBoot.Name = "txtDOBoot";
            this.txtDOBoot.ReadOnly = true;
            this.txtDOBoot.Size = new System.Drawing.Size(25, 20);
            this.txtDOBoot.TabIndex = 101;
            this.txtDOBoot.Text = "0";
            // 
            // txtLCA
            // 
            this.txtLCA.Location = new System.Drawing.Point(181, 92);
            this.txtLCA.Name = "txtLCA";
            this.txtLCA.ReadOnly = true;
            this.txtLCA.Size = new System.Drawing.Size(49, 20);
            this.txtLCA.TabIndex = 102;
            this.txtLCA.Text = "300";
            // 
            // txtHCA
            // 
            this.txtHCA.Enabled = false;
            this.txtHCA.Location = new System.Drawing.Point(181, 117);
            this.txtHCA.Name = "txtHCA";
            this.txtHCA.ReadOnly = true;
            this.txtHCA.Size = new System.Drawing.Size(49, 20);
            this.txtHCA.TabIndex = 103;
            this.txtHCA.Text = "300";
            // 
            // gpbStepNLoopControl
            // 
            this.gpbStepNLoopControl.Controls.Add(this.txtMaxAttempt);
            this.gpbStepNLoopControl.Controls.Add(this.txtErrorRange);
            this.gpbStepNLoopControl.Controls.Add(this.lblErrorRange);
            this.gpbStepNLoopControl.Controls.Add(this.txtIdleTol);
            this.gpbStepNLoopControl.Controls.Add(this.lblIdleTol);
            this.gpbStepNLoopControl.Controls.Add(this.txtTolerance);
            this.gpbStepNLoopControl.Controls.Add(this.lblTolerance);
            this.gpbStepNLoopControl.Controls.Add(this.lblMaxAttempt);
            this.gpbStepNLoopControl.Controls.Add(this.chbxStepNLoopControlEnable);
            this.gpbStepNLoopControl.Location = new System.Drawing.Point(6, 364);
            this.gpbStepNLoopControl.Name = "gpbStepNLoopControl";
            this.gpbStepNLoopControl.Size = new System.Drawing.Size(283, 189);
            this.gpbStepNLoopControl.TabIndex = 95;
            this.gpbStepNLoopControl.TabStop = false;
            this.gpbStepNLoopControl.Text = "Step N Loop Control";
            // 
            // txtErrorRange
            // 
            this.txtErrorRange.Location = new System.Drawing.Point(163, 156);
            this.txtErrorRange.Name = "txtErrorRange";
            this.txtErrorRange.ReadOnly = true;
            this.txtErrorRange.Size = new System.Drawing.Size(99, 20);
            this.txtErrorRange.TabIndex = 91;
            this.txtErrorRange.Text = "1";
            // 
            // lblErrorRange
            // 
            this.lblErrorRange.Location = new System.Drawing.Point(18, 159);
            this.lblErrorRange.Name = "lblErrorRange";
            this.lblErrorRange.Size = new System.Drawing.Size(71, 17);
            this.lblErrorRange.TabIndex = 90;
            this.lblErrorRange.Text = "Error Range";
            // 
            // txtIdleTol
            // 
            this.txtIdleTol.Location = new System.Drawing.Point(163, 123);
            this.txtIdleTol.Name = "txtIdleTol";
            this.txtIdleTol.ReadOnly = true;
            this.txtIdleTol.Size = new System.Drawing.Size(99, 20);
            this.txtIdleTol.TabIndex = 89;
            this.txtIdleTol.Text = "1";
            // 
            // lblIdleTol
            // 
            this.lblIdleTol.Location = new System.Drawing.Point(18, 126);
            this.lblIdleTol.Name = "lblIdleTol";
            this.lblIdleTol.Size = new System.Drawing.Size(71, 17);
            this.lblIdleTol.TabIndex = 88;
            this.lblIdleTol.Text = "Idle Tol";
            // 
            // txtTolerance
            // 
            this.txtTolerance.Location = new System.Drawing.Point(163, 90);
            this.txtTolerance.Name = "txtTolerance";
            this.txtTolerance.ReadOnly = true;
            this.txtTolerance.Size = new System.Drawing.Size(99, 20);
            this.txtTolerance.TabIndex = 59;
            this.txtTolerance.Text = "1";
            // 
            // lblTolerance
            // 
            this.lblTolerance.Location = new System.Drawing.Point(18, 93);
            this.lblTolerance.Name = "lblTolerance";
            this.lblTolerance.Size = new System.Drawing.Size(71, 17);
            this.lblTolerance.TabIndex = 59;
            this.lblTolerance.Text = "Tolerance";
            // 
            // lblMaxAttempt
            // 
            this.lblMaxAttempt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMaxAttempt.Location = new System.Drawing.Point(18, 59);
            this.lblMaxAttempt.Name = "lblMaxAttempt";
            this.lblMaxAttempt.Size = new System.Drawing.Size(71, 13);
            this.lblMaxAttempt.TabIndex = 76;
            this.lblMaxAttempt.Text = "Max Attempt";
            // 
            // chbxStepNLoopControlEnable
            // 
            this.chbxStepNLoopControlEnable.Location = new System.Drawing.Point(21, 19);
            this.chbxStepNLoopControlEnable.Name = "chbxStepNLoopControlEnable";
            this.chbxStepNLoopControlEnable.Size = new System.Drawing.Size(64, 26);
            this.chbxStepNLoopControlEnable.TabIndex = 87;
            this.chbxStepNLoopControlEnable.Text = "Enable";
            // 
            // txtMaxAttempt
            // 
            this.txtMaxAttempt.Location = new System.Drawing.Point(163, 56);
            this.txtMaxAttempt.Name = "txtMaxAttempt";
            this.txtMaxAttempt.ReadOnly = true;
            this.txtMaxAttempt.Size = new System.Drawing.Size(99, 20);
            this.txtMaxAttempt.TabIndex = 92;
            this.txtMaxAttempt.Text = "1";
            // 
            // gpbDriverCurrent
            // 
            this.gpbDriverCurrent.Controls.Add(this.lblTimeMS);
            this.gpbDriverCurrent.Controls.Add(this.lblIdleMA);
            this.gpbDriverCurrent.Controls.Add(this.lblRunMA);
            this.gpbDriverCurrent.Controls.Add(this.textBox1);
            this.gpbDriverCurrent.Controls.Add(this.txtTime);
            this.gpbDriverCurrent.Controls.Add(this.lblTime);
            this.gpbDriverCurrent.Controls.Add(this.txtRun);
            this.gpbDriverCurrent.Controls.Add(this.lblIdle);
            this.gpbDriverCurrent.Controls.Add(this.lblRun);
            this.gpbDriverCurrent.Location = new System.Drawing.Point(328, 364);
            this.gpbDriverCurrent.Name = "gpbDriverCurrent";
            this.gpbDriverCurrent.Size = new System.Drawing.Size(228, 189);
            this.gpbDriverCurrent.TabIndex = 96;
            this.gpbDriverCurrent.TabStop = false;
            this.gpbDriverCurrent.Text = "Driver Current";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(78, 133);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(65, 20);
            this.txtTime.TabIndex = 91;
            this.txtTime.Text = "0";
            // 
            // lblTime
            // 
            this.lblTime.Location = new System.Drawing.Point(39, 136);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(33, 17);
            this.lblTime.TabIndex = 90;
            this.lblTime.Text = "Time";
            // 
            // txtRun
            // 
            this.txtRun.Location = new System.Drawing.Point(78, 41);
            this.txtRun.Name = "txtRun";
            this.txtRun.ReadOnly = true;
            this.txtRun.Size = new System.Drawing.Size(65, 20);
            this.txtRun.TabIndex = 59;
            this.txtRun.Text = "0";
            // 
            // lblIdle
            // 
            this.lblIdle.Location = new System.Drawing.Point(39, 90);
            this.lblIdle.Name = "lblIdle";
            this.lblIdle.Size = new System.Drawing.Size(33, 17);
            this.lblIdle.TabIndex = 59;
            this.lblIdle.Text = "Idle";
            // 
            // lblRun
            // 
            this.lblRun.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRun.Location = new System.Drawing.Point(39, 44);
            this.lblRun.Name = "lblRun";
            this.lblRun.Size = new System.Drawing.Size(33, 13);
            this.lblRun.TabIndex = 76;
            this.lblRun.Text = "Run";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(78, 87);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(65, 20);
            this.textBox1.TabIndex = 92;
            this.textBox1.Text = "0";
            // 
            // lblRunMA
            // 
            this.lblRunMA.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRunMA.Location = new System.Drawing.Point(149, 44);
            this.lblRunMA.Name = "lblRunMA";
            this.lblRunMA.Size = new System.Drawing.Size(33, 13);
            this.lblRunMA.TabIndex = 93;
            this.lblRunMA.Text = "mA";
            // 
            // lblIdleMA
            // 
            this.lblIdleMA.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblIdleMA.Location = new System.Drawing.Point(149, 90);
            this.lblIdleMA.Name = "lblIdleMA";
            this.lblIdleMA.Size = new System.Drawing.Size(33, 13);
            this.lblIdleMA.TabIndex = 94;
            this.lblIdleMA.Text = "mA";
            // 
            // lblTimeMS
            // 
            this.lblTimeMS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTimeMS.Location = new System.Drawing.Point(149, 136);
            this.lblTimeMS.Name = "lblTimeMS";
            this.lblTimeMS.Size = new System.Drawing.Size(33, 13);
            this.lblTimeMS.TabIndex = 95;
            this.lblTimeMS.Text = "mA";
            // 
            // cmdOpen
            // 
            this.cmdOpen.Location = new System.Drawing.Point(6, 577);
            this.cmdOpen.Name = "cmdOpen";
            this.cmdOpen.Size = new System.Drawing.Size(70, 65);
            this.cmdOpen.TabIndex = 104;
            this.cmdOpen.Text = "Open";
            this.cmdOpen.UseVisualStyleBackColor = true;
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(92, 577);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(70, 65);
            this.cmdSave.TabIndex = 105;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            // 
            // cmdUpload
            // 
            this.cmdUpload.Location = new System.Drawing.Point(178, 577);
            this.cmdUpload.Name = "cmdUpload";
            this.cmdUpload.Size = new System.Drawing.Size(70, 65);
            this.cmdUpload.TabIndex = 106;
            this.cmdUpload.Text = "Upload";
            this.cmdUpload.UseVisualStyleBackColor = true;
            // 
            // cmdDown
            // 
            this.cmdDown.Location = new System.Drawing.Point(265, 577);
            this.cmdDown.Name = "cmdDown";
            this.cmdDown.Size = new System.Drawing.Size(70, 65);
            this.cmdDown.TabIndex = 107;
            this.cmdDown.Text = "Down";
            this.cmdDown.UseVisualStyleBackColor = true;
            // 
            // cmdStore
            // 
            this.cmdStore.Location = new System.Drawing.Point(353, 577);
            this.cmdStore.Name = "cmdStore";
            this.cmdStore.Size = new System.Drawing.Size(70, 65);
            this.cmdStore.TabIndex = 108;
            this.cmdStore.Text = "Store";
            this.cmdStore.UseVisualStyleBackColor = true;
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(463, 577);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(93, 65);
            this.cmdClose.TabIndex = 109;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // MagSetupPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 661);
            this.Controls.Add(this.gpbSetupPara);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MagSetupPage";
            this.Text = "MagSetupPage";
            this.gpbSetupPara.ResumeLayout(false);
            this.gpbCommunicatinSetup.ResumeLayout(false);
            this.gpbCommunicatinSetup.PerformLayout();
            this.gpbRSCommunication.ResumeLayout(false);
            this.gpbRSCommunication.PerformLayout();
            this.gpbMiscSettings.ResumeLayout(false);
            this.gpbMiscSettings.PerformLayout();
            this.gpbStepNLoopControl.ResumeLayout(false);
            this.gpbStepNLoopControl.PerformLayout();
            this.gpbDriverCurrent.ResumeLayout(false);
            this.gpbDriverCurrent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox gpbPolarity;
        internal System.Windows.Forms.GroupBox gpbSetupPara;
        internal System.Windows.Forms.GroupBox gpbCommunicatinSetup;
        private System.Windows.Forms.ComboBox combxBaudRate;
        private System.Windows.Forms.TextBox txtTimeOutCounter;
        private System.Windows.Forms.Label lblTimeOutCounter;
        private System.Windows.Forms.Label lblDeviceID;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.CheckBox chbxSyncOutputEnableDO2;
        private System.Windows.Forms.ComboBox combxDeviceID;
        private System.Windows.Forms.GroupBox gpbRSCommunication;
        private System.Windows.Forms.CheckBox chbAutoResponse;
        private System.Windows.Forms.Label lblMS;
        private System.Windows.Forms.RadioButton radRS485;
        private System.Windows.Forms.RadioButton radioButton1;
        internal System.Windows.Forms.GroupBox gpbMiscSettings;
        private System.Windows.Forms.CheckBox chbxEnableDecel;
        private System.Windows.Forms.CheckBox chbxIERR;
        private System.Windows.Forms.CheckBox chbxAutoRun0;
        private System.Windows.Forms.CheckBox chbxAutoRun1;
        private System.Windows.Forms.CheckBox chbxAlmLnp;
        private System.Windows.Forms.CheckBox chbxRZ;
        private System.Windows.Forms.Label lblEOBoot;
        private System.Windows.Forms.Label lblDOBoot;
        private System.Windows.Forms.Label lblLCA;
        private System.Windows.Forms.Label lblHCA;
        private System.Windows.Forms.TextBox txtEOBoot;
        private System.Windows.Forms.TextBox txtDOBoot;
        private System.Windows.Forms.TextBox txtHCA;
        private System.Windows.Forms.TextBox txtLCA;
        internal System.Windows.Forms.GroupBox gpbStepNLoopControl;
        private System.Windows.Forms.TextBox txtErrorRange;
        private System.Windows.Forms.Label lblErrorRange;
        private System.Windows.Forms.TextBox txtIdleTol;
        private System.Windows.Forms.Label lblIdleTol;
        private System.Windows.Forms.TextBox txtTolerance;
        private System.Windows.Forms.Label lblTolerance;
        private System.Windows.Forms.Label lblMaxAttempt;
        private System.Windows.Forms.CheckBox chbxStepNLoopControlEnable;
        private System.Windows.Forms.TextBox txtMaxAttempt;
        internal System.Windows.Forms.GroupBox gpbDriverCurrent;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TextBox txtRun;
        private System.Windows.Forms.Label lblIdle;
        private System.Windows.Forms.Label lblRun;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblRunMA;
        private System.Windows.Forms.Label lblIdleMA;
        private System.Windows.Forms.Label lblTimeMS;
        internal System.Windows.Forms.Button cmdOpen;
        internal System.Windows.Forms.Button cmdSave;
        internal System.Windows.Forms.Button cmdUpload;
        internal System.Windows.Forms.Button cmdDown;
        internal System.Windows.Forms.Button cmdStore;
        internal System.Windows.Forms.Button cmdClose;
    }
}