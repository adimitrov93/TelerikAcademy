namespace Animals
{
    using System;

    public class Dog : Animal, ISound
    {
        // Constructors
        public Dog(string name, byte age, Sex sex)
            : base(name, age, sex)
        {

        }

        // Methods
        public override void ProduceSound()
        {
            Console.WriteLine("{0} said Bau", this.Name);
        }
    }
}
