using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace Topx.Interface
{
    public class ResourceHelper
    {
        public List<TopX_AdditionalParameters> GetTopX_TMLO()
        {
             Assembly assembly = GetType().Assembly;

            var resourceStream = assembly.GetManifestResourceStream("Topx.Interface.Resources.TMLO_Mapping.json");

            string resource;

            using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
            {
                resource = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<List<TopX_AdditionalParameters>>(resource);
        }
    }
}
