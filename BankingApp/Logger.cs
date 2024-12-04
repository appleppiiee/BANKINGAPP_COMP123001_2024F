using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankingApp
{
    public class Logger
    {
        private static List<string> loginEvents = new List<string>();
        private static List<string> transactionEvents = new List<string>();

        public static void LoginHandler(object sender, EventArgs args)
        {
            if (args is LoginEventArgs loginArgs)
            {
                string log = $"{loginArgs.PersonName} logged in successfully: {loginArgs.Success} at {DateTime.Now}";
                loginEvents.Add(log);
            }
        }

        public static void TransactionHandler(object sender, EventArgs args)
        {
            if (args is TransactionEventArgs transactionArgs)
            {
                string operation = transactionArgs.Amount >= 0 ? "deposit" : "withdraw";
                string log = $"{transactionArgs.PersonName} performed a {operation} of {Math.Abs(transactionArgs.Amount):C} " +
                             $"successfully: {transactionArgs.Success} at {DateTime.Now}";
                transactionEvents.Add(log);
            }
        }

        public static void ShowLoginEvents()
        {
            Console.WriteLine("Login Events:");
            foreach (var log in loginEvents)
            {
                Console.WriteLine(log);
            }
        }

        public static void ShowTransactionEvents()
        {
            Console.WriteLine("Transaction Events:");
            foreach (var log in transactionEvents)
            {
                Console.WriteLine(log);
            }
        }
    }
}

