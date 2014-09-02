﻿namespace Abstraction
{
    using System;

    public class Circle : Figure
    {
        public Circle()
        {
        }

        public Circle(double radius)
            : base(radius)
        {
        }

        public override double Width
        {
            get
            {
                throw new NotImplementedException("Circle does not have Width");
            }

            set
            {
                throw new NotImplementedException("Circle does not have Width");
            }
        }

        public override double Height
        {
            get
            {
                throw new NotImplementedException("Circle does not have Height");
            }

            set
            {
                throw new NotImplementedException("Circle does not have Height");
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;

            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;

            return surface;
        }
    }
}
