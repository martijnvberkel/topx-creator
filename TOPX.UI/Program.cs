using System;
using System.ServiceModel.Description;
using System.Windows.Forms;
using NLog;
using TOPX.UI.Forms;
using SimpleInjector;
using Topx.Data;
using Topx.DataServices;
using Container = SimpleInjector.Container;
using TOPX.UI.Classes;
using Topx.Utility;
using PaletteDesigner;
using SimpleInjector.Lifestyles;

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
                using (ThreadScopedLifestyle.BeginScope(container))
                {
                    Application.Run(container.GetInstance<TopXConverter>());
                }
            }
            Cursor.Current = Cursors.Default;

        }

        private static bool Bootstrap()
        {
           
            container = new Container();
            container.Options.DefaultScopedLifestyle = new SimpleInjector.Lifestyles.ThreadScopedLifestyle();
            var connectionstring = LocalDbHelper.GetConnectionString();
            if (string.IsNullOrEmpty(connectionstring))
            {
                MessageBox.Show("De database kon niet worden aangemaakt of gevonden. Mogelijk is deze niet geïnstalleerd. Installeer SqlLocalDB.MSI", "Database niet gevonden", MessageBoxButtons.OK);
                return false;
            }
            Logging.Init();
            container.Register<ILogger>(LogManager.GetCurrentClassLogger);
            container.Register<IDataService>(() => new DataService(connectionstring), Lifestyle.Singleton);
            container.Register<IIOUtilities, IOUtilities>();
            container.Register<TopXConverter>(Lifestyle.Scoped);
            return true;
        }
    }
}
