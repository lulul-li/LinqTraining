using System;
using System.Collections.Generic;
using System.Linq;
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
                  yield return  product;
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

        public static IEnumerable<Employee> skip(IEnumerable<Employee> employees, int i)
        {
            var j = 0;
            foreach (var employee in employees)
            {
                if (j > 2)
                {
                    yield return employee;
                }
                j++;
            }
        }

        internal static IEnumerable<T> Find<T>( this IEnumerable<T> employees, Func<T, int, bool> p)
        {
           var index = 0;
            foreach (var employee in employees)
            {
                if (p(employee,index))
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
        public static IEnumerable<string> YourSelect<T>(this IEnumerable<T> sources, Func<T, string> func)
        {
            foreach (var s in sources)
            {
                yield return func(s);
            }

           
        }
    }
}