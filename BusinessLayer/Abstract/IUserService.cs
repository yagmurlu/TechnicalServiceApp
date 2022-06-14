using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        List<User> GetList();
        User GetById(int id);
        void UserAddBL(User user);
        void UserDelete(User user);
        void UserUpdate(User user);
        List<User> GetListInfoUser(string session);
        List<User> GetUserStatusTrue();
        List<User> GetUserStatusFalse();
    }
}
