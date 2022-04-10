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
        Contact GetById(int id);
        List<Contact> GetListInbox(string session);
        List<Contact> GetListSendbox(string session);
        void ContactAddBL(Contact contact);
        void ContactDelete(Contact contact);
        void ContactUpdate(Contact contact);
    }
}
