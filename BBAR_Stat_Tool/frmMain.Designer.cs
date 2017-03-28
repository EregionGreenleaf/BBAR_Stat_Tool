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
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.Location = new System.Drawing.Point(12, 340);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(157, 12);
            this.lblCopyright.TabIndex = 0;
            this.lblCopyright.Text = "©2017 BBARUnit. BBAR Stat Tool v.";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOne
            // 
            this.btnOne.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOne.Location = new System.Drawing.Point(12, 79);
            this.btnOne.Name = "btnOne";
            this.btnOne.Size = new System.Drawing.Size(274, 28);
            this.btnOne.TabIndex = 1;
            this.btnOne.Text = "Get Data";
            this.ttBtnOne.SetToolTip(this.btnOne, "Configure the Data you want from the MWO Leaderboards and download them.");
            this.btnOne.UseCompatibleTextRendering = true;
            this.btnOne.UseVisualStyleBackColor = true;
            this.btnOne.Click += new System.EventHandler(this.btnOne_Click);
            // 
            // btnTest
            // 
            this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnTest.Location = new System.Drawing.Point(12, 45);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(274, 28);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Test Connection Speed";
            this.ttBtnOne.SetToolTip(this.btnTest, "Configure the Data you want from the MWO Leaderboards and download them.");
            this.btnTest.UseCompatibleTextRendering = true;
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnGetSinglePlayer
            // 
            this.btnGetSinglePlayer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGetSinglePlayer.Location = new System.Drawing.Point(12, 113);
            this.btnGetSinglePlayer.Name = "btnGetSinglePlayer";
            this.btnGetSinglePlayer.Size = new System.Drawing.Size(274, 27);
            this.btnGetSinglePlayer.TabIndex = 3;
            this.btnGetSinglePlayer.Text = "Test Single Player Get";
            this.btnGetSinglePlayer.UseVisualStyleBackColor = true;
            this.btnGetSinglePlayer.Click += new System.EventHandler(this.btnTest2_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(274, 27);
            this.button1.TabIndex = 4;
            this.button1.Text = "Determine last available Season";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(298, 361);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnGetSinglePlayer);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnOne);
            this.Controls.Add(this.lblCopyright);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BBAR Stat Tool";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Button btnOne;
        private System.Windows.Forms.ToolTip ttBtnOne;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnGetSinglePlayer;
        private System.Windows.Forms.Button button1;
    }
}

