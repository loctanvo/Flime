using System;

namespace Fluent.Time
{
    public static class FluentDateTimeOffset
    {
        public static DateTimeOffset Ago(this TimeSpan ago)
        {
            return DateTimeOffset.Now.Subtract(ago);
        }
    }
}
