using System;

namespace Fluent.Time
{
    public static class Clock
    {
        public static DateTimeOffset OClock(this int hour)
        {
            return hour.OClock(Day.Today);
        }

        public static DateTimeOffset OClock(this int hour, DateTimeOffset date)
        {
            return new DateTimeOffset(date.Year,date.Month,date.Day,hour, 0,0, date.Offset);
        }
    }
}
