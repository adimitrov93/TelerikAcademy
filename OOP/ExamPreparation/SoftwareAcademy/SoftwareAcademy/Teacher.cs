namespace SoftwareAcademy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Teacher : ITeacher
    {
        private string name;
        private IList<ICourse> courses;

        public Teacher(string name)
        {
            this.Name = name;
            this.courses = new List<ICourse>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null of empty");
                }

                this.name = value;
            }
        }

        public void AddCourse(ICourse course)
        {
            this.courses.Add(course);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("Teacher: ");
            result.Append(string.Format("Name={0}", this.Name));

            if (this.courses.Count != 0)
            {
                // string coursesAsString = string.Join(", ", this.courses);

                result.Append("; Courses=[");

                foreach (var course in this.courses)
                {
                    result.Append(string.Format("{0}, ", course.Name));
                }

                result.Length -= 2;
                result.Append("]");
            }

            return result.ToString();
        }
    }
}
