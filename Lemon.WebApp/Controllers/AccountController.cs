using System.Web.Mvc;

namespace Lemon.WebApp.Controllers
{
    using System;

    using Lemon.WebApp.Models;
    using Lemon.WebApp.Services;

    public class AccountController : Controller
    {
        private readonly IAuthService authService;
        private readonly IAccountService accountService;
        private readonly IRatingService ratingService;

        public AccountController(IAuthService authService, IAccountService accountService, IRatingService ratingService)
        {
            this.authService = authService;
            this.accountService = accountService;
            this.ratingService = ratingService;
        }

        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    authService.CreateAccount(model.Email, model.Password);
                }
                catch (ArgumentException)
                {
                    ModelState.AddModelError("Email", "Этот e-mail уже используется.");
                    return View(model);
                }

                authService.Logon(model.Email);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Logon()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logon(LogonViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (authService.Validate(model.Email, model.Password))
                {
                    authService.Logon(model.Email, model.Remember);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Пароль или емеил неправильные. Повторите ввод.");
                return View(model);
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            authService.Logout();
            return RedirectToAction("Index", "Home");
        }


        public ActionResult UserProfile(int id)
        {
            var user = accountService.GetById(id);
            var currentUser = authService.GetCurrentUser();
            ProfileViewModel model;
            if (currentUser != null && user != null)
            {
                model = currentUser.Id == user.Id ? new ProfileViewModel(user, true, id, this.ratingService.GetPositiveRatingForUser(id), this.ratingService.GetNegativeRatingForUser(id), this.ratingService.GetAllCommentsForUser(id)) : new ProfileViewModel(user, false, id, this.ratingService.GetPositiveRatingForUser(id), this.ratingService.GetNegativeRatingForUser(id), this.ratingService.GetAllCommentsForUser(id));
            }
            else
            {
                model = new ProfileViewModel(user, false, id, this.ratingService.GetPositiveRatingForUser(id), this.ratingService.GetNegativeRatingForUser(id), this.ratingService.GetAllCommentsForUser(id));
            }

            return this.View(model);
        }
    }
}
