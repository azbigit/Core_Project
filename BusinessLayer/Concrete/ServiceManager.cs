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
    public class ServiceManager : IGenericService<Service>
    {
        IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public Service GetById(int id)
        {
            return _serviceDal.GetById(id);
        }

        public List<Service> GetList()
        {
            return _serviceDal.GetList();
        }

        public List<Service> GetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TAdd(Service t)
        {
            _serviceDal.Insert(t);       
        }

        public void TDelete(Service t)
        {
            _serviceDal.Delete(t);
        }

        public void TUpdate(Service t)
        {
            _serviceDal.Update(t);
        }
    }
}
