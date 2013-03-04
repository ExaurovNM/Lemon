using Lemon.DataAccess.DomainModels;

using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lemon.WebApp.Models
{
    public class MessagesViewModel
    {
        public int CorrespondenceId { get; set; }
        public string currentUserEmail { get; set; }
        public string CorrespondenceEmail { get; set; }
        public List<MessageViewModel> Messages { get; set; }

        public MessagesViewModel(List<Message> messages,int id,string senderEmail,string recieverEmail)
        {
            this.Messages = messages.Select(message => new MessageViewModel(message)).ToList();
            this.CorrespondenceId = id;
            this.currentUserEmail = senderEmail;
            this.CorrespondenceEmail = recieverEmail;
        }
    }
}