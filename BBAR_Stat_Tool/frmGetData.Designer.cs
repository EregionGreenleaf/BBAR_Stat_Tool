namespace BBAR_Stat_Tool
{
    partial class frmGetData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            //if (disposing && (components != null))
            //{
            //    components.Dispose();
            //}
            //base.Dispose(disposing);
            this.Hide();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGetData));
            this.cmbSeasonNumber = new System.Windows.Forms.ComboBox();
            this.lblSeason = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.chbAssault = new System.Windows.Forms.CheckBox();
            this.chbHeavy = new System.Windows.Forms.CheckBox();
            this.chbMedium = new System.Windows.Forms.CheckBox();
            this.chbLight = new System.Windows.Forms.CheckBox();
            this.lblTypeDescription = new System.Windows.Forms.Label();
            this.chbGeneral = new System.Windows.Forms.CheckBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtEMail = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEndPage = new System.Windows.Forms.TextBox();
            this.txtStartPage = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtStartGeneral = new System.Windows.Forms.TextBox();
            this.txtStartLight = new System.Windows.Forms.TextBox();
            this.txtStartMedium = new System.Windows.Forms.TextBox();
            this.txtStartHeavy = new System.Windows.Forms.TextBox();
            this.txtStartAssault = new System.Windows.Forms.TextBox();
            this.txtEndGeneral = new System.Windows.Forms.TextBox();
            this.txtEndLight = new System.Windows.Forms.TextBox();
            this.txtEndMedium = new System.Windows.Forms.TextBox();
            this.txtEndHeavy = new System.Windows.Forms.TextBox();
            this.txtEndAssault = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chbFullGeneral = new System.Windows.Forms.CheckBox();
            this.chbFullLight = new System.Windows.Forms.CheckBox();
            this.chbFullMedium = new System.Windows.Forms.CheckBox();
            this.chbFullHeavy = new System.Windows.Forms.CheckBox();
            this.chbFullAssault = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbSeasonNumber
            // 
            this.cmbSeasonNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmbSeasonNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSeasonNumber.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbSeasonNumber.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSeasonNumber.FormattingEnabled = true;
            this.cmbSeasonNumber.Location = new System.Drawing.Point(170, 52);
            this.cmbSeasonNumber.Name = "cmbSeasonNumber";
            this.cmbSeasonNumber.Size = new System.Drawing.Size(39, 26);
            this.cmbSeasonNumber.TabIndex = 0;
            this.cmbSeasonNumber.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblSeason
            // 
            this.lblSeason.AutoSize = true;
            this.lblSeason.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeason.Location = new System.Drawing.Point(12, 54);
            this.lblSeason.Name = "lblSeason";
            this.lblSeason.Size = new System.Drawing.Size(152, 21);
            this.lblSeason.TabIndex = 1;
            this.lblSeason.Text = "Season to download";
            this.lblSeason.Click += new System.EventHandler(this.label1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(368, 94);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(149, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.chbFullAssault);
            this.panel1.Controls.Add(this.chbFullHeavy);
            this.panel1.Controls.Add(this.chbFullMedium);
            this.panel1.Controls.Add(this.chbFullLight);
            this.panel1.Controls.Add(this.chbFullGeneral);
            this.panel1.Controls.Add(this.txtEndAssault);
            this.panel1.Controls.Add(this.txtEndHeavy);
            this.panel1.Controls.Add(this.txtEndMedium);
            this.panel1.Controls.Add(this.txtEndLight);
            this.panel1.Controls.Add(this.txtEndGeneral);
            this.panel1.Controls.Add(this.txtStartAssault);
            this.panel1.Controls.Add(this.txtStartHeavy);
            this.panel1.Controls.Add(this.txtStartMedium);
            this.panel1.Controls.Add(this.txtStartLight);
            this.panel1.Controls.Add(this.txtStartGeneral);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.lblTimer);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.chbAssault);
            this.panel1.Controls.Add(this.chbHeavy);
            this.panel1.Controls.Add(this.chbMedium);
            this.panel1.Controls.Add(this.chbLight);
            this.panel1.Controls.Add(this.lblTypeDescription);
            this.panel1.Controls.Add(this.chbGeneral);
            this.panel1.Location = new System.Drawing.Point(16, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 231);
            this.panel1.TabIndex = 3;
            this.panel1.Leave += new System.EventHandler(this.panel1_Leave);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.Location = new System.Drawing.Point(156, 210);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(25, 17);
            this.lblTimer.TabIndex = 7;
            this.lblTimer.Text = "0 h";
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTimer.Click += new System.EventHandler(this.lblTimer_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(0, 210);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(165, 17);
            this.lblTime.TabIndex = 6;
            this.lblTime.Text = "Approximate time to finish: ";
            // 
            // chbAssault
            // 
            this.chbAssault.AutoSize = true;
            this.chbAssault.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbAssault.Location = new System.Drawing.Point(3, 177);
            this.chbAssault.Name = "chbAssault";
            this.chbAssault.Size = new System.Drawing.Size(77, 22);
            this.chbAssault.TabIndex = 5;
            this.chbAssault.Text = "Assaults";
            this.toolTip1.SetToolTip(this.chbAssault, "Select to download the Assault Leaderboard for the selected Season");
            this.chbAssault.UseVisualStyleBackColor = true;
            this.chbAssault.CheckedChanged += new System.EventHandler(this.chkAssault_CheckedChanged);
            // 
            // chbHeavy
            // 
            this.chbHeavy.AutoSize = true;
            this.chbHeavy.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbHeavy.Location = new System.Drawing.Point(3, 148);
            this.chbHeavy.Name = "chbHeavy";
            this.chbHeavy.Size = new System.Drawing.Size(74, 22);
            this.chbHeavy.TabIndex = 4;
            this.chbHeavy.Text = "Heavies";
            this.toolTip1.SetToolTip(this.chbHeavy, "Select to download the Heavy Leaderboard for the selected Season");
            this.chbHeavy.UseVisualStyleBackColor = true;
            this.chbHeavy.CheckedChanged += new System.EventHandler(this.chkHeavy_CheckedChanged);
            // 
            // chbMedium
            // 
            this.chbMedium.AutoSize = true;
            this.chbMedium.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbMedium.Location = new System.Drawing.Point(3, 120);
            this.chbMedium.Name = "chbMedium";
            this.chbMedium.Size = new System.Drawing.Size(79, 22);
            this.chbMedium.TabIndex = 3;
            this.chbMedium.Text = "Mediums";
            this.toolTip1.SetToolTip(this.chbMedium, "Select to download the Medium Leaderboard for the selected Season");
            this.chbMedium.UseVisualStyleBackColor = true;
            this.chbMedium.CheckedChanged += new System.EventHandler(this.chbMedium_CheckedChanged);
            // 
            // chbLight
            // 
            this.chbLight.AutoSize = true;
            this.chbLight.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbLight.Location = new System.Drawing.Point(3, 92);
            this.chbLight.Name = "chbLight";
            this.chbLight.Size = new System.Drawing.Size(63, 22);
            this.chbLight.TabIndex = 2;
            this.chbLight.Text = "Lights";
            this.toolTip1.SetToolTip(this.chbLight, "Select to download the Light Leaderboard for the selected Season");
            this.chbLight.UseVisualStyleBackColor = true;
            this.chbLight.CheckedChanged += new System.EventHandler(this.chbLight_CheckedChanged);
            // 
            // lblTypeDescription
            // 
            this.lblTypeDescription.AutoSize = true;
            this.lblTypeDescription.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeDescription.Location = new System.Drawing.Point(93, 0);
            this.lblTypeDescription.Name = "lblTypeDescription";
            this.lblTypeDescription.Size = new System.Drawing.Size(124, 23);
            this.lblTypeDescription.TabIndex = 1;
            this.lblTypeDescription.Text = "Type Selection";
            this.toolTip1.SetToolTip(this.lblTypeDescription, "Select which type of leaderboards you\r\nwhant to download. Consider each\r\noption w" +
        "ill take approximately 2 hours\r\nto complete, based on your internet\r\nconnection " +
        "speed.");
            // 
            // chbGeneral
            // 
            this.chbGeneral.AutoSize = true;
            this.chbGeneral.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbGeneral.Location = new System.Drawing.Point(3, 64);
            this.chbGeneral.Name = "chbGeneral";
            this.chbGeneral.Size = new System.Drawing.Size(74, 22);
            this.chbGeneral.TabIndex = 0;
            this.chbGeneral.Text = "General";
            this.toolTip1.SetToolTip(this.chbGeneral, "Select to download the General Leaderboard for the selected Season");
            this.chbGeneral.UseVisualStyleBackColor = true;
            this.chbGeneral.CheckedChanged += new System.EventHandler(this.chbGeneral_CheckedChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(127, 9);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(180, 27);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Download Settings";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Credentials";
            this.toolTip1.SetToolTip(this.label3, "Select which type of leaderboards you\r\nwhant to download. Consider each\r\noption w" +
        "ill take approximately 2 hours\r\nto complete, based on your internet\r\nconnection " +
        "speed.");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "E-Mail";
            this.toolTip1.SetToolTip(this.label1, "The e-mail address you want to login");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            this.toolTip1.SetToolTip(this.label2, "The e-mail address you want to login");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "End on page:";
            this.toolTip1.SetToolTip(this.label4, "The e-mail address you want to login");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "Start on page:";
            this.toolTip1.SetToolTip(this.label5, "The e-mail address you want to login");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(47, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 23);
            this.label6.TabIndex = 1;
            this.label6.Text = "Configurations";
            this.toolTip1.SetToolTip(this.label6, "Select which type of leaderboards you\r\nwhant to download. Consider each\r\noption w" +
        "ill take approximately 2 hours\r\nto complete, based on your internet\r\nconnection " +
        "speed.");
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtPassword);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtEMail);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(16, 323);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(207, 127);
            this.panel2.TabIndex = 8;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(3, 97);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(199, 15);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtEMail
            // 
            this.txtEMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtEMail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEMail.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEMail.Location = new System.Drawing.Point(3, 50);
            this.txtEMail.Name = "txtEMail";
            this.txtEMail.Size = new System.Drawing.Size(199, 15);
            this.txtEMail.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txtEndPage);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtStartPage);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(229, 323);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(207, 108);
            this.panel3.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(135, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 17);
            this.label9.TabIndex = 9;
            this.label9.Text = "2.5 seconds";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "Each page takes approx.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(53, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "Max 3500 pages.";
            // 
            // txtEndPage
            // 
            this.txtEndPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtEndPage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEndPage.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndPage.Location = new System.Drawing.Point(126, 51);
            this.txtEndPage.Name = "txtEndPage";
            this.txtEndPage.Size = new System.Drawing.Size(44, 19);
            this.txtEndPage.TabIndex = 5;
            this.txtEndPage.Text = "200";
            this.txtEndPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEndPage.Leave += new System.EventHandler(this.txtEndPage_Leave);
            // 
            // txtStartPage
            // 
            this.txtStartPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtStartPage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStartPage.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartPage.Location = new System.Drawing.Point(126, 24);
            this.txtStartPage.Name = "txtStartPage";
            this.txtStartPage.Size = new System.Drawing.Size(44, 19);
            this.txtStartPage.TabIndex = 3;
            this.txtStartPage.Text = "1";
            this.txtStartPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtStartPage.Leave += new System.EventHandler(this.txtStartPage_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(102, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Start Page";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(174, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "End Page";
            // 
            // txtStartGeneral
            // 
            this.txtStartGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtStartGeneral.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartGeneral.Location = new System.Drawing.Point(106, 63);
            this.txtStartGeneral.Name = "txtStartGeneral";
            this.txtStartGeneral.Size = new System.Drawing.Size(58, 24);
            this.txtStartGeneral.TabIndex = 10;
            this.txtStartGeneral.Text = "1";
            this.txtStartGeneral.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtStartGeneral, "Page from where to start downloading the General Leaderboard");
            this.txtStartGeneral.TextChanged += new System.EventHandler(this.txtStartGeneral_TextChanged);
            this.txtStartGeneral.Leave += new System.EventHandler(this.txtStartGeneral_Leave);
            // 
            // txtStartLight
            // 
            this.txtStartLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtStartLight.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartLight.Location = new System.Drawing.Point(106, 91);
            this.txtStartLight.Name = "txtStartLight";
            this.txtStartLight.Size = new System.Drawing.Size(58, 24);
            this.txtStartLight.TabIndex = 11;
            this.txtStartLight.Text = "1";
            this.txtStartLight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtStartLight, "Page from where to start downloading the Light Leaderboard");
            this.txtStartLight.TextChanged += new System.EventHandler(this.txtStartLight_TextChanged);
            this.txtStartLight.Leave += new System.EventHandler(this.txtStartLight_Leave);
            // 
            // txtStartMedium
            // 
            this.txtStartMedium.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtStartMedium.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartMedium.Location = new System.Drawing.Point(106, 119);
            this.txtStartMedium.Name = "txtStartMedium";
            this.txtStartMedium.Size = new System.Drawing.Size(58, 24);
            this.txtStartMedium.TabIndex = 12;
            this.txtStartMedium.Text = "1";
            this.txtStartMedium.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtStartMedium, "Page from where to start downloading the Medium Leaderboard");
            // 
            // txtStartHeavy
            // 
            this.txtStartHeavy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtStartHeavy.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartHeavy.Location = new System.Drawing.Point(106, 147);
            this.txtStartHeavy.Name = "txtStartHeavy";
            this.txtStartHeavy.Size = new System.Drawing.Size(58, 24);
            this.txtStartHeavy.TabIndex = 13;
            this.txtStartHeavy.Text = "1";
            this.txtStartHeavy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtStartHeavy, "Page from where to start downloading the Heavy Leaderboard");
            // 
            // txtStartAssault
            // 
            this.txtStartAssault.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtStartAssault.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartAssault.Location = new System.Drawing.Point(106, 176);
            this.txtStartAssault.Name = "txtStartAssault";
            this.txtStartAssault.Size = new System.Drawing.Size(58, 24);
            this.txtStartAssault.TabIndex = 14;
            this.txtStartAssault.Text = "1";
            this.txtStartAssault.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtStartAssault, "Page from where to start downloading the Assault Leaderboard");
            // 
            // txtEndGeneral
            // 
            this.txtEndGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtEndGeneral.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndGeneral.Location = new System.Drawing.Point(176, 63);
            this.txtEndGeneral.Name = "txtEndGeneral";
            this.txtEndGeneral.Size = new System.Drawing.Size(58, 24);
            this.txtEndGeneral.TabIndex = 15;
            this.txtEndGeneral.Text = "3500";
            this.txtEndGeneral.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtEndGeneral, "Page to where finish downloading the General Leaderboard");
            this.txtEndGeneral.TextChanged += new System.EventHandler(this.txtEndGeneral_TextChanged);
            this.txtEndGeneral.Leave += new System.EventHandler(this.txtEndGeneral_Leave);
            // 
            // txtEndLight
            // 
            this.txtEndLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtEndLight.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndLight.Location = new System.Drawing.Point(176, 91);
            this.txtEndLight.Name = "txtEndLight";
            this.txtEndLight.Size = new System.Drawing.Size(58, 24);
            this.txtEndLight.TabIndex = 16;
            this.txtEndLight.Text = "3500";
            this.txtEndLight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtEndLight, "Page to where finish downloading the Light Leaderboard");
            // 
            // txtEndMedium
            // 
            this.txtEndMedium.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtEndMedium.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndMedium.Location = new System.Drawing.Point(176, 119);
            this.txtEndMedium.Name = "txtEndMedium";
            this.txtEndMedium.Size = new System.Drawing.Size(58, 24);
            this.txtEndMedium.TabIndex = 17;
            this.txtEndMedium.Text = "3500";
            this.txtEndMedium.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtEndMedium, "Page to where finish downloading the Medium Leaderboard");
            // 
            // txtEndHeavy
            // 
            this.txtEndHeavy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtEndHeavy.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndHeavy.Location = new System.Drawing.Point(176, 147);
            this.txtEndHeavy.Name = "txtEndHeavy";
            this.txtEndHeavy.Size = new System.Drawing.Size(58, 24);
            this.txtEndHeavy.TabIndex = 18;
            this.txtEndHeavy.Text = "3500";
            this.txtEndHeavy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtEndHeavy, "Page to where finish downloading the Heavy Leaderboard");
            // 
            // txtEndAssault
            // 
            this.txtEndAssault.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtEndAssault.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndAssault.Location = new System.Drawing.Point(176, 176);
            this.txtEndAssault.Name = "txtEndAssault";
            this.txtEndAssault.Size = new System.Drawing.Size(58, 24);
            this.txtEndAssault.TabIndex = 19;
            this.txtEndAssault.Text = "3500";
            this.txtEndAssault.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtEndAssault, "Page to where finish downloading the Assault Leaderboard");
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Black;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(387, 151);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(129, 35);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.toolTip1.SetToolTip(this.btnCancel, "Returns back");
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chbFullGeneral
            // 
            this.chbFullGeneral.AutoSize = true;
            this.chbFullGeneral.Location = new System.Drawing.Point(264, 68);
            this.chbFullGeneral.Name = "chbFullGeneral";
            this.chbFullGeneral.Size = new System.Drawing.Size(15, 14);
            this.chbFullGeneral.TabIndex = 20;
            this.chbFullGeneral.UseVisualStyleBackColor = true;
            this.chbFullGeneral.CheckedChanged += new System.EventHandler(this.chbFullGeneral_CheckedChanged);
            // 
            // chbFullLight
            // 
            this.chbFullLight.AutoSize = true;
            this.chbFullLight.Location = new System.Drawing.Point(264, 96);
            this.chbFullLight.Name = "chbFullLight";
            this.chbFullLight.Size = new System.Drawing.Size(15, 14);
            this.chbFullLight.TabIndex = 21;
            this.chbFullLight.UseVisualStyleBackColor = true;
            this.chbFullLight.CheckedChanged += new System.EventHandler(this.chbFullLight_CheckedChanged);
            // 
            // chbFullMedium
            // 
            this.chbFullMedium.AutoSize = true;
            this.chbFullMedium.Location = new System.Drawing.Point(264, 124);
            this.chbFullMedium.Name = "chbFullMedium";
            this.chbFullMedium.Size = new System.Drawing.Size(15, 14);
            this.chbFullMedium.TabIndex = 22;
            this.chbFullMedium.UseVisualStyleBackColor = true;
            this.chbFullMedium.CheckedChanged += new System.EventHandler(this.chbFullMedium_CheckedChanged);
            // 
            // chbFullHeavy
            // 
            this.chbFullHeavy.AutoSize = true;
            this.chbFullHeavy.Location = new System.Drawing.Point(264, 152);
            this.chbFullHeavy.Name = "chbFullHeavy";
            this.chbFullHeavy.Size = new System.Drawing.Size(15, 14);
            this.chbFullHeavy.TabIndex = 23;
            this.chbFullHeavy.UseVisualStyleBackColor = true;
            this.chbFullHeavy.CheckedChanged += new System.EventHandler(this.chbFullHeavy_CheckedChanged);
            // 
            // chbFullAssault
            // 
            this.chbFullAssault.AutoSize = true;
            this.chbFullAssault.Location = new System.Drawing.Point(264, 181);
            this.chbFullAssault.Name = "chbFullAssault";
            this.chbFullAssault.Size = new System.Drawing.Size(15, 14);
            this.chbFullAssault.TabIndex = 24;
            this.chbFullAssault.UseVisualStyleBackColor = true;
            this.chbFullAssault.CheckedChanged += new System.EventHandler(this.chbFullAssault_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(239, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 26);
            this.label12.TabIndex = 25;
            this.label12.Text = "Full\r\nDownload";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.Black;
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDownload.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownload.Location = new System.Drawing.Point(387, 194);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(129, 35);
            this.btnDownload.TabIndex = 11;
            this.btnDownload.Text = "Start Download";
            this.toolTip1.SetToolTip(this.btnDownload, "Returns back");
            this.btnDownload.UseVisualStyleBackColor = false;
            // 
            // frmGetData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(529, 462);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblSeason);
            this.Controls.Add(this.cmbSeasonNumber);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmGetData";
            this.Text = "BBARST - Get Data";
            this.Load += new System.EventHandler(this.frmGetData_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSeasonNumber;
        private System.Windows.Forms.Label lblSeason;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.CheckBox chbGeneral;
        private System.Windows.Forms.Label lblTypeDescription;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chbLight;
        private System.Windows.Forms.CheckBox chbMedium;
        private System.Windows.Forms.CheckBox chbHeavy;
        private System.Windows.Forms.CheckBox chbAssault;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEMail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEndPage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStartPage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtStartGeneral;
        private System.Windows.Forms.TextBox txtEndGeneral;
        private System.Windows.Forms.TextBox txtStartAssault;
        private System.Windows.Forms.TextBox txtStartHeavy;
        private System.Windows.Forms.TextBox txtStartMedium;
        private System.Windows.Forms.TextBox txtStartLight;
        private System.Windows.Forms.TextBox txtEndAssault;
        private System.Windows.Forms.TextBox txtEndHeavy;
        private System.Windows.Forms.TextBox txtEndMedium;
        private System.Windows.Forms.TextBox txtEndLight;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chbFullLight;
        private System.Windows.Forms.CheckBox chbFullGeneral;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chbFullAssault;
        private System.Windows.Forms.CheckBox chbFullHeavy;
        private System.Windows.Forms.CheckBox chbFullMedium;
        private System.Windows.Forms.Button btnDownload;
    }
}