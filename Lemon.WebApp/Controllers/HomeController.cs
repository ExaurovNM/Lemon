using System.Web.Mvc;

namespace Lemon.WebApp.Controllers
{
    using System;
    using System.Linq;

    using Lemon.WebApp.Models;
    using Lemon.WebApp.Services;
    using SportsStore.WebUI.Models;

    public class HomeController : Controller
    {
        private const int DefaultPageSize = 5;
        private readonly IOrderService orderService;

        public HomeController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public ActionResult Index(string searchQuery, int page = 1)
        {
            var allOrders = this.orderService.GetBySearchString(searchQuery, DefaultPageSize, page);
            var model = new MainPageViewModel
                {
                    Orders = allOrders.Select(order => new OrderViewModel(order)).ToList(),
                    PagingInfo = new PagingInfo { CurrentPage = page, TotalItems = allOrders.Count(), ItemsPerPage = DefaultPageSize },
                    SearchString = searchQuery
                };
            return View(model);
        }
    }
}
