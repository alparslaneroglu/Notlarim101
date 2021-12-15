using Notlarım101.DataAccessLayer.EntityFramework;
using Notlarım101.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notlarım101.BusinessLayer
{
    public class CategoryManager
    {
        Repository<Category> rcat = new Repository<Category>();
        public List<Category> GetCategories()
        {
            return rcat.List();
        }
    }
}
