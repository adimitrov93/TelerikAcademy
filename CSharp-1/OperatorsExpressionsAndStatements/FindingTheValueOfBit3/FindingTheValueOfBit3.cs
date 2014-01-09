//Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.

using System;

class FindingTheValueOfBit3
{
    static void Main()
    {
        Console.Write("Enter an integer number: ");
        int userInput = int.Parse(Console.ReadLine());

        int mask = 1;

        mask <<= 3;
        mask &= userInput;

        Console.WriteLine(mask == 0 ? "The bit 3 is 0." : "The bit 3 is 1.");
    }
}