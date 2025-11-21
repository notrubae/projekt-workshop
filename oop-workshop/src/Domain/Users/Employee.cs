using System;
using projekt_workshop.oop_workshop.Domain.Media;
using projekt_workshop.oop_workshop.Domain.Interfaces;
using MediaItem = projekt_workshop.oop_workshop.Domain.Media.Media;

namespace projekt_workshop.oop_workshop.Domain.Users
{
    public class Employee : User, IMediaManagement
    {
        public Employee(string name, int age, string ssn)
            : base(name, age, ssn) { }

        public override string GetRole() => "Employee";

        public void AddMedia(MediaCollection collection, MediaItem media)
        {
            collection.AddMedia(media);
            Console.WriteLine($"{media.Title} added.");
        }

        public void RemoveMedia(MediaCollection collection, MediaItem media)
        {
            collection.RemoveMedia(media);
            Console.WriteLine($"{media.Title} removed.");
        }
    }
}