using System;

class SubsetSums
{
    static int power(int power)
    {
        int result = 1;
        for (int i = 0; i < power; i++)
        {
            result *= 2;
        }

        return result - 1;
    }

    static void Main()
    {
        long s = long.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        long[] array = new long[n];

        for (int i = 0; i < n; i++)
        {
            array[i] = long.Parse(Console.ReadLine());
        }

        long sum;
        int subsetCount = 0;
        int length = power(n);

        for (int i = 1; i <= length; i++)
        {
            sum = 0L;

            for (int j = 0; j < n; j++)
            {
                if (((i >> j) & 1) == 1)
                {
                    sum += array[n - j - 1];
                }
            }

            if (sum == s)
            {
                subsetCount++;
            }
        }

        Console.WriteLine(subsetCount);
    }
}