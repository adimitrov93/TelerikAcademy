namespace ExtractStringThatApearOddNumberOfTimes
{
    using System;
    using System.Collections.Generic;

    public class ExtractStringThatApearOddNumberOfTimes
    {
        public static void Main()
        {
            string[] words = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (counts.ContainsKey(word))
                {
                    counts[word]++;
                }
                else
                {
                    counts[word] = 1;
                }
            }

            var result = new List<string>();

            foreach (var count in counts)
            {
                if (count.Value % 2 != 0)
                {
                    result.Add(count.Key);
                }
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
