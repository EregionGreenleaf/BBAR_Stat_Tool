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
            WebOps.LoginAndDownload(9, 0, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(9, 1, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(9, 2, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(9, 3, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(9, 4, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);

            WebOps.LoginAndDownload(7, 0, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(7, 1, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(7, 2, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(7, 3, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(7, 4, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);

            WebOps.LoginAndDownload(6, 0, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(6, 1, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(6, 2, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(6, 3, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(6, 4, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);

            WebOps.LoginAndDownload(5, 0, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(5, 1, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(5, 2, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(5, 3, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(5, 4, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);

            WebOps.LoginAndDownload(4, 0, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(4, 1, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(4, 2, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(4, 3, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(4, 4, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);

            WebOps.LoginAndDownload(3, 0, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(3, 1, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(3, 2, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(3, 3, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(3, 4, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);

            WebOps.LoginAndDownload(2, 0, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(2, 1, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(2, 2, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(2, 3, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(2, 4, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);

            WebOps.LoginAndDownload(1, 0, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(1, 1, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(1, 2, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(1, 3, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            WebOps.LoginAndDownload(1, 4, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);

            //WebOps.LoginAndDownload(1,0,);
        }

        private async void btnTest2_Click(object sender, EventArgs e)
        {
            if (ConfigFile.ACTUAL_GETDATASINGLE == null)
            {
                frmGetDataSingle newGetDataSingle = new frmGetDataSingle();
                ConfigFile.ACTUAL_GETDATASINGLE = newGetDataSingle;
                newGetDataSingle.Show();
            }
            else
            {
                frmGetDataSingle oldGetDataSingle = ConfigFile.ACTUAL_GETDATASINGLE;
                oldGetDataSingle.Show();
            }
            //this.Opacity = 50;
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ConfigFile.ACTUAL_GETDATASINGLE == null)
            {
                frmGetDataSingle newGetDataSingle = new frmGetDataSingle();
                ConfigFile.ACTUAL_GETDATASINGLE = newGetDataSingle;
                newGetDataSingle.Show();
            }
            else
            {
                frmGetDataSingle oldGetDataSingle = ConfigFile.ACTUAL_GETDATASINGLE;
                oldGetDataSingle.Show();
            }
            //this.Opacity = 50;
            this.Hide();

        }
    }
}
