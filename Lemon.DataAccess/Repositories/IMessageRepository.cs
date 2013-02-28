using Lemon.DataAccess.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemon.DataAccess.Repositories
{
    public interface IMessageRepository
    {
        void AddMessage(Message message);
        List<Message> GetById(int senderId, int recieverId);
        List<Message> GetBySenderId(int userId);
        List<Message> GetByRecieverId(int userId);
    }
}
