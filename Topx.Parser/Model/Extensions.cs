using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Topx.Parser.Model
{
    public static class Extensions
    {
        public static string Serialize<T>(this T value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            try
            {
                var xmlserializer = new XmlSerializer(typeof(T));
                var stringWriter = new StringWriter();
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    xmlserializer.Serialize(writer, value);
                    return stringWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }
        
        public static string GetZaakNummerWithYear(string zaaknummer)
        {
            if (zaaknummer.Length > 16 || zaaknummer.Length < 14)
                throw new Exception($"Zaaknummer heeft een afwijkend format: {zaaknummer}");

            var array = zaaknummer.Split("-"[0]);
            return array[0] + "-" + array[1] + "-" + "19" + array[2];
        }
    }

}


