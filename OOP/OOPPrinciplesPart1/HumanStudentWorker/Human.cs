namespace HumanStudentWorker
{
    using System;

    public abstract class Human
    {
        // Fields
        private string firstName;
        private string lastName;

        // Constructors
        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        // Properties
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name cannot be null or empty");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("First name cannot be less than 2 characters");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Last name cannot be null or empty");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("Last name cannot be less than 2 characters");
                }

                this.lastName = value;
            }
        }
    }
}
