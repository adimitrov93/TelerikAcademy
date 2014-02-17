namespace StudentLINQQueries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentMain
    {
        public static void Main()
        {
            List<Student> students = new List<Student>()
            {
                new Student("Petur", "Petrov", 20),
                new Student("Petur", "Ivanov", 20),
                new Student("Dimitrinka", "Petkova", 24),
                new Student("Ivan", "Furnadjiev", 18),
                new Student("Vasil", "Kirkov", 21),
                new Student("Vasil", "Avramov", 22)
            };

            var studentsWithFirstNameBeforeLastName = students.Where(st => st.FirstName.CompareTo(st.LastName) < 0);

            //foreach (var student in studentsWithFirstNameBeforeLastName)
            //{
            //    Console.WriteLine(student);
            //}

            var studentsWithAgeBetween18And24 = students.Where(st => st.Age >= 18 && st.Age <= 24);

            //foreach (var student in studentsWithAgeBetween18And24)
            //{
            //    Console.WriteLine(student);
            //}

            var sortedWithLINQ =
                from student in students
                orderby student.FirstName descending, student.LastName descending
                select student;

            //foreach (var student in sortedWithLINQ)
            //{
            //    Console.WriteLine(student);
            //}

            var sortedWithLambda = students.OrderByDescending(st => st.FirstName).ThenByDescending(st => st.LastName);

            //foreach (var student in sortedWithLambda)
            //{
            //    Console.WriteLine(student);
            //}
        }
    }
}
