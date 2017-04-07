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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowCharts));
            this.crtKDWKr = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.crtKDpM = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.crtAvMS = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.crtKDWKr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crtKDpM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crtAvMS)).BeginInit();
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
            this.crtKDWKr.Series.Add(series1);
            this.crtKDWKr.Series.Add(series2);
            this.crtKDWKr.Size = new System.Drawing.Size(569, 173);
            this.crtKDWKr.TabIndex = 0;
            this.crtKDWKr.Text = "chart1";
            // 
            // crtKDpM
            // 
            chartArea2.Name = "ChartArea1";
            this.crtKDpM.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.crtKDpM.Legends.Add(legend2);
            this.crtKDpM.Location = new System.Drawing.Point(12, 191);
            this.crtKDpM.Name = "crtKDpM";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Color = System.Drawing.Color.Red;
            series3.CustomProperties = "LineTension=0.4";
            series3.LabelForeColor = System.Drawing.Color.Red;
            series3.Legend = "Legend1";
            series3.Name = "KpM";
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Color = System.Drawing.Color.Blue;
            series4.CustomProperties = "LineTension=0.4";
            series4.LabelForeColor = System.Drawing.Color.Blue;
            series4.Legend = "Legend1";
            series4.Name = "DpM";
            this.crtKDpM.Series.Add(series3);
            this.crtKDpM.Series.Add(series4);
            this.crtKDpM.Size = new System.Drawing.Size(569, 173);
            this.crtKDpM.TabIndex = 1;
            this.crtKDpM.Text = "chart1";
            // 
            // crtAvMS
            // 
            chartArea3.Name = "ChartArea1";
            this.crtAvMS.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.crtAvMS.Legends.Add(legend3);
            this.crtAvMS.Location = new System.Drawing.Point(12, 370);
            this.crtAvMS.Name = "crtAvMS";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series5.Color = System.Drawing.Color.Red;
            series5.CustomProperties = "LineTension=0.4";
            series5.LabelForeColor = System.Drawing.Color.Red;
            series5.Legend = "Legend1";
            series5.Name = "AvMS";
            series6.BorderWidth = 2;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Stock;
            series6.Color = System.Drawing.Color.Blue;
            series6.Legend = "Legend1";
            series6.Name = "Played";
            series6.YValuesPerPoint = 4;
            this.crtAvMS.Series.Add(series5);
            this.crtAvMS.Series.Add(series6);
            this.crtAvMS.Size = new System.Drawing.Size(569, 173);
            this.crtAvMS.TabIndex = 2;
            this.crtAvMS.Text = "chart1";
            this.crtAvMS.Click += new System.EventHandler(this.crtAvMS_Click);
            // 
            // frmShowCharts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(593, 561);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart crtKDWKr;
        private System.Windows.Forms.DataVisualization.Charting.Chart crtKDpM;
        private System.Windows.Forms.DataVisualization.Charting.Chart crtAvMS;
    }
}