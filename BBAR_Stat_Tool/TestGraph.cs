using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBAR_Stat_Tool
{
    public partial class TestGraph : Form
    {
        public TestGraph()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series["test1"].Points.Clear();
            chart1.Series["test2"].Points.Clear();
            chart1.Series["test1"].LegendText = "KDr";
            chart1.Series["test2"].LegendText = "WLr";
            Random rdn = new Random();
            int[] first = new int[] { rdn.Next(100,410) , rdn.Next(100, 410), rdn.Next(100, 410), rdn.Next(100, 410), rdn.Next(100, 410), rdn.Next(100, 410),
                                        rdn.Next(100,410), rdn.Next(100,410), rdn.Next(100,410), rdn.Next(100,410) };
            int[] second = new int[] { rdn.Next(100,410) , rdn.Next(100, 410), rdn.Next(100, 410), rdn.Next(100, 410), rdn.Next(100, 410), rdn.Next(100, 410),
                                        rdn.Next(100,410), rdn.Next(100,410), rdn.Next(100,410), rdn.Next(100,410) };
            int max = rdn.Next(8, 15);
            for (int i = 0; i < max; i++)
            {
                chart1.Series["test1"].Points.AddXY
                                ((i+1)*1, rdn.Next(80, 380));
                chart1.Series["test2"].Points.AddXY
                                ((i+1)*1, rdn.Next(80, 380));
            }
            chart1.SaveImage("F:\\CODICE\\Output\\chart.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
            //chart1.Series["test1"].ChartType =
            //                    SeriesChartType.FastLine;
            //chart1.Series["test1"].Color = Color.Red;

            //chart1.Series["test2"].ChartType =
            //                    SeriesChartType.FastLine;
            //chart1.Series["test2"].Color = Color.Blue;
        }

        static float NextFloat(Random random)
        {
            var buffer = new byte[4];
            random.NextBytes(buffer);
            return BitConverter.ToSingle(buffer, 0);
        }
    }
}
