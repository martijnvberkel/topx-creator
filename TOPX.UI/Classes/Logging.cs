using NLog;
using NLog.Config;
using NLog.Targets;


namespace TOPX.UI.Classes
{
    class Logging
    {
        public static void Init()
        {
            var config = new LoggingConfiguration();

            var logfile = new FileTarget() { FileName = "${specialfolder:folder=ApplicationData}/TopX/Logs/Log_${shortdate}.txt", ArchiveEvery = FileArchivePeriod.Day, MaxArchiveFiles = 3 };

            config.AddTarget("logfile", logfile);
            NLog.LogManager.Configuration = config;
        }
    }
}
