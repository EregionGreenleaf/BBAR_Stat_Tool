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
        public string plName = string.Empty;
        public string txtFile = string.Empty;
        Bitmap txtImage = null;

        public frmShowCharts()
        {
            InitializeComponent();
        }

        private void frmShowCharts_Load(object sender, EventArgs e)
        {

        }

        public void Elaborate(List<PlayerStatT> playerGlobal, string playerName, FileInfo textFile = null, bool toPDF = false)
        {
            try
            {
                plName = playerName;
                txtFile = textFile.FullName;
                this.Text = "BBARST - Live Charts - " + playerName;

                //K/D ratio & W/L ratio SECTION
                double[] KDr;
                double[] WLr;
                List<double> listKDr = new List<double>();
                List<double> listWLr = new List<double>();
                for (int season = 1; season <= ConfigFile.SEASON_LAST; season++)
                {
                    List<PlayerStatT> listAllPlayer = new List<PlayerStatT>();
                    PlayerStatT actualPlayer = new PlayerStatT();
                    listAllPlayer = playerGlobal.Where(x => x.Season == season && x.Category == 0).ToList();
                    actualPlayer = listAllPlayer.Count > 0 ? listAllPlayer.First() : null;
                    if (actualPlayer != null)
                    {
                        if (actualPlayer.Name.ToUpper() == playerName.ToUpper())
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
                    else
                    {
                        listKDr.Add(0);
                        listWLr.Add(0);
                    }
                }
                KDr = listKDr.ToArray();
                WLr = listWLr.ToArray();
                GraphOps.DrawChartKDWLr(crtKDWKr, KDr, WLr,
                                        (double)playerGlobal.Where(x => x.Season == 0 && x.Category == 0).First().KDr,
                                        (double)playerGlobal.Where(x => x.Season == 0 && x.Category == 0).First().WLr);

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
                    List<PlayerStatT> listAllPlayer = new List<PlayerStatT>();
                    PlayerStatT actualPlayer = new PlayerStatT();
                    listAllPlayer = playerGlobal.Where(x => x.Season == season && x.Category == 0).ToList();
                    actualPlayer = listAllPlayer.Count > 0 ? listAllPlayer.First() : null;
                    if (actualPlayer != null)
                    {
                        if (actualPlayer.Name.ToUpper() == playerName.ToUpper())
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
                    else
                    {
                        listKpM.Add((double)0.0);
                        listDpM.Add((double)0.0);
                        listPlayedG.Add(0);
                    }
                }
                KpM = listKpM.ToArray();
                DpM = listDpM.ToArray();
                PlayerStatT tempPlayer = playerGlobal.Where(x => x.Season == 0 && x.Category == 0).First();
                GraphOps.DrawChartKDpM(crtKDpM, KpM, DpM,
                                        Math.Round((double)tempPlayer.Kills / (double)tempPlayer.GamesPlayed, 2),
                                        Math.Round((double)tempPlayer.Deaths / (double)tempPlayer.GamesPlayed, 2));

                // Avarage MS SECTION
                int[] AvMS;
                List<int> listAvMS = new List<int>();
                for (int season = 1; season <= ConfigFile.SEASON_LAST; season++)
                {
                    List<PlayerStatT> listAllPlayer = new List<PlayerStatT>();
                    PlayerStatT actualPlayer = new PlayerStatT();
                    listAllPlayer = playerGlobal.Where(x => x.Season == season && x.Category == 0).ToList();
                    actualPlayer = listAllPlayer.Count > 0 ? listAllPlayer.First() : null;
                    if (actualPlayer != null)
                    {
                        if (actualPlayer.Name.ToUpper() == playerName.ToUpper())
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
                    else
                    {
                        listAvMS.Add(0);
                    }
                }
                AvMS = listAvMS.ToArray();
                GraphOps.DrawChartAvMS(crtAvMS, AvMS, listPlayedG.ToArray(),
                                       (double)playerGlobal.Where(x => x.Season == 0 && x.Category == 0).First().AvarageMatchScore,
                                       Math.Round((double)playerGlobal.Where(x => x.Season == 0 && x.Category == 0).First().GamesPlayed / (double)ConfigFile.SEASON_LAST, 2));
                Bitmap textImage = GraphOps.CreateBitmapImage(textFile.FullName, toPDF);
                if (toPDF)
                    txtImage = textImage;
                else
                    pcbStats.Image = textImage;
            }
            catch(Exception exp)
            {

            }
        }

        private void crtAvMS_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintCharts_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap textImage = GraphOps.CreateBitmapImage(txtFile, true);
                PdfOps pdfOp = new PdfOps();
                pdfOp.DrawStats(plName, textImage);
            }
            catch
            {

            }
        }
    }
}
