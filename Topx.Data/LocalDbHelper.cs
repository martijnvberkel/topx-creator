using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Channels;
using System.Threading;

namespace Topx.Data
{
    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();

        static Singleton()
        {
        }

        private Singleton()
        {
        }

        public static Singleton Instance => instance;

        public string ConnectionString { get; set; }
    }

    public class LocalDbHelper
    {
        public static string GetConnectionString()
        {
            //Thread.Sleep(10000);

            if (Singleton.Instance.ConnectionString != null)
                return Singleton.Instance.ConnectionString;  // to prevent multiple calls to GetInstanceName()

            var useCustomConnectionString = Convert.ToBoolean(ConfigurationManager.AppSettings["UseCustomConnectionString"]);
           
            if (useCustomConnectionString)
            {
                var customConnectionString = ConfigurationManager.AppSettings["CustomConnectionString"];
                if (customConnectionString == null)
                    throw new Exception("CustomConnectionString is niet geconfigureerd in de app.config.");
                Singleton.Instance.ConnectionString = customConnectionString;
                return customConnectionString;
            }
            
            string connectionString;
            var instance = GetInstanceName();
            try
            {
               connectionString = $"data source = (LocalDb)\\{instance}; initial catalog = ModelTopX; integrated security = True; MultipleActiveResultSets = True";
               // var modelTopX = new ModelTopX(connectionString);
               // modelTopX.Log.FirstOrDefault();  // Only to check if the database is accessible.
            }
            catch (Exception ex)
            {
                throw new Exception("Database kan niet worden aangemaakt of benaderd. Controleer met het commando 'SqlLocalDb i' of er een database instance bestaat. Maak eventueel een nieuwe instance aan met het commando 'sqllocaldb create TopX'. Daarvoor zijn soms administrator-rechten nodig.");
            }
            Singleton.Instance.ConnectionString = connectionString;
            return connectionString;
        }

        private static string GetInstanceName()
        {
            // Start the child process.
            var p = new Process
            {
                StartInfo =
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    FileName = "cmd.exe",
                    Arguments = "/C sqllocaldb info",
                    CreateNoWindow = true,
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
                }
            };
            // Redirect the output stream of the child process.
            p.Start();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // p.WaitForExit();
            // Read the output stream first and then wait.
            string sOutput = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            //If LocalDb is not installed then it will return that 'sqllocaldb' is not recognized as an internal or external command operable program or batch file.
            if (sOutput.Trim().Length == 0 || sOutput.Contains("not recognized"))
                throw new Exception("SqlLocalDb is niet geinstalleerd. Dat is noodzakelijk voor de TopX Creator.");
            var array = sOutput.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            return array[0];
        }

        public static bool GrantAccess(string fullPath)
        {
            //DirectoryInfo info = new DirectoryInfo(fullPath);
            //WindowsIdentity self = System.Security.Principal.WindowsIdentity.GetCurrent();
            //DirectorySecurity ds = info.GetAccessControl();
            //ds.AddAccessRule(new FileSystemAccessRule(self.Name,
            //    FileSystemRights.FullControl,
            //    InheritanceFlags.ObjectInherit |
            //    InheritanceFlags.ContainerInherit,
            //    PropagationFlags.None,
            //    AccessControlType.Allow));
            //info.SetAccessControl(ds);
            return true;
        }
        public static bool CheckDatabaseExists(SqlConnection tmpConn, string databaseName)
        {
            string sqlCreateDBQuery;
            bool result = false;

            try
            {
                sqlCreateDBQuery = string.Format("SELECT database_id FROM sys.databases WHERE Name = '{0}'", databaseName);
                using (SqlCommand sqlCmd = new SqlCommand(sqlCreateDBQuery, tmpConn))
                {
                    tmpConn.Open();
                    object resultObj = sqlCmd.ExecuteScalar();
                    int databaseID = 0;
                    if (resultObj != null)
                    {
                        int.TryParse(resultObj.ToString(), out databaseID);
                    }
                    tmpConn.Close();
                    result = (databaseID > 0);
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
    }
}
