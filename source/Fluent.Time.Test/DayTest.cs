using System;
using Fluent.Time.Test.TestUtilities.Data;
using Fluent.Time.Test.TestUtilities.TimeHandling;
using NUnit.Framework;

namespace Fluent.Time.Test
{
    [TestFixture]
    public class DayTest
    {
        [Test]
        public void Today_Utc_ReturnTodaysDate()
        {
            TimeMachine.Sandbox(Some.CultureNotUtc, time =>
            {
                time.FreezeTo(Some.Time);

                var today = Day.Today;
                var todayUtc = Now.Utc;

                Assert.That(today.Date, Is.EqualTo(todayUtc.Date));
                Assert.That(today.TimeOfDay, Is.EqualTo(TimeSpan.Zero));
                Assert.That(today.Offset, Is.EqualTo(TimeSpan.Zero));
            });            
        }

        [Test]
        public void Tomorrow_Is_TodayAddOneDay()
        {
            TimeMachine.SandBox(time =>
            {
                time.FreezeTo(Some.Time);

                var tomorrow = Day.Tomorrow;
                var today = Day.Today;

                Assert.That(tomorrow.Subtract(today), Is.EqualTo(1.Days()));
            });
        }

        [Test]
        public void Yesterday_Is_TodaySubstractOneDay()
        {
            TimeMachine.SandBox(time =>
            {
                time.FreezeTo(Some.Time);

                var yesterday = Day.Yesterday;
                var today = Day.Today;

                Assert.That(today.Subtract(yesterday), Is.EqualTo(1.Days()));
            });
        }

        [Test]
        public void DayAfterTomorrow_IsTomorrowAddedOneDay()
        {
            TimeMachine.SandBox(time =>
            {
                time.FreezeTo(Some.Time);

                var tomorrow = Day.Tomorrow;
                var afterTomorrow = Day.AfterTomorrow;

                Assert.That(afterTomorrow.Subtract(tomorrow), Is.EqualTo(1.Days()));
            });
        }

        [Test]
        public void DayBeforeYesterday_IsYesterdaySubstractedOneDay()
        {
            TimeMachine.SandBox(time =>
            {
                time.FreezeTo(Some.Time);

                var yesterday = Day.Yesterday;
                var beforeYesterday = Day.BeforeYesterday;

                Assert.That(yesterday.Subtract(beforeYesterday), Is.EqualTo(1.Days()));
            });
        }
    }
}
