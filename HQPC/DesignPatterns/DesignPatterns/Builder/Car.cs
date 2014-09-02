namespace DesignPatterns.Builder
{
    using System;
    using System.Text;

    // The "Product" class
    public class Car
    {
        public Car(string make)
        {
            this.Make = make;
        }

        public string Make { get; set; }

        public string Engine { get; set; }

        public string Frame { get; set; }

        public string Wheels { get; set; }

        public string Paint { get; set; }

        public string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("Engine: " + this.Engine);
            result.AppendLine("Frame: " + this.Frame);
            result.AppendLine("Wheels: " + this.Wheels);
            result.AppendLine("Paint: " + this.Paint);

            return result.ToString();
        }
    }
}
