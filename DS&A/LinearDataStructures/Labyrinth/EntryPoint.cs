namespace Labyrinth
{
    using System;
    using System.Collections.Generic;

    public class EntryPoint
    {
        public static void Main()
        {
            string[] input = 
            {
                "000x0x",
                "0x0x0x",
                "0*x0x0",
                "0x0000",
                "000xx0",
                "000x0x"
            };

            int[,] matrix = DecodeInput(input);

            MatrixIndex startIndex = null;
            try
            {
                startIndex = FindStartPoint(matrix);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Traverse(matrix, startIndex);

            var result = EncodeResult(matrix);
            foreach (var row in result)
            {
                Console.WriteLine(row);
            }
        }

        private static MatrixIndex FindStartPoint(int[,] matrix)
        {
            MatrixIndex startIndex = null;
            bool startPointFound = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == -2)
                    {
                        startIndex = new MatrixIndex(row, col, 0);

                        startPointFound = true;
                        break;
                    }
                }
            }

            if (!startPointFound)
            {
                throw new ArgumentException("Invalid array. No start point in it.", "array");
            }

            return startIndex;
        }

        /// <summary>
        /// This method traverses the matrix and fill up the shortest paths to every cell. It uses BFS.
        /// </summary>
        /// <param name="matrix">The matrix to be traversed.</param>
        /// <param name="startIndex">Starting point of the traversal.</param>
        static void Traverse(int[,] matrix, MatrixIndex startIndex)
        {
            Queue<MatrixIndex> queue = new Queue<MatrixIndex>();

            queue.Enqueue(startIndex);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.Row + 1 < matrix.GetLength(0) && matrix[current.Row + 1, current.Col] == 0)
                {
                    var next = new MatrixIndex(current.Row + 1, current.Col, current.Value + 1);
                    matrix[next.Row, next.Col] = next.Value;
                    queue.Enqueue(next);
                }

                if (current.Row - 1 >= 0 && matrix[current.Row - 1, current.Col] == 0)
                {
                    var next = new MatrixIndex(current.Row - 1, current.Col, current.Value + 1);
                    matrix[next.Row, next.Col] = next.Value;
                    queue.Enqueue(next);
                }

                if (current.Col + 1 < matrix.GetLength(1) && matrix[current.Row, current.Col + 1] == 0)
                {
                    var next = new MatrixIndex(current.Row, current.Col + 1, current.Value + 1);
                    matrix[next.Row, next.Col] = next.Value;
                    queue.Enqueue(next);
                }

                if (current.Col - 1 >= 0 && matrix[current.Row, current.Col - 1] == 0)
                {
                    var next = new MatrixIndex(current.Row, current.Col - 1, current.Value + 1);
                    matrix[next.Row, next.Col] = next.Value;
                    queue.Enqueue(next);
                }
            }
        }

        static int[,] DecodeInput(string[] input)
        {
            int[,] result = new int[input.Length, input[0].Length];

            for (int row = 0; row < input.Length; row++)
            {
                for (int col = 0; col < input[row].Length; col++)
                {
                    if (input[row][col] == '*')
                    {
                        result[row, col] = -2;
                    }
                    else if (input[row][col] == 'x')
                    {
                        result[row, col] = -1;
                    }
                    else
                    {
                        result[row, col] = 0;
                    }
                }
            }

            return result;
        }

        static string[] EncodeResult(int[,] matrix)
        {
            string[] result = new string[matrix.GetLength(0)];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                List<string> currentRow = new List<string>();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == -2)
                    {
                        currentRow.Add("*");
                    }
                    else if (matrix[row, col] == -1)
                    {
                        currentRow.Add("x");
                    }
                    else if (matrix[row, col] == 0)
                    {
                        currentRow.Add("u");
                    }
                    else
                    {
                        currentRow.Add(matrix[row, col].ToString());
                    }
                }

                result[row] = string.Join(" ", currentRow);
            }

            return result;
        }
    }
}
