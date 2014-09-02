using System;
using System.Diagnostics;
namespace LargeCompanyArticles
{
    public class Program
    {
        private static Random rnd = new Random();

        public static void Main()
        {
            var company = new Company();

            Console.Write("Please wait...");

            var sw = new Stopwatch();
            sw.Start();

            // 500 000 products
            for (int i = 0; i < 500000; i++)
            {
                company.AddArticle(new Article
                    {
                        Barcode = rnd.Next(2000000000).ToString(),
                        Title = "Article" + i,
                        Vendor = "Vendor" + i,
                        Price = rnd.Next(10000)
                    });
            }

            sw.Stop();

            Console.WriteLine("\rAdding products -> Elapsed time: {0}", sw.Elapsed);

            sw.Restart();

            // 5 000 000 price searches
            for (int i = 0; i < 5000000; i++)
            {
                int min = rnd.Next(1000);
                int max = rnd.Next(1000, 10000);

                company.GetArticlesInRange(min, max);
            }

            sw.Stop();

            Console.WriteLine("\nSearching products -> Elapsed time: {0}\n", sw.Elapsed);
        }
    }
}
