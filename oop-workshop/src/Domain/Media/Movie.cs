using System;
using System.Collections.Generic;

namespace projekt_workshop.oop_workshop.Domain.Media
{
    public class Movie : Media
    {
        public string Director { get; set; }
        public List<string> Genres { get; set; }
        public int ReleaseYear { get; set; }
        public int Duration { get; set; } // minutes

        public Movie(
            string title,
            string language,
            string director,
            List<string> genres,
            int releaseYear,
            int duration
        ) : base(title, language)
        {
            Director = director;
            Genres = genres;
            ReleaseYear = releaseYear;
            Duration = duration;
        }

        public override void Action()
        {
            Play();
        }

        public void Play()
        {
            Console.WriteLine($"Playing movie: {Title}");
            Console.WriteLine($"Director: {Director}");
            Console.WriteLine($"Genres: {string.Join(", ", Genres)}");
            Console.WriteLine($"Year: {ReleaseYear}");
            Console.WriteLine($"Duration: {Duration} min");
        }
    }
}