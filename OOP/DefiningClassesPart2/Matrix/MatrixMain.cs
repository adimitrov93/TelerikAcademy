namespace Matrix
{
    using System;

    public class MatrixMain
    {
        public static void Main()
        {
            Matrix<int> matrix = new Matrix<int>(2, 1);
            matrix[0, 0] = 1;
            matrix[1, 0] = 2;

            Matrix<int> anotherMatrix = new Matrix<int>(1, 2);
            anotherMatrix[0, 0] = 4;
            anotherMatrix[0, 1] = 6;

            Matrix<int> result = matrix * anotherMatrix;

            if (matrix)
            {
                Console.WriteLine("There is no zero element.");
            }
            else
            {
                Console.WriteLine("There is zero element.");
            }
        }
    }
}