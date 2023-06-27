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
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        Context context = new Context();
        public ActionResult MyContent(string p)
        {

            p = (string)Session["WriterMail"];
            var WriterIDInfo = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();

            TempData["ID"] = WriterIDInfo;


            var ContentValues = cm.GetListByWriter(WriterIDInfo);
            ViewBag.UN = context.Writers.Where(x => x.WriterID == WriterIDInfo).Select(y => y.WriterName + " " + y.WriterSurname).FirstOrDefault();
            ViewBag.PP = context.Writers.Where(x => x.WriterID == WriterIDInfo).Select(y => y.WriterImage).FirstOrDefault();

            return View(ContentValues);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.ID = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string p = (string)Session["WriterMail"];
            var WriterIDInfo = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();

            content.ContentDate= DateTime.Now;
            content.ContentStatus = true;
            content.WriterID = WriterIDInfo;
            cm.ContentAdd(content);
            return RedirectToAction("MyContent", "WriterPanelContent");
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}