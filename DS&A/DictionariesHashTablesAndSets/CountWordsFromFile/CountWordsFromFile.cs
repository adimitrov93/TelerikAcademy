namespace CountWordsFromFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class CountWordsFromFile
    {
        public static void Main()
        {
            string allText = File.ReadAllText("..\\..\\words.txt").ToLower();
            var words = allText.Split(new [] { ' ', '.', ',', '!', '-', '?', ';', '\'', '\"', ':' }, StringSplitOptions.RemoveEmptyEntries);

            var counts = new Dictionary<string, int>();

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

            var sortedCounts = counts.OrderBy(x => x.Value);

            foreach (var count in sortedCounts)
            {
                Console.WriteLine("{0} -> {1}", count.Key, count.Value);
            }
        }
    }
}
