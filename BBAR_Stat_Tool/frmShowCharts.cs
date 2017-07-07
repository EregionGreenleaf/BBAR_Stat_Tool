using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BBAR_Stat_Tool
{
    public partial class frmShowCharts : Form
    {
        public string plName = string.Empty;
        public string txtFile = string.Empty;
        FileInfo fileText;
        //Bitmap txtImage = null;

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
                        if (actualPlayer.Name != null)
                        {
                            if (actualPlayer.Name.ToUpper() == playerName.ToUpper())
                            {
                                plName = actualPlayer.Name;
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
                            listKDr.Add((double)0.0);
                            listWLr.Add((double)0.0);
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
                        if (actualPlayer.Name != null)
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
                        if (actualPlayer.Name != null)
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
                    else
                    {
                        listAvMS.Add(0);
                    }
                }
                AvMS = listAvMS.ToArray();
                GraphOps.DrawChartAvMS(crtAvMS, AvMS, listPlayedG.ToArray(),
                                       (double)playerGlobal.Where(x => x.Season == 0 && x.Category == 0).First().AvarageMatchScore,
                                       Math.Round((double)playerGlobal.Where(x => x.Season == 0 && x.Category == 0).First().GamesPlayed / (double)ConfigFile.SEASON_LAST, 2));
                this.Text = "BBARST - Live Charts - " + plName;
                fileText = textFile;





                List<double> lightKDr = new List<double>();
                List<double> lightWLr = new List<double>();
                List<double> lightKpM = new List<double>();
                List<double> lightDpM = new List<double>();
                List<double> mediumKDr = new List<double>();
                List<double> mediumWLr = new List<double>();
                List<double> mediumKpM = new List<double>();
                List<double> mediumDpM = new List<double>();
                List<double> heavyKDr = new List<double>();
                List<double> heavyWLr = new List<double>();
                List<double> heavyKpM = new List<double>();
                List<double> heavyDpM = new List<double>();
                List<double> assaultKDr = new List<double>();
                List<double> assaultWLr = new List<double>();
                List<double> assaultKpM = new List<double>();
                List<double> assaultDpM = new List<double>();

                try
                {
                    playerGlobal.OrderBy(x => x.Season).ToList().ForEach(z =>
                    {
                        if (z.Category == 1)
                        {
                            lightKDr.Add(z.KDr == null ? 0 : (double)z.KDr);
                            lightWLr.Add(z.WLr == null ? 0 : (double)z.WLr);
                            lightKpM.Add(z.KpM == null ? 0 : (double)z.KpM);
                            lightDpM.Add(z.DpM == null ? 0 : (double)z.DpM);
                        }
                        if (z.Category == 2)
                        {
                            mediumKDr.Add(z.KDr == null ? 0 : (double)z.KDr);
                            mediumWLr.Add(z.WLr == null ? 0 : (double)z.WLr);
                            mediumKpM.Add(z.KpM == null ? 0 : (double)z.KpM);
                            mediumDpM.Add(z.DpM == null ? 0 : (double)z.DpM);
                        }
                        if (z.Category == 3)
                        {
                            heavyKDr.Add(z.KDr == null ? 0 : (double)z.KDr);
                            heavyWLr.Add(z.WLr == null ? 0 : (double)z.WLr);
                            heavyKpM.Add(z.KpM == null ? 0 : (double)z.KpM);
                            heavyDpM.Add(z.DpM == null ? 0 : (double)z.DpM);
                        }
                        if (z.Category == 4)
                        {
                            assaultKDr.Add(z.KDr == null ? 0 : (double)z.KDr);
                            assaultWLr.Add(z.WLr == null ? 0 : (double)z.WLr);
                            assaultKpM.Add(z.KpM == null ? 0 : (double)z.KpM);
                            assaultDpM.Add(z.DpM == null ? 0 : (double)z.DpM);
                        }
                    });
                }
                catch(Exception exp)
                {
                    Logger.PrintC(exp.Message);
                }

                //playerGlobal.Where(x => x.Season == 0 && x.Category == 1).FirstOrDefault().DpM;
                GraphOps.DrawChartByClass(crtByClass, lightKDr.ToArray(), lightWLr.ToArray(), lightKpM.ToArray(), lightDpM.ToArray(), "Light",
                                    (double)playerGlobal.Where(x => x.Season == 0 && x.Category == 1).FirstOrDefault().KDr,
                                    (double)playerGlobal.Where(x => x.Season == 0 && x.Category == 1).FirstOrDefault().WLr,
                                    (double)playerGlobal.Where(x => x.Season == 0 && x.Category == 1).FirstOrDefault().KpM,
                                    (double)playerGlobal.Where(x => x.Season == 0 && x.Category == 1).FirstOrDefault().DpM);
                GraphOps.DrawChartByClass(crtByClass, mediumKDr.ToArray(), mediumWLr.ToArray(), mediumKpM.ToArray(), mediumDpM.ToArray(), "Medium",
                                    (double)playerGlobal.Where(x => x.Season == 0 && x.Category == 2).FirstOrDefault().KDr,
                                    (double)playerGlobal.Where(x => x.Season == 0 && x.Category == 2).FirstOrDefault().WLr,
                                    (double)playerGlobal.Where(x => x.Season == 0 && x.Category == 2).FirstOrDefault().KpM,
                                    (double)playerGlobal.Where(x => x.Season == 0 && x.Category == 2).FirstOrDefault().DpM);
                GraphOps.DrawChartByClass(crtByClass, heavyKDr.ToArray(), heavyWLr.ToArray(), heavyKpM.ToArray(), heavyDpM.ToArray(), "Heavy",
                                    (double)playerGlobal.Where(x => x.Season == 0 && x.Category == 3).FirstOrDefault().KDr,
                                    (double)playerGlobal.Where(x => x.Season == 0 && x.Category == 3).FirstOrDefault().WLr,
                                    (double)playerGlobal.Where(x => x.Season == 0 && x.Category == 3).FirstOrDefault().KpM,
                                    (double)playerGlobal.Where(x => x.Season == 0 && x.Category == 3).FirstOrDefault().DpM);
                GraphOps.DrawChartByClass(crtByClass, assaultKDr.ToArray(), assaultWLr.ToArray(), assaultKpM.ToArray(), assaultDpM.ToArray(), "Assault",
                                    (double)playerGlobal.Where(x => x.Season == 0 && x.Category == 4).FirstOrDefault().KDr,
                                    (double)playerGlobal.Where(x => x.Season == 0 && x.Category == 4).FirstOrDefault().WLr,
                                    (double)playerGlobal.Where(x => x.Season == 0 && x.Category == 4).FirstOrDefault().KpM,
                                    (double)playerGlobal.Where(x => x.Season == 0 && x.Category == 4).FirstOrDefault().DpM);




                if (toPDF)
                    PdfOps.CreatePDFFileFromTxtFile(textFile.FullName, playerName);
                else
                    DataOps.PrintData(rtbData, textFile.FullName);

                /*
                if (new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "chart.png")).Exists)
                    File.Delete(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "chart.png"));
                if (new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "chart2.png")).Exists)
                    File.Delete(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "chart2.png"));
                if (new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "chart3.png")).Exists)
                    File.Delete(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "chart3.png"));
                if (new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "Light.png")).Exists)
                    File.Delete(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "Light.png"));
                if (new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "Medium.png")).Exists)
                    File.Delete(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "Medium.png"));
                if (new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "Heavy.png")).Exists)
                    File.Delete(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "Heavy.png"));
                if (new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "Assault.png")).Exists)
                    File.Delete(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "Assault.png"));
                */

                //Bitmap textImage = GraphOps.CreateBitmapImage(textFile.FullName, toPDF);
                //if (toPDF)
                //    txtImage = textImage;
                //else
                //    pcbStats.Image = textImage;
            }
            catch (Exception exp)
            {

            }
        }

        private void crtAvMS_Click(object sender, EventArgs e)
        {

        }

        public void btnPrintCharts_Click(object sender, EventArgs e)
        {
            try
            {
                string filePDF = PdfOps.CreatePDFFileFromTxtFile(fileText.FullName, plName);
                if(File.Exists(filePDF))
                    if(e != null)
                        System.Diagnostics.Process.Start(filePDF);

                //Bitmap textImage = GraphOps.CreateBitmapImage(txtFile, true);
                //PdfOps pdfOp = new PdfOps();
                //pdfOp.DrawStats(plName, textImage);
            }
            catch(Exception exp)
            {
                Logger.PrintC(exp.Message);
            }
        }

        private void frmShowCharts_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConfigFile.ACTUAL_MAIN.BringToFront();
            Thread.Sleep(150);
            ConfigFile.ACTUAL_MAIN.BringToFront();
        }

        private void crtKDWKr_Click(object sender, EventArgs e)
        {

        }
    }
}
