namespace Lemon.WebApp.Controllers
{
    using System.Web.Mvc;

    using Lemon.WebApp.Models;
    using Lemon.WebApp.Services;

    [Authorize]
    public class MyController : Controller
    {
        private readonly IAuthService authService;
        private readonly IOrderService orderService;
        private readonly IUserEventsService eventsService;

        public MyController(IAuthService authService, IOrderService orderService, IUserEventsService eventsService)
        {
            this.authService = authService;
            this.orderService = orderService;
            this.eventsService = eventsService;
        }

        [HttpGet]
        public ActionResult Orders()
        {
            var user = authService.GetCurrentUser();
            var orders = orderService.GetByUserId(user.Id);
            var model = new MyOrdersViewModel(orders);

            return View(model);
        }

        public ActionResult Events()
        {
            var id = authService.GetCurrentUserId();
            if (id == null)
            {
                return RedirectToRoute("Home");
            }
            var items = eventsService.GetByUserId(id.Value);
            var model = new MyEventsViewModel(items);

            return this.View(model);
        }
    }
}
