namespace Lemon.WebApp.Services
{
    using System.Collections.Generic;

    using Lemon.DataAccess.DomainModels;
    using Lemon.DataAccess.Repositories;
    using Lemon.WebApp.Controllers;

    public interface IOrderService
    {
        void Create(Order order);

        List<Order> Items();
    }

    class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public void Create(Order order)
        {
            orderRepository.Create(order);
        }

        public List<Order> Items()
        {
            return orderRepository.Items();
        }
    }
}
