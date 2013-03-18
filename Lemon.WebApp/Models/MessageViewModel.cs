namespace Lemon.WebApp.Models
{
    using System;

    using Lemon.DataAccess.DomainModels;

    public class MessageViewModel
    {
        public MessageViewModel(Message message)
        {
            Text = message.Text;
            Created = message.CreatedTime;
            ReciverId = message.ReceiverId;
            SenderId = message.SenderId;
            SenderEmail = message.Sender.Email;
            ReciverEmail = message.Receiver.Email;
        }

        public string Text { get; set; }

        public DateTime Created { get; set; }

        public int SenderId { get; set; }

        public int ReciverId { get; set; }

        public string SenderEmail { get; set; }

        public string ReciverEmail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CorrespondenceEmail { get; set; }

        public int CorrespondenceId { get; set; }

        public bool IsLastMessageFromCurrentUser { get; set; }

        public void UpdateCorrespondence(int currentUserId)
        {
            CorrespondenceEmail = currentUserId == SenderId ? ReciverEmail : SenderEmail;
            CorrespondenceId = currentUserId == SenderId ? ReciverId : SenderId;
            IsLastMessageFromCurrentUser = currentUserId == SenderId;
        }
    }
}