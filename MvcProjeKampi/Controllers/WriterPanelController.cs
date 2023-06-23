using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        Context context = new Context();

        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeading(string p)
        {
            p = (string)Session["WriterMail"];
            var WriterID = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();

            var values = hm.GetListByWriter(WriterID);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> ValueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();


            ViewBag.VLC = ValueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string mail = (string)Session["WriterMail"];
            var WriterID = context.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();

            heading.HeadingDate = DateTime.Now;
            heading.WriterID = WriterID;
            heading.HeadingStatus = true;
            hm.HeadingAdd(heading);
            return RedirectToAction("MyHeading", "WriterPanel");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> ValueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.VLC = ValueCategory;

            var HeadingValue = hm.GetByID(id);
            return View(HeadingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Now;
            hm.HeadingUpdate(heading);
            return RedirectToAction("MyHeading", "WriterPanel");
        }

        public ActionResult DeleteHeading(int id)
        {
            var HeadingValue = hm.GetByID(id);
            hm.HeadingDelete(HeadingValue);
            return RedirectToAction("MyHeading", "WriterPanel");
        }
    }
}