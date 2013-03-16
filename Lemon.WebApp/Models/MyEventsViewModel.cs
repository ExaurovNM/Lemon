namespace Lemon.WebApp.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using Lemon.DataAccess.DomainModels;

    public class MyEventsViewModel
    {
        public MyEventsViewModel(IList<UserEvent> items)
        {
            this.Events = items.Select(evend => new EventViewModel(evend)).ToList();
        }

        public List<EventViewModel> Events { get; set; }
    }
}