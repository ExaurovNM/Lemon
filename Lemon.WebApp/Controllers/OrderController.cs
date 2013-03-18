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
        private readonly IRatingService ratingService;

        public OrderController(IAuthService authService, IOrderService orderService, IRatingService ratingService)
        {
            this.authService = authService;
            this.orderService = orderService;
            this.ratingService = ratingService;
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
            var user = authService.GetCurrentUser();
            var canComment = orderService.IsCanComment(user.Id, id);
            var model = new OrderViewModel(order, canComment);
            model.IsOwnOrder = this.authService.GetCurrentUser().Id == order.CreaterId;
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
        public ActionResult AcceptOffer(int orderId, int employeeId)
        {
            if (this.authService.GetCurrentUser().Id == this.orderService.GetById(orderId).CreaterId)
            {
                this.orderService.AcceptOffer(orderId, employeeId);
            }
            return this.RedirectToAction("Details", "Order", new { @id = orderId });
        }

        public ActionResult CompleteOrder(int id)
        {
            if (orderService.GetById(id).CreaterId == authService.GetCurrentUser().Id)
            {
                return View(new CompleteOrderViewModel { OrderId = id });
            }
            return this.RedirectToAction("Details", "Order", new { @id = id });
        }

        [HttpPost]
        public ActionResult CompleteOrder(CompleteOrderViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            ratingService.AddRaiting(
                new UserRating
                    {
                        Comment = model.Comment,
                        Rating = (bool)model.Raiting,
                        RatingSenderId = this.authService.GetCurrentUser().Id,
                        RatingReceiverId = (int)this.orderService.GetById(model.OrderId).EmployeeId
                    });
            orderService.ChangeOrderStatus(model.OrderId, OrderStatus.Completed);
            return this.RedirectToAction("Details", "Order", new { @id = model.OrderId });
        }
    }
}
