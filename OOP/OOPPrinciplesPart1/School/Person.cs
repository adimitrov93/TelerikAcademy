namespace School
{
    using System;

    public abstract class Person
    {
        // Fields
        private string name;

        // Constructors
        public Person(string name)
        {
            this.Name = name;
        }

        // Properties
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty");
                }
                else if (value.Length < 2)
                {
                    throw new ArgumentException("Name cannot be less than 2 characters");
                }

                this.name = value;
            }
        }
    }
}
