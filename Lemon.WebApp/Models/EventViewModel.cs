namespace Lemon.WebApp.Models
{
    using System;

    using Lemon.DataAccess.DomainModels;

    public class EventViewModel
    {
        public EventViewModel(UserEvent evend)
        {
            this.Description = evend.Description;
            this.EventPublisherId = evend.EventPublisherId;
            this.EventType = evend.EventType;
            this.EventPublisherName = evend.EventPublisher.Email;
            this.Time = evend.CreatedTime;
        }

        public DateTime Time { get; set; }

        public string EventPublisherName { get; set; }

        public int EventType { get; set; }

        public int EventPublisherId { get; set; }

        public string Description { get; set; }
    }
}