using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Apax_IO_Module_Library
{
    public partial class IPForm : Form
    {
        public delegate void EventHandler_ApplyIPAddressClick(string szVal);
        public event EventHandler_ApplyIPAddressClick ApplyIPAddressClick;
        public IPForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ApplyIPAddressClick != null)
            {
                label1.Text = IPAddressText.Text;

                ApplyIPAddressClick(IPAddressText.Text);

            }
            this.Close();
        }

    }
}