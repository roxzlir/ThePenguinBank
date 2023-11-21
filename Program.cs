namespace ThePenguinBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }


        public static int GetInputNumber()
        {
            int userInput;
            while (true)
            {

                string inputNumber = Console.ReadLine();

                if (int.TryParse(inputNumber, out userInput))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Du gjorde en felaktig inmatning!");
                }

            }
            return userInput;
        }
        static string TryLogin(int securityNumber, int userPassword)
        {
            int maxAttempts = 3;

            int adminUsername = 0000; int adminPassword = 9999;



            for (int attempt = 0; attempt <= maxAttempts; attempt++)
            {
                Console.Write($"Ange användarnamn: ");
                int username = GetInputNumber();

                Console.Write($"Ange lösenord: ");
                int password = GetInputNumber();

                if (username == adminUsername && password == adminPassword)
                {
                    return "adminPassed";
                    break;


                }
                if (username == securityNumber && password == userPassword)
                {
                    return "customerPassed";
                    break;
                }
                else
                {
                    Console.WriteLine($"Inloggning misslyckades, antingen fel användarnamn eller fel lösenord. Försök {attempt}/{maxAttempts}.\n");
                }
            }

            return "LoginFailed";
        }
        static Checking CreateCheckingAccount()
        {
            Console.WriteLine("Thank you for opening a new checking account at Penguin Bank");

            Console.Write("Please write your customer ID number: ");
            double customerID = GetInputNumber();

            Random numberGenerator = new Random();
            int accountID = numberGenerator.Next(40000000, 49999999);

            double availableBalance = 0;


            Checking newAccount = new Checking(customerID, accountID, availableBalance);


            Console.WriteLine("Would you like to see a confirmation of your new account details, please press 1");
            Console.Write("Or to exit menu, please press 0: ");
            double userChoice = GetInputNumber();

            if (userChoice == 1)
            {
                Console.WriteLine("Your new checking account:\n" + "Customer ID: " + newAccount.CustomerID + "\nAccount number: " + newAccount.AccountID +
                "\nCurrent balance: " + newAccount.Balance);
                Console.WriteLine("Press any key + enter to exit");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Thank you for choosing Penguin Bank services!");
            }


            return newAccount;
        }
    }

}