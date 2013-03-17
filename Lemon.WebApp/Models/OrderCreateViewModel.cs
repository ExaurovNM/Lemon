namespace Lemon.WebApp.Models
{
    using System.ComponentModel.DataAnnotations;

    using Lemon.DataAccess.DomainModels;

    public class OrderCreateViewModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = " ¬ведите заголовок.")]
        public string Title { get; set; }

        [Required(ErrorMessage = " ¬ведите описание.")]
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