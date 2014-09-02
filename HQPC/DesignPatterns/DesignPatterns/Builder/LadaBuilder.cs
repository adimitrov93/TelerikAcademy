namespace DesignPatterns.Builder
{
    using System;

    // The "ConcreteBuilder" class
    public class LadaBuilder : CarBuilder
    {
        public LadaBuilder()
        {
            this.product = new Car("Lada");
        }

        public override void AssmebleEngine()
        {
            this.product.Engine = "1.2L";
        }

        public override void BuildFrame()
        {
            this.product.Frame = "Steel";
        }

        public override void AddWheels()
        {
            this.product.Wheels = "Michelin";
        }

        public override void Paint()
        {
            this.product.Paint = "White";
        }
    }
}
