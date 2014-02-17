namespace StudentLINQQueries
{
    public class Student
    {
        public Student (string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} : {2}", this.FirstName, this.LastName, this.Age);
        }
    }
}
