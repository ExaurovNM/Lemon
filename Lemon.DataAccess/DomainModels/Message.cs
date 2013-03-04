using System;
namespace Lemon.DataAccess.DomainModels
{
    public class Message : BaseEntity
    {
        public Message()
        {

        }

        public Message(int senderId, int recieverId, string text)
        {
            this.ReciverId = recieverId;
            this.SenderId = senderId;
            this.Text = text;
        }

        public string Text { get; set; }

        public int SenderId { get; set;  }

        public Account Sender { get; set; }

        public int ReciverId { get; set; }

        public Account Reciver { get; set; }

    }
}
