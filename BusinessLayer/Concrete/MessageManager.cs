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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public List<Message> GetList()
        {
            return _messageDal.GetList();
        }

        public List<Message> GetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TAdd(Message t)
        {
            _messageDal.Insert(t);
        }

        public void TDelete(Message t)
        {
            _messageDal.Delete(t);      
        }

        public void TUpdate(Message t)
        {
           _messageDal.Update(t);
        }
    }
}
