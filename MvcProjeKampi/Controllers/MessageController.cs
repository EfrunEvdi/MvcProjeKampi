using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();
        Context context = new Context();

        public ActionResult Inbox()
        {
            string mail = (string)Session["WriterMail"];

            var MessageListIn = mm.GetListInbox(mail);
            return View(MessageListIn);
        }

        public ActionResult Sendbox()
        {
            string mail = (string)Session["WriterMail"];

            var MessageListSend = mm.GetListSendbox(mail);
            return View(MessageListSend);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult results = messagevalidator.Validate(message);

            if (results.IsValid)
            {
                message.MessageDate = DateTime.Now;
                mm.MessageAdd(message);
                return RedirectToAction("Sendbox", "Message");
            }

            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(message);
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var Values = mm.GetByID(id);
            return View(Values);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var Values = mm.GetByID(id);
            return View(Values);
        }

        [HttpGet]
        public ActionResult DraftMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DraftMessage(Message message)
        {
            message.MessageIsDraft = true;
            message.MessageDate = DateTime.Now;
            mm.BoolValue(message);
            return RedirectToAction("Sendbox", "Message");
        }
    }
}