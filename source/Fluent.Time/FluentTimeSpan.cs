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

        public static TimeSpan Seconds(this double seconds)
        {
            return TimeSpan.FromSeconds(seconds);
        }

        public static TimeSpan Weeks(this int weeks)
        {
            return weeks.CallDoubleVersionOf(Weeks);
        }

        public static TimeSpan Days(this int days)
        {
            return days.CallDoubleVersionOf(Days);
        }

        public static TimeSpan Hours(this int hours)
        {
            return hours.CallDoubleVersionOf(Hours);
        }

        public static TimeSpan Minutes(this int minutes)
        {
            return minutes.CallDoubleVersionOf(Minutes);
        }

        public static TimeSpan Seconds(this int seconds)
        {
            return seconds.CallDoubleVersionOf(Seconds);
        }

        public static TimeSpan And(this TimeSpan timeSpan, TimeSpan addition)
        {
            return timeSpan.Add(addition);
        }

        private static TimeSpan CallDoubleVersionOf(this int value, Func<double, TimeSpan> doubleVersion)
        {
            return doubleVersion(value);
        }
    }
}
