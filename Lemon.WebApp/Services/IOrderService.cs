namespace Lemon.WebApp.Services
{
    using Lemon.DataAccess.DomainModels;
    using Lemon.DataAccess.Repositories;

    public interface IOrderService
    {
        void Create(Order order);
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
    }
}
