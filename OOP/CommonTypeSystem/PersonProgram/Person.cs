/*
 * Create a class Person with two fields – name and age. Age can be left unspecified (may contain null value.
 * Override ToString() to display the information of a person and if age is not specified – to say so. 
 */

namespace PersonProgram
{
    using System.Text;

    public class Person
    {
        // Constructors
        public Person(string name, byte? age = null)
        {
            this.Name = name;
            this.Age = age;
        }

        // Properties
        public string Name { get; private set; }

        public byte? Age { get; private set; }
        
        // Methods
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(string.Format("Name: {0}", this.Name));
            result.AppendLine(string.Format("Age: {0}", this.Age.HasValue ? this.Age.ToString() : "Not specified"));

            return result.ToString();
        }
    }
}
