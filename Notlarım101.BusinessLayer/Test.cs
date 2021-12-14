using Notlarım101.DataAccessLayer;
using Notlarım101.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notlarım101.BusinessLayer
{
    public class Test
    {
        Repository<NotlarimUser> ruser = new Repository<NotlarimUser>();
        Repository<Category> rcat = new Repository<Category>();
        Repository<Comment> rcom = new Repository<Comment>();
        Repository<Note> rnote = new Repository<Note>();
        Repository<Liked> rlike = new Repository<Liked>();
        public Test()
        {
            //NotlarimContext db = new NotlarimContext();
            //db.NotlarimUsers.ToList();

            var test = rcat.List(); // List methoduna içerisine parametre vermezsek bütün liste gelecek.
            var test1 = rcat.List(x => x.Id > 5); // list olduğu için içeriğini gösteriyor.
            var test4 = test1.Where(x => x.Id > 3).ToList();
            var test2 = rcat.QList(x => x.Id > 5);//Sorguyu çalıştırıyor fakat sonuç göndermiyor.
            var test6 = rnote.List(x => x.Id > 5);
            var test3 = test2.ToList();
        }

    }
}
