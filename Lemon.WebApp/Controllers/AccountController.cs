using System.Web.Mvc;

namespace Lemon.WebApp.Controllers
{
    using Lemon.DataAccess.Repositories;
    using Lemon.WebApp.Models;
    using Lemon.WebApp.Services;

    public class AccountController : Controller
    {
        private readonly IAccountRepository accountRepository;
        private readonly IAuthService authService;

        public AccountController(IAccountRepository accountRepository, IAuthService authService)
        {
            this.accountRepository = accountRepository;
            this.authService = authService;
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
                authService.CreateAccount(model.Email, model.Password);
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
    }
}
