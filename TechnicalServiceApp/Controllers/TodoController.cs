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
        [HttpGet]
        public ActionResult Completed(Contact p, int id) // Tamamlandı 
        {
            string session = (string)Session["AdminMail"];
            var value = todoManager.GetById(id);
            if (value.Done == false)
            {
                if (true)
                {
                    p.SenderMail = session;
                    p.RecevierMail = value.Contact.SenderMail;
                    p.Heading = "Tamamlandı";
                    p.Contents = "iletildi";
                    p.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    p.ContactStatus = true;
                    contactManager.ContactAddBL(p);
                    value.Done = true;
                    todoManager.TodoUpdate(value);
                    return RedirectToAction("Index");
                }
            }
            return View("Index"); // Go to INDEX
        }
        [HttpGet]
        public ActionResult RequestReceived(Contact p, int id) //Talep Alındı
        {
            string session = (string)Session["AdminMail"];
            var value = todoManager.GetById(id);
            if (value.Done == false)
            {
                if (true)
                {
                    p.SenderMail = session;
                    p.RecevierMail = value.Contact.SenderMail;
                    p.Heading = "Talep Alındı";
                    p.Contents = "Talebiniz Üzerinde Çalışıyoruz";
                    p.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    p.ContactStatus = true;
                    contactManager.ContactAddBL(p);
                    value.Working = true;
                    todoManager.TodoUpdate(value);
                    return RedirectToAction("Index");
                }
            }
            return View("Index"); // Go to INDEX
        }
        public ActionResult TodoReport() // Rapor Sayfası
        {
            var todoValues = todoManager.GetList();
            return View(todoValues);
        }
        public ActionResult TodoDelete(int id) //Aslında statu değiştirme olacak
        {
            var delete = todoManager.GetById(id);
            if (delete.TodoStatus == true)
            {
                delete.TodoStatus = false;
                todoManager.TodoDelete(delete);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddTodoContact(Todo todo, int id) // Contact dan todo ya mesaj ekleme
        {
            todo.Done = false;
            todo.Working = false;
            todo.TodoStatus = true;
            todo.ContactId = id;
            todoManager.TodoAddBL(todo);
            //todo = todoManager.GetList().Find(x => x.ContactId == id);
            //todoManager.TodoAddBL(todo);
            return RedirectToAction("Index", "Todo");
        }

        //[HttpGet]
        //public ActionResult AddTodo()
        //{
        //    return View();

        //}
        //[HttpPost]
        //public ActionResult AddTodo(Todo todo)
        //{
        //    todoManager.TodoAddBL(todo);
        //    return RedirectToAction("Index");
        //}
    }
}