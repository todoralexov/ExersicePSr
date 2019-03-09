using System;
using System.Linq;

namespace UserLogin
{
    class User
    {
        public String Username;
        public String Password;
        public String FakNum;
        public Int32 Role;
        public DateTime Created;
        public DateTime Active;

        public User() { }

        public User(String name, String pass, String num, Int32 role, DateTime created, DateTime active)
        {
            Username = name;
            Password = pass;
            FakNum = num;
            Role = role;
            Created = created;
            Active = active;
        }
    }
}