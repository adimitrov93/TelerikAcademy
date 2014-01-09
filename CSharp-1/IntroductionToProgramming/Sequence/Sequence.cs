//Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...

using System;

class Sequence
{
    static void Main()
    {
        int number = 2;

        Console.Write("{0}, {1}", number, (number + 1) * -1);

        number += 2;

        for (int i = 0; i < 4; i++, number += 2)
        {
            Console.Write(", {0}, {1}", number, (number + 1) * -1);
        }

        Console.WriteLine(".");
    }
}