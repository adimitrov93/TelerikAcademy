namespace School
{
    using System;
    using System.Collections.Generic;

    public class Class : ICommentable
    {
        // Fields
        private ICollection<Student> students;
        private ICollection<Teacher> teachers;

        // Constructors
        public Class(string uniqueIndentifier, ICollection<Student> students, ICollection<Teacher> teachers)
        {
            this.UniqueIndentifier = uniqueIndentifier;
            this.Students = students;
            this.Teachers = teachers;
        }

        public Class(string uniqueIndentifier, ICollection<Student> students, ICollection<Teacher> teachers, string comment)
            : this(uniqueIndentifier, students, teachers)
        {
            this.Comment = comment;
        }

        // Properties
        public string UniqueIndentifier { get; private set; }

        public ICollection<Student> Students
        {
            get
            {
                return new List<Student>(this.students);
            }
            private set
            {
                if (value.Count <= 1)
                {
                    throw new ArgumentException("The class must have at least 2 students");
                }

                this.students = value;
            }
        }

        public ICollection<Teacher> Teachers
        {
            get
            {
                return new List<Teacher>(this.teachers);
            }
            private set
            {
                if (value.Count == 0)
                {
                    throw new ArgumentException("The class must have at least 1 teacher");
                }

                this.teachers = value;
            }
        }

        public string Comment { get; private set; }
    }
}