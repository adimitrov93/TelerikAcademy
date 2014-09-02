namespace FindingWordsInAText
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;

    using Gma.DataStructures.StringSearch;

    public class Program
    {
        public static void Main()
        {
            var trie = new Trie<int>();

            BuildUp("..\\..\\sampleText.txt", trie);

            var wordsToSearch = GetWordsFromFile("..\\..\\sampleSearchWords.txt");
            var sw = new Stopwatch();
            sw.Start();
            foreach (var word in wordsToSearch)
            {
                LookUp(word.word, trie);
            }

            Console.WriteLine("Searching for 1000 words: {0}", sw.Elapsed);
        }

        private static void BuildUp(string fileName, ITrie<int> trie)
        {
            IEnumerable<Word> allWordsInFile = GetWordsFromFile(fileName);
            foreach (var word in allWordsInFile)
            {
                trie.Add(word.word, word.line);
            }
        }

        private static void LookUp(string searchString, ITrie<int> trie)
        {
            //Console.WriteLine("----------------------------------------");
            //Console.WriteLine("Look-up for string '{0}'", searchString);
            //var sw = new Stopwatch();
            //sw.Start();

            trie.Retrieve(searchString).ToArray();
            //sw.Stop();

            //string matchesText = String.Join(",", result);
            //int matchesCount = result.Count();

            //if (matchesCount == 0)
            //{
            //    Console.WriteLine("No matches found.\tTime: {0}", sw.Elapsed);
            //}
            //else
            //{
            //    Console.WriteLine(" {0} matches found. \tTime: {1}\tLines: {2}", matchesCount, sw.Elapsed,
            //        matchesText);
            //}
        }


        private static IEnumerable<Word> GetWordsFromFile(string file)
        {
            using (StreamReader reader = File.OpenText(file))
            {
                Console.WriteLine("Processing file {0} ...", file);
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                int lineNo = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    lineNo++;
                    IEnumerable<string> words = GetWordsFromLine(line);
                    foreach (string word in words)
                    {
                        yield return new Word { line = lineNo, word = word };
                    }
                }
                stopWatch.Stop();
                Console.WriteLine("Lines:{0}\tTime:{1}", lineNo, stopWatch.Elapsed);
            }
        }

        private static IEnumerable<string> GetWordsFromLine(string line)
        {
            var word = new StringBuilder();
            foreach (char ch in line)
            {
                if (char.IsLetter(ch))
                {
                    word.Append(ch);
                }
                else
                {
                    if (word.Length == 0) continue;
                    yield return word.ToString();
                    word.Clear();
                }
            }
        }
    }
}
