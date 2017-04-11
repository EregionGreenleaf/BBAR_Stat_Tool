using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace BBAR_Stat_Tool
{
    class PdfOps
    {
        XGraphicsState state;
        string imageSamplePath = string.Empty;
        double nextY;

        public void DrawStats(string playerName, Bitmap dataImage = null)
        {
            // Create a temporary file
            string season = ConfigFile.SEASON_LAST < 10 ? "0" + ConfigFile.SEASON_LAST.ToString() : ConfigFile.SEASON_LAST.ToString();
            nextY = 0;
            string filename = Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, playerName +
                                           "_" + season + ".pdf"); //String.Format("{0}_tempfile.pdf", Guid.NewGuid().ToString("D").ToUpper());
            using (PdfDocument pdfDocument = new PdfDocument())
            {
                pdfDocument.Info.Title = "BBAR Stat Tool's Charts";
                pdfDocument.Info.Author = "Antonino \"Eregion\" Amato";
                pdfDocument.Info.Subject = "Charts elaborated with data scraped from MWO's Leaderboard";
                pdfDocument.Info.Keywords = "MWO, Charts, Leaderboard";
                PdfPage pdfPage = pdfDocument.AddPage();
                using (XGraphics pdfGraphic = XGraphics.FromPdfPage(pdfPage))
                {
                    // Create a font
                    XFont fontTitle = new XFont("Verdana", 18, XFontStyle.Bold);
                    XFont fontText = new XFont("Adobe Garamond Pro", 12, XFontStyle.Regular);
                    //Draw the text
                    string title = playerName + "'s stats up to Season " + season;
                    pdfGraphic.DrawString(title, fontTitle, XBrushes.Black, new XRect(0, 20, pdfPage.Width, 35), XStringFormats.Center);

                    // Create demonstration pages
                    nextY = nextY + 80;
                    pdfGraphic.DrawString("Kill/Death Ratio table:", fontText, XBrushes.Black, new XRect(15, nextY, pdfPage.Width, 20), XStringFormats.TopLeft);
                    nextY += 20;
                    string filePath = Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "chart.png");
                    DrawImage(pdfGraphic, 4, filePath);

                    pdfGraphic.DrawString("Kills/Deaths per Match table:", fontText, XBrushes.Black, new XRect(15, nextY, pdfPage.Width, 20), XStringFormats.TopLeft);
                    nextY += 20;

                    filePath = Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "chart2.png");
                    DrawImage(pdfGraphic, 4, filePath);

                    pdfGraphic.DrawString("Average MS/Games Played table:", fontText, XBrushes.Black, new XRect(15, nextY, pdfPage.Width, 20), XStringFormats.TopLeft);
                    nextY += 20;

                    filePath = Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "chart3.png");
                    DrawImage(pdfGraphic, 4, filePath);

                    if (dataImage != null)
                    {
                        PdfPage pdfPageData = pdfDocument.AddPage();
                        XGraphics pdfGraphicData = XGraphics.FromPdfPage(pdfPageData);
                        DrawImage(pdfGraphicData, 15, 15, dataImage, pdfPageData);
                    }

                        // Save the document...
                    try
                    {
                        pdfDocument.Save(filename);
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show("File " + filename + " is open. Close it and try again.",
                            "PDF creation: Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1);
                    }
                }
            }
            // ...and start a viewer
            Process.Start(filename);
        }


        public void BeginBox(XGraphics gfx, int number, string title)
        {
            const int dEllipse = 15;
            XRect rect = new XRect(0, 20, 300, 200);
            if (number % 2 == 0)
                rect.X = 300 - 5;
            rect.Y = 40 + ((number - 1) / 2) * (200 - 5);
            rect.Inflate(-10, -10);
            XRect rect2 = rect;
            //rect2.Offset(this.borderWidth, this.borderWidth);
            rect2.Offset(1, 1);
            XColor black = XColor.FromKnownColor(XKnownColor.Black);
            XColor backColor = XColor.FromKnownColor(XKnownColor.Blue);
            XColor backColor2 = XColor.FromKnownColor(XKnownColor.DarkGreen);
            XPen borderPen = new XPen(black);
            gfx.DrawRoundedRectangle(new XSolidBrush(XColor.FromKnownColor(XKnownColor.Black)), rect2, new XSize(dEllipse + 8, dEllipse + 8));
            XLinearGradientBrush brush = new XLinearGradientBrush(rect, backColor, backColor2, XLinearGradientMode.Vertical);
            gfx.DrawRoundedRectangle(borderPen, brush, rect, new XSize(dEllipse, dEllipse));
            rect.Inflate(-5, -5);

            XFont font = new XFont("Verdana", 12, XFontStyle.Regular);
            gfx.DrawString(title, font, XBrushes.Navy, rect, XStringFormats.TopCenter);

            rect.Inflate(-10, -5);
            rect.Y += 20;
            rect.Height -= 20;

            this.state = gfx.Save();
            gfx.TranslateTransform(rect.X, rect.Y);
        }

        public void EndBox(XGraphics gfx)
        {
            gfx.Restore(this.state);
        }


        private void DrawImage(XGraphics gfx, int number, string imageSamplePath)
        {
            //BeginBox(gfx, number, "DrawImage (original)");
            using (XImage image = XImage.FromFile(imageSamplePath))
            {
                try
                {
                    // Left position in point
                    double x = 10; //(250 - image.PixelWidth * 72 / image.HorizontalResolution) / 2;
                    gfx.DrawImage(image, x, nextY);
                    //update next Y coordinate
                    nextY += image.PointHeight + 20;
                }
                catch (Exception exp)
                {

                }
            }

            //EndBox(gfx);
        }

        private void DrawImage(XGraphics gfx, double x, double y, Bitmap imageR, PdfPage pdfPageData)
        {
            
            using (XImage image = imageR)
            {
                XRect rectangle = new XRect();
                if (image.PointHeight + y > pdfPageData.Height || image.PointWidth + x > pdfPageData.Width)
                    rectangle = new XRect(x, y, pdfPageData.Width - x, pdfPageData.Height - y);
                else
                    rectangle = new XRect(x, y, image.PointWidth+ x, image.PointHeight +y);
                try
                {
                    gfx.DrawImage(image,rectangle);
                }
                catch (Exception exp)
                {

                }
            }
        }


    }
}