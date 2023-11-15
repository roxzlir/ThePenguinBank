using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePenguinBank
{
    abstract class Account
    {
        public double CustomerID { get; set; }
        public int AccountID { get; set; }
        public Account(double customerID, int accountID)
        {
            CustomerID = customerID;
            AccountID = accountID;
        }
    }
}
