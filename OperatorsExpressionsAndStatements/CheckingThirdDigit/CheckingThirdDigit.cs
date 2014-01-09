//Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732  true.

using System;

class CheckingThirdDigit
{
    static void Main()
    {
        Console.Write("Enter an integer number: ");
        int userInput = int.Parse(Console.ReadLine());

        userInput /= 100;
        userInput %= 10;

        Console.WriteLine(userInput == 7);
    }
}