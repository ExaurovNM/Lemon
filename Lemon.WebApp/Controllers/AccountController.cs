using System.Web.Mvc;

namespace Lemon.WebApp.Controllers
{
    using Lemon.DataAccess.Repositories;
    using Lemon.WebApp.Models;

    public class AccountController : Controller
    {
        private readonly IAccountRepository accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
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
                accountRepository.Create(model.Email, model.Password);
            }
            return View();
        }
    }
}
