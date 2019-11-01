using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topx.Utility
{
    public static class Extensions
    {
        public static string RemoveSpaces(this string Source)
        {
            return Source.Replace(" ", "");
        }

        public static bool AllEqual(params int[] values)
        {
            if (values == null || values.Length == 0)
                return true;
            return values.All(v => v.Equals(values[0]));
        }
    }
}
