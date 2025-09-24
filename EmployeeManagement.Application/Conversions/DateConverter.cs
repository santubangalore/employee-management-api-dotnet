using System.Globalization;

namespace EmployeeManagement.Application.Conversions
{
    internal class DateConverter
    {
        public static DateTime ReturnTimeOnServer(DateTime clientString)
        {
            string format = @"dd/MM/yyyy H:m:s zzz";

            try
            {

                TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("Indian Standard Time");

                DateTime date2 = TimeZoneInfo.ConvertTime(clientString, tz);
                return date2;
            }
            catch (FormatException)
            {
                return DateTime.MinValue;
            }
        }
    }
}
