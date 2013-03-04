using System.Web.Mvc;

namespace Lemon.WebApp.Controllers
{
    using Lemon.DataAccess.DomainModels;
    using Lemon.WebApp.Models;
    using Lemon.WebApp.Services;
    using Lemon.WebApp.WebHelpers;

    [Authorize]
    public class OrderController : Controller
    {
        private readonly IAuthService authService;
        private readonly IOrderService orderService;

        public OrderController(IAuthService authService, IOrderService orderService)
        {
            this.authService = authService;
            this.orderService = orderService;
        }

        public ActionResult Create()
        {
            var model = new OrderCreateViewModel();
            var user = authService.GetCurrentUser();
            model.UserId = user.Id;

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(OrderCreateViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            var user = this.authService.GetCurrentUser();
            if (user.Id != model.UserId)
            {
                this.ModelState.AddModelError(string.Empty, "Что-то тут не так... перегрузите страницу.");
                return this.View(model);
            }

            this.orderService.Create(model.GetDomain());

            return RedirectToAction("Index", "Home");
        }

        [ImportModelStateFromTempData]
        public ActionResult Details(int id)
        {
            var order = orderService.GetById(id);
            var model = new OrderViewModel(order);
            model.IsOwnOrder = authService.GetCurrentUser().Id == order.AccountId ? true : false;
            return View(model);
        }


        [HttpPost]
        [ExportModelStateToTempData]
        public ActionResult CreateComment(CreateCommentModel model)
        {
            if (ModelState.IsValid)
            {
                var domain = model.ConvertToDomain();
                domain.AuthorId = authService.GetCurrentUser().Id;
                orderService.AddCommentToOrder(domain);
                return RedirectToAction("Details", "Order", new { @id = model.OrderId });
            }

            return RedirectToAction("Details", "Order", new { @id = model.OrderId });
        }


        [HttpPost]
        public ActionResult AcceptOffer(int id)
        {
            if (this.authService.GetCurrentUser().Id == this.orderService.GetById(id).AccountId)
            {
                this.orderService.ChangeOrderStatus(id, OrderStatus.InProgress);
            }
            return RedirectToAction("Details", "Order", new { @id = id });
        }

        public ActionResult CloseOrder(int id)
        {
            if (orderService.GetById(id).AccountId == authService.GetCurrentUser().Id)
                return View(new CloseOrderViewModel{OrderId = id});
            else
                return RedirectToAction("Details", "Order", new { @id = id });
        }

        [HttpPost]
        public ActionResult CloseOrder(CloseOrderViewModel model)
        {
            if (!ModelState.IsValid) 
                return View(model);
            orderService.CloseOrder(model.OrderId);
            return RedirectToAction("Details", "Order", new { @id = model.OrderId });
        }
    }
}
