//Write a program that reads two arrays from the console and compares them element by element.

using System;

class ArrayComparsion
{
    static void Main()
    {
        Console.Write("Enter the length of the arrays: ");
        int length = int.Parse(Console.ReadLine());

        int[] firstArray = new int[length];
        int[] secondArray = new int[length];

        for (int i = 0; i < length; i++)
        {
            Console.Write("firstArray[{0}] = ", i);
            firstArray[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < length; i++)
        {
            Console.Write("secondArray[{0}] = ", i);
            secondArray[i] = int.Parse(Console.ReadLine());
        }

        bool areEqual = true;

        for (int i = 0; i < length; i++)
        {
            if (firstArray[i] != secondArray[i])
            {
                areEqual = false;
                break;
            }
        }

        Console.WriteLine(areEqual ? "This arrays are equal." : "This arrays are not equal.");
    }
}