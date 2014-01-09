using System;
using System.Text;

class DancingBits
{
    static void Main()
    {
        int k = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        int number = 0;
        StringBuilder input = new StringBuilder();
        StringBuilder calc = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            number = int.Parse(Console.ReadLine());
            input.Append(Convert.ToString(number, 2));
        }

        //11110001

        char currentValue = input[0];
        int result = 0;

        calc.Append(currentValue);

        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] == currentValue)
            {
                calc.Append(currentValue);
            }
            else if (calc.Length == k)
            {
                result++;
                calc.Clear();
                currentValue = input[i];
                calc.Append(currentValue);
            }
            else
            {
                calc.Clear();
                currentValue = input[i];
                calc.Append(currentValue);
            }
        }

        if (calc.Length == k)
        {
            result++;
        }

        Console.WriteLine(result);
    }
}