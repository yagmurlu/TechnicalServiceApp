using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TechnicalServiceApp.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        UserManager userManager = new UserManager(new EfUserDal());

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetListUser()
        {
            var userValues = userManager.GetList();
            return View(userValues);
        }
    }
}