﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfilAbstract
{
    public class Profil
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; }

        public Profil(string name,
                    string surname,
                    int age,
                    string email,
                    string password,
                    UserRole Userrole)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Email = email;
            Password = password;
            UserRole = Userrole;
        }
    }
}
