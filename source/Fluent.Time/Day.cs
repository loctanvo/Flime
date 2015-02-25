using System;

namespace Fluent.Time
{
    public class Day
    {
        public static DateTimeOffset Today
        {
            get
            {
                var now = Now.Utc;
                var day = now.Day;
                var month = now.Month;
                var year = now.Year;
                var offset = now.Offset;

                return new DateTimeOffset(new DateTime(year, month, day), offset);
            }
        }

        public static DateTimeOffset Tomorrow
        {
            get { return Today.Add(1.Days()); }
        }

        public static DateTimeOffset Yesterday
        {
            get { return Today.Subtract(1.Days()); }
        }

        public static DateTimeOffset AfterTomorrow
        {
            get { return Tomorrow.Add(1.Days()); }
        }

        public static DateTimeOffset BeforeYesterday
        {
            get { return Yesterday.Subtract(1.Days()); }
        }
    }
}
