namespace DesignPatterns.Builder
{
    using System;

    // The "Builder" class
    public abstract class CarBuilder
    {
        protected Car product;

        public abstract void AssmebleEngine();

        public abstract void BuildFrame();
        
        public abstract void AddWheels();
        
        public abstract void Paint();

        public Car GetCar()
        {
            return this.product;
        }
    }
}
