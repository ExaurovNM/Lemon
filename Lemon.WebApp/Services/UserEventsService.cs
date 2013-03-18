namespace Lemon.WebApp.Services
{
    using System.Collections.Generic;

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
                    EventSunscriberId = order.CreaterId,
                    EventPublisherId = order.CreaterId,
                    EventType = UserEventType.OrderEvent
                };
            this.Save(userEvent);
        }

        public void AddEvent(OrderComment orderComment, int accountId)
        {
            var orderOwnerEvent = new UserEvent
            {
                Description = orderComment.Comment,
                OrderId = orderComment.OrderId,
                EventSunscriberId = accountId,
                EventPublisherId = orderComment.AuthorId,
                EventType = UserEventType.NewCommentTOwnedOrderEvent,
                CommentId = orderComment.Id
            };

            var orderEmployeeEvent = new UserEvent
            {
                Description = orderComment.Comment,
                OrderId = orderComment.OrderId,
                EventSunscriberId = orderComment.AuthorId,
                EventPublisherId = orderComment.AuthorId,
                EventType = UserEventType.NewCommentToOrderByEmployeeEvent,
                CommentId = orderComment.Id
            };

            this.Save(orderOwnerEvent);
            this.Save(orderEmployeeEvent);
        }

        public IList<UserEvent> GetByUserId(int userId)
        {
            return this.userEventsRepository.GetByUserId(userId);
        }

        private void Save(UserEvent userEvent)
        {
            this.userEventsRepository.Save(userEvent);
        }
    }
}
