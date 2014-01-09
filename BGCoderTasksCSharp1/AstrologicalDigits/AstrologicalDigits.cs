using System;

class AstrologicalDigits
{
    static void Main()
    {
        string input = Console.ReadLine();
        int sum = 0;
        bool minusSign = false;

        while (true)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '.' || input[i] == '-')
                {
                    continue;
                }

                sum += ((int)input[i] - 48);
            }

            if (sum <= 9)
            {
                break;
            }
            else
            {
                input = sum.ToString();
                sum = 0;
            }
        }

        Console.WriteLine(sum);
    }
}