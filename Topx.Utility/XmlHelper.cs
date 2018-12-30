using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Topx.Data.DTO;

namespace Topx.Utility
{
    public class XmlHelper
    {
        public static string GetXmlStringFromObject(RIP.recordInformationPackage recordinformationPackage, int maxSize = 0)
        {
            string xmlstreamActual;
            using (var writer = new StringWriter())
            {
                var serializer = new XmlSerializer(typeof(RIP.recordInformationPackage));
                serializer.Serialize(writer, recordinformationPackage);
                writer.Flush();
                xmlstreamActual = writer.ToString();
            }
            return maxSize == 0 ? xmlstreamActual : xmlstreamActual.Substring(0, maxSize);

        }
    }
}
