//* Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.). Use generic method (read in Internet about generic methods in C#).

using System;
using System.Collections.Generic;

class OperationsWithSetOfNumbers
{
    static T Min<T>(params T[] numbers)
    {
        T min = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
        {
            if (Comparer<T>.Default.Compare(numbers[i], min) < 0)
            {
                min = numbers[i];
            }
        }

        return min;
    }

    static T Max<T>(params T[] numbers)
    {
        T max = numbers[0];

        for (int i = 0; i < numbers.Length; i++)
        {
            if (Comparer<T>.Default.Compare(numbers[i], max) > 0)
            {
                max = numbers[i];
            }
        }

        return max;
    }

    static T Average<T>(params T[] numbers) where T : new()
    {
        T sum = Sum(numbers);
        T average = Divide(sum, (T)(dynamic)numbers.Length);

        return average;
    }

    static T Sum<T>(params T[] numbers) where T : new()
    {
        T sum = new T();

        foreach (var number in numbers)
        {
            sum = Add(sum, number);
        }

        return sum;
    }

    static T Product<T>(params T[] numbers) where T : new()
    {
        T product = new T();
        product = Add(product, (T)(dynamic)1);

        foreach (var number in numbers)
        {
            product = Multiply(product, number);
        }

        return product;
    }

    static T Add<T>(T a, T b)
    {
        dynamic d1 = (dynamic)a;
        dynamic d2 = (dynamic)b;
        return (T)(d1 + d2);
    }

    static T Multiply<T>(T a, T b)
    {
        dynamic d1 = (dynamic)a;
        dynamic d2 = (dynamic)b;

        return (T)d1 * d2;
    }

    static T Divide<T>(T a, T b)
    {
        dynamic d1 = (dynamic)a;
        dynamic d2 = (dynamic)b;

        return (T)d1 / d2;
    }

    static void Main()
    {
        Console.WriteLine(Min(5, 9, -2, 3));
        Console.WriteLine(Max(5, 4, 9, -9, 4, 3));
        Console.WriteLine(Average(-7, 3));
        Console.WriteLine(Sum(5, 4, 9, -2, -7, 3));
        Console.WriteLine(Product(5, 4, 9, -9));
    }
}