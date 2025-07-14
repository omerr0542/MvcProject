using DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    // T değeri class olmak zorunda ve referans tip olmalı
    public class GenericRepository<T> : IRepository<T> where T: class
    {
        Context c;
        DbSet<T> _object;

        public GenericRepository(Context context)
        {
            c = context; // Context sınıfından gelen DbSet<T> tipindeki nesneyi c değişkenine atıyoruz.
            _object = c.Set<T>(); // Context sınıfından gelen DbSet<T> tipindeki nesneyi _object değişkenine atıyoruz.
                                  // Bu sayede dışarıdan gelen entity sınıflarını GenericRepository içinde kullanabiliyoruz.
        }

        public void Delete(T p)
        {
            var deletedEntity = c.Entry(p);
            deletedEntity.State = EntityState.Deleted;
            //_object.Remove(p); 
            c.SaveChanges();
        }

        public void Insert(T p)
        {
            // Bu şekilde eklenen obje otomatik olacak save changes fonksiyonu ile otomatik olarak eklenmiş olacak. Bu şekilde add işlemine ihtiyac duymayacağız.
            var addedEntity = c.Entry(p);
            addedEntity.State = EntityState.Added;
            // _object.Add(p);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter); // Filtreye uyan tek bir nesne döndürür, eğer yoksa null döner
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            if (filter == null)
            {
                return _object.ToList(); // Eğer filtre yoksa tüm verileri listele
            }
            else
            {
                return _object.Where(filter).ToList(); // Filtre varsa, filtreye uyan verileri listele
            }
        }

        public void Update(T p)
        {
            var modifiedEntity = c.Entry(p);
            modifiedEntity.State = EntityState.Modified;
            //_object.Update(p);
            c.SaveChanges(); // Değişiklikleri kaydet
        }

        public List<T> ListWithIncludes(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _object;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.ToList();
        }
    }
}
