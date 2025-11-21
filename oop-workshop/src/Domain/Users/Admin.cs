using System;
using System.Collections.Generic;
using projekt_workshop.oop_workshop.Domain.Interfaces;
using projekt_workshop.oop_workshop.Domain.Media;

namespace projekt_workshop.oop_workshop.Domain.Users
{
    public class Admin : Employee, IUserManagement
    {
        public Admin(string name, int age, string ssn)
            : base(name, age, ssn) { }

        public override string GetRole() => "Admin";

        public void ManageUsers(List<User> users)
        {
            Console.WriteLine("\n--- User Management ---");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Update User");
            Console.WriteLine("3. Delete User");
            Console.WriteLine("4. List Users");
            Console.Write("Choose: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter age: ");
                    int age = int.Parse(Console.ReadLine());
                    Console.Write("Enter SSN: ");
                    string ssn = Console.ReadLine();
                    User newUser = new Borrower(name, age, ssn);
                    CreateUser(users, newUser);
                    break;

                case "2":
                    Console.WriteLine("Update functionality not fully implemented.");
                    break;

                case "3":
                    Console.WriteLine("Delete functionality not fully implemented.");
                    break;

                case "4":
                    Console.WriteLine("\n--- All Users ---");
                    foreach (User u in users)
                    {
                        Console.WriteLine($"- {u.Name} ({u.GetRole()})");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        public void CreateUser(List<User> users, User user)
        {
            users.Add(user);
            Console.WriteLine($"User {user.Name} created.");
        }

        public void UpdateUser(User user, string newName, int newAge, string newSsn)
        {
            user.Name = newName;
            user.Age = newAge;
            user.SSN = newSsn;
            Console.WriteLine($"User {newName} updated.");
        }

        public void DeleteUser(List<User> users, User user)
        {
            users.Remove(user);
            Console.WriteLine($"User {user.Name} deleted.");
        }
    }
}