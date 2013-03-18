using System.Linq;
using System.Web.Mvc;

using Lemon.DataAccess.DomainModels;
using Lemon.WebApp.Models;
using Lemon.WebApp.Services;

namespace Lemon.WebApp.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly IAuthService authService;
        private readonly IMessageService messageService;
        private readonly IAccountService accountService;

        public MessageController(IAuthService authService, IMessageService messageService, IAccountService accountService)
        {
            this.authService = authService;
            this.messageService = messageService;
            this.accountService = accountService;
        }

        public ActionResult CorrespondenceWithUser(int id)
        {
            if (id != this.authService.GetCurrentUser().Id)
            {
                var listOfMessage = this.messageService.MessagesBetweenUsers(
                    id, this.authService.GetCurrentUser().Id);
                var senderUserName = this.authService.GetCurrentUser().UserName;
                var recieverUserName = this.accountService.GetById(id).UserName;
                var messages = new MessagesViewModel(listOfMessage, id, senderUserName, recieverUserName);
                return this.View(messages);
            }

            return this.RedirectToAction("UserProfile", "Account", new { id });
        }

        public ActionResult SendMessage(int id)
        {
            if (id != this.authService.GetCurrentUser().Id)
            {
                return this.View(new CreateMessageModel { recieverId = id });
            }

            return this.RedirectToAction("UserProfile", "Account", new { id });
        }

        [HttpPost]
        public ActionResult SendMessage(CreateMessageModel model)
        {
            if (ModelState.IsValid)
            {
                messageService.AddMessage(new Message(authService.GetCurrentUser().Id, model.recieverId, model.Text));
            }

            return RedirectToAction("CorrespondenceWithUser", "Message", new { @id = model.recieverId });
        }

        public ActionResult All()
        {
            int currentUserId = authService.GetCurrentUser().Id;
            var messages = messageService.LastMessages(currentUserId);
            var model = new LastMessagesListViewModel
                {
                    CurrentUserId = currentUserId,
                    LastMessages = messages.Select(message => new MessageViewModel(message)).ToList(),
                };

            foreach (var message in model.LastMessages)
            {
                message.UpdateCorrespondence(currentUserId);
            }

            return View(model);
        }
    }
}
