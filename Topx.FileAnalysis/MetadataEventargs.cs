using System;

namespace Topx.FileAnalysis
{
    public class MetadataEventargs : EventArgs
    {
        public int Progress;

        public MetadataEventargs(int progress)
        {
            Progress = progress;
        }

        public int GetProgress()
        {
            return Progress;
        }
    }
}