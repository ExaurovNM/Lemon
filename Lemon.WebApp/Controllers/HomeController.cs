using System.Web.Mvc;

namespace Lemon.WebApp.Controllers
{
    using System.Linq;

    using Lemon.DataAccess.DomainModels;
    using Lemon.WebApp.Models;
    using Lemon.WebApp.Services;

    public class HomeController : Controller
    {
        private readonly IOrderService orderService;

        public HomeController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public ActionResult Index(string searchString)
        {
            var model = new MainPageViewModel
                { 
                    Orders = this.orderService.GetBySearchString(searchString).Select(order => new OrderViewModel(order)).ToList() 
                };
            return View(model);
        }
    }
}
