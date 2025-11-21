using System;
namespace projekt_workshop.oop_workshop.Domain.Users
{
    public abstract class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string SSN { get; set; }
    
        protected User(string name, int age, string ssn)
        {
            Name = name;
            Age = age;
            SSN = ssn;
        }

        public void GetRoles()
        {
            
        }
        public abstract string GetRole();
    }
}