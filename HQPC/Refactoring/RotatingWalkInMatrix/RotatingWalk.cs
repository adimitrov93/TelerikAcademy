namespace RotatingWalkInMatrix
{
    using System;

    public static class RotatingWalk
    {
        public static void ChangeDirection(ref int directionRow, ref int directionCol)
        {
            int[] directionsRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsCol = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int currentDirectionIndex = 0;

            for (int index = 0; index < directionsRow.Length; index++)
            {
                if (directionRow == directionsRow[index] && directionCol == directionsCol[index])
                {
                    currentDirectionIndex = index;

                    break;
                }
            }

            if (currentDirectionIndex == (directionsRow.Length - 1))
            {
                directionRow = directionsRow[0];
                directionCol = directionsCol[0];
            }
            else
            {
                int nextDirectionIndex = currentDirectionIndex + 1;

                directionRow = directionsRow[nextDirectionIndex];
                directionCol = directionsCol[nextDirectionIndex];
            }
        }

        public static bool AreThereMoreMoves(int[,] matrix, int row, int col)
        {
            int[] directionsRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsCol = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < directionsRow.Length; i++)
            {
                if (row + directionsRow[i] < 0 || row + directionsRow[i] >= matrix.GetLength(0))
                {
                    directionsRow[i] = 0;
                }

                if (col + directionsCol[i] < 0 || col + directionsCol[i] >= matrix.GetLength(1))
                {
                    directionsCol[i] = 0;
                }
            }

            for (int i = 0; i < directionsRow.Length; i++)
            {
                if (matrix[row + directionsRow[i], col + directionsCol[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool FindEmptyCell(int[,] matrix, ref int row, ref int col)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        row = i;
                        col = j;

                        return true;
                    }
                }
            }

            return false;
        }

        public static bool IsInvalidMove(int[,] matrix, int row, int col, int directionX, int directionY)
        {
            return (row + directionX >= matrix.GetLength(0) ||
                    row + directionX < 0 ||
                    col + directionY >= matrix.GetLength(1) ||
                    col + directionY < 0 ||
                    matrix[row + directionX, col + directionY] != 0);
        }
    }
}
