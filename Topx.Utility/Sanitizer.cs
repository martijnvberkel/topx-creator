using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topx.Data;

namespace Topx.Utility
{
    public class Sanitizer
    {
        public static void CheckAndFixSanityOfFieldMappings(List<FieldMapping> listFieldMappings)
        {
            var duplicatesTarget = listFieldMappings
                .GroupBy(i => i.DatabaseFieldName)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key);
            foreach (var d in duplicatesTarget)
            {
                listFieldMappings.Remove(listFieldMappings.Find(t => t.DatabaseFieldName == d));
            }

            var duplicatesSource = listFieldMappings
                .GroupBy(i => i.MappedFieldName)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key);
            foreach (var d in duplicatesSource)
            {
                listFieldMappings.Remove(listFieldMappings.Find(t => t.MappedFieldName == d));
            }
        }
    }
}
