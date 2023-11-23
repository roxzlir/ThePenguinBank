
﻿using System.Runtime.CompilerServices;

﻿using Pastel;
using System.Drawing;
namespace ThePenguinBank
{
    public class Program
    {
        public static readonly List<Customer> logInList = new();
        static void Main()
        {
            Customer customer = new Customer(8808227832, 4000001, 123333, "Emil", 123);
            Customer customer1 = new Customer(9907139100, 400002, 12333, "Theres", 124);
            logInList.Add(customer);
            logInList.Add(customer1);
            Checking acc1 = new Checking(111111, 11111, 100);
            Checking acc2 = new Checking(222222, 33333, 100);
            Checking acc3 = new Checking(333333, 55555, 100);
            Customer.AccountList.Add(acc1);
            Customer.AccountList.Add(acc2);
            Customer.AccountList.Add(acc3);

            Customer.Transfer();

            Run();
        }
        static void Run()
        {
            int loginReturnResult = LoginAs();

            switch (loginReturnResult)
            {
                case 1:
                    Customer.CustomerMenu();
                    break;
                case 2:
                    Console.WriteLine("Inloggad som admin");
                    break;
                case 3:
                    Console.WriteLine("Du har gjort dina 3 försök.");
                    break;
                default:
                    break;
            }
        }
        public static double GetInputNumber()
        {
            double userInput;
            while (true)
            {
                string? inputNumber = Console.ReadLine();

                if (double.TryParse(inputNumber, out userInput))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Try a valid input!");
                }
            }
            return userInput;
        }
        static int LoginAs()
        {
            Console.WriteLine();
            int attempts = 0;
            int maxAttempts = 3;

            while (attempts < maxAttempts)
            {
                Console.Write("Please enter customer ID: ");
                
                double userCustomerIDInput = GetInputNumber();
                Console.Write($"Please enter password for ID {userCustomerIDInput}: ");
                double userPasswordInput = GetInputNumber();

                foreach (var customer in logInList)
                {
                    if (customer.CustomerID == userCustomerIDInput && customer.Password == userPasswordInput)
                    {
                        return 1;
                    }
                    else if (userCustomerIDInput == 511 && userPasswordInput == 00000)
                    {
                        return 2;
                    }
                    else
                    {
                        Console.WriteLine("You need to enter a valid log in.");
                    }

                }
            }

            return 3;
        }
        public static void PrintAccounts()
        {
            foreach (var accounts in Customer.AccountList)
            {
                Console.WriteLine("These are your accounts");
                {
                    if (accounts is Checking checkingAccount)
                    {
                        Console.WriteLine(
                            $"Type of account: Checking Account \nCustomer ID: {checkingAccount.CustomerID}\n" +
                            $"Account ID: {checkingAccount.AccountID}\nBalance: {checkingAccount.Balance}" +
                            $"\n--------------------------------------------------------------------------\n");
                    }
                    else if (accounts is Saving savingAccount)
                    {
                        Console.WriteLine(
                            $"Type of account: Savings Account \nCustomer ID: {savingAccount.CustomerID}\n" +
                            $"Account ID: {savingAccount.AccountID}\nBalance: {savingAccount.Balance}" +
                            $"\n--------------------------------------------------------------------------\n");
                    }
                }
            }
        }
        public static void PrintLogo()
        {
            string logoType = @"    
   _         _         _        _         _         _         _         _         _         _         _         _        _         _         _
 ('v')     ('v')     ('v')    ('v')     ('v')     ('v')     ('v')     ('v')     ('v')     ('v')     ('v')     ('v')    ('v')     ('v')     ('v') 
//-=-\\   //-=-\\   //-=-\\  //-=-\\   //-=-\\   //-=-\\   //-=-\\   //-=-\\   //-=-\\   //-=-\\   //-=-\\   //-=-\\  //-=-\\   //-=-\\   //-=-\\
(\_=_/)   (\_=_/)   (\_=_/)  (\_=_/)   (\_=_/)   (\_=_/)   (\_=_/)   (\_=_/)   (\_=_/)   (\_=_/)   (\_=_/)   (\_=_/)  (\_=_/)   (\_=_/)   (\_=_/)
 ^^ ^^     ^^ ^^     ^^ ^^    ^^ ^^     ^^ ^^     ^^ ^^     ^^ ^^     ^^ ^^     ^^ ^^     ^^ ^^     ^^ ^^     ^^ ^^    ^^ ^^     ^^ ^^     ^^ ^^    
                  /$$      /$$         /$$                                                             /$$                           
                  | $$  /$ | $$        | $$                                                            | $$                           
                  | $$ /$$$| $$ /$$$$$$| $$ /$$$$$$$ /$$$$$$ /$$$$$$/$$$$  /$$$$$$                    /$$$$$$   /$$$$$$               
                  | $$/$$ $$ $$/$$__  $| $$/$$_____//$$__  $| $$_  $$_  $$/$$__  $$                  |_  $$_/  /$$__  $$              
                  | $$$$_  $$$| $$$$$$$| $| $$     | $$  \ $| $$ \ $$ \ $| $$$$$$$$                    | $$   | $$  \ $$              
                  | $$$/ \  $$| $$_____| $| $$     | $$  | $| $$ | $$ | $| $$_____/                    | $$ /$| $$  | $$              
                  | $$/   \  $|  $$$$$$| $|  $$$$$$|  $$$$$$| $$ | $$ | $|  $$$$$$$                    |  $$$$|  $$$$$$/              
                  |__/     \__/\_______|__/\_______/\______/|__/ |__/ |__/\_______/                     \___/  \______/               
 /$$$$$$$$/$$                      /$$$$$$$                                    /$$                /$$$$$$$                   /$$      
|__  $$__| $$                     | $$__  $$                                  |__/               | $$__  $$                 | $$      
   | $$  | $$$$$$$  /$$$$$$       | $$  \ $$/$$$$$$ /$$$$$$$  /$$$$$$ /$$   /$$/$$/$$$$$$$       | $$  \ $$ /$$$$$$ /$$$$$$$| $$   /$$
   | $$  | $$__  $$/$$__  $$      | $$$$$$$/$$__  $| $$__  $$/$$__  $| $$  | $| $| $$__  $$      | $$$$$$$ |____  $| $$__  $| $$  /$$/
   | $$  | $$  \ $| $$$$$$$$      | $$____| $$$$$$$| $$  \ $| $$  \ $| $$  | $| $| $$  \ $$      | $$__  $$ /$$$$$$| $$  \ $| $$$$$$/ 
   | $$  | $$  | $| $$_____/      | $$    | $$_____| $$  | $| $$  | $| $$  | $| $| $$  | $$      | $$  \ $$/$$__  $| $$  | $| $$_  $$ 
   | $$  | $$  | $|  $$$$$$$      | $$    |  $$$$$$| $$  | $|  $$$$$$|  $$$$$$| $| $$  | $$      | $$$$$$$|  $$$$$$| $$  | $| $$ \  $$
   |__/  |__/  |__/\_______/      |__/     \_______|__/  |__/\____  $$\______/|__|__/  |__/      |_______/ \_______|__/  |__|__/  \__/
                                                             /$$  \ $$                                                                
                                                            |  $$$$$$/                                                                
                                                             \______/                                                                 
   _         _         _        _         _         _         _         _         _         _         _         _        _         _         _
 ('v')     ('v')     ('v')    ('v')     ('v')     ('v')     ('v')     ('v')     ('v')     ('v')     ('v')     ('v')    ('v')     ('v')     ('v') 
//-=-\\   //-=-\\   //-=-\\  //-=-\\   //-=-\\   //-=-\\   //-=-\\   //-=-\\   //-=-\\   //-=-\\   //-=-\\   //-=-\\  //-=-\\   //-=-\\   //-=-\\
(\_=_/)   (\_=_/)   (\_=_/)  (\_=_/)   (\_=_/)   (\_=_/)   (\_=_/)   (\_=_/)   (\_=_/)   (\_=_/)   (\_=_/)   (\_=_/)  (\_=_/)   (\_=_/)   (\_=_/)
 ^^ ^^     ^^ ^^     ^^ ^^    ^^ ^^     ^^ ^^     ^^ ^^     ^^ ^^     ^^ ^^     ^^ ^^     ^^ ^^     ^^ ^^     ^^ ^^    ^^ ^^     ^^ ^^     ^^ ^^   ";

            Console.WriteLine(logoType.Pastel(Color.Yellow).PastelBg(Color.BlueViolet));
        }
    }
}