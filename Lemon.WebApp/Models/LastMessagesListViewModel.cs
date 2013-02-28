namespace Lemon.WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Lemon.Common;
    using Lemon.DataAccess.DomainModels;

    public class LastMessagesListViewModel
    {
        public int CurrentUserId { get; set; }
        public List<Message> LastMessages;
        public List<string> PartnerEmail;

        public LastMessagesListViewModel()
        {}

       public LastMessagesListViewModel(int currUserId, List<Message> messages,List<string> partnerEmail)
       {
           this.CurrentUserId = currUserId;
           this.LastMessages=messages;
           this.PartnerEmail = partnerEmail;
       }
    }

    
}