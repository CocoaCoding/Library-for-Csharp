using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hinzberg.Helper.Parser
{
    public static class DateTimeParser
    {
        /// <summary>
        /// Creates DateTime from a YYYY-MM string
        /// Sample "2019-02"
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ParseDateTimeFromYYYYMMString(string value)
        {
            DateTime dt = new DateTime();
            if (value.Length == 7 && value.Substring(4, 1) == "-")
            {
                string yearPart = value.Substring(0, 4);
                string monthPart = value.Substring(5, 2);
                int year;
                int month;
                if (int.TryParse(monthPart, out month) && int.TryParse(yearPart, out year))
                {
                    return new DateTime(year, month, 1);
                }
            }
            throw new InvalidOperationException("Invalid Format in String");
        }

        /// <summary>
        /// Creates DateTime from a YYYY-MM string
        /// Sample "2019-02-01"
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ParseDateTimeFromYYYYMMDDString(string value)
        {
            DateTime dt = new DateTime();
            if (value.Length == 10 && value.Substring(4, 1) == "-" && value.Substring(7, 1) == "-")
            {
                string yearPart = value.Substring(0, 4);
                string monthPart = value.Substring(5, 2);
                string dayPart = value.Substring(8, 2);
                int year;
                int month;
                int day;
                if (int.TryParse(monthPart, out month) && int.TryParse(yearPart, out year) && int.TryParse(dayPart, out day))
                {
                    return new DateTime(year, month, day);
                }
            }
            throw new InvalidOperationException("Invalid Format in String");
        }
    }
}
