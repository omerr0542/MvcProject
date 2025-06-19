using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryDal : IRepository<Category> 
    {
        // Bunun yerine IRepository<Category> kullanabilirdik ama bu şekilde de yazabiliriz. Best Practice IRepository
        //List<Category> List();
        //void Insert(Category p);
        //void Update(Category p);
        //void Delete(Category p);
    }
}
