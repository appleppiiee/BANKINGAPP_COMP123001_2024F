using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankingApp
{
    public struct DayTime
    {
        string AccountNumber { get; }
        decimal Amount { get; }
        Person Originator { get; }
        DayTime Time { get; }


        public Transaction(string accountNumber, decimal amount, Person person, DayTime time)
        {
            AccountNumber = accountNumber;
            Amount = amount;
            Originator = person;
            Time = time;
        }

        public override string ToString()
        {
            string transactionType = Amount >= 0 ? "Deposit" : "Withdraw";
            return $"{transactionType}: Account {AccountNumber}, Name: {Originator.Name}, Amount: {Amount:$}, Time: {Time}"
        }
    }
}
