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

namespace TechnicalServiceApp.Controllers
{
    [Authorize]
   
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
      
        public PartialViewResult ContactPartial()
        {
            string p = (string)Session["AdminMail"];
            var contact = contactManager.GetList().Count();
            ViewBag.contact = contact;

            var sendMail = contactManager.GetListSendbox(p).Count();
            ViewBag.sendMail = sendMail;

            var receiverMail = contactManager.GetListInbox(p);
            ViewBag.receiverMail = receiverMail.Count();

            var draftMail = contactManager.GetListDraft(p).Count();//taslak
            ViewBag.draftMail = draftMail;
            var trashMail = contactManager.GetListTrash().Count();//çöp
            ViewBag.trashMail = trashMail;

            var readMessage = contactManager.GetReadList(p).Count();
            ViewBag.readMessage = readMessage;

            var unreadMessage = contactManager.GetUnReadList(p).Count();
            ViewBag.unreadMessage = unreadMessage;
            var spamMail = contactManager.GetListSpam(p).Count();//spam
            ViewBag.spamMail = spamMail;

            return PartialView();
        }
  
        public ActionResult AdminContactTopMenu()
        {
            string p = (string)Session["AdminMail"];
            var messageList = contactManager.GetListInbox(p);
            
            ViewBag.messageList = messageList.Count();
            return PartialView(messageList);
        }
        public ActionResult UserContactTopMenu()
        {
            string p = (string)Session["UserMail"];
            var messageList = contactManager.GetListInbox(p);

            ViewBag.messageList = messageList.Count();
            return PartialView(messageList);
        }
        [HttpGet]

        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
  
        public ActionResult NewMessage(Contact p, string menuName)
        {
            string session = (string)Session["AdminMail"];
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
            string session = (string)Session["AdminMail"];
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
        
        public ActionResult GetInboxMessageDetails(int id) //Inbox Details
        {
            var contactValues = contactManager.GetById(id);
            return PartialView(contactValues);
        }
        public ActionResult GetSendboxMessageDetails(int id) //Sendbox Details
        {
            var sendValues = contactManager.GetById(id);
            return PartialView(sendValues);
        }
    }
}