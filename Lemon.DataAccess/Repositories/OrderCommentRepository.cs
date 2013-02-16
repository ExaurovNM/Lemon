namespace Lemon.DataAccess.Repositories
{
    using System;

    using Lemon.DataAccess.Context;
    using Lemon.DataAccess.DomainModels;

    public class OrderCommentRepository : IOrderCommentRepository
    {
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