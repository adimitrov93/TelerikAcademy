namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class AnimalsDemo
    {
        public static void Main()
        {
            Dog[] dogs =
            {
                new Dog("Argos", 2, Sex.Male),
                new Dog("Dingo", 3, Sex.Male),
                new Dog("Fluffy", 1, Sex.Female),
                new Dog("Lassie", 3, Sex.Female)
            };

            Cat[] cats =
            {
                new Cat("Oscar", 2, Sex.Male),
                new Kitten("Snowy", 1),
                new Cat("Molly", 3, Sex.Female),
                new Tomcat("Coco", 5)
            };

            Frog[] frogs =
            {
                new Frog("Kermit", 5, Sex.Male),
                new Frog("Greenie", 3, Sex.Female)
            };

            Animal.ForEach(dogs);
            Animal.ForEach(cats);
            Animal.ForEach(frogs);

            Console.WriteLine();

            Console.WriteLine(dogs.Average(x => x.Age));
            Console.WriteLine(cats.Average(x => x.Age));
            Console.WriteLine(frogs.Average(x => x.Age));
        }
    }
}
