namespace DesignPatterns.Builder
{
    using System;

    // The "ConcreteBuilder" class
    public class LamborghiniBuilder : CarBuilder
    {
        public LamborghiniBuilder()
        {
            this.product = new Car("Lamborghini");
        }

        public override void AssmebleEngine()
        {
            this.product.Engine = "6.5L V12";
        }

        public override void BuildFrame()
        {
            this.product.Frame = "Aluminium";
        }

        public override void AddWheels()
        {
            this.product.Wheels = "Pirelli";
        }

        public override void Paint()
        {
            this.product.Paint = "No Paint";
        }
    }
}
