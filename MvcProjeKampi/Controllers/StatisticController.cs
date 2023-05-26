using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticController : Controller
    {
        Context context = new Context();
        // GET: Statistic
        public ActionResult Index()
        {
            ViewBag.TKS = context.Categories.Count();
            ViewBag.YKS = context.Headings.Where(x => x.CategoryID == 7).Count();
            ViewBag.AYS = context.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.EBS = context.Headings.Max(x => x.Category.CategoryName);
            ViewBag.TF = context.Categories.Where(x => x.CategoryStatus == true).Count() - context.Categories.Where(x => x.CategoryStatus == false).Count();
            return View();
        }
    }
}