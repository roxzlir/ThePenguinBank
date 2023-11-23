
﻿namespace ThePenguinBank
{
    internal class Customer : Account
    {
            private static object checking;

        public enum AccountTyp
        {
            cheking,
            saving
        }
        public string Name { get; set; }
        public double Password { get; set; }  

        public Customer(double customerID, int accountID, double balance, string name, double password) : base(
            customerID, accountID, balance)

        {
            Name = name;
            Password = password;
        }
        public void Deposit(double amount, AccountTyp accountType, Checking cheking, Saving saving)
        {
            double chekingBalance = cheking.Balance;
            double savingBalance = saving.Balance;

            if(accountType == AccountTyp.cheking)
            {
                chekingBalance += amount;
                Console.WriteLine(chekingBalance);
            }
            else if(accountType == AccountTyp.saving)
            {
                savingBalance += amount;
                Console.WriteLine(savingBalance);
            }
            else
            {
                Console.WriteLine("Inviled accountType, enter cheking or saving");
            }
        }

        public static void AccountLog(AccountTyp accountType, Checking cheking, Saving saving)
        {
            List <Transaction> transactions = new List<Transaction>();
            if(accountType == AccountTyp.cheking)
            {
                transactions = checking.Tra
            }

            else if(accountType == AccountTyp.saving)
            {
                transactions = saving.Tra
            }

            else
            {
                Console.WriteLine("Inlalid accountType, enter Cheking or saving");
                return;
            }
            Console.WriteLine("AccountTyp log in " + accountType);
            foreach (Transaction transaction in transactions)
            {
                Console.WriteLine(transaction.Date);
            }
        }

        //Add a method in Customer class: Deposit()

        //A   method that adds a value to property Balance in Checking and Saving.
        static void Main(string[] args)
        {
            RunBankingProgram();

            // lägg till alt i Menu
        }

        static void RunBankingProgram()
        {
            List<CheckingAccount> checkAccounts = new List<CheckingAccount>
        {
            new CheckingAccount("Sender Sendersson", 1000),
            new CheckingAccount("Anton Sender", 500),
            new CheckingAccount("Sonja Senderson", 100),
            new CheckingAccount("Sandra Senderssen", 400)

            // Avsändarlista
        };
            List<CheckingAccount> receiveAccounts = new List<CheckingAccount>
            {
                new CheckingAccount("Receiver Receiversson", 0),
                new CheckingAccount("Randy Receiv", 50),
                new CheckingAccount("Rickie Receiver", 10),
                new CheckingAccount("Becca Receiversen", 50),
            
            // Mottagarlista
        };


            while (true)
            {
                Console.WriteLine("\n==== Bank Transfer Menu ====");
                Console.WriteLine("1. Display Balances");
                Console.WriteLine("2. Transfer Money");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice (1-3): ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            // se balans på dina egna konton?? kan ju inte ska se andras konton?
                            // kanske inte visa tillgänglig summa hos andra? Sånt får man ju inte se..
                            DisplayBalance(checkAccounts, receiveAccounts);
                            break;
                        case 2:
                            PerformTransfer(checkAccounts, receiveAccounts);
                            break;
                        case 3:
                            Console.WriteLine("Exiting the program. Goodbye!");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        static void DisplayBalance(List<CheckingAccount> senders, List<CheckingAccount> receivers)
        {
            // display own accounts?

            Console.WriteLine("Senders Balances:");
            foreach (var sender in senders)
            {
                Console.WriteLine(sender.Username + "'s balance: $" + sender.Balance);
            }
            Console.WriteLine("Receivers Balances");
            foreach (var receiver in receivers)
            {
                Console.WriteLine(receiver.Username + "'s balance: $" + receiver.Balance);
                // SEK istället för $?
            }

        }

        static void PerformTransfer(List<CheckingAccount> senders, List<CheckingAccount> receivers)
        {
            // Show receiver accounts
            Console.WriteLine("Select the sender:");
            for (int i = 0; i < senders.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {senders[i].Username}");
            }

            if (int.TryParse(Console.ReadLine(), out int senderChoice) && senderChoice >= 1 && senderChoice <= senders.Count)
            {
                CheckingAccount selectedSender = senders[senderChoice - 1];

                // select receiver
                Console.WriteLine("Select the receiver: ");
                for (int j = 0; j < receivers.Count; j++)
                {
                    Console.WriteLine($"{j + 1}. {receivers[j].Username}");
                }

                if (int.TryParse(Console.ReadLine(), out int receiverChoice) && receiverChoice >= 1 && receiverChoice <= receivers.Count)
                {
                    CheckingAccount selectedReceiver = receivers[receiverChoice - 1];

                    // Enter the amount to transfer
                    Console.Write("Enter the amount to transfer: $");
                    if (double.TryParse(Console.ReadLine(), out double transferAmount))
                    {
                        selectedSender.TransferMoney(selectedReceiver, transferAmount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid numeric amount.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid receiver selection. Please enter a valid option.");
                }
            }
            else
            {
                Console.WriteLine("Invalid sender selection. Please enter a valid option.");
            }
        }
    }

    class CheckingAccount
    {
        public double Balance { get; private set; }
        public string Username { get; }

        public CheckingAccount(string userName, double currentBalance)
        {
            Username = userName;
            Balance = currentBalance;
        }

        public void TransferMoney(CheckingAccount recipient, double amount)
        {
            if (amount <= 0 || amount > Balance)
            {
                Console.WriteLine("Invalid transfer, the amount is too big or invalid!");
                return;
            }

            Balance -= amount;
            recipient.ReceiveMoney(amount);
            Console.WriteLine("$" + amount + " transferred from " + Username + " to " + recipient.Username);
        }

        private void ReceiveMoney(double amount)
        {
            Balance += amount;
        }
    }
}