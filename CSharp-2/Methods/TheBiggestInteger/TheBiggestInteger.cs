//Write a method GetMax() with two parameters that returns the bigger of two integers. Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().

using System;

class TheBiggestInteger
{
    static int GetMax(int first, int second)
    {
        if (first >= second)
        {
            return first;
        }
        else
        {
            return second;
        }
    }

    static void FindMaxOfThreeInts()
    {
        Console.Write("Enter the first int: ");
        int first = int.Parse(Console.ReadLine());

        Console.Write("Enter the second int: ");
        int second = int.Parse(Console.ReadLine());

        Console.Write("Enter the third int: ");
        int third = int.Parse(Console.ReadLine());

        int theBiggest = GetMax(first, GetMax(second, third));

        Console.WriteLine("The biggest: {0}", theBiggest);
    }

    static void Main()
    {
        FindMaxOfThreeInts();
    }
}