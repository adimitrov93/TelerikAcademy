//Write an if statement that examines two integer variables and exchanges their values if the first one is greater than the second one.

using System;

class TheGreaterInteger
{
    static void Main()
    {
        Console.Write("Enter an integer number: ");
        int first = int.Parse(Console.ReadLine());

        Console.Write("Enter another integer number: ");
        int second = int.Parse(Console.ReadLine());

        if (first > second)
        {
            int temp = first;
            first = second;
            second = temp;
        }

        Console.WriteLine("First: {0}", first);
        Console.WriteLine("Second: {0}", second);
    }
}