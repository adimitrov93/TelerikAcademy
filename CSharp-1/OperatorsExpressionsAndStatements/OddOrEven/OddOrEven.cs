//Write an expression that checks if given integer is odd or even.

using System;

class OddOrEven
{
    static void Main()
    {
        Console.Write("Enter an integer number: ");
        int userInput = int.Parse(Console.ReadLine());

        bool isEven = (userInput % 2) == 0;

        Console.WriteLine(isEven ? "This number is even." : "This number is odd.");
    }
}