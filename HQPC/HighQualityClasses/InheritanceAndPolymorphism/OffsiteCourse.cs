namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class OffsiteCourse : Course
    {
        private string town;

        public OffsiteCourse(string courseName)
            : base(courseName)
        {
            this.Town = null;
        }

        public OffsiteCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
            this.Town = null;
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
            this.Town = null;
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            set
            {
                if (value != null && value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("Town", "The town must be at least 3 characters long.");
                }

                this.town = value;
            }
        }

        public override string ToString()
        {
            string baseToString = base.ToString();
            StringBuilder result = new StringBuilder("Offsite" + baseToString);

            if (this.Town != null)
            {
                // Removes the } from the base.ToString().
                result.Length--;

                result.Append("; Town = ");
                result.Append(this.Town);
                result.Append(" }");
            }

            return result.ToString();
        }
    }
}
