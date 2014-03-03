namespace WarMachines.Machines
{
    using System.Text;

    using WarMachines.Interfaces;

    public class Tank : Machine, ITank
    {
        private const double InitialHealthPoints = 100;
        private const string On = "ON";
        private const string Off = "OFF";

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, InitialHealthPoints, attackPoints, defensePoints)
        {
            this.DefenseMode = false;
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == false)
            {
                this.DefensePoints += 30;
                this.AttackPoints -= 40;
            }
            else
            {
                this.DefensePoints -= 30;
                this.AttackPoints += 40;
            }

            this.DefenseMode = !DefenseMode;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());

            result.AppendLine(string.Format(" *Defense: {0}", this.DefenseMode ? On : Off));

            return result.ToString();
        }
    }
}
