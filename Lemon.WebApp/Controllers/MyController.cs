using System;
using System.Web;
using System.Web.Mvc;

namespace Lemon.WebApp.Controllers
{
    using Lemon.WebApp.Models;
    using Lemon.WebApp.Services;

    [Authorize]
    public class MyController : Controller
    {
        private readonly IAuthService authService;

        private readonly IOrderService orderService;

        public MyController(IAuthService authService, IOrderService orderService)
        {
            this.authService = authService;
            this.orderService = orderService;
        }

        [HttpGet]
        public ActionResult Orders()
        {
            var user = authService.GetCurrentUser();
            var orders = orderService.GetByUserId(user.Id);
            var model = new MyOrdersViewModel(orders);

            return View(model);
        }
    }
}
