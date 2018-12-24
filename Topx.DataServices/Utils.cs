using System.IO;
using System.Xml.Serialization;

namespace Topx.DataServices
{
   public static class Utils
    {
        public static T Deserialize<T>(string toDeserialize)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var textReader = new StringReader(toDeserialize))
            {
                return (T)xmlSerializer.Deserialize(textReader);
            }
        }

        public static string Serialize<T>(this T toSerialize)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }
    }
}
