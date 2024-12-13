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
    public class ToDoListManager : IGenericService<IToDoListService>
    {
        IToDoListDal _toDoListDal;

        public ToDoListManager(IToDoListDal toDoListDal)
        {
            _toDoListDal = toDoListDal;
        }

        public ToDoList GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ToDoList> GetList()
        {
            return _toDoListDal.GetList();
        }

        public List<IToDoListService> GetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TAdd(ToDoList t)
        {
            throw new NotImplementedException();
        }

        public void TAdd(IToDoListService t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(ToDoList t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(IToDoListService t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(ToDoList t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(IToDoListService t)
        {
            throw new NotImplementedException();
        }

        IToDoListService IGenericService<IToDoListService>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        List<IToDoListService> IGenericService<IToDoListService>.GetList()
        {
            throw new NotImplementedException();
        }
    }
}
