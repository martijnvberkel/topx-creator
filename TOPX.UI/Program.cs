using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TOPX.UI.Forms;
using Unity;
using SimpleInjector;
using Topx.Data;
using Topx.DataServices;
using Unity.Policy;
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
                Application.Run(container.GetInstance<TopXConverter>());

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

            var test = new DataService(connectionstring);
            if (!test.CanConnect())
            {
                MessageBox.Show("Kan de database niet vinden.");
                return false;
            }

            container.Register<IDataService>(() => new DataService(connectionstring), Lifestyle.Singleton);
            container.Register<TopXConverter>();
            return true;
        }


    }
}
