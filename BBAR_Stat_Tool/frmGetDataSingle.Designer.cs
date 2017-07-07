namespace BBAR_Stat_Tool
{
    partial class frmGetDataSingle
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.playerStatTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.playerStatTBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.playerStatTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerStatTBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(590, 440);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AllowDrop = true;
            this.textBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox1.Location = new System.Drawing.Point(12, 32);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(224, 420);
            this.textBox1.TabIndex = 1;
            this.textBox1.WordWrap = false;
            // 
            // playerStatTBindingSource
            // 
            this.playerStatTBindingSource.DataSource = typeof(BBAR_Stat_Tool.PlayerStatT);
            // 
            // playerStatTBindingSource1
            // 
            this.playerStatTBindingSource1.DataSource = typeof(BBAR_Stat_Tool.PlayerStatT);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(242, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 50);
            this.button2.TabIndex = 2;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "List of Players:";
            // 
            // frmGetDataSingle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(324, 475);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGetDataSingle";
            this.Text = "BBARST - Get Data for a list of Players";
            this.Load += new System.EventHandler(this.frmGetDataSingle_Load);
            this.Shown += new System.EventHandler(this.frmGetDataSingle_Show);
            ((System.ComponentModel.ISupportInitialize)(this.playerStatTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerStatTBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource playerStatTBindingSource;
        private System.Windows.Forms.BindingSource playerStatTBindingSource1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
    }
}