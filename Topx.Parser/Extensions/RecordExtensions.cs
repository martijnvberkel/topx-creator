using System;
using System.Linq;
using Topx.Data;

namespace Topx.Creator.Extensions
{
    internal static class RecordExtensions
    {
        public static bool IsElementEmpty(this Record record, string fieldNameStart)
        {
            var properties = typeof(Record).GetProperties().Where(p => p.Name.StartsWith(fieldNameStart, StringComparison.OrdinalIgnoreCase));

            foreach (var property in properties)
            {
                var value = property.GetValue(record) as string;
                if (!string.IsNullOrEmpty(value)) return false;
            }

            return true;
        }
    }
}
