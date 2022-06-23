using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TechnicalServiceApp.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        UserManager userManager = new UserManager(new EfUserDal());
        TodoManager todoManager = new TodoManager(new EfTodoDal());
        public ActionResult Index()
        {
            return View();
        }
       public ActionResult Statistic()
        {
            var active = userManager.GetUserStatusTrue().Count();
            ViewBag.active = active;
           
            var passive = userManager.GetUserStatusFalse().Count();
            ViewBag.passive = passive;

            var todoTrue = todoManager.GetTodoStatusTrue().Count();
            ViewBag.todoTrue = todoTrue;

            var todoFalse = todoManager.GetTodoStatusFalse().Count();
            ViewBag.todoFalse = todoFalse;

            var doneFalse = todoManager.GetTodoDoneFalse().Count();
            ViewBag.doneFalse = doneFalse;

            var doneTrue = todoManager.GetTodoDoneTrue().Count();
            ViewBag.doneTrue = doneTrue;

            var workTrue = todoManager.GetTodoWorkingTrue().Count();
            ViewBag.workTrue = workTrue;

            var workFalse = todoManager.GetTodoStatusFalse().Count();
            ViewBag.workFalse = workFalse;
            return View();
        }
    }
}