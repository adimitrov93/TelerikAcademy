using System;

class CartesianCoordinateSystem
{
    static void Main()
    {
        decimal xCoordinate = decimal.Parse(Console.ReadLine());
        decimal yCoordinate = decimal.Parse(Console.ReadLine());

        if (xCoordinate == 0 && yCoordinate == 0)
        {
            Console.WriteLine(0);
            return;
        }
        else if (xCoordinate == 0 && yCoordinate != 0)
        {
            Console.WriteLine(5);
            return;
        }
        else if (yCoordinate == 0 && xCoordinate != 0)
        {
            Console.WriteLine(6);
            return;
        }
        else if (xCoordinate > 0)
        {
            if (yCoordinate > 0)
            {
                Console.WriteLine(1);
                return;
            }
            else
            {
                Console.WriteLine(4);
                return;
            }
        }
        else if (xCoordinate < 0)
        {
            if (yCoordinate > 0)
            {
                Console.WriteLine(2);
                return;
            }
            else
            {
                Console.WriteLine(3);
                return;
            }
        }
    }
}