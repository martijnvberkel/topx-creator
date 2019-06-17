using System.Xml.XPath;

namespace Topx.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //var connectionstring = LocalDbHelper.GetConnectionString();
            //using (var con = new SqlConnection(connectionstring))
            //{
            //    con.Open();
            //    var sqlCommandText = @"USE master þ
            //             DECLARE @kill varchar(8000) = ''; 
            //             SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), spid) + ';' 
            //             FROM master..sysprocesses  
            //             WHERE dbid = db_id('ModelTopX') 
            //             EXEC(@kill); 
            //             ALTER DATABASE ModelTopX  SET SINGLE_USER WITH ROLLBACK IMMEDIATE; 
            //             drop database ModelTopX";
            //    var sqlCommand = new SqlCommand(sqlCommandText, con);
            //    sqlCommand.ExecuteNonQuery();
            //}

            var xmldoc = new XPathDocument(@"C:\Users\Martijn\.droid6\signature_files\DROID_SignatureFile_V94.xml");
            XPathNavigator navigator = xmldoc.CreateNavigator();

            XPathNodeIterator nodes = navigator.Select("//FileFormat");

            foreach (XPathNavigator item in nodes)
            {
               var x = item.Value;
            }
        }

    }


    class Signatures
    {
        public string PUID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
