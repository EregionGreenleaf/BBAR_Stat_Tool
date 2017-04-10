using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBAR_Stat_Tool
{
    public partial class frmShowCharts : Form
    {
        public frmShowCharts()
        {
            InitializeComponent();
        }

        private void frmShowCharts_Load(object sender, EventArgs e)
        {

        }

        public void Elaborate(List<PlayerStatT> playerGlobal, string playerName, FileInfo textFile = null)
        {
            this.Text = "BBARST - Live Charts - " + playerName;
            //K/D ratio & W/L ratio SECTION
            double[] KDr;
            double[] WLr;
            List<double> listKDr = new List<double>();
            List<double> listWLr = new List<double>();
            for(int season = 1; season <= ConfigFile.SEASON_LAST; season++)
            {
                PlayerStatT actualPlayer = playerGlobal.Where(x => x.Season == season && x.Category == 0).First();
                if (actualPlayer.Name == playerName)
                {
                    if (actualPlayer.KDr != null)
                        listKDr.Add((double)actualPlayer.KDr);
                    else
                        listKDr.Add(0);
                    if (actualPlayer.WLr != null)
                        listWLr.Add((double)actualPlayer.WLr);
                    else
                        listWLr.Add(0);
                }
                else
                {
                    listKDr.Add(0);
                    listWLr.Add(0);
                }
            }
            KDr = listKDr.ToArray();
            WLr = listWLr.ToArray();
            GraphOps.DrawChartKDWLr(crtKDWKr, KDr, WLr);

            // Kills per Match & Deaths per Match SECTION
            double[] KpM;
            double[] DpM;
            List<int> listPlayedG = new List<int>();
            List<double> listKpM = new List<double>();
            List<double> listDpM = new List<double>();
            for (int season = 1; season <= ConfigFile.SEASON_LAST; season++)
            {
                int kills = 0;
                int deaths = 0;
                int played = 0;
                PlayerStatT actualPlayer = playerGlobal.Where(x => x.Season == season && x.Category == 0).First();
                if (actualPlayer.Name == playerName)
                {
                    if (actualPlayer.Kills != null)
                        kills = (int)actualPlayer.Kills;
                    else
                        kills = 0;
                    if (actualPlayer.Deaths != null)
                        deaths = (int)actualPlayer.Deaths;
                    else
                        deaths = 0;
                    if (actualPlayer.GamesPlayed != 0)
                        played = (int)actualPlayer.GamesPlayed;
                    else
                        played = 0;
                    listKpM.Add((double)((double)kills / (double)played));
                    listDpM.Add((double)((double)deaths / (double)played));
                    listPlayedG.Add(played);
                }
                else
                {
                    listKpM.Add((double)0.0);
                    listDpM.Add((double)0.0);
                    listPlayedG.Add(0);
                }
            }
            KpM = listKpM.ToArray();
            DpM = listDpM.ToArray();
            GraphOps.DrawChartKDpM(crtKDpM, KpM, DpM);

            // Avarage MS SECTION
            int[] AvMS;
            List<int> listAvMS = new List<int>();
            for (int season = 1; season <= ConfigFile.SEASON_LAST; season++)
            {
                PlayerStatT actualPlayer = playerGlobal.Where(x => x.Season == season && x.Category == 0).First();
                if (actualPlayer.Name == playerName)
                {
                    if (actualPlayer.Kills != null)
                        listAvMS.Add((int)actualPlayer.AvarageMatchScore);
                    else
                        listAvMS.Add(0);
                }
                else
                {
                    listAvMS.Add(0);
                }
            }
            AvMS = listAvMS.ToArray();
            GraphOps.DrawChartAvMS(crtAvMS, AvMS, listPlayedG.ToArray());
            Bitmap textImage = GraphOps.CreateBitmapImage(textFile.FullName);
            pcbStats.Image = textImage;
        }

        private void crtAvMS_Click(object sender, EventArgs e)
        {

        }
    }
}
