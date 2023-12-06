namespace ThePenguinBank
{
    internal class Loan
    { 
        public static void ApplyForLoan() //This is our method for loan
        {
            Console.Clear();
            Methods.PrintMenuLogo();

            Console.WriteLine("You want to apply for a loan, please enter your Customer ID: ");
            var requestingCustomerID = Methods.GetInputNumber();

            Console.WriteLine("Please enter the request amount: ");
            double requestedAmount = Methods.GetInputNumber(); //User need to write the amount they want to borrow

            //We take the customerID that user provided above and create a new List, applyList. And we use the static AccountList we have and the method FindAll to match that 
            //customerID
            List<Account> applyList = Customer.AccountList.FindAll(x => x.CustomerID == requestingCustomerID);

            Console.WriteLine("Please select an account for the loan: ");
            int i = 1;
            foreach (var account in applyList) //And we run it to the loop
            {
                Console.WriteLine($"{i++}.{account.AccountID}");
            }
            var loanAccount = int.Parse(Console.ReadLine()!) - 1;
            var loanAmount = Customer.AccountList[loanAccount].Balance * 5; //And here we set the condition that loanAmount can max be 5 times what there is on the account
            //that the user chose to have as a "base" for the loan
            switch (loanAmount) //And then we made a simple switch case to be able to present different interest based on which amount the 
            {                  //user want to borrow
                case <= 50000:
                    Console.WriteLine($"Based on your balance ({Customer.AccountList[loanAccount].Balance}), we can approve a loan for: {loanAmount}");
                    Console.WriteLine("The interest for a loan up to 50 000 is 10%");
                    Console.WriteLine(requestedAmount < loanAmount
                        ? "You are approved for this loan!"
                        : "You are denied for this loan.");
                    break;
                case > 50000 and <= 150000:
                    Console.WriteLine($"Based on your balance ({Customer.AccountList[loanAccount].Balance}), we can approve a loan for: {loanAmount}");
                    Console.WriteLine("The interest for a loan between 50 000 - 150 000 is 7%");

                    Console.WriteLine(requestedAmount < loanAmount
                        ? "You are approved for this loan!"
                        : "You are denied for this loan.");
                    break;
                default:
                    Console.WriteLine($"Based on your balance ({Customer.AccountList[loanAccount].Balance}), we can approve a loan for: {loanAmount}");
                    Console.WriteLine("The interest for a loan above 150 000 is 4%");
                
                    Console.WriteLine(requestedAmount < loanAmount
                        ? "You are approved for this loan!"
                        : "You are denied for this loan.");
                    break;
            }
            Console.Write("Please press any key to exit to menu: ");
            Console.ReadKey();
            //Our goal was to build more on this method, the next step was to then add the loan amount to the account

            // NOTE TO SELF - Vi kan ju bara lägga in requestedAmount som user skriver in genom AccountList[toAccount].Balance += amount;
        }
    }
}