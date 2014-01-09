//Write a program that generates and prints to the console 10 random values in the range [100, 200].

using System;

class PrintRandomNumbers
{
    static void Main()
    {
        Random randomGenerator = new Random();

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Random: {0}", randomGenerator.Next(100, 201));
        }
    }
}