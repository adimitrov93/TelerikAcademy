namespace Matrix
{
    using System;
    using System.Collections.Generic;

    public class Matrix<T> where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>       //Ensures that T will be number
    {
        // Fields
        private T[,] matrix;
        private int rows;
        private int cols;

        // Constructors
        public Matrix(int rows, int cols)
        {
            if (rows <= 0 || cols <= 0)
            {
                throw new ArgumentOutOfRangeException("Dimensions of the matrix cannot be less or equal to zero");
            }

            this.matrix = new T[rows, cols];
            this.Rows = rows;
            this.Cols = cols;
        }

        // Properties
        public int Rows
        {
            get
            {
                return this.rows;
            }
            private set
            {
                this.rows = value;
            }
        }

        public int Cols
        {
            get
            {
                return this.cols;
            }
            private set
            {
                this.cols = value;
            }
        }

        // Indexers
        public T this[int row, int col]
        {
            get
            {
                return this.matrix[row, col];
            }
            set
            {
                this.matrix[row, col] = value;
            }
        }

        // Operators overloading
        public static Matrix<T> operator +(Matrix<T> a, Matrix<T> b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
            {
                throw new ArgumentException("The matrices must be with equal dimensions.");
            }

            Matrix<T> result = new Matrix<T>(a.Rows, a.Cols);

            for (int row = 0; row < result.Rows; row++)
            {
                for (int col = 0; col < result.Cols; col++)
                {
                    result[row, col] = (T)((dynamic)a[row, col] + (dynamic)b[row, col]);
                }
            }

            return result;
        }

        public static Matrix<T> operator -(Matrix<T> a, Matrix<T> b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
            {
                throw new ArgumentException("The matrices must be with equal dimensions.");
            }

            Matrix<T> result = new Matrix<T>(a.Rows, a.Cols);

            for (int row = 0; row < result.Rows; row++)
            {
                for (int col = 0; col < result.Cols; col++)
                {
                    result[row, col] = (T)((dynamic)a[row, col] - (dynamic)b[row, col]);
                }
            }

            return result;
        }

        public static Matrix<T> operator *(Matrix<T> a, Matrix<T> b)
        {
            if (a.Cols != b.Rows)
            {
                throw new ArgumentException("First matrix's cols must be equalt to second matrix's rows.");
            }

            Matrix<T> result = new Matrix<T>(a.Rows, b.Cols);

            for (int row = 0; row < result.Rows; row++)
            {
                for (int col = 0; col < result.Cols; col++)
                {
                    for (int i = 0; i < a.Cols; i++)        //Or b.Rows
                    {
                        result[row, col] = (T)((dynamic)result[row, col] + ((dynamic)a[row, i] * (dynamic)b[i, col]));
                    }
                }
            }

            return result;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            dynamic zero = 0;

            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    if ((dynamic)matrix[row, col] == zero)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            dynamic zero = 0;

            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    if ((dynamic)matrix[row, col] == zero)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
