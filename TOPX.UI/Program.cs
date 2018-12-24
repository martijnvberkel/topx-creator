using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using TOPX.UI.Forms;
using SimpleInjector;
using Topx.Data;
using Topx.DataServices;
using Container = SimpleInjector.Container;


namespace TOPX.UI
{
    static class Program
    {
        private static Container container;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
          
            if (Bootstrap())
            {
                Cursor.Current = Cursors.Default;
                Application.Run(container.GetInstance<TopXConverter>());
            }
            Cursor.Current = Cursors.Default;

        }

        private static bool Bootstrap()
        {
           
            container = new Container();
            var connectionstring = LocalDbHelper.GetConnectionString();
            if (string.IsNullOrEmpty(connectionstring))
            {
                MessageBox.Show("De database kon niet worden aangemaakt of gevonden. Mogelijk is deze niet geïnstalleerd. Installeer SqlLocalDB.MSI", "Database niet gevonden", MessageBoxButtons.OK);
                return false;
            }

          
            container.Register<IDataService>(() => new DataService(connectionstring), Lifestyle.Singleton);
            container.Register<TopXConverter>();
            return true;
        }
    }
}
