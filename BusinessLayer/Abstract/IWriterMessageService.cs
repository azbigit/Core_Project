using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterMessageService:IGenericService<WriterMessage>,IWriterMessageDal
    {
        List<WriterMessage> GetListSenderMessage(string p);// sınıfa özel metot tanımlandı
        List<WriterMessage> GetListRecieverMessage(string p);
    }
}
