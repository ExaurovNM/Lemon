namespace Lemon.WebApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Lemon.DataAccess.DomainModels;
    using Lemon.DataAccess.Repositories;

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IOrderCommentRepository orderCommentRepository;
        private readonly IUserEventsService eventsService;

        public OrderService(
            IOrderRepository orderRepository,
            IOrderCommentRepository orderCommentRepository,
            IUserEventsService eventsService)
        {
            this.orderRepository = orderRepository;
            this.orderCommentRepository = orderCommentRepository;
            this.eventsService = eventsService;
        }

        public void Create(Order order)
        {
            this.orderRepository.Create(order);
            this.eventsService.AddEvent(order);
        }

        public List<Order> Items()
        {
            return this.orderRepository.Items();
        }

        public Order GetById(int id)
        {
            return this.orderRepository.GetById(id);
        }

        public void AddCommentToOrder(OrderComment orderComment)
        {
            this.orderCommentRepository.AddCommentToOrder(orderComment);
            var order = orderRepository.GetById(orderComment.OrderId);
            this.eventsService.AddEvent(orderComment, order.CreaterId);
        }

        public List<Order> GetByUserId(int id)
        {
            return orderRepository.GetByUserId(id);
        }

        public void ChangeOrderStatus(int orderId, int newStatus)
        {
            if (orderRepository.GetById(orderId) != null)
            {
                orderRepository.ChangeOrderStatus(orderId, newStatus);
            }
        }

        public void AcceptOffer(int orderId, int employeeId)
        {
            this.ChangeOrderStatus(orderId, OrderStatus.InProgress);
            this.ChangeOrderEmployee(orderId, employeeId);
        }

        public void ChangeOrderEmployee(int orderId, int employeeId)
        {
            orderRepository.ChangeOrderEmployee(orderId, employeeId);
        }

        public bool IsCanComment(int userId, int orderId)
        {
            var order = orderRepository.GetById(orderId);
            if (order == null)
            {
                return false;
            }

            if (order.CreaterId == userId)
            {
                return false;
            }

            return order.OrderComments.All(comment => comment.AuthorId != userId);
        }

        public List<Order> GetBySearchString(string searchString, int pageSize, int pageNumber)
        {
            var takeCount = pageSize;
            var skipCount = (pageNumber - 1) * pageSize;

            if (string.IsNullOrWhiteSpace(searchString))
            {
                return orderRepository.GetByStatusId(OrderStatus.Openned, takeCount, skipCount).ToList();
            }
            var keyWords = searchString.Split(' ', ',', '.').Where(word => word != null);
            return this.orderRepository.GetByKeyWords(keyWords, OrderStatus.Openned, takeCount, skipCount);
        }
    }
}