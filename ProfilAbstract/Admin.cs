using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfilAbstract
{
    public class Admin : UserController
    {
        public override void AddUser(Profil Users)
        {
            User.Add(Users);
        }

        public void AddNewUsers(string name,
                                string surname,
                                int age,
                                string Email,
                                string password,
                                UserRole userRole)
        {
            Profil newUser = new Profil
                    (
                        name = name,
                        surname = surname,
                        age = age,
                        Email = Email,
                        password = password,
                        UserRole.User
                    );

            User.Add(newUser);
        }

        public void DeleteUser(int ID)
        {
            User.RemoveAt(ID);
            Console.Clear();
            Console.WriteLine("User has succesfully deleted!");
            bool valid = false;
            int counter = 1;
            foreach (Profil notDeleted in User)
            {

                if (notDeleted.UserRole == UserRole.User)
                {
                    valid = true;
                    Console.WriteLine($"\nUser's info:\n" +
                                          $"User ID: {counter++},\n" +
                                          $"Name: {notDeleted.Name},\n" +
                                          $"Surname: {notDeleted.Surname},\n" +
                                          $"Age: {notDeleted.Age},\n" +
                                          $"Email: {notDeleted.Email},\n" +
                                          $"Role: {notDeleted.UserRole}");
                }

            }
            if (valid)
            {
                return;
            }

        }

        public void UpdatedUser(int ID, string name, string surname, int age, string email, string password, UserRole userRole)
        {
            Profil newUser = new Profil
                 (
                     name = name,
                     surname = surname,
                     age = age,
                     email = email,
                     password = password,
                     UserRole.User
                 );

            User[ID] = newUser;
            Console.Clear();
            Console.WriteLine("User has succesfully updated!");
            bool valid = false;
            int counter = 1;
            foreach (Profil notDeleted in User)
            {

                if (notDeleted.UserRole == UserRole.User)
                {
                    valid = true;
                    Console.WriteLine($"\nUser's info:\n" +
                                          $"User ID: {counter++},\n" +
                                          $"Name: {notDeleted.Name},\n" +
                                          $"Surname: {notDeleted.Surname},\n" +
                                          $"Age: {notDeleted.Age},\n" +
                                          $"Email: {notDeleted.Email},\n" +
                                          $"Role: {notDeleted.UserRole}");
                }

            }
            if (valid)
            {
                return;
            }

        }
    }
}
