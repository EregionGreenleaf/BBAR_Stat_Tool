using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Threading;

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
                //newGetData.Show();
                newGetData.Visible = true;
            }
            else
            {
                frmGetData oldGetData = ConfigFile.ACTUAL_GETDATA;
                //oldGetData.Show();
                oldGetData.Visible = true;
            }
            //this.Opacity = 50;
            this.Hide();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            DownloadData data1 = new DownloadData(user: "eregiongreenleafthegray@yahoo.it",
                                                  password: "chupa33",
                                                  season: 9,
                                                  type: 0,
                                                  startPage: 0,
                                                  endPage: 3500,
                                                  taskNumber: 1);
            DownloadData data2 = new DownloadData(dData: data1, type: 1);
            //WebOps.LoginAndDownload(9, 0, "", "", 910, 3500);
            WebOps.LoginAndDownload(dData: data1);
            WebOps.LoginAndDownload(dData: data1, type: 1);
            WebOps.LoginAndDownload(dData: data1, type: 2);
            WebOps.LoginAndDownload(dData: data1, type: 3);
            WebOps.LoginAndDownload(dData: data1, type: 4);
            //WebOps.LoginAndDownload(9, 1, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(9, 2, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(9, 3, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(9, 4, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);

            //WebOps.LoginAndDownload(7, 0, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(7, 1, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(7, 2, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(7, 3, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(7, 4, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);

            //WebOps.LoginAndDownload(6, 0, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(6, 1, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(6, 2, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(6, 3, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(6, 4, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);

            //WebOps.LoginAndDownload(5, 0, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(5, 1, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(5, 2, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(5, 3, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(5, 4, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);

            //WebOps.LoginAndDownload(4, 0, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(4, 1, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(4, 2, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(4, 3, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(4, 4, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);

            //WebOps.LoginAndDownload(3, 0, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(3, 1, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(3, 2, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(3, 3, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(3, 4, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);

            //WebOps.LoginAndDownload(2, 0, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(2, 1, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(2, 2, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(2, 3, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(2, 4, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);

            //WebOps.LoginAndDownload(1, 0, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(1, 1, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(1, 2, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(1, 3, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);
            //WebOps.LoginAndDownload(1, 4, "eregiongreenleafthegray@yahoo.it", "chupa33", 0, 3500);

            //WebOps.LoginAndDownload(1,0,);
        }

        private async void btnTest2_Click(object sender, EventArgs e)
        {
            string playerName = Microsoft.VisualBasic.Interaction.InputBox("Insert Player Name to download:", "Download all data of Player", "PlayerName", -1, -1);
            playerName = playerName.Trim();
            if (!string.IsNullOrWhiteSpace(playerName))
            {
                ConfigFile._Global = new Semaphore(0, 1);
                List<int> typeList = new List<int> { 0, 1, 2, 3, 4 };
                List<int> seasonsList = new List<int>();
                for (int i = 1; i <= ConfigFile.SEASON_LAST; i++)
                    seasonsList.Add(i);

                ConfigFile.GLOBAL_PLAYER = new List<PlayerStatT>();
                ConfigFile.GLOBAL_AWAIT_OBJ = ConfigFile.SEASON_LAST * 4;
                ConfigFile.GLOBAL_AWAIT_ACTUAL = 0;

                List<int> actualSeason = new List<int> { 1 };
                List<int> actualType = new List<int> { 1 };
                WebOps.SearchPlayer(playerName, actualSeason, actualType, "eregiongreenleafthegray@yahoo.it", "chupa33");

                //foreach (var season in seasonsList)
                //{
                //    foreach(var type in typeList)
                //    {
                //        List<int> actualSeason = new List<int> { season };
                //        List<int> actualType = new List<int> { type };
                //        WebOps.SearchPlayer(playerName, actualSeason, actualType, "eregiongreenleafthegray@yahoo.it", "chupa33");
                //    }
                //}
                while(ConfigFile.GLOBAL_AWAIT_ACTUAL <= ConfigFile.GLOBAL_AWAIT_OBJ)
                {

                }

                await WebOps.SearchPlayer(playerName, seasonsList, new List<int> { 0, 1, 2, 3, 4 }, "eregiongreenleafthegray@yahoo.it", "chupa33");
                if(ConfigFile.GLOBAL_PLAYER.Count > 0)
                {

                }
                else
                {

                }
            }

            //if (ConfigFile.ACTUAL_GETDATASINGLE == null)
            //{
            //    frmGetDataSingle newGetDataSingle = new frmGetDataSingle();
            //    ConfigFile.ACTUAL_GETDATASINGLE = newGetDataSingle;
            //    newGetDataSingle.Show();
            //}
            //else
            //{
            //    frmGetDataSingle oldGetDataSingle = ConfigFile.ACTUAL_GETDATASINGLE;
            //    oldGetDataSingle.Show();
            //}

            //this.Hide();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            await WebOps.FindLastSeason();
            if (ConfigFile.LAST_SEASON_CHECKED)
            {
                Mex.AddMessage("Last Season found: " + ConfigFile.SEASON_LAST, Mex.INFO);
                //Mex.PrintMessageInForm("Last Season found: " + ConfigFile.SEASON_LAST);
                Mex.PrintMessageInForm(Mex.FormatMessageAtIndex());
                Mex.RemoveAll();
            }
            this.Enabled = true;
        }
    }
}
