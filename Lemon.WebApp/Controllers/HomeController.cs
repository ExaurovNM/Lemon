using System.Web.Mvc;

namespace Lemon.WebApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Lemon.Common;
    using Lemon.DataAccess.DomainModels;
    using Lemon.WebApp.Services;

    public class HomeController : Controller
    {
        private readonly IOrderService orderService;

        public HomeController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public ActionResult Index()
        {
            var model = new MainPageViewModel();
            model.Orders = orderService.Items().Select(order => new OrderViewModel(order)).ToList();
            return View(model);
        }
    }

    public class MainPageViewModel
    {
        public List<OrderViewModel> Orders { get; set; }
    }

    public class OrderViewModel
    {
        public OrderViewModel(Order order)
        {
            if (order == null)
            {
                return;
            }
            OwnerId = order.AccountId;
            Title = order.Title;
            Content = order.Content;
            OwnerDisplayName = order.Account.Email;
            CreatedTime = order.CretedTime;
            Id = order.Id;
        }

        public OrderViewModel()
        {
        }

        public int OwnerId { get; set; }

        public string OwnerDisplayName { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedTime { get; set; }

        public string CreatedTimeOut
        {
            get
            {
                return DateTimeHelper.GetOutTime(CreatedTime);
            }
        }

        public object Id { get; set; }
    }
}
