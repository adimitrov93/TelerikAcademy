namespace Shapes
{
    using System;

    public class Circle : Shape
    {
        // Constructors
        public Circle(decimal radius)
        {
            this.Width = radius;
            this.Height = radius;
        }

        // Methods
        public override decimal CalculateSurface()
        {
            return (decimal)Math.PI * this.Width * this.Width;
        }
    }
}