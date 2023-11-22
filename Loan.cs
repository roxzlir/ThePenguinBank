namespace ThePenguinBank
{
    internal class Loan : Account
    {
        public double Amount { get; set; }
        public double InterestRate { get; set; }
        public bool Approved { get; set; }

        public Loan(double customerID, int accountID, double balance, double amount, double interestRate, bool approved)
            : base(customerID, accountID, balance)
        {
            Amount = amount;
            InterestRate = interestRate;
            Approved = approved;
        }
    }
}