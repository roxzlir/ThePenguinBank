namespace ThePenguinBank;
using System.IO;
using System.Reflection.Metadata.Ecma335;

public class Methods
{
     

    public static void Run() //This is the method that we use as our "main" method, to run the Login and then the actual menu choices
    {
        Console.Clear();
        PrintLogo();
        Customer customer2 = new Customer(8808227832, 49799291, 5000, "Emil Nordin", 123);
        Customer customer1 = new Customer(9907139100, 45493109, 32000, "Theres Sundberg", 321);
        Customer.LogInList.Add(customer2);
        Customer.LogInList.Add(customer1);
        Checking acc1 = new Checking(8808227832, 44500172, 10000);
        Saving acc2 = new Saving(8808227832, 90231141, 56322);
        Checking acc3 = new Checking(9907139100, 45470221, 32000);
        Saving acc4 = new Saving(8808227832, 99222141, 71500);
        Customer.AccountList.Add(acc1);
        Customer.AccountList.Add(acc2);
        Customer.AccountList.Add(acc3);
        Customer.AccountList.Add(acc4);  //All of the above is added to have some data to play with in the app

        Console.WriteLine();
        int attempts = 0;
        int maxAttempts = 3;

        while (attempts < maxAttempts) //While loop with 3 attempts for login
        {
            Console.Write("Please enter customer ID: ");

            double userCustomerIDInput = GetInputNumber();
            Console.Write($"Please enter password for ID {userCustomerIDInput}: ");
            double userPasswordInput = GetInputNumber();

            foreach (var customer in Customer.LogInList) //Here we want the loop to check the static LogInList for every customer in it
            {
                if (customer.CustomerID == userCustomerIDInput && customer.Password == userPasswordInput)
                {                               //And if the customerID and customerPassword exists in the list and the user input matches that the if statment will run the   
                    Console.Clear();           //CustomerMenu method
                    Methods.PrintMenuLogo();
                    Customer.CustomerMenu();
                    break;
                }
                else if (userCustomerIDInput == 11111 && userPasswordInput == 00000)
                {                             //We hard coded the admin login since there only is 1 admin that are going to be able to login
                    Console.Clear();
                    Methods.PrintMenuLogo();
                    Admin.AdminMenu();
                    break;
                }
                else
                {
                    Console.WriteLine("You need to enter a valid log in.");
                    attempts++;
                    Console.WriteLine($"Login attempts {attempts} of {maxAttempts}.");
                    break;
                }
            }
        }

    }

    public static double GetInputNumber() //Simple but effective method for retrieving a user input as a double
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

    public static void PrintAccounts() //We added this method to display all the accounts that are created
    {
        Console.Clear();
        Methods.PrintMenuLogo();
        Console.WriteLine("-- These are all accounts --\n");
        foreach (var accounts in Customer.AccountList) //Since we have a static list 'AccountList' that every account that are created in the CreateNewAccount method
        {                                             //also adds the account to the list we run them in this loop
            {
                switch (accounts) //And made a swtich case that switch on the account type!
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

    public static void PrintLogo() //We added this method for display our big logo
    {                             //The logo is in a seperate file, so the first thing we tell users in our ReadMe is to change the  
                                  //pathway to your own C:\YourUsers etc for this to work. We wanted to try using a file for this
        string path = @"C:\Users\emilc\source\repos\ThePenguinBank\PenguinLogo.txt";
        string readText = File.ReadAllText(path);
        Console.ForegroundColor = ConsoleColor.DarkGreen; //Sets the color on the text
        Console.WriteLine(readText);
        Console.ResetColor();
    }
    public static void PrintMenuLogo() //Also added a smaler menu logo that follows you in the menu
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