using System;
using Fluent.Time.Test.TestUtilities.CultureHandling;

namespace Fluent.Time.Test.TestUtilities.TimeHandling
{
    public class TimeMachine
    {
        private TimeMachine()
        {
        }

        public static void Sandbox(string cultureName, Action<TimeMachine> timeTravellingCode)
        {
            Culture.Sandbox(cultureName, () => SandBox(timeTravellingCode));
        }

        public static void SandBox(Action<TimeMachine> timeTravellingCode)
        {
            try
            {
                var timeMachine = new TimeMachine();
                timeTravellingCode(timeMachine);
            }
            finally
            {
                Now.Reset();
            }
        }

        public TimeMachine FreezeTo(DateTimeOffset time)
        {
            Now.FreezeUtcTo(time);
            return this;
        }

        public TimeMachine Forward(TimeSpan timeSpan)
        {
            Now.FreezeUtcTo(Now.Utc.Add(timeSpan));
            return this;
        }

        public TimeMachine Backward(TimeSpan timeSpan)
        {
            Now.FreezeUtcTo(Now.Utc.Subtract(timeSpan));
            return this;
        }
    }
}
