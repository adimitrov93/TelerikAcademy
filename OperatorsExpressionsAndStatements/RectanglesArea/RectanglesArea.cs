//Write an expression that calculates rectangle’s area by given width and height.

using System;
using System.Globalization;
using System.Threading;

class RectanglesArea
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Enter rectangle's width: ");
        float width = float.Parse(Console.ReadLine());
        Console.Write("Enter rectangle's height: ");
        float height = float.Parse(Console.ReadLine());

        Console.WriteLine("Rectangle's area with width {0} mm and height {1} mm is {2} square mm.", width, height, width * height);
    }
}