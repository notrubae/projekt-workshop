namespace projekt_workshop.oop_workshop.Domain.Media
{
    public class App : Media
    {
        public string Version { get; set; }
        public string Publisher { get; set; }
        public List<string> Platforms { get; set; }
        public int FileSize { get; set; }
    
        public App(
            string title,
            string language,
            string version,
            string publisher,
            List<string> platforms,
            int fileSize
        ) : base(title, language)
        {
            Version = version;
            Publisher = publisher;
            Platforms = platforms;
            FileSize = fileSize;
        }
    
        public override void Action()
        {
            Execute();
        }
    
        public void Execute()
        {
            Console.WriteLine($"Launching app: {Title} (v{Version})");
        }
    }
}