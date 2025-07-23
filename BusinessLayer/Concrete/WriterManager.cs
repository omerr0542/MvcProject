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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetById(int id)
        {
            return _writerDal.Get(List => List.WriterID == id); 
        }

        public List<Writer> GetList()
        {
            return _writerDal.List(); 
        }

        public void WriterAdd(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            _writerDal.Update(writer);
        }

        public bool Authorization(Writer writer)
        {
            if(writer == null)
                return false;

            return _writerDal.List(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword).Any();
        }
    }
}
