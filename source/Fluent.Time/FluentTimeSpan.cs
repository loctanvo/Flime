using System;

namespace Fluent.Time
{
    public static class FluentTimeSpan
    {
        public static TimeSpan Weeks(this double weeks)
        {
            return TimeSpan.FromDays(weeks * 7);
        }

        public static TimeSpan Days(this double days)
        {
            return TimeSpan.FromDays(days);
        }

        public static TimeSpan Hours(this double hours)
        {
            return TimeSpan.FromHours(hours);
        }

        public static TimeSpan Minutes(this double minutes)
        {
            return TimeSpan.FromMinutes(minutes);
        }

        public static TimeSpan Weeks(this int weeks)
        {
            return weeks.Double().Weeks();
        }

        public static TimeSpan Days(this int days)
        {
            return days.Double().Days();
        }

        public static TimeSpan Hours(this int hours)
        {
            return hours.Double().Hours();
        }

        public static TimeSpan Minutes(this int minutes)
        {
            return minutes.Double().Minutes();
        }

        public static TimeSpan And(this TimeSpan timeSpan, TimeSpan addition)
        {
            return timeSpan.Add(addition);
        }

        private static double Double(this int value)
        {
            return value;
        }
    }
}
