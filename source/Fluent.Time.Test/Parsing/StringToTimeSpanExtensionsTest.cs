using System;
using Fluent.Time.Parsing;
using NUnit.Framework;

namespace Fluent.Time.Test.Parsing
{
    [TestFixture]
    public class StringToTimeSpanExtensionsTest
    {
        [TestCase("1.Millisecond", 1)]
        [TestCase("1.milliseconds", 1)]
        [TestCase("1.Milliseconds", 1)]
        [TestCase("42.millisecond", 42)]
        [TestCase("42.Milliseconds", 42)]
        public void ToTimeSpan_ValidMilliseconds_ParseCorrectly(string input, int milliseconds)
        {
            AssertEquals(input, milliseconds.Milliseconds());
        }
        
        [TestCase("1.Second", 1)]
        [TestCase("1.second", 1)]
        [TestCase("1.Seconds", 1)]
        [TestCase("42.second", 42)]
        [TestCase("42.Seconds", 42)]
        public void ToTimeSpan_ValidSeconds_ParseCorrectly(string input, int seconds)
        {
            AssertEquals(input, seconds.Seconds());
        }

        private static void AssertEquals(string s, TimeSpan expected)
        {
            Assert.That(s.ToTimeSpan(), Is.EqualTo(expected));
        }
    }
}
