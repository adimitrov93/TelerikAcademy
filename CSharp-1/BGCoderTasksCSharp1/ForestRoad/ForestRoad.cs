using System;

class ForestRoad
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = 2 * n - 1;
        char[,] matrix = new char[m, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == j)
                {
                    matrix[i, j] = '*';
                }
                else
                {
                    matrix[i, j] = '.';
                }
            }
        }

        for (int i = 1; i <= n - 1; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[n + i - 1, j] = matrix[n - i - 1, j];
            }
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}