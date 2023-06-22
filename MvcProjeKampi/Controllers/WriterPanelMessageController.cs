﻿using BusinessLayer.Concrete;
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
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
        public ActionResult Inbox()
        {
            var MessageListIn = mm.GetListInbox();
            return View(MessageListIn);
        }

        public ActionResult Sendbox()
        {
            var MessageListSend = mm.GetListSendbox();
            return View(MessageListSend);
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var Values = mm.GetByID(id);
            return View(Values);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var Values = mm.GetByID(id);
            return View(Values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult results = messagevalidator.Validate(message);

            if (results.IsValid)
            {
                message.MessageDate = DateTime.Now;
                mm.MessageAdd(message);
                return RedirectToAction("Sendbox", "WriterPanelMessage");
            }

            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(message);
        }
    }
}