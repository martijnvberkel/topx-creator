using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topx.FileAnalysis
{
    public class Pdf
    {
        public DateTime CreationDate(Stream stream)
        {
            var str = StreamHasString(stream);
            return DateTime.MinValue;
        }
        private string StreamHasString(Stream vStream)
        {
            byte[] streamBytes = new byte[vStream.Length];

            int pos = 0;
            int len = (int)vStream.Length;
            while (pos < len)
            {
                int n = vStream.Read(streamBytes, pos, len - pos);
                pos += n;
            }

            string stringOfStream = Encoding.UTF32.GetString(streamBytes);
            if (stringOfStream.Contains("CreateDate"))
            {
                return stringOfStream;
            }
            else
            {
                return null;
            }
        }
    }
}
