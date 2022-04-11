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

namespace TechnicalServiceApp.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator contactValidator = new ContactValidator();
        public ActionResult Inbox()
        {
            string p = (string)Session["AdminMail"];
            var messageList = contactManager.GetListInbox(p);
            return View(messageList);
        }
        public ActionResult Sendbox()
        {
            string p = (string)Session["AdminMail"];
            var messageList = contactManager.GetListInbox(p);
            return View(messageList);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult NewMessage(Contact p, string menuName)
        {
            string session = (string)Session["AdminUserName"];
            ValidationResult results =contactValidator.Validate(p);
            if (menuName == "send")
            {
                if (results.IsValid)
                {
                    p.SenderMail = session;
                    p.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    contactManager.ContactAddBL(p);
                    return RedirectToAction("SendBox");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else if (menuName == "draft")//Taslak
            {
                if (results.IsValid)
                {
                    p.SenderMail = session;
                    p.IsDraft = true;
                    p.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    contactManager.ContactAddBL(p);
                    return RedirectToAction("DraftMessages");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else if (menuName == "cancel")
            {
                return RedirectToAction("NewMessage");
            }
            return View();
        }
        public ActionResult DraftMessages()
        {
            string session = (string)Session["AdminUserName"];
            var result = contactManager.IsDraft(session);
            return View(result);
        }
        public ActionResult GetDraftDetails(int id)
        {
            var result = contactManager.GetById(id);
            return View(result);
        }
        public ActionResult IsRead(int id)
        {
            var contactValue = contactManager.GetById(id);
            if (contactValue.IsRead)
            {
                contactValue.IsRead = false;
            }
            else
            {
                contactValue.IsRead = true;
            }
            contactManager.ContactUpdate(contactValue);
            return RedirectToAction("Inbox");
        }
    }
}