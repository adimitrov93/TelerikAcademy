namespace StudentsTask
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    // 09. Create a class student with properties FirstName, LastName, FN, Tel, Email, Marks (a List<int>), GroupNumber.
    public class Student
    {
        // Fields
        private List<int> marks = new List<int>();

        // Constructor
        public Student(string firstName, string lastName, string fn, string tel, string email, List<int> marks, int groupNumber, string departmentName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FN = fn;
            this.Tel = tel;
            this.Email = email;
            this.Marks = marks;
            this.Groups = new Group(groupNumber, departmentName);
        }

        // Properties
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string FN { get; private set; }

        public string Tel { get; private set; }

        public string Email { get; private set; }

        public List<int> Marks
        {
            get
            {
                return new List<int>(this.marks);
            }
            private set
            {
                this.marks = value;
            }
        }

        public Group Groups { get; private set; }

        // Methods
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(string.Format("First name: {0}", this.FirstName));
            result.AppendLine(string.Format("Last name: {0}", this.LastName));
            result.AppendLine(string.Format("FN: {0}", this.FN));
            result.AppendLine(string.Format("Tel: {0}", this.Tel));
            result.AppendLine(string.Format("Email: {0}", this.Email));

            StringBuilder marksSB = new StringBuilder();
            foreach (var mark in Marks)
            {
                marksSB.AppendFormat("{0} ", mark);
            }

            result.AppendLine(string.Format("Marks: {0}", marksSB));
            result.AppendLine(string.Format("Group: {0} {1}", this.Groups.GroupNumber, this.Groups.DepartmentName));

            return result.ToString();
        }
    }
}
