namespace Lemon.WebApp.Services
{
    using Lemon.DataAccess.DomainModels;
    using Lemon.DataAccess.Repositories;

    public class UserEventsService : IUserEventsService
    {
        private readonly IUserEventsRepository userEventsRepository;

        public UserEventsService(IUserEventsRepository userEventsRepository)
        {
            this.userEventsRepository = userEventsRepository;
        }

        public void AddEvent(Order order)
        {
            var userEvent = new UserEvent
                {
                    Description = order.Title,
                    OrderId = order.Id,
                    EventSunscriberId = order.AccountId,
                    EventType = UserEventType.OrderEvent
                };
            this.Save(userEvent);
        }

        public void AddEvent(OrderComment orderComment, int accountId)
        {
            var userEvent = new UserEvent
            {
                Description = orderComment.Comment,
                OrderId = orderComment.OrderId,
                EventSunscriberId = accountId,
                EventPublisherId = orderComment.AuthorId,
                EventType = UserEventType.CommentEvent,
                CommentId = orderComment.Id
            };
            this.Save(userEvent);
        }

        private void Save(UserEvent userEvent)
        {
            this.userEventsRepository.Save(userEvent);
        }
    }
}
