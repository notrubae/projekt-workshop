using projekt_workshop.oop_workshop.Domain.Users;

namespace projekt_workshop.oop_workshop.Domain.Media
{
    public class Rating
    {
        int value;
        Media media;

        public Rating(int value, Media media)
        {
            this.value = value;
            this.media = media;
        }
    }
}