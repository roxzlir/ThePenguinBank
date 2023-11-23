namespace ThePenguinBank;

internal class Admin
{


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
    }

    public static void SEKToUSD()
    {
        Console.Write("Convert an amount in Swedish Krona (SEK) to US Dollar (USD): ");
        decimal SEK = Convert.ToDecimal(Console.ReadLine());

        decimal USD = SEK / 10.4275286757M;
        Console.WriteLine(SEK + " SEK converts to " + Math.Round(USD) + " USD.");
    }
    static void AdminMenu()
    {
        Program.PrintLogo();
        

        do
        {
            Console.WriteLine("1. Create New Customer");
            Console.WriteLine("2. Create Saving Account");
            Console.WriteLine("3. Print Accounts");
            Console.WriteLine("4. Transfer money between your accounts");
            Console.WriteLine("0. Close program");
            double choice = Program.GetInputNumber();
            switch (choice)
            {
                case 1:
                    CreateNewCustomer();
                    break;
                case 2:
                    
                    break;
                case 3:
                    
                    break;
                case 4:
                    {
                        
                    }
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("That was not a valid choice.");
                    break;
            }
        } while (true);
    }

}

