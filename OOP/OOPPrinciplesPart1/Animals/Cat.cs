namespace Animals
{
    using System;

    public class Cat : Animal, ISound
    {
        // Constructors
        public Cat(string name, byte age, Sex sex)
            : base(name, age, sex)
        {

        }

        // Methods
        public override void ProduceSound()
        {
            Console.WriteLine("{0} said Mrrr", this.Name);
        }
    }
}
