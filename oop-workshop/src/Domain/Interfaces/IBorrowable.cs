using MediaItem = projekt_workshop.oop_workshop.Domain.Media.Media;

namespace projekt_workshop.oop_workshop.Domain.Interfaces
{
    public interface IBorrowable
    {
        void BorrowMedia(MediaItem media);
    }
}