namespace Lemon.DataAccess.DomainModels
{
    public class Message : BaseEntity
    {
        public string Text { get; set; }

        public int SenderId { get; set;  }

        public int ReciverId { get; set; }
    }
}
