namespace Animals
{
    using System;

    public class Frog : Animal, ISound
    {
        // Constructors
        public Frog(string name, byte age, Sex sex)
            : base(name, age, sex)
        {

        }

        // Methods
        public override void ProduceSound()
        {
            Console.WriteLine("{0} said Ribbit", this.Name);
        }
    }
}
