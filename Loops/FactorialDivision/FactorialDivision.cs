//Write a program that calculates N!/K! for given N and K (1<K<N).

using System;
using System.Numerics;

class FactorialDivision
{
    static void Main()
    {
        Console.WriteLine("Enter n and k (1 < k < n): ");
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("k = ");
        int k = int.Parse(Console.ReadLine());

        BigInteger result = 1;

        for (int i = 0; i < (n - k); i++)           //This loop cancel out the factors of K! in N! and maked N!/K! E.g. 1*2*3*4*5/1*2*3 -> result  = 4 * 5
        {
            result *= (n - i);
        }

        Console.WriteLine("{0}!/{1}! = {2}", n, k, result);
    }
}