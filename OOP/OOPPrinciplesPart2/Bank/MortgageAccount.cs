namespace Bank
{
    public class MortgageAccount : Account
    {
        // Constructors
        public MortgageAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {

        }

        // Methods
        public override decimal CalcInterestAmount(uint numberOfMonths)
        {
            if (this.Customer is CompanyCustomer)
            {
                if (numberOfMonths > 12)
                {
                    numberOfMonths -= 6;
                }
                else
                {
                    decimal newNumberOfMonths = numberOfMonths / 2m;

                    return newNumberOfMonths * this.InterestRate;
                }
            }
            else
            {
                numberOfMonths -= 6;

                if (numberOfMonths <= 0)
                {
                    return 0;
                }
            }

            return base.CalcInterestAmount(numberOfMonths);
        }
    }
}
