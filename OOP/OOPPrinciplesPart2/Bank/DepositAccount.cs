namespace Bank
{
    public class DepositAccount : Account
    {
        // Constructors
        public DepositAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {

        }

        // Methods
        public override decimal CalcInterestAmount(uint numberOfMonths)
        {
            if (this.Balance > 0 && this.Balance < 1000)
            {
                return 0;
            }
            else
            {
                return base.CalcInterestAmount(numberOfMonths);
            }
        }
    }
}
