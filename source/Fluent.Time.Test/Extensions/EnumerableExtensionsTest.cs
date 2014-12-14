using Fluent.Time.Extensions;
using NUnit.Framework;

namespace Fluent.Time.Test.Extensions
{
    [TestFixture]
    public class EnumerableExtensionsTest
    {
        [Test]
        public void SeparatedBy_ValuesSeparatedBySeparator()
        {
            Assert.That(new []{"One", "Two", "Three"}.SeparatedBy("|"), 
                Is.EqualTo("One|Two|Three"));
        }
    }
}
