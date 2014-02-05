namespace OOPHomework
{
    public class Battery
    {
        // Fields
        private string model;
        private int hoursIdle;
        private int hoursTalk;

        // Constructors
        public Battery()
        {

        }

        public Battery(string model, BatteryType batteryType) : this (model, batteryType, 0, 0)
        {

        }

        public Battery(string model, BatteryType batteryType, int hoursIdle, int hoursTalk)
        {
            Model = model;
            BatteryType = batteryType;
            HoursIdle = hoursIdle;
            HoursTalk = hoursTalk;
        }

        // Properties
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (value.Length < 5)
                {
                    throw new System.ArgumentOutOfRangeException("Model must be at least 5 symbols long");
                }

                this.model = value;
            }
        }

        public BatteryType BatteryType { get; set; }

        public int HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentOutOfRangeException("Hours idle cannot be less than zero.");
                }

                this.hoursIdle = value;
            }
        }

        public int HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentOutOfRangeException("Hours talk cannot be less than zero.");
                }

                this.hoursTalk = value;
            }
        }

        // Methods
        public override string ToString()
        {
            return string.Format("Model: {1}{0}Battery type: {2}{0}Hours idle: {3}{0}Hours talk: {4}", System.Environment.NewLine, Model, BatteryType, this.hoursIdle, this.hoursTalk);
        }
    }
}
