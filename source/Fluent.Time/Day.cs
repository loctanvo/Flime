using System;

namespace Fluent.Time
{
    public class Day
    {
        public static DateTimeOffset Today()
        {
            var now = Now.Utc;
            var day = now.Day;
            var month = now.Month;
            var year = now.Year;
            var offset = now.Offset;

            return new DateTimeOffset(new DateTime(year, month, day), offset);
        }

        public static DateTimeOffset Tomorrow()
        {
            return Today().Add(1.Days());
        }

        public static DateTimeOffset Yesterday()
        {
            return Today().Subtract(1.Days());
        }

        public static DateTimeOffset AfterTomorrow()
        {
            return Tomorrow().Add(1.Days());
        }

        public static DateTimeOffset BeforeYesterday()
        {
            return Yesterday().Subtract(1.Days());
        }
    }
}
