using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            Context context = new Context();
            var adminuserinfo = context.Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);

            if (adminuserinfo != null)
            {
                return RedirectToAction("Index", "AdminCategory");
            }

            else
            {
                return View();
            }
        }
    }
}