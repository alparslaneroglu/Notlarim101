using Notlarım101.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Notlarım101.BusinessLayer
{
    public class Repository<T> where T : class //T nesnesi referans type olmadılır. Classlar da referans type olduğu için kısıtlı(kısıtlama yaptık farklı birşey gelmesin diye) olarak kullanılmıştır.
    {
        private NotlarimContext db = new NotlarimContext();
       private DbSet<T> objSet;
        public Repository()
        {
            objSet = db.Set<T>();
        }

        public List<T> List()//Yukarıya category  göndermiş olsak buraya category yazmamız gerekir
        {
            return objSet.ToList(); // Hangi nesne geleceğini bilmedğimiz için category  falan yazamıyoruz.
        }
        public List<T> List(Expression<Func<T, bool>> where) // where burada isim farklı birşeyde yazılabilir.
        {
            return objSet.Where(where).ToList();

        }
        public IQueryable<T> QList(Expression<Func<T, bool>> query) // where burada isim farklı birşeyde yazılabilir.
        {
            return objSet.Where(query);

        }

        public int Insert(T obj)
        {
            objSet.Add(obj);

            return Save();
        }



        public int Update(T obj)
        {
            return Save();
        }

        public int Delete(T obj)
        {
            objSet.Remove(obj);
            return Save();
        }
        public int Save()
        {
            return db.SaveChanges();

        }
    }
}
