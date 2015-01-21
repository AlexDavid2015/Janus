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
    public partial class DIO_FormSafetySetting : Form
    {
        public delegate void EventHandler_ApplySafetyValueClick(bool[] bVal);
        public event EventHandler_ApplySafetyValueClick ApplySafetyValueClick;
        int m_iChannelTotal;
        bool[] m_bVal;

        public static int COLUMNIDX_CHANNEL = 0;
        public static int COLUMNIDX_DOSAFETYSTATE = 1;

        //public DIO_FormSafetySetting()
        //{
        //    InitializeComponent();
        //}

        public DIO_FormSafetySetting(int iChannelTotal, bool[] bVal)
        {
            InitializeComponent();
            m_iChannelTotal = iChannelTotal;
            m_bVal = bVal;
            bool bSelectAll = true;
            gridviewSafety.RowCount = iChannelTotal;
            // Set init information
            for (int i = 0; i < iChannelTotal; i++)
            {
                gridviewSafety[COLUMNIDX_CHANNEL, i].Value = i.ToString();
                gridviewSafety[COLUMNIDX_DOSAFETYSTATE, i].Value = m_bVal[i].ToString();
                if (bSelectAll == true && m_bVal[i] == false)
                    bSelectAll = false;
            }
            chbxSelecteAll.Checked = bSelectAll;
        }

        private void gridviewSafety_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool bSelectAll;
            if (e.ColumnIndex == COLUMNIDX_DOSAFETYSTATE && e.RowIndex != -1)
            {
                gridviewSafety.EndEdit();   //Stop editing of cell. <<<<<< otherwise, we cannot get correct value
                bSelectAll = true;
                for (int i = 0; i < m_iChannelTotal; i++)
                {
                    if (Convert.ToBoolean(gridviewSafety[COLUMNIDX_DOSAFETYSTATE, i].Value) == false)   // found one is not selected
                    {
                        bSelectAll = false;
                        break;
                    }
                }
                if (chbxSelecteAll.Checked != bSelectAll)
                    chbxSelecteAll.Checked = bSelectAll;
            }
        }

        /// <summary>
        /// Apply setting when user configure safety status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDIO_SafetySettingApply_Click(object sender, EventArgs e)
        {
            if (ApplySafetyValueClick != null)
            {
                for (int i = 0; i < m_iChannelTotal; i++)
                {
                    m_bVal[i] = Convert.ToBoolean(gridviewSafety[COLUMNIDX_DOSAFETYSTATE, i].Value);
                }
                ApplySafetyValueClick(m_bVal);
            }
        }

        private void chbxSelecteAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < m_iChannelTotal; i++)
            {
                if (Convert.ToBoolean(gridviewSafety[COLUMNIDX_DOSAFETYSTATE, i].Value) != chbxSelecteAll.Checked)
                    gridviewSafety[COLUMNIDX_DOSAFETYSTATE, i].Value = chbxSelecteAll.Checked;

            }
        }
    }
}
