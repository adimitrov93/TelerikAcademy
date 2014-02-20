namespace Shapes
{
    using System;

    public abstract class Shape
    {
        // Fields
        private decimal width;
        private decimal height;

        // Properties
        public decimal Width
        {
            get
            {
                return this.width;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be less or equal to zero");
                }

                this.width = value;
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be less or equal to zero");
                }

                this.height = value;
            }
        }

        // Methods
        public abstract decimal CalculateSurface();
    }
}
