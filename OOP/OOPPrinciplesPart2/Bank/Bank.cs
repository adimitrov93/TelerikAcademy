namespace Bank
{
    using System;

    public class Bank
    {
        public static void Main()
        {
            LoanAccount loanIndividual = new LoanAccount(new IndividualCustomer(), 1000, 15);
            LoanAccount loanCompany = new LoanAccount(new CompanyCustomer(), 500, 18);

            DepositAccount depositIndividual = new DepositAccount(new IndividualCustomer(), 5000, 20);
            DepositAccount depositCompany = new DepositAccount(new CompanyCustomer(), 2400, 14);

            MortgageAccount mortgageIndividual = new MortgageAccount(new IndividualCustomer(), 2000, 15.5m);
            MortgageAccount mortgageCompany = new MortgageAccount(new CompanyCustomer(), 500, 12);

            Account[] accounts =
            {
                loanIndividual,
                loanCompany,
                depositIndividual,
                depositCompany,
                mortgageIndividual,
                mortgageCompany
            };

            foreach (var account in accounts)
            {
                Console.WriteLine(account.CalcInterestAmount(12));
            }
        }
    }
}
