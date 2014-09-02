namespace StudentsAndCourses
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Program
    {
        private static IDictionary<string, IList<string>> courses = new SortedDictionary<string, IList<string>>();

        public static void Main()
        {
            var lines = File.ReadLines("..\\..\\Students.txt");

            foreach (var line in lines)
            {
                var parts = line.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                var course = parts[2].Trim();
                var student = string.Format("{0} {1}", parts[0].Trim(), parts[1].Trim());

                if (!courses.ContainsKey(course))
                {
                    courses[course] = new List<string>();
                }

                courses[course].Add(student);
            }

            foreach (var course in courses)
            {
                var sortedStudents = course.Value.OrderBy(st => st);
                Console.WriteLine("{0} -> {1}", course.Key, string.Join(", ", sortedStudents));
            }
        }
    }
}