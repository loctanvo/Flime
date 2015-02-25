using System;

namespace Fluent.Time
{
    public class Now
    {
        private static Func<DateTimeOffset> _utcNow;

        static Now()
        {
            Reset();
        }

        public static DateTimeOffset Utc
        {
            get {return _utcNow();}
        }

        public static void Reset()
        {
            _utcNow = () => DateTimeOffset.UtcNow;
        }

        public static void FreezeTo(DateTimeOffset utcNow)
        {
            _utcNow = () => utcNow;
        }
    }
}
