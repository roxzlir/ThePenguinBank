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


    static void SEKToUSD()
    {
        Console.Write("Convert an amount in Swedish Krona (SEK) to US Dollar (USD): ");
        decimal SEK = Convert.ToDecimal(Console.ReadLine());

        decimal USD = SEK / 10.4275286757M;
        Console.WriteLine(SEK + " SEK converts to " + Math.Round(USD) + " USD.");
    }
}

