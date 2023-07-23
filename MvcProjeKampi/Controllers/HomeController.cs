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
    [AllowAnonymous]
    public class HomeController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult ContactUs()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult ContactUs(Message message)
        {
            message.MessageDate = DateTime.Now;
            message.ReceiverMail = "admin@gmail.com";
            message.MessageStatus = true;
            mm.MessageAdd(message);
            return PartialView("ContactUs");
        }
    }
}