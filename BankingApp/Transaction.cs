using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public struct Transaction
    {
        public string AccountNumber { get; }
        public decimal Amount { get; }
        public Person Originator { get; }
        public DateTime Time { get; }

        public Transaction(string accountNumber, decimal amount, Person person, DateTime time)
        {
            AccountNumber = accountNumber;
            Amount = amount;
            Originator = person;
            Time = time;
        }

        public override string ToString()
        {
            string type = Amount > 0 ? "Deposit" : "Withdraw";
            return $"{AccountNumber} {type} ${Math.Abs(Amount):0.00} by {Originator.Name} on {Time}";
        }
    }

}