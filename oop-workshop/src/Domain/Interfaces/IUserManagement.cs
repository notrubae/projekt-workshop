using System.Collections.Generic;
using projekt_workshop.oop_workshop.Domain.Users;

namespace projekt_workshop.oop_workshop.Domain.Interfaces
{
    public interface IUserManagement
    {
        void CreateUser(List<User> users, User user);
        void UpdateUser(User user, string newName, int newAge, string newSsn);
        void DeleteUser(List<User> users, User user);
    }
}