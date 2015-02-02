using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CxTitan
{
    public partial class Input : Form
    {
        public Input()
        {
            InitializeComponent();
        }

        private void cmdEnter_Click(object sender, EventArgs e)
        {
            float Top, Bot, BOV, G1VMin, G1VMax, G2VMin, G2VMax, MTTop, MTBot;
            int RFTop = 300;// hard coded 300(int RFTop = Globals.CurrentMachineStatus.Setup_RFPower;)
            int RFBot = 0;// hard coded
            Top = 0.9f;// 1.2f
            Bot = 0.03f;
            BOV = 6;
            G1VMin = 0;
            //G1VMax = 200 / Convert.ToSingle(Globals.GAS1_CF);
            G1VMax = 200 / 1.39f;// hard coded 200 / 1.39f, G1VMax = 200 / Convert.ToSingle(Globals.CurrentMachineStatus.Setup_Gas1CF);
            G2VMin = 0;
            G2VMax = 200 / 0.99f;// hard coded 200 / 0.99f, G2VMax = 200 / Convert.ToSingle(Globals.CurrentMachineStatus.Setup_Gas2CF);
            //G2VMax = 200;

            MTTop = 1;
            MTBot = 0.1f;

            // description
            if (SystemGlobals.InputTyp == "NM")
            {
                SystemGlobals.InputVal = tbInput.Text;
                this.Close();
                this.Dispose();
                return;
            }

            // speed of pusher(set up)
            if (SystemGlobals.InputTyp == "SP")
            {
                int parsedResult;
                if (int.TryParse(tbInput.Text, out parsedResult) == false)
                {
                    MessageBox.Show("Only Numeric Values are allowed.");
                    tbInput.Text = "";
                    tbInput.Focus();
                    return;
                }
                if (Convert.ToInt32(tbInput.Text) > 500)
                {
                    MessageBox.Show("Incorrect Speed. Max Speed is 500 mm/sec");
                    tbInput.Text = "500";
                    SystemGlobals.InputVal = tbInput.Text;
                    this.Close();
                    this.Dispose();
                    return;
                }
                if (Convert.ToInt32(tbInput.Text) < 50)
                {
                    MessageBox.Show("Incorrect Speed. Min Speed is 50 mm/sec");
                    tbInput.Text = "50";
                    SystemGlobals.InputVal = tbInput.Text;
                    this.Close();
                    this.Dispose();
                    return;
                }
                else
                {
                    SystemGlobals.InputVal = tbInput.Text;
                    this.Close();
                    this.Dispose();
                    return;
                }
                //tbInput.Text = "";
                //tbInput.Focus();
                //Globals.InputVal = tbInput.Text;
                //this.Close();
                //this.Dispose();
            }

            // bottom offset
            if (SystemGlobals.InputTyp == "BO")
            {
                float parsedResult;
                if (float.TryParse(tbInput.Text, out parsedResult) == false)
                {
                    MessageBox.Show("Only Numeric Values are allowed.");
                    tbInput.Text = "";
                    tbInput.Focus();
                    return;
                }
                if (Convert.ToSingle(tbInput.Text) > 100)
                {
                    MessageBox.Show("Please insert values less than 100.");
                }
                else
                {
                    if (Convert.ToSingle(tbInput.Text) < BOV)
                    {
                        MessageBox.Show("Please only insert values equal or more than 6.");
                    }
                    else
                    {
                        SystemGlobals.InputVal = tbInput.Text;
                        this.Close();
                        this.Dispose();
                        return;
                    }
                }
                tbInput.Text = "";
                tbInput.Focus();
            }

            // G1 volume
            if (SystemGlobals.InputTyp == "G1")
            {
                float parsedResult;
                if (float.TryParse(tbInput.Text, out parsedResult) == false)
                {
                    MessageBox.Show("Only Numeric Values are allowed.");
                    tbInput.Text = "";
                    tbInput.Focus();
                    return;
                }
                if (Convert.ToSingle(tbInput.Text) > G1VMax)
                {
                    MessageBox.Show("Please insert values between 2 and " + G1VMax + " sccm.");
                }
                else
                {
                    if (Convert.ToSingle(tbInput.Text) < G1VMin)
                    {
                        MessageBox.Show("Please insert values between 2 and " + G1VMax + " sccm.");
                    }
                    else
                    {
                        SystemGlobals.InputVal = tbInput.Text;
                        this.Close();
                        this.Dispose();
                        return;
                    }
                }
                tbInput.Text = "";
                tbInput.Focus();
            }

            // G2 volume
            if (SystemGlobals.InputTyp == "G2")
            {
                float parsedResult;
                if (float.TryParse(tbInput.Text, out parsedResult) == false)
                {
                    MessageBox.Show("Only Numeric Values are allowed.");
                    tbInput.Text = "";
                    tbInput.Focus();
                    return;
                }
                if (Convert.ToSingle(tbInput.Text) > G2VMax)
                {
                    MessageBox.Show("Please insert values between 2 and " + G2VMax + " sccm.");
                }
                else
                {
                    if (Convert.ToSingle(tbInput.Text) < G2VMin)
                    {
                        MessageBox.Show("Please insert values between 2 and " + G2VMax + " sccm.");
                    }
                    else
                    {
                        SystemGlobals.InputVal = tbInput.Text;
                        this.Close();
                        this.Dispose();
                        return;
                    }
                }
                tbInput.Text = "";
                tbInput.Focus();
            }

            // Pressure
            if (SystemGlobals.InputTyp == "PT")
            {
                float parsedResult;
                if (float.TryParse(tbInput.Text, out parsedResult) == false)
                {
                    MessageBox.Show("Only Numeric Values are allowed.");
                    tbInput.Text = "";
                    tbInput.Focus();
                    return;
                }
                if (Convert.ToSingle(tbInput.Text) > Top)
                {
                    MessageBox.Show("Please insert values between 0.1 and 0.9 mbar.");
                }
                else
                {
                    if (Convert.ToSingle(tbInput.Text) < Bot)
                    {
                        MessageBox.Show("Please insert values between 0.1 and 0.9 mbar.");
                    }
                    else
                    {
                        SystemGlobals.InputVal = tbInput.Text;
                        this.Close();
                        this.Dispose();
                        return;
                    }
                }
                tbInput.Text = "";
                tbInput.Focus();
            }

            // Power
            if (SystemGlobals.InputTyp == "PW")
            {
                float parsedResult;
                if (float.TryParse(tbInput.Text, out parsedResult) == false)
                {
                    MessageBox.Show("Only Numeric Values are allowed.");
                    tbInput.Text = "";
                    tbInput.Focus();
                    return;
                }
                if (Convert.ToSingle(tbInput.Text) > RFTop)
                {
                    MessageBox.Show("Please insert values between 0 and " + RFTop + " Watts.");
                }
                else
                {
                    if (Convert.ToSingle(tbInput.Text) < RFBot)
                    {
                        MessageBox.Show("Please insert values between 0 and " + RFTop + " Watts.");
                    }
                    else
                    {
                        SystemGlobals.InputVal = tbInput.Text;
                        this.Close();
                        this.Dispose();
                        return;
                    }
                }
                tbInput.Text = "";
                tbInput.Focus();
            }

            // RF Time
            if (SystemGlobals.InputTyp == "RT")
            {
                float parsedResult;
                if (float.TryParse(tbInput.Text, out parsedResult) == false)
                {
                    MessageBox.Show("Only Numeric Values are allowed.");
                    tbInput.Text = "";
                    tbInput.Focus();
                    return;
                }
                if (Convert.ToSingle(tbInput.Text) > 120)
                {
                    MessageBox.Show("Please insert values between 2 and 120 sec.");
                }
                else
                {
                    if (Convert.ToSingle(tbInput.Text) < 2)
                    {
                        MessageBox.Show("Please insert values between 2 and 120 sec. Please note Values less than 2 sec will not produce plasma.");
                    }
                    else
                    {
                        SystemGlobals.InputVal = tbInput.Text;
                        this.Close();
                        this.Dispose();
                        return;
                    }
                }
                tbInput.Text = "";
                tbInput.Focus();
            }

            // Top Offset
            if (SystemGlobals.InputTyp == "TO")
            {
                float parsedResult;
                if (float.TryParse(tbInput.Text, out parsedResult) == false)
                {
                    MessageBox.Show("Only Numeric Values are allowed.");
                    tbInput.Text = "";
                    tbInput.Focus();
                    return;
                }
                if (Convert.ToSingle(tbInput.Text) > 250)
                {
                    MessageBox.Show("Please insert values between 20 and 250.");
                }
                else
                {
                    if (Convert.ToSingle(tbInput.Text) < 20)
                    {
                        MessageBox.Show("Please insert values between 20 and 250.");
                    }
                    else
                    {
                        SystemGlobals.InputVal = tbInput.Text;
                        this.Close();
                        this.Dispose();
                        return;
                    }
                }
                tbInput.Text = "";
                tbInput.Focus();
            }

            // TTP
            if (SystemGlobals.InputTyp == "TTP")
            {
                int parsedResult;
                if (int.TryParse(tbInput.Text, out parsedResult) == false)
                {
                    MessageBox.Show("Only Numeric Values are allowed.");
                    tbInput.Text = "";
                    tbInput.Focus();
                    return;
                }
                if (Convert.ToInt32(tbInput.Text) > 10)
                {
                    MessageBox.Show("Please insert values between 1 and 10 sec.");
                }
                else
                {
                    if (Convert.ToInt32(tbInput.Text) <= 0)
                    {
                        MessageBox.Show("Please insert values between 1 and 10 sec.");
                    }
                    else
                    {
                        SystemGlobals.InputVal = tbInput.Text;
                        this.Close();
                        this.Dispose();
                        return;
                    }
                }
                tbInput.Text = "";
                tbInput.Focus();
            }

            // Tune position
            if (SystemGlobals.InputTyp == "TU")
            {
                float parsedResult;
                if (float.TryParse(tbInput.Text, out parsedResult) == false)
                {
                    MessageBox.Show("Only Numeric Values are allowed.");
                    tbInput.Text = "";
                    tbInput.Focus();
                    return;
                }
                if (Convert.ToSingle(tbInput.Text) > 100)
                {
                    MessageBox.Show("Please insert values between 0 and 100 %.");
                }
                else
                {
                    if (Convert.ToSingle(tbInput.Text) < 0)
                    {
                        MessageBox.Show("Please insert values between 0 and 100 %.");
                    }
                    else
                    {
                        SystemGlobals.InputVal = tbInput.Text;
                        this.Close();
                        this.Dispose();
                        return;
                    }
                }
                tbInput.Text = "";
                tbInput.Focus();
            }

            // Load position
            if (SystemGlobals.InputTyp == "LD")
            {
                float parsedResult;
                if (float.TryParse(tbInput.Text, out parsedResult) == false)
                {
                    MessageBox.Show("Only Numeric Values are allowed.");
                    tbInput.Text = "";
                    tbInput.Focus();
                    return;
                }
                if (Convert.ToSingle(tbInput.Text) > 100)
                {
                    MessageBox.Show("Please insert values between 0 and 100 %.");
                }
                else
                {
                    if (Convert.ToSingle(tbInput.Text) < 0)
                    {
                        MessageBox.Show("Please insert values between 0 and 100 %.");
                    }
                    else
                    {
                        SystemGlobals.InputVal = tbInput.Text;
                        this.Close();
                        this.Dispose();
                        return;
                    }
                }
                tbInput.Text = "";
                tbInput.Focus();
            }

            // Pick offset
            if (SystemGlobals.InputTyp == "PO")
            {
                float parsedResult;
                if (float.TryParse(tbInput.Text, out parsedResult) == false)
                {
                    MessageBox.Show("Only Numeric Values are allowed.");
                    tbInput.Text = "";
                    tbInput.Focus();
                    return;
                }
                if (Convert.ToSingle(tbInput.Text) > 10)
                {
                    MessageBox.Show("Please insert values between 0 and 10.");
                }
                else
                {
                    if (Convert.ToSingle(tbInput.Text) < 0)
                    {
                        MessageBox.Show("Please insert values between 0 and 10.");
                    }
                    else
                    {
                        SystemGlobals.InputVal = tbInput.Text;
                        this.Close();
                        this.Dispose();
                        return;
                    }
                }
                tbInput.Text = "";
                tbInput.Focus();
            }

            // No of Substrates(int)
            if (SystemGlobals.InputTyp == "NS")
            {
                int parsedResult;
                if (int.TryParse(tbInput.Text, out parsedResult) == false)
                {
                    MessageBox.Show("Only Numeric Values are allowed.");
                    tbInput.Text = "";
                    tbInput.Focus();
                    return;
                }
                if (Convert.ToInt32(tbInput.Text) > 40)
                {
                    MessageBox.Show("Please insert values between 2 and 40.");
                }
                else
                {
                    if (Convert.ToInt32(tbInput.Text) < 2)
                    {
                        MessageBox.Show("Please insert values between 2 and 40.");
                    }
                    else
                    {
                        SystemGlobals.InputVal = tbInput.Text;
                        this.Close();
                        this.Dispose();
                        return;
                    }
                }
                tbInput.Text = "";
                tbInput.Focus();
            }

            // Manual Tuner
            if (SystemGlobals.InputTyp == "MT")
            {
                float parsedResult;
                if (float.TryParse(tbInput.Text, out parsedResult) == false)
                {
                    MessageBox.Show("Only Numeric Values are allowed.");
                    tbInput.Text = "";
                    tbInput.Focus();
                    return;
                }
                if (Convert.ToSingle(tbInput.Text) > MTTop)
                {
                    MessageBox.Show("Please insert values between 0.1 and 1.0.");
                }
                else
                {
                    if (Convert.ToSingle(tbInput.Text) < MTBot)
                    {
                        MessageBox.Show("Please insert values between 0.1 and 1.0.");
                    }
                    else
                    {
                        SystemGlobals.InputVal = tbInput.Text;
                        this.Close();
                        this.Dispose();
                        return;
                    }
                }
                tbInput.Text = "";
                tbInput.Focus();
            }

            // Length
            if (SystemGlobals.InputTyp == "LE")
            {
                float parsedResult;
                if (float.TryParse(tbInput.Text, out parsedResult) == false)
                {
                    MessageBox.Show("Only Numeric Values are allowed.");
                    tbInput.Text = "";
                    tbInput.Focus();
                    return;
                }
                if (Convert.ToSingle(tbInput.Text) > 350)
                {
                    MessageBox.Show("Please insert values between 100 and 350.");
                }
                else
                {
                    if (Convert.ToSingle(tbInput.Text) < 100)
                    {
                        MessageBox.Show("Please insert values between 100 and 350.");
                    }
                    else
                    {
                        SystemGlobals.InputVal = tbInput.Text;
                        this.Close();
                        this.Dispose();
                        return;
                    }
                }
                tbInput.Text = "";
                tbInput.Focus();
            }

            // Mag offset(slot offset)
            if (SystemGlobals.InputTyp == "MO")
            {
                float parsedResult;
                if (float.TryParse(tbInput.Text, out parsedResult) == false)
                {
                    MessageBox.Show("Only Numeric Values are allowed.");
                    tbInput.Text = "";
                    tbInput.Focus();
                    return;
                }
                if (Convert.ToSingle(tbInput.Text) > 2)
                {
                    MessageBox.Show("Please insert values between 0 and 2.");
                }
                else
                {
                    if (Convert.ToSingle(tbInput.Text) < 0)
                    {
                        MessageBox.Show("Please insert values between 0 and 2.");
                    }
                    else
                    {
                        SystemGlobals.InputVal = tbInput.Text;
                        this.Close();
                        this.Dispose();
                        return;
                    }
                }
                tbInput.Text = "";
                tbInput.Focus();
            }

            // inactive timer
            if (SystemGlobals.InputTyp == "IAM")
            {
                int parsedResult;
                if (int.TryParse(tbInput.Text, out parsedResult) == false)
                {
                    MessageBox.Show("Only Numeric Values are allowed.");
                    tbInput.Text = "";
                    tbInput.Focus();
                    return;
                }
                if (Convert.ToInt32(tbInput.Text) > 600)
                {
                    MessageBox.Show("Please insert values between 5 and 600.");
                }
                else
                {
                    if (Convert.ToInt32(tbInput.Text) < 5)
                    {
                        MessageBox.Show("Please insert values between 5 and 600.");
                    }
                    else
                    {
                        SystemGlobals.InputVal = tbInput.Text;
                        this.Close();
                        this.Dispose();
                        return;
                    }
                }
                tbInput.Text = "";
                tbInput.Focus();
            }
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
