using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetOffice.WordApi;


namespace Topx.FileAnalysis
{
    public class Office
    {
        public static bool? IsPasswordProtected(string fileName)
        {
            switch (Path.GetExtension(fileName))
            {
                case ".doc":
                case ".docx":
                    {
                        return IsWordDocPasswordProtected(fileName);
                    }
                case ".xls":
                case ".xlsx":
                    {
                        return IsExcelPasswordProtected(fileName);
                    }

                default:
                    return false;
            }
        }

        private static bool? IsWordDocPasswordProtected(string fileName)
        {
            using (var wordApplication = new NetOffice.WordApi.Application())
            {
                try
                {
                    // Attempt to open existing document. If document is not password protected then 
                    // passwordDocument parameter is simply ignored. If document is password protected
                    // then an error is thrown and caught by the catch clause the follows, unless 
                    // password is equal to "#$nonsense@!"!                              
                    Document newDocument = wordApplication.Documents.Open(fileName, confirmConversions: false, addToRecentFiles: false, readOnly: true, passwordDocument: "#$nonsense@!");

                    // read text of document
                    string text = newDocument.Content.Text;
                }
                catch (Exception e)
                {
                    var inner = e.InnerException;
                    if (inner?.InnerException != null)
                    {
                        inner = inner.InnerException;
                        string sErrorMessage = inner.Message;

                        if (sErrorMessage.StartsWith("The password is incorrect") || sErrorMessage.StartsWith("Het wachtwoord is onjuist"))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                return false;
            }
        }
        private static bool? IsExcelPasswordProtected(string fileName)
        {
            using (var exceldApplication = new NetOffice.ExcelApi.Application())
            {
                try
                {
                   // exceldApplication.Visible = false;
                    //exceldApplication.show
                   
                    //var newWorkbook = exeldApplication.Workbooks.Open(fileName, false, true, string.Empty, "test" );
                    var newWorkbook = exceldApplication.Workbooks.Open(fileName, null, null,null, password:"' ");

                    // read text of document
                    string text = newWorkbook.Sheets[0].ToString();
                }
                catch (Exception e)
                {
                    var inner = e.InnerException;
                    if (inner?.InnerException != null)
                    {
                        inner = inner.InnerException;
                        string sErrorMessage = inner.Message;

                        if (sErrorMessage.StartsWith("The password is incorrect") || sErrorMessage.StartsWith("Het wachtwoord is onjuist"))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                return false;
            }
        }
    }
}
