using LinqTests;
using System;
using System.Collections.Generic;

namespace LinqSample.WithoutLinq
{
    internal static class WithoutLinq
    {
        public static IEnumerable<Product> Find(List<Product> products)
        {
            foreach (var product in products)
            {
                if (product.Price >= 200 && product.Price <= 500)
                {
                    yield return product;
                }
            }
        }

        public static IEnumerable<T> Find<T>(IEnumerable<T> products, Func<T, bool> predicate)
        {
            foreach (var product in products)
            {
                if (predicate(product))
                {
                    yield return product;
                }
            }
        }

        public static IEnumerable<T> Find<T>(IEnumerable<T> sources, Func<T, int, bool> predicate)
        {
            var index = 0;
            foreach (var source in sources)
            {
                if (predicate(source, index))
                {
                    yield return source;
                }
                index++;
            }
        }
    }
}