using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_protection_3
{
    public class User
    {
        public User() { }
        public User(string login, string password, string key, double value, double delta)
        {
            Login = login;
            Password = password;
            Key = key;
            Value = value;
            Delta = delta;
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public string Key { get; set; }
        public double Value { get; set; }
        public double Delta { get; set; }
    }
}
