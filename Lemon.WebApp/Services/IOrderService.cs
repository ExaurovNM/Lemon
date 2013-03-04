namespace Lemon.WebApp.Services
{
    using System.Collections.Generic;

    using Lemon.DataAccess.DomainModels;

    public interface IOrderService
    {
        void Create(Order order);

        List<Order> Items();

        Order GetById(int id);

        void AddCommentToOrder(OrderComment orderComment);

        List<Order> GetByUserId(int id);

        void ChangeOrderStatus(int orderId, int newStatus);

        void CloseOrder(int orderId);
    }
}
