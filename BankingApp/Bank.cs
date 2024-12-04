using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BankingApp
{
    public static class Bank
    {
        public static readonly Dictionary<string, Account> ACCOUNTS;
        public static readonly Dictionary<string, Person> USERS;

        static Bank()
        {
            Console.WriteLine("test");
            //initialize the USERS collection
            AddPerson("Narendra", "1234-5678");    //0
            AddPerson("Ilia", "2345-6789");        //1
            AddPerson("Mehrdad", "3456-7890");     //2
            AddPerson("Vinay", "4567-8901");       //3
            AddPerson("Arben", "5678-9012");       //4
            AddPerson("Patrick", "6789-0123");     //5
            AddPerson("Yin", "7890-1234");         //6
            AddPerson("Hao", "8901-2345");         //7
            AddPerson("Jake", "9012-3456");        //8
            AddPerson("Mayy", "1224-5678");        //9
            AddPerson("Nicoletta", "2344-6789");   //10


            //initialize the ACCOUNTS collection
            AddAccount(new VisaAccount());              //VS-100000
            AddAccount(new VisaAccount(150, -500));     //VS-100001
            AddAccount(new SavingAccount(5000));        //SV-100002
            AddAccount(new SavingAccount());            //SV-100003
            AddAccount(new CheckingAccount(2000));      //CK-100004
            AddAccount(new CheckingAccount(1500, true));//CK-100005
            AddAccount(new VisaAccount(50, -550));      //VS-100006
            AddAccount(new SavingAccount(1000));        //SV-100007 

            //associate users with accounts
            string number = "VS-100000";
            AddUserToAccount(number, "Narendra");
            AddUserToAccount(number, "Ilia");
            AddUserToAccount(number, "Mehrdad");

            number = "VS-100001";
            AddUserToAccount(number, "Vinay");
            AddUserToAccount(number, "Arben");
            AddUserToAccount(number, "Patrick");

            number = "SV-100002";
            AddUserToAccount(number, "Yin");
            AddUserToAccount(number, "Hao");
            AddUserToAccount(number, "Jake");

            number = "SV-100003";
            AddUserToAccount(number, "Mayy");
            AddUserToAccount(number, "Nicoletta");

            number = "CK-100004";
            AddUserToAccount(number, "Mehrdad");
            AddUserToAccount(number, "Arben");
            AddUserToAccount(number, "Yin");

            number = "CK-100005";
            AddUserToAccount(number, "Jake");
            AddUserToAccount(number, "Nicoletta");

            number = "VS-100006";
            AddUserToAccount(number, "Ilia");
            AddUserToAccount(number, "Vinay");

            number = "SV-100007";
            AddUserToAccount(number, "Patrick");
            AddUserToAccount(number, "Hao");

        }

        
        public static void AddUser(string name, string sin)
        {
            Person person = new Person(name, sin);
            person.OnLogin += Logger.LoginHandler;
            USERS[sin] = person;
        }

        public static void AddPerson(string name, string sin)
        {
            AddUser(name, sin);
        }
        public static void AddAccount(Account account)
        {
            account.OnTransaction += Logger.TransactionHandler;
            ACCOUNTS[account.Number] = account;
        }
        public static void AddUserToAccount(string number, string name)
        {
            var account = GetAccount(number);
            var user = GetPerson(name);
            account.AddUser(user);
        }

        public static Account GetAccount(string number)
        {
            if (ACCOUNTS.Keys.Contains(number))
            {
                return ACCOUNTS[number];
            }
            else
            {
                throw new AccountException(ExceptionType.ACCOUNT_DOES_NOT_EXIST);
            }
        }
        public static Person GetPerson(string name)
        {
            Person person = null;
            foreach(String key in USERS.Keys)
            {
                if (USERS[key].Name.Equals(name))
                {
                    person = USERS[key]; 
                    break;
                }                
            }    
            if(person == null)
            {
                throw new AccountException(ExceptionType.USER_DOES_NOT_EXIST);
            }
            else
            {
                return person;
            }
        }
        public static void SaveAccounts(string filename)
        {
            var json = JsonSerializer.Serialize(ACCOUNTS.Values, new JsonSerializerOptions { WriteIndented = true});
            File.WriteAllText(filename, json);
        }
        public static void SaveUsers(string filename)
        {
            var json = JsonSerializer.Serialize(USERS.Values, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filename, json);
        }
        public static List<Transaction> GetTransactions()
        {
            var allTransactions = new List<Transaction>();
            foreach(var account in ACCOUNTS.Values)
            {
                allTransactions.AddRange(account.transactions);
            }
            return allTransactions;
        }
        public static List<Transaction> GetAllTransactions()
        {
            var allTransactions = new List<Transaction>();
            foreach (var account in ACCOUNTS.Values)
            {
                allTransactions.AddRange(account.transactions);
            }
            return allTransactions;
        }
        public static void PrintAccounts()
        {
            int count = 0;
            foreach(var account in ACCOUNTS.Values)
            {
                Console.WriteLine($"{count++,2}: {account}");
            }
        }
        public static void PrintPersons()
        {
            int count = 0;
            foreach (var person in USERS.Values)
            {
                Console.WriteLine($"{count++,2}: {person}");
            }
        }
        
    }
}
