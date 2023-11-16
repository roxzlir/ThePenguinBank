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
    }

}