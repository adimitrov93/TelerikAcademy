namespace DesignPatterns.Builder
{
    using System;

    public class CarFactory
    {
        public Car Construct(CarBuilder builder)
        {
            builder.BuildFrame();
            builder.Paint();
            builder.AssmebleEngine();
            builder.AddWheels();

            return builder.GetCar();
        }
    }
}
