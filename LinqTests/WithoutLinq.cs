using System;
using System.Collections.Generic;
using System.Linq;
using LinqTests;

namespace LinqSample.WithoutLinq
{
    internal static class WithoutLinq
    {
        public static bool YourAll<T>(this IEnumerable<T> sources, Func<T, bool> func)
        {
            using (var enumerator = sources.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (!func(enumerator.Current))
                    {
                        return false;
                    }
                }
            }
            
            return true;
        }

        public static bool YourAny<T>(this IEnumerable<T> sources, Func<T, bool> func)
        {
            var enumerator = sources.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (func(enumerator.Current))
                {
                    return true;
                }
            }
            return false;
        }
    }
}