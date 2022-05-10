using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TechnicalServiceApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin login)
        {
            Context context = new Context();
            var adminUserInfo = context.Admins.FirstOrDefault(x => x.AdminMail == login.AdminMail
              && x.AdminPassword == login.AdminPassword);
            if (adminUserInfo!=null)
            {
                return RedirectToAction("AdminProfile", "Admin");
            }
            else
            {
                return RedirectToAction("AdminLogin","Login");     
            }
            
        }
        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(User login)
        {
            Context context = new Context();
            var userInfo = context.Users.FirstOrDefault(x => x.UserMail == login.UserMail
              && x.UserPassword == login.UserPassword);
            if (userInfo != null)
            {
                return RedirectToAction("UserProfile", "Login");
            }
            else
            {
                return RedirectToAction("UserLogin", "Login");
            }

        }

    }
}