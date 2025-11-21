using System;
using System.Collections.Generic;
using projekt_workshop.oop_workshop.Domain.Media;
using MediaItem = projekt_workshop.oop_workshop.Domain.Media.Media;

namespace projekt_workshop.oop_workshop.Domain.Users
{
    public class Borrower : User
    {
        public List<MediaItem> BorrowedItems { get; private set; }

        public Borrower(string name, int age, string ssn)
            : base(name, age, ssn)
        {
            BorrowedItems = new List<MediaItem>();
        }

        public override string GetRole()
        {
            return "Borrower";
        }

        public void ListMedia(List<MediaItem> media)
        {
            foreach (var m in media)
            {
                Console.WriteLine($"- {m.Title}");
            }
        }

        public void ViewDetails(MediaItem media)
        {
            media.Preview();
        }

        public void BorrowMedia(MediaItem media)
        {
            BorrowedItems.Add(media);
            Console.WriteLine($"{Name} borrowed {media.Title}");
        }

        public void RateMedia(MediaItem media, int rating)
        {
            if (!BorrowedItems.Contains(media))
            {
                Console.WriteLine("You can only rate items you borrowed.");
                return;
            }

            media.AddRating(new Rating(rating, this));
            Console.WriteLine($"Rated {media.Title} with {rating}.");
        }

        public void PerformAction(MediaItem media)
        {
            media.Action();
        }
    }
}