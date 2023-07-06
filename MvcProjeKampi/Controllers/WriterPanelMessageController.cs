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
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();
        Context context = new Context();

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

        public ActionResult Inbox()
        {
            string mail = (string)Session["WriterMail"];

            var MessageListIn = mm.GetListInbox(mail);
            return View(MessageListIn);
        }

        public ActionResult Sendbox()
        {
            string mail = (string)Session["WriterMail"];

            var MessageListSend = mm.GetListSendbox(mail).OrderByDescending(x => x.MessageDate).ToList();
            return View(MessageListSend);
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
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult results = messagevalidator.Validate(message);
            string mail = (string)Session["WriterMail"];
            var WriterID = context.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();

            if (results.IsValid)
            {
                message.MessageDate = DateTime.Now;
                message.SenderMail = mail;
                mm.MessageAdd(message);
                return RedirectToAction("Sendbox", "WriterPanelMessage");
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
    }
}