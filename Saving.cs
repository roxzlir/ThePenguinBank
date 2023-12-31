﻿namespace ThePenguinBank
{
    internal class Saving : Account
    {
        public Saving(double customerID, int accountID, double balance) : base(customerID, accountID, balance)
        { 
        }
        
        public static void CreateSavingAccount() //We have a equal method for CheckingAccount
        {                                       // for more info, see Class Checking and CreateCheckingAccount() for more comments on the thoughts on this
            Console.Clear();
            Methods.PrintMenuLogo();

            Console.WriteLine("Thank you for opening a new saving account at Penguin Bank");

            Console.Write("Please write your customer ID number: ");
            double customerID = Methods.GetInputNumber();

            Random numberGenerator = new Random();
            int accountID = numberGenerator.Next(90000000, 99999999);

            Console.Write("Please add balance to the account: ");
            double balance = Methods.GetInputNumber();


            Saving newAccount = new Saving(customerID, accountID, balance);

            Console.WriteLine("Would you like to see a confirmation of your new account details, please press 1");
            Console.Write("Or to exit menu, please press 0: ");
            double userChoice = Methods.GetInputNumber();
            if (userChoice == 1)
            {
                Console.WriteLine("Your new checking account:\n" + "Customer ID: " + newAccount.CustomerID +
                                  "\nAccount number: " + newAccount.AccountID +
                                  "\nCurrent balance: " + newAccount.Balance);
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Thank you for choosing Penguin Bank services!");
            }

            Customer.AccountList.Add(new Saving(customerID, accountID, balance));
            Console.WriteLine();
        }
    }
}