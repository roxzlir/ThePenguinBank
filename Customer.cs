
namespace ThePenguinBank
{
    internal class Customer : Account
    {
        public static List<Account> AccountList = new();

        

        public enum AccountTyp
        {
            cheking,
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
        public void Deposit(double amount, AccountTyp accountType, Checking cheking, Saving saving)
        {
            double chekingBalance = cheking.Balance;
            double savingBalance = saving.Balance;

            if (accountType == AccountTyp.cheking)
            {
                chekingBalance += amount;
                Console.WriteLine(chekingBalance);
            }
            else if (accountType == AccountTyp.saving)
            {
                savingBalance += amount;
                Console.WriteLine(savingBalance);
            }
            else
            {
                Console.WriteLine("Inviled accountType, enter cheking or saving");
            }
        }

        //public static void AccountLog(AccountTyp accountType, Checking checking, Saving saving)
        //{
        //    List<Transaction> transactions = new List<Transaction>();
        //    if (accountType == AccountTyp.cheking)
        //    {
        //        transactions = Customer.checking.Tra
        //    }

        //    else if (accountType == AccountTyp.saving)
        //    {
        //        transactions = saving.Tra
        //    }

        //    else
        //    {
        //        Console.WriteLine("Inlalid accountType, enter Cheking or saving");
        //        return;
        //    }
        //    Console.WriteLine("AccountTyp log in " + accountType);
        //    foreach (Transaction transaction in transactions)
        //    {
        //        Console.WriteLine(transaction.Date);
        //    }
        //}

        //Add a method in Customer class: Deposit()

        //A   method that adds a value to property Balance in Checking and Saving.


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


