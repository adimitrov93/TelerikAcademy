// Write a program to test this functionality.

namespace PersonProgram
{
    using System;

    public class PersonProgram
    {
        public static void Main()
        {
            Person person = new Person("Teodor");

            Console.WriteLine(person);

            person = new Person("Stefan", 20);

            Console.WriteLine(person);
        }
    }
}
