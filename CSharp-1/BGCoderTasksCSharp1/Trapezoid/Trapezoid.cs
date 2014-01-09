using System;

class Trapezoid
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int row = n + 1, col = 2 * n;
        char[,] matrix = new char[row, col];

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (i == n)
                {
                    matrix[i, j] = '*';
                }
                else if (i == 0 && j >= n)
                {
                    matrix[i, j] = '*';
                }
                else if (j == ((2 * n) - 1))
                {
                    matrix[i, j] = '*';
                }
                else
                {
                    matrix[i, j] = '.';
                }
            }
        }

        for (int i = 0; i < (n - 1); i++)
        {
            matrix[(i + 1), (n - 1 - i)] = '*';
        }



        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}