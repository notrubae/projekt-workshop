using System;
using System.Collections.Generic;
namespace projekt_workshop.oop_workshop.Domain.Users
{
    public class Admin : User
    {
        public Admin(string name, int age, string ssn)
            : base(name, age, ssn)
        {
        }
    
        public override string GetRole()
        {
            return "Admin";
        }
    
        public void CreateUser(List<User> users, User user)
        {
            users.Add(user);
            Console.WriteLine($"User '{user.Name}' created.");
        }
    
        public void UpdateUser(User user, string newName, int newAge, string newSsn)
        {
            user.Name = newName;
            user.Age = newAge;
            user.SSN = newSsn;
    
            Console.WriteLine($"User '{newName}' updated.");
        }
    
        public void DeleteUser(List<User> users, User user)
        {
            users.Remove(user);
            Console.WriteLine($"User '{user.Name}' removed.");
        }
    
        public void ManageUsers(List<User> users)
        {
            Console.WriteLine("User list:");
            foreach (var user in users)
            {
                Console.WriteLine($"{user.GetRole()} - {user.Name} ({user.SSN})");
            }
        }
    }
}