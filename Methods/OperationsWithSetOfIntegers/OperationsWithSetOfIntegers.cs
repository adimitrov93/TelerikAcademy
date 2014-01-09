//Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers. Use variable number of arguments.

using System;

class OperationsWithSetOfIntegers
{
    static int Min(params int[] numbers)
    {
        int min = int.MaxValue;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
            {
                min = numbers[i];
            }
        }

        return min;
    }

    static int Max(params int[] numbers)
    {
        int max = int.MinValue;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }

        return max;
    }

    static int Average(params int[] numbers)
    {
        int sum = Sum(numbers);
        int average = sum / numbers.Length;

        return average;
    }

    static int Sum(params int[] numbers)
    {
        int sum = 0;

        foreach (var number in numbers)
        {
            sum += number;
        }

        return sum;
    }

    static int Product(params int[] numbers)
    {
        int product = 1;

        foreach (var number in numbers)
        {
            product *= number;
        }

        return product;
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