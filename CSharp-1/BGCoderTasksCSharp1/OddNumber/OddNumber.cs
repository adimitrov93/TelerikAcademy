using System;

class OddNumber
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        long input, result = 0;

        for (int i = 0; i < n; i++)
        {
            input = long.Parse(Console.ReadLine());
            result ^= input;
        }

        Console.WriteLine(result);
    }
}