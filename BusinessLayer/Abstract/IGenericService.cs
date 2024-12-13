using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> 
    {
        void TAdd(T t);
        void TDelete(T t);
        void TUpdate(T t);
        List<T> GetList();

        T GetById (int id);

        List<T> GetListbyFilter();  // generate  interface dediğimizde bu method da  gelsin diye ekledik
                                    //Tüm managerlarda hata döneceği için ekmelek gerekecek 
    }       
}
