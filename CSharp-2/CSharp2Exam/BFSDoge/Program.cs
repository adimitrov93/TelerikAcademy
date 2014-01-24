using System;
using System.Collections.Generic;

class Program
{

    static int?[,] matrix;
    static int allPaths = 0;
    static int foodRow;
    static int foodCol;
    static int row = 0;
    static int col = 0;

    static void Main()
    {
        GetData();

        Queue<int?> q = new Queue<int?>();
        q.Enqueue(matrix[0, 0]);
        while (q.Count > 0)
        {
            int? current = q.Dequeue();
            if (current == null)
                continue;

            if (IsValidCell(row + 1, col))
            {
                q.Enqueue(matrix[row + 1, col]);
                row++;
            }
            if (IsValidCell(row, col + 1))
            {
                q.Enqueue(matrix[row, col + 1]);
                col++;
            }

            if (current == 1)
            {
                allPaths++;
            }
        }

        Console.WriteLine(allPaths);
    }

    private static void GetData()
    {
        string[] inputDim = Console.ReadLine().Split();

        matrix = new int?[int.Parse(inputDim[0]), int.Parse(inputDim[1])];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = 0;
            }
        }

        matrix[0, 0] = null;

        string[] inputFood = Console.ReadLine().Split();

        foodRow = int.Parse(inputFood[0]);
        foodCol = int.Parse(inputFood[1]);

        matrix[foodRow, foodCol] = 1;

        int numberOfEnemys = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfEnemys; i++)
        {
            string[] inputEnemy = Console.ReadLine().Split();

            matrix[int.Parse(inputEnemy[0]), int.Parse(inputEnemy[1])] = -1;
        }
    }

    static bool IsValidCell(int row, int col)
    {
        bool result = (row >= 0 && row < matrix.GetLength(0)) && (col >= 0 && col < matrix.GetLength(1)) && (matrix[row, col] != -1) && (row <= foodRow) && (col <= foodCol);

        return result;
    }
}