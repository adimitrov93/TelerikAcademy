namespace HumanStudentWorker
{
    using System;

    public class Worker : Human
    {
        // Fields
        private decimal workHoursPerDay;

        // Constructors
        public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        // Properties
        public decimal WeekSalary { get; private set; }

        public decimal WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            private set
            {
                if (value > 24)
                {
                    throw new ArgumentException("Work hours per day cannot be more than one day");
                }

                this.workHoursPerDay = value;
            }
        }

        // Methods
        public decimal MoneyPerHour()
        {
            decimal daySalary = this.WeekSalary / 5;
            decimal moneyPerHour = daySalary / this.WorkHoursPerDay;

            return moneyPerHour;
        }
    }
}
