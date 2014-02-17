//Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, product, min, max, average.

namespace IEnumerableExtensions
{
    using System;
    using System.Collections.Generic;

    public static class Extensions
    {
        public static void Main()
        {
            IEnumerable<float> list = new List<float>();
            (list as List<float>).Add(5);
            (list as List<float>).Add(4);
            (list as List<float>).Add(8);

            Console.WriteLine(list.Sum());
            Console.WriteLine(list.Product());
            Console.WriteLine(list.Min());
            Console.WriteLine(list.Max());
            Console.WriteLine(list.Average());
        }

        public static T Sum<T>(this IEnumerable<T> collection) where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            dynamic sum = 0;

            foreach (var item in collection)
            {
                sum += item;
            }

            return (T)sum;
        }

        public static T Product<T>(this IEnumerable<T> collection) where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            dynamic product = 1;

            foreach (var item in collection)
            {
                product *= item;
            }

            return (T)product;
        }

        public static T Min<T>(this IEnumerable<T> collection) where T : IComparable, IComparable<T>
        {
            dynamic min = null;

            foreach (var item in collection)
            {
                if (item.CompareTo(min) < 0 || min == null)
                {
                    min = item;
                }
            }

            return (T)min;
        }

        public static T Max<T>(this IEnumerable<T> collection) where T : IComparable, IComparable<T>
        {
            dynamic max = null;

            foreach (var item in collection)
            {
                if (item.CompareTo(max) > 0 || max == null)
                {
                    max = item;
                }
            }

            return (T)max;
        }

        public static T Average<T>(this IEnumerable<T> collection) where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
        {
            dynamic sum = 0;
            int count = 0;

            foreach (var item in collection)
            {
                sum += item;
                count++;
            }

            return (T)(sum / count);
        }
    }
}
