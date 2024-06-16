using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryHelper
{
    public static class DateParser
    {
        public static DateTime ParseDate(string dateString)
        {
            DateTime parsedDate;
            if (DateTime.TryParse(dateString, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                return parsedDate;
            }
            throw new FormatException($"Invalid date format: {dateString}");
        }
    }
}
