using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using LinqTests;

namespace LinqSample.YourOwnLinq
{
    internal static class YourOwnLinq
    {
        public static bool MyAll<T>(this List<T> sources, Func<T, bool> func)
        {
            foreach (var s in sources)
            {
                if (!func(s)) return false;
            }

            return true;
        }

        public static bool MyAny<T>(this IEnumerable<T> sources, Func<T, bool> func)
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

        public static T MySingle<T>(IEnumerable<T> sources, Func<T, bool> func)
        {
            var enumerator = sources.GetEnumerator();
            var index = 1;
            while (enumerator.MoveNext())
            {
                if (func(enumerator.Current))
                {
                    if (index > 1)
                    {
                        throw new InvalidOperationException();
                    }

                    var result = enumerator.Current;
                    index++;
                }
            }
            throw new InvalidOperationException();
        }

        public static IEnumerable<T> MyDistinct<T>(IEnumerable<T> resouces)
        {
            var result = new HashSet<T>();
            var enumerator = resouces.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (result.Add(enumerator.Current))
                {
                    yield return enumerator.Current;
                }
            }



        }
    }
}