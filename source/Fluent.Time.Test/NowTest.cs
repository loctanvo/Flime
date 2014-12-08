using System;
using NUnit.Framework;

namespace Fluent.Time.Test
{
    [TestFixture]
    public class NowTest
    {
        [Test]
        public void Utc_Default_IsUtcNow()
        {
            Assert.That(Now.Utc, Is.EqualTo(DateTimeOffset.UtcNow).Within(1.Seconds()));
        }

        [Test]
        public void LocalTime_Default_IsLocalTime()
        {
            Assert.That(Now.LocalTime.Ticks, Is.EqualTo(DateTimeOffset.Now.Ticks).Within(1.Seconds().Ticks));
        }
    }
}
