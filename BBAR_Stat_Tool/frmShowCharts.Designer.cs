namespace BBAR_Stat_Tool
{
    partial class frmShowCharts
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowCharts));
            this.crtKDWKr = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.crtKDpM = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.crtAvMS = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlImageContainer = new System.Windows.Forms.Panel();
            this.pcbStats = new System.Windows.Forms.PictureBox();
            this.btnPrintCharts = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.crtKDWKr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crtKDpM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crtAvMS)).BeginInit();
            this.pnlImageContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbStats)).BeginInit();
            this.SuspendLayout();
            // 
            // crtKDWKr
            // 
            chartArea1.Name = "ChartArea1";
            this.crtKDWKr.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.crtKDWKr.Legends.Add(legend1);
            this.crtKDWKr.Location = new System.Drawing.Point(12, 12);
            this.crtKDWKr.Name = "crtKDWKr";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Red;
            series1.CustomProperties = "LineTension=0.4";
            series1.LabelForeColor = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "KDr";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.Blue;
            series2.CustomProperties = "LineTension=0.4";
            series2.LabelForeColor = System.Drawing.Color.Blue;
            series2.Legend = "Legend1";
            series2.Name = "WLr";
            series3.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Red;
            series3.Legend = "Legend1";
            series3.Name = "Av KDr";
            series4.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Blue;
            series4.Legend = "Legend1";
            series4.Name = "Av WLr";
            this.crtKDWKr.Series.Add(series1);
            this.crtKDWKr.Series.Add(series2);
            this.crtKDWKr.Series.Add(series3);
            this.crtKDWKr.Series.Add(series4);
            this.crtKDWKr.Size = new System.Drawing.Size(700, 220);
            this.crtKDWKr.TabIndex = 0;
            this.crtKDWKr.Text = "chart1";
            // 
            // crtKDpM
            // 
            chartArea2.Name = "ChartArea1";
            this.crtKDpM.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.crtKDpM.Legends.Add(legend2);
            this.crtKDpM.Location = new System.Drawing.Point(12, 238);
            this.crtKDpM.Name = "crtKDpM";
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series5.Color = System.Drawing.Color.Red;
            series5.CustomProperties = "LineTension=0.4";
            series5.LabelForeColor = System.Drawing.Color.Red;
            series5.Legend = "Legend1";
            series5.Name = "KpM";
            series6.BorderWidth = 2;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series6.Color = System.Drawing.Color.Blue;
            series6.CustomProperties = "LineTension=0.4";
            series6.LabelForeColor = System.Drawing.Color.Blue;
            series6.Legend = "Legend1";
            series6.Name = "DpM";
            series7.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Color = System.Drawing.Color.Red;
            series7.Legend = "Legend1";
            series7.Name = "Av KpM";
            series8.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Color = System.Drawing.Color.Blue;
            series8.Legend = "Legend1";
            series8.Name = "Av DpM";
            this.crtKDpM.Series.Add(series5);
            this.crtKDpM.Series.Add(series6);
            this.crtKDpM.Series.Add(series7);
            this.crtKDpM.Series.Add(series8);
            this.crtKDpM.Size = new System.Drawing.Size(700, 220);
            this.crtKDpM.TabIndex = 1;
            this.crtKDpM.Text = "chart1";
            // 
            // crtAvMS
            // 
            chartArea3.Name = "ChartArea1";
            this.crtAvMS.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.crtAvMS.Legends.Add(legend3);
            this.crtAvMS.Location = new System.Drawing.Point(12, 464);
            this.crtAvMS.Name = "crtAvMS";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series9.Color = System.Drawing.Color.Red;
            series9.CustomProperties = "LineTension=0.4";
            series9.LabelForeColor = System.Drawing.Color.Red;
            series9.Legend = "Legend1";
            series9.Name = "AvMS";
            series10.BorderWidth = 2;
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Stock;
            series10.Color = System.Drawing.Color.Blue;
            series10.Legend = "Legend1";
            series10.Name = "Played";
            series10.YValuesPerPoint = 4;
            series11.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series11.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series11.Legend = "Legend1";
            series11.Name = "Av MS";
            series11.ShadowColor = System.Drawing.Color.Black;
            series11.ShadowOffset = 1;
            series12.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series12.Color = System.Drawing.Color.Blue;
            series12.Legend = "Legend1";
            series12.Name = "Av Played";
            series12.ShadowColor = System.Drawing.Color.Black;
            series12.ShadowOffset = 1;
            this.crtAvMS.Series.Add(series9);
            this.crtAvMS.Series.Add(series10);
            this.crtAvMS.Series.Add(series11);
            this.crtAvMS.Series.Add(series12);
            this.crtAvMS.Size = new System.Drawing.Size(700, 220);
            this.crtAvMS.TabIndex = 2;
            this.crtAvMS.Text = "chart1";
            this.crtAvMS.Click += new System.EventHandler(this.crtAvMS_Click);
            // 
            // pnlImageContainer
            // 
            this.pnlImageContainer.AutoScroll = true;
            this.pnlImageContainer.Controls.Add(this.pcbStats);
            this.pnlImageContainer.Location = new System.Drawing.Point(718, 12);
            this.pnlImageContainer.Name = "pnlImageContainer";
            this.pnlImageContainer.Size = new System.Drawing.Size(638, 672);
            this.pnlImageContainer.TabIndex = 4;
            // 
            // pcbStats
            // 
            this.pcbStats.Location = new System.Drawing.Point(16, 0);
            this.pcbStats.Name = "pcbStats";
            this.pcbStats.Size = new System.Drawing.Size(596, 531);
            this.pcbStats.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pcbStats.TabIndex = 4;
            this.pcbStats.TabStop = false;
            this.pcbStats.WaitOnLoad = true;
            // 
            // btnPrintCharts
            // 
            this.btnPrintCharts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrintCharts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintCharts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPrintCharts.Location = new System.Drawing.Point(591, 642);
            this.btnPrintCharts.Name = "btnPrintCharts";
            this.btnPrintCharts.Size = new System.Drawing.Size(118, 39);
            this.btnPrintCharts.TabIndex = 6;
            this.btnPrintCharts.Text = "Print Data to PDF";
            this.btnPrintCharts.UseVisualStyleBackColor = true;
            this.btnPrintCharts.Click += new System.EventHandler(this.btnPrintCharts_Click);
            // 
            // frmShowCharts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1366, 693);
            this.Controls.Add(this.btnPrintCharts);
            this.Controls.Add(this.pnlImageContainer);
            this.Controls.Add(this.crtAvMS);
            this.Controls.Add(this.crtKDpM);
            this.Controls.Add(this.crtKDWKr);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmShowCharts";
            this.Text = "BBARST - Charts";
            this.Load += new System.EventHandler(this.frmShowCharts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.crtKDWKr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crtKDpM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crtAvMS)).EndInit();
            this.pnlImageContainer.ResumeLayout(false);
            this.pnlImageContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbStats)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart crtKDWKr;
        private System.Windows.Forms.DataVisualization.Charting.Chart crtKDpM;
        private System.Windows.Forms.DataVisualization.Charting.Chart crtAvMS;
        private System.Windows.Forms.Panel pnlImageContainer;
        private System.Windows.Forms.PictureBox pcbStats;
        private System.Windows.Forms.Button btnPrintCharts;
    }
}