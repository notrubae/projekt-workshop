using System;
using System.Collections.Generic;

namespace projekt_workshop.oop_workshop.Domain.Media
{
    public abstract class Media
    {
        public string Title { get; set; }
        public string Language { get; set; }
        public List<Rating> Ratings { get; private set; }
    
        protected Media(string title, string language)
        {
            Title = title;
            Language = language;
            Ratings = new List<Rating>();
        }
    
        public void Preview()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Language: {Language}");
        }
    
        public void Download()
        {
            Console.WriteLine($"Downloading {Title}...");
        }
    
        public void AddRating(Rating rating)
        {
            Ratings.Add(rating);
        }
    
        public abstract void Action();
    }
}