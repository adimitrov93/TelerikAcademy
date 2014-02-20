namespace Shapes
{
    public class Rectangle : Shape
    {
        // Constructors
        public Rectangle(decimal width, decimal height)
        {
            this.Width = width;
            this.Height = height;
        }

        // Methods
        public override decimal CalculateSurface()
        {
            return this.Width * this.Height;
        }
    }
}
