using System;

class Program
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());

        long r = 0;
        long result = 0;

        if (b == 3)
        {
            r = a + c;
        }
        else if (b == 6)
        {
            r = a * c;
        }
        else if (b == 9)
        {
            r = a % c;
        }

        if (r % 3 == 0)
        {
            result = r / 3;
        }
        else
        {
            result = r % 3;
        }

        Console.WriteLine(result);
        Console.WriteLine(r);
    }
}