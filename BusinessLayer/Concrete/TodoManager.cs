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
    public class TodoManager : ITodoService
    {
        ITodoDal _todoDal;
        public TodoManager(ITodoDal todoDal)
        {
            _todoDal = todoDal;
        }
        public Todo GetById(int id)
        {
            return _todoDal.Get(x => x.TodoId == id);
        }

        public List<Todo> GetList()
        {
            return _todoDal.List();
        }
        public List<Todo> OcakList()// OCAK AYINDA ALINAN GÖREVLER
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 01);
        }
        public List<Todo> OcakDoneList() //OCAK AYINDA TAMAMLANAN GÖREVLER
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 01 && x.Done == true);
        }
        public List<Todo> SubatList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 02);
        }
        public List<Todo> SubatDoneList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 02 && x.Done == true);
        }
        public List<Todo> MartList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 03);
        }
        public List<Todo> MartDoneList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 03 && x.Done == true);
        }
        public List<Todo> NisanList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 04);
        }
        public List<Todo> NisanDoneList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 04 && x.Done == true);
        }
        public List<Todo> MayısList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 05);
        }
        public List<Todo> MayısDoneList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 05 && x.Done == true);
        }
        public List<Todo> HaziranList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 06);
        }
        public List<Todo> HaziranDoneList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 06 && x.Done == true);
        }
        public List<Todo> TemmuzList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 07);
        }
        public List<Todo> TemmuzDoneList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 07 && x.Done == true);
        }
        public List<Todo> AgustosList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 08);
        }
        public List<Todo> AgustosDoneList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 08 && x.Done == true);
        }
        public List<Todo> EylülList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 09);
        }
        public List<Todo> EylülDoneList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 09 && x.Done == true);
        }
        public List<Todo> EkimList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 10);
        }
        public List<Todo> EkimDoneList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 10 && x.Done == true);
        }
        public List<Todo> KasımList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 11);
        }
        public List<Todo> KasımDoneList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 11 && x.Done == true);
        }
        public List<Todo> AralıkList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 12 && x.Done == true);
        }
        public List<Todo> AralıkDoneList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 12);
        }
        public List<Todo> GetListTodo(string session)
        {
            return _todoDal.List(x => x.Contact.RecevierMail == session && x.TodoStatus == true && x.TodoDelete == false);
        }
        public void TodoAddBL(Todo todo)
        {
            _todoDal.Insert(todo);
        }

        public void TodoDelete(Todo todo)
        {
            _todoDal.Update(todo);
        }

        public void TodoUpdate(Todo todo)
        {
            _todoDal.Update(todo);
        }

        public List<Todo> GetTodoStatusTrue()
        {
            return _todoDal.List(x => x.TodoStatus == true);
        }
        public List<Todo> GetTodoStatusFalse()
        {
            return _todoDal.List(x => x.TodoStatus == false);
        }
        public List<Todo> GetTodoDoneTrue()
        {
            return _todoDal.List(x => x.Done == true);
        }
        public List<Todo> GetTodoDoneFalse()
        {
            return _todoDal.List(x => x.Done == false);
        }
        public List<Todo> GetTodoWorkingTrue()
        {
            return _todoDal.List(x => x.Working == true);
        }
        public List<Todo> GetTodoWorkingFalse()
        {
            return _todoDal.List(x => x.Working == false);
        }

        // TAMAMLANMAYAN GÖREVLER
        public List<Todo> OcakDontList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 01 && x.Done == false);
        }

        public List<Todo> SubatDontList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 02 && x.Done == false);
        }
        public List<Todo> MartDontList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 03 && x.Done == false);
        }

        public List<Todo> NisanDontList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 04 && x.Done == false);
        }

        public List<Todo> MayısDontList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 05 && x.Done == false);
        }

        public List<Todo> HaziranDontList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 06 && x.Done == false);
        }
        public List<Todo> TemmuzDontList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 07 && x.Done == false);
        }
        public List<Todo> AgustosDontList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 08 && x.Done == false);
        }

        public List<Todo> EylülDontList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 09 && x.Done == false);
        }

        public List<Todo> EkimDontList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 10 && x.Done == false);
        }

        public List<Todo> KasımDontList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 11 && x.Done == false);
        }

        public List<Todo> AralıkDontList()
        {
            return _todoDal.List(x => x.Contact.ContactDate.Month == 12 && x.Done == false);
        }
    }

}
