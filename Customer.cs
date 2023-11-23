
namespace ThePenguinBank
{
    public class Customer : Account
    {
        public static readonly List<Account> AccountList = new();
        public enum AccountTyp
        {
            checking,
            saving
        }
        public string Name { get; set; }
        public double Password { get; set; }

        public Customer(double customerID, int accountID, double balance, string name, double password) : base(
            customerID, accountID, balance)

        {
            Name = name;
            Password = password;
        }
        
       public static int CustomerMenu()
        {
            int choice;
            Program.PrintLogo();
            do
            {
                Console.WriteLine("1. Create Checking Account");
                Console.WriteLine("2. Create Saving Account");
                Console.WriteLine("3. Print Accounts");
                Console.WriteLine("4. Transfer Money");
                Console.WriteLine("5. Get loan");
                Console.WriteLine("6. deposit");
                Console.WriteLine("7. Exchange currency");

                Console.WriteLine("0. Close program");

                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input, try again.");
                }

                switch (choice)
                {
                    case 1:
                        Checking.CreateCheckingAccount();
                        break;
                    case 2:
                        Saving.CreateSavingAccount();
                        break;
                    case 3:
                        Program.PrintAccounts();
                        break;
                    case 4:
                        Customer.Transfer();
                        break;
                    case 5:
                        break;
                    case 6:
                        Customer.Deposit();
                        break;
                    case 7:
                        Admin.SEKToUSD();
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
        public static void Deposit()
        {
            while (true)
            {
                Console.WriteLine("What account do you want to deposit to?");

                int i = 1;
                foreach (var account in AccountList)
                {

                    Console.WriteLine($"{i++}.{account.AccountID}");

                }

                var toAccount = int.Parse(Console.ReadLine()) - 1;

                Console.WriteLine("How much would you like to transfer?");
                int amount = int.Parse(Console.ReadLine());

                if (amount <= 0)
                {
                    Console.WriteLine("You have to enter a valid number!");
                }

                AccountList[toAccount].Balance += amount;

                Console.WriteLine($"You have deposited {amount} to {toAccount}");
                break;
            }
        }
        public static void Transfer()
        {
            while (true)
            {
                Console.WriteLine("What account do you want to transfer from?");

                int i = 1;
                foreach (var account in AccountList)
                {
                    Console.WriteLine($"{i++}.{account.AccountID}");
                }

                var fromAccount = int.Parse(Console.ReadLine()) - 1;

                Console.WriteLine("What account do you want to transfer to?");

                foreach (var account in AccountList)
                {
                    Console.WriteLine($"{i++}.{account.AccountID}");
                }

                var toAccount = int.Parse(Console.ReadLine()) - 1;

                Console.WriteLine("How much would you like to transfer?");
                int amount = int.Parse(Console.ReadLine());

                if (amount <= 0 || amount > AccountList[fromAccount].Balance)
                {
                    Console.WriteLine("Invalid transfer, the amount is too big or invalid!");
                    return;
                }

                AccountList[fromAccount].Balance -= amount;
                AccountList[toAccount].Balance += amount;

                Console.WriteLine("$" + amount + " transferred from " + AccountList[fromAccount].CustomerID + " to " +
                                  AccountList[toAccount].CustomerID);
                break;
            }
        }
    }
}


