using System;

namespace Topx.FileAnalysis
{
    public  class EventCounter
    {
        public int DossiersProgress;
        public int DossiersCount;
        public bool DroidStarted;
        public int TotalRecordsIdentified;
        public bool IsReady;
    }
    public class MetadataEventargs : EventArgs
    {
        public EventCounter Eventcounter = new EventCounter();
      
        public MetadataEventargs(bool droidStarted)
        {
           Eventcounter.DroidStarted = droidStarted;
        }
       
        public EventCounter GetProgress()
        {
            return Eventcounter;
        }
    }
}