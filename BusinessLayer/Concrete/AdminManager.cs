using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;
      
        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }
        public void AdminAddBL(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public void AdminDelete(Admin admin)
        {
            _adminDal.Update(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            _adminDal.Update(admin);
        }

        public Admin GetById(int id)
        {
            return _adminDal.Get(x => x.AdminId == id);
        }

        public List<Admin> GetList()
        {
           return _adminDal.List();
        }
        public List<Admin> GetListInfoAdmin(string session)
        {
            return _adminDal.List(x => x.AdminMail == session);
        }
        public List<Admin> GetUserStatusTrue()
        {
            return _adminDal.List(x => x.AdminStatus == true);
        }
        public List<Admin> GetUserStatusFalse()
        {
            return _adminDal.List(x => x.AdminStatus == false);
        }
    }
}
