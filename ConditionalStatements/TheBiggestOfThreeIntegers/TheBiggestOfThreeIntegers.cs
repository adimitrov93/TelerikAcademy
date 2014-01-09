//Write a program that finds the biggest of three integers using nested if statements.

using System;

class TheBiggestOfThreeIntegers
{
    static void Main()
    {
        Console.Write("Enter an integer: ");
        int first = int.Parse(Console.ReadLine());

        Console.Write("Enter an integer: ");
        int second = int.Parse(Console.ReadLine());

        Console.Write("Enter an integer: ");
        int third = int.Parse(Console.ReadLine());

        int biggestNumber = third;

        if (first > second)
        {
            if (first > third)
            {
                biggestNumber = first;
            }
        }
        else
        {
            if (second > third)
            {
                biggestNumber = second;
            }
        }

        Console.WriteLine("The biggest number is {0}", biggestNumber);
    }
}