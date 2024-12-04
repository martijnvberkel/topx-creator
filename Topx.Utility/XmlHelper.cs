using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using Topx.Data.DTO;

namespace Topx.Utility
{
    public class XmlHelper
    {
        public StringBuilder ValidationErrors = new StringBuilder();

        public string GetXmlStringFromObject(RIP.recordInformationPackage recordinformationPackage)
        {
            string xmlstreamActual;
            using (var writer = new StringWriter())
            {
                var serializer = new XmlSerializer(typeof(RIP.recordInformationPackage));
                serializer.Serialize(writer, recordinformationPackage);
                writer.Flush();
                xmlstreamActual = writer.ToString();
            }
            ValidateXmlString(xmlstreamActual);
            return xmlstreamActual;
        }

        public void ValidateXmlString(string xmlstring)
        {
            Assembly assembly = GetType().Assembly;

            var resourceStreamRIP = assembly.GetManifestResourceStream("Topx.Utility.Resources.RIP_v0.3.xsd");
            var resourceStreamTopX = assembly.GetManifestResourceStream("Topx.Utility.Resources.topx-2.3_0.xsd");
            var schema = new XmlSchemaSet();
            schema.Add("http://www.nationaalarchief.nl/RIP/v0.3", new XmlTextReader(resourceStreamRIP));
            schema.Add("http://www.nationaalarchief.nl/ToPX/v2.3", new XmlTextReader(resourceStreamTopX));

            XDocument xdoc = XDocument.Parse(xmlstring);

            xdoc.Validate(schema, ValidationEventHandler);
        }

        private void ValidationEventHandler(dynamic sender, ValidationEventArgs e)
        {
            XmlSeverityType type = XmlSeverityType.Warning;
            if (Enum.TryParse<XmlSeverityType>("Error", out type))
            {
                if (type == XmlSeverityType.Error) ValidationErrors.AppendLine (e.Message + Environment.NewLine + sender.Parent);
            }
        }
    }
}
