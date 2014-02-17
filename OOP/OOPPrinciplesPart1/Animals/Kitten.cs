namespace Animals
{
    using System;

    public class Kitten : Cat, ISound
    {
        // Constructors
        public Kitten(string name, byte age)
            : base(name, age, Sex.Female)
        {

        }

        // Methods
        public override void ProduceSound()
        {
            Console.WriteLine("{0} said Miau", this.Name);
        }
    }
}
