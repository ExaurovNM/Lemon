using System;
namespace Lemon.DataAccess.DomainModels
{
    public class Message : BaseEntity
    {
        public string Text { get; set; }

        public int SenderId { get; set;  }

        public int ReciverId { get; set; }

        public Message()
        {
            
        }
        public Message(int senderId, int recieverId, string Text)
        {
            this.ReciverId = recieverId;
            this.SenderId = senderId;
            this.Text = Text;
        }
    }
}
