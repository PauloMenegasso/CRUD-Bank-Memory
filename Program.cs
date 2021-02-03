using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        static List<Account> accountList = new List<Account>();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListAccounts();
                        break;
                    case "2":
                        InsertAccounts();
                        break;
                    case "3":
                        Transfer();
                        break;
                    case "4":
                        Withdraw();
                        break;
                    case "5":
                        Deposit();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOption = GetUserOption();
            }
            Console.WriteLine("Thanks for using our services.");
            Console.ReadLine();
        }

        private static void InsertAccount()
        {
            Console.WriteLine("Insert new account");

            Console.Write("Type 1 for physical account and 2 for legal account");
            int accTypeEntry = ReadNumericEntry();

            Console.WriteLine("Type client name: ");
            string nameEntry = ReadStringEntry();

            Console.WriteLine("Type initial balance: ");
            double balanceEntry = ReadDoubleEntry();

            Console.WriteLine("Type the credit: ");
            double creditEntry = ReadDoubleEntry();

            Account newAccount = new Account(accountType: (AccountType)accTypeEntry,
                              balance: balanceEntry,
                              credit: creditEntry,
                              name: nameEntry);
            accountList.Add(newAccount);
        }


        private static void ListAccounts()
        {
            Console.WriteLine("Accounts list");

            if (accountList.Count == 0)
            {
                Console.WriteLine("There are any accounts inserted yet.");
                return;
            }
            for(int i = 0; i < accountList.Count; i++)
            {
                Account account = accountList[i];
                Console.WriteLine("Account #{0} - ", i);
                Console.WriteLine(account);
            }
        }

        private static void Withdraw()
        {
            Console.WriteLine("Select the account id from which you want to withdraw: ");
            int selectIndex = ReadNumericEntry();

            Account account = accountList[selectIndex];

            Console.WriteLine("Select the value you wish to withdraw: ");
            double selectValue = ReadDoubleEntry();

            account.Withdraw(selectValue);
        }

        private static void Deposit()
        {
            Console.WriteLine("Select the account id from which you want to deposit: ");
            int selectIndex = ReadNumericEntry();

            Account account = accountList[selectIndex];

            Console.WriteLine("Select the value you wish to deposit: ");
            double selectValue = ReadDoubleEntry();

            account.Deposit(selectValue);
        }

        private static void Transfer()
        {
            Console.WriteLine("Select the account id from which you want to withdraw: ");
            int selectIndexBase = ReadNumericEntry();

            Account account = accountList[selectIndexBase];


            Console.WriteLine("Select the account id from which you want to transfer: ");
            int selectIndexTransfer = ReadNumericEntry();

            Account destinyAccount = accountList[selectIndexTransfer];


            Console.WriteLine("Select the value to transfer: ");
            double selectValue = ReadDoubleEntry();

            account.Transfer(transferValue: selectValue, destinyAccount: destinyAccount);
        }


        private static int ReadNumericEntry()
        {
            int entry = int.Parse(Console.ReadLine());
            return entry;
        }

        private static double ReadDoubleEntry()
        {
            double entry = double.Parse(Console.ReadLine());
            return entry;
        }

        private static string ReadStringEntry()
        {
            string entry = Console.ReadLine();
            return entry;
        }


        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to the bank.");
            Console.WriteLine("Select your desired option:");

            Console.WriteLine("1 - List accounts");
            Console.WriteLine("2 - Insert new account");
            Console.WriteLine("3 - Transfer");
            Console.WriteLine("4 - Withdraw");
            Console.WriteLine("5 - Deposit");
            Console.WriteLine("C - Clean Console");
            Console.WriteLine("X - Exit");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
