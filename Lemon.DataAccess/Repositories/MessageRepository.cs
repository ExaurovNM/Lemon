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
        public List<Message> GetBySenderIdAndRecieverId(int senderId, int recieverId)
        {
            using (var context=new DataBaseContext())
            {
                
                return
                    context.Messages
                    .Include(message => message.Reciver)
                    .Include(message => message.Sender)
                    .Where(message => (message.SenderId == senderId && message.ReciverId == recieverId)).ToList();
                
            }
        }
        public List<Message> GetBySenderId(int senderId)
        {
            using (var context = new DataBaseContext())
            {
                return 
                    context.Messages
                    .Include(message => message.Reciver)
                    .Include(message => message.Sender)
                    .Where(message => (message.SenderId == senderId))
                    .ToList();
            }
        }

        public List<Message> GetByRecieverId(int recieverId)
        {
            using (var context = new DataBaseContext())
            {
                return
                    context.Messages
                    .Include(message => message.Reciver)
                    .Include(message => message.Sender)
                    .Where(message => (message.ReciverId == recieverId)).ToList();
            }
        }
 
    }
}