//Write a program that reads a date and time given in the format: day.month.year hour:minute:second and prints the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.

using System;
using System.Globalization;
using System.Threading;

class HourAddition
{
    static void Main()
    {
        Console.Write("Enter the date and time int format day.mount.year hour:minute:second: ");
        DateTime input = DateTime.Parse(Console.ReadLine());

        input = input.AddMinutes(390);      //6 hours and 30 minutes

        string format = "dd.MM.yyyy dddd HH:mm:ss";

        Console.WriteLine(input.ToString(format, CultureInfo.CreateSpecificCulture("bg-BG")));
    }
}