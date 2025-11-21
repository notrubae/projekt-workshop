namespace projekt_workshop.oop_workshop.Domain.Users
{
    public class Borrower : User
    {
        public List<Media> BorrowedItems { get; private set; }
    
        public Borrower(string name, int age, string ssn)
            : base(name, age, ssn)
        {
            BorrowedItems = new List<Media>();
        }
    
        public override string GetRole()
        {
            return "Borrower";
        }
    
        public void ListMedia(List<Media> media)
        {
            foreach (var m in media)
            {
                Console.WriteLine($"- {m.Title}");
            }
        }
    
        public void ViewDetails(Media media)
        {
            media.Preview();
        }
    
        public void BorrowMedia(Media media)
        {
            BorrowedItems.Add(media);
            Console.WriteLine($"{Name} borrowed {media.Title}");
        }
    
        public void RateMedia(Media media, int rating)
        {
            if (!BorrowedItems.Contains(media))
            {
                Console.WriteLine("You can only rate items you borrowed.");
                return;
            }
    
            media.AddRating(new Rating(rating, this));
            Console.WriteLine($"Rated {media.Title} with {rating}.");
        }
    
        public void PerformAction(Media media)
        {
            media.Action();
        }
    }
}