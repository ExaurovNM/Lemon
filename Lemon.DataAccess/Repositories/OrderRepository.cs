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
                order.Status = OrderStatus.Openned;
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }

        public List<Order> Items()
        {
            using (var context = new DataBaseContext())
            {
                return context.Orders.Include("Creater").Include("OrderComments").OrderByDescending(order => order.CreatedTime).ToList();
            }
        }

        public Order GetById(int id)
        {
            using (var context = new DataBaseContext())
            {
                return context.Orders
                    .Include("Creater")
                    .Include("OrderComments")
                    .Include("OrderComments.Author")
                    .FirstOrDefault(order => order.Id == id);
            }
        }

        public List<Order> GetByUserId(int id)
        {
            using (var context = new DataBaseContext())
            {
                return context.Orders.Include("Creater").Include("OrderComments.Author").Where(order => order.CreaterId == id).ToList();
            }
        }

        public void ChangeOrderStatus(int orderId, int newStatus)
        {
            using (var context = new DataBaseContext())
            {
                context.Orders.FirstOrDefault(order => order.Id == orderId).Status = newStatus;
                context.SaveChanges();
            }
        }

        public List<Order> GetByStatusId(int statusId, int takeCount, int skipCount)
        {
            using (var context = new DataBaseContext())
            {
                return
                    context.Orders.Include("Creater")
                           .Include("OrderComments.Author")
                           .Where(ord => ord.Status == statusId)
                           .OrderByDescending(order => order.CreatedTime)
                           .Skip(skipCount)
                           .Take(takeCount)
                           .ToList();
            }
        }

        public void ChangeOrderEmployee(int orderId, int? employeeId)
        {
            using (var context = new DataBaseContext())
            {
                context.Orders.FirstOrDefault(order => order.Id == orderId).EmployeeId = employeeId;
                context.SaveChanges();
            }
        }

        public List<Order> GetByKeyWords(IEnumerable<string> keyWords, int orderStatus, int takeCount, int skipCount)
        {
            using (var context = new DataBaseContext())
            {
                return
                    context
                    .Orders
                    .Include("Creater")
                    .Include("OrderComments")
                    .Include("OrderComments.Author")
                    .Where(order => order.Status == orderStatus)
                    .Where(order =>
                            keyWords.Any(
                                keyWord =>
                                order.Title.ToLower().Contains(keyWord.ToLower())
                                || order.Content.Contains(keyWord.ToLower()))).OrderByDescending(
                                    order => order.CreatedTime).Skip(skipCount).Take(takeCount).ToList();
            }
        }
    }
}