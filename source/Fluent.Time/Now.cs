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

        public static DateTimeOffset OfKind<T>() where T:IKindBasedNow, new()
        {
            return new T().Now;
        }

        public static DateTimeOffset Utc
        {
            get {return _utcNow();}
        }

        public static DateTimeOffset LocalTime
        {
            get { return _utcNow().ToLocalTime(); }
        }

        public static void Reset()
        {
            _utcNow = () => DateTimeOffset.UtcNow;
        }

        public static void FreezeUtcTo(DateTimeOffset utcNow)
        {
            _utcNow = () => utcNow;
        }

        public static void FreezeLocalTimeTo(DateTimeOffset localTimeNow)
        {
            _utcNow = localTimeNow.ToUniversalTime;
        }
    }
}
