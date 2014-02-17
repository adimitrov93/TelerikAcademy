namespace Animals
{
    using System;
    using System.Collections;

    public abstract class Animal : ISound
    {
        // Fields
        private string name;

        // Constructors
        public Animal(string name, byte age, Sex sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
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
                if (value.Length < 2)
                {
                    throw new ArgumentException("Name cannot be less than 2 characters");
                }

                this.name = value;
            }
        }

        public byte Age { get; private set; }

        public Sex Sex { get; private set; }

        //Methods
        public abstract void ProduceSound();

        public static void ForEach(ICollection animals)
        {
            foreach (var animal in animals)
            {
                (animal as Animal).ProduceSound();
            }
        }
    }
}
