using System;
using System.Numerics;

class XPatterns
{
    static long[,] matrix;
    static int[] rowPattern = { 0, 0, 1, 1, 0, 0 };
    static int[] colPattern = { 1, 1, 0, 0, 1, 1 };
    static BigInteger maxSum = 0;

    static void GetData()
    {
        int n = int.Parse(Console.ReadLine());
        matrix = new long[n, n];

        for (int row = 0; row < n; row++)
        {
            string line = Console.ReadLine();
            string[] lineFragments = line.Split();

            for (int col = 0; col < n; col++)
            {
                matrix[row, col] = long.Parse(lineFragments[col]);
            }
        }
    }

    static bool IsValidPattern(int row, int col)
    {
        long previousValue = matrix[row, col];
        bool isValid = true;

        for (int i = 0; i < rowPattern.Length; i++)
        {
            row += rowPattern[i];
            col += colPattern[i];

            if (matrix[row, col] != previousValue + 1)
            {
                isValid = false;
                break;
            }

            previousValue = matrix[row, col];
        }


        return isValid;
    }

    static bool ProcessMatrix()
    {
        for (int row = 0; row <= matrix.GetLength(1) - 3; row++)
        {
            for (int col = 0; col <= matrix.GetLength(0) - 5; col++)
            {
                if (IsValidPattern(row, col))
                {
                    BigInteger curSum = SumPattern(row, col);

                    if (curSum > maxSum)
                    {
                        maxSum = curSum;
                    }
                }
            }
        }

        if (maxSum == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private static BigInteger SumPattern(int row, int col)
    {
        BigInteger sum = matrix[row, col];

        for (int i = 0; i < rowPattern.Length; i++)
        {
            row += rowPattern[i];
            col += colPattern[i];

            sum += matrix[row, col];
        }

        return sum;
    }

    static void Main()
    {
        DateTime start = DateTime.Now;
        GetData();

        bool result = ProcessMatrix();

        if (result)
        {
            Console.WriteLine("{0} {1}", "YES", maxSum);
        }
        else
        {
            SumDiagonal();
            Console.WriteLine("{0} {1}", "NO", maxSum);
        }
        DateTime end = DateTime.Now;
    }

    private static void SumDiagonal()
    {
        maxSum = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            maxSum += matrix[i, i];
        }
    }
}