using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        // GET: Writer
        public ActionResult Index()
        {
            var WriterValues = wm.GetList();
            return View(WriterValues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            WriterValidator WriterValidator = new WriterValidator();
            ValidationResult results = WriterValidator.Validate(writer);

            if (results.IsValid)
            {
                wm.WriterAdd(writer);
                return RedirectToAction("Index", "Writer");
            }

            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var WriterValues = wm.GetByID(id);
            return View(WriterValues);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer writer)
        {
            WriterValidator WriterValidator = new WriterValidator();
            ValidationResult results = WriterValidator.Validate(writer);

            if (results.IsValid)
            {
                wm.WriterUpdate(writer);
                return RedirectToAction("Index", "Writer");
            }

            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
    }
}