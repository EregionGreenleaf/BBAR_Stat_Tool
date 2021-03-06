﻿using System;
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
using System.Data.SqlClient;
using System.IO;

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

        public string lblActiveTasksText
        {
            get
            {
                return this.lblActiveTasks.Text.Replace("Active Tasks: ", string.Empty);
            }
            set
            {
                this.lblActiveTasks.Text = "Active Tasks: " + value.ToString();
            }
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
                oldGetData.Visible = true;
            }
            //this.Opacity = 50;
            this.Hide();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.BringToFront();
            lblElaborating.Text = "Not elaborating.";
            lblElaborating.ForeColor = Color.Green;
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Select the folder in which to OUTPUT elaborated data." + Environment.NewLine +
                    "Press 'CANCEL' if you want to use default directory (as determined in the config file).";
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    ConfigFile.DIRECTORY_OUTPUT = new DirectoryInfo(fbd.SelectedPath);
                    //string[] files = Directory.GetFiles(fbd.SelectedPath);

                    //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }

            this.BringToFront();

            prbSinglePlayer.Enabled = false;
            prbSinglePlayer.Maximum = ConfigFile.SEASON_LAST;
            prbSinglePlayer.Value = 0;
            lblLastSeason.Text = "Last Season: " + ConfigFile.SEASON_LAST;
            this.BringToFront();
        }

        private async void btnTest_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            await GeneralOps.RefreshDownloadTime();
            this.Enabled = true;
        }

        private async void btnTest2_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            ConfigFile.IncrementTaskStarted();
            string playerName = string.Empty; //Interaction.InputBox("Insert Player Name to download:", "Download all data of Player", "PlayerName", -1, -1);


            frmInputBoxX input = new frmInputBoxX();
            DialogResult result = input.ShowDialog();
            if (result == DialogResult.OK)
            {
                playerName = string.IsNullOrWhiteSpace(ConfigFile.ACTUAL_PLAYER) ? null : ConfigFile.ACTUAL_PLAYER;
            }

            if (!string.IsNullOrWhiteSpace(playerName))
            {
                playerName = playerName.Trim();
                if (!string.IsNullOrWhiteSpace(playerName))
                {
                    ConfigFile._Global = new Semaphore(1, 1);
                    List<int> typeList = new List<int> { 0, 1, 2, 3, 4 };
                    List<int> seasonsList = new List<int>();
                    for (int i = 1; i <= ConfigFile.SEASON_LAST; i++)
                        seasonsList.Add(i);

                    ConfigFile.GLOBAL_PLAYER = new List<PlayerStatT>();

                    List<int> actualSeason = new List<int> { 1 };
                    List<int> actualType = new List<int> { 1 };

                    //await WebOps.SearchPlayer(playerName, new List<int> { 1 }, new List<int> { 0 }, ConfigFile.DEFAULT_USER, ConfigFile.DEFAULT_PASS);

                    prbSinglePlayer.Maximum = 5;
                    prbSinglePlayer.Enabled = true;
                    prbSinglePlayer.Value = 0;

                    int[] typeArray = typeList.ToArray();
                    int[] seasonArray = actualSeason.ToArray();
                    for (int typeCat = 0; typeCat <= 4; typeCat++)
                    {
                        await Task.WhenAll(seasonsList.Select(i => WebOps.SearchPlayer(playerName, new List<int> { i }, new List<int> { typeCat }, ConfigFile.DEFAULT_USER, ConfigFile.DEFAULT_PASS)).ToArray());
                        prbSinglePlayer.Value = typeCat + 1;
                    }
                    // Code 00
                    ConfigFile.GLOBAL_PLAYER = DataOps.AddAbsoluteSeason(ConfigFile.GLOBAL_PLAYER, playerName);
                    ConfigFile.GLOBAL_PLAYER = DataOps.PopulateKDpM(ConfigFile.GLOBAL_PLAYER);
                    FileInfo textFile = DataOps.PlayerDataToFile(ConfigFile.GLOBAL_PLAYER);
                    frmShowCharts newChart = new frmShowCharts();
                    newChart.Elaborate(ConfigFile.GLOBAL_PLAYER, playerName, textFile);
                    newChart.Visible = true;
                }
                ConfigFile.IncrementTaskFinished();
            }
            this.Enabled = true;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            int lastRecorded = ConfigFile.SEASON_LAST;
            await WebOps.FindLastSeason();
            lblLastSeason.Text = "Last Season: " + ConfigFile.SEASON_LAST.ToString();
            lblLastSeason.ForeColor = Color.Green;
            if (lastRecorded != ConfigFile.SEASON_LAST)
                MessageBox.Show("New Last Season found: " + ConfigFile.SEASON_LAST, 
                    "Search for last Season available", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information, 
                    MessageBoxDefaultButton.Button1);
            else
                MessageBox.Show("No new Seasons founded." + Environment.NewLine + 
                    "Last available Season remains : " + ConfigFile.SEASON_LAST, 
                    "Search for last Season available", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information, 
                    MessageBoxDefaultButton.Button1);
            if (ConfigFile.LAST_SEASON_CHECKED)
            {
                //Mex.AddMessage("Last Season found: " + ConfigFile.SEASON_LAST, Mex.INFO);
                //Mex.PrintMessageInForm(Mex.FormatMessageAtIndex());
                Mex.RemoveAll();
            }
            this.Enabled = true;
        }

        private void lblCopyright_Click(object sender, EventArgs e)
        {

        }

        private void btnSQL_Click(object sender, EventArgs e)
        {
            List<FileInfo> list = new List<FileInfo>
            {
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S01_GENERAL.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S01_LIGHT.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S01_MEDIUM.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S01_HEAVY.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S01_ASSAULT.txt").ToString()),

                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S02_GENERAL.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S02_LIGHT.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S02_MEDIUM.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S02_HEAVY.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S02_ASSAULT.txt").ToString()),

                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S03_GENERAL.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S03_LIGHT.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S03_MEDIUM.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S03_HEAVY.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S03_ASSAULT.txt").ToString()),

                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S04_GENERAL.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S04_LIGHT.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S04_MEDIUM.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S04_HEAVY.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S04_ASSAULT.txt").ToString()),

                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S05_GENERAL.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S05_LIGHT.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S05_MEDIUM.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S05_HEAVY.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S05_ASSAULT.txt").ToString()),

                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S06_GENERAL.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S06_LIGHT.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S06_MEDIUM.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S06_HEAVY.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S06_ASSAULT.txt").ToString()),

                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S07_GENERAL.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S07_LIGHT.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S07_MEDIUM.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S07_HEAVY.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S07_ASSAULT.txt").ToString()),

                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S08_GENERAL.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S08_LIGHT.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S08_MEDIUM.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S08_HEAVY.txt").ToString()),
                new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "S08_ASSAULT.txt").ToString())
            };

            int season = 1;
            int type = 0;
            foreach(FileInfo actualFile in list)
            {
                if (type == 5)
                {
                    type = 0;
                    season++;
                }
                DataOps.WriteToDB(actualFile, season, type);
                type++;

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // gray out this form
            this.Enabled = false;
            // increments active tasks
            ConfigFile.IncrementTaskStarted();
            // asks for the "player name" to the user
            string playerName = Interaction.InputBox("Insert Player Name to download:", "Download all data of Player", "PlayerName", -1, -1);
            lblElaborating.Text = "Retriving data...";
            lblElaborating.ForeColor = Color.Green;
            // opens a "waiting to complete" form
            //frmWaiting waiting = new frmWaiting("Retriving data from remote DB...");
            //waiting.lblInformation.Text = "Retriving data from remote DB...";
            //waiting.Enabled = true;
            //waiting.Show();
            //waiting.BringToFront();

            playerName = playerName.Trim();
            if (!string.IsNullOrWhiteSpace(playerName))
            {
                List<PlayerStatT> player = SqlOps.RetrievePlayerStat(playerName);
                lblElaborating.Text = "Elaborating data...";
                lblElaborating.ForeColor = Color.Red;
                //waiting.lblInformation.Text = "Elaborating data...";
                if (player.Count > 0)
                {
                    player = DataOps.AddAbsoluteSeason(player, playerName);
                    player = DataOps.PopulateKDpM(player);
                    FileInfo textFile = DataOps.PlayerDataToFile(player);
                    frmShowCharts newChart = new frmShowCharts();
                    newChart.Elaborate(player, playerName, textFile);
                    //waiting.Dispose();
                    newChart.Visible = true;
                }
                else
                {
                    //waiting.Dispose();
                    MessageBox.Show("Player not found.", "Search Player in DB: WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    this.BringToFront();
                }
            }
            this.BringToFront();
            ConfigFile.IncrementTaskFinished();
            //waiting.Dispose();
            lblElaborating.Text = "Not elaborating.";
            lblElaborating.ForeColor = Color.Green;
            this.BringToFront();
            this.Enabled = true;
        }

        private void lblLastSeason_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            frmGetDataSingle getList = new frmGetDataSingle();
            DialogResult result = getList.ShowDialog();
            if (result == DialogResult.OK)
            {
                if(ConfigFile.ACTUAL_PLAYER_LIST.Count > 0)
                {
                    prbPlayerList.Maximum = 5*ConfigFile.ACTUAL_PLAYER_LIST.Count;
                    prbPlayerList.Enabled = true;
                    prbPlayerList.Value = 0;
                    ConfigFile.IncrementTaskStarted();

                    foreach (string playerName in ConfigFile.ACTUAL_PLAYER_LIST)
                    {
                        if (!string.IsNullOrWhiteSpace(playerName.Trim()))
                        {
                            ConfigFile._Global = new Semaphore(1, 1);
                            List<int> typeList = new List<int> { 0, 1, 2, 3, 4 };
                            List<int> seasonsList = new List<int>();
                            for (int i = 1; i <= ConfigFile.SEASON_LAST; i++)
                                seasonsList.Add(i);

                            ConfigFile.GLOBAL_PLAYER = new List<PlayerStatT>();

                            List<int> actualSeason = new List<int> { 1 };
                            List<int> actualType = new List<int> { 1 };

                            //await WebOps.SearchPlayer(playerName, new List<int> { 1 }, new List<int> { 0 }, ConfigFile.DEFAULT_USER, ConfigFile.DEFAULT_PASS);


                            int[] typeArray = typeList.ToArray();
                            int[] seasonArray = actualSeason.ToArray();
                            for (int typeCat = 0; typeCat <= 4; typeCat++)
                            {
                                await Task.WhenAll(seasonsList.Select(i => WebOps.SearchPlayer(playerName.Trim(), new List<int> { i }, new List<int> { typeCat }, ConfigFile.DEFAULT_USER, ConfigFile.DEFAULT_PASS)).ToArray());
                                prbPlayerList.Value = prbPlayerList.Value + 1;
                            }
                            // Code 00
                            ConfigFile.GLOBAL_PLAYER = DataOps.AddAbsoluteSeason(ConfigFile.GLOBAL_PLAYER, playerName.Trim());
                            ConfigFile.GLOBAL_PLAYER = DataOps.PopulateKDpM(ConfigFile.GLOBAL_PLAYER);
                            FileInfo textFile = DataOps.PlayerDataToFile(ConfigFile.GLOBAL_PLAYER);
                            frmShowCharts newChart = new frmShowCharts();
                            newChart.Elaborate(ConfigFile.GLOBAL_PLAYER, playerName, textFile);
                            newChart.btnPrintCharts_Click(this, null);
                            //newChart.Visible = true;
                        }
                        else
                        {
                            prbPlayerList.Value = prbPlayerList.Value + 5;
                        }

                    }

                    ConfigFile.IncrementTaskFinished();
                    MessageBox.Show("Finished elaborating stats and printing relative PDFs for " + ConfigFile.ACTUAL_PLAYER_LIST.Count() + " players.", "Stats Elaboration", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("No Player Names inserted." + Environment.NewLine + "No data will be elaborated.", "Stats Elaboration", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show("No Player Names inserted." + Environment.NewLine + "No data will be elaborated.", "Stats Elaboration", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }

            //this.Enabled = false;
            //ConfigFile.IncrementTaskStarted();
            //string playerName = Interaction.InputBox("Insert Player Name to download:", "Download all data of Player", "PlayerName", -1, -1);
            //playerName = playerName.Trim();
            //if (!string.IsNullOrWhiteSpace(playerName))
            //{
            //    ConfigFile._Global = new Semaphore(1, 1);
            //    List<int> typeList = new List<int> { 0, 1, 2, 3, 4 };
            //    List<int> seasonsList = new List<int>();
            //    for (int i = 1; i <= ConfigFile.SEASON_LAST; i++)
            //        seasonsList.Add(i);

            //    ConfigFile.GLOBAL_PLAYER = new List<PlayerStatT>();

            //    List<int> actualSeason = new List<int> { 1 };
            //    List<int> actualType = new List<int> { 1 };

            //    //await WebOps.SearchPlayer(playerName, new List<int> { 1 }, new List<int> { 0 }, ConfigFile.DEFAULT_USER, ConfigFile.DEFAULT_PASS);

            //    prbSinglePlayer.Maximum = 5;
            //    prbSinglePlayer.Enabled = true;
            //    prbSinglePlayer.Value = 0;

            //    int[] typeArray = typeList.ToArray();
            //    int[] seasonArray = actualSeason.ToArray();
            //    for (int typeCat = 0; typeCat <= 4; typeCat++)
            //    {
            //        await Task.WhenAll(seasonsList.Select(i => WebOps.SearchPlayer(playerName, new List<int> { i }, new List<int> { typeCat }, ConfigFile.DEFAULT_USER, ConfigFile.DEFAULT_PASS)).ToArray());
            //        prbSinglePlayer.Value = typeCat + 1;
            //    }
            //    // Code 00
            //    ConfigFile.GLOBAL_PLAYER = DataOps.AddAbsoluteSeason(ConfigFile.GLOBAL_PLAYER, playerName);
            //    ConfigFile.GLOBAL_PLAYER = DataOps.PopulateKDpM(ConfigFile.GLOBAL_PLAYER);
            //    FileInfo textFile = DataOps.PlayerDataToFile(ConfigFile.GLOBAL_PLAYER);
            //    frmShowCharts newChart = new frmShowCharts();
            //    newChart.Elaborate(ConfigFile.GLOBAL_PLAYER, playerName, textFile);
            //    newChart.Visible = true;
            //}
            //ConfigFile.IncrementTaskFinished();
            //this.Enabled = true;

        }
    }
}
