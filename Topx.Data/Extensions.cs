using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Topx.Data
{
    public static class Extensions
    {
        public static ICollection<Record> Clone(this ICollection<Record> records)
        {
            ICollection<Record> newRecords = new List<Record>();
            foreach (var record in records)
            {
                var newRecord = new Record();
                foreach (var sourcePropertyInfo in record.GetType().GetProperties())
                {
                    var destPropertyInfo = newRecord.GetType().GetProperty(sourcePropertyInfo.Name);

                    if (destPropertyInfo != null && destPropertyInfo.Name != "Dossiers")
                        destPropertyInfo.SetValue(newRecord, sourcePropertyInfo.GetValue(record, null), null);
                }
                newRecords.Add(record);
            }
            return newRecords;
        }
    }
}
