using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePenguinBank
{
    internal class Checking : Account
    {
        public double Balance { get; set; }
        public Checking(double customerID, int accountID, double balance) : base(customerID, accountID)
        {
            CustomerID = customerID;
            AccountID = accountID;
            Balance = balance;
        }
    }
}
