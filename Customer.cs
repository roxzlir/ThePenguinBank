
using System.Security.Principal;

namespace ThePenguinBank
{
    public class Customer : Account
    {
        public static readonly List<Account> AccountList = new();
        public static readonly List<string> TransactionsList = new();

        public string Name { get; set; }
        public double Password { get; set; }

        public Customer(double customerID, int accountID, double balance, string name, double password) : base(
            customerID, accountID, balance)

        {
            Name = name;
            Password = password;
        }
        
       public static void CustomerMenu() //The customer menu:
        {
            double choice;
            Console.WriteLine("You are now logged in as a Penguin customer!\n");
            do
            {
                Console.Clear();
                Methods.PrintMenuLogo();
                Console.WriteLine("1. Create Checking Account");
                Console.WriteLine("2. Create Saving Account");
                Console.WriteLine("3. Print Accounts");
                Console.WriteLine("4. Transfer Money");
                Console.WriteLine("5. Apply for loan");
                Console.WriteLine("6. Deposit");
                Console.WriteLine("7. Exchange currency");
                Console.WriteLine("8. Print Transactions");
                Console.WriteLine("0. Log out");

                while (!double.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input, try again.");
                }

                switch (choice) //As in the admin menu we take the users input and run a switch case with the choice and start the method for that function.
                {
                    case 1:
                        Checking.CreateCheckingAccount();
                        break;
                    case 2:
                        Saving.CreateSavingAccount();
                        break;
                    case 3:
                        Methods.PrintAccounts();
                        break;
                    case 4:
                        Transfer();
                        break;
                    case 5:
                        Loan.ApplyForLoan();
                        break;
                    case 6:
                        Deposit();
                        break;
                    case 7:
                        Admin.SEKToUSD();
                        break;
                    case 8:
                        PrintTransactions();
                        break;
                    case 0:
                        Methods.Run();
                        break;
                    default:
                        Console.WriteLine("That was not a valid choice.");
                        break;
                }
            } while (choice != 0);


        }
        public static void Deposit() //This is our method for deposit funds in to accounts.
        {
            Console.Clear();
            Methods.PrintMenuLogo();
            while (true)
            {
                Console.WriteLine("What account do you want to deposit to?");
                int i = 1;
                foreach (var account in AccountList)
                {

                    Console.WriteLine($"{i++}.{account.AccountID}");

                }
                var toAccount = int.Parse(Console.ReadLine()) - 1;

                Console.WriteLine("How much would you like to deposit?");
                int amount = int.Parse(Console.ReadLine());

                if (amount <= 0)
                {
                    Console.WriteLine("You have to enter a valid number!");
                }

                AccountList[toAccount].Balance += amount;

                Console.WriteLine($"You have deposited {amount} to {AccountList[toAccount].AccountID}");
                break;
            }
            Console.Write("Please press any key to exit to menu: ");
            Console.ReadKey();
        }
        public static void Transfer()
        {
            Console.Clear();
            Methods.PrintMenuLogo();
            while (true)
            {
                Console.WriteLine("What account do you want to transfer from?");

                int i = 1;
                foreach (var account in AccountList)
                {
                    Console.WriteLine($"{i++}. Account: {account.AccountID} - Balance: {account.Balance}");
                }

                var fromAccount = int.Parse(Console.ReadLine()) - 1;

                Console.WriteLine("What account do you want to transfer to?");
                int y = 1;
                foreach (var account in AccountList)
                {
                    Console.WriteLine($"{y++}. Account: {account.AccountID} - Balance: {account.Balance}");
                }

                var toAccount = int.Parse(Console.ReadLine()) - 1;

                Console.Clear();
                Methods.PrintMenuLogo();
                Console.WriteLine("How much would you like to transfer?");
                int amount = int.Parse(Console.ReadLine());

                if (amount <= 0 || amount > AccountList[fromAccount].Balance)
                {
                    Console.WriteLine("Invalid transfer, the amount is too big or invalid!");
                    return;
                }

                AccountList[fromAccount].Balance -= amount;
                AccountList[toAccount].Balance += amount;
                Console.Clear();
                Methods.PrintMenuLogo();
                Console.WriteLine(amount + " transferred from " + AccountList[fromAccount].CustomerID + $" Account: {AccountList[fromAccount].AccountID} to " +
                                  AccountList[toAccount].CustomerID + $" Account: {AccountList[fromAccount].AccountID}");
                
                
                TransactionsList.Add((("$" + amount + " transferred from " + AccountList[fromAccount].CustomerID + $" Account: {AccountList[fromAccount].AccountID} to " +
                                  AccountList[toAccount].CustomerID + $" Account: {AccountList[fromAccount].AccountID}")).ToString());
                     
                break;
            }
            Console.Write("Please press any key to exit to menu: ");
            Console.ReadKey();
        }
        public static void PrintTransactions()
        {
            Console.Clear();
            Methods.PrintMenuLogo(); 
            foreach (var transaction in TransactionsList)
            {
                Console.WriteLine($"--------------------------\n{transaction}\n--------------------------\n");
            }
            Console.Write("Please press any key to exit to menu: ");
            Console.ReadKey();
        }
    }
}


