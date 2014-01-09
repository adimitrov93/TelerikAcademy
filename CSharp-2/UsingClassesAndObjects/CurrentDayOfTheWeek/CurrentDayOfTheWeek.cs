//Write a program that prints to the console which day of the week is today. Use System.DateTime.

using System;

class CurrentDayOfTheWeek
{
    static void Main()
    {
        DateTime currentDate = DateTime.Today;

        Console.WriteLine("Today is {0}", currentDate.DayOfWeek);
    }
}