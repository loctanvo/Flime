using System;

namespace Fluent.Time
{
    public static class DateTimeProvider
    {
        private static Func<DateTimeOffset> _now;
        private static Func<DateTimeOffset> _utcNow;

        static DateTimeProvider()
        {
            Reset();
        }

        public static void Reset()
        {
            _now = () => DateTimeOffset.Now;
            _utcNow = () => DateTimeOffset.UtcNow;
        }

        public static DateTimeOffset Now => _now();
        public static DateTimeOffset UtcNow => _utcNow();

        public static void FreezeNow(DateTimeOffset now)
        {
            _now = () => now;
        }

        public static void FreezeUtcNow(DateTimeOffset utcNow)
        {
            _utcNow = () => utcNow;
        }
    }
}
