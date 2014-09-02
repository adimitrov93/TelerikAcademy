namespace MessagesInABottle
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        static string secretMessage;
        static SortedDictionary<char, string> codes = new SortedDictionary<char, string>();
        static int possibleResults = 0;
        static List<string> results = new List<string>();

        static void Solver(int index, StringBuilder currentResult)
        {
            if (index >= secretMessage.Length)
            {
                possibleResults++;
                results.Add(currentResult.ToString());
                return;
            }
            else
            {
                foreach (var letter in codes)
                {
                    if (index + letter.Value.Length <= secretMessage.Length && secretMessage.Substring(index, letter.Value.Length) == letter.Value)
                    {
                        currentResult.Append(letter.Key);
                        Solver(index + letter.Value.Length, currentResult);
                        currentResult.Length--;
                    }
                }
            }
        }

        public static void Main()
        {
            secretMessage = Console.ReadLine();

            ExtractCodes();

            StringBuilder currentResult = new StringBuilder();

            Solver(0, currentResult);

            Console.WriteLine(possibleResults);

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }

        private static void ExtractCodes()
        {
            string cipher = Console.ReadLine();

            char currentLetter = ' ';
            string currentCode = string.Empty;

            for (int i = 0; i < cipher.Length; i++)
            {
                if (char.IsLetter(cipher[i]))
                {
                    if (currentLetter != ' ' && !codes.ContainsKey(currentLetter))
                    {
                        codes.Add(currentLetter, currentCode);
                    }

                    currentLetter = cipher[i];
                    currentCode = string.Empty;
                }
                else if (char.IsDigit(cipher[i]))
                {
                    currentCode += cipher[i];
                }
            }

            if (currentLetter != ' ')
            {
                codes.Add(currentLetter, currentCode);
            }
        }
    }
}
