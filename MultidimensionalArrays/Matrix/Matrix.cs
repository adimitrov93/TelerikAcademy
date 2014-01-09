//* Write a class Matrix, to holds a matrix of integers. Overload the operators for adding, subtracting and multiplying of matrices, indexer for accessing the matrix content and ToString().

using System;
using System.Text;

class Matrix
{
    private int[,] matrix;
    private int rows;
    private int cols;

    public int[,] Value                 //Matrix Property
    {
        get
        {
            return this.matrix;
        }
        set
        {
            this.matrix = value;
            this.rows = value.GetLength(0);
            this.cols = value.GetLength(1);
        }
    }

    public int Rows                     //Rows property
    {
        get
        {
            return this.rows;
        }
    }

    public int Columns                  //Columns Property
    {
        get
        {
            return this.cols;
        }
    }

    public Matrix(int[,] matrix)        //Constructor
    {
        this.Value = (int[,])matrix.Clone();
    }

    public Matrix(int rows, int cols)   //Constructor
    {
        this.Value = new int[rows, cols];
    }

    public static Matrix operator +(Matrix a, Matrix b)         //Overloading adding
    {
        if (a.Rows != b.Rows || a.Columns != b.Columns)
        {
            throw new FormatException("Matrixes must have same dimensions!");
        }
        else
        {
            Matrix result = new Matrix(a.Rows, a.Columns);

            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }

            return result;
        }
    }

    public static Matrix operator -(Matrix a, Matrix b)         //Overloading substracting
    {
        if (a.Rows != b.Rows || a.Columns != b.Columns)
        {
            throw new FormatException("Matrixes must have same dimensions!");
        }
        else
        {
            Matrix result = new Matrix(a.Rows, a.Columns);

            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    result[i, j] = a[i, j] - b[i, j];
                }
            }

            return result;
        }
    }

    public static Matrix operator *(Matrix a, Matrix b)         //Overloading multiplying
    {
        if (a.Columns != b.Rows)
        {
            throw new FormatException("First matrix columns must be equal to second matrix rows!");
        }
        else
        {
            Matrix result = new Matrix(a.Rows, b.Columns);

            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < b.Columns; j++)
                {
                    for (int k = 0; k < a.Columns; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }

            return result;
        }
    }

    public int this[int row, int col]                               //Indexer
    {
        get
        {
            return this.Value[row, col];
        }
        set
        {
            this.Value[row, col] = value;
        }
    }

    public override string ToString()                           //Overriding ToString
    {
        StringBuilder result = new StringBuilder();

        result.Append(this[0, 0]);

        for (int col = 1; col < this.Columns; col++)
        {
            result.AppendFormat(" {0}", this[0, col]);
        }
        for (int row = 1; row < this.Rows; row++)
        {
            result.AppendFormat("\n{0}", this[row, 0]);
            for (int j = 1; j < this.Columns; j++)
            {
                result.AppendFormat(" {0}", this[row, j]);
            }
        }
        return result.ToString();
    }



    static void Main()
    {
        Matrix a = new Matrix(3, 4);
        a.Value[1, 1] = 5;
        Matrix b = new Matrix(3, 4);
        b.Value[1, 1] = 3;

        Console.WriteLine("a.Rows: {0}; a.Columns: {1}", a.Rows, a.Columns);
        Console.WriteLine("b.Rows: {0}; b.Columns: {1}", b.Rows, b.Columns);

        try
        {
            Console.WriteLine("\na+b=\n{0}", a + b);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        b = new Matrix(4, 3);
        b.Value[1, 1] = 3;

        try
        {
            Console.WriteLine("\na-b=\n{0}", a - b);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        try
        {
            Console.WriteLine("\na*b=\n{0}", a * b);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}