using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePenguinBank
{
    internal class Customer:Account
    {
        public string Name { get; set; }
        public double SecurityNumber { get; set; }
        public int MaxAttempd { get; set; }
        public string UserNameCustomer { get; set; }
        public double CustomerID { get; set; }
        public int AccountID { get; set; }
        public Customer(double customerID, int accountID, string name, double securityNumber, int maxAttempds, string userNameCustomer) :base(customerID,accountID)
        {
            CustomerID = customerID;
            AccountID = accountID;
            Name = name;
            SecurityNumber = securityNumber;
            MaxAttempd = maxAttempds;
            UserNameCustomer = userNameCustomer;
        }
    }
}
