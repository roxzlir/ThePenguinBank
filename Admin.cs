using System.Timers;

namespace ThePenguinBank;
internal class Admin 
{
    private static decimal USD = 10.49M; //We have chose to set a starting value of USD currency rate as a property.
    private static decimal GetInputDecimal() //We created a method to receive a user input in decimal data type to be able to set the currency rate with decimals.
    {
        decimal userInput;
        while (true) //Simple while loop with TryParse.
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
    private static void SetCurrencyRate() //This method will be able to set the currency rate.
    {
        Console.Clear();
        Methods.PrintMenuLogo();
        Console.WriteLine($"Right now your US Dollar exchange rate value is: {USD}");
        Console.Write("To set new exchange rate press 1, to exit press any key: ");
        double menu = Methods.GetInputNumber(); //We take a user input with a double, since we are using double alot in our code.
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
        Console.Write("Please press any key to exit to menu: ");
        Console.ReadKey();
    }
    private static void CreateNewCustomer() //We added the create new customer in admin class since it will be in the admin menu choice. 
    {
        Console.Clear();
        Methods.PrintMenuLogo();
        Console.Write("To add a new customer, please enter a new customer ID: ");
        double customerID = Methods.GetInputNumber(); //We want admin to add the customer ID for the new customer.

        Random numberGenerator = new Random(); //We provide a new account as standard for a new customer, since a customer in a bank always need a commitment.
        int accountID = numberGenerator.Next(40000000, 49999999); //We chose to add a random accountnumber to our customers, there is one in a million chance that two customer will get the same accountnumber...
        Console.WriteLine($"A checking account have automatically been created to {customerID}, accountnumber: {accountID}");

        Console.Write("Please enter the new customer's name: ");
        var name = Console.ReadLine();

        int balance = 0;

        Console.Write("Please enter a password for this customer: ");
        double password = Methods.GetInputNumber(); //Admin will set the password.

        Console.WriteLine("A new customer is now created, here is a overview of the complete customer data:");
        Console.WriteLine($"\nCustomer ID: {customerID}\nChecking accountnumber: {accountID}\nCustomer name: {name}" +
                             $"\nCustomer password: {password}\n");
 
        Customer createdCustomer = new Customer(customerID, accountID, balance, name, password); //We take all the data and create a new customer object.
        Checking newChecking = new Checking(customerID, accountID, balance); //We add the same data for adding a new checking object or "Checkingaccount" in our bank.

        Methods.LogInList.Add(createdCustomer); //We add the customer to our LogInList, this list is the base for our login process, we compare 
                                               //the user input with this list of "approved" customerID's and passwords.
        Customer.AccountList.Add(newChecking);//We also add the checking object to our AccountList to be used in serveral methods.

        Console.Write("Please press any key to exit to menu: ");
        Console.ReadKey();
    }

    public static void SEKToUSD() //This is our method to make an exchange between currencies. We have a base for this method but haven't had time to build it further
                                 //we wanted to take funds from balance and add it in another "account"
    {
        Console.Clear();
        Methods.PrintMenuLogo();
        Console.Write("Convert an amount in Swedish Krona (SEK) to US Dollar (USD): ");
        decimal SEK = GetInputDecimal(); //Here we use the InputDecimal method
        
        decimal ExchangeRate = SEK / USD; //We take the property USD as base for this
        Console.WriteLine(SEK + " SEK converts to " + Math.Round(ExchangeRate) + " USD.");
        Console.Write("Please press any key to exit to menu: ");
        Console.ReadKey();
    }
    public static void AdminMenu() //The admin menu:
    {
        double choice;
        do //We use a do/while loop since we want all the data inside to be presented once no matter what.
        {
            Console.Clear();
            Methods.PrintMenuLogo();
            Console.WriteLine("You are now logged in as Admin\n");

            Console.WriteLine("1. Create New Customer");
            Console.WriteLine("2. Set Currency Rate");
            Console.WriteLine("3. Display Next Transaction Time (VARNING, when displayed the time will continue until reboot program)");
            Console.WriteLine("0. Log out");
            choice = Methods.GetInputNumber(); //We take the the user input and add it to a switch case.
                                              //Run all our methods depending which choice the admin make.
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
                    Methods.Run();
                    break;
                default:
                    Console.WriteLine("That was not a valid choice.");
                    break;
            }
        } while (choice != 0);
       
    }

    private static void RunTransactionTimerInBackground() //This is the first version of our transaction control timer. 
    {
        Console.Clear();
        Methods.PrintMenuLogo();

        Console.WriteLine("Await next transaction time... Perfect time for a quick coffee run ;D");
        Console.WriteLine("While you wait, remember to press a key when you want to go back to menu!");

        var aTimer = new System.Timers.Timer(300000); //We use the System Timers Timer and create a new instance of that with our input of milliseconds.
            aTimer.Elapsed += OnTimedEvent;          //This runs in the background when we start this method and will keep doing that after it's started.                                             
            aTimer.AutoReset = true;                //Our goal was to connect this with our "transfer" method.
            aTimer.Enabled = true;
            Console.ReadLine();
            static void OnTimedEvent(Object source, ElapsedEventArgs e)
            {
                Console.WriteLine("The last transaction was confirmed at: " + e.SignalTime);
                Console.WriteLine("\nNEXT TRANSACTION WILL BE IN 5 MINUTES\n");
            }
    }

}

