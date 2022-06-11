using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TechnicalServiceApp.Controllers
{
   
    public class RegisterController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        UserManager userManager = new UserManager(new EfUserDal());
        // GET: Register
        [Authorize]
        [HttpGet]
        public ActionResult AdminRegister()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult AdminRegister(Admin admin)
        {
            adminManager.AdminAddBL(admin);
            return RedirectToAction("Admin","GetListAdmin");
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult UserRegister()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult UserRegister(User user)
        {

            userManager.UserAddBL(user);
            return RedirectToAction("UserLogin","Login");
        }
    }
}