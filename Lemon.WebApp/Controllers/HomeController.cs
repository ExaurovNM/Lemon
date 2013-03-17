using System.Web.Mvc;

namespace Lemon.WebApp.Controllers
{
    using System.Linq;

    using Lemon.DataAccess.DomainModels;
    using Lemon.WebApp.Models;
    using Lemon.WebApp.Services;

    using SportsStore.WebUI.Models;

    public class HomeController : Controller
    {
        private int pageSize = 5;
        private readonly IOrderService orderService;

        public HomeController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public ActionResult Index(string searchString, int page = 1)
        {
            var allOrders = this.orderService.GetBySearchString(searchString);
            var model = new MainPageViewModel
                {
                    Orders = allOrders.Skip((page - 1) * pageSize).Select(order => new OrderViewModel(order)).ToList(),
                    PagingInfo = new PagingInfo { CurrentPage = page, TotalItems = allOrders.Count(), ItemsPerPage = pageSize },
                    SearchString = searchString
                };
            return View(model);
        }
    }
}
