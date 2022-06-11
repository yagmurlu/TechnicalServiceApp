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
        List<Contact> GetList();
        List<Contact> GetListContent(string p);
        List<Contact> GetListInbox(string session);
        List<Contact> GetListSendbox(string session);
        List<Contact> GetReadList(string session);//okundu
        List<Contact> GetUnReadList(string session);//okunmadı
        List<Contact> IsDraft(string session);//taslak
        List<Contact> GetListDraft(string session);
        List<Contact> GetListTrash();
        List<Contact> GetListSpam(string session);
        void ContactAddBL(Contact contact);
        void ContactDelete(Contact contact);
        void ContactUpdate(Contact contact);
    }
}
