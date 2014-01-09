//Write a program to calculate the Nth Catalan number by given N.
//In the combinatorial mathematics, the Catalan numbers are calculated by the following formula: Cn=(2n)!/((n+1)!n!)

using System;
using System.Numerics;

class NthCatalanNumber
{
    static void Main()
    {
        Console.WriteLine("The program calculates the Nth Catalan number.");
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());

        int m = 2 * n;
        BigInteger result = 1;

        for (int i = 0; i < (m - (n + 1)); i++)     //This loop uses the method from exercise 04.FactorialDivision for (2n)!/(n+1)!
        {
            result *= m - i;
        }

        for (int i = n; i > 1; i--)                 //This loop divides result by n!
        {
            result /= i;
        }

        Console.WriteLine("Cn = {0}", result);
    }
}