namespace School
{
    using System;
    using System.Collections.Generic;

    public class Teacher : Person, ICommentable
    {
        // Fields
        private ICollection<Discipline> disciplines;

        // Constructors
        public Teacher(string name, List<Discipline> disciplines)
            : base(name)
        {
            this.Disciplines = disciplines;
        }

        public Teacher(string name, List<Discipline> disciplines, string comment)
            : this(name, disciplines)
        {
            this.Comment = comment;
        }

        // Properties
        public ICollection<Discipline> Disciplines
        {
            get
            {
                return new List<Discipline>(this.disciplines);
            }
            private set
            {
                if (value.Count == 0)
                {
                    throw new ArgumentException("The teacher must have at least 1 discipline");
                }

                this.disciplines = value;
            }
        }

        public string Comment { get; private set; }
    }
}