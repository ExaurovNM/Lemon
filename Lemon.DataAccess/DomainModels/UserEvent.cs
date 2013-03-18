namespace Lemon.DataAccess.DomainModels
{
    public class UserEvent : BaseEntity
    {
        public Account EventSunscriber { get; set; }

        public int EventSunscriberId { get; set; }

        public Account EventPublisher { get; set; }

        public int EventPublisherId { get; set; }

        public string Description { get; set; }

        public int EventType { get; set; }

        public int? OrderId { get; set; }

        public int? CommentId { get; set; }
    }
}
