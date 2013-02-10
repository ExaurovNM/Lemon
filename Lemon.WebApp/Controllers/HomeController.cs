using System.Web.Mvc;

namespace Lemon.WebApp.Controllers
{
    using System.Linq;

    using Lemon.WebApp.Models;
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
            var model = new MainPageViewModel
                { 
                    Orders = this.orderService.Items().Select(order => new OrderViewModel(order)).ToList() 
                };
            return View(model);
        }
    }
}
