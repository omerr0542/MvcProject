using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {

        //GenericRepository<Category> _genericRepository;
        //public CategoryManager(GenericRepository<Category> genericRepository)
        //{
        //    //_genericRepository = genericRepository;
        //}

        ICategoryDal _categoryDal;
        
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetList()
        {
            return _categoryDal.List(); // GenericRepository yerine ICategoryDal kullanıyoruz
        }

        public void CategoryAddBL(Category category)
        {
            _categoryDal.Insert(category); // GenericRepository yerine ICategoryDal kullanıyoruz    
        }

        public Category GetByID(int ID)
        {
            return _categoryDal.Get(x => x.CategoryID == ID); // GenericRepository yerine ICategoryDal kullanıyoruz
        }

        public void DeleteCategory(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void UpdateCategoty(Category category)
        {
            _categoryDal.Update(category);
        }

        //public List<Category> GetAllBL()
        //{
        //    return _genericRepository.List();
        //}

        //public Category GetById(int id)
        //{
        //    return _genericRepository.List(x => x.CategoryID == id).FirstOrDefault();
        //}

        //public void CategoryAddBL(Category category)
        //{
        //    //İş kuralları burada kontrol edilebilir
        //    if (category.CategoryName == "" || category.CategoryName.Length <= 3 || category.CategoryName.Length > 50)
        //    {
        //        throw new Exception("Kategori adı uygun değildir.");
        //    }
        //    else if (category.CategoryDescription.Length > 200)
        //    {
        //        throw new Exception("Kategori açıklaması 200 karakterden fazla olamaz.");
        //    }
        //    else
        //    {
        //        _genericRepository.Insert(category);
        //    }
        //}

        //public void Update(Category category)
        //{
        //    _genericRepository.Update(category);
        //}

        //public void Delete(Category category)
        //{
        //    _genericRepository.Delete(category);
        //}
    }
}
