using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TechnicalServiceApp.Controllers
{
    public class TodoController : Controller
    {
        // GET: Todo
        TodoManager todoManager = new TodoManager(new EfTodoDal());
        public ActionResult Index()
        {
            var todoValues = todoManager.GetList();
            return View(todoValues);
        }
    }
}