namespace StudentsTask
{
    // 16. * Create a class Group with properties GroupNumber and DepartmentName. Introduce a property Group in the Student class.
    public class Group
    {
        // Constructors
        public Group(int groupNumber, string departmentName)
        {
            this.GroupNumber = groupNumber;
            this.DepartmentName = departmentName;
        }

        // Properties
        public int GroupNumber { get; private set; }

        public string DepartmentName { get; private set; }
    }
}