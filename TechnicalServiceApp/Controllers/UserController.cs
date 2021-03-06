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
using System.Web;
using System.Web.Mvc;

namespace TechnicalServiceApp.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        UserManager userManager = new UserManager(new EfUserDal());
        UserValidator userValidator = new UserValidator();
        public ActionResult Index()
        {
            return View();
        }
   
        public ActionResult GetListUser(int p=1)// Admin panelinde tüm kullanıcıları gösterir.
        {
            var userValues = userManager.GetList().ToPagedList(p, 6);
            return View(userValues);
        }
        public ActionResult UserInfoTopMenu()
        {
            string p = (string)Session["UserMail"];
            var userInfo = userManager.GetListInfoUser(p);
            return PartialView(userInfo);
        }
        public ActionResult UserSettingsLayoutPartial()
        {
            string p = (string)Session["UserMail"];
            var userInfo = userManager.GetListInfoUser(p);
            return PartialView(userInfo);
        }
        public ActionResult UserProfile()
        {
            string p = (string)Session["UserMail"];
            var userProfile = userManager.GetListInfoUser(p);
            return View(userProfile);
        }
        [HttpGet]
        public ActionResult UserEdit(int id)
        {
            var userEdit = userManager.GetById(id);
            return View(userEdit);
        }
        [HttpPost]
        public ActionResult UserEdit(User p)
        {

            ValidationResult results = userValidator.Validate(p);
            if (results.IsValid)
            {
                userManager.UserUpdate(p);
                return RedirectToAction("UserProfile");
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
        public ActionResult UserChangePassword(int id)
        {
            var pass = userManager.GetById(id);
            return View(pass);

        }
        //x=>x.mail==admin.mail >> detail dan çıkarttım çünkü admin başkalarının maillerini ve şifrelerine
        //erişebiliyordu.
        [HttpPost]
        public ActionResult UserChangePassword(User user)
        {
            ValidationResult results = userValidator.Validate(user);
            using (Context db = new Context())
            {
                var detail = db.Users.Where(x => x.UserPassword == user.UserPassword && x.UserMail == user.UserMail && 
                x.UserNewPassword != user.UserNewPassword && user.UserNewPassword!=null).FirstOrDefault();
                if (detail != null)
                {
                    detail.UserPassword = user.UserNewPassword;
                    db.SaveChanges();
                    ViewBag.Message = "Şifre Güncelleme Başarılı!";
                    return RedirectToAction("UserProfile");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                    ViewBag.Message = "Tekrar Deneyiniz!";
                }
            }
            return View(user);
        }
        public ActionResult UserStatus(int id)
        {
            var userStatus = userManager.GetById(id);
            if (userStatus.UserStatus == false)
            {
                userStatus.UserStatus = true;
                userManager.UserDelete(userStatus);
                return RedirectToAction("GetListUser");
            }
            else
            {
                userStatus.UserStatus = false;
                userManager.UserDelete(userStatus);
                return RedirectToAction("GetListUser");
            }
          
        }
        [HttpGet]
        public ActionResult AdminPageUserEdit(int id)
        {
            var userEdit = userManager.GetById(id);
            return View(userEdit);
        }
        [HttpPost]
        public ActionResult AdminPageUserEdit(User p)
        {

            ValidationResult results = userValidator.Validate(p);
            if (results.IsValid)
            {
                userManager.UserUpdate(p);
                return RedirectToAction("GetListUser");
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
        public ActionResult UserAdd()
        {
            return View();
        }      
        [HttpPost]
        public ActionResult UserAdd(User user)
        {
            userManager.UserAddBL(user);
            return RedirectToAction("GetListUser");
        }
        public ActionResult ActiveUserList(int p = 1)
        {
            var active = userManager.GetUserStatusTrue().ToPagedList(p, 10);
            return View(active);
        }
        public ActionResult PasifUserList(int p = 1)
        {
            var active = userManager.GetUserStatusFalse().ToPagedList(p, 10);
            return View(active);
        }
    }
}