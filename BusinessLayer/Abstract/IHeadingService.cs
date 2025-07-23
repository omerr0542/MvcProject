using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetAll();
        List<Heading> GetListByWriter(int id);
        void HeadingAdd(Heading heading);
        Heading GetById(int id);
        void HeadingDelete(Heading heading);
        void HeadingUpdate(Heading heading);
        List<Heading> GetAllWithIncludes(); // Include ile ilişkili verileri getirmek için
        Heading GetByIdWithIncludes(int id); // Include ile ilişkili verileri getirmek için
        List<Heading> GetListByWriterWithIncludes(int id);
    }
}
