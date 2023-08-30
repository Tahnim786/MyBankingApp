using System;
using System.Globalization; // Required for currency formatting

namespace MyBankingApp
{
    class MyProgram
    {
        static void Main(string[] args)
        {
            // Create a bank account for the user with an initial balance
            BankAccount myAccount = new BankAccount("Tahnim Ali", 1500.0);

            Console.WriteLine($"Welcome to My Banking App!");
            Console.WriteLine($"Account Holder: {myAccount.AccountHolder}");
            Console.WriteLine($"Account Balance: £{myAccount.Balance.ToString("N2")}"); // Format as GBP

            // Start a loop to allow the user to perform actions repeatedly
            while (true)
            {
                Console.WriteLine("\nPlease go through the menu:");
                Console.WriteLine("1. Deposit Funds");
                Console.WriteLine("2. Withdraw Funds");
                Console.WriteLine("3. Check Account Balance");
                Console.WriteLine("4. Leave App");

                int myChoice = int.Parse(Console.ReadLine()!); 

                switch (myChoice)
                {
                    case 1:
                        Console.Write("Enter the amount to deposit: ");
                        double depositAmount = double.Parse(Console.ReadLine()!);
                        myAccount.Deposit(depositAmount);
                        Console.WriteLine($"Deposited £{depositAmount.ToString("N2")} successfully."); 
                        break;

                    case 2:
                        Console.Write("Enter the amount to withdraw: ");
                        double withdrawAmount = double.Parse(Console.ReadLine()!);
                        if (myAccount.Withdraw(withdrawAmount))
                        {
                            Console.WriteLine($"Withdrawn £{withdrawAmount.ToString("N2")} successfully."); 
                        }
                        else
                        {
                            Console.WriteLine("Insufficient funds.");
                        }
                        break;

                    case 3:
                        Console.WriteLine($"Account Balance: £{myAccount.Balance.ToString("N2")}"); 
                        break;

                    case 4:
                        Console.WriteLine("Exiting...");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }
    }

    // Represents a bank account
    class BankAccount
    {
        public string AccountHolder { get; }
        public double Balance { get; private set; }

        // Constructor to create a bank account with an account holder name and initial balance
        public BankAccount(string accountHolder, double initialBalance)
        {
            AccountHolder = accountHolder;
            Balance = initialBalance;
        }

        // Method to deposit funds into the account
        public void Deposit(double amount)
        {
            Balance += amount;
        }

        // Method to withdraw funds from the account
        public bool Withdraw(double amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
    }
}
