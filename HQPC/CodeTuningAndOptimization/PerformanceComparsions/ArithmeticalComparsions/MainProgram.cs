namespace ArithmeticalComparsions
{
    using System;

    public class MainProgram
    {
        public static void Main()
        {
            Console.WriteLine(SumComparsions.RunTests());
            Console.WriteLine(SubstractionComparsions.RunTests());
            Console.WriteLine(IncrementComparsions.RunTests());
            Console.WriteLine(MultiplicationComparsions.RunTests());
            Console.WriteLine(DivisionComparsions.RunTests());
        }
    }
}
