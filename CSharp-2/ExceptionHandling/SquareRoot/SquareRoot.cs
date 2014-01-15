//Write a program that reads an integer number and calculates and prints its square root. If the number is invalid or negative, print "Invalid number". In all cases finally print "Good bye". Use try-catch-finally.

using System;

class SquareRoot
{
    static void Main()
    {
        Console.Write("Enter number: ");
        double number = double.Parse(Console.ReadLine());

        try
        {
            if (number <= 0)
            {
                throw new FormatException("Number must be positive.");
            }

            double result = Math.Sqrt(number);

            Console.WriteLine("Square root of {0:0.##} is {1:0.##}", number, result);
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Good bye.");
        }
    }
}