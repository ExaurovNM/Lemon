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
        public ActionResult SendMessage(int id)
        {
            if (id == authService.GetCurrentUser().Id)
                return RedirectToAction("UserProfile", "Account", new { @id = id });
            List<Message> listOfMessage = messageService.MessagesBetweenUsers(id, authService.GetCurrentUser().Id);
            string senderEmail = authService.GetCurrentUser().Email;
            string recieverEmail = accountService.GetById(id).Email;
            var messages = new MessageViewModel(listOfMessage, id, senderEmail, recieverEmail);
            return View(messages);
        }

        [HttpPost]
        public ActionResult SendMessage(CreateMessageModel model)
        {
            if (ModelState.IsValid)
            {

                messageService.AddMessage(new Message(authService.GetCurrentUser().Id, model.recieverId, model.Text));
            }
            return RedirectToAction("SendMessage", "Message", new { @id = model.recieverId });
        }

        public ActionResult All()
        {
            int currentUserId = authService.GetCurrentUser().Id;
            List<Message> Messages = messageService.LastMessages(currentUserId);
            List<string> partnerEmail=new List<string>();
            foreach (Message message in Messages)
                partnerEmail.Add(accountService.GetById(message.SenderId==currentUserId?message.ReciverId:message.SenderId).Email);
            return View(new LastMessagesListViewModel(currentUserId,Messages,partnerEmail));
        }
    }
}
