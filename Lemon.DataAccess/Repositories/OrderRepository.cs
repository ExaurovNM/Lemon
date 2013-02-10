namespace Lemon.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Lemon.DataAccess.Context;
    using Lemon.DataAccess.DomainModels;

    public class OrderRepository : IOrderRepository
    {
        public void Create(Order order)
        {
            using (var context = new DataBaseContext())
            {
                order.CreatedTime = DateTime.UtcNow;
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }

        public List<Order> Items()
        {
            using (var context = new DataBaseContext())
            {
                return context.Orders.Include("Account").Include("OrderComments").ToList();
            }
        }

        public Order GetById(int id)
        {
            using (var context = new DataBaseContext())
            {
                return context.Orders.Include("Account").Include("OrderComments").FirstOrDefault(order => order.Id == id);
            }
        }

        public void AddCommentToOrder(OrderComment orderComment)
        {
            using (var context = new DataBaseContext())
            {
                orderComment.CreatedTime = DateTime.UtcNow;
                context.OrderComments.Add(orderComment);
                context.SaveChanges();
            }   
        }
    }
}