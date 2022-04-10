using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
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
    }
}