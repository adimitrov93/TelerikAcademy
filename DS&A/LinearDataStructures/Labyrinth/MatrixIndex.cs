namespace Labyrinth
{
    using System;

    public class MatrixIndex
    {
        public MatrixIndex(int row, int col, int value)
        {
            this.Row = row;
            this.Col = col;
            this.Value = value;
        }

        public int Row { get; private set; }

        public int Col { get; private set; }

        public int Value { get; private set; }
    }
}
