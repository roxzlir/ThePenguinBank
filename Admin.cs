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
}