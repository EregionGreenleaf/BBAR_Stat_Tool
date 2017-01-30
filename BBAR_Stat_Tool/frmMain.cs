using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBAR_Stat_Tool
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        public string lblCopyrightText
        {
            get
            {
                return this.lblCopyright.Text;
            }
            set
            {
                this.lblCopyright.Text = value;
            }
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            if (ConfigFile.ACTUAL_GETDATA == null)
            {
                frmGetData newGetData = new frmGetData();
                ConfigFile.ACTUAL_GETDATA = newGetData;
                newGetData.Show();
            }
            else
            {
                frmGetData oldGetData = ConfigFile.ACTUAL_GETDATA;
                oldGetData.Show();
            }
            //this.Opacity = 50;
            this.Hide();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            WebOps.LoginAndDownload(7, 0, "eregiongreenleafthegray@yahoo.it", "chupa33");
            //WebOps.LoginAndDownload(1,0,);
        }
    }
}
