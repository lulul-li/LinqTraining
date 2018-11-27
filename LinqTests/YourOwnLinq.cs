using System;
using System.Collections.Generic;
using System.Linq;
using ExpectedObjects;
using LinqTests;

namespace LinqSample.YourOwnLinq
{
    internal static class YourOwnLinq
    {
        public static T MyFirstOrDefault<T>(this IEnumerable<T> sources, Func<T, bool> func)
        {
            var enumerator = sources.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (func(enumerator.Current))
                {
                    return enumerator.Current;
                }
            }
            return default(T);
        }

        public static T YourSingle<T>(IEnumerable<T> sources, Func<T, bool> func)
        {
            var enumerator = sources.GetEnumerator();
            var current = enumerator.Current;
            var index = 0;
            while (enumerator.MoveNext())
            {
                if (func(enumerator.Current))
                {
                    current = enumerator.Current;
                    index++;
                    if (index > 1)
                    {
                        break; ;
                    }
                }
            }
            if (index == 0 || index > 1)
            {
                throw new InvalidOperationException();
            }
            return current;
        }

        public static IEnumerable<T> YourDistinct<T>(IEnumerable<T> sources, IEqualityComparer<T> myCompare)
        {
            var enumerator = sources.GetEnumerator();
            var hashSet = new HashSet<T>(myCompare);
            while (enumerator.MoveNext())
            {
                if (hashSet.Add(enumerator.Current))
                {
                    yield return enumerator.Current;
                }
            }


        }

        public static bool YourContains<T>(this IEnumerable<T> employees, IEnumerable<T> validateList, IEqualityComparer<T> myComparer)
        {
            var enumerator = employees.GetEnumerator();
            var validateEnumerator = validateList.GetEnumerator();
            var hashSet = new HashSet<T>(myComparer);
            while (enumerator.MoveNext())
            {
                hashSet.Add(enumerator.Current);
            }

            while (validateEnumerator.MoveNext())
            {
                if (!hashSet.Contains(validateEnumerator.Current))
                {
                    return false;
                }
            }
            return true;

            //var enumerator = employees.GetEnumerator();
            //var validateEnumerator = validateList.GetEnumerator();

            //while (enumerator.MoveNext())
            //{
            //    validateEnumerator.Reset();
            //    while (validateEnumerator.MoveNext())
            //    {
            //        if (enumerator.Current.Equals(validateEnumerator.Current))
            //        {
            //            return true;
            //        }
            //    }
            //}
            //return false;
        }

        public static bool YourSequenceEqual<T>(IEnumerable<T> sources, IEnumerable<T> sources2, IEqualityComparer<T> myCompare)
        {
            var enumerator1 = sources.GetEnumerator();
            var enumerator2 = sources2.GetEnumerator();
            bool a, b;
            while ((a = enumerator1.MoveNext()) & ( b =  enumerator2.MoveNext()))
            {
                if (!myCompare.Equals(enumerator1.Current, enumerator2.Current))
                {
                    return false;
                }
            }
            return a == b;
        }
    }
}