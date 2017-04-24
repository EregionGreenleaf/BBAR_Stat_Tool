using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBAR_Stat_Tool
{
    public partial class frmWaiting : Form
    {
        public string strInfo = string.Empty;
        public frmWaiting(string info = null)
        {
            Thread.Sleep(50);
            InitializeComponent();
            if(!string.IsNullOrWhiteSpace(info))
                strInfo = info;
        }

        private void frmWaiting_Load(object sender, EventArgs e)
        {
            lblInformation.Text = strInfo;
            prbVoid.Enabled = true;
            prbVoid.Show();
            Thread.Sleep(50);
            this.BringToFront();
            prbVoid.Value = 50;
        }
    }
}
