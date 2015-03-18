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
            this.gpbPolarityEnable = new System.Windows.Forms.GroupBox();
            this.radEnableLow = new System.Windows.Forms.RadioButton();
            this.radEnableHigh = new System.Windows.Forms.RadioButton();
            this.gpbSAErr = new System.Windows.Forms.GroupBox();
            this.radSAErrLow = new System.Windows.Forms.RadioButton();
            this.radSAErrHigh = new System.Windows.Forms.RadioButton();
            this.gpbInput = new System.Windows.Forms.GroupBox();
            this.radDigitalInputLow = new System.Windows.Forms.RadioButton();
            this.radDigitalInputHigh = new System.Windows.Forms.RadioButton();
            this.gpbOutput = new System.Windows.Forms.GroupBox();
            this.radDigitalOutputLow = new System.Windows.Forms.RadioButton();
            this.radDigitalOutputHigh = new System.Windows.Forms.RadioButton();
            this.gpbAlarm = new System.Windows.Forms.GroupBox();
            this.radAlarmLow = new System.Windows.Forms.RadioButton();
            this.radAlarmHigh = new System.Windows.Forms.RadioButton();
            this.gpbInPos = new System.Windows.Forms.GroupBox();
            this.radInPosLow = new System.Windows.Forms.RadioButton();
            this.radInPosHigh = new System.Windows.Forms.RadioButton();
            this.gpbLatch = new System.Windows.Forms.GroupBox();
            this.radLatchLow = new System.Windows.Forms.RadioButton();
            this.radLatchHigh = new System.Windows.Forms.RadioButton();
            this.gpbLimit = new System.Windows.Forms.GroupBox();
            this.radLimitLow = new System.Windows.Forms.RadioButton();
            this.radLimitHigh = new System.Windows.Forms.RadioButton();
            this.gpbHome = new System.Windows.Forms.GroupBox();
            this.radHomeLow = new System.Windows.Forms.RadioButton();
            this.radHomeHigh = new System.Windows.Forms.RadioButton();
            this.gpbDir = new System.Windows.Forms.GroupBox();
            this.radDirCW = new System.Windows.Forms.RadioButton();
            this.radDirCCW = new System.Windows.Forms.RadioButton();
            this.lblEnable = new System.Windows.Forms.Label();
            this.lblSAErr = new System.Windows.Forms.Label();
            this.lblInput = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.lblAlarm = new System.Windows.Forms.Label();
            this.lblInPos = new System.Windows.Forms.Label();
            this.lblLatch = new System.Windows.Forms.Label();
            this.lblLimit = new System.Windows.Forms.Label();
            this.lblHome = new System.Windows.Forms.Label();
            this.cmdDir = new System.Windows.Forms.Label();
            this.gpbSetupPara = new System.Windows.Forms.GroupBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdStore = new System.Windows.Forms.Button();
            this.cmdDown = new System.Windows.Forms.Button();
            this.cmdUpload = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdOpen = new System.Windows.Forms.Button();
            this.gpbDriverCurrent = new System.Windows.Forms.GroupBox();
            this.lblTimeMS = new System.Windows.Forms.Label();
            this.lblIdleMA = new System.Windows.Forms.Label();
            this.lblRunMA = new System.Windows.Forms.Label();
            this.txtCurrentIdle = new System.Windows.Forms.TextBox();
            this.txtCurrentIdleTimeSetting = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.txtCurrentRun = new System.Windows.Forms.TextBox();
            this.lblIdle = new System.Windows.Forms.Label();
            this.lblRun = new System.Windows.Forms.Label();
            this.gpbStepNLoopControl = new System.Windows.Forms.GroupBox();
            this.txtMaxAttempt = new System.Windows.Forms.TextBox();
            this.txtErrorRange = new System.Windows.Forms.TextBox();
            this.lblErrorRange = new System.Windows.Forms.Label();
            this.txtIdleTol = new System.Windows.Forms.TextBox();
            this.lblIdleTol = new System.Windows.Forms.Label();
            this.txtTolerance = new System.Windows.Forms.TextBox();
            this.lblTolerance = new System.Windows.Forms.Label();
            this.lblMaxAttempt = new System.Windows.Forms.Label();
            this.chbxStepNLoopControlEnable = new System.Windows.Forms.CheckBox();
            this.gpbMiscSettings = new System.Windows.Forms.GroupBox();
            this.txtHCA = new System.Windows.Forms.TextBox();
            this.txtLCA = new System.Windows.Forms.TextBox();
            this.txtDOBoot = new System.Windows.Forms.TextBox();
            this.txtEOBoot = new System.Windows.Forms.TextBox();
            this.lblHCA = new System.Windows.Forms.Label();
            this.lblLCA = new System.Windows.Forms.Label();
            this.lblDOBoot = new System.Windows.Forms.Label();
            this.lblEOBoot = new System.Windows.Forms.Label();
            this.chbxRZ = new System.Windows.Forms.CheckBox();
            this.chbxAlmInp = new System.Windows.Forms.CheckBox();
            this.chbxAutoRun1 = new System.Windows.Forms.CheckBox();
            this.chbxAutoRun0 = new System.Windows.Forms.CheckBox();
            this.chbxIERR = new System.Windows.Forms.CheckBox();
            this.chbxEnableDecel = new System.Windows.Forms.CheckBox();
            this.gpbCommunicatinSetup = new System.Windows.Forms.GroupBox();
            this.lblMS = new System.Windows.Forms.Label();
            this.chbxAutoResponse = new System.Windows.Forms.CheckBox();
            this.gpbRSCommunication = new System.Windows.Forms.GroupBox();
            this.radRS232 = new System.Windows.Forms.RadioButton();
            this.radRS485 = new System.Windows.Forms.RadioButton();
            this.combxDeviceID = new System.Windows.Forms.ComboBox();
            this.combxBaudRate = new System.Windows.Forms.ComboBox();
            this.txtTimeOutCounter = new System.Windows.Forms.TextBox();
            this.lblTimeOutCounter = new System.Windows.Forms.Label();
            this.lblDeviceID = new System.Windows.Forms.Label();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.chbxAppendID = new System.Windows.Forms.CheckBox();
            this.gpbPolarity.SuspendLayout();
            this.gpbPolarityEnable.SuspendLayout();
            this.gpbSAErr.SuspendLayout();
            this.gpbInput.SuspendLayout();
            this.gpbOutput.SuspendLayout();
            this.gpbAlarm.SuspendLayout();
            this.gpbInPos.SuspendLayout();
            this.gpbLatch.SuspendLayout();
            this.gpbLimit.SuspendLayout();
            this.gpbHome.SuspendLayout();
            this.gpbDir.SuspendLayout();
            this.gpbSetupPara.SuspendLayout();
            this.gpbDriverCurrent.SuspendLayout();
            this.gpbStepNLoopControl.SuspendLayout();
            this.gpbMiscSettings.SuspendLayout();
            this.gpbCommunicatinSetup.SuspendLayout();
            this.gpbRSCommunication.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbPolarity
            // 
            this.gpbPolarity.Controls.Add(this.gpbPolarityEnable);
            this.gpbPolarity.Controls.Add(this.gpbSAErr);
            this.gpbPolarity.Controls.Add(this.gpbInput);
            this.gpbPolarity.Controls.Add(this.gpbOutput);
            this.gpbPolarity.Controls.Add(this.gpbAlarm);
            this.gpbPolarity.Controls.Add(this.gpbInPos);
            this.gpbPolarity.Controls.Add(this.gpbLatch);
            this.gpbPolarity.Controls.Add(this.gpbLimit);
            this.gpbPolarity.Controls.Add(this.gpbHome);
            this.gpbPolarity.Controls.Add(this.gpbDir);
            this.gpbPolarity.Controls.Add(this.lblEnable);
            this.gpbPolarity.Controls.Add(this.lblSAErr);
            this.gpbPolarity.Controls.Add(this.lblInput);
            this.gpbPolarity.Controls.Add(this.lblOutput);
            this.gpbPolarity.Controls.Add(this.lblAlarm);
            this.gpbPolarity.Controls.Add(this.lblInPos);
            this.gpbPolarity.Controls.Add(this.lblLatch);
            this.gpbPolarity.Controls.Add(this.lblLimit);
            this.gpbPolarity.Controls.Add(this.lblHome);
            this.gpbPolarity.Controls.Add(this.cmdDir);
            this.gpbPolarity.Location = new System.Drawing.Point(6, 10);
            this.gpbPolarity.Name = "gpbPolarity";
            this.gpbPolarity.Size = new System.Drawing.Size(283, 338);
            this.gpbPolarity.TabIndex = 77;
            this.gpbPolarity.TabStop = false;
            this.gpbPolarity.Text = "Polarity";
            // 
            // gpbPolarityEnable
            // 
            this.gpbPolarityEnable.Controls.Add(this.radEnableLow);
            this.gpbPolarityEnable.Controls.Add(this.radEnableHigh);
            this.gpbPolarityEnable.Enabled = false;
            this.gpbPolarityEnable.Location = new System.Drawing.Point(106, 294);
            this.gpbPolarityEnable.Name = "gpbPolarityEnable";
            this.gpbPolarityEnable.Size = new System.Drawing.Size(156, 30);
            this.gpbPolarityEnable.TabIndex = 104;
            this.gpbPolarityEnable.TabStop = false;
            // 
            // radEnableLow
            // 
            this.radEnableLow.AutoSize = true;
            this.radEnableLow.Checked = true;
            this.radEnableLow.Location = new System.Drawing.Point(89, 9);
            this.radEnableLow.Name = "radEnableLow";
            this.radEnableLow.Size = new System.Drawing.Size(45, 17);
            this.radEnableLow.TabIndex = 1;
            this.radEnableLow.TabStop = true;
            this.radEnableLow.Text = "Low";
            this.radEnableLow.UseVisualStyleBackColor = true;
            // 
            // radEnableHigh
            // 
            this.radEnableHigh.AutoSize = true;
            this.radEnableHigh.Location = new System.Drawing.Point(6, 9);
            this.radEnableHigh.Name = "radEnableHigh";
            this.radEnableHigh.Size = new System.Drawing.Size(47, 17);
            this.radEnableHigh.TabIndex = 0;
            this.radEnableHigh.TabStop = true;
            this.radEnableHigh.Text = "High";
            this.radEnableHigh.UseVisualStyleBackColor = true;
            // 
            // gpbSAErr
            // 
            this.gpbSAErr.Controls.Add(this.radSAErrLow);
            this.gpbSAErr.Controls.Add(this.radSAErrHigh);
            this.gpbSAErr.Enabled = false;
            this.gpbSAErr.Location = new System.Drawing.Point(106, 263);
            this.gpbSAErr.Name = "gpbSAErr";
            this.gpbSAErr.Size = new System.Drawing.Size(156, 30);
            this.gpbSAErr.TabIndex = 103;
            this.gpbSAErr.TabStop = false;
            // 
            // radSAErrLow
            // 
            this.radSAErrLow.AutoSize = true;
            this.radSAErrLow.Checked = true;
            this.radSAErrLow.Location = new System.Drawing.Point(89, 9);
            this.radSAErrLow.Name = "radSAErrLow";
            this.radSAErrLow.Size = new System.Drawing.Size(45, 17);
            this.radSAErrLow.TabIndex = 1;
            this.radSAErrLow.TabStop = true;
            this.radSAErrLow.Text = "Low";
            this.radSAErrLow.UseVisualStyleBackColor = true;
            // 
            // radSAErrHigh
            // 
            this.radSAErrHigh.AutoSize = true;
            this.radSAErrHigh.Location = new System.Drawing.Point(6, 9);
            this.radSAErrHigh.Name = "radSAErrHigh";
            this.radSAErrHigh.Size = new System.Drawing.Size(47, 17);
            this.radSAErrHigh.TabIndex = 0;
            this.radSAErrHigh.TabStop = true;
            this.radSAErrHigh.Text = "High";
            this.radSAErrHigh.UseVisualStyleBackColor = true;
            // 
            // gpbInput
            // 
            this.gpbInput.Controls.Add(this.radDigitalInputLow);
            this.gpbInput.Controls.Add(this.radDigitalInputHigh);
            this.gpbInput.Enabled = false;
            this.gpbInput.Location = new System.Drawing.Point(106, 233);
            this.gpbInput.Name = "gpbInput";
            this.gpbInput.Size = new System.Drawing.Size(156, 30);
            this.gpbInput.TabIndex = 102;
            this.gpbInput.TabStop = false;
            // 
            // radDigitalInputLow
            // 
            this.radDigitalInputLow.AutoSize = true;
            this.radDigitalInputLow.Checked = true;
            this.radDigitalInputLow.Location = new System.Drawing.Point(89, 9);
            this.radDigitalInputLow.Name = "radDigitalInputLow";
            this.radDigitalInputLow.Size = new System.Drawing.Size(45, 17);
            this.radDigitalInputLow.TabIndex = 1;
            this.radDigitalInputLow.TabStop = true;
            this.radDigitalInputLow.Text = "Low";
            this.radDigitalInputLow.UseVisualStyleBackColor = true;
            // 
            // radDigitalInputHigh
            // 
            this.radDigitalInputHigh.AutoSize = true;
            this.radDigitalInputHigh.Location = new System.Drawing.Point(6, 9);
            this.radDigitalInputHigh.Name = "radDigitalInputHigh";
            this.radDigitalInputHigh.Size = new System.Drawing.Size(47, 17);
            this.radDigitalInputHigh.TabIndex = 0;
            this.radDigitalInputHigh.TabStop = true;
            this.radDigitalInputHigh.Text = "High";
            this.radDigitalInputHigh.UseVisualStyleBackColor = true;
            // 
            // gpbOutput
            // 
            this.gpbOutput.Controls.Add(this.radDigitalOutputLow);
            this.gpbOutput.Controls.Add(this.radDigitalOutputHigh);
            this.gpbOutput.Enabled = false;
            this.gpbOutput.Location = new System.Drawing.Point(106, 202);
            this.gpbOutput.Name = "gpbOutput";
            this.gpbOutput.Size = new System.Drawing.Size(156, 30);
            this.gpbOutput.TabIndex = 101;
            this.gpbOutput.TabStop = false;
            // 
            // radDigitalOutputLow
            // 
            this.radDigitalOutputLow.AutoSize = true;
            this.radDigitalOutputLow.Checked = true;
            this.radDigitalOutputLow.Location = new System.Drawing.Point(89, 9);
            this.radDigitalOutputLow.Name = "radDigitalOutputLow";
            this.radDigitalOutputLow.Size = new System.Drawing.Size(45, 17);
            this.radDigitalOutputLow.TabIndex = 1;
            this.radDigitalOutputLow.TabStop = true;
            this.radDigitalOutputLow.Text = "Low";
            this.radDigitalOutputLow.UseVisualStyleBackColor = true;
            // 
            // radDigitalOutputHigh
            // 
            this.radDigitalOutputHigh.AutoSize = true;
            this.radDigitalOutputHigh.Location = new System.Drawing.Point(6, 9);
            this.radDigitalOutputHigh.Name = "radDigitalOutputHigh";
            this.radDigitalOutputHigh.Size = new System.Drawing.Size(47, 17);
            this.radDigitalOutputHigh.TabIndex = 0;
            this.radDigitalOutputHigh.TabStop = true;
            this.radDigitalOutputHigh.Text = "High";
            this.radDigitalOutputHigh.UseVisualStyleBackColor = true;
            // 
            // gpbAlarm
            // 
            this.gpbAlarm.Controls.Add(this.radAlarmLow);
            this.gpbAlarm.Controls.Add(this.radAlarmHigh);
            this.gpbAlarm.Location = new System.Drawing.Point(106, 171);
            this.gpbAlarm.Name = "gpbAlarm";
            this.gpbAlarm.Size = new System.Drawing.Size(156, 30);
            this.gpbAlarm.TabIndex = 100;
            this.gpbAlarm.TabStop = false;
            // 
            // radAlarmLow
            // 
            this.radAlarmLow.AutoSize = true;
            this.radAlarmLow.Checked = true;
            this.radAlarmLow.Location = new System.Drawing.Point(89, 9);
            this.radAlarmLow.Name = "radAlarmLow";
            this.radAlarmLow.Size = new System.Drawing.Size(45, 17);
            this.radAlarmLow.TabIndex = 1;
            this.radAlarmLow.TabStop = true;
            this.radAlarmLow.Text = "Low";
            this.radAlarmLow.UseVisualStyleBackColor = true;
            // 
            // radAlarmHigh
            // 
            this.radAlarmHigh.AutoSize = true;
            this.radAlarmHigh.Location = new System.Drawing.Point(6, 9);
            this.radAlarmHigh.Name = "radAlarmHigh";
            this.radAlarmHigh.Size = new System.Drawing.Size(47, 17);
            this.radAlarmHigh.TabIndex = 0;
            this.radAlarmHigh.TabStop = true;
            this.radAlarmHigh.Text = "High";
            this.radAlarmHigh.UseVisualStyleBackColor = true;
            // 
            // gpbInPos
            // 
            this.gpbInPos.Controls.Add(this.radInPosLow);
            this.gpbInPos.Controls.Add(this.radInPosHigh);
            this.gpbInPos.Location = new System.Drawing.Point(106, 140);
            this.gpbInPos.Name = "gpbInPos";
            this.gpbInPos.Size = new System.Drawing.Size(156, 30);
            this.gpbInPos.TabIndex = 99;
            this.gpbInPos.TabStop = false;
            // 
            // radInPosLow
            // 
            this.radInPosLow.AutoSize = true;
            this.radInPosLow.Checked = true;
            this.radInPosLow.Location = new System.Drawing.Point(89, 9);
            this.radInPosLow.Name = "radInPosLow";
            this.radInPosLow.Size = new System.Drawing.Size(45, 17);
            this.radInPosLow.TabIndex = 1;
            this.radInPosLow.TabStop = true;
            this.radInPosLow.Text = "Low";
            this.radInPosLow.UseVisualStyleBackColor = true;
            // 
            // radInPosHigh
            // 
            this.radInPosHigh.AutoSize = true;
            this.radInPosHigh.Location = new System.Drawing.Point(6, 9);
            this.radInPosHigh.Name = "radInPosHigh";
            this.radInPosHigh.Size = new System.Drawing.Size(47, 17);
            this.radInPosHigh.TabIndex = 0;
            this.radInPosHigh.TabStop = true;
            this.radInPosHigh.Text = "High";
            this.radInPosHigh.UseVisualStyleBackColor = true;
            // 
            // gpbLatch
            // 
            this.gpbLatch.Controls.Add(this.radLatchLow);
            this.gpbLatch.Controls.Add(this.radLatchHigh);
            this.gpbLatch.Location = new System.Drawing.Point(106, 108);
            this.gpbLatch.Name = "gpbLatch";
            this.gpbLatch.Size = new System.Drawing.Size(156, 30);
            this.gpbLatch.TabIndex = 98;
            this.gpbLatch.TabStop = false;
            // 
            // radLatchLow
            // 
            this.radLatchLow.AutoSize = true;
            this.radLatchLow.Checked = true;
            this.radLatchLow.Location = new System.Drawing.Point(89, 9);
            this.radLatchLow.Name = "radLatchLow";
            this.radLatchLow.Size = new System.Drawing.Size(45, 17);
            this.radLatchLow.TabIndex = 1;
            this.radLatchLow.TabStop = true;
            this.radLatchLow.Text = "Low";
            this.radLatchLow.UseVisualStyleBackColor = true;
            // 
            // radLatchHigh
            // 
            this.radLatchHigh.AutoSize = true;
            this.radLatchHigh.Location = new System.Drawing.Point(6, 9);
            this.radLatchHigh.Name = "radLatchHigh";
            this.radLatchHigh.Size = new System.Drawing.Size(47, 17);
            this.radLatchHigh.TabIndex = 0;
            this.radLatchHigh.TabStop = true;
            this.radLatchHigh.Text = "High";
            this.radLatchHigh.UseVisualStyleBackColor = true;
            // 
            // gpbLimit
            // 
            this.gpbLimit.Controls.Add(this.radLimitLow);
            this.gpbLimit.Controls.Add(this.radLimitHigh);
            this.gpbLimit.Location = new System.Drawing.Point(106, 77);
            this.gpbLimit.Name = "gpbLimit";
            this.gpbLimit.Size = new System.Drawing.Size(156, 30);
            this.gpbLimit.TabIndex = 97;
            this.gpbLimit.TabStop = false;
            // 
            // radLimitLow
            // 
            this.radLimitLow.AutoSize = true;
            this.radLimitLow.Checked = true;
            this.radLimitLow.Location = new System.Drawing.Point(89, 9);
            this.radLimitLow.Name = "radLimitLow";
            this.radLimitLow.Size = new System.Drawing.Size(45, 17);
            this.radLimitLow.TabIndex = 1;
            this.radLimitLow.TabStop = true;
            this.radLimitLow.Text = "Low";
            this.radLimitLow.UseVisualStyleBackColor = true;
            // 
            // radLimitHigh
            // 
            this.radLimitHigh.AutoSize = true;
            this.radLimitHigh.Location = new System.Drawing.Point(6, 9);
            this.radLimitHigh.Name = "radLimitHigh";
            this.radLimitHigh.Size = new System.Drawing.Size(47, 17);
            this.radLimitHigh.TabIndex = 0;
            this.radLimitHigh.TabStop = true;
            this.radLimitHigh.Text = "High";
            this.radLimitHigh.UseVisualStyleBackColor = true;
            // 
            // gpbHome
            // 
            this.gpbHome.Controls.Add(this.radHomeLow);
            this.gpbHome.Controls.Add(this.radHomeHigh);
            this.gpbHome.Location = new System.Drawing.Point(106, 46);
            this.gpbHome.Name = "gpbHome";
            this.gpbHome.Size = new System.Drawing.Size(156, 30);
            this.gpbHome.TabIndex = 96;
            this.gpbHome.TabStop = false;
            // 
            // radHomeLow
            // 
            this.radHomeLow.AutoSize = true;
            this.radHomeLow.Checked = true;
            this.radHomeLow.Location = new System.Drawing.Point(89, 9);
            this.radHomeLow.Name = "radHomeLow";
            this.radHomeLow.Size = new System.Drawing.Size(45, 17);
            this.radHomeLow.TabIndex = 1;
            this.radHomeLow.TabStop = true;
            this.radHomeLow.Text = "Low";
            this.radHomeLow.UseVisualStyleBackColor = true;
            // 
            // radHomeHigh
            // 
            this.radHomeHigh.AutoSize = true;
            this.radHomeHigh.Location = new System.Drawing.Point(6, 9);
            this.radHomeHigh.Name = "radHomeHigh";
            this.radHomeHigh.Size = new System.Drawing.Size(47, 17);
            this.radHomeHigh.TabIndex = 0;
            this.radHomeHigh.TabStop = true;
            this.radHomeHigh.Text = "High";
            this.radHomeHigh.UseVisualStyleBackColor = true;
            // 
            // gpbDir
            // 
            this.gpbDir.Controls.Add(this.radDirCW);
            this.gpbDir.Controls.Add(this.radDirCCW);
            this.gpbDir.Location = new System.Drawing.Point(106, 15);
            this.gpbDir.Name = "gpbDir";
            this.gpbDir.Size = new System.Drawing.Size(156, 30);
            this.gpbDir.TabIndex = 95;
            this.gpbDir.TabStop = false;
            // 
            // radDirCW
            // 
            this.radDirCW.AutoSize = true;
            this.radDirCW.Checked = true;
            this.radDirCW.Location = new System.Drawing.Point(89, 9);
            this.radDirCW.Name = "radDirCW";
            this.radDirCW.Size = new System.Drawing.Size(43, 17);
            this.radDirCW.TabIndex = 1;
            this.radDirCW.TabStop = true;
            this.radDirCW.Text = "CW";
            this.radDirCW.UseVisualStyleBackColor = true;
            // 
            // radDirCCW
            // 
            this.radDirCCW.AutoSize = true;
            this.radDirCCW.Location = new System.Drawing.Point(6, 9);
            this.radDirCCW.Name = "radDirCCW";
            this.radDirCCW.Size = new System.Drawing.Size(50, 17);
            this.radDirCCW.TabIndex = 0;
            this.radDirCCW.Text = "CCW";
            this.radDirCCW.UseVisualStyleBackColor = true;
            // 
            // lblEnable
            // 
            this.lblEnable.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEnable.Location = new System.Drawing.Point(18, 305);
            this.lblEnable.Name = "lblEnable";
            this.lblEnable.Size = new System.Drawing.Size(42, 13);
            this.lblEnable.TabIndex = 86;
            this.lblEnable.Text = "Enable";
            // 
            // lblSAErr
            // 
            this.lblSAErr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSAErr.Location = new System.Drawing.Point(18, 274);
            this.lblSAErr.Name = "lblSAErr";
            this.lblSAErr.Size = new System.Drawing.Size(42, 13);
            this.lblSAErr.TabIndex = 85;
            this.lblSAErr.Text = "SA-Err";
            // 
            // lblInput
            // 
            this.lblInput.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblInput.Location = new System.Drawing.Point(18, 244);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(42, 13);
            this.lblInput.TabIndex = 84;
            this.lblInput.Text = "Input";
            // 
            // lblOutput
            // 
            this.lblOutput.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOutput.Location = new System.Drawing.Point(18, 213);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(42, 13);
            this.lblOutput.TabIndex = 83;
            this.lblOutput.Text = "Output";
            // 
            // lblAlarm
            // 
            this.lblAlarm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAlarm.Location = new System.Drawing.Point(18, 182);
            this.lblAlarm.Name = "lblAlarm";
            this.lblAlarm.Size = new System.Drawing.Size(42, 13);
            this.lblAlarm.TabIndex = 82;
            this.lblAlarm.Text = "Alarm";
            // 
            // lblInPos
            // 
            this.lblInPos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblInPos.Location = new System.Drawing.Point(18, 152);
            this.lblInPos.Name = "lblInPos";
            this.lblInPos.Size = new System.Drawing.Size(42, 13);
            this.lblInPos.TabIndex = 81;
            this.lblInPos.Text = "In Pos";
            // 
            // lblLatch
            // 
            this.lblLatch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLatch.Location = new System.Drawing.Point(18, 119);
            this.lblLatch.Name = "lblLatch";
            this.lblLatch.Size = new System.Drawing.Size(42, 13);
            this.lblLatch.TabIndex = 80;
            this.lblLatch.Text = "Latch";
            // 
            // lblLimit
            // 
            this.lblLimit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLimit.Location = new System.Drawing.Point(18, 88);
            this.lblLimit.Name = "lblLimit";
            this.lblLimit.Size = new System.Drawing.Size(42, 13);
            this.lblLimit.TabIndex = 79;
            this.lblLimit.Text = "Limit";
            // 
            // lblHome
            // 
            this.lblHome.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblHome.Location = new System.Drawing.Point(18, 57);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(42, 13);
            this.lblHome.TabIndex = 78;
            this.lblHome.Text = "Home";
            // 
            // cmdDir
            // 
            this.cmdDir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdDir.Location = new System.Drawing.Point(18, 26);
            this.cmdDir.Name = "cmdDir";
            this.cmdDir.Size = new System.Drawing.Size(33, 13);
            this.cmdDir.TabIndex = 77;
            this.cmdDir.Text = "Dir";
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
            // cmdStore
            // 
            this.cmdStore.Location = new System.Drawing.Point(353, 577);
            this.cmdStore.Name = "cmdStore";
            this.cmdStore.Size = new System.Drawing.Size(70, 65);
            this.cmdStore.TabIndex = 108;
            this.cmdStore.Text = "Store";
            this.cmdStore.UseVisualStyleBackColor = true;
            this.cmdStore.Click += new System.EventHandler(this.cmdStore_Click);
            // 
            // cmdDown
            // 
            this.cmdDown.Location = new System.Drawing.Point(265, 577);
            this.cmdDown.Name = "cmdDown";
            this.cmdDown.Size = new System.Drawing.Size(70, 65);
            this.cmdDown.TabIndex = 107;
            this.cmdDown.Text = "Down";
            this.cmdDown.UseVisualStyleBackColor = true;
            this.cmdDown.Click += new System.EventHandler(this.cmdDown_Click);
            // 
            // cmdUpload
            // 
            this.cmdUpload.Location = new System.Drawing.Point(178, 577);
            this.cmdUpload.Name = "cmdUpload";
            this.cmdUpload.Size = new System.Drawing.Size(70, 65);
            this.cmdUpload.TabIndex = 106;
            this.cmdUpload.Text = "Upload";
            this.cmdUpload.UseVisualStyleBackColor = true;
            this.cmdUpload.Click += new System.EventHandler(this.cmdUpload_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(92, 577);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(70, 65);
            this.cmdSave.TabIndex = 105;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdOpen
            // 
            this.cmdOpen.Location = new System.Drawing.Point(6, 577);
            this.cmdOpen.Name = "cmdOpen";
            this.cmdOpen.Size = new System.Drawing.Size(70, 65);
            this.cmdOpen.TabIndex = 104;
            this.cmdOpen.Text = "Open";
            this.cmdOpen.UseVisualStyleBackColor = true;
            this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
            // 
            // gpbDriverCurrent
            // 
            this.gpbDriverCurrent.Controls.Add(this.lblTimeMS);
            this.gpbDriverCurrent.Controls.Add(this.lblIdleMA);
            this.gpbDriverCurrent.Controls.Add(this.lblRunMA);
            this.gpbDriverCurrent.Controls.Add(this.txtCurrentIdle);
            this.gpbDriverCurrent.Controls.Add(this.txtCurrentIdleTimeSetting);
            this.gpbDriverCurrent.Controls.Add(this.lblTime);
            this.gpbDriverCurrent.Controls.Add(this.txtCurrentRun);
            this.gpbDriverCurrent.Controls.Add(this.lblIdle);
            this.gpbDriverCurrent.Controls.Add(this.lblRun);
            this.gpbDriverCurrent.Location = new System.Drawing.Point(328, 364);
            this.gpbDriverCurrent.Name = "gpbDriverCurrent";
            this.gpbDriverCurrent.Size = new System.Drawing.Size(228, 189);
            this.gpbDriverCurrent.TabIndex = 96;
            this.gpbDriverCurrent.TabStop = false;
            this.gpbDriverCurrent.Text = "Driver Current";
            // 
            // lblTimeMS
            // 
            this.lblTimeMS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTimeMS.Location = new System.Drawing.Point(149, 136);
            this.lblTimeMS.Name = "lblTimeMS";
            this.lblTimeMS.Size = new System.Drawing.Size(33, 13);
            this.lblTimeMS.TabIndex = 95;
            this.lblTimeMS.Text = "mS";
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
            // lblRunMA
            // 
            this.lblRunMA.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRunMA.Location = new System.Drawing.Point(149, 44);
            this.lblRunMA.Name = "lblRunMA";
            this.lblRunMA.Size = new System.Drawing.Size(33, 13);
            this.lblRunMA.TabIndex = 93;
            this.lblRunMA.Text = "mA";
            // 
            // txtCurrentIdle
            // 
            this.txtCurrentIdle.Location = new System.Drawing.Point(78, 87);
            this.txtCurrentIdle.Name = "txtCurrentIdle";
            this.txtCurrentIdle.Size = new System.Drawing.Size(65, 20);
            this.txtCurrentIdle.TabIndex = 92;
            this.txtCurrentIdle.Text = "1";
            // 
            // txtCurrentIdleTimeSetting
            // 
            this.txtCurrentIdleTimeSetting.Location = new System.Drawing.Point(78, 133);
            this.txtCurrentIdleTimeSetting.Name = "txtCurrentIdleTimeSetting";
            this.txtCurrentIdleTimeSetting.Size = new System.Drawing.Size(65, 20);
            this.txtCurrentIdleTimeSetting.TabIndex = 91;
            this.txtCurrentIdleTimeSetting.Text = "1";
            // 
            // lblTime
            // 
            this.lblTime.Location = new System.Drawing.Point(39, 136);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(33, 17);
            this.lblTime.TabIndex = 90;
            this.lblTime.Text = "Time";
            // 
            // txtCurrentRun
            // 
            this.txtCurrentRun.Location = new System.Drawing.Point(78, 41);
            this.txtCurrentRun.Name = "txtCurrentRun";
            this.txtCurrentRun.Size = new System.Drawing.Size(65, 20);
            this.txtCurrentRun.TabIndex = 59;
            this.txtCurrentRun.Text = "1";
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
            // txtMaxAttempt
            // 
            this.txtMaxAttempt.Location = new System.Drawing.Point(163, 56);
            this.txtMaxAttempt.Name = "txtMaxAttempt";
            this.txtMaxAttempt.Size = new System.Drawing.Size(99, 20);
            this.txtMaxAttempt.TabIndex = 92;
            this.txtMaxAttempt.Text = "1";
            // 
            // txtErrorRange
            // 
            this.txtErrorRange.Location = new System.Drawing.Point(163, 156);
            this.txtErrorRange.Name = "txtErrorRange";
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
            this.gpbMiscSettings.Controls.Add(this.chbxAlmInp);
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
            // txtHCA
            // 
            this.txtHCA.Enabled = false;
            this.txtHCA.Location = new System.Drawing.Point(181, 117);
            this.txtHCA.Name = "txtHCA";
            this.txtHCA.Size = new System.Drawing.Size(49, 20);
            this.txtHCA.TabIndex = 103;
            this.txtHCA.Text = "300";
            // 
            // txtLCA
            // 
            this.txtLCA.Location = new System.Drawing.Point(181, 92);
            this.txtLCA.Name = "txtLCA";
            this.txtLCA.Size = new System.Drawing.Size(49, 20);
            this.txtLCA.TabIndex = 102;
            this.txtLCA.Text = "300";
            // 
            // txtDOBoot
            // 
            this.txtDOBoot.Enabled = false;
            this.txtDOBoot.Location = new System.Drawing.Point(76, 117);
            this.txtDOBoot.Name = "txtDOBoot";
            this.txtDOBoot.Size = new System.Drawing.Size(25, 20);
            this.txtDOBoot.TabIndex = 101;
            this.txtDOBoot.Text = "0";
            // 
            // txtEOBoot
            // 
            this.txtEOBoot.Enabled = false;
            this.txtEOBoot.Location = new System.Drawing.Point(76, 92);
            this.txtEOBoot.Name = "txtEOBoot";
            this.txtEOBoot.Size = new System.Drawing.Size(25, 20);
            this.txtEOBoot.TabIndex = 97;
            this.txtEOBoot.Text = "0";
            // 
            // lblHCA
            // 
            this.lblHCA.Location = new System.Drawing.Point(140, 120);
            this.lblHCA.Name = "lblHCA";
            this.lblHCA.Size = new System.Drawing.Size(35, 17);
            this.lblHCA.TabIndex = 100;
            this.lblHCA.Text = "HCA";
            // 
            // lblLCA
            // 
            this.lblLCA.Location = new System.Drawing.Point(140, 95);
            this.lblLCA.Name = "lblLCA";
            this.lblLCA.Size = new System.Drawing.Size(35, 17);
            this.lblLCA.TabIndex = 99;
            this.lblLCA.Text = "LCA";
            // 
            // lblDOBoot
            // 
            this.lblDOBoot.Location = new System.Drawing.Point(18, 120);
            this.lblDOBoot.Name = "lblDOBoot";
            this.lblDOBoot.Size = new System.Drawing.Size(52, 17);
            this.lblDOBoot.TabIndex = 98;
            this.lblDOBoot.Text = "DO Boot";
            // 
            // lblEOBoot
            // 
            this.lblEOBoot.Location = new System.Drawing.Point(18, 95);
            this.lblEOBoot.Name = "lblEOBoot";
            this.lblEOBoot.Size = new System.Drawing.Size(52, 17);
            this.lblEOBoot.TabIndex = 97;
            this.lblEOBoot.Text = "EO Boot";
            // 
            // chbxRZ
            // 
            this.chbxRZ.Location = new System.Drawing.Point(166, 71);
            this.chbxRZ.Name = "chbxRZ";
            this.chbxRZ.Size = new System.Drawing.Size(64, 17);
            this.chbxRZ.TabIndex = 92;
            this.chbxRZ.Text = "RZ";
            // 
            // chbxAlmInp
            // 
            this.chbxAlmInp.Location = new System.Drawing.Point(166, 48);
            this.chbxAlmInp.Name = "chbxAlmInp";
            this.chbxAlmInp.Size = new System.Drawing.Size(64, 17);
            this.chbxAlmInp.TabIndex = 91;
            this.chbxAlmInp.Text = "Alm/Inp";
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
            // chbxAutoRun0
            // 
            this.chbxAutoRun0.Location = new System.Drawing.Point(21, 48);
            this.chbxAutoRun0.Name = "chbxAutoRun0";
            this.chbxAutoRun0.Size = new System.Drawing.Size(95, 17);
            this.chbxAutoRun0.TabIndex = 89;
            this.chbxAutoRun0.Text = "Auto Run 0";
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
            // chbxEnableDecel
            // 
            this.chbxEnableDecel.Enabled = false;
            this.chbxEnableDecel.Location = new System.Drawing.Point(21, 25);
            this.chbxEnableDecel.Name = "chbxEnableDecel";
            this.chbxEnableDecel.Size = new System.Drawing.Size(95, 17);
            this.chbxEnableDecel.TabIndex = 87;
            this.chbxEnableDecel.Text = "Enable Decel";
            // 
            // gpbCommunicatinSetup
            // 
            this.gpbCommunicatinSetup.Controls.Add(this.lblMS);
            this.gpbCommunicatinSetup.Controls.Add(this.chbxAutoResponse);
            this.gpbCommunicatinSetup.Controls.Add(this.gpbRSCommunication);
            this.gpbCommunicatinSetup.Controls.Add(this.combxDeviceID);
            this.gpbCommunicatinSetup.Controls.Add(this.combxBaudRate);
            this.gpbCommunicatinSetup.Controls.Add(this.txtTimeOutCounter);
            this.gpbCommunicatinSetup.Controls.Add(this.lblTimeOutCounter);
            this.gpbCommunicatinSetup.Controls.Add(this.lblDeviceID);
            this.gpbCommunicatinSetup.Controls.Add(this.lblBaudRate);
            this.gpbCommunicatinSetup.Controls.Add(this.chbxAppendID);
            this.gpbCommunicatinSetup.Location = new System.Drawing.Point(309, 10);
            this.gpbCommunicatinSetup.Name = "gpbCommunicatinSetup";
            this.gpbCommunicatinSetup.Size = new System.Drawing.Size(250, 186);
            this.gpbCommunicatinSetup.TabIndex = 93;
            this.gpbCommunicatinSetup.TabStop = false;
            this.gpbCommunicatinSetup.Text = "Communication Setup";
            // 
            // lblMS
            // 
            this.lblMS.Location = new System.Drawing.Point(197, 160);
            this.lblMS.Name = "lblMS";
            this.lblMS.Size = new System.Drawing.Size(33, 17);
            this.lblMS.TabIndex = 96;
            this.lblMS.Text = "ms";
            // 
            // chbxAutoResponse
            // 
            this.chbxAutoResponse.Enabled = false;
            this.chbxAutoResponse.Location = new System.Drawing.Point(131, 50);
            this.chbxAutoResponse.Name = "chbxAutoResponse";
            this.chbxAutoResponse.Size = new System.Drawing.Size(99, 26);
            this.chbxAutoResponse.TabIndex = 95;
            this.chbxAutoResponse.Text = "Auto Response";
            // 
            // gpbRSCommunication
            // 
            this.gpbRSCommunication.Controls.Add(this.radRS232);
            this.gpbRSCommunication.Controls.Add(this.radRS485);
            this.gpbRSCommunication.Location = new System.Drawing.Point(13, 15);
            this.gpbRSCommunication.Name = "gpbRSCommunication";
            this.gpbRSCommunication.Size = new System.Drawing.Size(95, 57);
            this.gpbRSCommunication.TabIndex = 94;
            this.gpbRSCommunication.TabStop = false;
            // 
            // radRS232
            // 
            this.radRS232.AutoSize = true;
            this.radRS232.Location = new System.Drawing.Point(6, 31);
            this.radRS232.Name = "radRS232";
            this.radRS232.Size = new System.Drawing.Size(61, 17);
            this.radRS232.TabIndex = 1;
            this.radRS232.TabStop = true;
            this.radRS232.Text = "RS-232";
            this.radRS232.UseVisualStyleBackColor = true;
            // 
            // radRS485
            // 
            this.radRS485.AutoSize = true;
            this.radRS485.Checked = true;
            this.radRS485.Location = new System.Drawing.Point(6, 9);
            this.radRS485.Name = "radRS485";
            this.radRS485.Size = new System.Drawing.Size(61, 17);
            this.radRS485.TabIndex = 0;
            this.radRS485.TabStop = true;
            this.radRS485.Text = "RS-485";
            this.radRS485.UseVisualStyleBackColor = true;
            // 
            // combxDeviceID
            // 
            this.combxDeviceID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combxDeviceID.FormattingEnabled = true;
            this.combxDeviceID.Location = new System.Drawing.Point(131, 119);
            this.combxDeviceID.Name = "combxDeviceID";
            this.combxDeviceID.Size = new System.Drawing.Size(60, 21);
            this.combxDeviceID.TabIndex = 93;
            // 
            // combxBaudRate
            // 
            this.combxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            // chbxAppendID
            // 
            this.chbxAppendID.Location = new System.Drawing.Point(131, 19);
            this.chbxAppendID.Name = "chbxAppendID";
            this.chbxAppendID.Size = new System.Drawing.Size(81, 26);
            this.chbxAppendID.TabIndex = 87;
            this.chbxAppendID.Text = "Append ID";
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MagSetupPage";
            this.Load += new System.EventHandler(this.MagSetupPage_Load);
            this.gpbPolarity.ResumeLayout(false);
            this.gpbPolarityEnable.ResumeLayout(false);
            this.gpbPolarityEnable.PerformLayout();
            this.gpbSAErr.ResumeLayout(false);
            this.gpbSAErr.PerformLayout();
            this.gpbInput.ResumeLayout(false);
            this.gpbInput.PerformLayout();
            this.gpbOutput.ResumeLayout(false);
            this.gpbOutput.PerformLayout();
            this.gpbAlarm.ResumeLayout(false);
            this.gpbAlarm.PerformLayout();
            this.gpbInPos.ResumeLayout(false);
            this.gpbInPos.PerformLayout();
            this.gpbLatch.ResumeLayout(false);
            this.gpbLatch.PerformLayout();
            this.gpbLimit.ResumeLayout(false);
            this.gpbLimit.PerformLayout();
            this.gpbHome.ResumeLayout(false);
            this.gpbHome.PerformLayout();
            this.gpbDir.ResumeLayout(false);
            this.gpbDir.PerformLayout();
            this.gpbSetupPara.ResumeLayout(false);
            this.gpbDriverCurrent.ResumeLayout(false);
            this.gpbDriverCurrent.PerformLayout();
            this.gpbStepNLoopControl.ResumeLayout(false);
            this.gpbStepNLoopControl.PerformLayout();
            this.gpbMiscSettings.ResumeLayout(false);
            this.gpbMiscSettings.PerformLayout();
            this.gpbCommunicatinSetup.ResumeLayout(false);
            this.gpbCommunicatinSetup.PerformLayout();
            this.gpbRSCommunication.ResumeLayout(false);
            this.gpbRSCommunication.PerformLayout();
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
        private System.Windows.Forms.CheckBox chbxAppendID;
        private System.Windows.Forms.ComboBox combxDeviceID;
        private System.Windows.Forms.GroupBox gpbRSCommunication;
        private System.Windows.Forms.CheckBox chbxAutoResponse;
        private System.Windows.Forms.Label lblMS;
        private System.Windows.Forms.RadioButton radRS485;
        private System.Windows.Forms.RadioButton radRS232;
        internal System.Windows.Forms.GroupBox gpbMiscSettings;
        private System.Windows.Forms.CheckBox chbxEnableDecel;
        private System.Windows.Forms.CheckBox chbxIERR;
        private System.Windows.Forms.CheckBox chbxAutoRun0;
        private System.Windows.Forms.CheckBox chbxAutoRun1;
        private System.Windows.Forms.CheckBox chbxAlmInp;
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
        private System.Windows.Forms.TextBox txtCurrentIdleTimeSetting;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TextBox txtCurrentRun;
        private System.Windows.Forms.Label lblIdle;
        private System.Windows.Forms.Label lblRun;
        private System.Windows.Forms.TextBox txtCurrentIdle;
        private System.Windows.Forms.Label lblRunMA;
        private System.Windows.Forms.Label lblIdleMA;
        private System.Windows.Forms.Label lblTimeMS;
        internal System.Windows.Forms.Button cmdOpen;
        internal System.Windows.Forms.Button cmdSave;
        internal System.Windows.Forms.Button cmdUpload;
        internal System.Windows.Forms.Button cmdDown;
        internal System.Windows.Forms.Button cmdStore;
        internal System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Label cmdDir;
        private System.Windows.Forms.Label lblHome;
        private System.Windows.Forms.Label lblLatch;
        private System.Windows.Forms.Label lblLimit;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Label lblAlarm;
        private System.Windows.Forms.Label lblInPos;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Label lblSAErr;
        private System.Windows.Forms.Label lblEnable;
        private System.Windows.Forms.GroupBox gpbDir;
        private System.Windows.Forms.RadioButton radDirCCW;
        private System.Windows.Forms.GroupBox gpbHome;
        private System.Windows.Forms.RadioButton radHomeLow;
        private System.Windows.Forms.RadioButton radHomeHigh;
        private System.Windows.Forms.GroupBox gpbLimit;
        private System.Windows.Forms.RadioButton radLimitLow;
        private System.Windows.Forms.RadioButton radLimitHigh;
        private System.Windows.Forms.GroupBox gpbLatch;
        private System.Windows.Forms.RadioButton radLatchLow;
        private System.Windows.Forms.RadioButton radLatchHigh;
        private System.Windows.Forms.GroupBox gpbAlarm;
        private System.Windows.Forms.RadioButton radAlarmLow;
        private System.Windows.Forms.RadioButton radAlarmHigh;
        private System.Windows.Forms.GroupBox gpbInPos;
        private System.Windows.Forms.RadioButton radInPosLow;
        private System.Windows.Forms.RadioButton radInPosHigh;
        private System.Windows.Forms.GroupBox gpbOutput;
        private System.Windows.Forms.RadioButton radDigitalOutputLow;
        private System.Windows.Forms.RadioButton radDigitalOutputHigh;
        private System.Windows.Forms.GroupBox gpbInput;
        private System.Windows.Forms.RadioButton radDigitalInputLow;
        private System.Windows.Forms.RadioButton radDigitalInputHigh;
        private System.Windows.Forms.GroupBox gpbSAErr;
        private System.Windows.Forms.RadioButton radSAErrLow;
        private System.Windows.Forms.RadioButton radSAErrHigh;
        private System.Windows.Forms.GroupBox gpbPolarityEnable;
        private System.Windows.Forms.RadioButton radEnableLow;
        private System.Windows.Forms.RadioButton radEnableHigh;
        private System.Windows.Forms.RadioButton radDirCW;
    }
}