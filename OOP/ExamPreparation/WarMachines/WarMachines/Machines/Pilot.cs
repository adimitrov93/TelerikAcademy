namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using WarMachines.Interfaces;

    public class Pilot : IPilot
    {
        private string name;
        private IList<IMachine> engagedMachines;

        public Pilot(string name)
        {
            this.Name = name;
            engagedMachines = new List<IMachine>();
        }

        public Pilot(IPilot pilot)
        {
            var pilotToClone = pilot as Pilot;

            if (pilotToClone != null)
            {
                this.Name = pilotToClone.Name;
                this.engagedMachines = new List<IMachine>(pilotToClone.engagedMachines);
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty");
                }

                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            this.engagedMachines.Add(machine);
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            string numberOfMachines = this.engagedMachines.Count != 0 ? this.engagedMachines.Count.ToString() : "no";
            string machinesWord = this.engagedMachines.Count != 1 ? "machines" : "machine";
            result.Append(string.Format("{0} - {1} {2}", this.Name, numberOfMachines, machinesWord));

            if (this.engagedMachines.Count != 0)
            {
                result.AppendLine();
            }

            var sortedEngagedMachines = this.engagedMachines.OrderBy(m => m.HealthPoints).ThenBy(m => m.Name);

            foreach (var machine in sortedEngagedMachines)
            {
                result.Append(machine.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
