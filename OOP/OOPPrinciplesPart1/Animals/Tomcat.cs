namespace Animals
{
    using System;

    public class Tomcat : Cat, ISound
    {
        // Constructors
        public Tomcat(string name, byte age)
            : base(name, age, Sex.Male)
        {

        }

        // Methods
        public override void ProduceSound()
        {
            Console.WriteLine("{0} growls", this.Name);
        }
    }
}
