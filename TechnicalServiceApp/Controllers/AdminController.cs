using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;


namespace TechnicalServiceApp.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        AdminValidator validations = new AdminValidator();

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult GetListAdmin(int p=1)
        {
          
       
            var adminValues = adminManager.GetList().ToPagedList(p,6);
            return View(adminValues);
        }
        
        public ActionResult AdminInfoTopMenu()
        {
            string p = (string)Session["AdminMail"];
            var adminInfo = adminManager.GetListInfoAdmin(p);
            return PartialView(adminInfo);
        }
       
        public ActionResult AdminProfile()
        {
            string p = (string)Session["AdminMail"];
            
            var adminProfile = adminManager.GetListInfoAdmin(p);
            return View(adminProfile);
        }
        [HttpGet]
        public ActionResult AdminAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminAdd(Admin admin)
        {
            adminManager.AdminAddBL(admin);
            
            return RedirectToAction ("GetListAdmin");
        }

        [HttpGet]
        public ActionResult AdminEdit(int id)
        {
            var adminEdit = adminManager.GetById(id);
            return View(adminEdit);
        }
        
        [HttpPost]
        
        public ActionResult AdminEdit(Admin admin)
        {

            ValidationResult results = validations.Validate(admin);
            if (results.IsValid)
            {
                adminManager.AdminUpdate(admin);
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
        public ActionResult ChangePassword(int id)
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
                var detail = db.Admins.Where(x => x.AdminPassword == admin.AdminPassword && x.AdminMail == admin.AdminMail && x.AdminNewPassword != admin.AdminNewPassword &&admin.AdminNewPassword!=null).FirstOrDefault();


                if (detail != null)
                {
                    detail.AdminPassword = admin.AdminNewPassword;
                    db.SaveChanges();
                    ViewBag.Message = "Şifre Güncelleme Başarılı!";
                    return RedirectToAction("AdminProfile");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                    ViewBag.Message = " Tekrar Deneyiniz!";
                }



            }
            return View(admin);
        }
        public ActionResult AdminSettingsLayoutPartial()
        {
            string p = (string)Session["AdminMail"];
            var adminInfo = adminManager.GetListInfoAdmin(p);
            return PartialView(adminInfo);
        }
        [HttpGet]
        public ActionResult AdminPageAdminEdit(int id)
        {
            var adminEdit = adminManager.GetById(id);
            return View(adminEdit);
        }
        [HttpPost]
        public ActionResult AdminPageAdminEdit(Admin p)
        {

            ValidationResult results = validations.Validate(p);
            if (results.IsValid)
            {
                adminManager.AdminUpdate(p);
                return RedirectToAction("GetListAdmin");
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
        public ActionResult AdminStatus(int id)
        {
            var status = adminManager.GetById(id);
            if (status.AdminStatus == false)
            {
                status.AdminStatus = true;
                adminManager.AdminDelete(status);
                return RedirectToAction("GetListAdmin");
            }
            else
            {
                status.AdminStatus = false;
                adminManager.AdminDelete(status);
                return RedirectToAction("GetListAdmin");
            }

        }
        public ActionResult ActiveAdminList(int p = 1)
        {
            var active = adminManager.GetUserStatusTrue().ToPagedList(p, 10);
            return View(active);
        }
        public ActionResult PasifAdminList(int p = 1)
        {
            var active = adminManager.GetUserStatusFalse().ToPagedList(p, 10);
            return View(active);
        }
    }
}