﻿using System;
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
    public partial class frmGetData : Form
    {
        public frmGetData()
        {
            InitializeComponent();
            //Personalized
            ConfigFile.TOTAL_PAGES = 200;
            for(int i = ConfigFile.SEASON_FIRST; i <= ConfigFile.SEASON_LAST; i++)
            {
                cmbSeasonNumber.Items.Add(i.ToString());
            }
            txtStartGeneral.Enabled = false;
            txtStartAssault.Enabled = false;
            txtStartHeavy.Enabled = false;
            txtStartMedium.Enabled = false;
            txtStartLight.Enabled = false;
            txtEndGeneral.Enabled = false;
            txtEndGeneral.Text = ConfigFile.MAX_PAGES.ToString();
            txtEndAssault.Enabled = false;
            txtEndAssault.Text = ConfigFile.MAX_PAGES.ToString();
            txtEndHeavy.Enabled = false;
            txtEndHeavy.Text = ConfigFile.MAX_PAGES.ToString();
            txtEndMedium.Enabled = false;
            txtEndMedium.Text = ConfigFile.MAX_PAGES.ToString();
            txtEndLight.Enabled = false;
            txtEndLight.Text = ConfigFile.MAX_PAGES.ToString();

            chbFullGeneral.Enabled = false;
            chbFullAssault.Enabled = false;
            chbFullHeavy.Enabled = false;
            chbFullMedium.Enabled = false;
            chbFullLight.Enabled = false;

            prbPageProgressGeneral.Value = 0;
            prbPageProgressLight.Value = 0;
            prbPageProgressMedium.Value = 0;
            prbPageProgressHeavy.Value = 0;
            prbPageProgressAssault.Value = 0;

        }

        /// <summary>
        /// Const equivalent of the "close" button
        /// </summary>
        private const int CP_NOCLOSE_BUTTON = 0x200;
        /// <summary>
        /// Override the parameters of the form, hiding the "close" button
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private void frmGetData_Load(object sender, EventArgs e)
        {
            Logger.PrintC("test: " + e.ToString());
            FileInfo localCredentials = new FileInfo(ConfigFile.LOCAL_CREDENTIALS);
            if (localCredentials.Exists)
            {
                string[] fileCredentials = File.ReadAllLines(localCredentials.FullName);
                if(fileCredentials.Count() == 2)
                {
                    txtEMail.Text = fileCredentials[0];
                    txtPassword.Text = fileCredentials[1];
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chbGeneral_CheckedChanged(object sender, EventArgs e)
        {
            ConfigFile.GENERAL = chbGeneral.Checked;

            if (chbGeneral.Checked)
            {
                if (chbFullGeneral.Checked)
                {
                    txtStartGeneral.Enabled = false;
                    txtEndGeneral.Enabled = false;
                }
                else
                {
                    txtStartGeneral.Enabled = true;
                    txtEndGeneral.Enabled = true;
                }
                chbFullGeneral.Enabled = true;
                prbPageProgressGeneral.Enabled = true;
                prbPageProgressGeneral.Value = 0;
            }
            else
            {
                txtStartGeneral.Enabled = false;
                txtEndGeneral.Enabled = false;
                chbFullGeneral.Enabled = false;
                prbPageProgressGeneral.Enabled = false;
                prbPageProgressGeneral.Value = 0;
            }
            
            RefreshTimerCount(ConfigFile.GENERAL);
        }

        private void chbLight_CheckedChanged(object sender, EventArgs e)
        {
            ConfigFile.LIGHT = chbLight.Checked;
            if (chbLight.Checked)
            {
                if (chbFullLight.Checked)
                {
                    txtStartLight.Enabled = false;
                    txtEndLight.Enabled = false;
                }
                else
                {
                    txtStartLight.Enabled = true;
                    txtEndLight.Enabled = true;
                }
                chbFullLight.Enabled = true;
                prbPageProgressLight.Enabled = true;
                prbPageProgressLight.Value = 0;
            }
            else
            {
                txtStartLight.Enabled = false;
                txtEndLight.Enabled = false;
                chbFullLight.Enabled = false;
                prbPageProgressLight.Enabled = false;
                prbPageProgressLight.Value = 0;
            }
            RefreshTimerCount(ConfigFile.LIGHT);
        }

        private void chbMedium_CheckedChanged(object sender, EventArgs e)
        {
            ConfigFile.MEDIUM = chbMedium.Checked;
            if (chbMedium.Checked)
            {
                if (chbFullMedium.Checked)
                {
                    txtStartMedium.Enabled = false;
                    txtEndMedium.Enabled = false;
                }
                else
                {
                    txtStartMedium.Enabled = true;
                    txtEndMedium.Enabled = true;
                }
                chbFullMedium.Enabled = true;
                prbPageProgressMedium.Enabled = true;
                prbPageProgressMedium.Value = 0;
            }
            else
            {
                txtStartMedium.Enabled = false;
                txtEndMedium.Enabled = false;
                chbFullMedium.Enabled = false;
                prbPageProgressMedium.Enabled = false;
                prbPageProgressMedium.Value = 0;
            }
            RefreshTimerCount(ConfigFile.MEDIUM);
        }

        private void chkHeavy_CheckedChanged(object sender, EventArgs e)
        {
            ConfigFile.HEAVY = chbHeavy.Checked;
            if (chbHeavy.Checked)
            {
                if (chbFullHeavy.Checked)
                {
                    txtStartHeavy.Enabled = false;
                    txtEndHeavy.Enabled = false;
                }
                else
                {
                    txtStartHeavy.Enabled = true;
                    txtEndHeavy.Enabled = true;
                }
                chbFullHeavy.Enabled = true;
                prbPageProgressHeavy.Enabled = true;
                prbPageProgressHeavy.Value = 0;
            }
            else
            {
                txtStartHeavy.Enabled = false;
                txtEndHeavy.Enabled = false;
                chbFullHeavy.Enabled = false;
                prbPageProgressHeavy.Enabled = false;
                prbPageProgressHeavy.Value = 0;
            }
            RefreshTimerCount(ConfigFile.HEAVY);
        }

        private void chkAssault_CheckedChanged(object sender, EventArgs e)
        {
            ConfigFile.ASSAULT = chbAssault.Checked;
            if (chbAssault.Checked)
            {
                if (chbFullAssault.Checked)
                {
                    txtStartAssault.Enabled = false;
                    txtEndAssault.Enabled = false;
                }
                else
                {
                    txtStartAssault.Enabled = true;
                    txtEndAssault.Enabled = true;
                }
                chbFullAssault.Enabled = true;
                prbPageProgressAssault.Enabled = true;
                prbPageProgressAssault.Value = 0;
            }
            else
            {
                txtStartAssault.Enabled = false;
                txtEndAssault.Enabled = false;
                chbFullAssault.Enabled = false;
                prbPageProgressAssault.Enabled = false;
                prbPageProgressAssault.Value = 0;
            }
            RefreshTimerCount(ConfigFile.ASSAULT);
        }

        /// <summary>
        /// RISCRIVERE PER LA MODIFICA ALLE PAGINE DA SCARICARE
        /// </summary>
        /// <param name="stat"></param>
        public void RefreshTimerCount(bool stat)
        {
            double timeMultiplier = 0.025;
            int pagesGeneral = 0;
            int pagesLight = 0;
            int pagesMedium = 0;
            int pagesHeavy = 0;
            int pagesAssault = 0;
            double tempDouble = 0;
            double expected = 0.0;
            double time;
            int check = 0;

            if (chbAssault.Checked)
            {
                if (chbFullAssault.Checked)
                {
                    pagesAssault = (int)ConfigFile.MAX_PAGES - (int)ConfigFile.MIN_PAGES;
                }
                else
                {
                    int temp = 0;
                    int start = int.TryParse(txtStartAssault.Text, out temp) ? temp : ConfigFile.MIN_PAGES;
                    int end = int.TryParse(txtEndAssault.Text, out temp) ? temp : ConfigFile.MAX_PAGES;
                    pagesAssault = end - start;
                }
                check++;
            }

            if (chbHeavy.Checked)
            {
                if (chbFullHeavy.Checked)
                {
                    pagesHeavy = (int)ConfigFile.MAX_PAGES - (int)ConfigFile.MIN_PAGES;
                }
                else
                {
                    int temp = 0;
                    int start = int.TryParse(txtStartHeavy.Text, out temp) ? temp : ConfigFile.MIN_PAGES;
                    int end = int.TryParse(txtEndHeavy.Text, out temp) ? temp : ConfigFile.MAX_PAGES;
                    pagesHeavy = end - start;
                }
                check++;
            }
            if (chbMedium.Checked)
            {
                if (chbFullMedium.Checked)
                {
                    pagesMedium = (int)ConfigFile.MAX_PAGES - (int)ConfigFile.MIN_PAGES;
                }
                else
                {
                    int temp = 0;
                    int start = int.TryParse(txtStartMedium.Text, out temp) ? temp : ConfigFile.MIN_PAGES;
                    int end = int.TryParse(txtEndMedium.Text, out temp) ? temp : ConfigFile.MAX_PAGES;
                    pagesMedium = end - start;
                }
                check++;
            }
            if (chbLight.Checked)
            {
                if (chbFullLight.Checked)
                {
                    pagesLight = (int)ConfigFile.MAX_PAGES - (int)ConfigFile.MIN_PAGES;
                }
                else
                {
                    int temp = 0;
                    int start = int.TryParse(txtStartLight.Text, out temp) ? temp : ConfigFile.MIN_PAGES;
                    int end = int.TryParse(txtEndLight.Text, out temp) ? temp : ConfigFile.MAX_PAGES;
                    pagesLight = end - start;
                }
                check++;
            }
            if (chbGeneral.Checked)
            {
                if (chbFullGeneral.Checked)
                {
                    pagesGeneral = (int)ConfigFile.MAX_PAGES - (int)ConfigFile.MIN_PAGES;
                }
                else
                {
                    int temp = 0;
                    int start = int.TryParse(txtStartGeneral.Text, out temp) ? temp : ConfigFile.MIN_PAGES;
                    int end = int.TryParse(txtEndGeneral.Text, out temp) ? temp : ConfigFile.MAX_PAGES;
                    pagesGeneral = end - start;
                }
                check++;
            }

            int greatest = Math.Max(Math.Max(Math.Max(Math.Max(pagesLight, pagesMedium), pagesHeavy), pagesAssault),pagesGeneral)+1;
            double greatestTime = (greatest * (1 + (timeMultiplier * (check > 1 ? check : 0.0)))) * ConfigFile.TIME_PAGE;
            TimeSpan final = new TimeSpan((long)greatestTime * 10000);
            expected = greatest * ConfigFile.TIME_PAGE;
            lblTimer.Text = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                                    final.Hours,
                                    final.Minutes,
                                    final.Seconds,
                                    final.Milliseconds);
        }

        private void CheckPage(TextBox sender)
        {
            int tempValue;
            int value = int.TryParse(sender.Text, out tempValue) ? tempValue : -666;
            if(value != -666)
            {
                if(value < ConfigFile.MIN_PAGES)
                {
                    sender.BackColor = Color.Red;
                    MessageBox.Show("Page Value cannot be negative.", "Input pages Error", MessageBoxButtons.OK);
                    return;
                }
                if(value > ConfigFile.MAX_PAGES)
                {
                    sender.BackColor = Color.Red;
                    MessageBox.Show("Page Value exceed the maximum allowed: " + ConfigFile.MAX_PAGES, "Input pages Error", MessageBoxButtons.OK);
                    return;
                }
                sender.BackColor = Color.FromArgb(224, 224, 224);
            }
            else
            {
                sender.BackColor = Color.Red;
                MessageBox.Show("Value must be an integer number.", "Input pages Error", MessageBoxButtons.OK);
                return;
            }
            RefreshTimerCount(true);
        }
        
        /*
        private void CheckPages()
        {
            int tempInt = 0;
            int start = int.TryParse(txtStartPage.Text, out tempInt) ? tempInt : -666;
            int end = int.TryParse(txtEndPage.Text, out tempInt) ? tempInt : -666;
            if (start == -666)
            {
                txtStartPage.BackColor = Color.Red;
                txtEndPage.BackColor = Color.Red;
                MessageBox.Show("Start Page Not Correct.", "Input pages Error", MessageBoxButtons.OK);
                ConfigFile.TOTAL_PAGES = 0;
                return;
            }
            if (end == -666)
            {
                txtStartPage.BackColor = Color.Red;
                txtEndPage.BackColor = Color.Red;
                MessageBox.Show("End Page Not Correct.", "Input pages Error", MessageBoxButtons.OK);
                ConfigFile.TOTAL_PAGES = 0;
                return;
            }
            if (start < 0)
            {
                txtStartPage.BackColor = Color.Red;
                ConfigFile.TOTAL_PAGES = 0;
                MessageBox.Show("Start Page cannot be negative.", "Input pages Error", MessageBoxButtons.OK);
                return;
            }
            if (end < 0)
            {
                txtEndPage.BackColor = Color.Red;
                ConfigFile.TOTAL_PAGES = 0;
                MessageBox.Show("End Page cannot be negative.", "Input pages Error", MessageBoxButtons.OK);
                return;
            }
            ConfigFile.TOTAL_PAGES = end - start + 1;
            if (ConfigFile.TOTAL_PAGES > ConfigFile.MAX_PAGES)
            {
                txtStartPage.BackColor = Color.Red;
                txtEndPage.BackColor = Color.Red;
                ConfigFile.TOTAL_PAGES = 0;
                MessageBox.Show("Page limit exedeed.", "Input pages Error", MessageBoxButtons.OK);
                return;
            }
            if (ConfigFile.TOTAL_PAGES < 1)
            {
                txtStartPage.BackColor = Color.Red;
                txtEndPage.BackColor = Color.Red;
                ConfigFile.TOTAL_PAGES = 0;
                MessageBox.Show("You cannot download less then 1 page", "Input pages Error", MessageBoxButtons.OK);
                return;
            }
            txtStartPage.BackColor = Color.FromArgb(224, 224, 224);
            txtEndPage.BackColor = Color.FromArgb(224, 224, 224);
        }
        */


        private void chbFullGeneral_CheckedChanged(object sender, EventArgs e)
        {
            txtStartGeneral.Enabled = !chbFullGeneral.Checked;
            txtEndGeneral.Enabled = !chbFullGeneral.Checked;
            RefreshTimerCount(true);
        }

        private void chbFullLight_CheckedChanged(object sender, EventArgs e)
        {
            txtStartLight.Enabled = !chbFullLight.Checked;
            txtEndLight.Enabled = !chbFullLight.Checked;
            RefreshTimerCount(true);
        }

        private void chbFullMedium_CheckedChanged(object sender, EventArgs e)
        {
            txtStartMedium.Enabled = !chbFullMedium.Checked;
            txtEndMedium.Enabled = !chbFullMedium.Checked;
            RefreshTimerCount(true);
        }

        private void chbFullHeavy_CheckedChanged(object sender, EventArgs e)
        {
            txtStartHeavy.Enabled = !chbFullHeavy.Checked;
            txtEndHeavy.Enabled = !chbFullHeavy.Checked;
            RefreshTimerCount(true);
        }

        private void chbFullAssault_CheckedChanged(object sender, EventArgs e)
        {
            txtStartAssault.Enabled = !chbFullAssault.Checked;
            txtEndAssault.Enabled = !chbFullAssault.Checked;
            RefreshTimerCount(true);
        }
        
        private void txtGENERIC_Leave(object sender, EventArgs e)
        {
            CheckPage(sender as TextBox);
        }

        private void panel1_Leave(object sender, EventArgs e)
        {
            int tempInt;
            int startGeneral, endGeneral, totalGeneral;
            int startLight, endLight, totalLight;
            int startMedium, endMedium, totalMedium;
            int startHeavy, endHeavy, totalHeavy;
            int startAssault, endAssault, totalAssault;
            string errors = null;
            if (chbGeneral.Checked && chbFullGeneral.Checked == false)
            {
                startGeneral = int.TryParse(txtStartGeneral.Text, out tempInt) ? tempInt : -666;
                endGeneral = int.TryParse(txtEndGeneral.Text, out tempInt) ? tempInt : -666;
                totalGeneral = endGeneral - startGeneral;
                if (totalGeneral < 0 || totalGeneral > ConfigFile.MAX_PAGES)
                {
                    txtStartGeneral.BackColor = Color.Red;
                    txtEndGeneral.BackColor = Color.Red;
                    if (totalGeneral < 0)
                        errors += "\n- GENERAL pages values are incorrect.";
                    if (totalGeneral > ConfigFile.MAX_PAGES)
                        errors += "\n- GENERAL pages values totals over the maximum allowed: " + ConfigFile.MAX_PAGES;
                }
            }
            if (chbAssault.Checked && chbFullAssault.Checked == false)
            {
                startAssault = int.TryParse(txtStartAssault.Text, out tempInt) ? tempInt : -666;
                endAssault = int.TryParse(txtEndAssault.Text, out tempInt) ? tempInt : -666;
                totalAssault = endAssault - startAssault;
                if (totalAssault < 0 || totalAssault > ConfigFile.MAX_PAGES)
                {
                    txtStartAssault.BackColor = Color.Red;
                    txtEndAssault.BackColor = Color.Red;
                    if (totalAssault < 0)
                        errors += "\n- ASSAULT pages values are incorrect.";
                    if (totalAssault > ConfigFile.MAX_PAGES)
                        errors += "\n- ASSAULT pages values totals over the maximum allowed: " + ConfigFile.MAX_PAGES;
                }
            }
            if (chbHeavy.Checked && chbFullHeavy.Checked == false)
            {
                startHeavy = int.TryParse(txtStartHeavy.Text, out tempInt) ? tempInt : -666;
                endHeavy = int.TryParse(txtEndHeavy.Text, out tempInt) ? tempInt : -666;
                totalHeavy = endHeavy - startHeavy;
                if (totalHeavy < 0 || totalHeavy > ConfigFile.MAX_PAGES)
                {
                    txtStartHeavy.BackColor = Color.Red;
                    txtEndHeavy.BackColor = Color.Red;
                    if (totalHeavy < 0)
                        errors += "\n- HEAVY pages values are incorrect.";
                    if (totalHeavy > ConfigFile.MAX_PAGES)
                        errors += "\n- HEAVY pages values totals over the maximum allowed: " + ConfigFile.MAX_PAGES;
                }
            }
            if (chbMedium.Checked && chbFullMedium.Checked == false)
            {
                startMedium = int.TryParse(txtStartMedium.Text, out tempInt) ? tempInt : -666;
                endMedium = int.TryParse(txtEndMedium.Text, out tempInt) ? tempInt : -666;
                totalMedium = endMedium - startMedium;
                if (totalMedium < 0 || totalMedium > ConfigFile.MAX_PAGES)
                {
                    txtStartMedium.BackColor = Color.Red;
                    txtEndMedium.BackColor = Color.Red;
                    if (totalMedium < 0)
                        errors += "\n- MEDIUM pages values are incorrect.";
                    if (totalMedium > ConfigFile.MAX_PAGES)
                        errors += "\n- MEDIUM pages values totals over the maximum allowed: " + ConfigFile.MAX_PAGES;
                }
            }
            if (chbLight.Checked && chbFullLight.Checked == false)
            {
                startLight = int.TryParse(txtStartLight.Text, out tempInt) ? tempInt : -666;
                endLight = int.TryParse(txtEndLight.Text, out tempInt) ? tempInt : -666;
                totalLight = endLight - startLight;
                if (totalLight < 0 || totalLight > ConfigFile.MAX_PAGES)
                {
                    txtStartLight.BackColor = Color.Red;
                    txtEndLight.BackColor = Color.Red;
                    if (totalLight < 0)
                        errors += "\n- LIGHT pages values are incorrect.";
                    if (totalLight > ConfigFile.MAX_PAGES)
                        errors += "\n- LIGHT pages values totals over the maximum allowed: " + ConfigFile.MAX_PAGES;
                }
            }
            if(errors != null)
                MessageBox.Show(errors, "General 'page values' errors.", MessageBoxButtons.OK);
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            ConfigFile.ACTUAL_MAIN.Show();
            this.Hide();
        }

        private void txtGeneral_MouseCaptureChanged(object sender, EventArgs e)
        {
            (sender as TextBox).SelectAll();
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            string email = txtEMail.Text;
            string password = txtPassword.Text;

            
            //Task<int> response = await WebOps.CheckCredentials(email, password);
            int response = await WebOps.CheckCredentials(email, password);

            switch (response)
            {
                case 1:
                    MessageBox.Show("You must enter an email.", "MWO Credential Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;
                case 2:
                    MessageBox.Show("You must enter a password.", "MWO Credential Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;
                case 3:
                    MessageBox.Show("Your MWO Credentials are invalid." + Environment.NewLine + "Check your eMail and Password and try again.", "MWO Credential Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;
                case 4:
                    break;
                case 5:
                    MessageBox.Show("There has been an error while trying to connect." + Environment.NewLine + "Check your connection and try again.", "MWO Credential Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;
            }

            int tempInt = 0;
            int season = int.TryParse(cmbSeasonNumber.Text, out tempInt) ? tempInt : ConfigFile.SEASON_LAST;
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                if (string.IsNullOrWhiteSpace(email))
                    Mex.AddMessage("Email field is not valid.", Mex.ERROR);
                if (string.IsNullOrWhiteSpace(password))
                    Mex.AddMessage("Password field is not valid.", Mex.ERROR);
                Mex.AddMessage("Will not proceed.", Mex.WARNING);
                Mex.PrintErrorMessagesInForm();
                Mex.RemoveAll();
                return;
            }

            // saves email & password to a local file
            if (ckbSaveCredentials.Checked)
            {
                if (!new FileInfo(ConfigFile.LOCAL_CREDENTIALS).Exists)
                {
                    File.WriteAllLines(ConfigFile.LOCAL_CREDENTIALS, new string[] { email, password });
                }
                else
                {
                    try
                    {
                        File.Delete(ConfigFile.LOCAL_CREDENTIALS);
                    }
                    catch
                    {

                    }
                    File.WriteAllLines(ConfigFile.LOCAL_CREDENTIALS, new string[] { email, password });
                }
            }

            DownloadData baseData = new DownloadData(user: email,
                                                     password: password,
                                                     season: season);
            if (chbGeneral.Checked)
            {
                int startGeneral;
                int endGeneral;
                if (chbFullGeneral.Checked)
                {
                    startGeneral = (int)ConfigFile.MIN_PAGES - 1;
                    endGeneral = ConfigFile.MAX_PAGES;
                }
                else
                {
                    startGeneral = int.TryParse(txtStartGeneral.Text, out tempInt) ? tempInt-1 : (int)ConfigFile.MIN_PAGES;
                    endGeneral = int.TryParse(txtEndGeneral.Text, out tempInt) ? tempInt-1 : ConfigFile.MAX_PAGES;
                }
                WebOps.LoginAndDownload(dData: baseData, type: 0, startPage: startGeneral, finishPage: endGeneral, bar: prbPageProgressGeneral, writeDB: true);
            }
            if (chbLight.Checked)
            {
                int startLight;
                int endLight;
                if (chbFullLight.Checked)
                {
                    startLight = (int)ConfigFile.MIN_PAGES - 1;
                    endLight = ConfigFile.MAX_PAGES;
                }
                else
                {
                    startLight = int.TryParse(txtStartLight.Text, out tempInt) ? tempInt -1: (int)ConfigFile.MIN_PAGES;
                    endLight = int.TryParse(txtEndLight.Text, out tempInt) ? tempInt-1 : ConfigFile.MAX_PAGES;
                }
                WebOps.LoginAndDownload(dData: baseData, type: 1, startPage: startLight, finishPage: endLight, bar: prbPageProgressLight);
            }
            if (chbMedium.Checked)
            {
                int startMedium;
                int endMedium;
                if (chbFullMedium.Checked)
                {
                    startMedium = (int)ConfigFile.MIN_PAGES - 1;
                    endMedium = ConfigFile.MAX_PAGES;
                }
                else
                {
                    startMedium = int.TryParse(txtStartMedium.Text, out tempInt) ? tempInt -1: (int)ConfigFile.MIN_PAGES;
                    endMedium = int.TryParse(txtEndMedium.Text, out tempInt) ? tempInt-1 : ConfigFile.MAX_PAGES;
                }
                WebOps.LoginAndDownload(dData: baseData, type: 2, startPage: startMedium, finishPage: endMedium, bar: prbPageProgressMedium);
            }
            if (chbHeavy.Checked)
            {
                int startHeavy;
                int endHeavy;
                if (chbFullHeavy.Checked)
                {
                    startHeavy = (int)ConfigFile.MIN_PAGES - 1;
                    endHeavy = ConfigFile.MAX_PAGES;
                }
                else
                {
                    startHeavy = int.TryParse(txtStartHeavy.Text, out tempInt) ? tempInt -1: (int)ConfigFile.MIN_PAGES;
                    endHeavy = int.TryParse(txtEndHeavy.Text, out tempInt) ? tempInt-1 : ConfigFile.MAX_PAGES;
                }
                WebOps.LoginAndDownload(dData: baseData, type: 3, startPage: startHeavy, finishPage: endHeavy, bar: prbPageProgressHeavy);
            }
            if (chbAssault.Checked)
            {
                int startAssault;
                int endAssault;
                if (chbFullAssault.Checked)
                {
                    startAssault = (int)ConfigFile.MIN_PAGES - 1;
                    endAssault = ConfigFile.MAX_PAGES;
                }
                else
                {
                    startAssault = int.TryParse(txtStartAssault.Text, out tempInt) ? tempInt -1: (int)ConfigFile.MIN_PAGES;
                    endAssault = int.TryParse(txtEndAssault.Text, out tempInt) ? tempInt-1 : ConfigFile.MAX_PAGES;
                }
                WebOps.LoginAndDownload(dData: baseData, type: 4, startPage: startAssault, finishPage: endAssault, bar: prbPageProgressAssault);
            }
        }

        private void frmGetData_VisibleChanged(object sender, EventArgs e)
        {
            cmbSeasonNumber.Items.Clear();
            for (int i = ConfigFile.SEASON_FIRST; i <= ConfigFile.SEASON_LAST; i++)
            {
                cmbSeasonNumber.Items.Add(i.ToString());
            }
            RefreshTimerCount(true);
        }

        private void prbPageProgress_Click(object sender, EventArgs e)
        {

        }

        private void lblTimer_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
