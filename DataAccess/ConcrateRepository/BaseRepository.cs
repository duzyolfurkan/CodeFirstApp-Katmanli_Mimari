using DataAccess.Context;
using Entities.Abstract;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ConcrateRepository
{
    //<T> koyunca generic yapı oluşturuldu.
    //where T: class dendiğinde bu generic yapının class olması zorunluluğu getirildi.
    //Bu gelen classların IBaseEntity tipinde olması gerektiğini söyledim.

    //Baserepository bizim CRUD işlemlerimizi üstlenecek sınıftır.
    public class BaseRepository<T> where T : class, IBaseEntity
    {
        private readonly CodeFirstDbContext _codeFirstDbContext; // Ekleme, silme, güncelleme işlemleri için buna ihtiyacım var.
        private DbSet<T> _table;

        //School gelirse school dbsete taecher gelirse teacher dbsete 
        public BaseRepository(CodeFirstDbContext codeFirstDbContext)
        {
            _codeFirstDbContext = codeFirstDbContext;
            _table = _codeFirstDbContext.Set<T>();
        }

        public bool Add(T entity)
        {
            _table.Add(entity);
            return Save() > 0;
        }

        public bool Delete(T entity)
        {
            //Veritabanından veriler silinmez statüsü değiştirilir.
            entity.status = Status.Deleted;
            return Update(entity);

            //Komple silme işlemi bu şekilde yapılır.
            //_table.Remove(entity);
            //return Save() > 0;
        }

        public bool Update(T entity)
        {
            _codeFirstDbContext.Entry<T>(entity).State = EntityState.Modified;
            return Save() > 0;
        }

        public List<T> GetAll()
        {
            return _table.Where(x => x.status == Status.Active || x.status == Status.Modified).ToList();
        }

        public T GetById(int id)
        {
            return _table.Find(id);
        }

        public bool AddRange(List<T> entities)
        {
            _table.AddRange(entities);
            return Save() > 0;
        }


        public int Save()
        {
            return _codeFirstDbContext.SaveChanges();
        }
    }
}
