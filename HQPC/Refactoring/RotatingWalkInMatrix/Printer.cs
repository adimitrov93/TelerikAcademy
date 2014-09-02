namespace RotatingWalkInMatrix
{
    using System;

    public static class Printer
    {
        public static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    Console.Write("{0,3}", matrix[row, column]);
                }

                Console.WriteLine();
            }
        }
    }
}
