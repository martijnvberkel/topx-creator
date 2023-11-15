using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Topx.Utility
{
    public class Validations
    {
        public const string DateParsing = "d-M-yyyy";
        public const string ForbiddenCharsInFileName = @",<>:”/\|?@#$%^&*()[]{}+';"" ";
        public static readonly string[] ForbiddenFileNames = { "CON", "PRN", "AUX", "NUL", 
                                                "COM1","COM2","COM3","COM4","COM5","COM6","COM7","COM8","COM9", 
                                                "LPT1","LPT2","LPT3","LPT4","LPT5","LPT6","LPT7","LPT8","LPT9"};

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

        public static string GetIllegalCharsInFileName(string filename)
        {
            var countPoints = filename.Count(t => t == '.');
            if (countPoints > 1)
                return ".";

            // Test op illegale chars 
            var position = filename.IndexOfAny(ForbiddenCharsInFileName.ToCharArray());
            if (position != -1)
                return filename[position].ToString();
            
            if (ForbiddenFileNames.Contains(filename))            
                return filename;
            
            return string.Empty;
        }

        public static bool TestForFileExtension(string filename)
        {
            var delimiters = filename.Count(t => t == '.');
            return delimiters > 0;
        }
    }
}
