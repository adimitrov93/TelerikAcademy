//Write an expression that checks if given point (x,  y) is within a circle K(O, 5).

using System;
using System.Globalization;
using System.Threading;

class PointWithinCircle
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("x = ");
        float xCoordinate = float.Parse(Console.ReadLine());
        Console.Write("y = ");
        float yCoordinate = float.Parse(Console.ReadLine());

        bool isWithinCircle = ((xCoordinate * xCoordinate) + (yCoordinate * yCoordinate)) < 25;

        Console.WriteLine(isWithinCircle ? "This point is within the circle." : "This point is outside the circle.");
    }
}