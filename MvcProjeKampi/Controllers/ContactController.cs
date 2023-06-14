using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        Context context = new Context();

        public ActionResult Index()
        {
            var ContactValues = cm.GetList();
            return View(ContactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var ContactValue = cm.GetByID(id);
            return View(ContactValue);
        }

        public ActionResult MessageListMenu()
        {
            ViewBag.CV = context.Contacts.Count();
            ViewBag.IV = context.Messages.Where(x => x.ReceiverMail == "admin@gmail.com").Count();
            ViewBag.SV = context.Messages.Where(x => x.SenderMail == "admin@gmail.com").Count();
            ViewBag.DV = context.Messages.Where(x => x.MessageIsDraft == false).Count();
            ViewBag.TV = context.Messages.Where(x => x.MessageStatus == false).Count();
            return PartialView();
        }
    }
}