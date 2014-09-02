namespace RotatingWalkInMatrix
{
    using System;

    public static class Engine
    {
        public static int[,] PerformRotatingWalk(int matrixSize)
        {
            int[,] matrix = new int[matrixSize, matrixSize];
            int currentNumber = 1;
            int row = 0;
            int col = 0;
            
            while (RotatingWalk.FindEmptyCell(matrix, ref row, ref col))
            {
                int directionRow = 1;
                int directionCol = 1;

                while (RotatingWalk.AreThereMoreMoves(matrix, row, col))
                {
                    matrix[row, col] = currentNumber;
                    
                    while (RotatingWalk.IsInvalidMove(matrix, row, col, directionRow, directionCol))
                    {
                        RotatingWalk.ChangeDirection(ref directionRow, ref directionCol);
                    }

                    row += directionRow;
                    col += directionCol;
                    currentNumber++;
                }

                // I coudn't find a way of not changing the whole program logic to escape this 2 lines. So I leaved them this way.
                matrix[row, col] = currentNumber;
                currentNumber++;
            }

            return matrix;
        }
    }
}
