namespace projekt_workshop.oop_workshop.Domain.Media
{
    public class Song : Media
    {
        public string Composer { get; set; }
        public string Singer { get; set; }
        public string Genre { get; set; }
        public string FileType { get; set; }
        public int Duration { get; set; } // seconds
    
        public Song(
            string title,
            string language,
            string composer,
            string singer,
            string genre,
            string fileType,
            int duration
        ) : base(title, language)
        {
            Composer = composer;
            Singer = singer;
            Genre = genre;
            FileType = fileType;
            Duration = duration;
        }
    
        public override void Action()
        {
            Play();
        }
    
        public void Play()
        {
            Console.WriteLine($"Playing song: {Title}");
            Console.WriteLine($"Composer: {Composer}");
            Console.WriteLine($"Singer: {Singer}");
            Console.WriteLine($"Genre: {Genre}");
            Console.WriteLine($"Duration: {Duration} sec");
        }
    }
}