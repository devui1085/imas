using IMAS.Localization.ExtensionMethod;
using System;
using System.Globalization;
using IMAS.Common.Configuration;

namespace IMAS.Common.Globalization
{
    public static class DateTimeExtension
    {
        #region Persian Calendar
        public static string ToPersianDate(this DateTime dateTime, string standardFormat = "d")
        {
            PersianCalendar pc = new PersianCalendar();
            string persianDate;

            switch (standardFormat)
            {
                case "d":
                    // Short date pattern
                    // Example: 1394/1/25
                    persianDate = $"{pc.GetYear(dateTime)}/{pc.GetMonth(dateTime)}/{pc.GetDayOfMonth(dateTime)}";
                    break;
                case "D":
                    // Long date pattern
                    // Example: یکشنبه، 17 اسفند 1393
                    persianDate =
                        $"{("FA_" + pc.GetDayOfWeek(dateTime).ToString()).Localize()}، {pc.GetDayOfMonth(dateTime)} {("FA_Month" + pc.GetMonth(dateTime)).Localize()} {pc.GetYear(dateTime)}";
                    break;
                case "f":
                    // Full date/time pattern (short time).
                    // Example: یکشنبه، 17 اسفند 1393 8:35
                    persianDate = string.Format("{0} {1} {2} {3} ساعت {4}:{5}",
                        pc.GetDayOfWeek(dateTime).ToString().Localize(),
                        pc.GetDayOfMonth(dateTime),
                        string.Format("Date_Month{0}", pc.GetMonth(dateTime)).Localize(),
                        pc.GetYear(dateTime),
                        dateTime.Hour,
                        dateTime.Minute);
                    break;
                case "g":
                    // General date/time pattern (short time).
                    // Example: 1394/1/13 - 14:45
                    persianDate =
                        $"{pc.GetYear(dateTime)}/{pc.GetMonth(dateTime)}/{pc.GetDayOfMonth(dateTime)} - {dateTime.Hour}:{dateTime.Minute}";
                    break;
                case "MMDD":
                    // Example: 6/23
                    persianDate =
                        $"{pc.GetMonth(dateTime)}/{pc.GetDayOfMonth(dateTime)}";
                    break;
                default:
                    persianDate = "";
                    break;
            }

            return persianDate;
        }

        public static string ToEstimatedDateTimeString(this DateTime dateTime)
        {
            string result = string.Empty;
            var timeDiff = (DateTime.Now - dateTime);
            var totalSeconds = (int)timeDiff.TotalSeconds;
            var totalMinutes = (int)timeDiff.TotalMinutes;
            var totalHours = (int)timeDiff.TotalHours;
            var totalDays = (int)timeDiff.TotalDays;
            int totalWeeks = totalDays / 7;
            int totalMonths = totalDays / 30;
            if (totalSeconds >= 0 && totalSeconds < 60)
            {
                result = $"{totalSeconds} {"SecondsAgo".Localize()}";
            }
            else if (totalMinutes > 0 && totalMinutes < 60)
            {
                result = $"{totalMinutes} {"MinutesAgo".Localize()}";
            }
            else if (totalHours > 0 && totalHours < 24)
            {
                result = $"{totalHours} {"HoursAgo".Localize()}";
            }
            else if (totalDays > 0 && totalDays < 7)
            {
                result = $"{totalDays} {"DaysAgo".Localize()}";
            }
            else if (totalWeeks > 0 && totalWeeks < 4)
            {
                result = $"{totalWeeks} {"WeeksAgo".Localize()}";
            }
            else if (totalMonths > 0 && totalMonths < 4)
            {
                result = $"{totalMonths} {"MonthsAgo".Localize()}";
            }
            else
            {
                result = dateTime.ToPersianDate();
            }
            return result;
        }

        public static string ToNumericPersianDateString(this DateTime dateTime, string sperator = "/")
        {
            var persianDate = "";
            var pc = new PersianCalendar();

            persianDate = $"{pc.GetYear(dateTime)}/{pc.GetMonth(dateTime)}/{pc.GetDayOfMonth(dateTime)}";
            return persianDate;
        }

        public static int GetPersianYear(this DateTime d)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(d);
        }

        public static int GetPersianMonth(this DateTime d)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetMonth(d);
        }

        #endregion


        public static int GetAge(this DateTime dateTime)
        {
            return (DateTime.Now - dateTime).Days / 365;
        }

        public static DateTime ToUtc(this DateTime localDateTime)
        {
            var sourceTimeZoneId = AppConfigurationManager.LocalSystemTimeZone;
            return TimeZoneInfo.ConvertTimeToUtc(localDateTime, sourceTimeZoneId);
        }
    }
}
