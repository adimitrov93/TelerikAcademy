//Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.

using System;

class SquareWithMaxSum4
{
    static int n, m;
    static int[,] matrix;
    static int maxSumRow, maxSumCol;

    static void TakeMatrix()        //This method take a matrix from the input with user friendly messages.
    {
        Console.Write("n (n >= 3)= ");
        n = int.Parse(Console.ReadLine());

        Console.Write("m (m >= 3)= ");
        m = int.Parse(Console.ReadLine());

        matrix = new int[n, m];

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                Console.Write("matrix[{0}, {1}] = ", row, col);

                matrix[row, col] = int.Parse(Console.ReadLine());
            }
        }
    }

    static void FindMaxSum()        //This method is the heart of the program. It "walks" all the elements that can be start points of squares. Start point of square I define as the top left element of the square.
    {
        int currentSum = 0, maxSum = 0;

        for (int row = 0; row < matrix.GetLength(0) - 2; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            {
                currentSum = CalcSum(row, col);

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;

                    maxSumRow = row;
                    maxSumCol = col;
                }
            }
        }
    }

    static int CalcSum(int row, int col)    //This calculates the 3x3 square's sum by given start point of the square.
    {
        int currentSum = 0;

        currentSum += (matrix[row, col] + matrix[row + 1, col] + matrix[row + 2, col] +
                    matrix[row, col + 1] + matrix[row + 1, col + 1] + matrix[row + 2, col + 1] +
                    matrix[row, col + 2] + matrix[row + 1, col + 2] + matrix[row + 2, col + 2]);

        return currentSum;
    }

    static void PrintMatrix()       //Just print the matrix.
    {
        for (int row = maxSumRow; row < maxSumRow + 3; row++)
        {
            for (int col = maxSumCol; col < maxSumCol + 3; col++)
            {
                Console.Write("{0,-2}", matrix[row, col]);
            }

            Console.WriteLine();
        }
    }

    static void Main()
    {
        TakeMatrix();

        FindMaxSum();

        PrintMatrix();
    }
}