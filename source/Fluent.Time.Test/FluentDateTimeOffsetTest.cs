using Fluent.Time.Test.TestUtilities.Data;
using Fluent.Time.Test.TestUtilities.TimeHandling;
using NUnit.Framework;

namespace Fluent.Time.Test
{
    [TestFixture]
    public class FluentDateTimeOffsetTest
    {
        [Test]
        public void Ago_Default_SubstractsFromNow()
        {
        	TimeMachine.SandBox(travel =>
        	{
        	    travel.FreezeTo(Some.Time);

        	    Assert.That(2.Hours().Ago(), Is.EqualTo(Now.Utc.Subtract(2.Hours())));
        	});
        }

        [Test]
        public void FromNow_Default_AddsFromNow()
        {
            TimeMachine.SandBox(travel =>
            {
                travel.FreezeTo(Some.Time);

                Assert.That(2.Hours().FromNow(), Is.EqualTo(Now.Utc.Add(2.Hours())));
            });
        }
    }
}
