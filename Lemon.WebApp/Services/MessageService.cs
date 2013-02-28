using Lemon.DataAccess.DomainModels;
using Lemon.DataAccess.Repositories;
using Lemon.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lemon.WebApp.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository messageRepository;


        public MessageService(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }
        public void AddMessage(Message message)
        {
            messageRepository.AddMessage(message);
        }
        public List<Message> GetById(int senderId, int recieverId)
        {
            return messageRepository.GetById(senderId, recieverId);
        }

        public List<Message> MessagesBetweenUsers(int firstId, int secondId)
        {
            List<Message> listOfMessage = GetById(firstId, secondId);
            listOfMessage.AddRange(GetById(secondId, firstId));
            return listOfMessage.OrderBy(message => message.CreatedTime).ToList();
        }
        public List<Message> LastMessages(int currUserId)
        {
            var firstPart = messageRepository.GetBySenderId(currUserId).Select(message => message.ReciverId).Distinct();
            var secondPart = messageRepository.GetByRecieverId(currUserId).Select(message => message.SenderId).Distinct();
            var allId = firstPart.Union(secondPart);
            List<Message> result = new List<Message>();
            foreach (int id in allId)
            {
                result.Add(this.MessagesBetweenUsers(currUserId, id).Last());
            }
            return result.OrderByDescending(message=>message.CreatedTime).ToList();
        }
    }
}