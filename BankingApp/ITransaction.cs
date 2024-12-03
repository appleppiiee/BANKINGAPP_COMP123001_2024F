using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    internal interface ITransaction
    {
        void Widthraw(decimal amount, Person person)
        {
            Console.WriteLine("test");
        }

        void Deposit(decimal amount, Person person)
        {
        }

        
    }
}
