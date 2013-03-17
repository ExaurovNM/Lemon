namespace Lemon.WebApp.Models
{
    using SportsStore.WebUI.Models;
using System.Collections.Generic;

    public class MainPageViewModel
    {
        public List<OrderViewModel> Orders { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string SearchString { get; set; }
    }
}