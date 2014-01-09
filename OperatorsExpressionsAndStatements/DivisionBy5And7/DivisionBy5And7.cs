//Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.

using System;

class DivisionBy5And7
{
    static void Main()
    {
        Console.Write("Enter an integer number: ");
        int userInput = int.Parse(Console.ReadLine());

        bool isDivisionPossible = ((userInput % 5 == 0) && (userInput % 7 == 0)) ? true : false;

        Console.WriteLine(isDivisionPossible ? "This number can be divided (without remainder) by 7 and 5 in the same time." :
            "This number cannot be divided (without remainder) by 7 and 5 in the same time.");
    }
}