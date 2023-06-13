using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        public ActionResult Inbox()
        {
            var MessageListIn = mm.GetListInbox();
            TempData["GKS"] = MessageListIn.Count();
            return View(MessageListIn);
        }

        public ActionResult Sendbox()
        {
            var MessageListSend = mm.GetListSendbox();
            TempData["OKS"] = MessageListSend.Count();
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
            message.MessageStatus = false;
            message.MessageIsDraft = false;
            message.MessageDate = DateTime.Now;
            mm.MessageAdd(message);
            return View();
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