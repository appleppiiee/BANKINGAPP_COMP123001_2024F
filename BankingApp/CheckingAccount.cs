using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankingApp
{
    public class CheckingAccount : Account, ITransaction
    {
        private static decimal COST_PER_TRANSACTION = 0.05m;
        private static decimal INTEREST_RATE = 0.005m;
        private static bool hasOverDraft;

        public CheckingAccount(decimal balance = 0, bool hasOverDraft = false)
            : base("CK-", balance)
        {
            this.hasOverdraft = hasOverDraft;
        }

        public void DepOsit(decimal amount, Person person)
        {
            base.Deposit(amount, person);
            OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, true));
        }

        public void Widthraw(decimal amount, Person person)
        {
            if (!IsPersonAssociated(person))
            {
                OnTransactionOccur(this, new TransactionEventArgs(person.Name, -amount, false));
                throw new AccountException(ExceptionType.UnauthorizedAccess);
            }

            if(!IsLoggedIn(person))
            {
                OnTransactionOccur(this, new TransactionEventArgs(person.Name, -amount, false));
                throw new AccountException(ExceptionType.InsufficientFunds);
            }

            if(amount > Balance && !hasOverDraft)
            {
                OnTransactionOccur(this, new TransactionEventArgs(person.Name, -amount, false));
                throw new AccountException(ExceptionType.InsufficientFunds);
            }

            base.Deposit(-amount, person);
            OnTransactionOccur(this, new TransactionEventArgs(person.Name, -amount, true));
        }


        public override void PrepareMonthlyReport()
        {
            decimal serviceCharge = Transactions.Count * COST_PER_TRANSACTION;
            decimal interest = (LowestBalance * INTEREST_RATE) / 12;
            Balance += interest - serviceCharge;
            TransactionScope.Clear();
        }
    }
}
