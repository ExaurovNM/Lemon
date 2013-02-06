namespace Lemon.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Lemon.DataAccess.Context;
    using Lemon.DataAccess.DomainModels;

    public interface IOrderRepository
    {
        void Create(Order order);

        List<Order> Items();
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

        public List<Order> Items()
        {
            using (var context = new DataBaseContext())
            {
                return context.Orders.Include("Account").ToList();
            }

        }
    }
}
