namespace Lemon.DataAccess.DomainModels
{
    public class UserRating : BaseEntity
    {
        public int RatingSenderId { get; set; }

        public int RatingReceiverId { get; set; }

        public bool Rating { get; set; }

        public string Comment { get; set; }
    }
}
