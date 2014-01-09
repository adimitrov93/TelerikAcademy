//Write methods that calculate the surface of a triangle by given:
//Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.

using System;

class SurfaceOfATriangle
{
    static double Power(double baseOfNumber, int power)
    {
        double result = 1;

        for (int i = 1; i <= power; i++)
        {
            result *= baseOfNumber;
        }

        return result;
    }

    static double AreaBySideAndAltitude(double side, double altitude)
    {
        double area;

        area = (side * altitude) / 2;

        return area;
    }

    static double AreaByThreeSides(double a, double b, double c)
    {
        double halfPerimeter = (a + b + c) / 2;

        double area = Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));       //Heron's Formula

        return area;
    }

    static double AreaByTwoSidesAndAngle(double a, double b, double angleInRadians)
    {
        double angleInDegrees = angleInRadians * 0.0174532925;      //We need the angle in radians because Math.Cos works with radians
        double c = Math.Sqrt(Power(a, 2) + Power(b, 2) - (2 * a * b * Math.Cos(angleInDegrees)));          //The Law of Cosines, we find the third side

        double area = AreaByThreeSides(a, b, c);

        return area;
    }

    static void Main()
    {
        Console.WriteLine("Area of triangle with side {0} and altitude to it {1} is {2} square meters.", 20, 12, AreaBySideAndAltitude(20, 12));
        Console.WriteLine("Area of triangle with sides {0}, {1} and {2} is {3} square meters.", 5, 5, 5, AreaByThreeSides(5, 5, 5));
        Console.WriteLine("Area of triangle with sides {0}, {1} and angle between them {2} is {3} square meters.", 5, 7, 49, AreaByTwoSidesAndAngle(5, 7, 49));
    }
}