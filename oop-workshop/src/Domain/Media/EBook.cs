namespace projekt_workshop.oop_workshop.Domain.Media
{
    public class EBook : Media
    {
        public string Author { get; set; }
        public int Pages { get; set; }
        public int Year { get; set; }
        public string ISBN { get; set; }
    
        public EBook(
            string title,
            string language,
            string author,
            int pages,
            int year,
            string isbn
        ) : base(title, language)
        {
            Author = author;
            Pages = pages;
            Year = year;
            ISBN = isbn;
        }
    
        public override void Action()
        {
            Read();
        }
    
        public void Read()
        {
            Console.WriteLine($"Reading e-book: {Title} by {Author}");
            Console.WriteLine($"Year: {Year} | Pages: {Pages} | ISBN: {ISBN}");
        }
    }
}