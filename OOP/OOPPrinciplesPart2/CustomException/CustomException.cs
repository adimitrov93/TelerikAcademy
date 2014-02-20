namespace CustomException
{
    using System;

    public class CustomException
    {
        public static void Main()
        {
            int startRange = 1;
            int endRange = 100;

            Console.Write("Enter a number between {0} and {1}:", startRange, endRange);
            int someNumber = int.Parse(Console.ReadLine());

            if (someNumber < 1 || someNumber > 100)
            {
                throw new InvalidRangeException<int>(1, 100);
            }

            DateTime startDate = new DateTime(1980, 1, 1);
            DateTime endDate = new DateTime(2013, 12, 21);

            Console.Write("Enter a date between {0}.{1}.{2} and {3}.{4}.{5}", startDate.Day, startDate.Month, startDate.Year, endDate.Day, endDate.Month, endDate.Year);
            DateTime someDate = DateTime.Parse(Console.ReadLine());

            if (someDate < startDate || someDate > endDate)
            {
                throw new InvalidRangeException<DateTime>("Invalid date!", startDate, endDate);
            }
        }
    }
}
