namespace Lemon.DataAccess.DomainModels
{
    public class UserEvent : BaseEntity
    {
        public int EventSunscriberId { get; set; }

        public string Description { get; set; }

        public int EventType { get; set; }

        public int OrderId { get; set; }

        public int CommentId { get; set; }

        public int EventPublisherId { get; set; }
    }
}
