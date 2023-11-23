namespace ThePenguinBank;

internal class Admin
{

    public static decimal USD = 10.49M;


    public static decimal GetInputDecimal()
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
        Console.WriteLine();
    }
    public static void SetCurrencyRate()
    {
        Console.WriteLine($"Right now your US Dollar exchange rate value is: {USD}");
        Console.Write("To set new exchange rate press 1, to exit press any key: ");
        double menu = Program.GetInputNumber();
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
    public static Customer CreateNewCustomer()
    {
        Console.Write("To add a new customer, please enter a new customer ID: ");
        double customerID = Program.GetInputNumber();
        Random numberGenerator = new Random();
        int accountID = numberGenerator.Next(40000000, 49999999);
        Console.WriteLine($"A checking account have automaticlly been created to {customerID}, accountnumber: {accountID}");
        Console.Write("Please enter the new customer's name: ");
        string name = Console.ReadLine();

        int balance = 0;

        Console.Write("Please enter a password for this customer: ");
        double password = Program.GetInputNumber();

        Console.WriteLine("A new customer is now created, please press 1 and enter if you want a overview of the complete customer data. To exit this menu, press 0");
        Console.Write("Enter choice: ");
        double menuChoice = Program.GetInputNumber();

        if (menuChoice == 1)
        {
            Console.WriteLine($"New customer\nCustomer ID: {customerID}\nChecking accountnumber: {accountID}\nCustomer name: {name}" +
                $"\nCustomer password: {password}");
        }
        else if (menuChoice == 0)
        {
            Console.WriteLine("Closing menu.");
        }

        
        Customer createdCustomer = new Customer(customerID, accountID, balance, name, password);
        Program.logInList.Add(createdCustomer);
        return createdCustomer;
        Console.WriteLine();
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
        Program.PrintLogo();

        Console.WriteLine("You are now logged in as Admin");
        Console.WriteLine();
        do
        {
            Console.WriteLine("1. Create New Customer");
            Console.WriteLine("2. Set Currency Rate");
            Console.WriteLine("0. Log out");
            double choice = Program.GetInputNumber();
            switch (choice)
            {
                case 1:
                    CreateNewCustomer();
                    break;
                case 2:
                    SetCurrencyRate();
                    break;
                case 0:
                    Program.LoginAs();
                    break;
                default:
                    Console.WriteLine("That was not a valid choice.");
                    break;
            }
        } while (true);
    }

}

