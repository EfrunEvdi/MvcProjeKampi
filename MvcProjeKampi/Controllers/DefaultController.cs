using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());

        public ActionResult Headings()
        {
            var headingList = headingManager.GetList();
            return View(headingList);
        }

        public PartialViewResult ContentByHeading(int id = 0)
        {
            var contentList = contentManager.GetListByHeadingID(id);
            ViewBag.BA = contentList.Where(x => x.HeadingID == id).Select(y => y.Heading.HeadingName).FirstOrDefault();
            return PartialView(contentList);
        }
    }
}