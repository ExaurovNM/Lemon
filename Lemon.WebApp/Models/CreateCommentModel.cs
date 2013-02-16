namespace Lemon.WebApp.Models
{
    using System.ComponentModel.DataAnnotations;

    using Lemon.DataAccess.DomainModels;

    public class CreateCommentModel
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = " Введите комментарий.")]
        [Display(Name = "Комментарий")]
        public string Comment { get; set; }

        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Введите цену")]
        public decimal ProposedCost { get; set; }

        public OrderComment ConvertToDomain()
        {
            return new OrderComment
                {
                    OrderId = this.OrderId,
                    Comment = this.Comment,
                    ProposedCost = this.ProposedCost
                };
        }
    }
}