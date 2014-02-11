namespace GenericList
{
    using System;

    public class GenericListMain
    {
        public static void Main()
        {
            GenericList<int> list = new GenericList<int>(5);
            list.Add(6);
            list.Add(3);
            list.Add(9);
            list.Add(-7);
            list.InsertAt(925, 2);
            list.Add(222);
            list.Add(2);

            Console.WriteLine(list.Min());
            Console.WriteLine(list.Max());
            Console.WriteLine(list.IndexOf(2));
            Console.WriteLine(list.ElementAt(3));

            list[6] = 666;

            Console.WriteLine(list[6]);
            Console.WriteLine(list.ToString());
        }
    }
}