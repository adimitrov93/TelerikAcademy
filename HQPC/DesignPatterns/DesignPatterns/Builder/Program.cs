namespace DesignPatterns.Builder
{
    using System;

    public class Program
    {
        public static void Main()
        {
            CarFactory director = new CarFactory();
            CarBuilder concreteBuilder;
            Car product;

            concreteBuilder = new LamborghiniBuilder();
            product = director.Construct(concreteBuilder);
            Console.WriteLine(product.ToString());

            concreteBuilder = new LadaBuilder();
            product = director.Construct(concreteBuilder);
            Console.WriteLine(product.ToString());
        }
    }
}
