using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetList();
        Contact GetById(int id);
        void ContactAddBL(Contact contact);
        void ContactDelete(Contact contact);
        void ContactUpdate(Contact contact);
    }
}
