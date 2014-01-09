using System;
using System.Numerics;

class Tribonacci
{
    static void Main()
    {
        BigInteger t1 = BigInteger.Parse(Console.ReadLine());
        BigInteger t2 = BigInteger.Parse(Console.ReadLine());
        BigInteger t3 = BigInteger.Parse(Console.ReadLine());

        int n = int.Parse(Console.ReadLine());

        if (n == 1)
        {
            Console.WriteLine(t1);
            return;
        }
        else if (n == 2)
        {
            Console.WriteLine(t2);
            return;
        }
        else if (n == 3)
        {
            Console.WriteLine(t3);
            return;
        }

        BigInteger[] sequence = new BigInteger[n];

        sequence[0] = t1;
        sequence[1] = t2;
        sequence[2] = t3;

        for (int i = 3; i < n; i++)
        {
            sequence[i] = sequence[i - 1] + sequence[i - 2] + sequence[i - 3];
        }

        Console.WriteLine(sequence[n - 1]);
    }
}