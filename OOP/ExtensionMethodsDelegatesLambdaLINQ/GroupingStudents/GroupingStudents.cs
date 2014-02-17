namespace GroupingStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GroupingStudents
    {
        public static List<Student> students = new List<Student>()
        {
            new Student("Dragan Cankov", "Oscar Wilde"),
            new Student("Petur Kirkov", "G.M. Dimitrov"),
            new Student("Petranka Djimidjunkova", "Oscar Wilde"),
            new Student("Ivan Ivanov", "Oscar Wilde"),
            new Student("Dimitur Petkov", "G.M. Dimitrov")
        };

        public static void Main()
        {
            GroupStudentsWithLINQ();
            Console.WriteLine(new string('-', 25));
            GroupStudentsWithLambda();
        }

        // 18. Create a program that extracts all students grouped by GroupName and then prints them to the console. Use LINQ.
        public static void GroupStudentsWithLINQ()
        {
            var groupedStudents =
                from st in students
                group st by st.GroupName into newGroup
                orderby newGroup.Key
                select newGroup;

            foreach (var group in groupedStudents)
            {
                Console.WriteLine(group.Key + ":");

                foreach (var student in group)
                {
                    Console.WriteLine(student);
                }

                Console.WriteLine();
            }
        }

        // 19. Rewrite the previous using extension methods.
        public static void GroupStudentsWithLambda()
        {
            var groupedStudents = students.GroupBy(st => st.GroupName).OrderBy(gr => gr.Key);

            foreach (var group in groupedStudents)
            {
                Console.WriteLine(group.Key + ":");

                foreach (var student in group)
                {
                    Console.WriteLine(student);
                }

                Console.WriteLine();
            }
        }
    }
}
