namespace projekt_workshop.oop_workshop.Domain.Media
{
    public class Image : Media
    {
        public string Resolution { get; set; }
        public string Format { get; set; }
        public int FileSize { get; set; }
        public DateTime DateTaken { get; set; }
    
        public Image(
            string title,
            string language,
            string resolution,
            string format,
            int fileSize,
            DateTime dateTaken
        ) : base(title, language)
        {
            Resolution = resolution;
            Format = format;
            FileSize = fileSize;
            DateTaken = dateTaken;
        }
    
        public override void Action()
        {
            Display();
        }
    
        public void Display()
        {
            Console.WriteLine($"Displaying image: {Title}");
            Console.WriteLine($"Resolution: {Resolution}");
            Console.WriteLine($"Format: {Format}");
            Console.WriteLine($"Size: {FileSize} MB");
            Console.WriteLine($"Date Taken: {DateTaken.ToShortDateString()}");
        }
    }
}