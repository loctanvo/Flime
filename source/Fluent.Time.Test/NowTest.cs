using System;
using System.Threading;
using Fluent.Time.Test.TestUtilities.CultureHandling;
using Fluent.Time.Test.TestUtilities.Data;
using Fluent.Time.Test.TestUtilities.TimeHandling;
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
        public void LocalTime_EqualsToUtcButDifferInTimeZone()
        {
            const string cultureWithTimeOffsetComparedToUtc = "nb-NO";
            Culture.Sandbox(cultureWithTimeOffsetComparedToUtc, () =>
                TimeMachine.SandBox(travel =>
                {
                    travel.FreezeTo(Some.Time);

                    var utc = Now.Utc;
                    var local = Now.LocalTime;

                    Assert.That(local, Is.EqualTo(utc));
                    Assert.That(local.Offset, Is.Not.EqualTo(utc.Offset));
                    Assert.That(local.Ticks, Is.Not.EqualTo(utc.Ticks));
                }));
        }

        [Test]
        public void Of_UtcKind_ReturnsUtcKind()
        {
            var utc = Now.Of(Kind.Utc);

            Assert.That(utc.Offset, Is.EqualTo(TimeSpan.Zero));
        }

        [Test]
        public void Of_LocalKind_ReturnsLocalTime()
        {
            const string cultureWithOffsetNotZero = "nb-NO";
            TimeMachine.Sandbox(cultureWithOffsetNotZero, time =>
            {
                time.FreezeTo(Some.Time);
                var result = Now.Of(Kind.Local);
                var localTime = Now.LocalTime;

                Assert.That(result.Ticks, Is.EqualTo(localTime.Ticks));
                Assert.That(result.Offset, Is.EqualTo(localTime.Offset));
            });
        }

        [Test]
        public void Of_UnknownKind_ThrowsException()
        {
            const int unknownKind = 42;

            Assert.That(() => Now.Of((Kind)unknownKind), Throws
                .ArgumentException
                .With
                .Message
                .EqualTo("Kind with value 42 is not supported. Valid values are: Utc|Local"));
        }

        [Test]
        public void FreezeUtcTo_GivenTime_AlwaysReturnsGivenTime()
        {
            Now.FreezeUtcTo(Some.Time);

            Thread.Sleep(0.5.Seconds());

            Assert.That(Now.Utc, Is.EqualTo(Some.Time));
        }
    }
}
