using System;
using System.Globalization;
using System.Threading;

namespace Fluent.Time.Test.TestUtilities.CultureHandling
{
    public class Culture
    {
        public static void Sandbox(string cultureName, Action cultureModifyingCode)
        {
            var originalCulture = Thread.CurrentThread.CurrentCulture;
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureName);
                cultureModifyingCode();
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = originalCulture;
            }
        }
    }
}
