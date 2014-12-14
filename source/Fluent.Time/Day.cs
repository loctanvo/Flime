using System;

namespace Fluent.Time
{
    public class Day
    {
        public static DateTimeOffset Today<T>() where T : IKindBasedNow, new()
        {
            var now = Now.OfKind<T>();
            var day = now.Day;
            var month = now.Month;
            var year = now.Year;
            var offset = now.Offset;

            return new DateTimeOffset(new DateTime(year, month, day), offset);
        }

        public static DateTimeOffset Tomorrow<T>() where T : IKindBasedNow, new()
        {
            return Today<T>().Add(1.Days());
        }

        public static DateTimeOffset Yesterday<T>() where T: IKindBasedNow, new()
        {
            return Today<T>().Subtract(1.Days());
        }

        public static DateTimeOffset AfterTomorrow<T>() where T : IKindBasedNow, new()
        {
            return Tomorrow<T>().Add(1.Days());
        }

        public static DateTimeOffset BeforeYesterday<T>() where T: IKindBasedNow, new()
        {
            return Yesterday<T>().Subtract(1.Days());
        }
    }
}
