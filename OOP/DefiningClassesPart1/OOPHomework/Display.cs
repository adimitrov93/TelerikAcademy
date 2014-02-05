namespace OOPHomework
{
    public class Display
    {
        // Fields
        private int width;
        private int height;
        private int numberOfColors;

        // Constructors
        public Display()
        {

        }

        public Display(int width, int height, int numberOfColors)
        {
            Width = width;
            Height = height;
            NumberOfColors = numberOfColors;
        }

        // Properties
        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentOutOfRangeException("Width of the display cannot be less than zero.");
                }

                this.width = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentOutOfRangeException("Height of the display cannot be less than zero.");
                }

                this.height = value;
            }
        }

        public int NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }
            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentOutOfRangeException("The number of colors of the display cannot be less than zero.");
                }

                this.numberOfColors = value;
            }
        }

        // Methods
        public override string ToString()
        {
            return string.Format("Size: {1}x{2}{0}Number of colors: {3}", System.Environment.NewLine, this.width, this.height, this.numberOfColors);
        }
    }
}
