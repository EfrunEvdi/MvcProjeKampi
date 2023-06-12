using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
            return PartialView();
        }
    }
}