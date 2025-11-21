using projekt_workshop.oop_workshop.Domain.Users;

namespace projekt_workshop.oop_workshop.Domain.Media
{
    public class Rating
    {
        public int Score { get; set; }
        public User RatedBy { get; set; }

        public Rating(int score, User ratedBy)
        {
            Score = score;
            RatedBy = ratedBy;
        }
    }
}
