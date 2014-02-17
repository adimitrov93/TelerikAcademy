namespace School
{
    using System;

    public class Discipline : ICommentable
    {
        // Fields
        protected string name;

        // Constructors
        public Discipline(string name, uint numberOfLectures, uint numberOfExercises)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExercises = numberOfExercises;
        }

        public Discipline(string name, uint numberOfLectures, uint numberOfExercises, string comment)
            : this(name, numberOfLectures, numberOfExercises)
        {
            this.Comment = comment;
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

        public uint NumberOfLectures { get; private set; }

        public uint NumberOfExercises { get; private set; }

        public string Comment { get; private set; }
    }
}