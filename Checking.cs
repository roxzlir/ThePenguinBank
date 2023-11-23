
﻿namespace ThePenguinBank

{
    internal class Checking : Account
    {
        public Checking(double customerID, int accountID, double balance) : base(customerID, accountID, balance)
        { 
        }
        public static void CreateCheckingAccount()
        {
            Console.WriteLine("Thank you for opening a new checking account at Penguin Bank");

            Console.Write("Please write your customer ID number: ");
            double customerID = Program.GetInputNumber();

            Random numberGenerator = new Random();
            int accountID = numberGenerator.Next(40000000, 49999999);

            Console.Write("Please add balance to the account: ");
            double balance = Program.GetInputNumber();

            Checking newAccount = new Checking(customerID, accountID, balance);

            Console.WriteLine("Would you like to see a confirmation of your new account details, please press 1");
            Console.Write("Or to exit menu, please press 0: ");
            double userChoice = Program.GetInputNumber();

            if (userChoice == 1)
            {
                Console.WriteLine("Your new checking account:\n" + "Customer ID: " + newAccount.CustomerID +
                                  "\nAccount number: " + newAccount.AccountID +
                                  "\nCurrent balance: " + newAccount.Balance);
                Console.WriteLine("Press any key + enter to exit");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Thank you for choosing Penguin Bank services!");
            }

            Customer.AccountList.Add(new Checking(customerID, accountID, balance));
        }
    }
}