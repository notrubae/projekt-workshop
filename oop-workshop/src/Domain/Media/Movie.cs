using System;
using System.Collections.Generic;   
namespace projekt_workshop.oop_workshop.Domain.Media
{
    public class Movie : Media
    {
        public int ReleaseYear { get; set; }
        public List<string> Hosts { get; set; }
        public List<string> Guests { get; set; }
        public int EpisodeNumber { get; set; }
    
        public Movie(
            string title,
            string language,
            int releaseYear,
            List<string> hosts,
            List<string> guests,
            int episodeNumber
        ) : base(title, language)
        {
            ReleaseYear = releaseYear;
            Hosts = hosts;
            Guests = guests;
            EpisodeNumber = episodeNumber;
        }
    
        public override void Action()
        {
            Listen();
        }
    
        public void Listen()
        {
            Console.WriteLine($"Listening to podcast: {Title}");
            Console.WriteLine($"Episode: {EpisodeNumber}");
            Console.WriteLine($"Year: {ReleaseYear}");
            Console.WriteLine($"Hosts: {string.Join(", ", Hosts)}");
            Console.WriteLine($"Guests: {string.Join(", ", Guests)}");
        }
    
        public void Complete()
        {
            Console.WriteLine($"Completed podcast episode {EpisodeNumber} of {Title}");
        }
    }
}