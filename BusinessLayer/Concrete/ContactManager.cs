using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        public void ContactAddBL(Contact contact)
        {
            throw new NotImplementedException();
        }

        public void ContactDelete(Contact contact)
        {
            throw new NotImplementedException();
        }

        public void ContactUpdate(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Contact GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
