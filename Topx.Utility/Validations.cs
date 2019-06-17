using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Topx.Utility
{
    public class Validations
    {
        public const string DateParsing = "d-M-yyyy";
        public static bool TestForValidDate(string date)
        {
            DateTime dateTime;
            return DateTime.TryParseExact(date, DateParsing, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);
        }

        public static bool TestForValidYear(string year)
        {
            var regex = new Regex("^(19|20)\\d{2}$");
            return regex.IsMatch(year);
        }

        public static bool TestForValidFileName(string filename)
        {
            // Test op illegale chars én op spatie (wat niet mag ivm Archivematica beperking)
            return filename.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) == -1 && filename.IndexOfAny(new[] {' ', @"\"[0]}) == -1;
        }
    }
}
