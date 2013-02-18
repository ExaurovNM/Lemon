namespace Lemon.WebApp.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using Lemon.DataAccess.DomainModels;

    public class MyOrdersViewModel
    {
        public MyOrdersViewModel(List<Order> orders)
        {
            this.Orders = orders.Select(order => new OrderViewModel(order)).ToList();
        }

        public List<OrderViewModel> Orders { get; set; } 
    }
}