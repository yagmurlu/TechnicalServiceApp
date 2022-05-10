using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
        AdminValidator validations = new AdminValidator();
       
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetListAdmin()
        {
            var adminValues = adminManager.GetList();
            return View(adminValues);
        }
        public ActionResult AdminInfoTopMenu()
        {
            string p = (string)Session["AdminMail"];
            var adminInfo = adminManager.GetListInfoAdmin(p);
            return PartialView(adminInfo);
        }
        public ActionResult AdminSettings()
        {
            string p = (string)Session["AdminMail"];
            var adminSettings = adminManager.GetListInfoAdmin(p);
            return View(adminSettings);
        }
        public ActionResult AdminProfile()
        {
            string p = (string)Session["AdminMail"];
            var adminProfile = adminManager.GetListInfoAdmin(p);
            return View(adminProfile);
        }
        [HttpGet]
        public ActionResult AdminEdit(int id = 1)
        {
            var adminEdit = adminManager.GetById(id);
            return View(adminEdit);
        }
        [HttpPost]
        public ActionResult AdminEdit(Admin p)
        {

            ValidationResult results = validations.Validate(p);
            if (results.IsValid)
            {
                adminManager.AdminUpdate(p);
                return RedirectToAction("AdminProfile");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult ChangePassword(int id = 1)
        {
            var pass = adminManager.GetById(id);
            return View(pass);

        }


        //x=>x.mail==admin.mail >> detail dan çıkarttım çünkü admin başkalarının maillerini ve şifrelerine
        //erişebiliyordu.
        [HttpPost]
        public ActionResult ChangePassword(Admin admin)
        {
            ValidationResult results = validations.Validate(admin);
            using (Context db = new Context())
            {
                var detail = db.Admins.Where(x => x.AdminPassword == admin.AdminPassword && x.AdminMail == admin.AdminMail && x.AdminNewPassword !=admin.AdminNewPassword ).FirstOrDefault();


                if (detail != null)
                {
                    detail.AdminPassword = admin.AdminNewPassword;
                    db.SaveChanges();
                    ViewBag.Message = "Şifre Güncelleme Başarılı!";
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                    ViewBag.Message = " Hata Oluştu!";
                }



            }
            return View(admin);
        }

    }
}