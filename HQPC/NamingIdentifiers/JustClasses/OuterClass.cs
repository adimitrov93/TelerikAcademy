using System;

public class OuterClass
{
    private const int MAX_COUNT = 6;

    public class InnerClass
    {
        public void PrintVariable(bool variable)
        {
            string variableAsString = variable.ToString();

            Console.WriteLine(variableAsString);
        }
    }

    public static void InputMethod()
    {
        InnerClass instance = new InnerClass();
        instance.PrintVariable(true);
    }
}