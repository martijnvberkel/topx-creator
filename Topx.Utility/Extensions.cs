using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public static string ToString(this List<string> ListOfString)
        {
            var result = string.Empty;
            foreach (var comment1 in ListOfString)
            {
                result += ", " + comment1;
            }

            return result.Substring(0, result.Length - 2);
        }
    }
}
