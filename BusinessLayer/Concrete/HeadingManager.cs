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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;
        
        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public List<Heading> GetAll()
        {
            return _headingDal.List(); 
        }

        public Heading GetById(int id)
        {
            return _headingDal.Get(h => h.HeadingID == id);
        }

        public void HeadingAdd(Heading heading)
        {
            _headingDal.Insert(heading);
        }

        public void HeadingDelete(Heading heading)
        {
            _headingDal.Delete(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public List<Heading> GetAllWithIncludes()
        {
            return _headingDal.ListWithIncludes(x => x.Category, x => x.Writer);
        }

        public Heading GetByIdWithIncludes(int id)
        {
            return _headingDal.FilterWithIncludes(x => x.HeadingID == id, x => x.Category, x => x.Writer)[0];
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _headingDal.List(x => x.WriterID == id);
        }

        public List<Heading> GetListByWriterWithIncludes(int id)
        {
            return _headingDal.FilterWithIncludes(x => x.WriterID == id, x => x.Category, x => x.Writer);
        }
    }
}
