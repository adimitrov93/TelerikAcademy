namespace School
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private const int MaxStudentsInCourse = 30;

        private ICollection<Student> students;

        public Course()
        {
            this.students = new List<Student>();
        }

        public int StudentsCount
        {
            get
            {
                return this.students.Count;
            }
        }

        public void Join(Student student)
        {
            if (this.students.Count == MaxStudentsInCourse)
            {
                throw new OverflowException("This course is already full.");
            }

            this.students.Add(student);
        }

        public void Leave(Student student)
        {
            this.students.Remove(student);
        }
    }
}
