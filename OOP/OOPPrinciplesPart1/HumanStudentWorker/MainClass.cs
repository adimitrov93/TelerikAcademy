namespace HumanStudentWorker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MainClass
    {
        public static void Main()
        {
            List<Student> students = new List<Student>()
            {
                new Student("Dragan", "Cankov", 6),
                new Student("Ivan", "Petrakiev", 4),
                new Student("Pavlin", "Petrov", 5),
                new Student("Petur", "Kirkov", 2),
                new Student("Ilian", "Peshev", 3),
                new Student("Dimitur", "Dimitrov", 6),
                new Student("Diana", "Petrova", 5),
                new Student("Ivana", "Smokovlieva", 4),
                new Student("Kamelia", "Arsova", 2),
                new Student("Lilia", "Ninova", 4)
            };

            var sortedStudents = students.OrderBy(st => st.Grade);

            List<Worker> workers = new List<Worker>()
            {
                new Worker("Hristo", "Iordanov", 250, 8),
                new Worker("Todor", "Nikolov", 280, 10),
                new Worker("Atanas", "Marinov", 200, 6),
                new Worker("Angel", "Stefanov", 220, 8),
                new Worker("Maria", "Mihailova", 230, 6),
                new Worker("Elena", "Kirilova", 290, 8),
                new Worker("Liliana", "Dimitrova", 250, 7),
                new Worker("Violeta", "Misheva", 260, 8),
                new Worker("Rumiana", "Rimitrova", 320, 12),
                new Worker("Emilia", "Georgieva", 300, 10)
            };

            var sortedWorkers = workers.OrderByDescending(w => w.MoneyPerHour());

            var mergedList = sortedStudents.Concat<Human>(sortedWorkers).OrderBy(x => x.FirstName).ThenBy(x => x.LastName);
        }
    }
}
