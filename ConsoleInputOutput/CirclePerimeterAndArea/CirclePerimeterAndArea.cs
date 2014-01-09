//Write a program that reads the radius r of a circle and prints its perimeter and area.

using System;
using System.Globalization;
using System.Threading;

class CirclePerimeterAndArea
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Enter circle's radius: ");
        float radius = float.Parse(Console.ReadLine());

        Console.WriteLine("The perimeter of the circle is {0:F2} mm.", 2 * Math.PI * radius);
        Console.WriteLine("The area of the circle is {0:F2} square mm.", Math.PI * radius * radius);
    }
}