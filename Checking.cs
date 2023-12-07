
﻿namespace ThePenguinBank

{
    internal class Checking : Account
    {
        public Checking(double customerID, int accountID, double balance) : base(customerID, accountID, balance)
        { 
        }
        public static void CreateCheckingAccount() //We have a method for creating a CheckingAccount and another for SavingAccount
        {
            Console.Clear();
            Methods.PrintMenuLogo();
            Console.WriteLine("Thank you for opening a new checking account at Penguin Bank");

            Console.Write("Please write your customer ID number: ");
            double customerID = Methods.GetInputNumber();

            Random numberGenerator = new Random(); //We add a random account number, we saw no need for a user to decide this for there own 
            int accountID = numberGenerator.Next(40000000, 49999999); // (we are aware that there is a one in a million chance that customers will get the same account number 

            Console.Write("Please add balance to the account: ");
            double balance = Methods.GetInputNumber();

            Checking newAccount = new Checking(customerID, accountID, balance);

            Console.WriteLine("Would you like to see a confirmation of your new account details, please press 1");
            Console.Write("Or to exit menu, please press 0: ");
            double userChoice = Methods.GetInputNumber();

            if (userChoice == 1)
            {
                Console.WriteLine("Your new checking account:\n" + "Customer ID: " + newAccount.CustomerID +
                                  "\nAccount number: " + newAccount.AccountID +
                                  "\nCurrent balance: " + newAccount.Balance);
                Console.Write("Please press any key to exit to menu: ");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Thank you for choosing Penguin Bank services!");
                Console.Write("Please press any key to exit to menu: ");
                Console.ReadKey();
            }
            Customer.AccountList.Add(new Checking(customerID, accountID, balance)); //Here we add the created account to our static AccountList to be able to use them in other methods
        }
    }
}