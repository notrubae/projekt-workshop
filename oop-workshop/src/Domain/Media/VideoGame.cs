using System;
using System.Collections.Generic;

namespace projekt_workshop.oop_workshop.Domain.Media
{
    public class VideoGame : Media
    {
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public int ReleaseYear { get; set; }
        public List<string> Platforms { get; set; }
    
        public VideoGame(
            string title,
            string language,
            string genre,
            string publisher,
            int releaseYear,
            List<string> platforms
        ) : base(title, language)
        {
            Genre = genre;
            Publisher = publisher;
            ReleaseYear = releaseYear;
            Platforms = platforms;
        }
    
        public override void Action()
        {
            Play();
        }
    
        public void Play()
        {
            Console.WriteLine($"Playing video game: {Title}");
            Console.WriteLine($"Genre: {Genre}");
            Console.WriteLine($"Publisher: {Publisher}");
            Console.WriteLine($"Release Year: {ReleaseYear}");
            Console.WriteLine($"Platforms: {string.Join(", ", Platforms)}");
        }
    
        public void Complete()
        {
            Console.WriteLine($"Completed video game: {Title}");
        }
    }
}