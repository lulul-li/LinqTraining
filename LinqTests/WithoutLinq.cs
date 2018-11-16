using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
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
        public static IEnumerable<T> Whileskip<T>(this IEnumerable<T> sources, int i, Func<T, bool> p)
        {
            var enumerator = sources.GetEnumerator();
            var index = 0;
            while (enumerator.MoveNext())
            {
                if (index < i && p(enumerator.Current))
                {
                    index++;
                }
                else
                {
                    yield return enumerator.Current;
                }
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

        public static IEnumerable<T> YTakeWhile<T>(IEnumerable<T> sources, int i, Func<T, bool> P)
        {
            var index = 0;
            foreach (var source in sources)
            {
                if (index >= i)
                {
                    yield break;
                }

                if (P(source))
                {

                    yield return source;
                    index++;
                }
            }
        }

        public static IEnumerable<int> YourGroup<T>(IEnumerable<T> employees, int i, Func<T, int> func)
        {
            var index = 0;
            var num = 0;
            var ints = new List<int>();
            
            foreach (var s in employees)
            {
                num += func(s);
                index++;
                if (index % i != 0)
                {
                    continue;
                }

                ints.Add(num);
                index = 0;
                num = 0;

            }
            ints.Add(num);
             return ints;
        }

        internal static T YourFirst<T>(IEnumerable<T> employees, Func<T, bool> p)
        {
            var enumerator = employees.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (p(enumerator.Current))
                {
                     return enumerator.Current;
                }
            }
            return default(T);
        }
        
        internal static T YourLast<T>(IEnumerable<T> employees, Func<T, bool> p)
        {
            var yourWhere = employees.YourWhere(p);
            var enumerator = yourWhere.GetEnumerator();
            var result = enumerator.Current;
            while (enumerator.MoveNext())
            {
                if (p(enumerator.Current))
                {
                    result = enumerator.Current;
                }
            }

            return result;
        }
    }
}