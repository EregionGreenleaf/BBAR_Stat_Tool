namespace BBAR_Stat_Tool
{
    partial class frmMain
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblCopyright = new System.Windows.Forms.Label();
            this.btnOne = new System.Windows.Forms.Button();
            this.ttBtnOne = new System.Windows.Forms.ToolTip(this.components);
            this.btnTest = new System.Windows.Forms.Button();
            this.btnGetSinglePlayer = new System.Windows.Forms.Button();
            this.btnLastSeason = new System.Windows.Forms.Button();
            this.prbSinglePlayer = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.lblLastSeason = new System.Windows.Forms.Label();
            this.lblElaborating = new System.Windows.Forms.Label();
            this.prbPlayerList = new System.Windows.Forms.ProgressBar();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSQL = new System.Windows.Forms.Button();
            this.lblActiveTasks = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.Location = new System.Drawing.Point(367, 291);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(157, 12);
            this.lblCopyright.TabIndex = 0;
            this.lblCopyright.Text = "©2017 BBARUnit. BBAR Stat Tool v.";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCopyright.Click += new System.EventHandler(this.lblCopyright_Click);
            // 
            // btnOne
            // 
            this.btnOne.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOne.Location = new System.Drawing.Point(10, 112);
            this.btnOne.Name = "btnOne";
            this.btnOne.Size = new System.Drawing.Size(274, 28);
            this.btnOne.TabIndex = 1;
            this.btnOne.Text = "Download Seasonal Data";
            this.ttBtnOne.SetToolTip(this.btnOne, "Downloads all seasonal data from the Web by configuring\r\nthe Data you want from t" +
        "he MWO Leaderboards.");
            this.btnOne.UseCompatibleTextRendering = true;
            this.btnOne.UseVisualStyleBackColor = true;
            this.btnOne.Click += new System.EventHandler(this.btnOne_Click);
            // 
            // btnTest
            // 
            this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTest.Location = new System.Drawing.Point(12, 45);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(274, 28);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Test Connection Speed";
            this.ttBtnOne.SetToolTip(this.btnTest, "Determines connection speed by sampling a test connection.");
            this.btnTest.UseCompatibleTextRendering = true;
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnGetSinglePlayer
            // 
            this.btnGetSinglePlayer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGetSinglePlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetSinglePlayer.Location = new System.Drawing.Point(10, 175);
            this.btnGetSinglePlayer.Name = "btnGetSinglePlayer";
            this.btnGetSinglePlayer.Size = new System.Drawing.Size(274, 27);
            this.btnGetSinglePlayer.TabIndex = 3;
            this.btnGetSinglePlayer.Text = "Single Player Data from Web";
            this.ttBtnOne.SetToolTip(this.btnGetSinglePlayer, "Download all available Data of a single Player.\r\nOutput will be set in a file wit" +
        "h the name of the Player.");
            this.btnGetSinglePlayer.UseVisualStyleBackColor = true;
            this.btnGetSinglePlayer.Click += new System.EventHandler(this.btnTest2_Click);
            // 
            // btnLastSeason
            // 
            this.btnLastSeason.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLastSeason.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLastSeason.Location = new System.Drawing.Point(12, 12);
            this.btnLastSeason.Name = "btnLastSeason";
            this.btnLastSeason.Size = new System.Drawing.Size(274, 27);
            this.btnLastSeason.TabIndex = 4;
            this.btnLastSeason.Text = "Determine last available Season";
            this.ttBtnOne.SetToolTip(this.btnLastSeason, "Determine the last season available on the MWO Leaderboard site.\r\nIt could take s" +
        "ome time, based on connection speed and the number of seasons available.");
            this.btnLastSeason.UseVisualStyleBackColor = true;
            this.btnLastSeason.Click += new System.EventHandler(this.button1_Click);
            // 
            // prbSinglePlayer
            // 
            this.prbSinglePlayer.Location = new System.Drawing.Point(290, 175);
            this.prbSinglePlayer.Name = "prbSinglePlayer";
            this.prbSinglePlayer.Size = new System.Drawing.Size(272, 27);
            this.prbSinglePlayer.TabIndex = 5;
            this.ttBtnOne.SetToolTip(this.prbSinglePlayer, "State of the \'Single Player Data\' download process.");
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(10, 241);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(274, 27);
            this.button1.TabIndex = 9;
            this.button1.Text = "Single Player Data from DB";
            this.ttBtnOne.SetToolTip(this.button1, "Elaborate Single Player stats taking data from DB\r\n(faster then Web, data not upd" +
        "ated as Web).\r\nOutput will be set in a file with the name of the Player.");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lblLastSeason
            // 
            this.lblLastSeason.AutoSize = true;
            this.lblLastSeason.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastSeason.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastSeason.ForeColor = System.Drawing.Color.Red;
            this.lblLastSeason.Location = new System.Drawing.Point(292, 18);
            this.lblLastSeason.Name = "lblLastSeason";
            this.lblLastSeason.Size = new System.Drawing.Size(118, 16);
            this.lblLastSeason.TabIndex = 6;
            this.lblLastSeason.Text = "Last Season: 10";
            this.lblLastSeason.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ttBtnOne.SetToolTip(this.lblLastSeason, "Shows last season detected (green)\r\nor set in Config File (red)");
            this.lblLastSeason.Click += new System.EventHandler(this.lblLastSeason_Click);
            // 
            // lblElaborating
            // 
            this.lblElaborating.AutoEllipsis = true;
            this.lblElaborating.AutoSize = true;
            this.lblElaborating.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblElaborating.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElaborating.ForeColor = System.Drawing.Color.Red;
            this.lblElaborating.Location = new System.Drawing.Point(288, 246);
            this.lblElaborating.MaximumSize = new System.Drawing.Size(350, 50);
            this.lblElaborating.Name = "lblElaborating";
            this.lblElaborating.Size = new System.Drawing.Size(117, 19);
            this.lblElaborating.TabIndex = 10;
            this.lblElaborating.Text = "Retriving data...";
            this.lblElaborating.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ttBtnOne.SetToolTip(this.lblElaborating, "Shows actual state of DB connection/elaboration");
            this.lblElaborating.UseCompatibleTextRendering = true;
            // 
            // prbPlayerList
            // 
            this.prbPlayerList.Location = new System.Drawing.Point(290, 208);
            this.prbPlayerList.Name = "prbPlayerList";
            this.prbPlayerList.Size = new System.Drawing.Size(272, 27);
            this.prbPlayerList.TabIndex = 12;
            this.ttBtnOne.SetToolTip(this.prbPlayerList, "State of the \'Single Player Data\' download process.");
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(10, 208);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(274, 27);
            this.button2.TabIndex = 11;
            this.button2.Text = "List of Players\' Data from Web";
            this.ttBtnOne.SetToolTip(this.button2, "Download all available Data of a list of players.\r\nOutput will be set in a series" +
        " of files with the name \r\nof the Players, with the relative PDF.");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSQL
            // 
            this.btnSQL.Enabled = false;
            this.btnSQL.ForeColor = System.Drawing.Color.Black;
            this.btnSQL.Location = new System.Drawing.Point(295, 115);
            this.btnSQL.Name = "btnSQL";
            this.btnSQL.Size = new System.Drawing.Size(231, 21);
            this.btnSQL.TabIndex = 8;
            this.btnSQL.Text = "Admin: Load to SQL Server";
            this.ttBtnOne.SetToolTip(this.btnSQL, "Reserved to server administration");
            this.btnSQL.UseVisualStyleBackColor = true;
            this.btnSQL.Click += new System.EventHandler(this.btnSQL_Click);
            // 
            // lblActiveTasks
            // 
            this.lblActiveTasks.AutoSize = true;
            this.lblActiveTasks.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblActiveTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveTasks.ForeColor = System.Drawing.Color.Yellow;
            this.lblActiveTasks.Location = new System.Drawing.Point(12, 283);
            this.lblActiveTasks.Name = "lblActiveTasks";
            this.lblActiveTasks.Size = new System.Drawing.Size(106, 16);
            this.lblActiveTasks.TabIndex = 7;
            this.lblActiveTasks.Text = "Active Tasks: ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BBAR_Stat_Tool.Properties.Resources.Mauler;
            this.pictureBox1.Location = new System.Drawing.Point(347, -24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(244, 341);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(572, 306);
            this.Controls.Add(this.prbPlayerList);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblElaborating);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSQL);
            this.Controls.Add(this.lblActiveTasks);
            this.Controls.Add(this.lblLastSeason);
            this.Controls.Add(this.prbSinglePlayer);
            this.Controls.Add(this.btnLastSeason);
            this.Controls.Add(this.btnGetSinglePlayer);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnOne);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BBAR Stat Tool";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Button btnOne;
        private System.Windows.Forms.ToolTip ttBtnOne;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnGetSinglePlayer;
        private System.Windows.Forms.Button btnLastSeason;
        private System.Windows.Forms.ProgressBar prbSinglePlayer;
        private System.Windows.Forms.Label lblLastSeason;
        private System.Windows.Forms.Label lblActiveTasks;
        private System.Windows.Forms.Button btnSQL;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblElaborating;
        private System.Windows.Forms.ProgressBar prbPlayerList;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

