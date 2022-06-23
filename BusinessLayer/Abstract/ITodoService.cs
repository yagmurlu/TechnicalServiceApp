using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITodoService
    {
        List<Todo> GetList();
        List<Todo> OcakList();
        List<Todo> OcakDoneList();//Tamamlanan Görev
        List<Todo> OcakDontList();//Tamamlanmayan Görev
        List<Todo> SubatList();
        List<Todo> SubatDoneList();
        List<Todo> SubatDontList();
        List<Todo> MartList();
        List<Todo> MartDoneList();
        List<Todo> MartDontList();
        List<Todo> NisanList();
        List<Todo> NisanDoneList();
        List<Todo> NisanDontList();
        List<Todo> MayısList();
        List<Todo> MayısDoneList();
        List<Todo> MayısDontList();
        List<Todo> HaziranList();
        List<Todo> HaziranDoneList();
        List<Todo> HaziranDontList();
        List<Todo> TemmuzList();
        List<Todo> TemmuzDoneList();
        List<Todo> TemmuzDontList();
        List<Todo> AgustosList();
        List<Todo> AgustosDoneList();
        List<Todo> AgustosDontList();
        List<Todo> EylülList();
        List<Todo> EylülDoneList();
        List<Todo> EylülDontList();
        List<Todo> EkimList();
        List<Todo> EkimDoneList();
        List<Todo> EkimDontList();
        List<Todo> KasımList();
        List<Todo> KasımDoneList();
        List<Todo> KasımDontList();
        List<Todo> AralıkList();
        List<Todo> AralıkDoneList();
        List<Todo> AralıkDontList();
        List<Todo> GetListTodo( string session);
        Todo GetById(int id);
        void TodoAddBL(Todo todo);
        void TodoDelete(Todo todo);
        void TodoUpdate(Todo todo);
        List<Todo> GetTodoStatusTrue();    
        List<Todo> GetTodoStatusFalse();    
        List<Todo> GetTodoDoneTrue();    
        List<Todo> GetTodoDoneFalse();    
        List<Todo> GetTodoWorkingTrue();    
        List<Todo> GetTodoWorkingFalse();    

    }
}
