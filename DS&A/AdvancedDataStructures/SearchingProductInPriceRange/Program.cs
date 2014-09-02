namespace SearchingProductInPriceRange
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    
    using Wintellect.PowerCollections;

    public class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            var orderedBag = new OrderedBag<Product>();
            var totalTime = default(TimeSpan);

            sw.Start();
            AddProductsToBag(orderedBag, 500000);
            Console.WriteLine("Time taken for adding 500000 items: {0}", sw.Elapsed);

            for (int i = 0; i < 10000; i++)
            {
                sw.Start();

                List<Product> found = FindFirst20(orderedBag, 100000, 100000 + i * 2);

                totalTime += sw.Elapsed;
            }

            Console.WriteLine("Range searching for 10000 items done in: {0}", totalTime);
        }

        public static void AddProductsToBag(OrderedBag<Product> orderedBag, int numberOfItems)
        {
            for (int i = 1; i <= numberOfItems; i++)
            {
                orderedBag.Add(new Product(i.ToString(), i));
            }
        }

        public static List<Product> FindFirst20(OrderedBag<Product> orderedBag, int lowPrice, int highPrice)
        {
            var from = new Product("searchItem", highPrice);
            var to = new Product("searchItem", lowPrice);

            var results = orderedBag.Range(from, true, to, true).Take(20);

            return results.ToList();
        }
    }
}
