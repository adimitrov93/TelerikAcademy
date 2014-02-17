namespace StudentsTask
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class StudentsTask
    {
        // 09. Create a List<Student> with sample students.
        static List<Student> students = new List<Student>()
        {
            new Student("Pesho", "Peshov", "15150689", "02989596", "pesho@abv.bg", new List<int>(){ 6, 3, 2, 5, 5, 4}, 2, "Mathematics"),
            new Student("Gosho", "Goshov", "15150699", "06291949", "gosho@abv.bg", new List<int>(){ 3, 4, 5, 2, 5, 2}, 3, "Chemistry"),
            new Student("Ivan", "Ivanov", "15153303", "04665919", "ivan@gmail.com", new List<int>(){ 5, 2, 3, 5, 6, 3}, 2, "Physics"),
            new Student("Dragan", "Arabadjiev", "15154112", "0292925408", "drago@mail.bg", new List<int>(){ 2, 6, 3, 3, 6, 2}, 1, "Mathematics"),
            new Student("Dimitrinka", "Ovcharova", "15150622", "0895119", "dimka@abv.bg", new List<int>(){ 2, 5, 3, 3, 2, 2}, 2, "Mathematics")
        };

        public static void Main()
        {
            FindStudentsFromGroup2WithLINQ();
            Console.WriteLine(new string('-', 25));
            FindStudentsFromGroup2WithLambda();
            Console.WriteLine(new string('-', 25));
            FindStudentsIWithAbvEmailWithLINQ();
            Console.WriteLine(new string('-', 25));
            FindStudentWithPhonesInSofiaWithLINQ();
            Console.WriteLine(new string('-', 25));
            FindStudentsWithMark6WithLINQ();
            Console.WriteLine(new string('-', 25));
            FindStudentsWithMarksTwoMarks2WithLimbda();
            Console.WriteLine(new string('-', 25));
            FindMarksOfThe2006Students();
            Console.WriteLine(new string('-', 25));
            FindStudentsFromMathematics();
        }

        // Extension method for List<>
        public static void Print(this IEnumerable<Student> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        // 09. Select only the students that are from group number 2. Use LINQ query. Order the students by FirstName.
        public static void FindStudentsFromGroup2WithLINQ()
        {
            var extracted =
                from student in students
                where student.Groups.GroupNumber == 2
                orderby student.FirstName
                select student;

            extracted.Print();
        }

        // 10. Implement the previous using the same query expressed with extension methods.
        public static void FindStudentsFromGroup2WithLambda()
        {
            var extracted = students.Where(st => st.Groups.GroupNumber == 2).OrderBy(st => st.FirstName);

            extracted.Print();
        }

        // 11. Extract all students that have email in abv.bg. Use string methods and LINQ.
        public static void FindStudentsIWithAbvEmailWithLINQ()
        {
            var extracted =
                from st in students
                where st.Email.EndsWith("abv.bg")
                select st;

            extracted.Print();
        }

        // 12. Extract all students with phones in Sofia. Use LINQ.
        public static void FindStudentWithPhonesInSofiaWithLINQ()
        {
            var extracted =
                from st in students
                where st.Tel.StartsWith("02")
                select st;

            extracted.Print();
        }

        // 13. Select all students that have at least one mark Excellent (6) into a new anonymous class that has properties – FullName and Marks. Use LINQ.
        public static void FindStudentsWithMark6WithLINQ()
        {
            var extracted =
                from st in students
                where st.Marks.Contains(6)
                select new
                {
                    FullName = st.FirstName + " " + st.LastName,
                    Marks = st.Marks
                };

            foreach (var st in extracted)
            {
                Console.WriteLine("Full name: {0}", st.FullName);

                foreach (var mark in st.Marks)
                {
                    Console.Write("{0} ", mark);
                }

                Console.WriteLine();
            }
        }

        // 14. Write down a similar program that extracts the students with exactly  two marks "2". Use extension methods.
        public static void FindStudentsWithMarksTwoMarks2WithLimbda()
        {
            var extracted = students.Where(st => st.Marks.FindAll(x => x == 2).Count == 2);

            extracted.Print();
        }

        // 15. Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
        public static void FindMarksOfThe2006Students()
        {
            var extracted = students.Where(st => st.FN.Substring(4, 2).Equals("06")).Select(st => st.Marks);

            foreach (var marks in extracted)
            {
                foreach (var mark in marks)
                {
                    Console.Write("{0} ", mark);
                }

                Console.WriteLine();
            }
        }

        // 16. Extract all students from "Mathematics" department. Use the Join operator.
        public static void FindStudentsFromMathematics()
        {
            Group[] groups = { new Group(0, "Mathematics") };

            var extracted =
                from st in students
                join gr in groups on st.Groups.DepartmentName equals gr.DepartmentName
                select st;

            extracted.Print();
        }
    }
}
