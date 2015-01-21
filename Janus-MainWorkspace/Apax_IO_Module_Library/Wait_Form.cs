using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apax_IO_Module_Library
{
    public partial class Wait_Form : Form
    {
        private int iCount;
        private int iRunTime;
        private int iMilliSec;

        public Wait_Form()
        {
            InitializeComponent();
            iCount = 1;
            iRunTime = 0;
            iMilliSec = 0;

        }
        public void Start_Wait()
        {

            this.iMilliSec = 4500;
            this.Timer1.Enabled = true;
        }
        public void Start_Wait(int iWait)
        {
            this.iMilliSec = iWait;
            this.Timer1.Enabled = true;
        }
        public void End_Wait()
        {
            Timer1.Enabled = false;
            this.Close();
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            int iLabelStatus;
            iLabelStatus = (iCount % 4);
            iRunTime = (iRunTime + Timer1.Interval);

            switch (iLabelStatus)
            {
                case 0:
                    this.lbl_Wait.Text = "Please waiting.";
                    iCount = 0;
                    break;
                case 1:
                    this.lbl_Wait.Text = "Please waiting..";
                    break;
                case 2:
                    this.lbl_Wait.Text = "Please waiting...";
                    break;
                case 3:
                    this.lbl_Wait.Text = "Please waiting....";
                    break;
            }
            if ((iRunTime >= iMilliSec))
            {
                progressBar1.Value = 100;
                End_Wait();
            }
            else
            {
                progressBar1.Value = (int)(iRunTime * (100.0 / (double)iMilliSec));
            }
            iCount = (iCount + 1);
        }

    }
}