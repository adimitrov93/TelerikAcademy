//Write a program that reads the coefficients a, b and c of a quadratic equation ax2+bx+c=0 and solves it (prints its real roots).

using System;
using System.Globalization;
using System.Threading;

class QuadraticEquation
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.WriteLine("Coefficients:");

        Console.Write("a = ");
        float a = float.Parse(Console.ReadLine());

        Console.Write("b = ");
        float b = float.Parse(Console.ReadLine());

        Console.Write("a = ");
        float c = float.Parse(Console.ReadLine());

        float d = (b * b) - (4 * a * c);    //Discriminant

        if (d < 0)
        {
            Console.WriteLine("No real solutions.");
        }
        else if (d == 0)
        {
            Console.WriteLine("x1,2 = {0:F2}", (-b) / (2 * a));
        }
        else
        {
            Console.WriteLine("x1 = {0:0.##}\tx2 = {1:0.##}", ((-b) + Math.Sqrt(d)) / (2 * a), ((-b) - Math.Sqrt(d)) / (2 * a));
        }
    }
}