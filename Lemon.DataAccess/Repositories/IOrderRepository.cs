namespace Lemon.DataAccess.Repositories
{
    using System.Collections.Generic;

    using Lemon.DataAccess.DomainModels;

    public interface IOrderRepository
    {
        void Create(Order order);

        List<Order> Items();

        Order GetById(int id);
    }
}
