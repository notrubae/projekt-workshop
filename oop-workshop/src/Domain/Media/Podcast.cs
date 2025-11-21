using System;
using System.Collections.Generic;

namespace projekt_workshop.oop_workshop.Domain.Media
{
   public class Podcast : Media
   {
       public int ReleaseYear { get; set; }
       public List<string> Hosts { get; set; }
       public List<string> Guests { get; set; }
       public int EpisodeNumber { get; set; }
   
       public Podcast(
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
           Console.WriteLine($"Release year: {ReleaseYear}");
   
           Console.WriteLine("Hosts:");
           foreach (var h in Hosts)
               Console.WriteLine($"- {h}");
   
           Console.WriteLine("Guests:");
           foreach (var g in Guests)
               Console.WriteLine($"- {g}");
       }
   
       public void Complete()
       {
           Console.WriteLine($"Completed episode {EpisodeNumber} of {Title}");
       }
   }
}