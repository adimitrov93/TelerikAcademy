namespace HashedSet
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var hashSet = new HashedSet<int>();

            hashSet.Add(1);
            hashSet.Add(1);
            hashSet.Add(1);
            hashSet.Add(1);
            hashSet.Add(1);
            hashSet.Add(1);
            hashSet.Add(1);
            hashSet.Add(2);
            hashSet.Add(3);
            hashSet.Add(4);
            hashSet.Add(5);

            foreach (var number in hashSet)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("Count: " + hashSet.Count);
            Console.WriteLine(new string('-', 40));
            hashSet.Remove(2);

            foreach (var number in hashSet)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine(new string('-', 40));

            var unionHashSet = new HashedSet<int>();

            unionHashSet.Add(5);
            unionHashSet.Add(6);
            unionHashSet.Add(7);

            var intersectHashSet = new HashedSet<int>();

            intersectHashSet.Add(5);
            intersectHashSet.Add(4);
            intersectHashSet.Add(7);

            unionHashSet.UnionWith(hashSet);
            intersectHashSet.IntersectWith(hashSet);

            foreach (var item in unionHashSet)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 40));

            foreach (var item in intersectHashSet)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 40));
        }
    }
}
