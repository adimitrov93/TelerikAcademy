//Write a method that reverses the digits of given decimal number. Example: 256  652

using System;

class ReverseTheDigitsOfNumber
{
    static decimal ReverseDigits(decimal number)
    {
        string numberInString = number.ToString();
        char[] numberInCharArray = numberInString.ToCharArray();

        Array.Reverse(numberInCharArray);

        numberInString = new string(numberInCharArray);
        number = decimal.Parse(numberInString);

        return number;
    }

    static void Main()
    {
        decimal number = 256m;
        decimal reversedNumber = ReverseDigits(number);

        Console.WriteLine("{0} -> {1}", number, reversedNumber);
    }
}