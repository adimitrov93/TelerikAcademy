namespace Shapes
{
    using System;

    public class ShapesDemo
    {
        public static void Main()
        {
            Shape[] shapes =
            {
                new Rectangle(5, 10),
                new Triangle(5, 6),
                new Circle(10)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.CalculateSurface());
            }
        }
    }
}
