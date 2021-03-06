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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;
        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public Contact GetById(int id)
        {
            return _contactDal.Get(x => x.ContactId == id);
        }
        public List<Contact> GetList()
        {
            return _contactDal.List();
        }  
      
        public List<Contact> GetListInbox(string session)
        {
            return _contactDal.List(x => x.RecevierMail == session && x.ContactStatus == true);//alıcı
        }

        public List<Contact> GetListSendbox(string session)
        {
            return _contactDal.List(x => x.SenderMail == session && x.ContactStatus == true); //gönderen
        }
        public List<Contact> GetListTrash(string session) //Çöp Kutusundaki mesajları listele
        {
            return _contactDal.List(x => x.RecevierMail== session  && x.ContactStatus == false); //Alıcı çöp kutusu
        }
        public void ContactAddBL(Contact contact)
        {
            _contactDal.Insert(contact);
        }

        public void ContactDelete(Contact contact)
        {
            _contactDal.Update(contact);
        }

        public void ContactUpdate(Contact contact)
        {
            _contactDal.Update(contact);
        }

        public List<Contact> GetReadList(string session)
        {
            return _contactDal.List(x => x.IsRead == true && x.RecevierMail == session);
        }

        public List<Contact> GetUnReadList(string session)
        {
            return _contactDal.List(x => x.RecevierMail == session && x.IsRead == false);
        }

        public List<Contact> IsDraft(string session)
        {
            return _contactDal.List(x => x.IsDraft == true && x.SenderMail == session);
        }

        public List<Contact> GetListDraft(string session)
        {
            return _contactDal.List(x => x.IsDraft == true && x.SenderMail == session);
        }

        public List<Contact> GetListTrash()
        {
            return _contactDal.List(x => x.Trash == true);
        }

       

        public List<Contact> GetListContent(string p)
        {
            return _contactDal.List(x => x.Contents.Contains(p));
        }
    }
}
