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
    public partial class AO_FormSafetySetting : Form
    {
        //public AO_FormSafetySetting()
        //{
        //    InitializeComponent();
        //}

        public delegate void EventHandler_ApplySafetyValueClick(string[] szVal);
        public event EventHandler_ApplySafetyValueClick ApplySafetyValueClick;
        int m_iChannelTotal;
        float[] m_fVal;
        string[] m_szRange;

        public static int COLUMNIDX_CHANNEL = 0;
        public static int COLUMNIDX_AOSAFETYVALUE = 1;
        public static int COLUMNIDX_AORANGE = 2;

        public AO_FormSafetySetting(int iChannelTotal, float[] fVal, string[] szRange)
        {
            InitializeComponent();
            m_iChannelTotal = iChannelTotal;
            gridviewSafety.RowCount = iChannelTotal;
            m_fVal = fVal;
            m_szRange = szRange;
            for (int i = 0; i < iChannelTotal; i++)
            {
                gridviewSafety[COLUMNIDX_CHANNEL, i].Value = i.ToString();
                gridviewSafety[COLUMNIDX_AOSAFETYVALUE, i].Value = fVal[i].ToString("0.000;-0.000");
                gridviewSafety[COLUMNIDX_AOSAFETYVALUE, i].ToolTipText = m_szRange[i];
                gridviewSafety[COLUMNIDX_AORANGE, i].Value = m_szRange[i];
            }
        }

        private void btnAO_SafetySettingApply_Click(object sender, EventArgs e)
        {
            if (ApplySafetyValueClick != null)
            {
                string[] o_szVal = new string[m_iChannelTotal];
                for (int i = 0; i < m_iChannelTotal; i++)
                {
                    o_szVal[i] = Convert.ToString(gridviewSafety[COLUMNIDX_AOSAFETYVALUE, i].Value);
                }
                ApplySafetyValueClick(o_szVal);
            }
        }
    }
}
