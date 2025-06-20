using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        GenericRepository<Category> _genericRepository = new GenericRepository<Category>();

        public List<Category> GetAllBL()
        {
            return _genericRepository.List();
        }

        public Category GetById(int id)
        {
            return _genericRepository.List(x => x.CategoryID == id).FirstOrDefault();
        }

        public void CategoryAddBL(Category category)
        {
            // İş kuralları burada kontrol edilebilir
            if(category.CategoryName == "" || category.CategoryName.Length <= 3 || category.CategoryName.Length > 50)
            {
                throw new Exception("Kategori adı uygun değildir.");
            }
            else if (category.CategoryDescription.Length > 200)
            {
                throw new Exception("Kategori açıklaması 200 karakterden fazla olamaz.");
            }
            else
            {
                _genericRepository.Insert(category);
            }
        }

        public void Update(Category category)
        {
            _genericRepository.Update(category);
        }

        public void Delete(Category category)
        {
            _genericRepository.Delete(category);
        }
    }
}
