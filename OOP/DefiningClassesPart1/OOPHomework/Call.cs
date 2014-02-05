namespace OOPHomework
{
    public class Call
    {
        // Fields
        private System.DateTime dateAndTime;
        private string dialedPhoneNumber;
        private int duration;

        // Constructors
        public Call(System.DateTime dateAndTime, string dialedPhoneNumber, int duration)
        {
            this.dateAndTime = dateAndTime;
            this.dialedPhoneNumber = dialedPhoneNumber;
            this.duration = duration;
        }

        // Properties
        public int Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                if (duration < 0)
                {
                    throw new System.ArgumentOutOfRangeException("Duration cannot be negative number");
                }

                this.duration = value;
            }
        }

        // Methods
        public bool Equals(Call call)
        {
            if (this.dateAndTime.Equals(call.dateAndTime) && this.dialedPhoneNumber.Equals(call.dialedPhoneNumber) && this.duration == call.duration)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return string.Format("Date: {1}.{2}.{3}{0}Time: {4}:{5}:{6}{0}Dialed phone number: {7}{0}Duration: {8}s",
                System.Environment.NewLine, this.dateAndTime.Date, this.dateAndTime.Month, this.dateAndTime.Year,
                this.dateAndTime.Hour, this.dateAndTime.Minute, this.dateAndTime.Second, this.dialedPhoneNumber, this.duration);
        }
    }
}
