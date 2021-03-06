﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace BBAR_Stat_Tool
{
    public class GraphOps
    {

        public static void DrawChartKDWLr(Chart chart1, double[] data1, double[] data2, double avgKDr, double avgWLr)
        {
            chart1.Series["KDr"].Points.Clear();
            chart1.Series["WLr"].Points.Clear();
            chart1.Series["KDr"].LegendText = "KDr";
            chart1.Series["WLr"].LegendText = "WLr";
            for (int i = 0; i < ConfigFile.SEASON_LAST; i++)
            {
                chart1.Series["KDr"].Points.AddXY
                                ((i + 1) * 1, data1[i]);
                chart1.Series["WLr"].Points.AddXY
                                ((i + 1) * 1, data2[i]);
                chart1.Series["Av KDr"].Points.AddXY((i + 1) * 1, avgKDr);
                chart1.Series["Av WLr"].Points.AddXY((i + 1) * 1, avgWLr);
            }
            chart1.SaveImage(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "chart.png"), ChartImageFormat.Png);
        }

        public static void DrawChartKDpM(Chart chart1, double[] data1, double[] data2, double avgKpM, double avgDpM)
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
                chart1.Series["Av KpM"].Points.AddXY((i + 1) * 1, avgKpM);
                chart1.Series["Av DpM"].Points.AddXY((i + 1) * 1, avgDpM);
            }
            chart1.SaveImage(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "chart2.png"), ChartImageFormat.Png);
        }



        public static void DrawChartByClass(Chart chart1, double[] KDr, double[] WLr, double[] KpM, double[] DpM, string byClass, 
                                            double avKDr, double avWLr, double avKpM, double avDpM )
        {


            //double[] yValues = { 65.62, 75.54, 60.45, 34.73, 85.42, 55.9, 63.6, 55.2, 77.1 };
            //string[] xValues = { "France", "Canada", "Germany", "USA", "Italy", "Spain", "Russia", "Sweden", "Japan" };
            //chart1.Series["Default"].Points.DataBindXY(xValues, yValues);

            //// Set radar chart type
            //chart1.Series["Default"].ChartType = SeriesChartType.Radar;

            //// Set radar chart style (Area, Line or Marker)
            //chart1.Series["Default"]["RadarDrawingStyle"] = "Area";

            //// Set circular area drawing style (Circle or Polygon)
            //chart1.Series["Default"]["AreaDrawingStyle"] = "Polygon";

            //// Set labels style (Auto, Horizontal, Circular or Radial)
            //chart1.Series["Default"]["CircularLabelsStyle"] = "Horizontal";

            //// Show as 3D
            //chart1.ChartAreas["Default"].Area3DStyle.Enable3D = true;


            //double avKDr, avWLr, avKpM, avDpM;
            //double temp1 = 0, temp2 = 0;
            //int loop = 0;
            //KDr.ToList().ForEach(x => 
            //{
            //    if (x != 0)
            //    {
            //        loop++;
            //        temp1 += x;
            //    }
            //});
            //avKDr = temp1 / loop;

            //loop = 0;
            //temp1 = 0;
            //WLr.ToList().ForEach(x =>
            //{
            //    if (x != 0)
            //    {
            //        loop++;
            //        temp1 += x;
            //    }
            //});
            //avWLr = temp1 / loop;

            //loop = 0;
            //temp1 = 0;
            //KpM.ToList().ForEach(x =>
            //{
            //    if (x != 0)
            //    {
            //        loop++;
            //        temp1 += x;
            //    }
            //});
            //avKpM = temp1 / loop;

            //loop = 0;
            //temp1 = 0;
            //DpM.ToList().ForEach(x =>
            //{
            //    if (x != 0)
            //    {
            //        loop++;
            //        temp1 += x;
            //    }
            //});
            //avDpM = temp1 / loop;

            chart1.AntiAliasing = AntiAliasingStyles.All;
            chart1.Series["KDr"].Points.Clear();
            chart1.Series["KDr"].LegendText = "KDr";
            chart1.Series["WLr"].Points.Clear();
            chart1.Series["WLr"].LegendText = "WLr";
            chart1.Series["KpM"].Points.Clear();
            chart1.Series["KpM"].LegendText = "KpM";
            chart1.Series["DpM"].Points.Clear();
            chart1.Series["DpM"].LegendText = "DpM";

            chart1.Series["avKDr"].Points.Clear();
            chart1.Series["avWLr"].Points.Clear();
            chart1.Series["avKpM"].Points.Clear();
            chart1.Series["avDpM"].Points.Clear();


            for (int i = 0; i < ConfigFile.SEASON_LAST; i++)
            {
                chart1.Series["KDr"].Points.AddXY
                                ((i + 1) * 1, KDr[i]);
                chart1.Series["WLr"].Points.AddXY
                                ((i + 1) * 1, WLr[i]);
                chart1.Series["KpM"].Points.AddXY
                                ((i + 1) * 1, KpM[i]);
                chart1.Series["DpM"].Points.AddXY
                                ((i + 1) * 1, DpM[i]);
                chart1.Series["avKDr"].Points.AddXY
                                ((i + 1) * 1, avKDr);
                chart1.Series["avWLr"].Points.AddXY
                                ((i + 1) * 1, avWLr);
                chart1.Series["avKpM"].Points.AddXY
                                ((i + 1) * 1, avKpM);
                chart1.Series["avDpM"].Points.AddXY
                                ((i + 1) * 1, avDpM);

            }
            chart1.SaveImage(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, byClass + ".png"), ChartImageFormat.Png);



            //chart1.Series["AvMS"].LegendText = "AvMS";
            //chart1.Series["Played"].Points.Clear();
            //chart1.Series["Played"].LegendText = "Play";
            //int maxData1 = 0;
            //int maxData2 = 0;
            //for (int y = 0; y < data1.Count(); y++)
            //{
            //    maxData1 = Math.Max(data1[y], maxData1);
            //}
            //for (int y = 0; y < data2.Count(); y++)
            //{
            //    maxData2 = Math.Max(data2[y], maxData2);
            //}
            //if (maxData2 > (maxData1 * 1.5))
            //{
            //    for (int y = 0; y < data2.Count(); y++)
            //    {
            //        data2[y] = (int)(data2[y] / 2);
            //    }
            //    avgPlayed /= 2;
            //    chart1.Series["Played"].LegendText = "Matches" + Environment.NewLine + "div. 2";
            //    chart1.Series["Av Played"].LegendText = "Av Mat." + Environment.NewLine + "div. 2";
            //}
            //for (int i = 0; i < ConfigFile.SEASON_LAST; i++)
            //{
            //    chart1.Series["AvMS"].Points.AddXY
            //                    ((i + 1) * 1, data1[i]);
            //    chart1.Series["Played"].Points.AddXY
            //                    ((i + 1) * 1, data2[i]);
            //    chart1.Series["Av MS"].Points.AddXY((i + 1) * 1, avgMS);
            //    chart1.Series["Av Played"].Points.AddXY((i + 1) * 1, avgPlayed);
            //}
            //chart1.SaveImage(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "chart3.png"), ChartImageFormat.Png);
        }




        public static void DrawChartAvMS(Chart chart1, int[] data1, int[] data2, double avgMS, double avgPlayed)
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
                avgPlayed /= 2;
                chart1.Series["Played"].LegendText = "Matches" + Environment.NewLine + "div. 2";
                chart1.Series["Av Played"].LegendText ="Av Mat." + Environment.NewLine + "div. 2";
            }
            for (int i = 0; i < ConfigFile.SEASON_LAST; i++)
            {
                chart1.Series["AvMS"].Points.AddXY
                                ((i + 1) * 1, data1[i]);
                chart1.Series["Played"].Points.AddXY
                                ((i + 1) * 1, data2[i]);
                chart1.Series["Av MS"].Points.AddXY((i + 1) * 1, avgMS);
                chart1.Series["Av Played"].Points.AddXY((i + 1) * 1, avgPlayed);
            }
            chart1.SaveImage(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "chart3.png"), ChartImageFormat.Png);
        }


        public static Bitmap CreateBitmapImage(string sImageText, bool toPDF = false)
        {
            //sImageText = System.IO.File.ReadAllText(sImageText);
            string final = string.Empty;
            string[] lines = System.IO.File.ReadAllLines(sImageText);
            string[] type = new string[] {"   GENERAL: ", "   LIGHTS:  ", "   MEDIUMS: ", "   HEAVIES: ", "   ASSAULTS:" };
            int counter = 0;
            int season = 0;
            final += String.Format("{0,-5} {1,-7} {2,-7} {3,-7} {4,-7} {5,-7} {6,-7} {7,-7} {8,-7}",
                                "   TYPE     ", "WINS", "LOSSES", "W/Lr", "KILLS", "DEATHS", "K/Dr", "GAMES", "AV.MS")
                                + Environment.NewLine +
                                "ABSOLUTE:" + Environment.NewLine;
            foreach (string line in lines)
            {
                string[] result = line.Split(';');
                final += String.Format("{0,-5} {1,-7} {2,-7} {3,-7} {4,-7} {5,-7} {6,-7} {7,-7} {8,-7}",
                                type[counter], result[3], result[4], result[5], result[6], result[7], result[8], result[9], result[10] )
                                + Environment.NewLine;
                counter++;
                if (counter > 4)
                {
                    counter = 0;
                    season++;
                    if (season < 10)
                        final += "SEASON 0" + season.ToString() + ":" + Environment.NewLine;
                    else
                        final += "SEASON " + season.ToString() + ":" + Environment.NewLine;
                }
            }
            sImageText = final.Remove(final.TrimEnd().LastIndexOf(Environment.NewLine)); ;
            
            Bitmap objBmpImage = new Bitmap(1, 1);
            int intWidth = 0;
            int intHeight = 0;
            // Create the Font object for the image text drawing.
            Font objFont = new Font("Courier New", 12.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            // Create a graphics object to measure the text's width and height.
            Graphics objGraphics = Graphics.FromImage(objBmpImage);
            // This is where the bitmap size is determined.
            intWidth = (int)objGraphics.MeasureString(sImageText, objFont).Width;
            intHeight = (int)objGraphics.MeasureString(sImageText, objFont).Height;
            // Create the bmpImage again with the correct size for the text and font.
            objBmpImage = new Bitmap(objBmpImage, new Size(intWidth, intHeight));
            // Add the colors to the new bitmap.
            objGraphics = Graphics.FromImage(objBmpImage);
            // Set Background color
            //objGraphics.Clear(Color.White);
            objGraphics.Clear(Color.Black);
            if (toPDF)
                objGraphics.Clear(Color.White);
            objGraphics.SmoothingMode = SmoothingMode.AntiAlias;
            objGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            //objGraphics.DrawString(sImageText, objFont, new SolidBrush(Color.FromArgb(102, 102, 102)), 0, 0);
            if(toPDF)
                objGraphics.DrawString(sImageText, objFont, new SolidBrush(Color.Black), 0, 0);
            else
                objGraphics.DrawString(sImageText, objFont, new SolidBrush(Color.FromArgb(234, 234, 234)), 0, 0);
            objGraphics.Flush();
            return (objBmpImage);
        }

}
}
