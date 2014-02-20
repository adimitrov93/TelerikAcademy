namespace Shapes
{
    public class Triangle : Shape
    {
        // Constructors
        public Triangle(decimal side, decimal height)
        {
            this.Width = side;
            this.Height = height;
        }

        // Methods
        public override decimal CalculateSurface()
        {
            return this.Width * this.Height / 2;
        }
    }
}
