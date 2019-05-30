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

            var fileTarget = new FileTarget()
            {
                FileName = "${specialfolder:folder=ApplicationData}/TopX/Logs/Log_${shortdate}.txt",
                ArchiveEvery = FileArchivePeriod.Day,
                MaxArchiveFiles = 3,
                Name = "Log",
                NetworkWrites = true,
                KeepFileOpen = false,
                Layout = "${longdate} ${uppercase:${level}} ${message}"

            };

            config.AddTarget("Log", fileTarget);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Trace, fileTarget));
            NLog.LogManager.Configuration = config;
        }
    }
}
