using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TechnicalServiceApp.Controllers
{
    [AllowAnonymous]
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
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminMail,false);
                Session["AdminMail"] = adminUserInfo.AdminMail;
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
                FormsAuthentication.SetAuthCookie(userInfo.UserMail, false);
                Session["UserMail"] = userInfo.UserMail;
                return RedirectToAction("UserProfile", "User");
            }
            else
            {
                return RedirectToAction("UserLogin", "Login");
            }

        }
        public ActionResult AdminLogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AdminLogin", "Login");
        }
        public ActionResult UserLogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("UserLogin", "Login");
        }

    }
}