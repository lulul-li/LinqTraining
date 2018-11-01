using System;
using System.Collections.Generic;

namespace LinqSample.YourOwnLinq
{
    internal static class YourOwnLinq
    {
        public static IEnumerable<T> YourWhere<T>(this IEnumerable<T> sources, Func<T, bool> predicate)
        {
            foreach (var source in sources)
            {
                if (predicate(source))
                {
                    yield return source;
                }
            }
        }

        public static IEnumerable<TResult> YourSelect<T, TResult>(this IEnumerable<T> sources,
            Func<T, TResult> selector)
        {
            foreach (var source in sources)
            {
                yield return selector(source);
            }
        }

        public static IEnumerable<T> YourTake<T>(IEnumerable<T> sources, int count)
        {
            var enumerator = sources.GetEnumerator();
            var index = 0;
            while (enumerator.MoveNext())
            {
                if (index >= count)
                {
                    yield break;
                }
                yield return enumerator.Current;
                index++;
            }
        }

        public static IEnumerable<T> YourSkip<T>(this IEnumerable<T> soucres, int count)
        {
            var index = 0;
            foreach (var soucre in soucres)
            {
                if (index >= count)
                {
                    yield return soucre;
                }
                index++;
            }
        }

        public static IEnumerable<T> YourTakeWhile<T>(this IEnumerable<T> sources, int count, Func<T, bool> predicate)
        {
            var index = 0;
            var enumerator = sources.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (index >= count)
                {
                    yield break;
                }
                if (predicate(enumerator.Current))
                {
                    yield return enumerator.Current;
                    index++;
                }
            }
        }

        public static IEnumerable<T> YourSkipWhile<T>(IEnumerable<T> sources, int count, Func<T, bool> predicate)
        {
            var index = 0;
            var enumerator = sources.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (index < count && predicate(enumerator.Current))
                {
                    index++;
                }
                else
                {
                    yield return enumerator.Current;
                }
            }
        }
    }
}