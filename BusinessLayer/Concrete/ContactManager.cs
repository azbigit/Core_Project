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
    public class ContactManager:IGenericService<Contact>
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public Contact GetById(int id)
        {
          return _contactDal.GetById(id);
        }

        public List<Contact> GetList()
        {
            return _contactDal.GetList();
        }

        public List<Contact> GetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TAdd(Contact t)
        {
           _contactDal.Insert(t);
        }

        public void TDelete(Contact t)
        {
           _contactDal.Delete(t);

        }

        public void TUpdate(Contact t)
        {
            _contactDal.Update(t);
        }
    }
}
