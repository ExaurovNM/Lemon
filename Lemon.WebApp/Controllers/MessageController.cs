using Lemon.DataAccess.DomainModels;
using Lemon.WebApp.Models;
using Lemon.WebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lemon.WebApp.Controllers
{
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
                List<Message> listOfMessage = this.messageService.MessagesBetweenUsers(
                    id, this.authService.GetCurrentUser().Id);
                string senderEmail = this.authService.GetCurrentUser().Email;
                string recieverEmail = this.accountService.GetById(id).Email;
                var messages = new MessagesViewModel(listOfMessage, id, senderEmail, recieverEmail);
                return this.View(messages);
            }
            return this.RedirectToAction("UserProfile", "Account", new { @id = id });
        }
        public ActionResult SendMessage(int id)
        {
            if (id != this.authService.GetCurrentUser().Id)
            {
                return this.View(new CreateMessageModel{recieverId = id});
            }
            return this.RedirectToAction("UserProfile", "Account", new { @id = id });
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
