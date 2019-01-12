using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using Topx.Data;

namespace Topx.UnitTests.PdfCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            var testDir = @"D:\Topx_Data\TestFiles";
            using (var entities = new ModelTopX())
            {
                var dossiers = (from d in entities.Dossiers select d) .Include("Records") .ToList();
                foreach (var dossier in dossiers)
                {
                    foreach (var record in dossier.Records)
                    {
                        Create(Path.Combine(testDir, record.Bestand_Formaat_Bestandsnaam));
                    }
                }
            }
        }

        private static void Create(string fileName)
        {
            var pdf = new PdfDocument();
            pdf.Info.Title = "Test PDF";
            var pdfPage = pdf.AddPage();
            var graph = XGraphics.FromPdfPage(pdfPage);
            var font = new XFont("Verdana", 12, XFontStyle.Regular);

            var formatter = new XTextFormatter(graph);
            var layoutRectangle = new XRect(10, 10, pdfPage.Width.Point, pdfPage.Height.Point);
            formatter.DrawString(RandomString(), font, XBrushes.Black, layoutRectangle);
            
            pdf.Save(fileName);
              
        }

        private static string RandomString()
        {
            var builder = new StringBuilder();
            var size = RandomNumber() * 10000;
            for (var i = 0; i < size ; i++)
            {
                if (i % 10 == 0)
                {
                    builder.Append(" ");
                }
                if (i % 100 == 0)
                {
                    builder.Append(Environment.NewLine);
                }
                var ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * (double) RandomNumber() + 65)));
                builder.Append(ch);
            }
            
            return builder.ToString();
        }
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static double RandomNumber()
        {
            lock (syncLock)
            { // synchronize
                return random.NextDouble();
            }
        }
    }
}
