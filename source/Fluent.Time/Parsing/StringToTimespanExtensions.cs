using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Fluent.Time.Parsing
{
    public static class StringToTimespanExtensions
    {
        private static readonly IDictionary<string, Func<int, TimeSpan>> Parsers =
            new Dictionary<string, Func<int, TimeSpan>>
            {
                {@"^\d+\.[mM]illi[sS]econds?$", @int => @int.Milliseconds()},
                {@"^\d+\.[sS]econds?$", @int => @int.Seconds()}
            };

        public static TimeSpan ToTimeSpan(this string input)
        {
            var parser = Parsers.FirstOrDefault(p => Regex.IsMatch(input, p.Key));
            var integer = int.Parse(input.Split('.').First());
            return parser.Value(integer);
        }
    }
}
