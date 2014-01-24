using System;
using System.Collections.Generic;
using System.Text;

class VariableLengthCoding
{
    static string[] numbers;
    static Dictionary<int, char> codeTable = new Dictionary<int, char>();
    static StringBuilder result = new StringBuilder();

    static void Main()
    {
        GetData();

        for (int i = 0; i < numbers.Length; i++)
        {
            result.Append(ConvertToSymbol(numbers[i].Length));
        }

        Console.WriteLine(result);
    }

    private static char ConvertToSymbol(int lenght)
    {
        //foreach (var item in codeTable)
        //{
        //    if (item.Key == lenght)
        //    {
        //        return item.Value;
        //    }
        //}

        return codeTable[lenght];

        //return ' ';
    }

    private static void GetData()
    {
        string[] inputFragments = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        StringBuilder inputSB = new StringBuilder();

        for (int i = 0; i < inputFragments.Length; i++)
        {
            int number = int.Parse(Convert.ToString(int.Parse(inputFragments[i]), 2));
            inputSB.Append(number);

            if (inputSB.Length % 8 != 0)
            {
                inputSB.Insert(inputSB.Length - inputSB.Length % 8, '0');
            }
        }

        string input = inputSB.ToString();
        input = input.TrimEnd('0');
        numbers = input.Split('0');

        int numberOfSymbols = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfSymbols; i++)
        {
            string inputSymbol = Console.ReadLine();

            char symbol = inputSymbol[0];
            int freq = int.Parse(inputSymbol.Substring(1, inputSymbol.Length - 1));

            codeTable.Add(freq, symbol);
        }
    }
}