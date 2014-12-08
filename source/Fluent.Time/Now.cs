using System;

namespace Fluent.Time
{
    public static class Now
    {
        private static Func<DateTimeOffset> _now;
        private static Func<DateTimeOffset> _utcNow;

        static Now()
        {
            Reset();
        }

        public static void Reset()
        {
            _now = () => DateTimeOffset.Now;
            _utcNow = () => DateTimeOffset.UtcNow;
        }

        public static DateTimeOffset LocalTime => _now();
        public static DateTimeOffset Utc => _utcNow();
    }
}
