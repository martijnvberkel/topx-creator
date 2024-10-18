using System;
using Newtonsoft.Json;

namespace Topx.UnitTests.Helpers
{
    public static class Cloner
    {
        public static T DeepClone<T>(this T source)
        {
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            var serialized = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<T>(serialized);
        }
    }
}
