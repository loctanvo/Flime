using System;
using System.Threading;
using Fluent.Time.Test.TestUtilities.Data;
using NUnit.Framework;

namespace Fluent.Time.Test
{
    [TestFixture]
    public class NowTest
    {
        [TearDown]
        public void CleanUp()
        {
            Now.Reset();
        }

        [Test]
        public void Utc_Default_IsUtcNow()
        {
            Assert.That(Now.Utc, Is.EqualTo(DateTimeOffset.UtcNow).Within(1.Seconds()));
        }

        [Test]
        public void FreezeUtcTo_GivenTime_AlwaysReturnsGivenTime()
        {
            Now.FreezeTo(Some.Time);

            Thread.Sleep(0.5.Seconds());

            Assert.That(Now.Utc, Is.EqualTo(Some.Time));
        }
    }
}
