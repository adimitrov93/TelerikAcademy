//* Write a program that finds the largest area of equal neighbor elements in a rectangular matrix and prints its size. Example:

using System;

class LargestAreaWithEqualValues
{
    //For this task i use Depth-First Search algorithm.

    static int?[,] matrix =                 //I use matrix of nullable integers, because i need a value to indicate witch element is visited already. If the value is null, this element is counted.
    {
        {1, 3, 2, 2, 2, 4},
        {3, 3, 3, 2, 4, 4},
        {4, 3, 1, 2, 3, 3},
        {4, 3, 1, 3, 3, 1},
        {4, 3, 3, 3, 1, 1},
    };
    static int longestSeq = 0;
    static int currentSeq = 0;

    static void FindNeighbor(int row, int col)              //This is the hearth of the algorithm.
    {
        int currentValue = (int)matrix[row, col];
        matrix[row, col] = null;

        currentSeq++;

        for (int add = -1; add <= 1; add += 2)          //This is very cool for cycle. First it divides one, and then it adds one to the row/col.
        {
            if (IsValidCell(row + add, col) && matrix[row + add, col] == currentValue)
            {
                FindNeighbor(row + add, col);
            }
            if (IsValidCell(row, col + add) && matrix[row, col + add] == currentValue)
            {
                FindNeighbor(row , col + add);
            }
        }
    }

    static bool IsValidCell(int row, int col)
    {
        bool result = (row >= 0 && row < matrix.GetLength(0)) && (col >= 0 && col < matrix.GetLength(1));

        return result;
    }

    static void PrintMatrix()
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col].HasValue)
                {
                    Console.Write("{0} ", matrix[row, col]);
                }
                else
                {
                    Console.Write("- ");
                }
            }

            Console.WriteLine();
        }
    }

    static void Main()
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col].HasValue)
                {
                    currentSeq = 0;

                    FindNeighbor(row, col);
                    PrintMatrix();

                    Console.WriteLine("Current: {0}, MAX: {1}", currentSeq, longestSeq);

                    if (currentSeq > longestSeq)
                    {
                        longestSeq = currentSeq;
                    }
                }
            }
        }
    }
}