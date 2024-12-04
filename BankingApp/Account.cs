using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankingApp
{
    public abstract class Account
    {
        private static int LAST_NUMBER = 100_000;
        protected readonly List<Person> users;
        public readonly List<Transaction> transactions;

        public string Number { get; }
        public decimal Balance { get; protected set; }
        public decimal LowestBalance { get; protected set; }

        public event EventHandler OnLogin;
        public event EventHandler OnTransaction;

        protected Account(string type, decimal balance)
        {
            Console.WriteLine("test");
            if (type != "VS-" && type != "SV-" && type != "CK-")
            {
                throw new ArgumentException("Invalid account type. Must be 'VS-', 'SV-', or 'CK-'.");
            }

            Number = $"{type}{LAST_NUMBER++}";
            Balance = balance;
            LowestBalance = balance;

            users = new List<Person>();
            transactions = new List<Transaction>();
        }
        //deposit
        public void Deposit(decimal amount, Person person)
        {
            Balance += amount;
            if(Balance < LowestBalance)
            {
                LowestBalance = Balance;
            }
            var transaction = new Transaction(Number, amount, person, Utils.Now);
            transactions.Add(transaction);
            OnTransactionOccur(this, EventArgs.Empty);
        }       
        //adduser
        public void AddUser(Person person)
        {
            users.Add(person);
        }
        public void AddPerson(Person person )
        {
            AddUser(person);
        }
        //isuser
        public bool IsUser(string name)
        {
            foreach(Person user in users)
            {
                if(user.Name == name)
                {
                    return true;
                }                
            }
            return true;
        }
        //ontrasactionOccur
        public virtual void OnTransactionOccur(object sender, EventArgs e)
        {

        }
        //preparemonthlystatement
        public abstract void PrepareMonthlyReport();

        //tostring
        public override string ToString()
        {
            var result = $"Account Number: {Number}\n";
            result += "Users:\n";
            foreach(var user in users)
            {
                result += $"-{user.Name}\n";
            }
            result += $"Balance: {Balance:c2}\n";
            result += "Transactions:\n";
            foreach(var transaction in transactions)
            {
                result += transaction.ToString() + "\n";
            }
            return result;
        }

    }
}
