using Lemon.DataAccess.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lemon.WebApp.Models
{
    public class MessageViewModel
    {
        public int recieverId { get; set; }
        public string senderEmail { get; set; }
        public string recieverEmail { get; set; }
        public List<Message> Messages { get; set; }
        public MessageViewModel(List<Message> messages,int id,string senderEmail,string recieverEmail)
        {
            this.Messages = messages;
            this.recieverId = id;
            this.senderEmail = senderEmail;
            this.recieverEmail = recieverEmail;
        }
    }
}