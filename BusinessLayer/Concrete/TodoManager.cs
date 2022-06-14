﻿using BusinessLayer.Abstract;
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
        public List<Todo> GetListTodo(string session)
        {
            return _todoDal.List(x => x.Contact.RecevierMail == session && x.TodoStatus == true);//alıcı
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

    }
        
}
