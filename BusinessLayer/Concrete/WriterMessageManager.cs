using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterMessageManager : IWriterMessageDal
    {
        IWriterMessageDal _writerMessageDal;

        public WriterMessageManager(IWriterMessageDal writerMessageDal)
        {
            _writerMessageDal = writerMessageDal;
        }

        public List<WriterMessage> GetListSenderMessage(string p)
        {
            return _writerMessageDal.GetbyFilter(x => x.Sender == p);
        }

        public List<WriterMessage> GetListRecieverMessage(string p)
        {
            return _writerMessageDal.GetbyFilter(x => x.Reciver == p);
        }

        public void Delete(WriterMessage t)
        {
             _writerMessageDal.Delete(t);
        }

        public List<WriterMessage> GetbyFilter(Expression<Func<WriterMessage, bool>> filter)
        {
            return _writerMessageDal.GetList();
        }

        public WriterMessage GetById(int id)
        {
            return _writerMessageDal.GetById(id);
        }

        public List<WriterMessage> GetList()
        {
            return _writerMessageDal.GetList();
        }

        public void Insert(WriterMessage t)
        {
            _writerMessageDal.Insert(t);
        }

        public void Update(WriterMessage t)
        {
            _writerMessageDal.Update(t);
        }
    }
}
