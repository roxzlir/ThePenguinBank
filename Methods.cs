namespace ThePenguinBank;
using System.IO;
using System.Reflection.Metadata.Ecma335;

public class Methods
{
    public static List<Customer> LogInList = new();

    public static void Run()
    {
        Console.Clear();
        Methods.PrintLogo();
        Customer customer = new Customer(8808227832, 49799291, 5000, "Emil Nordin", 123);
        Customer customer1 = new Customer(9907139100, 45493109, 32000, "Theres Sundberg", 321);
        LogInList.Add(customer);
        LogInList.Add(customer1);
        Checking acc1 = new Checking(8808227832, 44500172, 10000);
        Saving acc2 = new Saving(8808227832, 90231141, 56322);
        Checking acc3 = new Checking(9907139100, 45470221, 32000);
        Saving acc4 = new Saving(8808227832, 99222141, 71500);
        Customer.AccountList.Add(acc1);
        Customer.AccountList.Add(acc2);
        Customer.AccountList.Add(acc3);
        Customer.AccountList.Add(acc4);

        int loginReturnResult = LoginAs();

        switch (loginReturnResult)
        {
            case 1:
                Console.Clear();
                Methods.PrintMenuLogo();
                Customer.CustomerMenu();
                break;
            case 2:
                Console.Clear();
                Methods.PrintMenuLogo();
                Admin.AdminMenu();
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

            Console.WriteLine("Try a valid input!");
        }

        return userInput;
    }

    public static int LoginAs()
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

            foreach (var customer in LogInList)
            {
                if (customer.CustomerID == userCustomerIDInput && customer.Password == userPasswordInput)
                {
                    return 1;
                }
                else if (userCustomerIDInput == 11111 && userPasswordInput == 00000)
                {
                    return 2;

                }
                else
                {
                    Console.WriteLine("You need to enter a valid log in.");
                    break;
                }
            }
        }
        return 3;   
    }

    public static void PrintAccounts()
    {
        Console.Clear();
        Methods.PrintMenuLogo();
        Console.WriteLine("-- These are all accounts --\n");
        foreach (var accounts in Customer.AccountList)
        {
            {
                switch (accounts)
                {
                    case Checking checkingAccount:
                        Console.WriteLine(
                            $"Type of account: Checking Account \nCustomer ID: {checkingAccount.CustomerID}\n" +
                            $"Account ID: {checkingAccount.AccountID}\nBalance: {checkingAccount.Balance}" +
                            $"\n--------------------------------------------------------------------------\n");
                        break;
                    case Saving savingAccount:
                        Console.WriteLine(
                            $"Type of account: Savings Account \nCustomer ID: {savingAccount.CustomerID}\n" +
                            $"Account ID: {savingAccount.AccountID}\nBalance: {savingAccount.Balance}" +
                            $"\n--------------------------------------------------------------------------\n");
                        break;
                }
            }
        }

        Console.Write("Please press any key to exit to menu: ");
        Console.ReadKey();
    }

    public static void PrintLogo()
    {

        string path = @"C:\Users\emilc\source\repos\ThePenguinBank\PenguinLogo.txt";
        string readText = File.ReadAllText(path);
        
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(readText);
        Console.ResetColor();
    }
    public static void PrintMenuLogo() 
    {
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(@"  
   _    
 ('v')  The
//-=-\\ Penguin
(\_=_/) Bank
 ^^ ^^");
        Console.ResetColor();
    }
}