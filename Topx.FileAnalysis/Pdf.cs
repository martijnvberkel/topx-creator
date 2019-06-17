using System;
using PdfSharp.Pdf.IO;

namespace Topx.FileAnalysis
{
    public class Pdf
    {
        public static bool? IsPasswordProtected(string fileName)
        {
            try
            {
                var document = PdfReader.Open(fileName );
            }
            catch (Exception ex)
            {
                return ex.Message.StartsWith("A password is required") ? (bool?) true : null;
            }
            return false;
        }
    }
}
