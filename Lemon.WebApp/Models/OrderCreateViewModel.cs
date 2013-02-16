namespace Lemon.WebApp.Models
{
    using Lemon.DataAccess.DomainModels;

    public class OrderCreateViewModel
    {
        public int UserId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public decimal ProbableCost { get; set; }

        public Order GetDomain()
        {
            return new Order
                {
                    AccountId = UserId,
                    Content = Content,
                    Title = Title,
                    ProbableCost = ProbableCost
                };
        }
    }
}