using System;

class SandGlass
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0, j = 0; i < n; i++)
        {
            Console.WriteLine(new string('.', j) + new string('*', n - 2 * j) + new string('.', j));

            if (i < n / 2)
            {
                j++;
            }
            else
            {
                j--;
            }
        }
    }
}