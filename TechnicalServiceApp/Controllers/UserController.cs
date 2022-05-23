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
        public ActionResult GetListUser()// Admin panelinde tüm kullanıcıları gösterir.
        {
            var userValues = userManager.GetList();
            return View(userValues);
        }
        public ActionResult UserInfoTopMenu()
        {
            string p = (string)Session["UserMail"];
            var userInfo = userManager.GetListInfoUser(p);
            return PartialView(userInfo);
        }
    }
}