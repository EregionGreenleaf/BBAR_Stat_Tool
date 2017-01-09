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
            this.chbGeneral = new System.Windows.Forms.CheckBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblTypeDescription = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chbLight = new System.Windows.Forms.CheckBox();
            this.chbMedium = new System.Windows.Forms.CheckBox();
            this.chkHeavy = new System.Windows.Forms.CheckBox();
            this.chkAssault = new System.Windows.Forms.CheckBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEMail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEndPage = new System.Windows.Forms.TextBox();
            this.txtStartPage = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
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
            this.cmbSeasonNumber.Location = new System.Drawing.Point(170, 54);
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
            this.progressBar1.Location = new System.Drawing.Point(229, 330);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(193, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblTimer);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.chkAssault);
            this.panel1.Controls.Add(this.chkHeavy);
            this.panel1.Controls.Add(this.chbMedium);
            this.panel1.Controls.Add(this.chbLight);
            this.panel1.Controls.Add(this.lblTypeDescription);
            this.panel1.Controls.Add(this.chbGeneral);
            this.panel1.Location = new System.Drawing.Point(16, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(193, 209);
            this.panel1.TabIndex = 3;
            // 
            // chbGeneral
            // 
            this.chbGeneral.AutoSize = true;
            this.chbGeneral.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbGeneral.Location = new System.Drawing.Point(3, 37);
            this.chbGeneral.Name = "chbGeneral";
            this.chbGeneral.Size = new System.Drawing.Size(74, 22);
            this.chbGeneral.TabIndex = 0;
            this.chbGeneral.Text = "General";
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
            // lblTypeDescription
            // 
            this.lblTypeDescription.AutoSize = true;
            this.lblTypeDescription.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeDescription.Location = new System.Drawing.Point(27, 0);
            this.lblTypeDescription.Name = "lblTypeDescription";
            this.lblTypeDescription.Size = new System.Drawing.Size(124, 23);
            this.lblTypeDescription.TabIndex = 1;
            this.lblTypeDescription.Text = "Type Selection";
            this.toolTip1.SetToolTip(this.lblTypeDescription, "Select which type of leaderboards you\r\nwhant to download. Consider each\r\noption w" +
        "ill take approximately 2 hours\r\nto complete, based on your internet\r\nconnection " +
        "speed.");
            // 
            // chbLight
            // 
            this.chbLight.AutoSize = true;
            this.chbLight.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbLight.Location = new System.Drawing.Point(3, 65);
            this.chbLight.Name = "chbLight";
            this.chbLight.Size = new System.Drawing.Size(63, 22);
            this.chbLight.TabIndex = 2;
            this.chbLight.Text = "Lights";
            this.chbLight.UseVisualStyleBackColor = true;
            this.chbLight.CheckedChanged += new System.EventHandler(this.chbLight_CheckedChanged);
            // 
            // chbMedium
            // 
            this.chbMedium.AutoSize = true;
            this.chbMedium.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbMedium.Location = new System.Drawing.Point(3, 93);
            this.chbMedium.Name = "chbMedium";
            this.chbMedium.Size = new System.Drawing.Size(79, 22);
            this.chbMedium.TabIndex = 3;
            this.chbMedium.Text = "Mediums";
            this.chbMedium.UseVisualStyleBackColor = true;
            this.chbMedium.CheckedChanged += new System.EventHandler(this.chbMedium_CheckedChanged);
            // 
            // chkHeavy
            // 
            this.chkHeavy.AutoSize = true;
            this.chkHeavy.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHeavy.Location = new System.Drawing.Point(3, 121);
            this.chkHeavy.Name = "chkHeavy";
            this.chkHeavy.Size = new System.Drawing.Size(74, 22);
            this.chkHeavy.TabIndex = 4;
            this.chkHeavy.Text = "Heavies";
            this.chkHeavy.UseVisualStyleBackColor = true;
            this.chkHeavy.CheckedChanged += new System.EventHandler(this.chkHeavy_CheckedChanged);
            // 
            // chkAssault
            // 
            this.chkAssault.AutoSize = true;
            this.chkAssault.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAssault.Location = new System.Drawing.Point(3, 150);
            this.chkAssault.Name = "chkAssault";
            this.chkAssault.Size = new System.Drawing.Size(77, 22);
            this.chkAssault.TabIndex = 5;
            this.chkAssault.Text = "Assaults";
            this.chkAssault.UseVisualStyleBackColor = true;
            this.chkAssault.CheckedChanged += new System.EventHandler(this.chkAssault_CheckedChanged);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(0, 183);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(165, 17);
            this.lblTime.TabIndex = 6;
            this.lblTime.Text = "Approximate time to finish: ";
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.Location = new System.Drawing.Point(156, 183);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(25, 17);
            this.lblTimer.TabIndex = 7;
            this.lblTimer.Text = "0 h";
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(108, 320);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 33);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtPassword);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtEMail);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(215, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(207, 127);
            this.panel2.TabIndex = 8;
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
            // txtEMail
            // 
            this.txtEMail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEMail.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEMail.Location = new System.Drawing.Point(3, 50);
            this.txtEMail.Name = "txtEMail";
            this.txtEMail.Size = new System.Drawing.Size(199, 15);
            this.txtEMail.TabIndex = 3;
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
            this.panel3.Location = new System.Drawing.Point(215, 187);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(207, 108);
            this.panel3.TabIndex = 9;
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
            this.txtEndPage.TextChanged += new System.EventHandler(this.txtEndPage_TextChanged);
            // 
            // txtStartPage
            // 
            this.txtStartPage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStartPage.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartPage.Location = new System.Drawing.Point(126, 24);
            this.txtStartPage.Name = "txtStartPage";
            this.txtStartPage.Size = new System.Drawing.Size(44, 19);
            this.txtStartPage.TabIndex = 3;
            this.txtStartPage.Text = "1";
            this.txtStartPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtStartPage.TextChanged += new System.EventHandler(this.txtStartPage_TextChanged);
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
            // frmGetData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(433, 365);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.CheckBox chkHeavy;
        private System.Windows.Forms.CheckBox chkAssault;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Button button1;
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
    }
}