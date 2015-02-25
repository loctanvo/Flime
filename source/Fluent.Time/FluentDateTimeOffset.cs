using System;

namespace Fluent.Time
{
    public static class FluentDateTimeOffset
    {
        public static DateTimeOffset Ago(this TimeSpan ago)
        {
            return Now.Utc.Subtract(ago);
        }

        public static DateTimeOffset FromNow(this TimeSpan fromNow)
        {
            return Now.Utc.Add(fromNow);
        }
    }
}
