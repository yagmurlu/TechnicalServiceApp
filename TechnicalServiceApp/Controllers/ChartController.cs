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
    [Authorize]
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
            var active = userManager.GetUserStatusTrue().Count();//Aktif Kullanıcı
            ViewBag.active = active;
           
            var passive = userManager.GetUserStatusFalse().Count();//Pasij Kullanıcı
            ViewBag.passive = passive;

            var todoTrue = todoManager.GetTodoStatusTrue().Count();
            ViewBag.todoTrue = todoTrue;

            var todoFalse = todoManager.GetTodoStatusFalse().Count();
            ViewBag.todoFalse = todoFalse;

            var doneFalse = todoManager.GetTodoDoneFalse().Count();//Tamamlanmadı
            ViewBag.doneFalse = doneFalse;

            var doneTrue = todoManager.GetTodoDoneTrue().Count(); //Tamamlandı
            ViewBag.doneTrue = doneTrue;

            var workTrue = todoManager.GetTodoWorkingTrue().Count(); //Talep alındı
            ViewBag.workTrue = workTrue;

            //var workFalse = todoManager.GetTodoStatusFalse().Count();
            //ViewBag.workFalse = workFalse;


            //AYLIK TALEP ARTIŞI- AYNI AYDA TAMAMLANANve TAMAMLAMAYAN GÖREV SAYISI
            var ocakAyı = todoManager.OcakList().Count();
            ViewBag.ocakAyı = ocakAyı;
            var ocakTamamAyı = todoManager.OcakDoneList().Count();
            ViewBag.ocakTamamAyı = ocakTamamAyı;
            var ocakDont = todoManager.OcakDontList().Count();
            ViewBag.ocakDont = ocakDont;

            var subatAyı = todoManager.SubatList().Count();
            ViewBag.subatAyı = subatAyı;
            var subatTamamAyı = todoManager.SubatDoneList().Count();
            ViewBag.subatTamamAyı = subatTamamAyı;
            var subatDont = todoManager.SubatDontList().Count();
            ViewBag.subatDont = subatDont;

            var martAyı = todoManager.MartList().Count();
            ViewBag.martAyı = martAyı;
            var martTamamAyı = todoManager.MartDoneList().Count();
            ViewBag.martTamamAyı = martTamamAyı;
            var martDont = todoManager.MartDontList().Count();
            ViewBag.martDont = martDont;

            var nisanAyı = todoManager.NisanList().Count();
            ViewBag.nisanAyı = nisanAyı;
            var nisanTamamAyı = todoManager.NisanDoneList().Count();
            ViewBag.nisanTamamAyı = nisanTamamAyı;
            var nisanDont = todoManager.NisanDontList().Count();
            ViewBag.nisanDont = nisanDont;

            var mayısAyı = todoManager.MayısList().Count();
            ViewBag.mayısAyı = mayısAyı;
            var mayısTamamAyı = todoManager.MayısDoneList().Count();
            ViewBag.mayısTamamAyı = mayısTamamAyı;
            var mayısDont = todoManager.MayısDontList().Count();
            ViewBag.mayısDont = mayısDont;

            var haziranAyı = todoManager.HaziranList().Count();
            ViewBag.haziranAyı = haziranAyı;
            var haziranTamamAyı = todoManager.HaziranDoneList().Count();
            ViewBag.haziranTamamAyı = haziranTamamAyı;
            var haziranDont = todoManager.HaziranDontList().Count();
            ViewBag.haziranDont = haziranDont;

            var temmuzAyı = todoManager.TemmuzList().Count();
            ViewBag.temmuzAyı = temmuzAyı;
            var temmuzTamamAyı = todoManager.TemmuzDoneList().Count();
            ViewBag.temmuzTamamAyı = temmuzTamamAyı;
            var temmuzDont = todoManager.TemmuzDontList().Count();
            ViewBag.temmuzDont = temmuzDont;

            var agustosAyı = todoManager.AgustosList().Count();
            ViewBag.agustosAyı = agustosAyı;
            var agustosTamamAyı = todoManager.AgustosDoneList().Count();
            ViewBag.agustosTamamAyı = agustosTamamAyı;
            var agustosDont = todoManager.AgustosDontList().Count();
            ViewBag.agustosDont = agustosDont;

            var eylülAyı = todoManager.EylülList().Count();
            ViewBag.eylülAyı = eylülAyı;
            var eylülTamamAyı = todoManager.EylülDoneList().Count();
            ViewBag.eylülTamamAyı = eylülTamamAyı;
            var eylülDont = todoManager.EylülDontList().Count();
            ViewBag.eylülDont = eylülDont;

            var ekimAyı = todoManager.EkimList().Count();
            ViewBag.ekimAyı = ekimAyı;
            var ekimTamamAyı = todoManager.EkimDoneList().Count();
            ViewBag.ekimTamamAyı = ekimTamamAyı;
            var ekimDont = todoManager.EkimDontList().Count();
            ViewBag.ekimDont = ekimDont;

            var kasımAyı = todoManager.KasımList().Count();
            ViewBag.kasımAyı = kasımAyı;
            var kasımTamamAyı = todoManager.KasımDoneList().Count();
            ViewBag.kasımTamamAyı = kasımTamamAyı;
            var kasımDont = todoManager.KasımDontList().Count();
            ViewBag.kasımDont = kasımDont;

            var aralıkAyı = todoManager.AralıkList().Count();
            ViewBag.aralıkAyı = aralıkAyı;
            var aralıkTamamAyı = todoManager.AralıkDoneList().Count();
            ViewBag.aralıkTamamAyı = aralıkTamamAyı;
            var aralıkDont = todoManager.AralıkDontList().Count();
            ViewBag.aralıkDont = aralıkDont;

            return View();
        }
    }
}