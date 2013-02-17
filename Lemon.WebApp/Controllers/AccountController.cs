using System.Web.Mvc;

namespace Lemon.WebApp.Controllers
{
    using System;

    using Lemon.DataAccess.DomainModels;
    using Lemon.DataAccess.Repositories; 
    using Lemon.WebApp.Models;
    using Lemon.WebApp.Services;

    public class AccountController : Controller
    {
        private readonly IAuthService authService;
        private readonly IAccountService accountService;

        public AccountController(IAuthService authService, IAccountService accountService)
        {
            this.authService = authService;
            this.accountService = accountService;
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
                if(authService.Validate(model.Email, model.Password))
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
                model = currentUser.Id == user.Id ? new ProfileViewModel(user, true) : new ProfileViewModel(user, false);
            }
            else
            {
                model = new ProfileViewModel(user, false);
            }
            
            return this.View(model);
        }
    }

    public class ProfileViewModel
    {
        public ProfileViewModel(Account user, bool isEditable)
        {
            IsExist = user != null;
            IsEditable = isEditable;
        }

        public bool IsEditable { get; set; }

        public bool IsExist { get; set; }
    }
}
