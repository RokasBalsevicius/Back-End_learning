using BANKING.Repositories;
using BANKING.Models;
using Utilities;

namespace BANKING.Services;

public class BankingService
{
    private readonly Utility utils = new();
    private readonly CustomerRepository repository = new();

    public void BankingApplication()
    {
        var customers = repository.Customers;
        while (true)
        {
            Console.WriteLine("====== Banking Application Main Menu ======");
            Console.WriteLine("1 - Create Account");
            Console.WriteLine("2 - Deposit");
            Console.WriteLine("3 - Withdrawal");
            Console.WriteLine("4 - Check Balance");
            Console.WriteLine("5 - Exit");

            long menuOption = utils.ReadNumber<int>("Enter menu option: ");

            switch (menuOption)
            {
                case 1:
                    while (true)
                    {
                        string? surname = null;
                        Console.WriteLine("Enter the first name of new account holder or type 'Exit' to exit");
                        string? firstName = Console.ReadLine()?.Trim().ToUpper();

                        if (string.IsNullOrWhiteSpace(firstName))
                        {
                            Console.WriteLine("First name cannot be empty!");
                            continue;
                        }
                        else if (firstName == "EXIT")
                        {
                            Console.WriteLine("Exiting to main menu....");
                            break;
                        }

                        while (true)
                        {

                            Console.WriteLine("Enter the surname of new account holder or type 'Exit' to exit");
                            surname = Console.ReadLine()?.Trim().ToUpper();
                            if (string.IsNullOrWhiteSpace(surname))
                            {
                                Console.WriteLine("Surname cannot be empty!");
                                Console.WriteLine("-------------------------");
                                continue;
                            }
                            else if (surname == "EXIT")
                            {
                                Console.WriteLine("Exiting to main menu....");
                                Console.WriteLine("-------------------------");
                                break;
                            }
                            break;
                        }

                        while (true)
                        {
                            Console.WriteLine("Enter personal code or type 'Exit' to exit: ");
                            string? input = Console.ReadLine()?.Trim().ToUpper();

                            if (input == "EXIT")
                            {
                                Console.WriteLine("Exiting to main menu....");
                                Console.WriteLine("-------------------------");
                                break;
                            }

                            if (!long.TryParse(input, out long personalCode))
                            {
                                Console.WriteLine("Invalid personal code, please enter numbers only!");
                                continue;
                            }

                            if (personalCode.ToString().Length < 9 || personalCode.ToString().Length > 12)
                            {
                                Console.WriteLine("Enterred personal code is not valid, personal code length must be between 9 and 12");
                                continue;
                            }

                            var match = customers.FirstOrDefault(i => i.PersonalNumber == personalCode);

                            if (match != null)
                            {
                                Console.WriteLine("This personal code already exists! Try again.");
                                continue;
                            }


                            string fullName = $"{firstName} {surname}";
                            customers.Add(new Customer
                            {
                                FullName = fullName,
                                PersonalNumber = personalCode,
                                Accounts = new()
                                {
                                    new() {Type = "CHECKINGS", Balance = 0 },
                                    new() { Type = "SAVINGS", Balance = 0 }
                                }
                            });
                            Console.WriteLine($"New account created for {fullName}");
                            break;
                        }
                        break;
                    }
                    continue;
                case 2:
                    while (true)
                    {
                        Console.WriteLine("Enter the full name of account holder or type 'Exit' to exit: ");
                        string? nameInput = Console.ReadLine()?.Trim().ToUpper();
                        if (string.IsNullOrWhiteSpace(nameInput))
                        {
                            Console.WriteLine("Full name cannot be empty!");
                            continue;
                        }
                        if (nameInput == "EXIT")
                        {
                            Console.WriteLine("Exiting to main menu..");
                            break;
                        }

                        var match = customers.FirstOrDefault(n => n.FullName == nameInput);
                        if (match == null)
                        {
                            Console.WriteLine($"Account with entered full name '{nameInput}' does not exists.");
                            Console.WriteLine($"Currently existing account names are: ");
                            foreach (var item in customers)
                            {
                                Console.WriteLine(item.FullName);
                            }
                            continue;
                        }

                        while (true)
                        {
                            Console.WriteLine("Enter deposit amount or type 'Exit' to exit: ");
                            string? amountInput = Console.ReadLine()?.Trim().ToUpper();
                            if (amountInput == "EXIT")
                            {
                                Console.WriteLine("Exiting to main menu..");
                                break;
                            }

                            if (!double.TryParse(amountInput, out double depositAmount))
                            {
                                Console.WriteLine("Invalid deposit value. Please enter numbers only!");
                                continue;
                            }

                            var checkingsAccount = match.Accounts.FirstOrDefault(t => t.Type.Equals("CHECKINGS", StringComparison.OrdinalIgnoreCase));
                            double checkingsAccountBalance = checkingsAccount.Balance;
                            Console.WriteLine($"Balance of account '{nameInput}' before deposit: {checkingsAccountBalance}");
                            checkingsAccount.Balance = Math.Round(checkingsAccount.Balance + depositAmount, 2);
                            Console.WriteLine($"Updated balance of account {nameInput} after deposit: {checkingsAccount.Balance}");
                            break;
                        }
                        break;
                    }
                    continue;
                case 3:
                    while (true)
                    {
                        Console.WriteLine("Enter the full name of account holder or type 'Exit' to exit: ");
                        string? nameInput = Console.ReadLine()?.Trim().ToUpper();
                        if (string.IsNullOrWhiteSpace(nameInput))
                        {
                            Console.WriteLine("Full name cannot be empty!");
                            continue;
                        }
                        if (nameInput == "EXIT")
                        {
                            Console.WriteLine("Exiting to main menu..");
                            break;
                        }
                        var match = customers.FirstOrDefault(c => c.FullName == nameInput);
                        if (match == null)
                        {
                            Console.WriteLine($"Bank account under entered name {nameInput} does not exits");
                            Console.WriteLine("Currently existing account names are: ");
                            foreach (var customer in customers)
                            {
                                Console.WriteLine(customer.FullName);
                            }
                            continue;
                        }
                        while (true)
                        {
                            Console.WriteLine("Enter withdrawal amount or type 'Exit' to exit: ");
                            string? amountInput = Console.ReadLine()?.Trim().ToUpper();
                            if (amountInput == "EXIT")
                            {
                                Console.WriteLine("Exiting to main menu..");
                                break;
                            }

                            if (!double.TryParse(amountInput, out double amount))
                            {
                                Console.WriteLine("Invalid withdrawal amount entered. Please enter a number");
                                continue;
                            }

                            var checkingsAccount = match.Accounts.FirstOrDefault(account => account.Type == "CHECKINGS");
                            double remainingCheckingsBalance = Math.Round(checkingsAccount.Balance, 2);
                            double withdrawalAmount = Math.Round(amount, 2);

                            if (remainingCheckingsBalance - withdrawalAmount < 0)
                            {
                                Console.WriteLine($"Withdrawal amount '{withdrawalAmount}' is greater than account balance '{remainingCheckingsBalance}', leaving account balance negative '{remainingCheckingsBalance - withdrawalAmount}' ");
                                Console.WriteLine($"Please enter amount less or equal to current remaining account balance: {remainingCheckingsBalance}");
                                continue;
                            }

                            checkingsAccount.Balance = remainingCheckingsBalance - withdrawalAmount;
                            Console.WriteLine($"Withdrawal of {withdrawalAmount} EUR completed successfully. Remaining Checkings account balance is: {checkingsAccount.Balance} EUR");
                            break;
                        }
                        break;
                    }
                    continue;
                case 4:
                    while (true)
                    {
                        Console.WriteLine("Enter account holder full name or type 'Exit' to exit: ");
                        string? nameInput = Console.ReadLine()?.Trim().ToUpper();
                        if (string.IsNullOrWhiteSpace(nameInput))
                        {
                            Console.WriteLine("Account name cannot be empty");
                            continue;
                        }
                        if (nameInput == "EXIT")
                        {
                            Console.WriteLine("Exiting to main menu...");
                            break;
                        }

                        var match = customers.FirstOrDefault(customer => customer.FullName == nameInput);
                        if (match == null)
                        {
                            Console.WriteLine($"Account with entered name '{nameInput}' does not exists.");
                            continue;
                        }

                        foreach (var account in match.Accounts)
                            Console.WriteLine($"Account '{account.Type}' balance is {account.Balance} EUR.");
                        break;
                    }
                    continue;
                case 5:
                    Console.WriteLine("Exiting banking application.. Bye!");
                    return;
                default:
                    Console.WriteLine("Invalid input, enter valid menu option.");
                    continue;
            }
        }
    }
}