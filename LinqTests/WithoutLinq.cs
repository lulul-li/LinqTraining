using System;
using System.Collections.Generic;
using LinqTests;

namespace LinqSample.WithoutLinq
{
    internal static class WithoutLinq
    {
        public static IEnumerable<Product> Find(IEnumerable<Product> products, Predicate<Product> p)
        {
            foreach (var product in products)
            {
                if (p(product))
                {
                    yield return product;
                }
            }
        }

        public static IEnumerable<Employee> more30(IEnumerable<Employee> employees, Func<Employee, bool> f)
        {
            foreach (var employee in employees)
            {
                if (f(employee))
                {
                    yield return employee;
                }
            }
        }

        public static IEnumerable<T> skip<T>(this IEnumerable<T> sources, int i)
        {
            var j = 0;
            foreach (var s in sources)
            {
                if (j >= i)
                {
                    yield return s;
                }
                j++;
            }
        }

        internal static IEnumerable<T> Find<T>(this IEnumerable<T> employees, Func<T, int, bool> p)
        {
            var index = 0;
            foreach (var employee in employees)
            {
                if (p(employee, index))
                {
                    yield return employee;
                }

                index++;
            }
        }

        public static IEnumerable<T> YourWhere<T>(this IEnumerable<T> sources, Func<T, bool> func)
        {
            var index = 0;
            foreach (var s in sources)
            {
                if (func(s))
                {
                    yield return s;
                }
                index++;
            }
        }

        public static IEnumerable<TT> YourSelect<T, TT>(this IEnumerable<T> sources, Func<T, TT> func)
        {
            foreach (var s in sources)
            {
                yield return func(s);
            }
        }

        public static IEnumerable<T> Ytake<T>(this IEnumerable<T> sources, int i)
        {
            var index = 0;
            foreach (var source in sources)
            {
                if (index < i)
                {
                    yield return source;
                }
                index++;
            }
        }
    }
}