//Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).

using System;
using System.Numerics;

class FactorialExpression
{
    static void Main()
    {
        Console.WriteLine("Enter n and k (1 < n < k): ");
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("k = ");
        int k = int.Parse(Console.ReadLine());

        BigInteger result = 1;

        for (int i = n; i > 1; i--)                 //This loop makes N!
        {
            result *= i;
        }

        //result = N!

        for (int i = 0; i < (k - (k - n)); i++)     //This loop uses the method from the previous exercise
        {
            result *= (k - i);
        }

        Console.WriteLine("{0}!*{1}! / ({1}-{0})! = {2}", n, k, result);
    }
}