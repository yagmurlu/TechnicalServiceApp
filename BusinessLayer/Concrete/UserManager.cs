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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public User GetById(int id)
        {
            return _userDal.Get(x => x.UserId == id);
        }

        public List<User> GetList()
        {
            return _userDal.List();
        }

        public void UserAddBL(User user)
        {
            _userDal.Insert(user);
        }

        public void UserDelete(User user)
        {
            _userDal.Delete(user);
        }

        public void UserUpdate(User user)
        {
            _userDal.Update(user);
        }  
        public List<User> GetListInfoUser(string session)
        {
            return _userDal.List(x => x.UserMail == session);
        }
    }
}
