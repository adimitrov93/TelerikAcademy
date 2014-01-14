//Write a method that calculates the number of workdays between today and given date, passed as parameter. Consider that workdays are all days from Monday to Friday except a fixed list of public holidays
//specified preliminary as array.

using System;

class WorkingDaysCalculator
{
    //This work only for 2014. If needed for other year holidays array must be updated

    static DateTime[] holidays = 
    {
        new DateTime(2014, 1, 1),
        new DateTime(2014, 3, 3),
        new DateTime(2014, 4, 18),
        new DateTime(2014, 4, 21),
        new DateTime(2014, 5, 1),
        new DateTime(2014, 5, 2),
        new DateTime(2014, 5, 5),
        new DateTime(2014, 5, 6),
        new DateTime(2014, 9, 22),
        new DateTime(2014, 11, 1),
        new DateTime(2014, 12, 24),
        new DateTime(2014, 12, 25),
        new DateTime(2014, 12, 26),
        new DateTime(2014, 12, 31)
    };

    static bool IsHoliday(DateTime date)        //Search the database and check if a date is holiday
    {
        bool isHoliday = false;

        foreach (var holiday in holidays)
        {
            if (date == holiday)
            {
                isHoliday = true;
            }
        }

        return isHoliday;
    }

    static int WorkingDays(DateTime endDate)    //Count the number of working days from today to endDate
    {
        DateTime currentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        int workingDays = 0;

        while (currentDate.CompareTo(endDate) <= 0)
        {
            if (!IsHoliday(currentDate) && !currentDate.DayOfWeek.Equals(DayOfWeek.Saturday) && !currentDate.DayOfWeek.Equals(DayOfWeek.Sunday))
            {
                workingDays++;
            }

            currentDate = currentDate.AddDays(1);
        }

        return workingDays;
    }

    static string PrintDate(DateTime date)      //Returns formatted string with date
    {
        return String.Format("{0}.{1}.{2}", date.Date.Day, date.Date.Month, date.Date.Year);
    }

    static void Main()
    {
        DateTime inputDate = new DateTime();

        //get date
        try
        {
            Console.Write("Enter end date in format dd.mm.yyyy: ");
            inputDate = DateTime.Parse(Console.ReadLine());

            if (inputDate.CompareTo(DateTime.Now) < 0)
            {
                throw new Exception("The date must be at least tommorow.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("You entered wrong date!");
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        //count the working dayss
        int workingDays = WorkingDays(inputDate);

        //print result
        Console.WriteLine("From today ({0}) to {1} there are {2} working days.", PrintDate(DateTime.Now), PrintDate(inputDate), workingDays);
    }
}