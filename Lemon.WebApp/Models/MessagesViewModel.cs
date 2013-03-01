using Lemon.DataAccess.DomainModels;

using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lemon.WebApp.Models
{
    public class MessagesViewModel
    {
        public int recieverId { get; set; }
        public string senderEmail { get; set; }
        public string recieverEmail { get; set; }
        public List<MessageViewModel> Messages { get; set; }

        public MessagesViewModel(List<Message> messages,int id,string senderEmail,string recieverEmail)
        {
            this.Messages = messages.Select(message => new MessageViewModel(message)).ToList();
            this.recieverId = id;
            this.senderEmail = senderEmail;
            this.recieverEmail = recieverEmail;
        }
    }
}