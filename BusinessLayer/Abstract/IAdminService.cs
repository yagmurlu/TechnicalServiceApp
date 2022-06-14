using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetList();
        Admin GetById(int id);
        void AdminAddBL(Admin admin);
        void AdminDelete(Admin admin);
        void AdminUpdate(Admin admin);
        List<Admin> GetListInfoAdmin(string session);
        List<Admin> GetUserStatusTrue();
        List<Admin> GetUserStatusFalse();
    }
}
