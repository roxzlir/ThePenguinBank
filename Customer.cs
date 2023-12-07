
using System.Security.Principal;

namespace ThePenguinBank
{
    public class Customer : Account
    {
        public static readonly List<Account> AccountList = new(); //Our account list that we use in several methods
        public static readonly List<string> TransactionsList = new(); //This is our transaction list that we store all transaction messages in and then we can display them as "made transactions"
        public static readonly List<Customer> LogInList = new(); //We added a static List to add our customer object's in to be able to match them in the login

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
                foreach (var account in AccountList) //We made a foreach loop to display all the account that is available to make a deposit to since it's hard for a user 
                {                                   //to know all the accounts that exist.

                    Console.WriteLine($"{i++}.{account.AccountID} (customer ID: {account.CustomerID})");

                }
                var toAccount = int.Parse(Console.ReadLine()) - 1; //User then selects one account

                Console.WriteLine("How much would you like to deposit?");
                int amount = int.Parse(Console.ReadLine());

                if (amount <= 0)
                {
                    Console.WriteLine("You have to enter a valid number!");
                }

                AccountList[toAccount].Balance += amount; //and here we add the amount to the accounts balance property

                Console.WriteLine($"You have deposited {amount} to account  {AccountList[toAccount].AccountID} owned by customer ID {AccountList[toAccount].CustomerID}");
                break;
            }
            Console.Write("Please press any key to exit to menu: ");
            Console.ReadKey();
        }
        public static void Transfer() //The method for transfering funds from one balance property to antoher
        {
            Console.Clear();
            Methods.PrintMenuLogo();
            while (true)
            {
                Console.WriteLine("What account do you want to transfer from?");

                int i = 1;
                foreach (var account in AccountList) //Here we made the same solution as in deposit
                {
                    Console.WriteLine($"{i++}. Account: {account.AccountID} - Balance: {account.Balance}");
                }

                var fromAccount = int.Parse(Console.ReadLine()) - 1; 

                Console.WriteLine("What account do you want to transfer to?");
                int y = 1;
                foreach (var account in AccountList) //And repeated it again for the account that will receive a new balance amount
                {
                    Console.WriteLine($"{y++}. Account: {account.AccountID} - Balance: {account.Balance}");
                }

                var toAccount = int.Parse(Console.ReadLine()) - 1;

                Console.Clear();
                Methods.PrintMenuLogo();
                Console.WriteLine("How much would you like to transfer?");
                int amount = int.Parse(Console.ReadLine());

                if (amount <= 0 || amount > AccountList[fromAccount].Balance) //Added if statement as a fail safe if there isn't enough funds in the balance property
                {
                    Console.WriteLine("Invalid transfer, the amount is too big or invalid!");
                    return;
                }

                AccountList[fromAccount].Balance -= amount; //The acctual transfer process.
                AccountList[toAccount].Balance += amount;
                Console.Clear();
                Methods.PrintMenuLogo();
                Console.WriteLine(amount + " transferred from " + AccountList[fromAccount].CustomerID + $" Account: {AccountList[fromAccount].AccountID} to " +
                                  AccountList[toAccount].CustomerID + $" Account: {AccountList[fromAccount].AccountID}");
                
                //Since we want to be able to display all transactions in our next method we made a very simple solution. We created a static list, TransactionsList with a string input
                //and the we just took the text from above and used ToString method and saved to whole thing!
                TransactionsList.Add((("$" + amount + " transferred from " + AccountList[fromAccount].CustomerID + $" Account: {AccountList[fromAccount].AccountID} to " +
                                  AccountList[toAccount].CustomerID + $" Account: {AccountList[fromAccount].AccountID}")).ToString());
                     
                break;
            }
            Console.Write("Please press any key to exit to menu: ");
            Console.ReadKey();
        }
        public static void PrintTransactions() //And here is the method were we just print the TransactionsList in a foreach loop
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


