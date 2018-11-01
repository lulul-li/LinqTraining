using System;
using System.Collections.Generic;
using System.Linq;

namespace JoeyIsFat
{
    internal static class WithoutLinq
    {
        public static IEnumerable<TResult> YourSelect<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            foreach (var item in source)
            {
                yield return selector(item);
            }
        }

        public static IEnumerable<TSource> YourTake<TSource>(IEnumerable<TSource> employees, int count)
        {
            var enumerator = employees.GetEnumerator();

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

        public static IEnumerable<TSource> YourSkip<TSource>(IEnumerable<TSource> employees, int count)
        {
            var enumerator = employees.GetEnumerator();

            var index = 0;

            while (enumerator.MoveNext())
            {
                if (index >= count)
                {
                    yield return enumerator.Current;
                }

                index++;
            }
        }

        public static IEnumerable<int> GetSum<TSource>(IEnumerable<TSource> source, int pageSize,
            Func<TSource, int> sumFunc)
        {
            var rowIndex = 0;

            while (rowIndex < source.Count())
            {
                yield return source.Skip(rowIndex).Take(pageSize).Sum(sumFunc);
                rowIndex += pageSize;
            }
        }

        public static IEnumerable<TSource> TakeWhile<TSource>(IEnumerable<TSource> source, int count,
            Func<TSource, bool> predicate)
        {
            var enumerator = source.GetEnumerator();
            var index = 0;

            while (enumerator.MoveNext() && index < count)
            {
                if (predicate(enumerator.Current))
                {
                    yield return enumerator.Current;
                    index++;
                }
            }
        }

        public static IEnumerable<TSource> SkipWhile<TSource>(IEnumerable<TSource> employees, int count,
            Func<TSource, bool> predicate)
        {
            var enumerator = employees.GetEnumerator();

            var skipCounter = 0;

            while (enumerator.MoveNext())
            {
                if (skipCounter >= count || !predicate(enumerator.Current))
                {
                    yield return enumerator.Current;
                }
                else
                {
                    skipCounter++;
                }
                //if (predicate(enumerator.Current))
                //{
                //}

                //else
                //{
                //    yield return enumerator.Current;
                //}
            }
        }

        public static IEnumerable<T> Find<T>(this IEnumerable<T> employees, Func<T, int, bool> predicate)
        {
            var index = 0;
            foreach (var employee in employees)
            {
                if (predicate(employee, index))
                {
                    yield return employee;
                }
                index++;
            }
        }

        public static IEnumerable<T> Find<T>(IEnumerable<T> sources, Func<T, bool> predicate)
        {
            foreach (var source in sources)
            {
                if (predicate(source))
                {
                    yield return source;
                }
            }
        }
    }
}