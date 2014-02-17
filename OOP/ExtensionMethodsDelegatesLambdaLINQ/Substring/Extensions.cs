//Implement an extension method Substring(int index, int length) for the class StringBuilder that returns new StringBuilder and has the same functionality as Substring in the class String.

namespace Substring
{
    using System;
    using System.Text;

    public static class Extensions
    {
        public static void Main()
        {
            StringBuilder name = new StringBuilder("Telerik Academy");

            Console.WriteLine(name.Substring(2, 12));
        }

        public static StringBuilder Substring(this StringBuilder str, int index, int length)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                result.Append(str[index]);
                index++;

                if (index >= str.Length)
                {
                    break;
                }
            }

            return result;
        }
    }
}
