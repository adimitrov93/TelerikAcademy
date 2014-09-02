namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Course
    {
        private string lab;

        public LocalCourse(string courseName)
            : base(courseName)
        {
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
            this.Lab = null;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {
                if (value != null && value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("Lab", "The lab must be at least 3 characters long.");
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            string baseToString = base.ToString();
            StringBuilder result = new StringBuilder("Local" + baseToString);

            if (this.Lab != null)
            {
                // Removes the } from the base.ToString().
                result.Length--;

                result.Append("; Lab = ");
                result.Append(this.Lab);
                result.Append(" }");
            }

            return result.ToString();
        }
    }
}
