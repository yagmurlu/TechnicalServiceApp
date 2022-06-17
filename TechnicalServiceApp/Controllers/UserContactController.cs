using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
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
    public class UserContactController : Controller
    {
        // GET: WriterContact
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator contactValidator = new ContactValidator();

        public ActionResult Inbox()
        {           
            string p = (string)Session["UserMail"];
            var messageList = contactManager.GetListInbox(p);
            return View(messageList);
        }

        public ActionResult Sendbox()
        {
            string p = (string)Session["UserMail"];
            var messageList = contactManager.GetListSendbox(p);
            return View(messageList);
        }
        public ActionResult Trash() //Çöp Kutusu
        {
            string p = (string)Session["UserMail"];
            var messageList = contactManager.GetListTrash(p);
            return View(messageList);
        }

        public PartialViewResult UserContactPartial()
        {
            string p = (string)Session["UserMail"];
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
            //var spamMail = contactManager.GetListSpam(p).Count();//spam
            //ViewBag.spamMail = spamMail;

            return PartialView();
        }


        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Contact p, string menuName)
        {
            string session = (string)Session["UserMail"];
            ValidationResult results = contactValidator.Validate(p);
            if (menuName == "send")
            {
                if (results.IsValid)
                {
                    p.SenderMail = session;
                    p.RecevierMail = "admin@gmail.com";
                    p.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    p.ContactStatus = true;
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

        public ActionResult DraftMessages() // Taslak
        {
            string session = (string)Session["UserMail"];
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
        public ActionResult UserContactDelete(int id) //Aslında statu değiştirme olacak
        {
            var delete = contactManager.GetById(id);
            if (delete.ContactStatus == true)
            {
                delete.ContactStatus = false;
                contactManager.ContactDelete(delete);
                return RedirectToAction("Inbox");
            }
            return RedirectToAction("Inbox");
        }
    }
}