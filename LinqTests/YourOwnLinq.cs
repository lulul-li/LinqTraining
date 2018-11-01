using System;
using System.Collections.Generic;

namespace LinqSample.YourOwnLinq
{
    internal static class YourOwnLinq
    {
        public static IEnumerable<TSource> YourWhere<TSource>(this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            var index = 0;

            foreach (var item in source)
            {
                if (predicate(item, index))
                {
                    yield return item;
                }
            }
        }
    }
}