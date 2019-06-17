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
    }
}
