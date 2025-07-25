using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();
        void ContentAdd(Content content);
        Content GetByID(int ID);
        void DeleteContent(Content content);
        void UpdateContent(Content content);
        List<Content> GetListByHeadingID(int id);
        List<Content> GetListByWriterID(int id);
        List<Content> GetAllWithIncludes(); // Include ile ilişkili verileri getirmek için

    }
}
