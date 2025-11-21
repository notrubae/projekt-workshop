using projekt_workshop.oop_workshop.Domain.Media;
using MediaItem = projekt_workshop.oop_workshop.Domain.Media.Media;

namespace projekt_workshop.oop_workshop.Domain.Interfaces
{
    public interface IMediaManagement
    {
        void AddMedia(MediaCollection collection, MediaItem media);
        void RemoveMedia(MediaCollection collection, MediaItem media);
    }
}