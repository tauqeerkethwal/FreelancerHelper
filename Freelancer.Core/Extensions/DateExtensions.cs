using System;
using System.Globalization;
namespace Freelancer.Core.Extensions
{
    public static class DateExtensions
    {


        public static DateTime ConvertToDateTime(this string val)
        {
            try
            {
                return Convert.ToDateTime(val);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DateTime ConvertToDateTimeDefault(this string val)
        {
            var v = DateTime.MinValue;
            if (DateTime.TryParse(val, out v))
                return v;

            return DateTime.MinValue;
        }



        public static DateTime ConvertToDateTimeDefault(this string val, string format)
        {
            var v = DateTime.MinValue;


            if (DateTime.TryParseExact(val, format,
                                   System.Threading.Thread.CurrentThread.CurrentCulture,
                                   DateTimeStyles.None,
                                   out v))
                return v;


            return DateTime.MinValue;
        }

        public static DateTime? ConvertToDateTimeDefaultNullable(this string val, string format)
        {
            var v = DateTime.MinValue;


            if (DateTime.TryParseExact(val, format,
                                   System.Threading.Thread.CurrentThread.CurrentCulture,
                                   DateTimeStyles.None,
                                   out v))
                return v;


            return null;
        }

        public static string SqlFormattedDate(this DateTime sourceDate)
        {
            string sqlFormattedDate = string.Empty;


            sqlFormattedDate = sourceDate.ToString("yyyy-MM-dd HH:mm:ss");

            return sqlFormattedDate;
        }

        public static string DisplayFormattedDateTime(this DateTime sourceDate)
        {
            string FormattedDate = string.Empty;


            FormattedDate = sourceDate.ToString("dd-MM-yyyy HH:mm:ss");

            return FormattedDate;
        }

        public static string DisplayFormattedDate(this DateTime sourceDate)
        {
            string FormattedDate = string.Empty;


            FormattedDate = sourceDate.ToString("dd-MM-yyyy");

            return FormattedDate;
        }

        public static string DisplayFormattedTime(this DateTime sourceDate)
        {
            string FormattedDate = string.Empty;


            FormattedDate = sourceDate.ToString("HH:mm");

            return FormattedDate;
        }

        public static string GetHour(this DateTime sourceDate)
        {
            string FormattedDate = string.Empty;


            FormattedDate = sourceDate.ToString("HH");

            return FormattedDate;
        }

        public static string GetMinutes(this DateTime sourceDate)
        {
            string FormattedDate = string.Empty;


            FormattedDate = sourceDate.ToString("mm");

            return FormattedDate;
        }
    }
}