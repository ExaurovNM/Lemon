using System.Data.Entity;

namespace Lemon.DataAccess.Repositories
{
    using System;

    using Lemon.DataAccess.Context;
    using Lemon.DataAccess.DomainModels;
using System.Collections.Generic;
    using System.Linq;

    public class MessageRepository : IMessageRepository
    {
        public void AddMessage(Message message)
        {
            using (var context = new DataBaseContext())
            {
                message.CreatedTime = DateTime.UtcNow;
                context.Messages.Add(message);
                context.SaveChanges();
            }
        }
        public List<Message> GetById(int senderId, int recieverId)
        {
            using (var context=new DataBaseContext())
            {
                
                return
                    context.Messages.Where(message => (message.SenderId == senderId && message.ReciverId == recieverId)).ToList();
                
            }
        }
 
    }
}