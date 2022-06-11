using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace TechnicalServiceApp.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        // GET: Todo
        TodoManager todoManager = new TodoManager(new EfTodoDal());
        ContactManager contactManager = new ContactManager(new EfContactDal());
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            string p = (string)Session["AdminMail"];
            var todoList = todoManager.GetListTodo(p);
            return View(todoList);
            //var todoValues = todoManager.GetList();
            //return View(todoValues);
        }
        [HttpPost]
        public ActionResult Completed(Todo todo) // Tamamlandı
        {

            //string session = (string)Session["AdminMail"];
            //var value = todoManager.GetById(id);
            //if (todo.Done)
            //{

            //    value.Done = true;
            //    value.Contact.Contents = "iletildi";
            //    todoManager.TodoDone(todo, session);
            //}

            //return RedirectToAction("Index"); // Go to INDEX


            //var result = contactManager.GetById(id);
            //
            //if (completed=="comp")
            //{
            //    contact.SenderMail = session;
            //    contact.RecevierMail = result.ToString();
            //    contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            //    contact.Contents = "İşlemeniz Tamamlanmıştır. İyi Günler Dileriz";

            //    contactManager.ContactAddBL(contact);
            //}

            return View();
        }
        [HttpPost]
        public ActionResult RequestReceived() //Talep Alındı
        {
            return View();
        }
        public ActionResult TodoReport()
        {
            var todoValues = todoManager.GetList();
            return View(todoValues);
        }
        public ActionResult TodoDelete(int id)
        {
            var delete = todoManager.GetById(id);
            todoManager.TodoDelete(delete);
            return RedirectToAction("Index");
        }
        //[HttpGet]
        //public ActionResult AddTodoContact() // Contact dan todo ya mesaj ekleme
        //{
        //    return View();
        //}
        [HttpGet]
        public ActionResult AddTodoContact(int id) // Contact dan todo ya mesaj ekleme
        {
            
            var value = contactManager.GetList().Find(x => x.ContactId == id);
            
            return View(value);
        }

        [HttpGet]
        public ActionResult AddTodo()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddTodo(Todo todo)
        {
            todoManager.TodoAddBL(todo);
            return RedirectToAction("Index");
        }
    }
}