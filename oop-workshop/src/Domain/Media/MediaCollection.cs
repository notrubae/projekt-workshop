using System;
using System.Collections.Generic;

namespace projekt_workshop.oop_workshop.Domain.Media
{
    public class MediaCollection
    {
        private List<Media> mediaList;

        public MediaCollection()
        {
            mediaList = new List<Media>();
        }

        public void AddMedia(Media media)
        {
            mediaList.Add(media);
            Console.WriteLine($"Added media: {media.Title}");
        }

        public void RemoveMedia(Media media)
        {
            mediaList.Remove(media);
            Console.WriteLine($"Removed media: {media.Title}");
        }

        public void ListAllMedia()
        {
            Console.WriteLine("\n--- All Media ---");
            if (mediaList.Count == 0)
            {
                Console.WriteLine("No media available.");
                return;
            }

            foreach (Media m in mediaList)
            {
                Console.WriteLine($"- {m.Title} ({m.Language})");
            }
        }

        public Media FindMedia(string title)
        {
            foreach (Media m in mediaList)
            {
                if (m.Title.ToLower() == title.ToLower())
                {
                    return m;
                }
            }
            Console.WriteLine($"Media '{title}' not found.");
            return null;
        }
    }
}
