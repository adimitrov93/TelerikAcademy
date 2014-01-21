//Write a program that reads two dates in the format: day.month.year and calculates the number of days between them. Example:

using System;

class NumberOfDays
{
    static void Main()
    {
        Console.Write("Enter the first date: ");
        DateTime firstDate = DateTime.Parse(Console.ReadLine());

        Console.Write("Enter the second date: ");
        DateTime secondDate = DateTime.Parse(Console.ReadLine());

        var distance = (secondDate - firstDate);

        Console.WriteLine("Distance: {0} days", distance.TotalDays);
    }
}