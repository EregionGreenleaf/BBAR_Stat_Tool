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
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;

namespace BBAR_Stat_Tool
{
    class PdfOps
    {
        //XGraphicsState state;
        string imageSamplePath = string.Empty;
        double nextY;

        public void DrawStats(string playerName, Bitmap dataImage = null)
        {
            // Create a temporary file
            string season = ConfigFile.SEASON_LAST < 10 ? "0" + ConfigFile.SEASON_LAST.ToString() : ConfigFile.SEASON_LAST.ToString();
            nextY = 0;
            string filename = Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, playerName +
                                               "_" + season + ".pdf"); //String.Format("{0}_tempfile.pdf", Guid.NewGuid().ToString("D").ToUpper());
            try
            {

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
                            DrawImage(pdfGraphicData, 25, 10, dataImage, pdfPageData);
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
            catch
            {

            }
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
                    gfx.DrawImage(image, rectangle);
                }
                catch (Exception exp)
                {

                }
            }
        }

        public static void CreatePDFFileFromTxtFile(string textfilefullpath, string playerName)
        {
            Document doc = new Document();
            Section section = doc.AddSection();
            section.PageSetup.LeftMargin = 30;
            section.PageSetup.RightMargin = 10;

            MigraDoc.DocumentObjectModel.Font font = new MigraDoc.DocumentObjectModel.Font("Courier New", 14);
            font.Bold = true;
            font.Italic = false;
            font.Underline = Underline.None;
            Paragraph paragraph = section.AddParagraph();
            paragraph.AddFormattedText(playerName + "'s Stats up to Season " + ConfigFile.SEASON_LAST, font);


            if (new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "chart.png")).Exists)
            {
                MigraDoc.DocumentObjectModel.Shapes.Image image = section.AddImage(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "chart.png"));
                image.LockAspectRatio = true;
                image.Left = 0;
            }
            if (new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "chart2.png")).Exists)
            {
                MigraDoc.DocumentObjectModel.Shapes.Image image = section.AddImage(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "chart2.png"));
                image.LockAspectRatio = true;
                image.Left = 0;
            }
            if (new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "chart3.png")).Exists)
            {
                MigraDoc.DocumentObjectModel.Shapes.Image image = section.AddImage(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, "chart3.png"));
                image.LockAspectRatio = true;
                image.Left = 0;
            }

            //just font arrangements as you wish

            section = DataOps.PrintData(section, textfilefullpath);
            //add each line to pdf 
            //foreach (string line in textFileLines)
            //{
            //    MigraDoc.DocumentObjectModel.Font font = new MigraDoc.DocumentObjectModel.Font("Courier New", 10);
            //    font.Bold = true;

            //    Paragraph paragraph = section.AddParagraph();
            //    paragraph.AddFormattedText(line, font);

            //}


            //save pdf document
            PdfDocumentRenderer renderer = new PdfDocumentRenderer();
            renderer.Document = doc;
            renderer.RenderDocument();
            FileInfo fileName = new FileInfo(Path.Combine(ConfigFile.DIRECTORY_OUTPUT.FullName, playerName + "_" + ConfigFile.SEASON_LAST.ToString() + ".pdf"));
            FileOps.CheckFile(fileName, true);
            renderer.Save(fileName.FullName);
        }


        // ORIGINAL METHOD
        //void CreatePDFFileFromTxtFile(string textfilefullpath, string pdfsavefullpath)
        //{
        //    //first read text to end add to a string list.
        //    List<string> textFileLines = new List<string>();
        //    using (StreamReader sr = new StreamReader(textfilefullpath))
        //    {
        //        while (!sr.EndOfStream)
        //        {
        //            textFileLines.Add(sr.ReadLine());
        //        }
        //    }

        //    Document doc = new Document();
        //    Section section = doc.AddSection();

        //    //just font arrangements as you wish
        //    MigraDoc.DocumentObjectModel.Font font = new MigraDoc.DocumentObjectModel.Font("Courier New", 10);
        //    font.Bold = true;

        //    //add each line to pdf 
        //    foreach (string line in textFileLines)
        //    {
        //        Paragraph paragraph = section.AddParagraph();
        //        paragraph.AddFormattedText(line, font);

        //    }


        //    //save pdf document
        //    PdfDocumentRenderer renderer = new PdfDocumentRenderer();
        //    renderer.Document = doc;
        //    renderer.RenderDocument();
        //    renderer.Save(pdfsavefullpath);
        //}

    }
}