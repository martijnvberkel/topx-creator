using System;
using System.Globalization;
using System.Linq;

namespace Topx.Utility
{
    public class StringUtilities
    {
        public static int CheckForSystemCharacters(string str)
        {
            for (var index = 0; index < str.Length; index++)
            {
                var ch = str[index];
                if (ch < 32)
                    return index;
            }

            return 0;
        }
    }
}
