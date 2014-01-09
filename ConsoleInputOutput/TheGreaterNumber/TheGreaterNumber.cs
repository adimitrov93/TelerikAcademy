//Write a program that gets two numbers from the console and prints the greater of them. Don’t use if statements.

using System;
using System.Globalization;
using System.Threading;

class TheGreaterNumber
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Enter a number: ");
        float a = float.Parse(Console.ReadLine());

        Console.Write("Enter another number: ");
        float b = float.Parse(Console.ReadLine());

        Console.WriteLine("The greater number is {0}", Math.Max(a, b));
    }
}