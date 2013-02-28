using Lemon.DataAccess.DomainModels;
using Lemon.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lemon.WebApp.Services
{
    public interface IMessageService
    {
        void AddMessage(Message message);
        List<Message> GetById(int senderId, int recieverId);
        List<Message> MessagesBetweenUsers(int firstId, int secondId);
        List<Message> LastMessages(int currUserId);
    }
}