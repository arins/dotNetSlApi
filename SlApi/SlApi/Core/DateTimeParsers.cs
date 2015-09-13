using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlApi.Core
{
    public static class DateTimeParsers
    {
        public static string ParseApiTime(string value)
        {
            try
            {
                var result = DateTime.ParseExact(value, "HH:mm", CultureInfo.CurrentCulture);
                return result.ToString("HH:mm");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("not a valid time", ex);
            }
        }

        public static string ParseApiDate(string value)
        {
            try
            {
                var result = DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.CurrentCulture);
                return result.ToString("yyyy-MM-dd");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("not a valid date", ex);
            }
        }
    }

    public static class DateTimeConverter
    {
        public static string ApiDateToString(this DateTime? date)
        {
            return date?.ApiDateToString();
        }

        public static string ApiTimeToString(this DateTime? date)
        {
            return date?.ApiTimeToString();
        }

        public static string ApiDateToString(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        public static string ApiTimeToString(this DateTime date)
        {
            return date.ToString("HH:mm");
        }
    }
}
