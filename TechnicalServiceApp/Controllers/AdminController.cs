using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TechnicalServiceApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetListAdmin()
        {
            var adminValues = adminManager.GetList();
            return View(adminValues);
        }
    }
}