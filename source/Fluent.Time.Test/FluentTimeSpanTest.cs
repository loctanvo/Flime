using System;
using NUnit.Framework;

namespace Fluent.Time.Test
{
    [TestFixture]
    public class FluentTimeSpanTest
    {
        [TestCase(1, 7)]
        [TestCase(2, 14)]
        [TestCase(3, 21)]
        [TestCase(1.5, 10.5)]
        public void Weeks_ParseCorrectly(double weeks, double expectedDays)
        {
            Assert.That(weeks.Weeks(), Is.EqualTo(TimeSpan.FromDays(expectedDays)));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(42)]
        [TestCase(4.2)]
        public void Days_ParseCorrectly(double value)
        {
            Assert.That(value.Days(), Is.EqualTo(TimeSpan.FromDays(value)));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(42)]
        [TestCase(4.2)]
        public void Hours_Integer_ParseCorrectly(double value)
        {
            Assert.That(value.Hours(), Is.EqualTo(TimeSpan.FromHours(value)));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(42)]
        [TestCase(4.2)]
        public void Minutes_ParseCorrectly(double value)
        {
            Assert.That(value.Minutes(), Is.EqualTo(TimeSpan.FromMinutes(value)));
        }

        [Test]
        public void And_AddsTheTime()
        {
            Assert.That(2.Hours().And(10.Minutes()), Is.EqualTo(TimeSpan.FromMinutes(130)));
        }
    }
}
