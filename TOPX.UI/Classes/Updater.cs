using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoUpdaterDotNET;

namespace TOPX.UI.Classes
{
    public class Updater
    {
        public static void InitAutoUpdater()
        {
            AutoUpdater.OpenDownloadPage = false;
            AutoUpdater.ShowSkipButton = false;
            AutoUpdater.ShowRemindLaterButton = true;
            AutoUpdater.AppTitle = "TopX Creator";
            AutoUpdater.LetUserSelectRemindLater = true;
            AutoUpdater.Start("https://mvbworks.com/downloads/version.xml");
        }
    }
}
