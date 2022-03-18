using BusinessLayer.Abstract;
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
        public Todo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Todo> GetList()
        {
            throw new NotImplementedException();
        }

        public void TodoAddBL(Todo todo)
        {
            throw new NotImplementedException();
        }

        public void TodoDelete(Todo todo)
        {
            throw new NotImplementedException();
        }

        public void TodoUpdate(Todo todo)
        {
            throw new NotImplementedException();
        }
    }
}
