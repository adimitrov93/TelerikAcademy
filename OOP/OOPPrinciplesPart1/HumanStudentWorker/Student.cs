namespace HumanStudentWorker
{
    using System;

    public class Student : Human
    {
        // Fields
        private byte grade;

        // Constructors
        public Student(string firstName, string lastName, byte grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        // Properties
        public byte Grade
        {
            get
            {
                return this.grade;
            }
            private set
            {
                if (value < 2 || value > 6)
                {
                    throw new ArgumentException("Grade must be between 2 and 6 inclusively");
                }

                this.grade = value;
            }
        }
    }
}
