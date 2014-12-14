using System.Collections.Generic;
using System.Linq;

namespace Fluent.Time.Extensions
{
    public static class EnumerableExtensions
    {
        public static string SeparatedBy(this IEnumerable<string> me, string separator)
        {
            return me.Aggregate((first, second) => string.Format("{0}{1}{2}", first, separator, second));
        }
    }
}
