namespace Lemon.DataAccess.Repositories
{
    using System;

    using Lemon.DataAccess.Context;
    using Lemon.DataAccess.DomainModels;

    public interface IOrderRepository
    {
        void Create(Order order);
    }

    public class OrderRepository : IOrderRepository
    {
        public void Create(Order order)
        {
            using (var context = new DataBaseContext())
            {
                order.CretedTime = DateTime.UtcNow;
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }
    }
}
