﻿using System.Web.Mvc;

namespace Lemon.WebApp.Controllers
{
    using Lemon.DataAccess.DomainModels;
    using Lemon.WebApp.Models;
    using Lemon.WebApp.Services;

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

        public ActionResult Details(int id)
        {
            var order = orderService.GetById(id);
            var model = new OrderViewModel(order);

            return View(model);
        }


        [HttpPost]
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
    }

    public class CreateCommentModel
    {
        public int OrderId { get; set; }

        public string Comment { get; set; }

        public OrderComment ConvertToDomain()
        {
            return new OrderComment { OrderId = OrderId, Comment = Comment };
        }
    }
}
