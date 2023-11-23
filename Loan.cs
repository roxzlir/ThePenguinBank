namespace ThePenguinBank
{
    internal class Loan
    {

        public static void ApplyForLoan()
        {
            Console.WriteLine("You want to apply for a loan, please enter your Customer ID: ");
            var requestingCustomerID = Program.GetInputNumber();

            Console.WriteLine("Please enter the request amount: ");
            double requestedAmount = Program.GetInputNumber();
            List<Account> applyList = Customer.AccountList.FindAll(x => x.CustomerID == requestingCustomerID);

            Console.WriteLine("Please select an account for the loan: ");
            int i = 1;
            foreach (var account in applyList)
            {
                Console.WriteLine($"{i++}.{account.AccountID}");
            }

            var loanAccount = int.Parse(Console.ReadLine()) - 1;

            var loanAmount = Customer.AccountList[loanAccount].Balance * 5;
            if (loanAmount <= 50000)
            {
                Console.WriteLine($"Based on your balance ({Customer.AccountList[loanAccount].Balance}), we can approve a loan for: {loanAmount}");
                Console.WriteLine("The interest for a loan up to 50 000 is 10%");
                if (requestedAmount < loanAmount)
                {
                    Console.WriteLine("You are approved for this loan!");
                }
                else
                {
                    Console.WriteLine("You are denied for this loan.");
                }
            }
            else if (loanAmount > 50000 && loanAmount <= 150000)
            {
                Console.WriteLine($"Based on your balance ({Customer.AccountList[loanAccount].Balance}), we can approve a loan for: {loanAmount}");
                Console.WriteLine("The interest for a loan between 50 000 - 150 000 is 7%");
                if (requestedAmount < loanAmount)
                {
                    Console.WriteLine("You are approved for this loan!");
                }
                else
                {
                    Console.WriteLine("You are denied for this loan.");
                }
            }
            else
            {
                Console.WriteLine($"Based on your balance ({Customer.AccountList[loanAccount].Balance}), we can approve a loan for: {loanAmount}");
                Console.WriteLine("The interest for a loan above 150 000 is 4%");
                if (requestedAmount < loanAmount)
                {
                    Console.WriteLine("You are approved for this loan!");
                }
                else
                {
                    Console.WriteLine("You are denied for this loan.");
                }
            }

            Console.WriteLine();
        }
    }
}