using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePenguinBank
{
    internal class Loan : Account
    {
        public double Amount { get; set; }
        public double InterestRate { get; set; }
        public bool Approved { get; set; }

        public Loan(double customerID, int accountID, double amount, double interestRate, bool approved) : base(customerID, accountID)
        {
            Amount = amount;
            InterestRate = interestRate;
            Approved = approved;
        }
    }
}
