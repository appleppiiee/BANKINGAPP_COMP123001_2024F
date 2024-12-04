using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankingApp
{
    public class VisaAccount
    {
        private const decimal INTEREST_RATE = 0.1995m;
        private readonly decimal creditLimit;

        public VisaAccount(decimal balance = 0, decimal creditLimit = 1200)
            : base("VS-", balance)
        {
            this.creditLimit = creditLimit;
        }

        public void DoPayment(decimal amount, Person person)
        {
            base.Deposit(amount, person);
        }

        public void DoPurchase(decimal amount, Person person)
        {
            if (!users.Contains(person))
                throw new AccountException(ExceptionType.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);

            if (!person.IsAuthenticated)
                throw new AccountException(ExceptionType.USER_NOT_LOGGED_IN);

            if (Balance - amount < -creditLimit)
                throw new AccountException(ExceptionType.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);

            base.Deposit(-amount, person); // Negative amount to reduce balance
        }

        public override void PrepareMonthlyStatement()
        {
            decimal interest = (LowestBalance * INTEREST_RATE) / 12;
            Balance -= interest;
            transactions.Clear();
        }

        public void Withdraw(decimal amount, Person person)
        {
            throw new NotImplementedException();
        }
    }
}
