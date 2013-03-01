namespace Lemon.WebApp.Models
{
    using System.Collections.Generic;

    public class LastMessagesListViewModel
    {
        public int CurrentUserId { get; set; }

        public List<MessageViewModel> LastMessages { get; set; }
    }
}