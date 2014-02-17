namespace School
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        public static void Main()
        {
            List<Student> students = new List<Student>()
            {
                new Student("Ivan", 1),
                new Student("Petkan", 2),
                new Student("Dragan", 3)
            };

            Teacher[] teachers =
            {
                new Teacher("Petkova", new List<Discipline>(){ new Discipline("Math", 2, 2) })
            };

            Class newClass = new Class("2a", students, teachers);
        }
    }
}