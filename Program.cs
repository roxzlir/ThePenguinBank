using Pastel;
using System.Drawing;

namespace ThePenguinBank
{
    internal class Program
    {
        public static List<Account> AccountList = new();
        public static List<Customer> logInList = new();


        static void Main()
        {
            Admin admin = new Admin();
            Customer customer = new Customer(8808227832, 4000001, 123333, "Emil", 123);
            Customer customer1 = new Customer(9907139100, 400002, 12333, "Theres", 124);
            LoginAs();
            Run();
            Menu();
            Console.WriteLine("Hello, World!");
        }


        static void Run()
        {
            int loginReturnResult = LoginAs();

            switch (loginReturnResult)

            {
                case 1:

                    Console.WriteLine("Inloggad som en customer");

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

        static int Menu()
        {
            int choice;

            do
            {
                Console.WriteLine("1. Create Checking Account");
                Console.WriteLine("2. Create Saving Account");
                Console.WriteLine("3. Print Accounts");
                Console.WriteLine("4. Transfer money between your accounts");
                Console.WriteLine("0. Close program");

                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input, try again.");
                }

                switch (choice)
                {
                    case 1:
                        CreateCheckingAccount();
                        break;
                    case 2:
                        CreateSavingAccount();
                        break;
                    case 3:
                        PrintAccounts();
                        break;
                    case 4:
                    {
                        TransferInternal();
                    }
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("That was not a valid choice.");
                        break;
                }
            } while (choice != 0);

            return choice;
        }

        static double GetInputNumber()
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
                double userCustomerIDInput = GetInputNumber();
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
                        Console.WriteLine("You need to enter a valid login");
                    }
                }
            }

            return 3;
        }

        static void CreateCheckingAccount()
        {
            Console.WriteLine("Thank you for opening a new checking account at Penguin Bank");

            Console.Write("Please write your customer ID number: ");
            double customerID = GetInputNumber();

            Random numberGenerator = new Random();
            int accountID = numberGenerator.Next(40000000, 49999999);

            double balance = GetInputNumber();

            Checking newAccount = new Checking(customerID, accountID, balance);

            Console.WriteLine("Would you like to see a confirmation of your new account details, please press 1");
            Console.Write("Or to exit menu, please press 0: ");
            double userChoice = GetInputNumber();

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

            AccountList.Add(new Checking(customerID, accountID, balance));
        }

        static void CreateSavingAccount()
        {
            Console.WriteLine("Thank you for opening a new saving account at Penguin Bank");

            Console.Write("Please write your customer ID number: ");
            double customerID = GetInputNumber();

            Random numberGenerator = new Random();
            int accountID = numberGenerator.Next(90000000, 99999999);

            double availableBalance = 0;


            Saving newAccount = new Saving(customerID, accountID, availableBalance);

            Console.WriteLine("Would you like to see a confirmation of your new account details, please press 1");
            Console.Write("Or to exit menu, please press 0: ");
            double userChoice = GetInputNumber();
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

            AccountList.Add(new Saving(customerID, accountID, availableBalance));
        }

        public static void PrintAccounts()
        {
            foreach (var accounts in AccountList)
            {
                Console.WriteLine("These are your accounts");
                {
                    if (accounts is Checking checkingAccount)
                    {
                        Console.WriteLine(
                            $"Type of account: Checking Account \nCustomer ID: {checkingAccount.CustomerID}\n" +
                            $"Account ID: {checkingAccount.AccountID}\nBalance: {checkingAccount.Balance}");
                    }
                    else if (accounts is Saving savingAccount)
                    {
                        Console.WriteLine(
                            $"Type of account: Savings Account \nCustomer ID: {savingAccount.CustomerID}\n" +
                            $"Account ID: {savingAccount.AccountID}\nBalance: {savingAccount.Balance}");
                    }
                }
            }
        }

        public static void TransferInternal()
        {
            while (true)
            {
                Console.WriteLine("What account do you want to transfer from?");

                for (var i = 0; i < AccountList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {AccountList[i]}");
                }

                var fromAccount = int.Parse(Console.ReadLine()) - 1; 

                Console.WriteLine("What account do you want to transfer to?");

                for (var i = 0; i < AccountList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {AccountList[i]}");
                }

                var toAccount = int.Parse(Console.ReadLine()) - 1;


                Console.WriteLine("How much would you like to transfer?");
                int amount = int.Parse(Console.ReadLine());

                if (amount > 0 && fromAccount <= 0 && amount <= AccountList[fromAccount].Balance)
                {
                    double newBalance = AccountList[fromAccount].Balance - amount;
                    double newReciveBalance = AccountList[toAccount].Balance + amount;
                }
                else
                {
                    Console.WriteLine("You need to input a valid number!");
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