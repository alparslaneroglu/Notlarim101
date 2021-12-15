using Notlarım101.DataAccessLayer;
using Notlarım101.DataAccessLayer.EntityFramework;
using Notlarım101.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notlarım101.BusinessLayer
{
    public class CategoryModel
    {
        NotlarimContext db = new NotlarimContext();
        public List<Category> List()
        {
            return db.Categories.ToList(); // liste olduğu için return bekliyor.
        }


        public void Insert(Category cat)
        {
            db.Categories.Add(cat);
            Save();
        }

        public void Update(int id)
        {
            var a = db.Categories.Find(id);
            a.Title = "dssdsd";

            Save();
        }
        public void Delete(int id)
        {
            var a = db.Categories.Find(id);
            db.Categories.Remove(a);

            Save();
        }
        private void Save()
        {
            db.SaveChanges();
        }
    }
}
