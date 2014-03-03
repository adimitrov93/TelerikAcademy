namespace WarMachines.Machines
{
    using System.Text;

    using WarMachines.Interfaces;

    public class Fighter : Machine, IFighter
    {
        private const double InitialHealthPoints = 200;
        private const string On = "ON";
        private const string Off = "OFF";

        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            : base(name, InitialHealthPoints, attackPoints, defensePoints)
        {
            this.StealthMode = stealthMode;
        }

        public bool StealthMode { get; private set; }

        public void ToggleStealthMode()
        {
            this.StealthMode = !StealthMode;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());

            result.Append(string.Format(" *Stealth: {0}", this.StealthMode ? On : Off));

            return result.ToString();
        }
    }
}
