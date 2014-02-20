namespace Bank
{
    using System;

    public abstract class Account
    {
        // Fields
        private Customer customer;
        private decimal interestRate;

        // Constructors
        public Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        // Properties
        public Customer Customer
        {
            get
            {
                return this.customer;       //TO DO - encapsulate
            }
            private set
            {
                this.customer = value;
            }
        }

        public decimal Balance { get; protected set; }

        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Interest rate cannot be less or equal to zero");
                }

                this.interestRate = value;
            }
        }

        // Methods
        public void DepositMoney(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount of money cannot be less or equal to zero");
            }

            this.Balance += amount;
        }

        public virtual decimal CalcInterestAmount(uint numberOfMonths)
        {
            return this.InterestRate * numberOfMonths;
        }
    }
}
