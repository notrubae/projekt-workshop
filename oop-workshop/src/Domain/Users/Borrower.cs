using System;
using System.Collections.Generic;
using projekt_workshop.oop_workshop.Domain.Media;

namespace projekt_workshop.oop_workshop.Domain.Users
{
    public class Borrower : User
    {
        public List<Media.Media> BorrowedItems { get; private set; }
    
        public Borrower(string name, int age, string ssn)
            : base(name, age, ssn)
        {
            BorrowedItems = new List<Media.Media>();
        }
    
        public override string GetRole()
        {
            return "Borrower";
        }
    
        public void ListMedia(List<Media.Media> media)
        {
            foreach (var m in media)
            {
                Console.WriteLine($"- {m.Title}");
            }
        }
    
        public void ViewDetails(Media.Media media)
        {
            media.Preview();
        }
    
        public void BorrowMedia(Media.Media media)
        {
            BorrowedItems.Add(media);
            Console.WriteLine($"{Name} borrowed {media.Title}");
        }
        // return
    
        public void RateMedia(Media.Media media, int value)
        {
            if (!BorrowedItems.Contains(media))
            {
                Console.WriteLine("You can only rate items you borrowed.");
                return;
            }

            Rating rating = new Rating(value, media);
            
            media.AddRating(rating);
            Console.WriteLine($"Rated {media.Title} with {rating}.");
        }
    
        public void PerformAction(Media.Media media)
        {
            media.Action();
        }
    }
}