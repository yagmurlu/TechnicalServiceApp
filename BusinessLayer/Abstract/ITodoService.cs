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
        List<Todo> GetListTodo( string session);
        Todo GetById(int id);

        void TodoAddBL(Todo todo);
        void TodoDelete(Todo todo);
        void TodoUpdate(Todo todo);
        
    }
}
