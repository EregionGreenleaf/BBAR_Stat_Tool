using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace BBAR_Stat_Tool
{
    public class GraphOps
    {

        public static void DrawChartKDWLr(Chart chart1, double[] data1, double[] data2 )
        {
            chart1.Series["KDr"].Points.Clear();
            chart1.Series["WLr"].Points.Clear();
            chart1.Series["KDr"].LegendText = "KDr";
            chart1.Series["WLr"].LegendText = "WLr";
            Random rdn = new Random();
            int[] first = new int[] { rdn.Next(100,410) , rdn.Next(100, 410), rdn.Next(100, 410), rdn.Next(100, 410), rdn.Next(100, 410), rdn.Next(100, 410),
                                        rdn.Next(100,410), rdn.Next(100,410), rdn.Next(100,410), rdn.Next(100,410) };
            int[] second = new int[] { rdn.Next(100,410) , rdn.Next(100, 410), rdn.Next(100, 410), rdn.Next(100, 410), rdn.Next(100, 410), rdn.Next(100, 410),
                                        rdn.Next(100,410), rdn.Next(100,410), rdn.Next(100,410), rdn.Next(100,410) };
            for (int i = 0; i < ConfigFile.SEASON_LAST; i++)
            {
                chart1.Series["KDr"].Points.AddXY
                                ((i + 1) * 1, data1[i]);
                chart1.Series["WLr"].Points.AddXY
                                ((i + 1) * 1, data2[i]);
            }
            chart1.SaveImage("C:\\TEST\\Output\\chart.png", ChartImageFormat.Png);

            //PdfDocument 
            //chart1.Series["test1"].ChartType =
            //                    SeriesChartType.FastLine;
            //chart1.Series["test1"].Color = Color.Red;

            //chart1.Series["test2"].ChartType =
            //                    SeriesChartType.FastLine;
            //chart1.Series["test2"].Color = Color.Blue;
        }

        public static void DrawChartKDpM(Chart chart1, double[] data1, double[] data2)
        {
            chart1.Series["KpM"].Points.Clear();
            chart1.Series["DpM"].Points.Clear();
            chart1.Series["KpM"].LegendText = "KpM";
            chart1.Series["DpM"].LegendText = "DpM";
            for (int i = 0; i < ConfigFile.SEASON_LAST; i++)
            {
                chart1.Series["KpM"].Points.AddXY
                                ((i + 1) * 1, data1[i]);
                chart1.Series["DpM"].Points.AddXY
                                ((i + 1) * 1, data2[i]);
            }
            chart1.SaveImage("C:\\TEST\\Output\\chart2.png", ChartImageFormat.Png);
        }

        public static void DrawChartAvMS(Chart chart1, int[] data1, int[] data2)
        {
            chart1.Series["AvMS"].Points.Clear();
            chart1.Series["AvMS"].LegendText = "AvMS";
            chart1.Series["Played"].Points.Clear();
            chart1.Series["Played"].LegendText = "Play";
            int maxData1 = 0;
            int maxData2 = 0;
            for (int y=0; y<data1.Count(); y++)
            {
                maxData1 = Math.Max(data1[y], maxData1);
            }
            for (int y = 0; y < data2.Count(); y++)
            {
                maxData2 = Math.Max(data2[y], maxData2);
            }
            if(maxData2 > (maxData1 * 1.5))
            {
                for(int y = 0; y < data2.Count(); y++)
                {
                    data2[y] = (int)(data2[y] / 2);
                }
                chart1.Series["Played"].LegendText = "Play" + Environment.NewLine + " div. 2";
            }
            for (int i = 0; i < ConfigFile.SEASON_LAST; i++)
            {
                chart1.Series["AvMS"].Points.AddXY
                                ((i + 1) * 1, data1[i]);
                chart1.Series["Played"].Points.AddXY
                                ((i + 1) * 1, data2[i]);

            }
            chart1.SaveImage("C:\\TEST\\Output\\chart3.png", ChartImageFormat.Png);
        }

    }
}
