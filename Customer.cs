namespace ThePenguinBank
{
    internal class Customer : Account
    {
        public string Name { get; set; }
        public double Password { get; set; }

        public Customer(double customerID, int accountID, double balance, string name, double password) : base(
            customerID, accountID, balance)
        {
            Name = name;
            Password = password;
        }
    }
}