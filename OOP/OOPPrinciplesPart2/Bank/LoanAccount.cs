namespace Bank
{
    public class LoanAccount : Account
    {
        // Constructors
        public LoanAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {

        }

        // Methods
        public override decimal CalcInterestAmount(uint numberOfMonths)
        {
            if (this.Customer is IndividualCustomer)
            {
                numberOfMonths -= 3;
            }
            else
            {
                numberOfMonths -= 2;
            }

            if (numberOfMonths > 0)
            {
                return base.CalcInterestAmount(numberOfMonths);
            }
            else
            {
                return 0;
            }
        }
    }
}
