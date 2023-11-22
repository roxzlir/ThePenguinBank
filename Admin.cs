namespace ThePenguinBank;

internal class Admin
{

    public static double GetInputNumber() 
    {
        double userInput;
        while (true)
        {
            string inputNumber = Console.ReadLine();
            if (double.TryParse(inputNumber, out userInput))
            {
                break;
            }
            else
            {
                Console.WriteLine("You made an incorrect entry, please enter integers only.");
            }
        }
        return userInput;
    }
 InternalTransfer
    }
    public Customer CreateNewCustomer()
    {
        Console.Write("To add a new customer, please enter a new customer ID: ");
        double customerID = GetInputNumber();
        Random numberGenerator = new Random();
        int accountID = numberGenerator.Next(40000000, 49999999);
        Console.WriteLine($"A checking account have automaticlly been created to {customerID}, accountnumber: {accountID}");
        Console.Write("Please enter the new customer's name: ");
        string name = Console.ReadLine();
        Console.Write($"Please enter {name}'s securitynumber: ");
        double securityNumber = GetInputNumber();
        int maxAttempds = 3;
        Console.Write("Please add a usernamn for this customer: ");
        string userNameCustomer = Console.ReadLine();


        Console.WriteLine("A new customer is now created, please press 1 and enter if you want a overview of the complete customer data. To exit this menu, press 0");
        Console.Write("Enter choice: ");
        double menuChoice = GetInputNumber();

        if (menuChoice == 1)
        {
            Console.WriteLine($"New customer\nCustomer ID: {customerID}\nChecking accountnumber: {accountID}\nCustomer name: {name}" +
                $"\nCustomer securitynumber: {securityNumber}\nCustomer username: {userNameCustomer}");
        }
        else if (menuChoice == 0)
        {
            Console.WriteLine("Closing menu.");
        }

        Customer createdCustomer = new Customer(customerID, accountID, name, securityNumber, maxAttempds, userNameCustomer);
        return createdCustomer;
    }
    static void SEKToUSD()
    {
        Console.Write("Convert an amount in Swedish Krona (SEK) to US Dollar (USD): ");
        decimal SEK = Convert.ToDecimal(Console.ReadLine());

        decimal USD = SEK / 10.4275286757M;
        Console.WriteLine(SEK + " SEK converts to " + Math.Round(USD) + " USD.");
    }

}

