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

        public OrderService(IOrderRepository orderRepository, IOrderCommentRepository orderCommentRepository)
        {
            this.orderRepository = orderRepository;
            this.orderCommentRepository = orderCommentRepository;
        }

        public void Create(Order order)
        {
            this.orderRepository.Create(order);
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

        public List<Order> GetByStatusId(int statusId)
        {
            return this.orderRepository.GetByStatusId(statusId);
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

            if (order.AccountId == userId)
            {
                return false;
            }

            if (order.OrderComments.Any(comment => comment.AuthorId == userId))
            {
                return false;
            }

            return true;
        }
    }
}