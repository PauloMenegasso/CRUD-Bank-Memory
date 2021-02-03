using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Account
    {
        private AccountType AccountType { get; set; }
        private double Balance { get; set; }

        private double Credit { get; set; }
        private string Name { get; set; }

        public Account(AccountType accountType, double balance, double credit, string name)
        {
            this.AccountType = accountType;
            this.Balance = balance;
            this.Credit = credit;
            this.Name = name;
        }

        public bool Withdraw(double withdrawValue)
        {
            if (this.Balance - withdrawValue < (this.Credit * -1))
            {
                Console.WriteLine("Not enough credit.");
                return false;
            }

            this.Balance -= withdrawValue;
            WriteBalance();
            return true;
        }

        public void Deposit(double depositValue)
        {
            this.Balance += depositValue;
            WriteBalance();
        }

        public void Transfer(double transferValue, Account destinyAccount)
        {
            if (this.Withdraw(transferValue))
            {
                destinyAccount.Deposit(transferValue);
            }

        }

        public override string ToString()
        {
            string retunr = "";
            retunr += "Account Type " + this.AccountType + " | ";
            retunr += "Name " + this.Name + " | ";
            retunr += "Balance " + this.Balance + " | ";
            retunr += "Credit " + this.Credit + " | ";
            return retunr;
        }



        public void WriteBalance()
        {
            Console.WriteLine("The actual balance of {0}'s account is {1}", this.Name, this.Balance);
        }

    }
}
