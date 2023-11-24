using System.Timers;

namespace ThePenguinBank;
internal class Admin
{
    private static decimal USD = 10.49M;
    private static decimal GetInputDecimal()
    {
        decimal userInput;
        while (true)
        {
            string? inputNumber = Console.ReadLine();

            if (decimal.TryParse(inputNumber, out userInput))
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
    private static void SetCurrencyRate()
    {
        Console.WriteLine($"Right now your US Dollar exchange rate value is: {USD}");
        Console.Write("To set new exchange rate press 1, to exit press any key: ");
        double menu = Methods.GetInputNumber();
        switch (menu)
        {
            case 1:
                Console.Write("Please enter new value for US Dollar (USD): ");
                USD = GetInputDecimal();
                break;
                

            default:
                Console.WriteLine("Exit menu");
                break;
        }
        Console.WriteLine($"New exchange rate value for USD is: {USD}");
        Console.WriteLine();
    }
    private static Customer CreateNewCustomer()
    {
        Console.Write("To add a new customer, please enter a new customer ID: ");
        double customerID = Methods.GetInputNumber();
        Random numberGenerator = new Random();
        int accountID = numberGenerator.Next(40000000, 49999999);
        Console.WriteLine($"A checking account have automatically been created to {customerID}, accountnumber: {accountID}");
        Console.Write("Please enter the new customer's name: ");
        var name = Console.ReadLine();

        var balance = 0;

        Console.Write("Please enter a password for this customer: ");
        double password = Methods.GetInputNumber();

        Console.WriteLine("A new customer is now created, please press 1 and enter if you want a overview of the complete customer data. To exit this menu, press 0");
        Console.Write("Enter choice: ");
        double menuChoice = Methods.GetInputNumber();

        switch (menuChoice)
        {
            case 1:
                Console.WriteLine($"New customer\nCustomer ID: {customerID}\nChecking accountnumber: {accountID}\nCustomer name: {name}" +
                                  $"\nCustomer password: {password}");
                break;
            case 0:
                Console.WriteLine("Closing menu.");
                break;
        }

        
        Customer createdCustomer = new Customer(customerID, accountID, balance, name, password);
        Methods.LogInList.Add(createdCustomer);
        return createdCustomer;
    }

    public static void SEKToUSD()
    {
        Console.Write("Convert an amount in Swedish Krona (SEK) to US Dollar (USD): ");
        decimal SEK = GetInputDecimal();
        
        decimal ExchangeRate = SEK / USD;
        Console.WriteLine(SEK + " SEK converts to " + Math.Round(ExchangeRate) + " USD.");
        Console.WriteLine();
    }
    public static void AdminMenu()
    {
        Methods.PrintLogo();
        
        Console.WriteLine("You are now logged in as Admin\n");
   
        do
        {
            Console.WriteLine("1. Create New Customer");
            Console.WriteLine("2. Set Currency Rate");
            Console.WriteLine("3. Display Next Transaction Time (VARNING, when displayed the time will continue until reboot program)");
            Console.WriteLine("0. Log out");
            double choice = Methods.GetInputNumber();
            switch (choice)
            {
                case 1:
                    CreateNewCustomer();
                    break;
                case 2:
                    SetCurrencyRate();
                    break;
                case 3:
                    RunTransactionTimerInBackground();
                    break;
                case 0:
                    Methods.LoginAs();
                    break;
                default:
                    Console.WriteLine("That was not a valid choice.");
                    break;
            }
        } while (true);
    }

    private static void RunTransactionTimerInBackground()
    {
        Console.WriteLine("Await next transaction time... Perfect time for a quick coffee run ;D");
        Console.WriteLine("While you wait, remember to press a key when you want to go back to menu!");

        var aTimer = new System.Timers.Timer(300000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            Console.ReadLine();
            static void OnTimedEvent(Object source, ElapsedEventArgs e)
            {
                Console.WriteLine("The last transaction was confirmed at: " + e.SignalTime);
                Console.WriteLine("\nNEXT TRANSACTION WILL BE IN 5 MINUTES\n");
            }
    }

}

