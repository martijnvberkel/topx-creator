using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Targets;
using NLog.Windows.Forms;

namespace TOPX.UI.Classes
{
    class Logging
    {
        static void Init()
        {
            
            // var logfile = new FileTarget() { FileName = "Log_${shortdate}.txt", ArchiveEvery = FileArchivePeriod.Day, MaxArchiveFiles = 3 };
            var target = new FormControlTarget() {ControlName = "txtLogMessage", FormName = "FormLog", Append = true};

            NLog.Config.SimpleConfigurator.ConfigureForTargetLogging(target, LogLevel.Trace);
        }
    }
}
