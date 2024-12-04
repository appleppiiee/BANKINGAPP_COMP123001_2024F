using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    class Person
    {
        private string password;

        // Event to handle login activities
        public event EventHandler OnLogin;

        public string Sin { get; }
        public string Name { get; }
        public bool IsAuthenticated { get; private set; }

        public Person(string name, string sin)
        {
            Name = name;
            Sin = sin;
            password = sin.Substring(0, 3); // Default password: first three characters of SIN
            IsAuthenticated = false;
        }
        public void Login(string passwordInput)
        {
            if (passwordInput != password)
            {
                IsAuthenticated = false;
                OnLogin?.Invoke(this, new LoginEventArgs(Name, false));
                throw new AccountException(ExceptionType.PASSWORD_INCORRECT);
            }

            IsAuthenticated = true;
            OnLogin?.Invoke(this, new LoginEventArgs(Name, true));
        }

        public void Logout()
        {
            IsAuthenticated = false;
        }

        public override string ToString()
        {
            return $"{Name}, Authenticated: {IsAuthenticated}";
        }
    }
}
