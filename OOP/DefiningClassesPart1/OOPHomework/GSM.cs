using System.Collections.Generic;
namespace OOPHomework
{
    public class GSM
    {
        // Static Fields
        private static GSM iPhone4S;

        // Fields
        private string manufacturer;
        private string model;
        private decimal price;
        private string owner;
        private List<Call> callHistory;

        // Static Constructors
        static GSM()
        {
            iPhone4S = new GSM("Apple", "iPhone 4s", 1000, null, new Battery("iBattery 4s", BatteryType.LiIon, 2, 1), new Display(200, 100, 256));
        }

        // Constructors
        public GSM(string manufacturer, string model) : this(manufacturer, model, 0, null, null, null)
        {
            
        }

        public GSM(string manufacturer, string model, decimal price, string owner) : this(manufacturer, model, price, owner, null, null)
        {

        }
        
        public GSM(string manufacturer, string model, decimal price, string owner, string batteryModel, BatteryType batteryType, int batteryHoursIdle, int batteryHoursTalk, int displayWidth, int displayHeight, int displayNumberOfColors) :
            this(manufacturer, model, price, owner, new Battery(batteryModel, batteryType, batteryHoursIdle, batteryHoursTalk), new Display(displayWidth, displayHeight, displayNumberOfColors))
        {

        }

        public GSM(string manufacturer, string model, decimal price, string owner, Battery battery, Display display)
        {
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
            Owner = owner;
            Battery = battery;
            Display = display;
            callHistory = new List<Call>();
        }

        // Static Properties
        public static GSM IPhone4s
        {
            get
            {
                return iPhone4S;
            }
        }

        // Properties
        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                if (value.Length < 5)
                {
                    throw new System.ArgumentOutOfRangeException("Manufacturer must be at least 5 symbols long");
                }

                this.manufacturer = value;
            }
        }

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

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentOutOfRangeException("The price cannot be less than zero.");
                }

                this.price = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                if (value != null && value.Length < 5)
                {
                    throw new System.ArgumentOutOfRangeException("Owner's name must be at least 5 symbols long");
                }

                this.owner = value;
            }
        }

        public Battery Battery { get; set; }

        public Display Display { get; set; }

        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }
        }

        // Methods
        public override string ToString()
        {
            return string.Format("Manufacturer: {1}{0}Model: {2}{0}Price: {3}{0}Owner: {4}{0}{0}Battery characteristics:{0}{5}{0}{0}Display characteristics:{0}{6}{0}",
                System.Environment.NewLine, this.manufacturer, this.model, this.price, this.owner, Battery.ToString(), Display.ToString());
        }

        public void AddCall(Call newCall)
        {
            this.callHistory.Add(newCall);
        }

        public void DeleteCall(Call call)
        {
            for (int i = 0; i < callHistory.Count; i++)
            {
                if (callHistory[i].Equals(call))
                {
                    callHistory.RemoveAt(i);
                }
            }
        }

        public void ClearCallHistory()
        {
            this.callHistory.Clear();
        }

        public decimal CalculateTotalPrice(decimal pricePerMinute)
        {
            int totalDuration = 0;

            foreach (var call in this.callHistory)
            {
                totalDuration += call.Duration;
            }

            if (totalDuration % 60 != 0)
            {
                totalDuration /= 60;
                totalDuration++;
            }
            else
            {
                totalDuration /= 60;
            }

            return totalDuration * pricePerMinute;
        }
    }
}
