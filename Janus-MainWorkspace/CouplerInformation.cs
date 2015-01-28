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
    public partial class CouplerInformation : Form
    {
        public CouplerInformation()
        {
            InitializeComponent();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void CouplerInformation_Load(object sender, EventArgs e)
        {
            if (Avantech.bModbusConnected)
            {
                labModuleName.Text = "APAX-PAC";
                txtFwVer.Text = Avantech.txtFwVer;//Firmware Version
                txtFwVer2.Text = Avantech.txtFwVer2;//Kernel Firmware Version
                txtFpgaFwVer.Text = Avantech.txtFpgaFwVer;//FPGA Firmware Version
                txtDeviceName.Text = Avantech.txtDeviceName;// Device Name
                txtDeviceDesc.Text = Avantech.txtDeviceDesc;// Device Desc
                txtMacAddress.Text = Avantech.txtMacAddress;//MAC address
                txtIPAddress.Text = Avantech.txtIPAddress;//IP address
                txtSubnetAddress.Text = Avantech.txtSubnetAddress;//subnet mask
                txtDefaultGateway.Text = Avantech.txtDefaultGateway;//default gateway
                numHostIdle.Text = Avantech.numHostIdle;// Host Idle time
            }
            else
            {
                labModuleName.Text = "APAX-PAC";
                txtFwVer.Text = "";//Firmware Version
                txtFwVer2.Text = "";//Kernel Firmware Version
                txtFpgaFwVer.Text = "";//FPGA Firmware Version
                txtDeviceName.Text = "";// Device Name
                txtDeviceDesc.Text = "";// Device Desc
                txtMacAddress.Text = "";//MAC address
                txtIPAddress.Text = "";//IP address
                txtSubnetAddress.Text = "";//subnet mask
                txtDefaultGateway.Text = "";//default gateway
                numHostIdle.Text = "";// Host Idle time
            }
        }
    }
}
