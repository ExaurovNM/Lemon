namespace Lemon.DataAccess.DomainModels
{
    public class Order : BaseEntity
    {
        public virtual Account Account { get; set; }

        public int AccountId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}