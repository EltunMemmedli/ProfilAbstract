using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProfilAbstract
{
    public abstract class UserController
    {
        public ArrayList User = new ArrayList();

        public abstract void AddUser(Profil Users);

        public ArrayList GetUser()
        {
            return User;
        }

        public void SignIn(string email, string password)
        {
            bool matchFound = false;


            foreach (Profil users in User)
            {

                if (password == users.Password && email == users.Email)
                {
                    Console.Clear();
                    matchFound = true;
                    Console.WriteLine("Login successful.");


                    Console.WriteLine($"\nWelcome {users.Name}\n\n" +
                                      $"Your info:\n" +
                                      $"Name: {users.Name},\n" +
                                      $"Surname: {users.Surname},\n" +
                                      $"Age: {users.Age},\n" +
                                      $"Email: {users.Email},\n" +
                                      $"Role: {users.UserRole}");
                    break;
                }

            }

        }

        public void SignUp(string name,
                            string surname,
                            int age,
                            string email,
                            string password,
                            UserRole userrole)
        {
            Profil newUser = new Profil(name, surname, age, email, password, userrole);
            User.Add(newUser);
            int counter = 1;
            Console.Clear();



            Console.WriteLine($"\nUser - ID: {counter++}" +
                                $"\nYour info:\n" +
                                $"Name: {newUser.Name},\n" +
                                $"Surname: {newUser.Surname},\n" +
                                $"Age: {newUser.Age},\n" +
                                $"Email: {newUser.Email},\n" +
                                $"Role: {newUser.UserRole}");


        }

        public void UpdateProfil(string password, int propertyID, string newProperty)
        {
            foreach (Profil Property in User)
            {
                if (password == Property.Password)
                {
                    Profil NewUser = Property;

                    if (propertyID == 1) //Name
                    {
                        NewUser.Name = newProperty;
                    }
                    else if (propertyID == 2) //Surname
                    {
                        NewUser.Surname = newProperty;
                    }
                    else if (propertyID == 3) //Age
                    {


                        if (int.TryParse(newProperty, out int NewProperty) && NewProperty > 0)
                        {
                            NewUser.Age = int.Parse(newProperty);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Imvalid syntax!\n");
                            break;
                        }
                    }
                    else if (propertyID == 4) //Email
                    {
                        string pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
                        Regex regex = new Regex(pattern);

                        bool valid = regex.IsMatch(newProperty);
                        if (!(string.IsNullOrEmpty(newProperty)) && valid)
                        {
                            NewUser.Email = newProperty;
                        }
                        else
                        {
                            Console.WriteLine("Invalid email!");
                        }
                    }
                    else if (propertyID == 5) //Password
                    {
                        if (!(string.IsNullOrEmpty(newProperty)))
                        {
                            NewUser.Password = newProperty;
                        }
                        else
                        {
                            Console.WriteLine("Invalid password!");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Can not find!");
                    }
                    NewUser = Property;
                }
            }
        }

    }
}