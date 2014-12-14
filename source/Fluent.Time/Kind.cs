using System;

namespace Fluent.Time
{
    public interface IKindBasedNow
    {
        DateTimeOffset Now { get; }
    }

    public class Utc : IKindBasedNow
    {
        public DateTimeOffset Now { get { return Time.Now.Utc; } }
    }

    public class Local : IKindBasedNow
    {
        public DateTimeOffset Now { get { return Time.Now.LocalTime; } }
    }
}
