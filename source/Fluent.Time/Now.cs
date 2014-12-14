using System;
using Fluent.Time.Extensions;

namespace Fluent.Time
{
    public class Now
    {
        private static Func<DateTimeOffset> _utcNow;

        static Now()
        {
            Reset();
        }

        public static DateTimeOffset Of(Kind kind)
        {
            if (kind == Kind.Utc)
            {
                return Utc;
            }
            if (kind == Kind.Local)
            {
                return LocalTime;
            }

            throw new ArgumentException(string
                .Format("Kind with value {0} is not supported. Valid values are: {1}",
                    kind,
                    Enum.GetNames(typeof (Kind)).SeparatedBy("|")));
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
