namespace Lemon.WebApp.Services
{
    using System.Collections.Generic;

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
    }
}