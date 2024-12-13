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
    public class TestimonialManager : IGenericService<Testimonial>
    {
        ItestimonialDal _ıtestimonialDal;

        public TestimonialManager(ItestimonialDal ıtestimonialDal)
        {
            _ıtestimonialDal = ıtestimonialDal;
        }

        public Testimonial GetById(int id)
        {
            return _ıtestimonialDal.GetById(id);
        }

        public List<Testimonial> GetList()
        {
            return _ıtestimonialDal.GetList();
        }

        public List<Testimonial> GetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TAdd(Testimonial t)
        {
           _ıtestimonialDal.Insert(t);
        }

        public void TDelete(Testimonial t)
        {
            _ıtestimonialDal.Delete(t);
        }

        public void TUpdate(Testimonial t)
        {
           _ıtestimonialDal.Update(t);
        }
    }
}
