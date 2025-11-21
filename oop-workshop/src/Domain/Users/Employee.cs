namespace projekt_workshop.oop_workshop.Domain.Users
{
    namespace DefaultNamespace;
    
    public class Employee : User
    {
        public Employee(string name, int age, string ssn)
            : base(name, age, ssn)
        {
        }
    
        public override string GetRole()
        {
            return "Employee";
        }
    
        public void AddMedia(MediaCollection collection, Media media)
        {
            collection.AddMedia(media);
            Console.WriteLine($"{media.Title} added to collection.");
        }
    
        public void RemoveMedia(MediaCollection collection, Media media)
        {
            collection.RemoveMedia(media);
            Console.WriteLine($"{media.Title} removed from collection.");
        }
    }
}