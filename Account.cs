namespace ThePenguinBank
{
    abstract class Account
    {
        public double CustomerID { get; set; }
        public int AccountID { get; set; }
        public double Balance { get; set; }

        public Account(double customerID, int accountID, double balance)
        {
            CustomerID = customerID;
            AccountID = accountID;
            Balance = balance;
        }
    }
}