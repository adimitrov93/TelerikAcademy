using System;
using System.Collections.Generic;
using System.Text;

class TRES4Numbers
{
    static string DecimalToEight(ulong decimalNumber)
    {
        ulong remainder = 0;
        List<ulong> binaryNumber = new List<ulong>();

        while (decimalNumber > 8)
        {
            remainder = decimalNumber % 9;
            decimalNumber /= 9;

            binaryNumber.Add(remainder);
        }

        binaryNumber.Add(decimalNumber);

        binaryNumber.Reverse();

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < binaryNumber.Count; i++)
        {
            result.Append(binaryNumber[i]);
        }

        return result.ToString();
    }

    static string tres4Number(char digit)
    {
        switch (digit)
        {
            case '0': return "LON+";
            case '1': return "VK-";
            case '2': return "*ACAD";
            case '3': return "^MIM";
            case '4': return "ERIK|";
            case '5': return "SEY&";
            case '6': return "EMY>>";
            case '7': return "/TEL";
            case '8': return "<<DON";

            default: return "no";
        }
    }

    static void Main()
    {
        ulong input = ulong.Parse(Console.ReadLine());

        string octalNumber = DecimalToEight(input);

        //Console.WriteLine(octalNumber);

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < octalNumber.Length; i++)
        {
            result.Append(tres4Number(octalNumber[i]));
        }

        Console.WriteLine(result);
    }
}