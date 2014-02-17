//Write a program to return the string with maximum length from an array of strings. Use LINQ.

namespace MaximumLenght
{
    using System;
    using System.Linq;

    public class MaximumLenght
    {
        public static int maxLenght = 0;

        public static void Main()
        {
            string[] arrayOfStrings =
            {
                "Telerik",
                "Academy",
                "Software",
                "Developers",
                "Skills",
                "LINQ"
            };

            var longestWords =
                from str in arrayOfStrings
                where IsLongest(str)
                select str;

            Console.WriteLine(longestWords.Last());
        }

        private static bool IsLongest(string str)
        {
            if (str.Length > maxLenght)
            {
                maxLenght = str.Length;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}