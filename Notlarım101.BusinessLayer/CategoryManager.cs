using Notlarım101.BusinessLayer.Abstract;
using Notlarım101.DataAccessLayer.EntityFramework;
using Notlarım101.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notlarım101.BusinessLayer
{
    public class CategoryManager:ManagerBase<Category>
    {
        //Repository<Category> rcat = new Repository<Category>();
        //public List<Category> GetCategories()
        //{
        //    return rcat.List();
        //}

        public override int Delete(Category obj)
        {
            NoteManager nm = new NoteManager();

            //LikedManager
            //CommentManager bu managerlerıda new leyeceğiz.
            //Kategori ile ilgili notların silinmesi gerekecek.
            foreach (Note note in obj.Notes.ToList())
            {
                //Note ile ilişkili Like ların siklinmesi 
                foreach (Liked like in note.Likes.ToList())
                {
                    //lm.delete
                }
                //Note ile ilişkili Comment ların silinmesi
                foreach (Comment comment in note.Comments.ToList())
                {
                    //comm.delete
                }
                //nm.Delete(note);
            }
            return base.Delete(obj);
        }
    }
}
