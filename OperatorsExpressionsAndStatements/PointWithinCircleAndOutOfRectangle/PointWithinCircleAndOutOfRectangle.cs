//Write an expression that checks for given point (x, y) if it is within the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2).

using System;
using System.Globalization;
using System.Threading;

class PointWithinCircleAndOutOfRectangle
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("x = ");
        float xCoordinate = float.Parse(Console.ReadLine());
        Console.Write("y = ");
        float yCoordinate = float.Parse(Console.ReadLine());

        bool isWithinCircle = ((xCoordinate - 1) * (xCoordinate - 1) + (yCoordinate - 1) * (yCoordinate - 1)) < 9;

        if (isWithinCircle)
        {
            bool isOutOfRect = (xCoordinate < -1 || xCoordinate > 5 || yCoordinate < -1 || yCoordinate > 1);

            if (isOutOfRect)
            {
                Console.WriteLine("This point is within the circle and out of the rectangle.");
            }
            else
            {
                Console.WriteLine("This point doesn't meet the criteria.");
            }
        }
        else
        {
            Console.WriteLine("This point doesn't meet the criteria.");
        }
    }
}