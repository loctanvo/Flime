using Fluent.Time.Test.TestUtilities.Data;
using Fluent.Time.Test.TestUtilities.TimeHandling;
using NUnit.Framework;

namespace Fluent.Time.Test
{
    [TestFixture]
    public class ClockTest
    {
        [Test]
        public void OClock_NotSpecified_ReturnsTimeToday()
        {
            TimeMachine.SandBox(time =>
            {
                time.FreezeTo(Some.Time);

                var twoOClock = 2.OClock();

                Assert.That(twoOClock.TimeOfDay.Hours, Is.EqualTo(2));
                Assert.That(twoOClock.TimeOfDay.Minutes, Is.EqualTo(0));
                Assert.That(twoOClock.TimeOfDay.Seconds, Is.EqualTo(0));
                Assert.That(twoOClock.TimeOfDay.Milliseconds, Is.EqualTo(0));
                Assert.That(twoOClock.Date, Is.EqualTo(Day.Today.Date));
            });
        }

        [Test]
        public void OClock_DateSpecified_ReturnsTimeOfThatDate()
        {
            TimeMachine.SandBox(time =>
            {
                time.FreezeTo(Some.Time);

                var twoOClock = 2.OClock(Day.Yesterday);

                Assert.That(twoOClock.TimeOfDay.Hours, Is.EqualTo(2));
                Assert.That(twoOClock.TimeOfDay.Minutes, Is.EqualTo(0));
                Assert.That(twoOClock.TimeOfDay.Seconds, Is.EqualTo(0));
                Assert.That(twoOClock.TimeOfDay.Milliseconds, Is.EqualTo(0));
                Assert.That(twoOClock.Date, Is.EqualTo(Day.Yesterday.Date));
            });
        }
    }
}
