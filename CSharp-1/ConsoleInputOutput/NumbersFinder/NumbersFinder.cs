//Write a program that reads two positive integer numbers and prints how many numbers p exist between them such that the reminder of the division by 5 is 0 (inclusive).
//Example: p(17,25) = 2.

using System;

class NumbersFinder
{
    static void Main()
    {
        Console.Write("Enter a positive integer number: ");
        uint a = uint.Parse(Console.ReadLine());
        Console.Write("Enter another positive integer number: ");
        uint b = uint.Parse(Console.ReadLine());

        if (a >= b && (a % 5 != 0))
        {
            Console.WriteLine("There is no number meeting the criterion.");
            return;
        }

        if (a % 5 != 0)
        {
            if (a % 10 < 5)                     //Check if the units digit is less than 5               Example: a = 13, 3 < 5
            {
                a = a + (5 - (a % 10));         //Make the number to meet the condition a % 5 == 0      Example: a = 13, this line add 2, a = 15
            }
            else
            {
                a = a + (10 - (a % 10));        //Make the number to meet the condition a % 5 == 0       Example: a = 17, this line add 3, a = 20
            }
        }

        if (a > b)
        {
            Console.WriteLine("There is no number meeting the criterion.");
        }
        else if (a == b)
        {
            Console.WriteLine("There is 1 number meeting the criterion.");
        }
        else
        {
            uint result = ((b - a) / 5) + 1;

            if (result == 1)
            {
                Console.WriteLine("There is 1 number meeting the criterion.");
            }
            else
            {
                Console.WriteLine("There are {0} numbers meeting the criterion.", result);
            }
        }
    }
}