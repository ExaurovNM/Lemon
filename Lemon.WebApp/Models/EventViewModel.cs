namespace Lemon.WebApp.Models
{
    using Lemon.DataAccess.DomainModels;

    public class EventViewModel
    {
        public EventViewModel(UserEvent evend)
        {
            this.Description = evend.Description;
        }

        public string Description { get; set; }
    }
}