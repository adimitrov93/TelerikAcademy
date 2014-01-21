//Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. Display them in the standard date format for Canada.

using System;
using System.Text.RegularExpressions;

class ExtractDate
{
    const string pattern = "[0-9]{1,2}.[0-9]{1,2}.[0-9]{4}";
    static void Main()
    {
        string text = "This year the Telerik academy started at 28.10.2013. It will finish 2.1.2014.";

        Regex regex = new Regex(pattern);

        MatchCollection dates = regex.Matches(text);

        foreach (var date in dates)
        {
            Console.WriteLine(date);
        }
    }
}