using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TOPX.UI.Forms;
using Unity;
using  SimpleInjector;
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
            Bootstrap();
            Application.Run(container.GetInstance<TopXConverter>());
            
        }

        private static void Bootstrap()
        {
            container = new Container();

            container.Register<IDataService>(() => new DataService(), Lifestyle.Singleton);
            
            container.Register<TopXConverter>();
        }

       
    }
}
