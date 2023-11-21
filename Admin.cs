namespace ThePenguinBank;

internal class Admin : Account
{
    public Admin(double customerID, int accountID, string newCustomer, string userName) : base(customerID, accountID)
    {
        NewCustomer = newCustomer;
        UserName = userName;
    }

    public string NewCustomer { get; set; }
    public string UserName { get; set; }

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
   
}