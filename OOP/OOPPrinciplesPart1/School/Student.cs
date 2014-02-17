namespace School
{
    using System;

    public class Student : Person, ICommentable
    {
        //Constructors
        public Student(string name, uint classNumber)
            : base(name)
        {
            this.ClassNumber = classNumber;
        }

        public Student(string name, uint classNumber, string comment)
            : this(name, classNumber)
        {
            this.Comment = comment;
        }

        // Properties
        public uint ClassNumber { get; private set; }

        public string Comment { get; private set; }
    }
}