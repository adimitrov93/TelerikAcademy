namespace GroupingStudents
{
    public class Student
    {
        // Constructor
        public Student(string fullName, string groupName)
        {
            this.FullName = fullName;
            this.GroupName = groupName;
        }

        // Properties
        public string FullName { get; private set; }

        public string GroupName { get; private set; }

        // Methods
        public override string ToString()
        {
            return this.FullName;
        }
    }
}
