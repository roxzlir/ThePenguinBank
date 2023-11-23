using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ThePenguinBank
{
    internal class Customer:Account
     {
        private static object checking;

        public enum AccountTyp
        {
            cheking,
            saving
        }
        public string Name { get; set; }
        public double SecurityNumber { get; set; }
        public int MaxAttempd { get; set; }
        public string UserNameCustomer { get; set; } 
        public Customer(double customerID, int accountID, string name, double securityNumber, int maxAttempds, string userNameCustomer) :base(customerID,accountID)
        {
            Name = name;
            SecurityNumber = securityNumber;
            MaxAttempd = maxAttempds;
            UserNameCustomer = userNameCustomer;
        }
        public void Deposit(double amount, AccountTyp accountType, Checking cheking, Saving saving)
        {
            double chekingBalance = cheking.Balance;
            double savingBalance = saving.Balance;

            if(accountType == AccountTyp.cheking)
            {
                chekingBalance += amount;
                Console.WriteLine(chekingBalance);
            }
            else if(accountType == AccountTyp.saving)
            {
                savingBalance += amount;
                Console.WriteLine(savingBalance);
            }
            else
            {
                Console.WriteLine("Inviled accountType, enter cheking or saving");
            }
        }

        public static void AccountLog(AccountTyp accountType, Checking cheking, Saving saving)
        {
            List <Transaction> transactions = new List<Transaction>();
            if(accountType == AccountTyp.cheking)
            {
                transactions = checking.Tra
            }

            else if(accountType == AccountTyp.saving)
            {
                transactions = saving.Tra
            }

            else
            {
                Console.WriteLine("Inlalid accountType, enter Cheking or saving");
                return;
            }
            Console.WriteLine("AccountTyp log in " + accountType);
            foreach (Transaction transaction in transactions)
            {
                Console.WriteLine(transaction.Date);
            }
        }

        //Add a method in Customer class: Deposit()
        //A   method that adds a value to property Balance in Checking and Saving.
    }
}
