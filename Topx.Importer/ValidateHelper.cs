using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Topx.Importer
{
    public class ValidateHelper
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
    }
}
