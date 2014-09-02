namespace Abstraction
{
    using System;

    public abstract class Figure
    {
        private double width;
        private double height;
        private double radius;

        public Figure()
        {
        }

        public Figure(double radius)
        {
            this.Radius = radius;
        }

        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public virtual double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("width", "Width must be positive number.");
                }

                this.width = value;
            }
        }

        public virtual double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("height", "Height must be positive number.");
                }

                this.height = value;
            }
        }

        public virtual double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("radius", "Radius must be positive number.");
                }

                this.radius = value;
            }
        }

        public abstract double CalcPerimeter();

        public abstract double CalcSurface();
    }
}
