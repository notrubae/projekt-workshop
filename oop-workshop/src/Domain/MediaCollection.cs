using System;
using System.Collections.Generic;

namespace projekt_workshop.oop_workshop.Domain
{
    public class MediaCollection
    {
        public List<Media.Media> MediaItems {get; set;}
        
        public MediaCollection()
        {
            MediaItems = new List<Media.Media>();
        }

        public void AddMedia(Media.Media media)
        {
            MediaItems.Add(media);
        }

        public void RemoveMedia(Media.Media media)
        {
            MediaItems.Remove(media);
        }
        
        public void ListMedia()
        {
            ;
            foreach (Media.Media media in MediaItems)
            {
                Console.WriteLine(media.Title);
            }
        }

        public Media.Media FindMedia(string title)
        {

            return MediaItems[MediaItems.FindIndex(mediaItem => mediaItem.Title == title)];
        }
        
    }
}