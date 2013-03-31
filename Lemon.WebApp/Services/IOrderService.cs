namespace Lemon.WebApp.Services
{
    using System.Collections.Generic;

    using Lemon.DataAccess.DomainModels;

    public interface IOrderService
    {
        void Create(Order order);

        List<Order> Items();

        Order GetById(int id);

        bool AddCommentToOrder(OrderComment orderComment);

        List<Order> GetByUserId(int id);

        void ChangeOrderStatus(int orderId, int newStatus);

        void AcceptOffer(int orderId, int employeeId);

        void ChangeOrderEmployee(int orderId, int employeeId);

        bool IsCanComment(int userId, int orderId);

        List<Order> GetBySearchString(string searchString, int pageSize, int pageNumber);
    }
}
